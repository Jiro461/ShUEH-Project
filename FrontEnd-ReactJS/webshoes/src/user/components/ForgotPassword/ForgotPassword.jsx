import React, { useState } from 'react';
import './ForgotPassword.scss'
import * as authService from "../../../services/authService"
import { loginUser } from "../../../redux/request";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";

const ForgotPassword = (props) => {
    const [forgotPassword, setForgotPassword] = useState(true)
    const [email, setEmail] = useState()
    const [otp, setOtp] = useState()
    const [password, setPassword] = useState()
    const dispatch = useDispatch()
    const navigate = useNavigate()

    const handleSubmit = async (e) => {
        e.preventDefault()
        props.setOpenBackDrop(true)
        let res = {}
        if (forgotPassword){
            res = await authService.forgotPasswordUser(email)
        } else {
            res = await authService.resetPasswordUser(email, otp, password)
        }
        
        props.handleNoti(res)
        if (res.status === 200){
            setForgotPassword(false)
        }  
    }
    return (
        <div className="overlay" onClick={() => props.setOpenLogin(false)}>
            <div className="forgotPassword-block" onClick={(e) => e.stopPropagation()}>
                <div className="forgotPassword-content">
                    <div className="close" onClick={() => props.setOpenLogin(false)}>
                        <i className="fa-solid fa-xmark"></i>
                    </div>
                    <div className="logo">
                        <img className="logo" src="/shueh-logo.svg" alt=""></img>
                    </div>

                    <div className="heading">
                        <h1>Forgot Password</h1>
                    </div>

                    <form onSubmit={handleSubmit}>
                        {forgotPassword ? 
                        (<div className="email">
                            <label>Email</label>
                            <input type="text" placeholder="Please enter your email to get OTP" onChange={(e)=>setEmail(e.target.value)}></input>
                        </div>) 
                        : (<div>
                            <div className="email-disabled">
                                <label>Email</label>
                                <input type="text" disabled="true" value={email}></input>
                            </div>
                            <div className="otp">
                                <label>Otp</label>
                                <input type="text" placeholder="Otp" onChange={(e)=>setOtp(e.target.value)}></input>
                            </div>
                            <div className="password">
                                <label>Password</label>
                                <input type="text" placeholder="Password" onChange={(e)=>setPassword(e.target.value)}></input>
                            </div>
                        </div>)}
                        
                        <button className="btn-submit" type="submit">{forgotPassword ? "Send OTP" : "Reset Password"}</button>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default ForgotPassword;