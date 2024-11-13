using System.Text.RegularExpressions;

namespace BackEnd_ASP.NET.Services.VnPay
{
    // Lớp dịch vụ VnPay, triển khai giao diện IVnPayService
    public class VnPayService : IVnPayService
    {
        // Biến thành viên để lưu trữ cấu hình
        private readonly IConfiguration _config;

        // Hàm khởi tạo, nhận vào một đối tượng IConfiguration
        public VnPayService(IConfiguration configuration)
        {
            this._config = configuration;
        }

        // Phương thức tạo URL thanh toán
        public string CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model)
        {
            // Tạo một chuỗi tick từ thời gian hiện tại
            var tick = DateTime.Now.Ticks.ToString();
            var vnpay = new VnPayLibrary();

            // Thêm dữ liệu yêu cầu vào thư viện VnPay
            vnpay.AddRequestData("vnp_Version", _config["VnPay:Version"] ?? "2.1.0");
            vnpay.AddRequestData("vnp_Command", _config["VnPay:Command"] ?? "pay");
            vnpay.AddRequestData("vnp_TmnCode", _config["VnPay:TmnCode"] ?? "12345678");
            vnpay.AddRequestData("vnp_Amount", (model.Amount * 100).ToString());
            vnpay.AddRequestData("vnp_CreateDate", model.CreateDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", _config["VnPay:CurrCode"] ?? "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
            vnpay.AddRequestData("vnp_Locale", _config["VnPay:Locale"] ?? "vn");
            vnpay.AddRequestData("vnp_OrderInfo", $"{model.FullName} thanh toán đơn hàng {model.OrderId} với tổng giá {model.Amount}");
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", _config["VnPay:PaymentBackReturnUrl"] ?? "https://shueh.somee.com/api/payment/payment-callback");
            vnpay.AddRequestData("vnp_TxnRef", tick);

            // Tạo URL yêu cầu thanh toán
            var paymentUrl = vnpay.CreateRequestUrl(_config["VnPay:BaseUrl"] ?? "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html", _config["VnPay:HashSecret"] ?? "12345678");
            return paymentUrl;
        }

        // Phương thức thực thi thanh toán
        public VnPaymentResponseModel PaymentExecute(IQueryCollection collections)
        {
            var vnpay = new VnPayLibrary();

            // Duyệt qua các cặp key-value trong collections
            foreach (var (key, value) in collections)
            {
                // Chỉ thêm dữ liệu phản hồi nếu key không rỗng và bắt đầu với "vnp_"
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(key, value.ToString());
                }
            }

            // Trích xuất thông tin đơn hàng và các thông tin cần thiết khác
            var vnp_orderId = ExtractOrderId(vnpay.GetResponseData("vnp_OrderInfo"));
            var vnp_TransactionId = vnpay.GetResponseData("vnp_TransactionId");
            var vnp_SecureHash = collections.FirstOrDefault(x => x.Key == "vnp_SecureHash").Value;
            var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            var vnp_OrderInfo = vnpay.GetResponseData("vnp_OrderInfo");

            // Kiểm tra chữ ký bảo mật
            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash!, _config["VnPay:HashSecret"] ?? string.Empty);
            if (!checkSignature || vnp_orderId == Guid.Empty)
            {
                // Trả về kết quả thất bại nếu chữ ký không hợp lệ hoặc không tìm thấy orderId
                return new VnPaymentResponseModel
                {
                    Success = false,
                };
            }

            // Trả về kết quả thành công nếu chữ ký hợp lệ
            return new VnPaymentResponseModel
            {
                Success = true,
                PaymentMethod = "VnPay",
                OrderDescription = vnp_OrderInfo,
                OrderId = vnp_orderId.ToString(),
                TransactionId = vnp_TransactionId.ToString(),
                Token = vnp_SecureHash!,
                VnPayResponseCode = vnp_ResponseCode
            };
        }

        // Phương thức trích xuất OrderId từ thông tin đơn hàng
        private Guid ExtractOrderId(string orderInfo)
        {
            // Sử dụng biểu thức chính quy để tìm kiếm OrderId
            string pattern = @"\b([a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12})\b";
            Match match = Regex.Match(orderInfo, pattern);

            // Trả về OrderId nếu tìm thấy, ngược lại trả về Guid.Empty
            return match.Success ? Guid.Parse(match.Value) : Guid.Empty;
        }
    }
}