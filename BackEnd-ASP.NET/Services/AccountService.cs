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
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email ?? "NoEmail"),
                new Claim(ClaimTypes.Role, user.RoleId?.ToString() ?? "None"),
                new Claim(ClaimTypes.Gender, user.Gender.ToString() ?? "Both"),
                new Claim("Provider", user.ProviderName ?? "Local"),  // Thêm Provider vào Claim
                new Claim("IsExternal", user.IsExternalLogin.ToString()),
                new Claim("IPAddress", httpContext.Connection.RemoteIpAddress?.ToString() ?? "Undefined")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = rememberMe
                    ? DateTimeOffset.UtcNow.AddDays(7)
                    : DateTimeOffset.UtcNow.AddHours(1)
            };

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
            if (string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Email))
                return BadRequest("Username and Email are required.");

            if (userDto.UserName.Length < 7)
                return BadRequest("Username must have longer than 7 characters.");

            if (!userDto.Email.IsValidEmail()) return BadRequest("Email is not valid");

            var existingUser = await userManager.FindByNameAsync(userDto.UserName);
            if (existingUser != null) return BadRequest("User with this Name already exists");

            var existingEmail = await userManager.FindByEmailAsync(userDto.Email);
            if (existingEmail != null) return BadRequest("User with this Email already exists");

            var guestRole = await GetGuestRoleAsync();
            if (guestRole == null) return BadRequest($"Role {RoleName.User} not found.");
            var user = CreateNewUser(
                userName: userDto.UserName,
                email: userDto.Email,
                firstName: userDto.FirstName,
                lastName: userDto.LastName,
                dateOfBirth: userDto.DateOfBirth.ToDateTime(),
                guestRole: guestRole,
                gender: userDto.Gender,
                isExternalLogin: false
            );

            return await CreateUserAndWishlistAsync(user, userDto.Password);
        }


        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
        public async Task<IActionResult> GoogleAuthen(HttpContext httpContext)
        {
            var result = await httpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded || result.Principal == null)
                return BadRequest("Can't authenticate.");

            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var firstName = result.Principal.FindFirstValue(ClaimTypes.GivenName) ?? "Unknown";
            var lastName = result.Principal.FindFirstValue(ClaimTypes.Surname) ?? "Unknown";
            var googleId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var avatarUrl = string.Empty;
            if (result.Principal.HasClaim(c => c.Type == "urn:google:picture"))
            {
                avatarUrl = result.Principal.FindFirst("urn:google:picture")?.Value ?? null;
            }
            if (email == null) return BadRequest("Can't get email from Google.");

            var guestRole = await GetGuestRoleAsync();
            if (guestRole == null) return BadRequest($"Role {RoleName.User} not found.");

            var existingUser = await userManager.FindByEmailAsync(email);
            if (existingUser == null)
            {
                existingUser = CreateNewUser(
                    userName: email,
                    email: email,
                    firstName: firstName,
                    lastName: lastName,
                    guestRole: guestRole,
                    avatarUrl: avatarUrl,
                    providerName: "Google",
                    isExternalLogin: true
                );

                await CreateUserAndWishlistAsync(existingUser);
            }
            else
            {
                await userRepository.UpdateAsync(existingUser);
            }

            await SignInWithCookies(existingUser, httpContext, true);
            var redirectUrl = $"http://localhost:3000/";
            return Redirect(redirectUrl);
        }

        public async Task<IActionResult> DeleteUserAsync(HttpContext httpContext)
        {
            var userId = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await context.Users
                .Include(u => u.Wishlist) // Load các wishlist liên quan
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user != null)
            {
                context.Wishlists.RemoveRange(user.Wishlist);

                // Xóa user
                await userRepository.DeleteAsync(user.Id);

            }

            return Ok("Delete Succesfully");
        }
        public async Task<IActionResult> SignOutUser(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Sign Out Successfully");
        }
        private async Task<IActionResult> CreateUserAndWishlistAsync(User user, string? password = null)
        {
            IdentityResult result;
            result = string.IsNullOrEmpty(password) ? await userManager.CreateAsync(user) : await userManager.CreateAsync(user, password);

            if (!result.Succeeded) return BadRequest(
            string.Join(";", result.Errors.Select(e => e.Description)));

            var wishList = new Wishlist { User = user };
            await userRepository.AddWishlistAsync(wishList);
            user.Wishlist = wishList;
            await userRepository.UpdateAsync(user);
            return Ok(password != null ? "Created Successfully" : "User Created without Password");
        }
        private User CreateNewUser(string userName, string email, string firstName = "Unknown",
                string lastName = "Unknown", DateTime? dateOfBirth = null,
                Role? guestRole = null, string providerName = "Local",
                bool isExternalLogin = false, bool? gender = null, string? avatarUrl = null)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                ProfileName = $"{firstName} {lastName}",
                AvatarUrl = avatarUrl ?? $"{MyURL.Host}/images/avatars/noavatar.png",
                DateOfBirth = dateOfBirth,
                Role = guestRole,
                ProviderName = providerName,
                IsExternalLogin = isExternalLogin,
                EmailConfirmed = isExternalLogin,
                TotalMoney = 0
            };
        }
        public async Task<Role?> GetGuestRoleAsync()
        {
            return await context.Roles.FirstOrDefaultAsync(r => r.Name == RoleName.User);
        }
    }
}
