import axios from "axios";

// Tạo đối tượng axios với cấu hình cơ bản cho các yêu cầu API
const request = axios.create({
    baseURL: `${process.env.REACT_APP_API_URL}/`, // Cấu hình URL cơ sở từ biến môi trường
    withCredentials: true // Cho phép gửi cookie trong các yêu cầu (nếu cần)
})

// Hàm GET để gửi yêu cầu lấy dữ liệu từ API
export const get = async (path, options = {}) => {
    // Gửi yêu cầu GET đến đường dẫn được chỉ định và trả về dữ liệu
    const response = await request.get(path, options)
    return response.data // Trả về dữ liệu của phản hồi
}

// Xuất đối tượng axios với cấu hình đã tạo
export default request
