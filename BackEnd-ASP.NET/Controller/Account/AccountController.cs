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

namespace BackEnd_ASP.NET.Controller.Account
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly ShUEHContext shUEHContext;

        public AccountController(IAccountService accountService, ShUEHContext shUEHContext)
        {
            this.accountService = accountService;
            this.shUEHContext = shUEHContext;
        }
        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await shUEHContext.Users
                .Include(u => u.Wishlist) // Load các wishlist liên quan
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            // if (user != null)
            // {

            //     // Xóa các wishlist trước
            //     shUEHContext.Wishlists.RemoveRange(user.Wishlist);

            //     // Xóa user
            //     shUEHContext.Users.Remove(user);

            //     await shUEHContext.SaveChangesAsync();
            // }
            return Ok(user);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            return await accountService.Register(userDto);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            return await accountService.Login(userDto, HttpContext);

        }
        [HttpGet("sign-in")]
        public IActionResult SignInGoogle()
        {
            var rememberMe = Request.Query["rememberMe"] == "true";
            var redirectUrl = Url.Action("GoogleAuthen", "Account"); // Đường dẫn callback
            var properties = new AuthenticationProperties
            {
                RedirectUri = redirectUrl,
                Items = { { "rememberMe", rememberMe.ToString() } }
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme); // Chuyển hướng tới Google
        }

        [HttpGet("GoogleAuthen")]  // Sau khi nhận thông tin đăng nhập từ Google
        public async Task<IActionResult> GoogleAuthen()
        {
            return await accountService.GoogleAuthen(HttpContext);
        }

    }


}
