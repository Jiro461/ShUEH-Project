import React, { useState } from 'react';
import './ForgotPassword.scss'
import * as authService from "../../../services/authService" // Import dịch vụ xác thực
import { loginUser } from "../../../redux/request"; // Không sử dụng trong mã hiện tại, có thể xóa
import { useDispatch } from "react-redux"; // Để sử dụng Redux dispatch (không sử dụng trong mã hiện tại)
import { useNavigate } from "react-router-dom"; // Để điều hướng tới các trang khác

const ForgotPassword = (props) => {
    const [forgotPassword, setForgotPassword] = useState(true) // Biến trạng thái để kiểm tra xem đang ở trang "quên mật khẩu" hay "đặt lại mật khẩu"
    const [email, setEmail] = useState() // Biến trạng thái cho email
    const [otp, setOtp] = useState() // Biến trạng thái cho mã OTP
    const [password, setPassword] = useState() // Biến trạng thái cho mật khẩu mới
    const dispatch = useDispatch() // Redux dispatch (không sử dụng trong mã hiện tại)
    const navigate = useNavigate() // Dùng để điều hướng tới các trang khác (không sử dụng trong mã hiện tại)

    const handleSubmit = async (e) => {
        e.preventDefault() // Ngăn chặn hành vi mặc định của form (submit)
        props.setOpenBackDrop(true) // Mở màn hình chờ (backdrop)
        let resForgot = {} // Biến lưu kết quả khi quên mật khẩu
        let resReset = {} // Biến lưu kết quả khi đặt lại mật khẩu
        if (forgotPassword){
            resForgot = await authService.forgotPasswordUser(email) // Gửi yêu cầu quên mật khẩu
        } else {
            resReset = await authService.resetPasswordUser(email, otp, password) // Gửi yêu cầu đặt lại mật khẩu
        }
        // Nếu yêu cầu quên mật khẩu thành công
        if (resForgot.status === 200){
            setForgotPassword(false) // Chuyển sang trạng thái nhập OTP và mật khẩu mới
            props.handleNoti(resForgot) // Hiển thị thông báo thành công
        }  
        // Nếu yêu cầu đặt lại mật khẩu thành công
        if (resReset.status === 200){
            props.setOpenForgotPassword(false) // Đóng form quên mật khẩu
            props.setOpenLogin(true) // Mở form đăng nhập
            props.handleNoti(resReset) // Hiển thị thông báo thành công
        }
    }
    return (
        <div className="overlay" onClick={() => props.setOpenLogin(false)}> 
            {/* Nếu nhấn ra ngoài form, đóng form đăng nhập */}
            <div className="forgotPassword-block" onClick={(e) => e.stopPropagation()}>
                {/* Ngăn sự kiện click lan tỏa ra ngoài */}
                <div className="forgotPassword-content">
                    <div className="close" onClick={() => props.setOpenLogin(false)}>
                        {/* Đóng form khi nhấn vào nút đóng */}
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
                                <input type="password" placeholder="Password" onChange={(e)=>setPassword(e.target.value)}></input>
                            </div>
                        </div>)}
                        
                        <button className="btn-submit" type="submit">{forgotPassword ? "Send OTP" : "Reset Password"}</button>
                        {/* Nếu đang ở trang quên mật khẩu, nút sẽ là "Send OTP", nếu ở trang reset mật khẩu, nút sẽ là "Reset Password" */}
                    </form>
                </div>
            </div>
        </div>
    );
};

export default ForgotPassword;
