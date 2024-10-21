// PaymentStep.js
import React, { useState } from 'react';

const PaymentStep = () => {
    const [activeStep, setActiveStep] = useState(0);

    const handleNextStep = () => {
        setActiveStep(prevStep => prevStep + 1);
    };

    const handleBackStep = () => {
        setActiveStep(prevStep => prevStep - 1);
    };

    const renderCurrentStep = () => {
        switch (activeStep) {
            case 0:
                return (
                    <div className="summary form-step active">
                        <div><img src="./img/Vector.png" alt="Vector Modifier" /></div>
                        <div className="content">
                            <h1>Summary</h1>
                            <div>
                                <h2><span>Sub total</span> <span>$210.00</span></h2>
                                <h2><span>Delivery</span> <span>$1.00</span></h2>
                            </div>
                            <h2 className="total">Total <span>$211.00</span></h2>
                            <button className="btn-next" onClick={handleNextStep}>Member Checkout</button>
                        </div>
                        <p className="note">
                            We deliver immersive virtual reality experiences that encourages
                            learning, creativity and play at transport hubs, select retail and
                            culturally significant venues.
                        </p>
                    </div>
                );
            case 1:
                return (
                    <div className="information form-step active">
                        <div><img src="./img/Vector.png" alt="Vector Modifier" /></div>
                        <div className="content">
                            <h1>Information</h1>
                            <div>
                                <h2><span>Full name</span></h2>
                                <input type="text" id="name" placeholder="Name..." className="input-data" />
                                <h2><span>City, District, ward</span></h2>
                                <input type="text" id="address-city" placeholder="Address..." className="input-data" />
                                <h2><span>Street name, building, house no.</span></h2>
                                <input type="text" id="address-street" placeholder="Address..." className="input-data" />
                                <h2><span>Street name, building, house no.</span></h2>
                                <input type="text" id="address-houseno" placeholder="Address..." className="input-data" />
                            </div>
                            <button className="btn-next" onClick={handleNextStep}>Submit</button>
                            <p className="back" onClick={handleBackStep}>Back</p>
                        </div>
                        <p className="note">
                            We deliver immersive virtual reality experiences that encourages
                            learning, creativity and play at transport hubs, select retail and
                            culturally significant venues.
                        </p>
                    </div>
                );
            case 2:
                return (
                    <div className="payment-cart form-step active">
                        <div><img src="./img/Vector.png" alt="Vector Modifier" /></div>
                        <div className="content">
                            <h1>Payment.</h1>
                            <div className="method">
                                <h3>How would you like to pay?</h3>
                                <div className="method-payment">
                                    <div className="momo"><img src="./img/momo_icon_circle_pinkbg_RGB.png" alt="Momo" /></div>
                                    <div><i className="fa-solid fa-building-columns"></i></div>
                                    <div><i className="fa-solid fa-money-bill"></i></div>
                                </div>
                                <p>
                                    You transfer money to shUEH according to the following information:<br />
                                    Account name: Tran Di Quan<br />
                                    Bank account: 04917133301<br />
                                    Bank: TP Bank<br />
                                    TP Bank account nickname: shUEH<br />
                                    (only applicable for interbank express transfer or money transfer within TP Bank).<br />
                                    Transfer content: Full name - Phone number<br />
                                </p>
                            </div>
                            <button className="btn-next" onClick={handleNextStep}>Place order</button>
                            <p className="back" onClick={handleBackStep}>Back</p>
                        </div>
                        <p className="note">
                            We deliver immersive virtual reality experiences that encourages
                            learning, creativity and play at transport hubs, select retail and
                            culturally significant venues.
                        </p>
                    </div>
                );
            case 3:
                return (
                    <div className="success form-step active">
                        <div><img src="./img/Vector.png" alt="Vector Modifier" /></div>
                        <div className="content">
                            <div><div className="check"><i className="fa-solid fa-check"></i></div></div>
                            <h2>Thank you for your purchase</h2>
                            <p>You have successfully placed your order<br />Order number #12345678</p>
                            <button id="continue">Continue shopping</button>
                            <button id="view-again">View order detail</button>
                        </div>
                        <p className="note">
                            We deliver immersive virtual reality experiences that encourages
                            learning, creativity and play at transport hubs, select retail and
                            culturally significant venues.
                        </p>
                    </div>
                );
            default:
                return null;
        }
    };

    return (
        <div className="cover-payment">
            {renderCurrentStep()}
        </div>
    );
};

export default PaymentStep;
