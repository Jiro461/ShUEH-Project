namespace BackEnd_ASP_NET.Models
{
    // Enum định nghĩa các trạng thái của đơn hàng
    // Giúp theo dõi quá trình xử lý đơn hàng
    public enum OrderStatus
    {
        Pending,     // Đơn hàng đang chờ xử lý
        Confirmed,   // Đơn hàng đã được xác nhận
        Shipped,     // Đơn hàng đã được gửi đi
        Delivered,   // Đơn hàng đã được giao
        Canceled     // Đơn hàng bị hủy
    }

    // Enum định nghĩa các loại giảm giá có thể áp dụng cho đơn hàng
    public enum DiscountType
    {
        ShippingFee, // Giảm giá cho phí vận chuyển
        OrderFee,    // Giảm giá cho tổng phí đơn hàng
    }

    // Enum định nghĩa các phương thức thanh toán hỗ trợ
    public enum PaymentMethod
    {
        VnPay,       // Phương thức thanh toán qua VNPay
        Cash,        // Phương thức thanh toán bằng tiền mặt
    }

    // Enum định nghĩa các mức độ đánh giá chung của sản phẩm/dịch vụ
    public enum GeneralReview
    {
        VeryGood,    // Đánh giá rất tốt
        Good,        // Đánh giá tốt
        Average,     // Đánh giá trung bình
        Bad,         // Đánh giá xấu
        VeryBad,     // Đánh giá rất xấu
    }

    // Lớp chứa các tên vai trò trong hệ thống để dễ dàng sử dụng và tránh lặp lại chuỗi
    // Cung cấp khả năng kiểm tra vai trò người dùng trong hệ thống
    public static class RoleName
    {
        public const string User = "User";   // Vai trò người dùng bình thường
        public const string Admin = "Admin"; // Vai trò quản trị viên
    }
}
