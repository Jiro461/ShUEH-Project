import React from 'react';
import './Navbar.scss'

const Navbar = () => {
    return (
            <div className='navbar-block'>
            
                <div className="promotion text-center d-none d-sm-block">
                    FREESHIP CHO HOÁ ĐƠN TRÊN 1 TRIỆU
                </div>

                <div className="nav-box">

                    <div className="logo">
                        <img src="/shueh-logo.svg" alt=""></img>
                    </div>

                    <nav className="main-nav d-none d-lg-block">
                        <ul>
                            <li>Home</li>
                            <li>Catalog</li>
                            <li>Brands</li>
                            <li>New</li>
                            <li>Sale</li>
                            <li>Support</li>
                        </ul>
                    </nav>

                    <div className="tool-block">
                        <div className="search-block d-none d-sm-flex">
                            <img className="search-icon" src="/nav-search.svg" alt="" />
                            <input type="text" placeholder='Search'/>
                        </div>
                        <div className="tool-item search-icon-mobile d-block d-sm-none">
                            <img src="/navbar-search-icon.svg" alt=""/>
                        </div>
                        <div className="tool-item cart-icon">
                            <img src="/nav-shopping-bag-none-noti.svg" alt="" />
                            <span className="cart-noti">1</span>
                        </div>
                        <div className="tool-item">
                            <img src="/nav-user.svg" alt="" />
                        </div>
                        <div className="tool-item d-none d-sm-block">
                            <img src="/nav-favor.svg" alt="" />
                        </div>
                        <div className="tool-item d-block d-sm-none">
                            <img src="/navbar-menu-wrapper.svg" alt="" />
                        </div>
                    </div>

                </div>

                <div className="nav-bottom d-lg-none d-flex">
                    <span>shueh</span>
                    <nav className="main-nav">
                        <ul>
                            <li>Home</li>
                            <li>Catalog</li>
                            <li>Brands</li>
                        </ul>
                    </nav>
                    <div className="tools d-none d-sm-block">
                        <img src="/nav-ins-icon.svg" alt=""></img>
                        <img src="/nav-linkedin-icon.svg" alt=""></img>
                        <img src="/nav-fb-icon.svg" alt=""></img>
                    </div>
                </div>
            </div>
    );
};

Navbar.propTypes = {

};

export default Navbar;