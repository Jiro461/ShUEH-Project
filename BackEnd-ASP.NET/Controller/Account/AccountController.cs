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
    [EnableCors("CorsPolicy")]
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
            return await accountService.DeleteUserAsync(HttpContext);
        }

        [HttpPost("sign-out")]
        public async Task<IActionResult> Signout()
        {
            return await accountService.SignOutUser(HttpContext);
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
