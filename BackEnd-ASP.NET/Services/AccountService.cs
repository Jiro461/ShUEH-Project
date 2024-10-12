using BackEnd_ASP_NET.Utilities.Extensions;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BackEnd_ASP.NET.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace BackEnd_ASP.NET.Services
{
    public class AccountService : ControllerBase, IAccountService
    {

        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;
        private readonly ShUEHContext context;
        private readonly SignInManager<User> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountService(IUserRepository userRepository, UserManager<User> userManager, ShUEHContext context, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.context = context;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Login(UserLoginDto userLoginDto, HttpContext httpContext)
        {
            if (string.IsNullOrEmpty(userLoginDto.UserName) || string.IsNullOrEmpty(userLoginDto.Password)) return BadRequest("Username and Password are required.");
            var user = await userManager.FindByNameAsync(userLoginDto.UserName);
            if (user == null) return BadRequest(new { message = "Invalid username or userLoginDto.Password" });
            var result = await signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, true);
            if (!result.Succeeded) return BadRequest($"Invalid Username or Password");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, userLoginDto.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim("IPAddress", httpContext.Connection.RemoteIpAddress.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = userLoginDto.rememberMe, // Cookie sẽ tồn tại sau khi đóng trình duyệt nếu chọn "Remember Me"
                ExpiresUtc = userLoginDto.rememberMe ? DateTimeOffset.UtcNow.AddDays(7) : DateTimeOffset.UtcNow.AddHours(1) // Hết hạn sau 7 ngày (có chọn userLoginDto.rememberMe) hoặc 1 giờ
            };
            if (httpContext == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to access HttpContext.");
            }

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

            return Ok("Login successfully");
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Email)) return BadRequest("Username and Email are required.");
            if (userDto.UserName.Length < 7) return BadRequest("Username must have longer than 7 word");
            // Tìm xem có tồn tại tài khoản trùng hay không
            var existingUser = await userManager.FindByNameAsync(userDto.UserName);
            if (existingUser != null) return BadRequest("User with this Name already exists");
            var existingEmail = await userManager.FindByEmailAsync(userDto.Email);
            if (existingEmail != null) return BadRequest("User with this Email already exists");
            // Lấy ra Role User
            var guestRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == RoleName.User);
            if (guestRole == null) return BadRequest($"Role {RoleName.User} not found.");

            // Tạo người dùng
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                DateOfBirth = userDto.DateOfBirth.ToDateTime(),     
                Email = userDto.Email,
                NormalizedEmail = userDto.Email.ToUpper(),
                Gender = userDto.Gender,
                TotalMoney = 0,
                Role = guestRole,
                UserName = userDto.UserName,
                NormalizedUserName = userDto.UserName.ToUpper(),
                EmailConfirmed = false,
            };

            //Thêm người dùng vào cơ sở dữ liệu trước
            var result = await userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded) return BadRequest($"{string.Join(";", result.Errors.Select(e => e.Description))}");
            var wishList = new Wishlist
            {
                UserId = user.Id
            };

            //Thêm wishlist cho người dùng vào cơ sở dữ liệu
            await userRepository.AddWishlistAsync(wishList);

            user.WistlistId = wishList.Id;

            //Cập nhật wishlistId cho người dùng
            await userRepository.UpdateAsync(user);
            return Ok("Created Successfully.");
        }


        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
