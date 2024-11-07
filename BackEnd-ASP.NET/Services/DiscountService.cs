using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_ASP.NET.Services
{
    public class DiscountService : ControllerBase, IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<IActionResult> AddDiscountAsync(DiscountDTO discountDTO)
        {
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
            if (await _discountRepository.AddDiscountAsync(discount)) return Ok();
            return BadRequest();
        }

        public async Task<IActionResult> DeleteDiscountAsync(Guid id)
        {
            if (await _discountRepository.DeleteDiscountAsync(id)) return Ok();
            return NotFound();
        }

        public async Task<IActionResult> GetAllDiscountsAsync()
        {
            var discounts = await _discountRepository.GetAllDiscountsAsync();
            if (discounts == null) return NotFound();
            discounts = discounts.Where(discount => discount.IsPublic && discount.Quantity > 0).ToList();
            //Trả về danh sách mã giảm giá
            var discountDTOs = discounts.Select(MapDiscountToDTO);
            return Ok(discountDTOs);
        }

        public async Task<IActionResult> GetDiscountByIdAsync(Guid id)
        {
            var discount = await _discountRepository.GetDiscountByIdAsync(id);
            if (discount == null) return NotFound();
            //Trả về mã giảm giá
            var discountDTO = MapDiscountToDTO(discount);
            return Ok(discountDTO);
        }

        public async Task<IActionResult> UpdateDiscountAsync(Guid discountId, DiscountDTO discountDTO)
        {
            var discount = await _discountRepository.GetDiscountByIdAsync(discountId);
            if (discount == null) return NotFound();
            //Cập nhật thông tin mã giảm giá
            discount.Code = discountDTO.Code;
            discount.Percentage = discountDTO.Percentage;
            discount.Type = discountDTO.Type;
            discount.Amount = discountDTO.Amount;
            discount.MaximumDiscount = discountDTO.MaximumDiscount;
            discount.MinimumOrder = discountDTO.MinimumOrder;
            discount.ExpiryDate = discountDTO.ExpiryDate;
            discount.Quantity = discountDTO.Quantity;
            await _discountRepository.UpdateDiscountAsync(discount);
            return Ok();
        }

        private DiscountDTO MapDiscountToDTO(Discount discount)
        {
            return new DiscountDTO
            {
                Id = discount.Id,
                Code = discount.Code,
                Percentage = discount.Percentage,
                Type = discount.Type,
                Quantity = discount.Quantity,
                Amount = discount.Amount,
                MaximumDiscount = discount.MaximumDiscount,
                MinimumOrder = discount.MinimumOrder,
                ExpiryDate = discount.ExpiryDate,
            };
        }
    }
}