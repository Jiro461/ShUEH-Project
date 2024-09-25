import React from 'react';
import './Navbar.scss'

const Navbar = () => {

    return (
        <div className='container'>
            <div className="promotion">
                <p>FREESHIP CHO HOÁ ĐƠN TRÊN 1 TRIỆU</p>
            </div>
            <div className="navbar">
                <div className="logo">
                    Logo
                </div>
                <div className="main-nav">
                    <ul>
                        <li>Home</li>
                        <li>Catalog</li>
                        <li>Brands</li>
                        <li>New</li>
                        <li>Sale</li>
                        <li>Support</li>
                    </ul>
                </div>
                <div className="tool">
                    <div className="search">
                        <img className="search-icon" src="/nav-search.svg" alt="" />
                        <input type="text" placeholder='Search'/>
                    </div>
                    <div className="tool-item">
                        <img src="/nav-shopping-bag.svg" alt="" />
                    </div>
                    <div className="tool-item">
                        <img src="/nav-user.svg" alt="" />
                    </div>
                    <div className="tool-item">
                        <img src="/nav-favor.svg" alt="" />
                    </div>
                </div>
            </div>
        </div>
    );
};

Navbar.propTypes = {

};

export default Navbar;