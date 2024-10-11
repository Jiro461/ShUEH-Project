// Cart.js
import React from 'react';

const Cart = () => {
    return (
        <div className="row cart-product">
            <div className="col"></div>
            <div className="col-10">
                <h1>Your Shopping Cart.</h1>
                <div className="cart">
                    {/* Cart item */}
                    <div className="row cart-item">
                        <div className="col-5">
                            <div className="row">
                                <div className="col">
                                    <div><img src="./img/show.png" alt="Product" /></div>
                                </div>
                                <div className="col">
                                    <h3>Nike Air Vapormax</h3>
                                    <h4>Size 8.5</h4>
                                </div>
                            </div>
                        </div>
                        <div className="col-2 color">
                            <h3>Orange</h3>
                        </div>
                        <div className="col-5">
                            <div className="row amount">
                                <div className="col amount-adjust">
                                    <div>-</div>
                                    <div>2</div>
                                    <div>+</div>
                                </div>
                                <div className="col">
                                    <h4>Pricing $210.00</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="col"></div>
        </div>
    );
};

export default Cart;
