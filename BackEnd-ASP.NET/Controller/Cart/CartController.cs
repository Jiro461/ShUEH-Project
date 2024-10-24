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

namespace BackEnd_ASP.NET.Controller.Cart
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
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
        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(Guid id, int size)
        {
            ShoppingCartId = GetCartId();

            var cartItem = context.CartItems.SingleOrDefault(
                c => c.SessionId == ShoppingCartId
                && c.ShoeId == id && c.Size == size);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    SessionId = ShoppingCartId,
                    ShoeId = id,
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
                Colors = c.Shoe!.Colors.Select(s => new { s.Color }).ToList(),
                ShoeName = c.Shoe!.Name,
                ShoeImage = c.Shoe!.ImageUrl,
                Quantity = c.Quantity,
                Size = c.Size,
                Shoe = c.Shoe
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

            return Guid.Parse(session.GetString(CartSessionKey) ?? string.Empty);
        }

    }
}
