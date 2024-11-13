import React, { useState, useEffect } from 'react';

const PaymentStep = () => {
    const [activeStep, setActiveStep] = useState(0);
    const [vouchers, setVouchers] = useState([]);
    const [selectedVoucher, setSelectedVoucher] = useState(null);
    const [isVoucherModalOpen, setVoucherModalOpen] = useState(false);
    const [searchCode, setSearchCode] = useState("");
    const [searchedVoucher, setSearchedVoucher] = useState(null);
    const [cartItems, setCartItems] = useState([]);
    const [subTotal, setSubTotal] = useState(0);
    const [paymentMethod, setPaymentMethod] = useState(2);
    const deliveryFee = 1000; // Giá trị vận chuyển cố định
    const [orderDetails, setOrderDetails] = useState({
        isUsingDiscount: false,
        discountId: "",
        detailOrder: "",
        orderItems: [],
        totalPrice: 0,
        paymentMethod: 2,
        orderDate: new Date().toISOString()
    });

    // Lấy danh sách voucher từ API khi component được mount
    useEffect(() => {
        const fetchVouchers = async () => {
            try {
                const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Discount/all`);
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
    }, [vouchers]);

    // Lấy thông tin sản phẩm trong giỏ hàng
    useEffect(() => {
        const fetchCartItems = async () => {
            try {
                const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Cart/get`, {
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
    }, [cartItems]);

    // Cập nhật orderDetails khi các dữ liệu khác thay đổi
    useEffect(() => {
        // Chuyển cartItems thành orderItems với các thuộc tính cần thiết
        const formattedOrderItems = cartItems.map(item => ({
            shoeId: item.shoeId,
            shoeName: item.shoeName,
            shoeImage: item.shoeImage,
            size: item.size,
            quantity: item.quantity,
            shoePrice: item.price,
            totalPrice: item.price * item.quantity,
            isReviewed: false, // mặc định là chưa review
        }));

        setOrderDetails({
            isUsingDiscount: !!selectedVoucher,
            discountId: selectedVoucher ? selectedVoucher.id : null,
            detailOrder: orderDetails.detailOrder,  // Không thay đổi nếu không liên quan
            orderItems: formattedOrderItems, // sử dụng cấu trúc mới
            totalPrice: calculateTotal(),
            paymentMethod: paymentMethod,
            orderDate: new Date().toISOString(),
        });
    }, [selectedVoucher, paymentMethod, cartItems, subTotal]);

    // Lấy token từ cookie (hoặc localStorage nếu dùng JWT token)
    const getAuthToken = () => {
        // Nếu sử dụng cookie:
        const token = document.cookie.replace(/(?:(?:^|.*;\s*)Authorization\s*\=\s*([^;]*).*$)|^.*$/, "$1");
        return token; // Lấy token từ cookie Authorization
    };

    const handleNextStep = async () => {
        if (activeStep === 1) {
            const name = document.getElementById('name').value;
            const city = document.getElementById('address-city').value;
            const street = document.getElementById('address-street').value;
            const houseNo = document.getElementById('address-houseno').value;

            if (!name || !city || !street) {
                alert('Vui lòng điền tất cả các trường bắt buộc');
                return;
            }

            const detailOrder = `${name}, ${city}, ${street}, ${houseNo}`;
            const updatedOrderDetails = {
                ...orderDetails,
                detailOrder: detailOrder,
            };
            setOrderDetails(updatedOrderDetails);
        }

        if (activeStep === 2) {
            if (paymentMethod !== 0 && paymentMethod !== 1) {
                alert('Vui lòng chọn phương thức thanh toán');
                return;
            }

            const finalOrderDetails = {
                isUsingDiscount: !!selectedVoucher, // Kiểm tra xem có voucher không
                discountId: selectedVoucher ? selectedVoucher.id : null, // Nếu có voucher, lấy id
                detailOrder: orderDetails.detailOrder,  // Địa chỉ nhận hàng
                orderItems: cartItems.map(item => ({
                    shoeId: item.shoeId,
                    shoeName: item.shoeName,
                    shoeImage: item.shoeImage,
                    size: item.size,
                    quantity: item.quantity,
                    shoePrice: item.price,
                    totalPrice: item.price * item.quantity,
                    isReviewed: false, // Điều chỉnh nếu cần thiết
                })),
                totalPrice: calculateTotal(),  // Tổng giá trị đơn hàng
                paymentMethod: paymentMethod,  // Phương thức thanh toán
                orderDate: new Date().toISOString(),  // Thời gian đặt hàng
            };

            try {
                const token = getAuthToken(); // Lấy token

                const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Payment`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        "Authorization": token ? `Bearer ${token}` : "",
                    },
                    body: JSON.stringify(finalOrderDetails),
                    credentials: "include",
                });

                if (response.ok) {
                    // Tới trang thanh toán
                    const responseData = await response.json();
    
                    if (paymentMethod === 0 && responseData.status === "Redirect" && responseData.paymentUrl) {
                        window.location.href = responseData.paymentUrl;
                    } else {
                        console.log("Order placed successfully");
                        setActiveStep(3);
                    }
                } else {
                    // Thanh toán thất bại
                    console.error("Failed to place order", await response.text());
                    alert("Thanh toán không thành công. Vui lòng thử lại.");
                    window.location.href = '/payment'; // Redirect to payment page
                }
            } catch (error) {
                console.error("Error placing order:", error);
            }
            return;
        }

        setActiveStep((prevStep) => prevStep + 1);
    };

    const handleBackStep = () => {
        setActiveStep(prevStep => prevStep - 1);
    };

    const handleVoucherSelection = (voucher) => {
        setSelectedVoucher(voucher);
        setVoucherModalOpen(false);
    };

    const handleSearchVoucher = async (code) => {
        const foundVoucher = vouchers.find(voucher => voucher.code === code);

        if (foundVoucher) {
            try {
                const response = await fetch(`${process.env.REACT_APP_API_URL}/api/Discount/${foundVoucher.id}`);
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
            setSearchedVoucher(null);
            console.log('Không tìm thấy voucher với mã này');
        }
    };

    const calculateTotal = () => {
        const total = selectedVoucher ? (
            selectedVoucher.type ? (
                selectedVoucher.amount ? (
                    subTotal - selectedVoucher.amount + deliveryFee) : (
                    subTotal * (100 - selectedVoucher.percentage) / 100 + deliveryFee)
            ) : (subTotal + deliveryFee - selectedVoucher.amount)
        ) : (subTotal + deliveryFee);
        return total;
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
                                                {(selectedVoucher.percentage === 0 && selectedVoucher.maximumDiscount === 0) ? `${selectedVoucher.amount}$` : `${selectedVoucher.percentage}%`}

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
                                    <div className="method-payment">
                                        <div className={`vnpay ${paymentMethod === 0 ? 'selected' : ''}`} onClick={() => setPaymentMethod(0)}>
                                            <img src="./img/vnpay.jpg" alt="VNPAY" />
                                        </div>
                                        <div className={`COD ${paymentMethod === 1 ? 'selected' : ''}`} onClick={() => setPaymentMethod(1)}>
                                            <i className="fa-solid fa-money-bill"></i>
                                        </div>
                                    </div>

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
                                <span>{searchedVoucher.percentage}%</span>
                                <span>Expires: {new Date(searchedVoucher.expiryDate).toLocaleDateString()}</span>
                            </div>
                        ) : (
                            <ul className="voucher-list">
                                {vouchers.filter(voucher => voucher.isPublic === true).map((voucher) => (
                                    (voucher.type === 0) ? (
                                        <li
                                            key={voucher.id}
                                            onClick={() => handleVoucherSelection(voucher)}
                                            className="row voucher-item"
                                            style={{ border: "2px solid green" }}
                                        >
                                            <div className="col-2"><i className="fa-solid fa-truck-fast"></i></div>
                                            <div className="col-6">
                                                <p>Shipping Fee</p>
                                                <p>up to ${voucher.amount}</p>
                                                <p>Min. spend ${voucher.minimumOrder}</p>
                                            </div>
                                        </li>
                                    ) : (
                                        <li
                                            key={voucher.id}
                                            onClick={() => handleVoucherSelection(voucher)}
                                            className="row voucher-item"
                                            style={{ border: "2px solid orange" }}
                                        >
                                            <div className="col-2">
                                                <i className="fa-solid fa-cart-shopping"></i>
                                            </div>
                                            <div className="col-6">
                                                {voucher.maximumDiscount === 0 && voucher.percentage === 0 ? (
                                                    <>
                                                        <p>${voucher.amount} OFF</p>
                                                        <p>Min. spend ${voucher.minimumOrder}</p>
                                                    </>
                                                ) : (
                                                    <>
                                                        <p>{voucher.percentage}% OFF</p>
                                                        <p>Capped at ${voucher.maximumDiscount}</p>
                                                        <p>Min. spend ${voucher.minimumOrder}</p>
                                                    </>
                                                )}
                                            </div>
                                        </li>

                                    )
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
