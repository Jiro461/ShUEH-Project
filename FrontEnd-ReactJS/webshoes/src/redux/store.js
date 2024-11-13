import { configureStore } from '@reduxjs/toolkit'; // Import configureStore từ Redux Toolkit để cấu hình store
import authReducer from "./authSlice"; // Import reducer auth từ authSlice

// Cấu hình và tạo store Redux
export default configureStore({
    reducer: {
        auth: authReducer // Gán reducer auth cho phần trạng thái auth trong store
    }
});
