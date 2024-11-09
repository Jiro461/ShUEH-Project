using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP_NET.Models;

namespace PaymentAPI.Controllers
{
    // Controller xử lý các yêu cầu liên quan đến mã giảm giá
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        // Dịch vụ giảm giá được tiêm vào thông qua constructor
        private readonly IDiscountService _discountService;

        // Constructor để khởi tạo dịch vụ giảm giá
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        // API để lấy tất cả các mã giảm giá từ phía client (dành cho khách hàng)
        [HttpGet("all")]
        public async Task<IActionResult> GetAllDiscounts()
        {
            // Gọi phương thức dịch vụ để lấy tất cả mã giảm giá dành cho khách hàng
            return await _discountService.GetAllDiscountsFromClientAsync();
        }

        // API để lấy tất cả các mã giảm giá từ phía admin (dành cho quản trị viên)
        [HttpGet("all-admin")]
        public async Task<IActionResult> GetAllDiscountsFromAdmin()
        {
            // Gọi phương thức dịch vụ để lấy tất cả mã giảm giá dành cho quản trị viên
            return await _discountService.GetAllDiscountsAsync();
        }

        // API để thêm mã giảm giá mới
        [HttpPost("add")]
        public async Task<IActionResult> AddDiscount(DiscountDTO discountDTO)
        {
            // Gọi phương thức dịch vụ để thêm một mã giảm giá mới
            return await _discountService.AddDiscountAsync(discountDTO);
        }

        // API để xóa một mã giảm giá theo ID
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDiscount(Guid id)
        {
            // Gọi phương thức dịch vụ để xóa một mã giảm giá theo ID
            return await _discountService.DeleteDiscountAsync(id);
        }

        // API để cập nhật một mã giảm giá theo ID
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateDiscount(Guid id, DiscountDTO discountDTO)
        {
            // Gọi phương thức dịch vụ để cập nhật mã giảm giá theo ID
            return await _discountService.UpdateDiscountAsync(id, discountDTO);
        }
        
        // API để lấy thông tin mã giảm giá theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountById(Guid id)
        {
            // Gọi phương thức dịch vụ để lấy thông tin của mã giảm giá theo ID
            return await _discountService.GetDiscountByIdAsync(id);
        }
    }
}
