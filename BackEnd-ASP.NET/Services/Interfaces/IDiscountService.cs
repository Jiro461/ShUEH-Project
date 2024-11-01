using BackEnd_ASP.NET.Models.User;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_ASP.NET.Services
{
    public interface IDiscountService
    {
        Task<IActionResult> AddDiscountAsync(DiscountDTO discountDTO);
        Task<IActionResult> DeleteDiscountAsync(Guid id);
        Task<IActionResult> GetAllDiscountsAsync();
        Task<IActionResult> GetDiscountByIdAsync(Guid id);
        Task<IActionResult> UpdateDiscountAsync(Guid discountId, DiscountDTO discountDTO);
    }
}