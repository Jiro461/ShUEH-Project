import './style.css';
import { useState, useEffect } from 'react';
import RateShoe from "../RateShoe/RateShoe"

function ProfileOrdered() {
    const [orders, setOrders] = useState([]);
    const [showReviewDialog, setShowReviewDialog] = useState(false);
    const [selectedOrder, setSelectedOrder] = useState(null);
    const [rating, setRating] = useState(0);
    const [comment, setComment] = useState("");
    const [like, setLike] = useState(false);
    const [reviews, setReviews] = useState([]);
    const [user, setUser] = useState(null);
    const [shoeName, setShoeName] = useState(null);

    // Fetch UserId when component mounts
    useEffect(() => {
        const fetchUserId = async () => {
            try {
                const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Account/cookieGetById`, {
                    method: 'GET',
                    credentials: 'include', // Đảm bảo thông tin cookie được gửi
                });

                if (!response.ok) throw new Error("Không thể lấy UserId");

                const data = await response.json();
                setUser(data);  // Giả sử API trả về { id: 'user-id' }
            } catch (error) {
                console.error("Lỗi khi lấy UserId:", error);
            }
        };

        fetchUserId();
    }, []);


    // Fetch order data when the component mounts
    useEffect(() => {
        const fetchOrders = async () => {
            try {
                const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Order/user`, { credentials: "include" });
                if (!response.ok) throw new Error("Không thể lấy danh sách order");

                const data = await response.json();
                setOrders(data || []);
            } catch (error) {
                console.error("Lỗi khi lấy danh sách order:", error);
            }
        };

        fetchOrders();
    }, []);

    // Hàm gọi API để lấy các đánh giá cho một đôi giày
    const fetchReviews = async (shoeId) => {
        try {
            const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Comment/all/${shoeId}`);
            if (!response.ok) throw new Error("Không thể lấy các đánh giá cho giày");

            const data = await response.json();
            setReviews(data || []);
        } catch (error) {
            console.error("Lỗi khi lấy các đánh giá:", error);
        }
    };

    const handleReviewClick = (order, shoeId, shoeName) => {
        setSelectedOrder(order);
        setShowReviewDialog(true);
        setShoeName(shoeName);
        fetchReviews(shoeId);
    };

    const handleCloseReviewDialog = () => {
        setShowReviewDialog(false);
        setRating(0);
        setComment("");
        setLike(false);
    };

    const handleRatingChange = (newRating) => {
        setRating(newRating);
    };

    const handleLikeChange = () => {
        setLike(!like);
    };

    const handleCommentChange = (e) => {
        setComment(e.target.value);
    };

    const handleSubmitReview = async () => {
        const formData = new FormData();

        formData.append('Rate', rating);
        formData.append('UserAvatar', 'str');
        formData.append('ShoeId', selectedOrder?.orderItems[0]?.shoeId);
        formData.append('UserId', user.id);
        formData.append('UserName', user.profileName);
        formData.append('TotalLike', like ? 1 : 0);
        formData.append('Comment', comment);

        if (selectedOrder.image) {
            formData.append('Image', selectedOrder.image);
        }

        formData.append('OrderItemId', selectedOrder?.orderItems[0]?.id);

        try {
            const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Comment`, {
                method: 'POST',
                body: formData,
            });

            if (!response.ok) {
                throw new Error('Lỗi khi gửi đánh giá');
            }

            const data = await response.json();
            console.log('Review submitted successfully:', data);
            handleCloseReviewDialog();
        } catch (error) {
            console.error('Error submitting review:', error);
        }
    };

    const handleMainImageChange = (e) => {
        const selectedFile = e.target.files[0];
        if (selectedFile && (selectedFile.name.endsWith('png') ||
            selectedFile.name.endsWith('jpg') ||
            selectedFile.name.endsWith('jpeg'))) {
            setSelectedOrder((prevOrder) => ({
                ...prevOrder,
                imageUrl: URL.createObjectURL(selectedFile),
                image: selectedFile,
            }));
        } else {
            alert('Chỉ hỗ trợ ảnh PNG, JPG, JPEG');
        }
    };

    console.log(orders);

    return (
        <>
            <div className="col ordered">
                {orders.map((order) => (
                    <div className="order" key={order.id}>
                        <div className="order-status">
                            <h2 className="code">Order: {order.id}</h2>
                            <h2 className="status">Successfully Delivered</h2>
                        </div>

                        {order.orderItems && order.orderItems.map((item, index) => (
                            <div className="item" key={index}>
                                <div className="image">
                                    <img src={`${process.env.REACT_APP_API_URL}/${item.shoeImage}`} alt={item.shoeName} />
                                </div>

                                <div className="item-info">
                                    <div className="info">
                                        <h3>{item.shoeName}</h3>
                                        <p>Size {item.size}</p>
                                        <h3>x{item.quantity}</h3>
                                    </div>
                                    <div>
                                        <p className="item-price" style={{ paddingBottom: "30px" }}>{item.totalPrice.toLocaleString('vi-VN')} VNĐ</p>
                                        <button className='btn-review' onClick={() => handleReviewClick(order, item.shoeId, item.shoeName)}>Reviews</button>
                                    </div>
                                </div>
                            </div>
                        ))}

                        <p className="total">Total <span>{order.totalPrice.toLocaleString('vi-VN')} VNĐ</span></p>
                        <div className="buy-back"><button type="button" className="btn-buyBack">Buy Back</button></div>
                    </div>
                ))}
            </div>

            {/* Review Dialog */}
            {showReviewDialog && (
                <div className="review-dialog">
                    <div className="row review-dialog-content">

                        {/* Display existing reviews */}
                        <div className="col-5 reviews-list">
                            {reviews.length > 0 ? (
                                reviews.map((review, index) => (
                                    <div key={index} className="review-item">
                                        <p className='user'><strong>{review.userName}</strong></p>
                                        <p className='star'>{review.rate} <i class="fa-solid fa-star"></i></p>
                                        {/* <p><strong>Total Like:</strong> {review.totalLike}</p> */}
                                        <p className='comment'>{review.comment}</p>
                                    </div>
                                ))
                            ) : (
                                <p>No reviews yet for this shoe.</p>
                            )}
                        </div>
                        <div className="col-6 review-post">
                            <form action="">
                                <div className="mb-3 image">
                                    <label htmlFor="avatar" className="form-label">
                                        <img src='' alt="" />
                                    </label>
                                    <input
                                        type="file"
                                        className="form-control"
                                        id="avatar"
                                        accept="image/*"
                                    />
                                </div>

                                <RateShoe maxStars={5} onRatingChange={handleRatingChange} />

                                <textarea
                                    id="address"
                                    placeholder="Enter your address..."
                                    className="input-data"
                                    rows="5"
                                    cols="50"
                                />
                            </form>
                        </div>
                        <div className='col-12 control'>
                            <div className="btn-submit-review" onClick={handleSubmitReview}>Submit Review</div>
                            <div className="btn-closes" onClick={handleCloseReviewDialog}>Close</div>
                        </div>
                    </div>
                </div>
            )}
        </>
    );
}

export default ProfileOrdered;
