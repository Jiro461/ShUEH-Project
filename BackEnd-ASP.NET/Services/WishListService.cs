using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BackEnd_ASP.NET.Services.VnPay;

namespace BackEnd_ASP.NET.Services
{
    // Lớp dịch vụ danh sách yêu thích, kế thừa từ ControllerBase và triển khai IWishListService
    public class WishListService : ControllerBase, IWishListService
    {
        // Khai báo các biến thành viên cho repository và dịch vụ thông báo
        private readonly IWishListRepository _wishListRepository;
        private readonly IShoeRepository _shoeRepository;
        private readonly INotificationService _notificationService;

        // Hàm khởi tạo, nhận vào các đối tượng cần thiết
        public WishListService(IWishListRepository wishListRepository, IShoeRepository shoeRepository, INotificationService notificationService)
        {
            _wishListRepository = wishListRepository;
            _shoeRepository = shoeRepository;
            _notificationService = notificationService;
        }

        // Phương thức lấy danh sách yêu thích của người dùng
        public async Task<IActionResult> GetWishList(HttpContext httpContext)
        {
            // Lấy userId từ HttpContext
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized(); // Kiểm tra người dùng đã đăng nhập

            // Lấy danh sách yêu thích từ repository
            var wishList = await _wishListRepository.GetWishList(Guid.Parse(userId));
            if (wishList == null) return NotFound(); // Trả về NotFound nếu không tìm thấy

            // Lấy danh sách ID giày từ danh sách yêu thích
            var shoeIds = wishList.Select(wishlistItem => wishlistItem.ShoeId).ToList();

            // Lấy thông tin chi tiết của từng đôi giày
            var shoes = shoeIds.Select(shoeId => _shoeRepository.GetShoeByIdAsync(shoeId ?? Guid.Empty).Result!).Select(shoe => new {
                shoe.Id,
                shoe.Name,
                shoe.Price,
                shoe.ImageUrl,
                shoe.IsSale,
                shoe.Discount,
                IsNew = shoe.CreateDate > DateTime.Now.AddDays(-14) // Kiểm tra giày mới
            }).ToList();

            // Tạo đối tượng phản hồi
            var response = new {
                WishListItems = shoes,
                Total = shoes.Count
            };
            return Ok(response); // Trả về danh sách yêu thích
        }

        // Phương thức thêm giày vào danh sách yêu thích
        public async Task<IActionResult> AddToWishList(HttpContext httpContext, Guid shoeId)
        {
            // Lấy userId từ HttpContext
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized(); // Kiểm tra người dùng đã đăng nhập

            // Tạo đối tượng WishlistItem mới
            var wishListItem = new WishlistItem {
                ShoeId = shoeId,
                UserId = Guid.Parse(userId)
            };

            // Thêm giày vào danh sách yêu thích
            if (await _wishListRepository.AddToWishList(Guid.Parse(userId), shoeId))
            {
                // Tạo thông báo cho việc thêm giày vào danh sách yêu thích
                await _notificationService.CreateNotificationForWishlist(wishListItem, Guid.Parse(userId));
                return Ok(); // Trả về thông báo thành công
            }
            return BadRequest(); // Trả về thông báo thất bại
        }

        // Phương thức xóa giày khỏi danh sách yêu thích
        public async Task<IActionResult> RemoveFromWishList(HttpContext httpContext, Guid shoeId)
        {
            // Lấy userId từ HttpContext
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized(); // Kiểm tra người dùng đã đăng nhập

            // Xóa giày khỏi danh sách yêu thích
            if (await _wishListRepository.RemoveFromWishList(Guid.Parse(userId), shoeId))
                return Ok(); // Trả về thông báo thành công
            return BadRequest(); // Trả về thông báo thất bại
        }
    }
}