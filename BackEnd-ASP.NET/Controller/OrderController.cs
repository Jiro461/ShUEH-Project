using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services;
using System.Security.Claims;

namespace BackEnd_ASP.NET.Controller.Order
{
    // Controller xử lý các yêu cầu liên quan đến đơn hàng
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        // Dịch vụ xử lý các logic liên quan đến đơn hàng
        private readonly IOrderService orderService;

        // Constructor để khởi tạo dịch vụ
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // API lấy đơn hàng của người dùng hiện tại
        [HttpGet("user")]
        public async Task<IActionResult> GetOrdersByUserIdAsync()
        {
            // Lấy userId từ claims của người dùng hiện tại
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Kiểm tra nếu không tìm thấy userId thì trả về Unauthorized
            if (userId == null)
            {
                return Unauthorized();
            }

            // Gọi phương thức trong service để lấy đơn hàng của người dùng hiện tại
            return await orderService.GetOrdersByUserIdAsync(Guid.Parse(userId));
        }

        // API xóa một đơn hàng theo id
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrderAsync(Guid id)
        {
            // Gọi phương thức trong service để xóa đơn hàng
            return await orderService.DeleteOrderAsync(id);
        }

        // API lấy tất cả đơn hàng với phân trang
        [HttpGet("all/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllOrdersAsync(int page, int pageSize)
        {
            // Kiểm tra nếu page hoặc pageSize không hợp lệ thì trả về BadRequest
            if (page < 0 || pageSize < 0)
            {
                return BadRequest("Invalid page or page size");
            }

            // Gọi phương thức trong service để lấy tất cả đơn hàng với phân trang
            return await orderService.GetAllOrdersAsync(page, pageSize);
        }

        // API lấy tất cả đơn hàng (không phân trang)
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            // Gọi phương thức trong service để lấy tất cả đơn hàng mà không phân trang
            return await orderService.GetAllOrdersAsync(-1, -1);
        }

        // API lấy đơn hàng theo trạng thái
        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetOrdersByStatusAsync(OrderStatus status)
        {
            // Gọi phương thức trong service để lấy đơn hàng theo trạng thái
            return await orderService.GetOrdersByStatusAsync(status);
        }

        // API lấy đơn hàng theo id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(Guid id)
        {
            // Gọi phương thức trong service để lấy đơn hàng theo id
            return await orderService.GetOrderByIdAsync(id);
        }

        // API cập nhật trạng thái đơn hàng
        [HttpPut("update/{id}/{status}")]
        public async Task<IActionResult> UpdateOrderAsync(Guid id, OrderStatus status)
        {
            // Gọi phương thức trong service để cập nhật trạng thái đơn hàng
            return await orderService.UpdateOrderAsync(id, status);
        }
    }
}
