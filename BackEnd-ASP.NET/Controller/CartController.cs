using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services;
using System.Security.Claims;
using BackEnd_ASP.NET.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using BackEnd_ASP.NET.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BackEnd_ASP.NET.Models;

namespace BackEnd_ASP.NET.Controller.Cart
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        public const string CartSessionKey = "CartId";
        public Guid ShoppingCartId { get; set; }
        private readonly ShUEHContext context;
        public CartController(ShUEHContext context)
        {
            this.context = context;
        }
        //Id is ShoeId, Size is ShoeSize
        [HttpGet("recommend")]
        public async Task<IActionResult> RecommendProducts()
        {
            ShoppingCartId = GetCartId();
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var wishlist = userId != null ? await context.WishlistItems.Where(w => w.UserId == Guid.Parse(userId)).ToListAsync() : null;
            // Lấy các sản phẩm hiện có trong giỏ hàng
            var cartItems = await context.CartItems
                .Where(c => c.SessionId == ShoppingCartId)
                .Select(c => c.ShoeId)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return Ok("No items in cart to recommend products.");
            }

            // Lấy các sản phẩm thường mua cùng với các sản phẩm trong giỏ hàng
            var recommendedProducts = await context.OrderItems
                .Where(oi => cartItems.Contains(oi.ShoeId))
                .GroupBy(oi => oi.ShoeId)
                .Select(g => new
                {
                    ShoeId = g.Key,
                    RecommendCount = g.Count() // Đếm số lần sản phẩm này được mua
                })
                .OrderByDescending(g => g.RecommendCount) // Sắp xếp giảm dần
                .Take(10) // Giới hạn số sản phẩm gợi ý
                .ToListAsync();

            // Chuyển đổi kết quả thành dữ liệu gợi ý
            var recommendations = await context.Shoes
                .Where(s => recommendedProducts.Select(rp => rp.ShoeId).Contains(s.Id))
                .Select(s => new ShoeGetAllDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ImageUrl ?? "images/shoes/noimage.webp",
                    Price = s.Price,
                    IsLiked = wishlist != null ? wishlist.Any(w => w.ShoeId == s.Id) : false
                })
                .ToListAsync();

            return Ok(recommendations);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(Guid shoeId, int size)
        {
            ShoppingCartId = GetCartId();

            var cartItem = context.CartItems.SingleOrDefault(
                c => c.SessionId == ShoppingCartId
                && c.ShoeId == shoeId && c.Size == size);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    SessionId = ShoppingCartId,
                    ShoeId = shoeId,
                    Quantity = 1,
                    DateCreated = DateTime.Now,
                    Size = size
                };

                await context.CartItems.AddAsync(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            var cartItems = await context.CartItems.Where(
                c => c.SessionId == ShoppingCartId).Include(c => c.Shoe!).ThenInclude(s => s.Colors).ToListAsync();

            var cartItemsDto = cartItems.Select(c => new
            {
                ItemId = c.Id,
                ShoeId = c.ShoeId,
                Colors = c.Shoe!.Colors.Select(s => new ShoeColorDTO { Color = s.Color }).ToList(),
                ShoeName = c.Shoe!.Name,
                ShoeImage = c.Shoe!.ImageUrl,
                Quantity = c.Quantity,
                Size = c.Size,
            }).ToList();
            return Ok(cartItemsDto);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCartItem(Guid id)
        {
            var cartItem = await context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound("Cart item not found");
            }
            context.CartItems.Remove(cartItem);
            await context.SaveChangesAsync();
            return Ok("Cart item deleted");
        }
        private Guid GetCartId()
        {
            var session = HttpContext.Session;
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(session.GetString(CartSessionKey)))
            {
                if (!string.IsNullOrWhiteSpace(userId))
                {
                    session.SetString(CartSessionKey, userId);
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    session.SetString(CartSessionKey, tempCartId.ToString());
                }
            }

            return Guid.TryParse(session.GetString(CartSessionKey), out var cartId)
                ? cartId
                : Guid.NewGuid(); // Trả về giá trị mới nếu parse thất bại
        }

    }
}
