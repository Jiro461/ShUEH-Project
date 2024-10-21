// Cart.js
import React from 'react';

const PaymentCart = () => {
    return (
        <div className="row cart-product">
            <div className="col"></div>
            <div className="col-10">
                <h1>Your Shopping Cart.</h1>
                <div className="cart">
                    {/* Cart item */}
                    <div className="row cart-item">
                        <div className="col-xl-2 col-4 image">
                            <div><img src="./img/show.png" alt="Product" /></div>
                        </div>
                        <div className="col-xl-9 col-5">
                            <div className="row cart-item-info">
                                <div className="col-xl-4 col-7 cart-item-name">
                                    <h3>Nike Air Vapormax</h3>
                                    <h4>Size 8.5</h4>
                                </div>

                                <div className="col-xl-2 col-5 cart-item-color">
                                    <h3>Orange</h3>
                                </div>

                                <div className="col-xl-3 col-12 amount-adjust">
                                    <div className='adjust'><i className="fa-solid fa-minus"></i></div>
                                    <div>2</div>
                                    <div className='adjust'><i className="fa-solid fa-plus"></i></div>
                                </div>

                                <div className="col-xl-3 col-12 cart-item-price">
                                    <h4>Pricing $210.00</h4>
                                </div>
                            </div>
                        </div>
                        <div className="col-1 btn-delete">
                            <i class="fa-solid fa-xmark"></i>
                        </div>
                    </div>

                </div>
            </div>
            <div className="col"></div>
        </div>
    );
};

export default PaymentCart;
