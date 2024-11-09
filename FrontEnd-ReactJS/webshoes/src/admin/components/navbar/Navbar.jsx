import { React, useState, useEffect } from 'react';
import axios from 'axios';
import Menu from '../menu/Menu';
import'./Navbar.scss'
import CircularProgress from '@mui/material/CircularProgress';
axios.defaults.withCredentials = true;
const Navbar = () => {
    var myvalue = process.env.REACT_APP_API_URL;
    const pageSize = 10;
    const [chatNumber, setChatNumber] = useState(0);
    const [isLogin, setIsLogin] = useState(false);
    const [isLoading, setIsLoading] = useState(true);
    const [chatMessage, setChatMessage] = useState([]);
    const [pageNumber, setPageNumber] = useState(1);
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
    const over99Notification = (number) => {
        return number > 99 ? '99+' : number;
    }
    return (
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
                    <span className='icon-counter chat-number'>{chatNumber}</span>
                    {isChatOpen && 
                    <div className='chat-message-list'>
                        <div className='chat-message-item-header'>
                            <span>Chat</span>
                        </div>
                        <div className='chat-message-item'>
                            {chatMessage.map((item, index) => (
                                <div className='chat-message-content' key={item.id}>
                                    <img src={`/logo192.png`} alt="" />
                                    <div className='chat-message-content-text'>
                                        <span className='chat-message-content-text-message'>{item.adminMessage}</span>
                                        <span className='chat-message-content-text-date'>{item.createDate}</span>
                                    </div>
                                </div>  
                            ))}
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
    );
};

Navbar.propTypes = {

};

export default Navbar;