import request from "../utils/request.js"; // Import request để gửi các yêu cầu HTTP

// Thêm một mã giảm giá mới
export const addNewDiscount = async (discount) => {
    var message = "Add new discount successfully"; // Thông báo thành công
    var type = "success"; // Kiểu thông báo là success
    try {
        // Gửi yêu cầu POST để thêm mã giảm giá mới
        const res = await request.post("/api/Discount/add", discount);    
        return {
            res: res, // Kết quả trả về
            status: res.status, // Mã trạng thái HTTP
            type: type, // Kiểu thông báo
            message: message // Thông báo thành công
        }
    } catch (error) {
        // Nếu có lỗi, kiểm tra trạng thái lỗi
        if (error.status === 400){
            return { 
                error: error,
                status: error.status,
                type: "warning", // Kiểu thông báo là cảnh báo
                message: "Please fill out required fields", // Thông báo cần điền đầy đủ các trường bắt buộc
            }
        }
        // Trả về lỗi chung nếu không phải lỗi 400
        return {
            error: error,
            status: error.status,
            type: "error", // Kiểu thông báo là lỗi
            message: "Add new discount failed" // Thông báo thất bại
        }
    }
}

// Lấy tất cả các mã giảm giá
export const getAllDiscounts = async () => {
    try {
        const res = await request.get("/api/Discount/all"); // Gửi yêu cầu GET để lấy tất cả các mã giảm giá
        return res.data.map((item) => { // Duyệt qua các mã giảm giá và xử lý
            if (item.percentage){
                item.percentage = `${item.percentage}%`; // Thêm ký hiệu "%" vào phần trăm
            }
            if (item.type === 0){
                item.type = "Ship"; // Loại giảm giá là miễn phí vận chuyển
            } else if (item.type === 1){
                item.type = "Order"; // Loại giảm giá là giảm giá đơn hàng
            }
            return item; // Trả về mã giảm giá đã xử lý
        });
    } catch (error) {
        console.log(error); // Nếu có lỗi, ghi log lỗi
    }
}

// Lấy mã giảm giá theo ID
export const getDiscountById = async (id) => {
    try {
        const res = await request.get(`/api/Discount/${id}`); // Gửi yêu cầu GET để lấy mã giảm giá theo ID
        return res.data; // Trả về dữ liệu của mã giảm giá
    } catch (error) {
        console.log(error); // Nếu có lỗi, ghi log lỗi
    }
}

// Cập nhật mã giảm giá
export const updateDiscount = async (id, discount) => {
    var message = "Update discount successfully"; // Thông báo thành công
    var type = "success"; // Kiểu thông báo là success
    try {
        // Gửi yêu cầu PUT để cập nhật mã giảm giá
        const res = await request.put(`/api/Discount/update/${id}`, discount);
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        }
    } catch (error) {
        // Nếu có lỗi, kiểm tra trạng thái lỗi
        if (error.status === 400){
            return { 
                error: error,
                status: error.status,
                type: "warning", // Kiểu thông báo là cảnh báo
                message: "Please fill out required fields", // Thông báo cần điền đầy đủ các trường bắt buộc
            }
        }
        // Trả về lỗi chung nếu không phải lỗi 400
        return {
            error: error,
            status: error.status,
            type: "error", // Kiểu thông báo là lỗi
            message: "Update discount failed" // Thông báo thất bại
        }
    }
}

// Xóa mã giảm giá
export const deleteDiscount = async (id) => {
    var message = "Delete discount successfully"; // Thông báo thành công
    var type = "success"; // Kiểu thông báo là success
    try {
        // Gửi yêu cầu DELETE để xóa mã giảm giá
        const res = await request.delete(`/api/Discount/delete/${id}`);    
        return {
            res: res,
            status: res.status,
            type: type,
            message: message
        }
    } catch (error) {
        // Trả về thông báo lỗi nếu yêu cầu xóa thất bại
        return {
            error: error,
            status: error.status,
            type: "error", // Kiểu thông báo là lỗi
            message: "Delete discount failed" // Thông báo thất bại
        }
    }
}
