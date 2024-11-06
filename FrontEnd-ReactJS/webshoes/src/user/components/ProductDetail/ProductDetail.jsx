import React, { useState } from 'react';
import config from "../../../config/config.json";
import RatingStars from '../RatingStars/RatingStars';
import { useNavigate } from 'react-router-dom';
import useFetchUserID from '../../hooks/useFetchUserID';

const ProductDetail = ({ product, error, loading }) => {
    const { SERVER_API } = config;
    const navigate = useNavigate();
    const [selectedSize, setSelectedSize] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);  // State để điều khiển modal
    const [selectedImage, setSelectedImage] = useState(""); // Lưu ảnh đã chọn

    // Sử dụng custom hook để lấy userID
    const userID = useFetchUserID();

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    // Xử lý chọn size giày
    const handleSizeSelect = (size) => {
        setSelectedSize(size);
    };

    // Xử lý khi thêm sản phẩm vào giỏ hàng
    const handleAddToCart = async () => {
        if (!userID) {
            navigate("/login");
        } else if (!selectedSize) {
            alert("Vui lòng chọn size trước khi thêm vào giỏ hàng.");
        } else {
            try {
                const response = await fetch(
                    `${SERVER_API}/api/Cart/add?shoeId=${product.id}&size=${selectedSize}`,
                    {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        credentials: 'include',
                    }
                );

                if (response.ok) {
                    alert("Đã thêm vào giỏ hàng!");
                } else {
                    throw new Error('Không thể thêm vào giỏ hàng');
                }
            } catch (error) {
                console.error("Lỗi:", error);
            }
        }
    };

    // Các phần tử hình ảnh và kích thước
    const img_shoe = product.otherImages.map((img_url, index) => (
        <div key={`image-${index}`} className="ava-shoe" onClick={() => openModal(`${SERVER_API}/${img_url.url}`)}>
            <img src={`${SERVER_API}/${img_url.url}`} alt={`Thumbnail ${index + 1}`} />
        </div>
    ));

    // Xử lý mở modal
    const openModal = (imageUrl) => {
        setSelectedImage(imageUrl);
        setIsModalOpen(true);
    };

    // Xử lý đóng modal
    const closeModal = () => {
        setIsModalOpen(false);
        setSelectedImage("");
    };

    // Các phần tử kích thước giày
    const shoe_size = product.shoeDetails.map((shoe, index) => (
        <div
            key={`size-${index}`}
            className={`col-2 size ${selectedSize === shoe.size ? 'selected' : ''}`}
            onClick={() => handleSizeSelect(shoe.size)}
        >
            {shoe.size}
        </div>
    ));

    return (
        <>
            <img src={process.env.PUBLIC_URL + "/img/back_shoe.png"} alt="Background" className="vector-img" />

            {/* Product Image Section */}
            <div className="col-md-12 col-lg-6 col-xl-6 g img-background box">
                <div className='line-vector'>
                    <img src={process.env.PUBLIC_URL + '/img/Vector4.png'} alt="Vector 4" className="vector-4" />
                    <img src={process.env.PUBLIC_URL + '/img/Vector5.png'} alt="Vector 5" className="vector-5" />
                </div>
                <img src={`${SERVER_API}/${product.imageUrl}`} alt={product.name} className="shoe-img" />
            </div>

            {/* Thumbnail Image Selection */}
            <div className="col-md-12 col-lg-1 col-xl-1 ava-shoe-selection">
                {img_shoe}
            </div>

            {/* Product Info Section */}
            <div className="col-md-12 col-lg-12 col-xl-3 detail-style">
                <h2>{product.name}</h2>

                <RatingStars rating={product.averageRating} />
                
                <h4>
                    {product.isSale ? (
                        <>
                            <span style={{
                                textDecoration: "line-through",
                                fontSize: "23px",
                                color: "#000",
                                marginRight: "10px"
                            }}>
                                ${product.price}
                            </span>
                            ${product.salePrice}
                        </>
                    ) : `${product.price}`}
                </h4>

                {/* Size Selection */}
                <div className="select-size">
                    <div className="select-button">
                        <div>Select size</div>
                    </div>
                    <div className="row row-cols-5 size-box">
                        {shoe_size}
                    </div>
                </div>

                {/* Add to Cart */}
                <div className="add-to-cart">
                    <button className="add-cart" onClick={handleAddToCart}>Add to cart</button>
                    <div className="heart">
                        <i className="fa-regular fa-heart"></i>
                    </div>
                </div>
            </div>

            {/* Modal for Image */}
            {isModalOpen && (
                <div className="modal-overlay" onClick={closeModal}>
                    <div className="modal-content">
                        <img src={selectedImage} alt="Selected Shoe" />
                    </div>
                </div>
            )}
        </>
    );
};

export default ProductDetail;
