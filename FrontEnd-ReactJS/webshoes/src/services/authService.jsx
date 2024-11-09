import request from "../utils/request";
import { loginFailed, loginStart, loginSuccess } from "../redux/authSlice";

export const loginStatus = async () => {
    try {
        const res = await request.get("/api/Account/cookieGetById")
        return res
    } catch (error) {
        return error
    }
}

export const loginUser = async (user, dispatch, navigate) => {
    var type = "success"
    var message = "Login successfully"
    try {
            const res = await request.post("/api/Account/login", user)
            const cookie = await request.get("/api/Account/cookieGetById")
            dispatch(loginSuccess(cookie.data))
            
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        }
    } catch (error) {
        if (error.status === 400){
            return { 
                error: error,
                status: error.status,
                type: "warning",
                message: "Invalid username or password",
            }
        }
        if (error.status === 401){
            return { 
                error: error,
                status: error.status,
                type: "warning",
                message: "You're allowed to do that",
            }
        }
        return {
            error: error,
            status: error.status,
            type: "error",
            message: "Login failed"
        }
    }
}

export const registerUser = async (user) => {
    var type = "success"
    var message = "Register successfully"
    try {
        const res = await request.post("/api/Account/register", user)
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        }
    } catch (error) {
        if (error.status === 400){
            return { 
                error: error,
                status: error.status,
                type: "warning",
                message: "Please fill out required fields",
            }
        }
        return {
            error: error,
            status: error.status,
            type: "error",
            message: "Register failed"
        }
    }
}

export const logoutUser = async () => {
    var type = "success"
    var message = "You're been logout"
    try {
        const res = await request.post("/api/Account/sign-out")
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        }
    } catch (error) {
        return {
            error: error,
            status: error.status,
            type: "error",
            message: "Logout failed"
        }
    }
}

export const forgotPasswordUser = async (email) => {
    var type = "info"
    var message = "OTP has been sent to your email"
    try {
        const emailPost = {
            email: email
        }
        const res = await request.post("/api/Email/forgot-password", emailPost)
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        }
    } catch (error) {
        return {
            error: error,
            status: error.status,
            type: "error",
            message: "Invalid email"
        }
    }
}

export const resetPasswordUser = async (email, otp, password) => {
    var type = "success"
    var message = "Change password successfully"
    try {
        const resetPassword = {
            email: email,
            otp: otp,
            newPassword: password
        }
        const res = await request.post("/api/Email/verify-otp", resetPassword)
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        }
    } catch (error) {
        if (error.status === 400){
            return { 
                error: error,
                status: error.status,
                type: "warning",
                message: "Invalid OTP",
            }
        }
        return {
            error: error,
            status: error.status,
            type: "error",
            message: "Change password failed"
        }
    }
}
