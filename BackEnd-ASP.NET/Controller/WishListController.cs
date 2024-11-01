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
        public async Task<IActionResult> GetWishList(){
            return await _wishListService.GetWishList(HttpContext);
        }
        [HttpPost("{shoeId}")]
        public async Task<IActionResult> AddToWishList(Guid shoeId){
            return await _wishListService.AddToWishList(HttpContext, shoeId);
        }
        [HttpDelete("{shoeId}")]
        public async Task<IActionResult> RemoveFromWishList(Guid shoeId){
            return await _wishListService.RemoveFromWishList(HttpContext, shoeId);
        }
    }
}