import request from "../utils/request";
import { loginFailed, loginStart, loginSuccess } from "../redux/authSlice";

// Hàm kiểm tra trạng thái đăng nhập của người dùng
export const loginStatus = async () => {
    try {
        // Gửi yêu cầu GET để kiểm tra cookie đăng nhập
        const res = await request.get("/api/Account/cookieGetById");
        return res; // Trả về phản hồi
    } catch (error) {
        return error; // Trả về lỗi nếu có
    }
}

// Hàm đăng nhập người dùng
export const loginUser = async (user, dispatch, navigate) => {
    var type = "success"; // Kiểu thông báo thành công
    var message = "Login successfully"; // Thông báo thành công
    try {
        // Gửi yêu cầu POST để đăng nhập
        const res = await request.post("/api/Account/login", user);
        // Lấy cookie đăng nhập và cập nhật trạng thái Redux
        const cookie = await request.get("/api/Account/cookieGetById");
        dispatch(loginSuccess(cookie.data));
        
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        };
    } catch (error) {
        // Xử lý lỗi khi đăng nhập
        if (error.status === 400) {
            return { 
                error: error,
                status: error.status,
                type: "warning", // Thông báo cảnh báo
                message: "Invalid username or password", // Thông báo sai tài khoản hoặc mật khẩu
            };
        }
        if (error.status === 401) {
            return { 
                error: error,
                status: error.status,
                type: "warning", // Thông báo cảnh báo
                message: "You're allowed to do that", // Thông báo quyền truy cập bị từ chối
            };
        }
        return {
            error: error,
            status: error.status,
            type: "error", // Thông báo lỗi
            message: "Login failed" // Thông báo đăng nhập thất bại
        };
    }
}

// Hàm đăng ký người dùng mới
export const registerUser = async (user) => {
    var type = "success"; // Kiểu thông báo thành công
    var message = "Register successfully"; // Thông báo thành công
    try {
        // Gửi yêu cầu POST để đăng ký
        const res = await request.post("/api/Account/register", user);
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        };
    } catch (error) {
        // Xử lý lỗi khi đăng ký
        if (error.status === 400) {
            return { 
                error: error,
                status: error.status,
                type: "warning", // Thông báo cảnh báo
                message: "Please fill out required fields", // Thông báo điền đầy đủ thông tin
            };
        }
        return {
            error: error,
            status: error.status,
            type: "error", // Thông báo lỗi
            message: "Register failed" // Thông báo đăng ký thất bại
        };
    }
}

// Hàm đăng xuất người dùng
export const logoutUser = async () => {
    var type = "success"; // Kiểu thông báo thành công
    var message = "You're been logout"; // Thông báo đăng xuất thành công
    try {
        // Gửi yêu cầu POST để đăng xuất
        const res = await request.post("/api/Account/sign-out");
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        };
    } catch (error) {
        return {
            error: error,
            status: error.status,
            type: "error", // Thông báo lỗi
            message: "Logout failed" // Thông báo đăng xuất thất bại
        };
    }
}

// Hàm gửi yêu cầu lấy mã OTP để khôi phục mật khẩu
export const forgotPasswordUser = async (email) => {
    var type = "info"; // Kiểu thông báo thông tin
    var message = "OTP has been sent to your email"; // Thông báo mã OTP đã được gửi
    try {
        // Tạo đối tượng gửi email để yêu cầu lấy mã OTP
        const emailPost = {
            email: email
        };
        // Gửi yêu cầu POST để gửi mã OTP
        const res = await request.post("/api/Email/forgot-password", emailPost);
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        };
    } catch (error) {
        return {
            error: error,
            status: error.status,
            type: "error", // Thông báo lỗi
            message: "Invalid email" // Thông báo email không hợp lệ
        };
    }
}

// Hàm xác minh OTP và thay đổi mật khẩu
export const resetPasswordUser = async (email, otp, password) => {
    var type = "success"; // Kiểu thông báo thành công
    var message = "Change password successfully"; // Thông báo thay đổi mật khẩu thành công
    try {
        // Tạo đối tượng gửi yêu cầu xác minh OTP và thay đổi mật khẩu
        const resetPassword = {
            email: email,
            otp: otp,
            newPassword: password
        };
        // Gửi yêu cầu POST để xác minh OTP và thay đổi mật khẩu
        const res = await request.post("/api/Email/verify-otp", resetPassword);
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        };
    } catch (error) {
        // Xử lý lỗi khi xác minh OTP
        if (error.status === 400) {
            return { 
                error: error,
                status: error.status,
                type: "warning", // Thông báo cảnh báo
                message: "Invalid OTP", // Thông báo OTP không hợp lệ
            };
        }
        return {
            error: error,
            status: error.status,
            type: "error", // Thông báo lỗi
            message: "Change password failed" // Thông báo thay đổi mật khẩu thất bại
        };
    }
}
