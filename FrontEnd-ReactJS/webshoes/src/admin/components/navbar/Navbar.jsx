import { React, useState, useEffect } from 'react';
import axios from 'axios';
import Menu from '../menu/Menu';
import './Navbar.scss';
import ChatAdmin from '../chatAdmin/ChatAdmin';
import CircularProgress from '@mui/material/CircularProgress';

axios.defaults.withCredentials = true; // Cấu hình axios để gửi cookie cùng với các yêu cầu

const Navbar = () => {
    // Khai báo các biến trạng thái
    const myvalue = process.env.REACT_APP_API_URL; // Lấy URL API từ biến môi trường
    const pageSize = 10; // Số lượng thông báo mỗi trang
    const chatPageSize = 10; // Số lượng tin nhắn chat mỗi trang
    const [isShowChat, setIsShowChat] = useState(false); // Trạng thái hiển thị cửa sổ chat
    const [userId, setUserId] = useState(''); // ID người dùng
    const [isLogin, setIsLogin] = useState(false); // Trạng thái đăng nhập
    const [isLoading, setIsLoading] = useState(true); // Trạng thái tải dữ liệu
    const [chatMessage, setChatMessage] = useState([]); // Mảng lưu trữ tin nhắn chat
    const [pageNumber, setPageNumber] = useState(1); // Số trang thông báo hiện tại
    const [chatPage, setChatPage] = useState(1); // Số trang chat hiện tại
    const [chatNumber, setChatNumber] = useState(1); // Số lượng tin nhắn chat
    const [notificationNumber, setNotificationNumber] = useState(0); // Số lượng thông báo
    const [notificationMessage, setNotificationMessage] = useState([]); // Mảng lưu trữ thông báo
    const [isChatOpen, setIsChatOpen] = useState(false); // Trạng thái mở/đóng cửa sổ chat
    const [isNotificationOpen, setIsNotificationOpen] = useState(false); // Trạng thái mở/đóng thông báo
    const [isMenuOpen, setIsMenuOpen] = useState(false); // Trạng thái mở/đóng menu
    const [isSettingOpen, setIsSettingOpen] = useState(false); // Trạng thái mở/đóng cài đặt
    const [isMaxWidth, setIsMaxWidth] = useState(false); // Trạng thái kiểm tra độ rộng màn hình

    useEffect(() => {
        const handleResize = () => {
            setIsMaxWidth(window.innerWidth <= 455); // Kiểm tra nếu độ rộng màn hình nhỏ hơn hoặc bằng 455
            if (window.innerWidth > 455) {
                setIsMenuOpen(false); // Đóng menu nếu độ rộng màn hình lớn hơn 455
            }
        };

        // Thiết lập giá trị ban đầu
        handleResize();

        // Thêm sự kiện lắng nghe thay đổi kích thước màn hình
        window.addEventListener('resize', handleResize);

        // Dọn dẹp sự kiện khi component bị hủy
        return () => {
            window.removeEventListener('resize', handleResize);
        };
    }, []); // Chỉ chạy một lần khi component được mount

    useEffect(() => {
        if (pageNumber > 1) {
            // Gọi API để lấy thông báo khi số trang lớn hơn 1
            axios.get(`${myvalue}/api/notification/admin/${pageNumber}/${pageSize}`)
                .then(res => {
                    setNotificationMessage(prev => [...prev, ...res.data]); // Thêm thông báo mới vào mảng
                    setNotificationNumber(prev => prev + res.data.length); // Cập nhật số lượng thông báo
                })
                .catch(err => {
                    console.log(err);
                });
        }
    }, [pageNumber]); // Chạy khi pageNumber thay đổi

    useEffect(() => {
        // Gọi API để lấy thông báo trang đầu tiên
        axios.get(`${myvalue}/api/notification/admin/1/${pageSize}`)
            .then(res => {
                setNotificationMessage(res.data); // Cập nhật mảng thông báo
                setIsLoading(false); // Đặt trạng thái tải dữ liệu thành false
                setNotificationNumber(res.data.length); // Cập nhật số lượng thông báo
            })
            .catch(err => {
                console.log(err);
            });
    }, []); // Chỉ chạy một lần khi component được mount

    useEffect(() => {
        if (chatPage > 1) {
            // Gọi API để lấy tin nhắn chat khi số trang lớn hơn 1
            axios.get(`${myvalue}/api/chat/conversations/${chatPage}/${chatPageSize}`)
                .then(res => {
                    setChatMessage(prev => [...prev, ...res.data]); // Thêm tin nhắn mới vào mảng
                    setChatNumber(prev => prev + res.data.length); // Cập nhật số lượng tin nhắn
                })
                .catch(err => {
                    console.log(err);
                });
        }
    }, [chatPage]); // Chạy khi chatPage thay đổi

    useEffect(() => {
        // Gọi API để lấy tin nhắn chat trang đầu tiên
        axios.get(`${myvalue}/api/chat/conversations/1/${chatPageSize}`)
            .then(res => {
                setChatMessage(res.data); // Cập nhật mảng tin nhắn
                setChatNumber(res.data.length); // Cập nhật số lượng tin nhắn
            })
            .catch(err => {
                console.log(err);
            });
    }, []); // Chỉ chạy một lần khi component được mount

    const fullScreen = () => {
        if (!document.fullscreenElement) {
            document.documentElement.requestFullscreen(); // Vào chế độ full screen
        } else {
            if (document.exitFullscreen) {
                document.exitFullscreen(); // Thoát khỏi chế độ full screen
            }
        }
    };

    const convertDate = (date) => {
        // Chuyển đổi định dạng ngày tháng
        return new Date(date).toLocaleDateString('vi-VN', { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit' });
    };

    const convertTime = (time) => {
        // Chuyển đổi định dạng thời gian
        return new Date(time).toLocaleTimeString('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric', hour: '2-digit', minute: '2-digit' });
    };

    const over99Notification = (number) => {
        // Hiển thị '99+' nếu số lượng thông báo lớn hơn 99
        return number > 99 ? '99+' : number;
    };

    return (
        <>
            {isShowChat && <ChatAdmin isOpen={isShowChat} setIsOpen={setIsShowChat} userId={userId} />}
            <div className='adminnavbar'>
                <div className='logo'>
                    <img className='logo-img' src='/logo.svg' alt="" />
                    {(isMaxWidth) ?
                        <div className='icon-wrap-container'>
                            <img src={`/wrap.svg`} alt="" className='icon icon-wrap' onClick={() => {
                                setIsMenuOpen(!isMenuOpen);
                                setIsNotificationOpen(false);
                                setIsSettingOpen(false);
                                setIsChatOpen(false);
                            }} />
                            {isMenuOpen &&
                                <div className='menuContainer'>
                                    <Menu />
                                </div>}
                        </div> : null}
                </div>
                <div className='icons'>
                    <div className='chatmessage' onClick={() => {
                        setIsChatOpen(!isChatOpen);
                        setIsNotificationOpen(false);
                        setIsSettingOpen(false);
                        setIsMenuOpen(false);
                    }}>
                        <img src={`/chat.svg`} alt="" className='icon icon-chat' />
                        <span className='icon-counter chat-number'>{over99Notification(chatNumber)}</span>
                        {isChatOpen &&
                            <div className='chat-message-list' onClick={(e) => {
                                e.stopPropagation();
                            }}>
                                <div className='chat-message-item-header'>
                                    <span>Chat</span>
                                </div>
                                <div className='chat-message-item'>
                                    {chatMessage.map((item, index) => {
                                        return (
                                            <div className='chat-message-content' key={item.userId} onClick={(e) => {
                                                e.stopPropagation();
                                                setIsShowChat(true);
                                                setUserId(item.userId);
                                                setIsChatOpen(false);
                                                setIsNotificationOpen(false);
                                                setIsSettingOpen(false);
                                            }}>
                                                <img src={`${myvalue}${item.lastMessage.fromUserImage}`} alt="" />
                                                <div className='chat-message-content-text'>
                                                    <span className='chat-message-content-text-from'>{item.lastMessage.fromUserName}</span>
                                                    <span className='chat-message-content-text-message'>{item.lastMessageContent}</span>
                                                    <span className='chat-message-content-text-date'>{convertTime(item.lastMessageTime)}</span>
                                                </div>
                                            </div>
                                        );
                                    })}
                                    <div className='chat-message-list-footer'>
                                        <button onClick={() => {
                                            setChatPage(chatPage + 1);
                                            setChatNumber(chatMessage.length);
                                        }}>View more</button>
                                    </div>
                                </div>
                            </div>}
                    </div>
                    <img src={`/expand.svg`} alt="" className='icon icon-expand' onClick={fullScreen} />
                    <div className="notification" onClick={() => {
                        setIsNotificationOpen(!isNotificationOpen);
                        setIsChatOpen(false);
                        setIsSettingOpen(false);
                    }}>
                        <img src="/notifications.svg" alt="" className='icon icon-notification' />
                        <span className='icon-counter notification-number'>{over99Notification(notificationNumber)}</span>
                        {isNotificationOpen &&
                            <div className='notification-list' onClick={(e) => {
                                e.stopPropagation();
                            }}>
                                <div className='notification-list-header'>
                                    <span>Notification</span>
                                </div>
                                {isLoading ? <div className='notification-item' style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100%' }}><CircularProgress /></div>
                                    : notificationNumber > 0 && notificationMessage.map((item, index) => (
                                        <div className='notification-item' key={item.id}>
                                            <img src={`/logo192.png`} alt="" />
                                            <div className='notification-content'>
                                                <div className='notification-content-message'>{item.adminMessage}</div>
                                                <div className='notification-content-date'>{convertDate(item.createDate)}</div>
                                            </div>
                                        </div>
                                    ))}
                                <div className='notification-list-footer'>
                                    <button onClick={(e) => {
                                        e.stopPropagation();
                                        if (!isLoading) {
                                            setPageNumber(pageNumber + 1);
                                            setNotificationNumber(notificationMessage.length);
                                        }
                                    }}>View more</button>
                                </div>
                            </div>}
                    </div>
                    <div className="user">
                        <img src='/logo192.png' alt='' />
                        <span>
                            Jiro
                        </span>
                    </div>
                    <div className='setting' onClick={() => {
                        setIsSettingOpen(!isSettingOpen);
                        setIsChatOpen(false);
                        setIsNotificationOpen(false);
                    }}>
                        <img src="/settings.svg" alt="" className='icon icon-settings' />
                        {isSettingOpen &&
                            <div className='setting-list'>
                                <div className='setting-item'>
                                    <button className='setting-item-button' onClick={() => {
                                        axios.post(`${myvalue}/api/account/sign-out`)
                                            .then(res => {
                                                window.location.href = '/admin/login';
                                            })
                                            .catch(err => {
                                                console.log(err);
                                            });
                                    }}>Logout</button>
                                </div>
                            </div>}
                    </div>
                </div>
            </div>
        </>
    );
};

Navbar.propTypes = {
    // Định nghĩa các prop types nếu cần
};

export default Navbar;