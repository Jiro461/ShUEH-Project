import React from 'react';

const ProductDetail = ({product, error, loading}) => {
    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    const img_shoe = product.otherImages.map((img_url) => {
        return (
            <div className="ava-shoe"><img src={`http://localhost:5118/` + img_url.url} alt="Thumbnail 1" /></div>
        )
    });

    const shoe_size = product.shoeDetails.map((shoe) => {
        return (
            <div className="col-2 size">{shoe.size}</div>
        )
    });
    
    return (
        <>
            <img src={process.env.PUBLIC_URL + "/img/back_shoe.png"} alt="Background" className="vector-img" />

            {/* Product Image Section */}
            <div className="col-md-12 col-lg-6 col-xl-6 g img-background box">
                <img src={`http://localhost:5118/` + product.imageUrl} alt="Nike PG 2.5" className="shoe-img" />
                <div className='line-vector'>
                    <img src={process.env.PUBLIC_URL + '/img/Vector4.png'} alt="Vector 4" className="vector-4" />
                    <img src={process.env.PUBLIC_URL + '/img/Vector5.png'} alt="Vector 5" className="vector-5" />
                </div>
            </div>

            {/* Thumbnail Image Selection */}
            <div className="col-md-12 col-lg-1 col-xl-1 ava-shoe-selection">
                {img_shoe}
            </div>

            {/* Product Info Section */}
            <div className="col-md-12 col-lg-12 col-xl-3 detail-style">
                <h2>{product.name}</h2>
                <h4>${product.price}</h4>

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
