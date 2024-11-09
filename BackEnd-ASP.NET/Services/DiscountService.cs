using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ASP.NET.Services
{
    // Lớp dịch vụ giảm giá, kế thừa từ ControllerBase và triển khai IDiscountService
    public class DiscountService : ControllerBase, IDiscountService
    {
        // Khai báo biến thành viên cho repository giảm giá
        private readonly IDiscountRepository _discountRepository;

        // Hàm khởi tạo, nhận vào một đối tượng IDiscountRepository
        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        // Phương thức thêm mã giảm giá mới
        public async Task<IActionResult> AddDiscountAsync(DiscountDTO discountDTO)
        {
            // Tạo đối tượng Discount từ DiscountDTO
            var discount = new Discount
            {
                Code = discountDTO.Code,
                IsPublic = discountDTO.IsPublic,
                Percentage = discountDTO.Percentage,
                Type = discountDTO.Type,
                Quantity = discountDTO.Quantity,
                Amount = discountDTO.Amount,
                MaximumDiscount = discountDTO.MaximumDiscount,
                MinimumOrder = discountDTO.MinimumOrder,
                ExpiryDate = discountDTO.ExpiryDate,
            };

            // Thêm mã giảm giá vào repository
            if (await _discountRepository.AddDiscountAsync(discount)) return Ok();
            return BadRequest();
        }

        // Phương thức xóa mã giảm giá theo ID
        public async Task<IActionResult> DeleteDiscountAsync(Guid id)
        {
            // Xóa mã giảm giá từ repository
            if (await _discountRepository.DeleteDiscountAsync(id)) return Ok();
            return NotFound();
        }
        
        // Phương thức lấy tất cả mã giảm giá
        public async Task<IActionResult> GetAllDiscountsAsync()
        {
            // Lấy danh sách mã giảm giá từ repository
            var discounts = await _discountRepository.GetAllDiscountsAsync();
            if (discounts == null) return NotFound();

            // Chuyển đổi danh sách Discount thành DiscountDTO
            var discountDTOs = discounts.Select(MapDiscountToDTO); 
            return Ok(discountDTOs);
        }

        // Phương thức lấy tất cả mã giảm giá công khai từ client
        public async Task<IActionResult> GetAllDiscountsFromClientAsync()
        {
            // Lấy danh sách mã giảm giá từ repository
            var discounts = await _discountRepository.GetAllDiscountsAsync();
            if (discounts == null) return NotFound();

            // Lọc mã giảm giá công khai và còn số lượng
            discounts = discounts.Where(discount => discount.IsPublic && discount.Quantity > 0).ToList();

            // Chuyển đổi danh sách Discount thành DiscountDTO
            var discountDTOs = discounts.Select(MapDiscountToDTO);
            return Ok(discountDTOs);
        }

        // Phương thức lấy mã giảm giá theo ID
        public async Task<IActionResult> GetDiscountByIdAsync(Guid id)
        {
            // Lấy mã giảm giá từ repository theo ID
            var discount = await _discountRepository.GetDiscountByIdAsync(id);
            if (discount == null) return NotFound();

            // Chuyển đổi Discount thành DiscountDTO
            var discountDTO = MapDiscountToDTO(discount);
            return Ok(discountDTO);
        }

        // Phương thức cập nhật mã giảm giá
        public async Task<IActionResult> UpdateDiscountAsync(Guid discountId, DiscountDTO discountDTO)
        {
            // Lấy mã giảm giá từ repository theo ID
            var discount = await _discountRepository.GetDiscountByIdAsync(discountId);
            if (discount == null) return NotFound();

            // Cập nhật thông tin mã giảm giá
            discount.Code = discountDTO.Code;
            discount.Percentage = discountDTO.Percentage;
            discount.Type = discountDTO.Type;
            discount.Amount = discountDTO.Amount;
            discount.MaximumDiscount = discountDTO.MaximumDiscount;
            discount.MinimumOrder = discountDTO.MinimumOrder;
            discount.ExpiryDate = discountDTO.ExpiryDate;
            discount.Quantity = discountDTO.Quantity;

            // Cập nhật mã giảm giá trong repository
            await _discountRepository.UpdateDiscountAsync(discount);
            return Ok();
        }

        // Phương thức chuyển đổi từ Discount sang DiscountDTO
        private DiscountDTO MapDiscountToDTO(Discount discount)
        {
            return new DiscountDTO
            {
                Id = discount.Id,
                Code = discount.Code,
                Percentage = discount.Percentage,
                Type = discount.Type,
                IsPublic = discount.IsPublic,
                Quantity = discount.Quantity,
                Amount = discount.Amount,
                MaximumDiscount = discount.MaximumDiscount,
                MinimumOrder = discount.MinimumOrder,
                ExpiryDate = discount.ExpiryDate,
            };
        }
    }
}