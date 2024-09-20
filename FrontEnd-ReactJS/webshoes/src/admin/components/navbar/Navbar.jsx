import React from 'react';
import PropTypes from 'prop-types';
const Navbar = () => {
    var myvalue = process.env.REACT_APP_API_URL;
    return (
        <div className='navbar'>
            <div className='logo'>
                <img src='logo.svg' alt =""/>
                <span>{myvalue}</span>
            </div>
            <div className='icons'>
                <img src='' alt="" className='icon'/>
                <img src="" alt="" className='icon'/>
                <img src="" alt="" className='icon'/>
                <div className="notification"></div>
                <div className="user"></div>
                <img src="" alt="" className='icon'/>
            </div>
        </div>
    );
};

Navbar.propTypes = {
    
};

export default Navbar;