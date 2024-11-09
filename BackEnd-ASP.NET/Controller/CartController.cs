using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BackEnd_ASP.NET.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using BackEnd_ASP.NET.Models;

namespace BackEnd_ASP.NET.Controller.Cart
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        public const string CartSessionKey = "CartId"; // Khóa lưu trữ ID giỏ hàng trong session
        public Guid ShoppingCartId { get; set; }
        private readonly ShUEHContext context;

        // Khởi tạo CartController với context
        public CartController(ShUEHContext context)
        {
            this.context = context;
        }

        // API giảm số lượng sản phẩm trong giỏ hàng
        [HttpPost("decrease")]
        public async Task<IActionResult> DecreaseQuantity(Guid id)
        {
            ShoppingCartId = GetCartId(); // Lấy ID giỏ hàng từ session
            var cartItem = await context.CartItems.FindAsync(ShoppingCartId); // Tìm sản phẩm trong giỏ
            if(cartItem == null) return NotFound("Cart item not found"); // Nếu không tìm thấy sản phẩm
            cartItem.Quantity--; // Giảm số lượng sản phẩm
            context.CartItems.Update(cartItem); // Cập nhật sản phẩm trong giỏ
            await context.SaveChangesAsync(); // Lưu thay đổi
            return Ok("Decrease completed"); // Trả về kết quả thành công
        }

        // API gợi ý sản phẩm dựa trên sản phẩm trong giỏ hàng
        [HttpGet("recommend")]
        public async Task<IActionResult> RecommendProducts()
        {
            ShoppingCartId = GetCartId(); // Lấy ID giỏ hàng từ session
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Lấy userId từ cookie hoặc token
            var wishlist = userId != null ? await context.WishlistItems.Where(w => w.UserId == Guid.Parse(userId)).ToListAsync() : null; // Lấy danh sách yêu thích của người dùng

            // Lấy các sản phẩm trong giỏ hàng
            var cartItems = await context.CartItems
                .Where(c => c.SessionId == ShoppingCartId)
                .Select(c => c.ShoeId)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return Ok("No items in cart to recommend products."); // Nếu giỏ hàng không có sản phẩm
            }

            // Lấy các sản phẩm thường được mua cùng với sản phẩm trong giỏ
            var recommendedProducts = await context.OrderItems
                .Where(oi => cartItems.Contains(oi.ShoeId))
                .GroupBy(oi => oi.ShoeId)
                .Select(g => new
                {
                    ShoeId = g.Key,
                    RecommendCount = g.Count() // Đếm số lần sản phẩm này được mua
                })
                .OrderByDescending(g => g.RecommendCount) // Sắp xếp theo số lần mua
                .Take(10) // Giới hạn kết quả
                .ToListAsync();

            // Chuyển kết quả gợi ý thành dữ liệu sản phẩm
            var recommendations = await context.Shoes
                .Where(s => recommendedProducts.Select(rp => rp.ShoeId).Contains(s.Id))
                .Select(s => new ShoeGetAllDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ImageUrl ?? "images/shoes/noimage.webp", // Đặt ảnh mặc định nếu không có
                    Price = s.Price,
                    IsLiked = wishlist != null ? wishlist.Any(w => w.ShoeId == s.Id) : false // Kiểm tra xem sản phẩm có trong danh sách yêu thích không
                })
                .ToListAsync();

            return Ok(recommendations); // Trả về danh sách sản phẩm gợi ý
        }

        // API thêm sản phẩm vào giỏ hàng
        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(Guid shoeId, int size)
        {
            ShoppingCartId = GetCartId(); // Lấy ID giỏ hàng từ session

            var cartItem = context.CartItems.FirstOrDefault(
                c => c.SessionId == ShoppingCartId
                && c.ShoeId == shoeId && c.Size == size); // Kiểm tra sản phẩm đã có trong giỏ chưa
            if (cartItem == null)
            {
                // Nếu chưa có, tạo mới một cart item
                cartItem = new CartItem
                {
                    SessionId = ShoppingCartId,
                    ShoeId = shoeId,
                    Quantity = 1, // Mỗi sản phẩm mới có số lượng là 1
                    DateCreated = DateTime.Now,
                    Size = size
                };

                await context.CartItems.AddAsync(cartItem); // Thêm sản phẩm vào giỏ
            }
            else
            {
                cartItem.Quantity++; // Nếu đã có, tăng số lượng sản phẩm
                context.CartItems.Update(cartItem);
            }
            await context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            return Ok(); // Trả về kết quả thành công
        }

        // API lấy thông tin sản phẩm trong giỏ hàng
        [HttpGet("get")]
        public async Task<IActionResult> GetCartItems()
        {
            ShoppingCartId = GetCartId(); // Lấy ID giỏ hàng từ session

            var cartItems = await context.CartItems.Where(
                c => c.SessionId == ShoppingCartId).Include(c => c.Shoe!).ThenInclude(s => s.Colors).ToListAsync(); // Lấy tất cả sản phẩm trong giỏ, bao gồm cả thông tin về màu sắc

            var cartItemsDto = cartItems.Select(c => new
            {
                ItemId = c.Id,
                ShoeId = c.ShoeId,
                Colors = c.Shoe!.Colors.Select(s => new ShoeColorDTO { Color = s.Color }).ToList(),
                ShoeName = c.Shoe!.Name,
                ShoeImage = c.Shoe!.ImageUrl,
                Price = c.Shoe!.Price,
                Quantity = c.Quantity,
                Size = c.Size,
            }).ToList();

            return Ok(cartItemsDto); // Trả về thông tin giỏ hàng
        }

        // API xóa sản phẩm khỏi giỏ hàng
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCartItem(Guid id)
        {
            var cartItem = await context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound("Cart item not found"); // Nếu không tìm thấy sản phẩm trong giỏ
            }
            context.CartItems.Remove(cartItem); // Xóa sản phẩm khỏi giỏ
            await context.SaveChangesAsync(); // Lưu thay đổi
            return Ok("Cart item deleted"); // Trả về kết quả thành công
        }

        // Phương thức lấy ID giỏ hàng từ session hoặc tạo mới nếu không tồn tại
        private Guid GetCartId()
        {
            var session = HttpContext.Session;
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(session.GetString(CartSessionKey)))
            {
                if (!string.IsNullOrWhiteSpace(userId))
                {
                    session.SetString(CartSessionKey, userId); // Nếu có userId, lưu vào session
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid(); // Nếu không có userId, tạo ID giỏ hàng mới
                    session.SetString(CartSessionKey, tempCartId.ToString());
                }
            }

            return Guid.TryParse(session.GetString(CartSessionKey), out var cartId)
                ? cartId
                : Guid.NewGuid(); // Trả về ID giỏ hàng nếu parse thành công, nếu không tạo ID mới
        }
    }
}