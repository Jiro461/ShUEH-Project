// PaymentPage.js
import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import PaymentCart from '../../components/PaymentCart/PaymentCart';
import PaymentStep from '../../components/PaymentStep/PaymentStep';
import config from '../../../config/config.json';
import './style.scss';

const PaymentPage = () => {
    const navigate = useNavigate();
    const { SERVER_API } = config;
    const [userID, setUserID] = useState(undefined); // `undefined` là trạng thái ban đầu khi chưa xác định được ID người dùng

    // Custom hook để kiểm tra đăng nhập và lấy userID
    useEffect(() => {
        const checkUserLoggedIn = async () => {
            try {
                const response = await fetch(`${SERVER_API}/api/Account/cookieGetById`, {
                    method: 'GET',
                    credentials: 'include',
                });

                if (response.ok) {
                    const data = await response.json();
                    setUserID(data.id);
                } else {
                    setUserID(null); // Không có userID nghĩa là người dùng chưa đăng nhập
                }
            } catch (error) {
                console.error("Lỗi khi kiểm tra trạng thái đăng nhập:", error);
                setUserID(null); // Thiết lập là null nếu có lỗi
            }
        };

        checkUserLoggedIn();
    }, [SERVER_API]);

    // Chuyển hướng nếu người dùng chưa đăng nhập
    useEffect(() => {
        if (userID === null) {
            navigate('/login');
        }
    }, [userID, navigate]);

    // Hiển thị Loading trong khi chờ xác định userID
    if (userID === undefined) {
        return <div>Loading...</div>;
    }

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
