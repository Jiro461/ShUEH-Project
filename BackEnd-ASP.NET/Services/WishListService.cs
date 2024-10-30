using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Utilities.FileHelpers;
using BackEnd_ASP.NET.Models.ShoeDetail;
using BackEnd_ASP_NET.Utilities.Extensions;
using System.Security.Claims;
using BackEnd_ASP.NET.Services.VnPay;

namespace BackEnd_ASP.NET.Services
{
    public class WishListService : ControllerBase, IWishListService
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly IShoeRepository _shoeRepository;
        private readonly INotificationService _notificationService;
        public WishListService(IWishListRepository wishListRepository, IShoeRepository shoeRepository, INotificationService notificationService)
        {
            _wishListRepository = wishListRepository;
            _shoeRepository = shoeRepository;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> GetWishList(HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            var wishList = await _wishListRepository.GetWishList(Guid.Parse(userId));
            if (wishList == null) return NotFound();
            var shoeIds = wishList.Select(wishlistItem => wishlistItem.ShoeId).ToList();
            var shoes = shoeIds.Select(shoeId => _shoeRepository.GetShoeByIdAsync(shoeId ?? Guid.Empty).Result!).Select(shoe => new {
                shoe.Id  ,
                shoe.Name,
                shoe.Price,
                shoe.ImageUrl,
                shoe.IsSale,
                shoe.Discount,
                IsNew = shoe.CreateDate > DateTime.Now.AddDays(-14)
            }).ToList();
            var response = new {
                WishListItems = shoes,
                Total = shoes.Count
            };
            return Ok(response);
        }
        public async Task<IActionResult> AddToWishList(HttpContext httpContext, Guid shoeId)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            var wishListItem = new WishlistItem {
                ShoeId = shoeId,
                UserId = Guid.Parse(userId)
            };
            if (await _wishListRepository.AddToWishList(Guid.Parse(userId), shoeId))
            {
                await _notificationService.CreateNotificationForWishlist(wishListItem, Guid.Parse(userId));
                return Ok();
            }
            return BadRequest();
        }
        public async Task<IActionResult> RemoveFromWishList(HttpContext httpContext, Guid shoeId)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            if (await _wishListRepository.RemoveFromWishList(Guid.Parse(userId), shoeId))
                return Ok();
            return BadRequest();
        }

    }

}
