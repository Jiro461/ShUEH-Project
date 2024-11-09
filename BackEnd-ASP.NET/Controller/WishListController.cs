using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services.VnPay;

namespace BackEnd_ASP.NET.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishListController : ControllerBase
    {
        // Inject IWishListService vào controller để xử lý các hành động liên quan đến danh sách yêu thích
        private readonly IWishListService _wishListService;

        // Constructor khởi tạo IWishListService
        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        #region WishList Operations

        // API lấy danh sách yêu thích của người dùng
        [HttpGet]
        public async Task<IActionResult> GetWishList()
        {
            // Gọi phương thức GetWishList từ service để lấy danh sách sản phẩm yêu thích của người dùng
            return await _wishListService.GetWishList(HttpContext);
        }

        // API thêm một giày vào danh sách yêu thích
        [HttpPost("{shoeId}")]
        public async Task<IActionResult> AddToWishList(Guid shoeId)
        {
            // Gọi phương thức AddToWishList từ service để thêm giày vào danh sách yêu thích
            return await _wishListService.AddToWishList(HttpContext, shoeId);
        }

        // API xóa một giày khỏi danh sách yêu thích
        [HttpDelete("{shoeId}")]
        public async Task<IActionResult> RemoveFromWishList(Guid shoeId)
        {
            // Gọi phương thức RemoveFromWishList từ service để xóa giày khỏi danh sách yêu thích
            return await _wishListService.RemoveFromWishList(HttpContext, shoeId);
        }

        #endregion
    }
}
