import React from 'react';

const DetailProduct = () => {
    return (
        <div className="row detail-product">
            <img src={process.env.PUBLIC_URL + "/img/back_shoe.png"} alt="Background" className="vector-img" />

            {/* Product Image Section */}
            <div className="col-md-12 col-lg-6 col-xl-6 g img-background box">
                <img src={process.env.PUBLIC_URL + "/img/airford1.png"} alt="Nike PG 2.5" className="shoe-img" />
                <div className="color-selection">
                    <div className="color"></div>
                    <div className="color"></div>
                    <div className="color"></div>
                </div>
            </div>

            {/* Thumbnail Image Selection */}
            <div className="col-md-12 col-lg-1 col-xl-1 ava-shoe-selection">
                <div className="ava-shoe"><img src={process.env.PUBLIC_URL + '/img/airjordan1_1.png'} alt="Thumbnail 1" /></div>
                <div className="ava-shoe"><img src={process.env.PUBLIC_URL + '/img/airjordan1_2.png'} alt="Thumbnail 2" /></div>
                <div className="ava-shoe"><img src={process.env.PUBLIC_URL + '/img/airjordan1_3.png'} alt="Thumbnail 3" /></div>
                <div className="ava-shoe"><img src={process.env.PUBLIC_URL + '/img/airjordan1_4.png'} alt="Thumbnail 4" /></div>
            </div>

            {/* Product Info Section */}
            <div className="col-md-12 col-lg-12 col-xl-3 detail-style">
                <h2>Nike PG 2.5</h2>
                <h3>Playstation 'White'</h3>
                <h4>$150.00</h4>

                {/* Size Selection */}
                <div className="select-size">
                    <div className="select-button">
                        <button>Select size</button>
                        <button>Size table</button>
                    </div>
                    <div className="row row-cols-5 size-box">
                        <div className="col-2 size">4</div>
                        <div className="col-2 size">4.5</div>
                        <div className="col-2 size">5</div>
                        <div className="col-2 size">5.5</div>
                        <div className="col-2 size">6</div>
                        <div className="col-2 size">6.5</div>
                        <div className="col-2 size">7</div>
                        <div className="col-2 size">7.5</div>
                        <div className="col-2 size">8</div>
                        <div className="col-2 size">8.5</div>
                    </div>
                </div>

                {/* Add to Cart */}
                <div className="add-cart">
                    <button  className="add">Add to cart</button>
                    <div className="heart">
                        <i className="fa-regular fa-heart"></i>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default DetailProduct;
