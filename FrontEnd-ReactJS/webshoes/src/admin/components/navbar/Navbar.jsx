import React from 'react';
import PropTypes from 'prop-types';
const IMAGE_PATH = '../../../../public'
const Navbar = () => {
    var myvalue = process.env.REACT_APP_API_URL;
    var IMAGE_PATH = process.env.PUBLIC_URL;
    return (
        <div className='navbar'>
            <div className='logo'>
                <img src='logo.svg' alt="" />
                <span>{myvalue}</span>
            </div>
            <div className='icons'>
                <img src={`/search.svg`} alt="" className='icon' />
                <img src={`/app.svg`} alt="" className='icon' />
                <img src={`/expand.svg`} alt="" className='icon' />
                <div className="notification"></div>
                <div className="user"></div>
                <img src="" alt="" className='icon' />
            </div>
        </div>
    );
};

Navbar.propTypes = {

};

export default Navbar;