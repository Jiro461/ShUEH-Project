using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BackEnd_ASP.NET.Services.VnPay;
using Microsoft.AspNetCore.Cors;
using BackEnd_ASP.NET.Services;
using System.Security.Claims;
using BackEnd_ASP_NET.Models;
using System.Net;
namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        public PaymentController(IVnPayService vnPayService, IOrderService orderService, IPaymentService paymentService)
        {
            _vnPayService = vnPayService;
            _orderService = orderService;
            _paymentService = paymentService;
        }
        [HttpPost]
        public async Task<IActionResult> Payment([FromBody] OrderPostDTO order)
        {
            //Lấy user id từ token
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //Nếu không có user thì không thể thanh toán
            if (userId == null) return Unauthorized();
            var addingOrder = await _orderService.AddOrderAsync(order, Guid.Parse(userId));
            if (order.PaymentMethod == PaymentMethod.Cash)
            {
                if (addingOrder.Item1 == Guid.Empty) return BadRequest(addingOrder.Item2);
                return Ok(new { status = "Success", Message = "Create order successfully" });
            }
            if (addingOrder.Item1 == Guid.Empty) return BadRequest(addingOrder.Item2);
            //Tạo request thanh toán VNPAY
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
                //Tạo url thanh toán VNPAY
                return Ok(new { status = "Redirect", PaymentUrl = _vnPayService.CreatePaymentUrl(HttpContext, vnPaymentRequestModel) });
            }
            return BadRequest("Can't add order");
        }

        [HttpGet("payment-callback")]
        public async Task<IActionResult> PaymentCallback()
        {
            var vnPayResponse = _vnPayService.PaymentExecute(HttpContext.Request.Query);
            Guid orderId;
            if (!Guid.TryParse(vnPayResponse.OrderId, out orderId)) return BadRequest("Invalid order ID");
            if (vnPayResponse == null
                || vnPayResponse.VnPayResponseCode != "00"
                || !vnPayResponse.Success)
            {
                var result = await _paymentService.HandleFailedPaymentAsync(orderId);
                if (result is not OkObjectResult) return BadRequest("Thanh toán VNPAY không thành công.");
                return BadRequest(result);
            }

            var paymentResult = await _paymentService.HandleSuccessfulPaymentAsync(orderId);
            if (paymentResult is not OkObjectResult) return BadRequest("Xử lý đơn hàng không thành công.");

            // Chuyển hướng về React khi thanh toán thành công
            return Redirect("http://localhost:3000/");
        }

    }
}

