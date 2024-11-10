import request from "../utils/request.js"

// Hàm tạo FormData từ dữ liệu người dùng
const createProductFormData = (user) => {
    const formData = new FormData();
    // Thêm các thuộc tính của người dùng vào FormData
    formData.append('FirstName', user.firstName); // Tên đầu
    formData.append('LastName', user.lastName); // Họ
    formData.append('Email', user.email); // Email
    formData.append('ProfileName', user.profileName); // Tên hồ sơ
    formData.append('Gender', user.gender); // Giới tính
    formData.append('Role', user.role); // Vai trò
    formData.append('DateOfBirth', user.dateOfBirth); // Ngày sinh

    // Thêm avatar nếu có
    if (user.avatar) formData.append('Avatar', user.avatar);
    
    return formData; // Trả về FormData đã tạo
};

// Hàm thêm người dùng mới
export const addNewUser = async (user) => {
    var type = "success"; // Kiểu thông báo thành công
    var message = "Add new user successfully"; // Thông báo thành công
    try {
        // Gửi yêu cầu POST để thêm người dùng mới
        const res = await request.post("/api/Account/add", user);    
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        };
    } catch (error) {
        // Xử lý lỗi nếu có
        if (error.status === 400) {
            return { 
                error: error,
                status: error.status,
                type: "warning", // Kiểu thông báo cảnh báo
                message: "Please fill out required fields", // Thông báo yêu cầu điền đầy đủ trường
            };
        }
        return {
            error: error,
            status: error.status,
            type: "error", // Kiểu thông báo lỗi
            message: "Add new user failed" // Thông báo nếu thêm người dùng thất bại
        };
    }
}

// Hàm lấy tất cả người dùng
export const getAllUsers = async () => {
    try {
        // Gửi yêu cầu GET để lấy tất cả người dùng
        const res = await request.get("/api/Account/get-users-info");
        // Xử lý dữ liệu trả về
        return res.data.map((item) => {
            item.avatarUrl = `${process.env.REACT_APP_API_URL}/${item.avatarUrl}`; // Thêm đường dẫn đầy đủ cho ảnh đại diện
            return item;
        });
    } catch (error) {
        console.log(error); // Log lỗi nếu có
    }
}

// Hàm lấy thông tin người dùng theo ID
export const getUserById = async (id) => {
    try {
        // Gửi yêu cầu GET để lấy thông tin người dùng theo ID
        const res = await request.get(`/api/Account/user/${id}`);
        res.data.avatarUrl = `${process.env.REACT_APP_API_URL}/${res.data.avatarUrl}`; // Thêm đường dẫn đầy đủ cho ảnh đại diện
        return res.data; // Trả về dữ liệu người dùng
    } catch (error) {
        console.log(error); // Log lỗi nếu có
    }
}

// Hàm cập nhật thông tin người dùng
export const updateUser = async (id, user) => {
    const formData = createProductFormData(user); // Tạo FormData từ dữ liệu người dùng
    var type = "success"; // Kiểu thông báo thành công
    var message = "Update user successfully"; // Thông báo thành công
    try {
        // Gửi yêu cầu PUT để cập nhật người dùng
        const res = await request.put(`/api/Account/${id}`, formData, {
            headers: "multipart/form-data" // Thiết lập header cho tải lên tệp
        });
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        };
    } catch (error) {
        // Xử lý lỗi nếu có
        if (error.status === 400) {
            return { 
                error: error,
                status: error.status,
                type: "warning", // Kiểu thông báo cảnh báo
                message: "Please fill out required fields", // Thông báo yêu cầu điền đầy đủ trường
            };
        }
        return {
            error: error,
            status: error.status,
            type: "error", // Kiểu thông báo lỗi
            message: "Update user failed" // Thông báo nếu cập nhật người dùng thất bại
        };
    }
}

// Hàm xóa người dùng theo ID
export const deleteUser = async (id) => {
    var type = "success"; // Kiểu thông báo thành công
    var message = "Delete user successfully"; // Thông báo thành công
    try {
        // Gửi yêu cầu DELETE để xóa người dùng
        const res = await request.delete(`/api/Account/admin/delete/${id}`);    
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
            type: "error", // Kiểu thông báo lỗi
            message: "Delete user failed" // Thông báo nếu xóa người dùng thất bại
        };
    }
}
