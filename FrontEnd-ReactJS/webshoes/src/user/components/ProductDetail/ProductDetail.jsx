import React from 'react';
import config from "../../../config/config.json";

const ProductDetail = ({ product, error, loading }) => {
    const { SERVER_API } = config;

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    // Image Selection
    const img_shoe = product.otherImages.map((img_url, index) => {
        return (
            <div key={`image-${index}`} className="ava-shoe"><img src={`${SERVER_API}/${img_url.url}`} alt="Thumbnail 1" /></div>
        );
    });

    // Size Selection
    const shoe_size = product.shoeDetails.map((shoe, index) => {
        return (
            <div key={`size-${index}`} className="col-2 size">{shoe.size}</div>
        );
    });

    // Rating  || 
    const rating = product.averageRating;

    // Rank Star
    const fullStars = Math.floor(rating); // số ngôi sao đầy
    const partialStarPercentage = (rating % 1) * 100; // phần trăm của ngôi sao cuối
    const emptyStars = 5 - Math.ceil(rating); // số ngôi sao rỗng

    // Render Star
    const renderStars = () => {
        const stars = [];
        for (let i = 0; i < fullStars; i++) {
            stars.push(
                <div key={`full-${i}`} className="star-container">
                    <svg viewBox="0 0 24 24" className="star">
                        <polygon points="12,2 15,8.5 22,9.3 17,14.1 18.6,21 12,17.5 5.4,21 7,14.1 2,9.3 9,8.5" className="star-fill" />
                    </svg>
                </div>
            );
        }
        if (partialStarPercentage > 0) {
            stars.push(
                <div key="partial" className="star-container">
                    <svg viewBox="0 0 24 24" className="star">
                        <polygon points="12,2 15,8.5 22,9.3 17,14.1 18.6,21 12,17.5 5.4,21 7,14.1 2,9.3 9,8.5" className="star-bg" />
                        <polygon
                            points="12,2 15,8.5 22,9.3 17,14.1 18.6,21 12,17.5 5.4,21 7,14.1 2,9.3 9,8.5"
                            className="star-fill"
                            style={{ clipPath: `inset(0 ${100 - partialStarPercentage}% 0 0)` }}
                        />
                    </svg>
                </div>
            );
        }
        for (let i = 0; i < emptyStars; i++) {
            stars.push(
                <div key={`empty-${i}`} className="star-container">
                    <svg viewBox="0 0 24 24" className="star">
                        <polygon points="12,2 15,8.5 22,9.3 17,14.1 18.6,21 12,17.5 5.4,21 7,14.1 2,9.3 9,8.5" className="star-bg" />
                    </svg>
                </div>
            );
        }
        return stars;
    };
    

    return (
        <>
            <img src={process.env.PUBLIC_URL + "/img/back_shoe.png"} alt="Background" className="vector-img" />

            {/* Product Image Section */}
            <div className="col-md-12 col-lg-6 col-xl-6 g img-background box">
                <div className='line-vector'>
                    <img src={process.env.PUBLIC_URL + '/img/Vector4.png'} alt="Vector 4" className="vector-4" />
                    <img src={process.env.PUBLIC_URL + '/img/Vector5.png'} alt="Vector 5" className="vector-5" />
                </div>
                <img src={`${SERVER_API}/${product.imageUrl}`} alt="Nike PG 2.5" className="shoe-img" />
            </div>

            {/* Thumbnail Image Selection */}
            <div className="col-md-12 col-lg-1 col-xl-1 ava-shoe-selection">
                {img_shoe}
            </div>

            {/* Product Info Section */}
            <div className="col-md-12 col-lg-12 col-xl-3 detail-style">
                <h2>{product.name}</h2>
                <h4>${product.price}</h4>

                {/* Rating Stars */}
                <div className="rating-stars">
                    {renderStars()}
                    <span className='rating-number'>({rating})</span>
                </div>

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
                    <button className="add-cart">Add to cart</button>
                    <div className="heart">
                        <i className="fa-regular fa-heart"></i>
                    </div>
                </div>
            </div>
        </>
    );
};

export default ProductDetail;
