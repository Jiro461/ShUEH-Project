using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ASP.NET.Services.VnPay
{
    public interface IWishListService
    {
        Task<IActionResult> GetWishList(HttpContext httpContext);
        Task<IActionResult> AddToWishList(HttpContext httpContext, Guid shoeId);
        Task<IActionResult> RemoveFromWishList(HttpContext httpContext, Guid shoeId);
    }
}