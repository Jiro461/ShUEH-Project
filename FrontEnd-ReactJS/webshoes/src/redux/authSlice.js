import { createSlice } from "@reduxjs/toolkit"; // Import createSlice từ Redux Toolkit để tạo slice
import * as authService from "../services/authService"; // Import các dịch vụ liên quan đến auth

// Tạo slice cho phần auth
const authSlice = createSlice({
    name: "auth", // Tên của slice là "auth"
    initialState: {
        login: { // Trạng thái ban đầu cho login
            currentUser: null, // Người dùng hiện tại, mặc định là null
            isFetching: false, // Biến trạng thái cho việc đang lấy dữ liệu
            error: false, // Biến trạng thái khi có lỗi
        }
    },
    reducers: {
        // Reducer cho việc bắt đầu quá trình đăng nhập
        loginStart: (state) => {
            state.login.isFetching = true; // Đánh dấu là đang lấy dữ liệu
        },
        // Reducer cho khi đăng nhập thành công
        loginSuccess: (state, action) => {
            state.login.isFetching = false; // Dừng trạng thái đang lấy dữ liệu
            state.login.error = false; // Không có lỗi
            state.login.currentUser = action.payload; // Cập nhật người dùng hiện tại
        },
        // Reducer cho khi đăng nhập thất bại
        loginFailed: (state) => {
            state.login.isFetching = false; // Dừng trạng thái đang lấy dữ liệu
            state.login.error = true; // Đánh dấu có lỗi
        },
        // Reducer cho khi đăng xuất thành công
        logoutSuccess: (state) => {
            state.login.currentUser = null; // Đặt lại người dùng hiện tại thành null
        }
    }
});

// Export các action từ slice
export const {
    loginStart,
    loginFailed,
    loginSuccess,
    logoutSuccess
} = authSlice.actions;

// Export reducer của authSlice
export default authSlice.reducer;
