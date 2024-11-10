import request from "../utils/request.js"

// Hàm lấy tất cả đơn hàng
export const getAllOrders = async () => {
    try {
        // Mảng trạng thái đơn hàng
        var status = ["Pending", "Confirmed", "Shipped", "Delivered", "Canceled"];
        // Mảng phương thức thanh toán
        var payment = ["Vnpay", "Cash"];
        
        // Gửi yêu cầu GET để lấy tất cả đơn hàng
        const res = await request.get("/api/Order/all");
        
        // Xử lý dữ liệu trả về từ API
        return res?.data?.orderDTOs?.map((item) => {
            // Tạo đường dẫn đầy đủ cho hình ảnh đơn hàng
            item.imageUrl = `${process.env.REACT_APP_API_URL}/${res.data.imageUrl}`;
            
            // Chuyển đổi trạng thái đơn hàng từ mã số thành tên trạng thái
            if (item.status === 0) item.status = "Pending";
            if (item.status === 1) item.status = "Confirmed";
            if (item.status === 2) item.status = "Shipped";
            if (item.status === 3) item.status = "Delivered";
            if (item.status === 4) item.status = "Canceled";
            
            // Chuyển đổi phương thức thanh toán từ mã số thành tên phương thức
            if (item.paymentMethod === 0) item.paymentMethod = "Vnpay";
            if (item.paymentMethod === 1) item.paymentMethod = "Cash";
            
            return item;
        });
    } catch (error) {
        console.log(error); // Log lỗi nếu có
    }
}

// Hàm lấy thông tin chi tiết một đơn hàng theo ID
export const getOrderById = async (id) => {
    try {
        // Gửi yêu cầu GET để lấy thông tin đơn hàng theo ID
        const res = await request.get(`/api/Order/${id}`);
        
        // Chuyển đổi trạng thái đơn hàng từ mã số thành tên trạng thái
        if (res.data.status === 0) res.data.status = "Pending";
        if (res.data.status === 1) res.data.status = "Confirmed";
        if (res.data.status === 2) res.data.status = "Shipped";
        if (res.data.status === 3) res.data.status = "Delivered";
        if (res.data.status === 4) res.data.status = "Canceled";
        
        console.log(res); // Log thông tin đơn hàng
        return res.data; // Trả về dữ liệu đơn hàng
    } catch (error) {
        console.log(error); // Log lỗi nếu có
    }
}

// Hàm cập nhật trạng thái đơn hàng
export const updateOrder = async (id, status) => {
    var message = "Update order successfully"; // Thông báo thành công
    var type = "success"; // Kiểu thông báo thành công
    try {
        // Gửi yêu cầu PUT để cập nhật trạng thái đơn hàng
        const res = await request.put(`/api/Order/update/${id}/${status}`);
        
        return {
            res: res, // Trả về kết quả từ API
            status: res.status, // Trả về mã trạng thái của phản hồi
            type: type, // Trả về kiểu thông báo
            message: message // Thông báo thành công
        };
    } catch (error) {
        // Nếu có lỗi xảy ra, kiểm tra lỗi và trả về thông báo
        if (error.status === 400) {
            return { 
                error: error,
                status: error.status,
                type: "warning", // Cảnh báo nếu lỗi do dữ liệu không hợp lệ
                message: "Please fill out required fields", // Thông báo lỗi
            };
        }
        return {
            error: error,
            status: error.status,
            type: "error", // Kiểu thông báo lỗi
            message: "Update order failed" // Thông báo lỗi
        };
    }
}

// Hàm xóa một đơn hàng theo ID
export const deleteOrder = async (id) => {
    var message = "Delete order successfully"; // Thông báo thành công
    var type = "success"; // Kiểu thông báo thành công
    try {
        // Gửi yêu cầu DELETE để xóa đơn hàng
        const res = await request.delete(`/api/Order/delete/${id}`);
        
        return {
            res: res, // Trả về kết quả từ API
            status: res.status, // Trả về mã trạng thái của phản hồi
            type: type, // Trả về kiểu thông báo thành công
            message: message // Thông báo thành công
        };
    } catch (error) {
        return {
            error: error,
            status: error.status,
            type: "error", // Kiểu thông báo lỗi
            message: "Delete order failed" // Thông báo lỗi khi xóa thất bại
        };
    }
}
