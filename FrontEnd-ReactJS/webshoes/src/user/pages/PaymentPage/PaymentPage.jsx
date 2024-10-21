// PaymentPage.js
import React from 'react';
import PaymentCart from '../../components/PaymentCart/PaymentCart';
import PaymentStep from '../../components/PaymentStep/PaymentStep';
import './style.scss';

const PaymentPage = () => {
    return (
        <div className="container-fluid payment-pages">
            <div className="row container-main">
                {/* Cart */}
                <div className="col">
                    <PaymentCart />
                </div>

                {/* Payment Steps */}
                <div className="col-3 payment">
                    <PaymentStep />
                </div>
            </div>
        </div>
    );
};

export default PaymentPage;
