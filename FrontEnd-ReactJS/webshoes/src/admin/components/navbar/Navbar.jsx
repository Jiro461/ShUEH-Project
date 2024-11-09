import { React, useState, useEffect } from 'react';
import axios from 'axios';
import Menu from '../menu/Menu';
import'./Navbar.scss'
import ChatAdmin from '../chatAdmin/ChatAdmin';
import CircularProgress from '@mui/material/CircularProgress';
axios.defaults.withCredentials = true;
const Navbar = () => {
    // {
    //     "userId": "fd81b4db-d756-4ce7-b549-420498fa9be3",
    //     "lastMessage": {
    //       "id": "44f73ccd-e5f8-4bf5-0b0d-08dd0097f806",
    //       "fromUserId": "fd81b4db-d756-4ce7-b549-420498fa9be3",
    //       "fromUserName": "Guest",
    //       "fromUserImage": "images/users/noimage.png",
    //       "toUserId": "AdminGroup",
    //       "toUserName": "Admin",
    //       "toUserImage": "images/users/noimage.png",
    //       "message": "xin chào admin",
    //       "timestamp": "2024-11-09T15:24:45.7526796"
    //     },
    //     "lastMessageContent": "xin chào admin",
    //     "lastMessageTime": "2024-11-09T15:24:45Z"
    //   },
    var myvalue = process.env.REACT_APP_API_URL;
    const pageSize = 10;
    const chatPageSize = 10;
    const [isShowChat, setIsShowChat] = useState(false);
    const [userId, setUserId] = useState('');
    const [isLogin, setIsLogin] = useState(false);
    const [isLoading, setIsLoading] = useState(true);
    const [chatMessage, setChatMessage] = useState([]);
    const [pageNumber, setPageNumber] = useState(1);
    const [chatPage, setChatPage] = useState(1);
    const [chatNumber, setChatNumber] = useState(1);
    const [notificationNumber, setNotificationNumber] = useState(0);
    const [notificationMessage, setNotificationMessage] = useState([]);
    const [isChatOpen, setIsChatOpen] = useState(false);
    const [isNotificationOpen, setIsNotificationOpen] = useState(false);
    const [isMenuOpen, setIsMenuOpen] = useState(false);
    const [isSettingOpen, setIsSettingOpen] = useState(false);
    const [isMaxWidth, setIsMaxWidth] = useState(false);
    useEffect(() => {
        const handleResize = () => {
            setIsMaxWidth(window.innerWidth <= 455);
            if(window.innerWidth > 455) {
                setIsMenuOpen(false);
            }
        };
        
        // Set initial value
        handleResize();
        
        // Add event listener
        window.addEventListener('resize', handleResize);
        
        // Cleanup
        return () => {
            window.removeEventListener('resize', handleResize); 
        };
    }, []); // Empty dependency array since we only want this to run once on mount

    useEffect(() => {
        if (pageNumber > 1) {
            axios.get(`${myvalue}/api/notification/admin/${pageNumber}/${pageSize}`)
            .then(res => {
                setNotificationMessage(prev => [...prev, ...res.data]);
                setNotificationNumber(prev => prev + res.data.length);
            })
            .catch(err => {
                console.log(err);
            })
        }
    }, [pageNumber]);
    useEffect(() => {
        axios.get(`${myvalue}/api/notification/admin/1/${pageSize}`)
        .then(res => {
            setNotificationMessage(res.data);
            setIsLoading(false);
            setNotificationNumber(res.data.length);
        })
        .catch(err => {
            console.log(err);
        })
    }, []); 
    useEffect(() => {
        if (chatPage > 1) {
        axios.get(`${myvalue}/api/chat/conversations/${chatPage}/${chatPageSize}`)
        .then(res => {
            setChatMessage(prev => [...prev, ...res.data]);
            setChatNumber(prev => prev + res.data.length);
        })
        .catch(err => {
                console.log(err);
            })
        }
    }, [chatPage]);
    useEffect(() => {
        axios.get(`${myvalue}/api/chat/conversations/1/${chatPageSize}`)
        .then(res => {
            setChatMessage(res.data);
            setChatNumber(res.data.length);
        })
        .catch(err => {
                console.log(err);
            })
    }, []);
    const fullScreen = () => {
        if (!document.fullscreenElement) {
            document.documentElement.requestFullscreen(); // Vào chế độ full screen
        } else {
            if (document.exitFullscreen) {
                document.exitFullscreen(); // Thoát khỏi chế độ full screen
            }
        }
    }
    const convertDate = (date) => {
        return new Date(date).toLocaleDateString('vi-VN', {year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit'});
    }
    const convertTime = (time) => {
        return new Date(time).toLocaleTimeString('vi-VN', {day: '2-digit', month: '2-digit', year: 'numeric', hour: '2-digit', minute: '2-digit'});
    }
    const over99Notification = (number) => {
        return number > 99 ? '99+' : number;
    }

    return (
        <>
        {isShowChat && <ChatAdmin isOpen={isShowChat} setIsOpen={setIsShowChat} userId={userId} />}
        <div className='adminnavbar'>
            <div className='logo'>
                <img className='logo-img' src='/logo.svg' alt="" />
                {(isMaxWidth) ? 
                <div className='icon-wrap-container'>
                <img src={`/wrap.svg`} alt="" className='icon icon-wrap' onClick={() => {
                    setIsMenuOpen(!isMenuOpen)
                    setIsNotificationOpen(false)
                    setIsSettingOpen(false)
                    setIsChatOpen(false)
                    }}/>
                {isMenuOpen && 
                <div className='menuContainer'>
                        <Menu />
                    </div>}
                </div> : null}
            </div>
            <div className='icons'>
              

                <div className='chatmessage' onClick={() => {
                    setIsChatOpen(!isChatOpen)
                    setIsNotificationOpen(false)
                    setIsSettingOpen(false)
                    setIsMenuOpen(false)
                }}>
                    <img src={`/chat.svg`} alt="" className='icon icon-chat' />
                    <span className='icon-counter chat-number'>{over99Notification(chatNumber)}</span>
                    {isChatOpen && 
                    <div className='chat-message-list' onClick={(e) => {
                        e.stopPropagation()
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
                    setIsNotificationOpen(!isNotificationOpen)
                    setIsChatOpen(false)
                    setIsSettingOpen(false)
                }}>
                    <img src="/notifications.svg" alt="" className='icon icon-notification' />
                    <span className='icon-counter notification-number'>{over99Notification(notificationNumber)}</span>
                    {isNotificationOpen && 
                    <div className='notification-list' onClick={(e) => {
                        e.stopPropagation()
                    }}>
                        <div className='notification-list-header'>
                            <span>Notification</span>
                        </div>
                        {isLoading ? <div className='notification-item' style={{display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100%'}}><CircularProgress /></div> 
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
                    setIsSettingOpen(!isSettingOpen)
                    setIsChatOpen(false)
                    setIsNotificationOpen(false)
                }}>
                    <img src="/settings.svg" alt="" className='icon icon-settings' />
                    {isSettingOpen && 
                    <div className='setting-list'>
                        <div className='setting-item'>
                            <button className='setting-item-button' onClick={()=> {
                                axios.post(`${myvalue}/api/account/sign-out`)
                                .then(res => {
                                    window.location.href = '/admin/login';
                                })
                                .catch(err => {
                                    console.log(err);
                                })
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

};

export default Navbar;