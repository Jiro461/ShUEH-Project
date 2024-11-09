using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services.VnPay;
using BackEnd_ASP.NET.Services;
using System.Security.Claims;
using BackEnd_ASP_NET.Models;
using BackEnd_ASP_NET.Utilities.Extensions;

namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        // Các dịch vụ được sử dụng trong controller
        private readonly IVnPayService _vnPayService; // Dịch vụ thanh toán VNPAY
        private readonly IOrderService _orderService; // Dịch vụ quản lý đơn hàng
        private readonly IPaymentService _paymentService; // Dịch vụ quản lý thanh toán

        // Constructor để khởi tạo các dịch vụ
        public PaymentController(IVnPayService vnPayService, IOrderService orderService, IPaymentService paymentService)
        {
            _vnPayService = vnPayService;
            _orderService = orderService;
            _paymentService = paymentService;
        }

        // API xử lý thanh toán khi người dùng chọn phương thức thanh toán
        [HttpPost]
        public async Task<IActionResult> Payment([FromBody] OrderPostDTO order)
        {
            // Lấy user id từ claims trong token của người dùng
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Nếu không có userId (người dùng chưa đăng nhập), trả về Unauthorized
            if (userId == null) return Unauthorized();

            // Thêm đơn hàng vào hệ thống và lấy kết quả
            var addingOrder = await _orderService.AddOrderAsync(order, Guid.Parse(userId));

            // Nếu phương thức thanh toán là tiền mặt
            if (order.PaymentMethod == PaymentMethod.Cash)
            {
                // Kiểm tra nếu đơn hàng không thể thêm vào hệ thống
                if (addingOrder.Item1 == Guid.Empty) return BadRequest(addingOrder.Item2);
                
                // Nếu thành công, trả về thông báo tạo đơn hàng thành công
                return Ok(new { status = "Success", Message = "Create order successfully" });
            }

            // Kiểm tra nếu không thể thêm đơn hàng vào hệ thống
            if (addingOrder.Item1 == Guid.Empty) return BadRequest(addingOrder.Item2);

            // Tạo request thanh toán VNPAY
            if (addingOrder.Item1 != Guid.Empty)
            {
                Guid orderId = addingOrder.Item1;
                var vnPaymentRequestModel = new VnPaymentRequestModel
                {
                    FullName = userId.ToString(),
                    Description = $"Thanh toán đơn hàng {orderId} với tổng giá {order.TotalPrice} với phương thức {order.PaymentMethod}",
                    Amount = decimal.ToDouble(order.TotalPrice),
                    CreateDate = order.OrderDate,
                    OrderId = orderId
                };

                // Tạo URL thanh toán VNPAY
                return Ok(new { status = "Redirect", PaymentUrl = _vnPayService.CreatePaymentUrl(HttpContext, vnPaymentRequestModel) });
            }
            
            // Nếu không thể thêm đơn hàng, trả về BadRequest
            return BadRequest("Can't add order");
        }

        // API xử lý callback từ VNPAY sau khi thanh toán hoàn tất
        [HttpGet("payment-callback")]
        public async Task<IActionResult> PaymentCallback()
        {
            // Xử lý phản hồi từ VNPAY
            var vnPayResponse = _vnPayService.PaymentExecute(HttpContext.Request.Query);
            Guid orderId;

            // Kiểm tra nếu orderId không hợp lệ
            if (!Guid.TryParse(vnPayResponse.OrderId, out orderId)) return BadRequest("Invalid order ID");

            // Nếu phản hồi không thành công từ VNPAY, gọi dịch vụ để xử lý thanh toán thất bại
            if (vnPayResponse == null || vnPayResponse.VnPayResponseCode != "00" || !vnPayResponse.Success)
            {
                var result = await _paymentService.HandleFailedPaymentAsync(orderId);
                if (result is not OkObjectResult) return BadRequest("Thanh toán VNPAY không thành công.");
                return BadRequest(result);
            }

            // Nếu thanh toán thành công, gọi dịch vụ để xử lý thanh toán thành công
            var paymentResult = await _paymentService.HandleSuccessfulPaymentAsync(orderId);
            if (paymentResult is not OkObjectResult) return BadRequest("Xử lý đơn hàng không thành công.");

            // Chuyển hướng người dùng về trang chủ sau khi thanh toán thành công
            return Redirect($"{MyURL.Host}");
        }
    }
}
