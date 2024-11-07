import React, { useState, useEffect } from 'react';
import config from '../../../config/config.json';

const PaymentStep = () => {
    const { SERVER_API } = config;
    const [activeStep, setActiveStep] = useState(0);
    const [vouchers, setVouchers] = useState([]);
    const [selectedVoucher, setSelectedVoucher] = useState(null);
    const [isVoucherModalOpen, setVoucherModalOpen] = useState(false);
    const [searchCode, setSearchCode] = useState("");
    const [searchedVoucher, setSearchedVoucher] = useState(null);
    const [cartItems, setCartItems] = useState([]);
    const [subTotal, setSubTotal] = useState(0);
    const deliveryFee = 1000; // Giá trị vận chuyển cố định

    // Lấy danh sách voucher từ API khi component được mount
    useEffect(() => {
        const fetchVouchers = async () => {
            try {
                const response = await fetch(`${SERVER_API}/api/Discount/all`);
                if (response.ok) {
                    const data = await response.json();
                    setVouchers(data);
                } else {
                    console.error('Không thể lấy danh sách voucher');
                }
            } catch (error) {
                console.error('Lỗi khi lấy voucher:', error);
            }
        };

        fetchVouchers();
    }, []);

    // Lấy thông tin sản phẩm trong giỏ hàng
    useEffect(() => {
        const fetchCartItems = async () => {
            try {
                const response = await fetch(`${SERVER_API}/api/Cart/get`, {
                    method: 'GET',
                    credentials: 'include',
                });

                if (response.ok) {
                    const data = await response.json();
                    setCartItems(data);
                    // Tính sub total
                    const total = data.reduce((sum, item) => sum + item.price * item.quantity, 0);
                    setSubTotal(total);
                } else {
                    console.error('Không thể lấy danh sách sản phẩm trong giỏ hàng');
                }
            } catch (error) {
                console.error('Lỗi khi lấy sản phẩm trong giỏ hàng:', error);
            }
        };

        fetchCartItems();
    }, []);

    console.log(cartItems);


    const handleNextStep = () => {
        setActiveStep(prevStep => prevStep + 1);
    };

    const handleBackStep = () => {
        setActiveStep(prevStep => prevStep - 1);
    };

    const handleVoucherSelection = (voucher) => {
        setSelectedVoucher(voucher);
        setVoucherModalOpen(false); // Đóng modal sau khi chọn
    };

    const handleSearchVoucher = async (code) => {
        const foundVoucher = vouchers.find(voucher => voucher.code === code);

        if (foundVoucher) {
            try {
                const response = await fetch(`${SERVER_API}/api/Discount/${foundVoucher.id}`);
                if (response.ok) {
                    const voucher = await response.json();
                    setSearchedVoucher(voucher);
                } else {
                    console.error('Không tìm thấy voucher');
                }
            } catch (error) {
                console.error('Lỗi khi tìm voucher:', error);
            }
        } else {
            setSearchedVoucher(null); // Đặt lại nếu không tìm thấy voucher
            console.log('Không tìm thấy voucher với mã này');
        }
    };

    const calculateTotal = () => {
        const discount = selectedVoucher ? (100 - selectedVoucher.percentage) / 100 : 1;
        return subTotal * discount + deliveryFee;
    };

    // Thêm hàm loại bỏ voucher
    const handleRemoveVoucher = () => {
        setSelectedVoucher(null);
    };

    const renderCurrentStep = () => {
        switch (activeStep) {
            case 0:
                return (
                    <div className="summary form-step active">
                        <div className='back-ground'><img src="./img/Vector.png" alt="Vector Modifier" /></div>
                        <div className="content-pay">
                            <h1>Summary</h1>
                            <div>
                                <h2><span>Sub total</span> <span>${subTotal.toFixed(2)}</span></h2>
                                <h2><span>Delivery</span> <span>${deliveryFee.toFixed(2)}</span></h2>
                            </div>
                            <div className='voucher'>
                                <h2>
                                    <span>Voucher</span>
                                    <span
                                        className='voucher-selection'
                                        onClick={() => setVoucherModalOpen(true)}
                                    >
                                        {selectedVoucher ? (
                                            <>
                                                {selectedVoucher.percentage}%
                                                {/* Thêm nút "Remove" để bỏ chọn voucher */}
                                                <button
                                                    onClick={(e) => {
                                                        e.stopPropagation(); // Ngăn modal mở ra
                                                        handleRemoveVoucher();
                                                    }}
                                                    className="remove-voucher-button"
                                                >
                                                    Remove
                                                </button>
                                            </>
                                        ) : 'Select'}
                                    </span>
                                </h2>
                            </div>
                            <h2 className="total">Total <span>${calculateTotal().toFixed(2)}</span></h2>
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
                        <div className='back-ground'><img src="./img/Vector.png" alt="Vector Modifier" /></div>
                        <div className="content-pay">
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
                        <div className='back-ground'><img src="./img/Vector.png" alt="Vector Modifier" /></div>
                        <div className="content-pay">
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
                        <div className='back-ground'><img src="./img/Vector.png" alt="Vector Modifier" /></div>
                        <div className="content-pay">
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

            {/* Modal cho Voucher */}
            {isVoucherModalOpen && (
                <div className="voucher-modal">
                    <div className="modal-content">
                        <h2>Select a Voucher</h2>
                        <div className="voucher-search">
                            <input
                                type="text"
                                placeholder="Enter voucher code"
                                value={searchCode}
                                onChange={(e) => {
                                    const code = e.target.value;
                                    setSearchCode(code);
                                    handleSearchVoucher(code);
                                }}
                            />
                        </div>

                        {searchedVoucher ? (
                            <div
                                className="voucher-item"
                                onClick={() => handleVoucherSelection(searchedVoucher)}
                            >
                                <span>{searchedVoucher.code}</span>
                                <span>{searchedVoucher.percentage}%</span>
                                <span>Expires: {new Date(searchedVoucher.expiryDate).toLocaleDateString()}</span>
                            </div>
                        ) : (
                            <ul className="voucher-list">
                                {vouchers.map((voucher) => (
                                    <li
                                        key={voucher.id}
                                        onClick={() => handleVoucherSelection(voucher)}
                                        className="voucher-item"
                                    >
                                        <span>{voucher.code}</span>
                                        <span>{voucher.percentage}%</span>
                                        <span>Expires: {new Date(voucher.expiryDate).toLocaleDateString()}</span>
                                    </li>
                                ))}
                            </ul>
                        )}

                        <button onClick={() => setVoucherModalOpen(false)}>Close</button>
                    </div>
                </div>
            )}
        </div>
    );
};

export default PaymentStep;
