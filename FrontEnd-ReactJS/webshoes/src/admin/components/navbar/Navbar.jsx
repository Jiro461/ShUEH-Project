import React from 'react';
import './Navbar.scss'
const Navbar = () => {
    var myvalue = process.env.REACT_APP_API_URL;

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
        <div className='navbar'>
            <div className='logo'>
                <img src='logo.svg' alt="" />
                <span>{myvalue}</span>
            </div>
            <div className='icons'>
                <img src={`/search.svg`} alt="" className='icon' />
                <img src={`/app.svg`} alt="" className='icon' />
                <img src={`/expand.svg`} alt="" className='icon' onClick={fullScreen} />
                <div className="notification">
                    <img src="notifications.svg" alt="" className='icon' />
                    <span>1</span>
                </div>
                <div className="user">
                    <img src='/logo192.png' alt='' />
                    <span>
                        Jiro
                    </span>
                </div>
                <img src="/settings.svg" alt="" className='icon' />
            </div>
        </div>
    );
};

Navbar.propTypes = {

};

export default Navbar;