import { React, useState, useEffect } from 'react';
import axios from 'axios';
import Menu from '../menu/Menu';
import'./Navbar.scss'
const Navbar = () => {
    var myvalue = process.env.REACT_APP_API_URL;
    const [chatNumber, setChatNumber] = useState(0);
    const [chatMessage, setChatMessage] = useState([]);
    const [notificationNumber, setNotificationNumber] = useState(0);
    const [notificationMessage, setNotificationMessage] = useState([]);
    const [isChatOpen, setIsChatOpen] = useState(false);
    const [isNotificationOpen, setIsNotificationOpen] = useState(false);
    const [isMenuOpen, setIsMenuOpen] = useState(false);
    const [isSettingOpen, setIsSettingOpen] = useState(false);
    const [isMaxWidth, setIsMaxWidth] = useState(false);
    useEffect(() => {
        setIsMaxWidth(window.innerWidth <= 455);
    }, [window.innerWidth]);
    useEffect(() => {
        axios.get(`${myvalue}/api/chat/get-chat-number`)
        .then(res => {
            setChatNumber(res.data);
        })
        .catch(err => {
            console.log(err);
        })
        axios.get(`${myvalue}/api/notification/admin`)
        .then(res => {
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

    return (
        <div className='adminnavbar'>
            <div className='logo'>
                <img src='/logo.svg' alt="" />
            </div>
            <div className='icons'>
                {(isMaxWidth) ? 
                <img src={`/wrap.svg`} alt="" className='icon icon-wrap' onClick={() => {
                    setIsMenuOpen(!isMenuOpen)
                    setIsNotificationOpen(false)
                    setIsSettingOpen(false)
                    setIsChatOpen(false)
                }}/> : null}
                {isMenuOpen && 
                <div className='menuContainer'>
                    <Menu />
                </div>}
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
                    <span className='icon-counter notification-number'>{notificationNumber}</span>
                    {isNotificationOpen && 
                    <div className='notification-list'>
                        <div className='notification-list-header'>
                            <span>Notification</span>
                        </div>
                        {notificationNumber > 0 && notificationMessage.map((item, index) => (
                            <div className='notification-item' key={item.id}>
                                <img src={`/logo192.png`} alt="" />
                                <div className='notification-content'>
                                    <div className='notification-content-message'>{item.adminMessage}</div>
                                    <div className='notification-content-date'>{item.createDate}</div>
                                </div>
                            </div>
                        ))}
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