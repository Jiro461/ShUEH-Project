import React, { useEffect, useState } from 'react';
import './Navbar.scss'
import Login from "../Login/Login";
import Register from "../Register/Register";
import { Alert, Backdrop, CircularProgress, Slide, Snackbar } from "@mui/material";
import * as authService from "../../../services/authService";
import { useSelector } from "react-redux"
import { useNavigate } from "react-router-dom";

const Navbar = (props) => {
    const [openLogin, setOpenLogin] = useState(false)
    const [openRegister, setOpenRegister] = useState(false)
    const [openBackDrop, setOpenBackDrop] = useState(false)
    const [openToastMessage, setOpenToastMessage] = useState(false)
    const [typeToastMessage, setTypeToastMessage] = useState("")
    const [titleToastMessage, setTitleToastMessage] = useState("")
    const user = useSelector((state) => state.auth.login.currentUser)
    const navigate = useNavigate()
    function SlideTransition(props) {
        return <Slide {...props} direction="left" />;
      }
    
      const handleClose = (event, reason) => {
        if (reason === 'clickaway') {
          return;
        }
    
        setOpenToastMessage(false);
      }
    const handleNoti = (res) => {
        setOpenToastMessage(true)
        setTypeToastMessage(res.type)
        setTitleToastMessage(res.message)
        setOpenBackDrop(false)
    }
    const handleLogout = async () => {
        const res = await authService.logoutUser()
        handleNoti(res)
        props.setData(null)
        navigate("/")
    }
   
    return (
            <div className='navbar-block'>
            
                <marquee direction="right" scrollamount="15" className="promotion text-center d-none d-sm-block">
                    FREESHIP CHO HOÁ ĐƠN TRÊN 1 TRIỆU
                </marquee>

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
                        <div className="tool-item d-none">
                            <img src="/navbar-menu-wrapper.svg" alt="" />
                        </div>

                        {user ? (<>
                            <div className="tool-item">
                                <img src="/nav-user.svg" alt="" />
                            </div>
                            <div className="tool-item">
                                <img src="/nav-favor.svg" alt="" />
                            </div>
                            <div className="tool-item">
                                Hi, {user.profileName}
                            </div>
                            <div className="tool-item btn btn-logout" onClick={handleLogout}>
                                Log out
                            </div>
                        </>) : (<>
                            <div className="tool-item btn" onClick={() => setOpenLogin(true)}>
                                Login
                            </div>
                            <div className="tool-item btn" onClick={() => setOpenRegister(true)}>
                                Register
                            </div>
                        </>)}
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

                {openLogin && <Login 
                setOpenLogin={setOpenLogin} 
                setOpenRegister={setOpenRegister}
                setOpenBackDrop={setOpenBackDrop} 
                handleNoti={handleNoti}
                setData={props.setData}
                />}

                {openRegister && <Register 
                setOpenLogin={setOpenLogin} 
                setOpenRegister={setOpenRegister} 
                setOpenBackDrop={setOpenBackDrop} 
                handleNoti={handleNoti}/>}

                {openBackDrop && (<Backdrop
                sx={(theme) => ({ color: '#fff', zIndex: theme.zIndex.drawer + 1 })}
                open={openBackDrop}
                >
                <CircularProgress color="inherit" />
                </Backdrop>)}

                {openToastMessage && (<Snackbar
                open={openToastMessage}
                autoHideDuration={3000}
                onClose={handleClose}
                TransitionComponent={SlideTransition}
                anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
                >
                <Alert severity={typeToastMessage} sx={{ width: '100%' }}>
                {titleToastMessage}
                </Alert>
                </Snackbar>)}
            </div>
    );
};

Navbar.propTypes = {

};

export default Navbar;