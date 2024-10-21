import React from 'react';
import'./Navbar.scss'
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
        <div className='adminnavbar'>
            <div className='logo'>
                <img src='/logo.svg' alt="" />
            </div>
            <div className='icons'>
                <img src={`/app.svg`} alt="" className='icon icon-app' />
                <img src={`/expand.svg`} alt="" className='icon icon-expand' onClick={fullScreen} />
                <div className="notification">
                    <img src="/notifications.svg" alt="" className='icon icon-notification' />
                    <span className='icon-counter'>1</span>
                </div>
                <div className="user">
                    <img src='/logo192.png' alt='' />
                    <span>
                        Jiro
                    </span>
                </div>  
                <img src="/settings.svg" alt="" className='icon icon-settings' />
            </div>
        </div>
    );
};

Navbar.propTypes = {

};

export default Navbar;