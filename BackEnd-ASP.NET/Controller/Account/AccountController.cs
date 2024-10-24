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

namespace BackEnd_ASP.NET.Controller.Account
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService, ShUEHContext shUEHContext, UserManager<User> userManager)
        {
            this.accountService = accountService;
        }

        [HttpGet("user/delete")]
        public async Task<IActionResult> Delete()
        {
            return await accountService.DeleteUserAsync(HttpContext);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByIdFromQuery(Guid id)
        {
            if (id == Guid.Empty) return Unauthorized();
            return await accountService.GetByIdAsync(id);
        }
        [HttpGet("cookieGetById")]
        public async Task<IActionResult> GetByIdFromCookie()
        {
            Guid userId = Guid.Parse(Request.Cookies["userId"] ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            if (userId == Guid.Empty) return Unauthorized();
            return await accountService.GetByIdAsync(userId);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromForm] UserPutDTO userDto)
        {
            return await accountService.UpdateUserAsync(id, userDto);
        }

        [HttpGet("get-users-info")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsersInfo()
        {
            return await accountService.GetUsersInfo();
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return await accountService.ResetPassword(request.Email, request.NewPassword);
        }
    }

    // DTO chứa dữ liệu đặt lại mật khẩu từ phía Frontend
    public class ResetPasswordRequest
    {
        public string? Email { get; set; }
        public string? NewPassword { get; set; }
    }
}
