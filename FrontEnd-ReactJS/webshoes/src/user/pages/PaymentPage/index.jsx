// PaymentPage.js
import React from 'react';
import Cart from '../../components/PaymentPage/Cart';
import PaymentStep from '../../components/PaymentPage/PaymentStep';
import './style.scss';

const PaymentPage = () => {
    return (
        <div className="container-fluid payment-pages">
            <div className="row container-main">
                {/* Cart */}
                <div className="col">
                    <Cart />
                </div>

                {/* Payment Steps */}
                <PaymentStep />
            </div>
        </div>
    );
};

export default PaymentPage;
