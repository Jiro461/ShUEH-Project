import React, { useEffect, useState } from 'react';
import './Navbar.scss'
import Login from "../Login/Login";
import Register from "../Register/Register";
import { Alert, Backdrop, CircularProgress, Slide, Snackbar } from "@mui/material";
import * as authService from "../../../services/authService";
import { useDispatch, useSelector } from "react-redux"
import { Link, useNavigate } from "react-router-dom";
import { loginSuccess } from "../../../redux/authSlice";

const Navbar = (props) => {
    const [openLogin, setOpenLogin] = useState(false)
    const [openRegister, setOpenRegister] = useState(false)
    const [openBackDrop, setOpenBackDrop] = useState(false)
    const [openToastMessage, setOpenToastMessage] = useState(false)
    const [typeToastMessage, setTypeToastMessage] = useState("")
    const [titleToastMessage, setTitleToastMessage] = useState("")
    const navbar = [
        { name: "Home", path: "/"},
        { name: "Brands", path: "/"},
        { name: "New", path: "/product?isNew=true"},
        { name: "Sale", path: "/product?isSale=true"},
        { name: "Support", path: "/"},
    ]
    const subnav = [
        { name: "Home", path: "/"},
        { name: "Brands", path: "/"},
        { name: "New", path: "/product?isNew=true"},
    ]
    const sidebarTools = [
        { src: "/nav-shopping-bag-none-noti.svg", name: "Cart", path: "/payment"},
        { src: "/nav-user.svg", name: "Account", path: "/profile"},
        { src: "/nav-favor.svg", name: "Favourite", path: "/profile/favour"},
    ]
    const [active, setActive] = useState("Home")
    const [openSideBar, setOpenSideBar] = useState(false)
    const user = useSelector((state) => state.auth.login.currentUser)
    const dispatch = useDispatch()
    const navigate = useNavigate()
    useEffect(() => {
        const checkAuth = async () => {
            const res = await authService.loginStatus()
            if (res.status === 200){
                dispatch(loginSuccess(res.data))
            }
        }
        checkAuth()
    },[]) 
    const handleNavbarClick = (e) => {
        setActive(e.currentTarget.textContent);
    }
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
        dispatch(loginSuccess(null))
        navigate("/")
    }
   
    return (
            <div className='navbar-block'>
            
                <marquee direction="right" scrollamount="15" className="promotion text-center d-none d-sm-block">
                    FREESHIP CHO HOÁ ĐƠN TRÊN 1 TRIỆU
                </marquee>

                <div className="nav-box">

                    <div className="logo">  
                        <Link to="/"><img src="/shueh-logo.svg" alt=""></img></Link>
                    </div>

                    <nav className="main-nav d-none d-lg-block">
                        <ul>
                            {navbar.map((item, index) => {
                                return <li key={index} className={active === item.name ? "active" : ""} onClick={handleNavbarClick}>
                                    <Link to={item.path}>{item.name}</Link>
                                </li>
                            })}
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
                        <div className="tool-item cart-icon" onClick={() => navigate("/payment")}>
                            <img src="/nav-shopping-bag-none-noti.svg" alt="" />
                            <span className="cart-noti">1</span>
                        </div>
                        <div className="tool-item d-none">
                            <img src="/navbar-menu-wrapper.svg" alt="" />
                        </div>

                        {user ? (<>
                            <div className="tool-item" onClick={() => navigate("/profile")}>
                                <img src="/nav-user.svg" alt="" />
                            </div> 
                            <div className="tool-item d-block d-md-none" onClick={() => setOpenSideBar(true)}>
                                <img src="/navbar-menu-wrapper.svg" alt="" />
                            </div>
                            <div className="tool-item d-none d-md-block" onClick={() => navigate("/profile/favour")}>
                                <img src="/nav-favor.svg" alt="" />
                            </div>
                            <div className="tool-item btn btn-logout d-none d-md-block" onClick={handleLogout}>
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
                            {subnav.map((item, index) => {
                                return <li key={index}>
                                    <Link to={item.path}>{item.name}</Link>
                                    </li>
                            })}
                        </ul>
                    </nav>
                    <div className="tools d-none d-sm-block">
                        <img src="/nav-ins-icon.svg" alt=""></img>
                        <img src="/nav-linkedin-icon.svg" alt=""></img>
                        <img src="/nav-fb-icon.svg" alt=""></img>
                    </div>
                </div>

                {openSideBar && <div className="sidebar-overlay">
                    
                    <div className="sidebar-content">
                    <div className="sidebar-btn-close" onClick={() => setOpenSideBar(false)}>X</div>
                        <div className="sidebar-nav">
                            {navbar.map((item, index) => {
                                return <div key={index} className="sidebar-nav-item" onClick={() => {
                                    setOpenSideBar(false)
                                    navigate(item.path)
                                }}>
                                    <span>{item.name}</span>
                                    <span><i className="fa-solid fa-angle-right"></i></span>
                                </div>
                            })}
                        </div>

                        <div className="sidebar-tools">
                            {sidebarTools.map((item, index) => {
                                return <div key={index} className="sidebar-tool-item" onClick={() => {
                                    setOpenSideBar(false)
                                    navigate(item.path)
                                }}>
                                <img src={item.src} alt=""></img>
                                <span>{item.name}</span>
                            </div>
                            })}
                        </div>
                    </div>

                    <div className="sidebar-btn">
                    {!user ? (<>
                            <div className="sidebar-btn-logout" onClick={handleLogout}>
                                Log out
                            </div>
                        </>) : (<>
                            <div className="sidebar-btn-item sidebar-btn-login" onClick={() => {
                                setOpenSideBar(false)
                                setOpenLogin(true)
                            }}>
                                Login
                            </div>
                            <div className="sidebar-btn-item sidebar-btn-register" onClick={() => {
                                setOpenSideBar(false)
                                setOpenRegister(true)
                            }}>
                                Register
                            </div>
                        </>)}
                    </div>
                </div>}

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