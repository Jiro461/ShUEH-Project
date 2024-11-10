import request from '../utils/request.js'

// Hàm lấy thông tin sản phẩm đơn lẻ theo id
export const getSingleProduct = async (id) => {
    try {
        // Gửi yêu cầu GET đến API để lấy thông tin sản phẩm
        const res = await request.get(`/api/Shoe/admin/${id}`);
        return {
            // Trả về thông tin sản phẩm, bao gồm id, tên, ảnh và các thông tin chi tiết khác
            id: res.data.shoeDTO.id,
            name: res.data.shoeDTO.name,
            imageUrl: `${process.env.REACT_APP_API_URL}/${res.data.shoeDTO.imageUrl}`,
            info: {
                brand: res.data.shoeDTO.brand,
                price: res.data.shoeDTO.price,
                salePrice: res.data.shoeDTO.salePrice,
                material: res.data.shoeDTO.material,
                category: res.data.shoeDTO.category,
                averageRating: res.data.shoeDTO.averageRating,
                sold: res.data.shoeDTO.sold,
            },
            chart: {
                // Dữ liệu cho biểu đồ
                dataKeys: [
                    { name: "visits", color: "#82ca9d" },
                    { name: "orders", color: "#8884d8" },
                ],
                data: res.data.chart // Dữ liệu cho biểu đồ
            }
        }
    } catch (error) {
        console.log(error); // In lỗi nếu có
    }
}

// Hàm lấy thông tin người dùng đơn lẻ theo id
export const getSingleUser = async (id) => {
    // Hàm so sánh ngày tháng
    const compareDates = (dateString) => {
        // Chuyển chuỗi thành đối tượng Date
        const inputDate = new Date(dateString);
        
        // Lấy ngày hiện tại
        const currentDate = new Date();
        
        // Tính sự khác biệt giữa ngày hiện tại và ngày đã cho (theo mili giây)
        const diffInTime = currentDate - inputDate;
        
        // Chuyển mili giây thành ngày
        const diffInDays = Math.floor(diffInTime / (1000 * 3600 * 24));
      
        // Trả về số ngày
        return diffInDays;
    };

    try {
        // Gửi yêu cầu GET để lấy hoạt động và thông tin người dùng
        const activities = await request.get(`/api/Notification/admin/user/${id}`);
        const user = await request.get(`/api/Account/user/${id}`);
        return {
            // Trả về thông tin người dùng, bao gồm id, tên, avatar, và thông tin chi tiết
            id: user.data.id,
            name: user.data.profileName,
            imageUrl: `${process.env.REACT_APP_API_URL}/${user.data.avatarUrl}`,
            info: {
                firstname: user.data.firstName,
                lastname: user.data.lastName,
                email: user.data.email,
                gender: user.data.gender ? "Male" : "Female", // Kiểm tra giới tính
            },
            // Lọc và xử lý các hoạt động của người dùng
            activities: activities.data.map((activity) => {
                const daysAgo = compareDates(activity.createDate); // Tính số ngày kể từ khi hoạt động
                return {
                    text: activity.adminMessage, // Thông điệp từ quản trị viên
                    time: activity.createDate // Thời gian hoạt động
                }
            }),
        }
    } catch (error) {
        console.log(error); // In lỗi nếu có
    }
}
