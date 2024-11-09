using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using BackEnd_ASP.NET.Models.User;

namespace BackEnd_ASP.NET.Controller.Account
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        // Khởi tạo controller với service IAccountService
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        // API để admin xóa người dùng
        [HttpDelete("admin/delete/{id}")]
        public async Task<IActionResult> DeleteByAdmin(Guid id)
        {
            return await accountService.DeleteUserByAdminAsync(id);
        }

        // API để người dùng tự xóa tài khoản của mình
        [HttpDelete("user/delete")]
        public async Task<IActionResult> Delete()
        {
            return await accountService.DeleteUserByUserAsync(HttpContext);
        }

        // API để thêm người dùng mới
        [HttpPost("add")]
        public async Task<IActionResult> Add(UserAddDTO userAddDTO)
        {
            return await accountService.AddUserAsync(userAddDTO);
        }

        // API lấy thông tin người dùng qua id từ query string
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByIdFromQuery(Guid id)
        {
            if (id == Guid.Empty) return Unauthorized(); // Nếu id không hợp lệ thì trả về Unauthorized
            return await accountService.GetUserByIdAsync(id);
        }

        // API lấy thông tin người dùng qua cookie
        [HttpGet("cookieGetById")]
        public async Task<IActionResult> GetByIdFromCookie()
        {
            Guid userId = Guid.Parse(Request.Cookies["userId"] ?? HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString());
            if (userId == Guid.Empty) return Unauthorized(); // Nếu không có userId hợp lệ thì trả về Unauthorized
            return await accountService.GetUserByIdAsync(userId);
        }

        // API để người dùng đăng xuất
        [HttpPost("sign-out")]
        public async Task<IActionResult> Signout()
        {
            return await accountService.SignOutUser(HttpContext);
        }

        // API đăng ký người dùng mới
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            return await accountService.Register(userDto);
        }

        // API đăng nhập người dùng
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            return await accountService.Login(userDto, HttpContext);
        }

        // API bắt đầu quá trình đăng nhập bằng Google
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

        // API callback sau khi đăng nhập bằng Google
        [HttpGet("GoogleAuthen")]
        public async Task<IActionResult> GoogleAuthen()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            if (!authenticateResult.Succeeded)
            {
                // Nếu không thành công, bạn có thể trả về trang lỗi hoặc thông báo lỗi
                return Redirect("http://localhost:3000");
            }
            return await accountService.GoogleAuthen(HttpContext);
        }

        // API cập nhật thông tin người dùng hiện tại
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromForm] UserPutDTO userDto)
        {
            Guid userId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            if (userId == Guid.Empty) return Unauthorized(); // Kiểm tra userId có hợp lệ không
            return await accountService.UpdateUserAsync(userId, userDto);
        }

        // API cập nhật thông tin người dùng theo id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserById(Guid id, [FromForm] UserPutDTO userDto)
        {
            return await accountService.UpdateUserAsync(id, userDto);
        }

        // API để lấy thông tin tất cả người dùng (chỉ dành cho Admin)
        [HttpGet("get-users-info")]
        public async Task<IActionResult> GetUsersInfo()
        {
            return await accountService.GetUsersInfo();
        }

        // API thay đổi mật khẩu của người dùng
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
        {
            Guid userId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            if (userId == Guid.Empty) return Unauthorized(); // Kiểm tra userId có hợp lệ không
            return await accountService.ChangePassword(userId, currentPassword, newPassword);
        }
    }

    // DTO chứa dữ liệu đặt lại mật khẩu từ phía Frontend
    public class ResetPasswordRequest
    {
        public string? Email { get; set; }
        public string? NewPassword { get; set; }
    }
}
