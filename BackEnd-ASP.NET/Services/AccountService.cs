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
        // private readonly IHttpContextAccessor httpContextAccessor;
        public AccountService(IUserRepository userRepository, UserManager<User> userManager,
        ShUEHContext context, SignInManager<User> signInManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.context = context;
            this.signInManager = signInManager;
        }
        private async Task SignInWithCookies(User user, HttpContext httpContext, bool rememberMe)
        {
            // Tạo danh sách Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email ?? "NoEmail"),
                new Claim(ClaimTypes.Role, user.RoleId?.ToString() ?? "None"),
                new Claim(ClaimTypes.Gender, user.Gender.ToString() ?? "Both"),
                new Claim("IPAddress", httpContext.Connection.RemoteIpAddress?.ToString() ?? "Undefined")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Thiết lập thuộc tính Cookie
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = rememberMe 
                    ? DateTimeOffset.UtcNow.AddDays(7)
                    : DateTimeOffset.UtcNow.AddHours(1)
            };

            // Đăng nhập và cấp cookie cho người dùng
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);
        }
        public async Task<IActionResult> Login(UserLoginDto userLoginDto, HttpContext httpContext)
        {
            if (string.IsNullOrEmpty(userLoginDto.UserName) || string.IsNullOrEmpty(userLoginDto.Password)) return BadRequest("Username and Password are required.");
            var user = await userManager.FindByNameAsync(userLoginDto.UserName);
            if (user == null) return BadRequest(new { message = "Invalid username or userLoginDto.Password" });
            var result = await signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, true);
            if (!result.Succeeded) return BadRequest($"Invalid Username or Password");
            await SignInWithCookies(user, httpContext, userLoginDto.rememberMe);
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
                User = user
            };
            //Thêm wishlist cho người dùng vào cơ sở dữ liệu
            await userRepository.AddWishlistAsync(wishList);
            user.Wishlist = wishList;
            //Cập nhật wishlistId cho người dùng
            await userRepository.UpdateAsync(user);
            return Ok("Created Successfully.");
        }


        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
        public async Task<IActionResult> GoogleAuthen(HttpContext httpContext)
        {
            var result = await httpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded || result.Principal == null)
            {
                return BadRequest("Không xác thực thành công.");
            }
            bool rememberMe = false;
            if (result.Properties.Items.TryGetValue("rememberMe", out var rememberMeValue))
            {
                rememberMe = bool.Parse(rememberMeValue ?? "false");
            }
            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var firstName = result.Principal.FindFirstValue(ClaimTypes.GivenName);
            var lastName = result.Principal.FindFirstValue(ClaimTypes.Surname);
            var googleId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (email == null)
            {
                return BadRequest("Không lấy được email từ Google.");
            }
            // Kiểm tra xem người dùng đã tồn tại chưa (theo Email hoặc GoogleId)

            var existingUser = await userManager.FindByEmailAsync(email);
            if (existingUser == null)
            {
                // Tạo mới người dùng nếu chưa tồn tại
                existingUser = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = email,
                    Email = email,
                    FirstName = firstName ?? "Unknown", // Phòng trường hợp Google không cung cấp
                    LastName = lastName ?? "Unknown",
                    DateOfBirth = DateTime.MinValue, // Tạm thời để MinValue vì Google không cung cấp
                    Gender = true, // Có thể để mặc định hoặc bỏ qua nếu không có thông tin
                    EmailConfirmed = true, // Vì đã xác thực qua Google
                    TotalMoney = 0 // Khởi tạo với 0
                };

                var resultCreate = await userManager.CreateAsync(existingUser);
                if (!resultCreate.Succeeded)
                {
                    return BadRequest("Không thể tạo tài khoản.");
                }
            }
            else
            {
                // Nếu người dùng đã tồn tại, có thể cập nhật LastModifiedDate
                existingUser.LastModifiedDate = MyDateTime.VietNam.DateTime;
                await userManager.UpdateAsync(existingUser);
            }
            await SignInWithCookies(existingUser, httpContext, rememberMe);
            return Ok("Đăng Nhập thành công");
        }
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            await userRepository.DeleteAsync(id);
            return Ok("Delete Succesfully");
        }
    }
}
