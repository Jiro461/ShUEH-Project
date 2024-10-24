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
namespace MomoPaymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class PaymentController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;
        private readonly IOrderService _orderService;
        public PaymentController(IVnPayService vnPayService, IOrderService orderService)
        {
            _vnPayService = vnPayService;
            _orderService = orderService;
        }
        [HttpPost("payment")]
        public async Task<IActionResult> PaymentVnPay([FromBody] OrderDTO order)
        {
            //Lấy user id từ token
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //Nếu không có user thì không thể thanh toán
            if (userId == null) return Unauthorized();
            //Nếu thanh toán bằng tiền mặt thì không cần tạo thanh toán VNPAY
            if (order.PaymentMethod == PaymentMethod.Cash)
            {
                var addingOrder = await _orderService.AddOrderAsync(order, Guid.Parse(userId));
                if (addingOrder is not OkObjectResult) return BadRequest("Can't add order with Cash");
                return Ok(new { status = "Success", Message = "Create order successfully" });
            }
            //Tạo thanh toán VNPAY
            var vnPaymentRequestModel = new VnPaymentRequestModel
            {
                FullName = userId.ToString(),
                Description = $"Thanh toán đơn hàng {order.Id} với tổng giá {order.TotalPrice}",
                Amount = decimal.ToDouble(order.TotalPrice),
                CreateDate = order.OrderDate,
                OrderId = order.Id
            };
            //Tạo url thanh toán VNPAY
            return Ok(new { status = "Success", PaymentUrl = _vnPayService.CreatePaymentUrl(HttpContext, vnPaymentRequestModel) });
        }

        [HttpGet("payment-callback")]
        public IActionResult PaymentCallback()
        {
            var vnPayResponse = _vnPayService.PaymentExecute(HttpContext.Request.Query);

            if (vnPayResponse == null || vnPayResponse.VnPayResponseCode != "00")
            {
                Console.WriteLine("Payment failed or invalid response");
                return BadRequest("Thanh toán không thành công.");
            }

            // Chuyển hướng về trang React sau khi thanh toán thành công
            return Redirect("http://localhost:3000/");
        }

    }
}

