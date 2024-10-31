

using System.Text.RegularExpressions;

namespace BackEnd_ASP.NET.Services.VnPay
{
    public class VnPayService : IVnPayService
    {
        private readonly IConfiguration _config;
        public VnPayService(IConfiguration configuration)
        {
            this._config = configuration;
        }

        public string CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model)
        {
            var tick = DateTime.Now.Ticks.ToString();
            var vnpay = new VnPayLibrary();
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
            vnpay.AddRequestData("vnp_ReturnUrl", _config["VnPay:PaymentBackReturnUrl"] ?? "https://localhost:5118/payment/payment-callback");
            vnpay.AddRequestData("vnp_TxnRef", tick);
            var paymentUrl = vnpay.CreateRequestUrl(_config["VnPay:BaseUrl"] ?? "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html", _config["VnPay:HashSecret"] ?? "12345678");
            return paymentUrl;
        }

        public VnPaymentResponseModel PaymentExecute(IQueryCollection collections)
        {
            var vnpay = new VnPayLibrary();
            foreach (var (key, value) in collections)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(key, value.ToString());
                }
            }
            var vnp_orderId = ExtractOrderId(vnpay.GetResponseData("vnp_OrderInfo"));
            var vnp_TransactionId = vnpay.GetResponseData("vnp_TransactionId");
            var vnp_SecureHash = collections.FirstOrDefault(x => x.Key == "vnp_SecureHash").Value;
            var vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            var vnp_OrderInfo = vnpay.GetResponseData("vnp_OrderInfo");
            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash!, _config["VnPay:HashSecret"] ?? string.Empty);
            if (!checkSignature || vnp_orderId == Guid.Empty)
            {
                return new VnPaymentResponseModel
                {
                    Success = false,
                };
            }
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
        private Guid ExtractOrderId(string orderInfo)
        {
            string pattern = @"\b([a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12})\b";
            Match match = Regex.Match(orderInfo, pattern);

            return match.Success ? Guid.Parse(match.Value) : Guid.Empty;
        }
    }
}
