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
    const [orderItemId, setOrderItemId] = useState(null);

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

    const handleReviewClick = (order, shoeId, id) => {
        setSelectedOrder(order);
        setShowReviewDialog(true);
        setImageUrl("");
        setOrderItemId({
            shoeId: shoeId,
            id: id
        });
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

    const handleCommentChange = (e) => {
        setComment(e.target.value);
    };

    const handleSubmitReview = async () => {
        const formData = new FormData();
    
        // Thêm các trường khác vào FormData
        formData.append('Comment', comment);
        formData.append('Rate', rating);
        formData.append('TotalLike', 5);
        formData.append('UserId', user.id);
        formData.append('ShoeId', orderItemId.shoeId);
        formData.append('OrderItemId', orderItemId.id);
        formData.append('UserName', user.profileName);
        formData.append('UserAvatar', "string");
    
        // Lấy file từ input và thêm vào FormData
        const fileInput = document.getElementById('img-comment');
        const imageFile = fileInput?.files[0];
    
        if (imageFile) {
            formData.append('Image', imageFile, imageFile.name);
        }
    
        try {
            const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Comment`, {
                method: 'POST',
                body: formData,
                credentials: "include"
            });
    
            if (!response.ok) {
                throw new Error('Lỗi khi gửi đánh giá');
            }
    
            // const data = await response.json();
            console.log('Review submitted successfully:');
            handleCloseReviewDialog();
        } catch (error) {
            alert('Bạn đã đánh giá sản phẩm rồi !');
        }
    };

    console.log("selectedOrder", reviews);

    const [imageUrl, setImageUrl] = useState("");

    // Modify the handleFileChange function to handle image preview and validation
    const handleSetImageUrl = (e) => {
        const selectedFile = e.target.files[0];
        if (selectedFile && (selectedFile.name.endsWith('png') ||
            selectedFile.name.endsWith('jpg') ||
            selectedFile.name.endsWith('jpeg'))) {
                setImageUrl(
                `${URL.createObjectURL(selectedFile)}`, // Use object URL for preview
            );
        } else {
            alert("Chỉ chấp nhận các file hình ảnh với định dạng .png, .jpg, .jpeg.");
        }
    };

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
                                    <img src={`${process.env.REACT_APP_API_URL}/${item.shoeImage}`} alt={item.shoeName}/>
                                </div>

                                <div className="item-info">
                                    <div className="info">
                                        <h3>{item.shoeName}</h3>
                                        <p>Size {item.size}</p>
                                        <h3>x{item.quantity}</h3>
                                    </div>
                                    <div>
                                        <p className="item-price" style={{ paddingBottom: "30px" }}>{item.totalPrice.toLocaleString('vi-VN')} VNĐ</p>
                                        <button className='btn-review' onClick={() => handleReviewClick(order, item.shoeId, item.id)}>Reviews</button>
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
                                        <p className='star'>{review.rate} <i className="fa-solid fa-star"></i></p>
                                        {/* <p><strong>Total Like:</strong> {review.totalLike}</p> */}
                                        <p className='comment'>{review.comment}</p>
                                        <div style={{width: "100%"}}>
                                            <img src={`${process.env.REACT_APP_API_URL}/${review.imageUrl}`} alt="image" style={{width: "100%"}}/>
                                        </div>
                                    </div>
                                ))
                            ) : (
                                <p>No reviews yet for this shoe.</p>
                            )}
                        </div>
                        <div className="col-6 review-post">
                            <form action="">
                                <div className="mb-3 image">
                                    <label htmlFor="img-comment" className="form-label">
                                        <img src={`${imageUrl}`} alt="" />
                                    </label>
                                    <input
                                        type="file"
                                        className="form-control"
                                        id="img-comment"
                                        accept="image/*"
                                        onChange={handleSetImageUrl}
                                    />
                                </div>

                                <RateShoe maxStars={5} onRatingChange={handleRatingChange} />

                                <textarea
                                    id="address"
                                    placeholder="Enter your address..."
                                    className="input-data"
                                    rows="5"
                                    cols="50"
                                    onChange={handleCommentChange}
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
