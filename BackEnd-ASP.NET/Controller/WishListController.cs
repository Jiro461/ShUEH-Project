using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services.VnPay;

namespace BackEnd_ASP.NET.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;
        public WishListController(IWishListService wishListService){
            _wishListService = wishListService;
        }
        [HttpGet]
        public async Task<IActionResult> GetWishList(HttpContext httpContext){
            return await _wishListService.GetWishList(httpContext);
        }
        [HttpPost("{shoeId}")]
        public async Task<IActionResult> AddToWishList(HttpContext httpContext, Guid shoeId){
            return await _wishListService.AddToWishList(httpContext, shoeId);
        }
        [HttpDelete("{shoeId}")]
        public async Task<IActionResult> RemoveFromWishList(HttpContext httpContext, Guid shoeId){
            return await _wishListService.RemoveFromWishList(httpContext, shoeId);
        }
    }
}