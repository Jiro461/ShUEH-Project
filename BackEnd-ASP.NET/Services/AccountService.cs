using BackEnd_ASP_NET.Utilities.Extensions;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BackEnd_ASP.NET.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using BackEnd_ASP.NET.Models.User;
using BackEnd_ASP_NET.Utilities.FileHelpers;

namespace BackEnd_ASP.NET.Services
{
    // Lớp AccountService xử lý các chức năng liên quan đến tài khoản người dùng (đăng nhập, đăng ký, thay đổi mật khẩu, v.v.)
    public class AccountService : ControllerBase, IAccountService
    {
        private readonly IUserRepository userRepository;  // Repository để truy cập dữ liệu người dùng
        private readonly UserManager<User> userManager;  // Quản lý người dùng từ ASP.NET Identity
        private readonly ShUEHContext context;  // Context để truy cập cơ sở dữ liệu
        private readonly SignInManager<User> signInManager;  // Quản lý quá trình đăng nhập của người dùng
        private readonly INotificationService notificationService;  // Dịch vụ thông báo cho người dùng
        private readonly IWebHostEnvironment _webHostEnvironment;  // Môi trường lưu trữ web (cho việc lưu ảnh đại diện người dùng, v.v.)

        // Constructor để khởi tạo các dependency cần thiết
        public AccountService(IUserRepository userRepository, UserManager<User> userManager,
            ShUEHContext context, SignInManager<User> signInManager, INotificationService notificationService, IWebHostEnvironment webHostEnvironment)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.context = context;
            this.signInManager = signInManager;
            this.notificationService = notificationService;
            this._webHostEnvironment = webHostEnvironment;
        }

        // Phương thức hỗ trợ đăng nhập và lưu trữ thông tin vào cookies
        private async Task SignInWithCookies(User user, HttpContext httpContext, bool rememberMe)
        {
            var roleName = context.Roles.FirstOrDefault(r => r.Id == user.RoleId)?.Name;  // Lấy tên vai trò của người dùng
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),  // Thêm thông tin ID người dùng
                new Claim(ClaimTypes.Name, user.UserName ?? "Unknown"),  // Thêm tên người dùng
                new Claim(ClaimTypes.Email, user.Email ?? "NoEmail"),  // Thêm email người dùng
                new Claim(ClaimTypes.Role, roleName ?? "None"),  // Thêm vai trò người dùng
                new Claim(ClaimTypes.Gender, user.Gender.ToString() ?? "Both"),  // Thêm giới tính người dùng
                new Claim("Provider", user.ProviderName ?? "Local"),  // Thêm thông tin về nhà cung cấp (Google, Facebook, v.v.)
                new Claim("IsExternal", user.IsExternalLogin.ToString() ?? "False"),  // Kiểm tra xem người dùng có đăng nhập qua bên thứ ba không
                new Claim("IPAddress", httpContext.Connection.RemoteIpAddress?.ToString() ?? "Undefined")  // Thêm địa chỉ IP của người dùng
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);  // Tạo ClaimsIdentity
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);  // Tạo ClaimsPrincipal

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,  // Kiểm tra xem người dùng có muốn giữ đăng nhập hay không
                ExpiresUtc = rememberMe
                    ? DateTimeOffset.UtcNow.AddDays(7)  // Nếu nhớ mật khẩu, thời gian hết hạn là 7 ngày
                    : DateTimeOffset.UtcNow.AddHours(1)  // Nếu không, hết hạn sau 1 giờ
            };

            // Đăng nhập người dùng và lưu thông tin vào cookie
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);
        }

        // Phương thức đăng nhập người dùng
        public async Task<IActionResult> Login(UserLoginDto userLoginDto, HttpContext httpContext)
        {
            if (string.IsNullOrEmpty(userLoginDto.UserName) || string.IsNullOrEmpty(userLoginDto.Password)) 
                return BadRequest("Username and Password are required.");  // Kiểm tra dữ liệu đầu vào

            var user = await userManager.FindByNameAsync(userLoginDto.UserName);  // Tìm người dùng theo tên
            if (user == null) return BadRequest(new { message = "Invalid username or password" });  // Nếu không tìm thấy người dùng

            var result = await signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, true);  // Kiểm tra mật khẩu người dùng
            if (!result.Succeeded) return BadRequest($"Invalid Username or Password");  // Nếu mật khẩu sai

            await SignInWithCookies(user, httpContext, userLoginDto.rememberMe);  // Đăng nhập và lưu vào cookies
            return Ok("Login successfully");  // Trả về thông báo thành công
        }

        // Phương thức lấy thông tin của tất cả người dùng
        public async Task<IActionResult> GetUsersInfo()
        {
            var users = await userRepository.GetAllAsync();  // Lấy tất cả người dùng từ repository
            var userInfoDTOs = users.Select(user => new UserInfoDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AvatarUrl = user.AvatarUrl,
                ProfileName = user.ProfileName,
                CreateDate = user.CreateDate,
                Email = user.Email,
                Role = user.Role?.Name,
                EmailConfirmed = user.EmailConfirmed,
                IsExternalLogin = user.IsExternalLogin
            });
            return Ok(userInfoDTOs);  // Trả về danh sách thông tin người dùng
        }

        // Phương thức lấy thông tin chi tiết của một người dùng theo ID
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            User? user = await userRepository.GetByIdAsync(id);  // Tìm người dùng theo ID
            if (user == null) return NotFound("User not found");  // Nếu không tìm thấy người dùng

            var userDto = new UserGetDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role?.Name,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                ProfileName = user.ProfileName,
                AvatarUrl = user.AvatarUrl,
                TotalMoney = user.TotalMoney,
                CreatedAt = user.CreateDate,
                EmailConfirmed = user.EmailConfirmed,
                IsExternalLogin = user.IsExternalLogin
            };

            return Ok(userDto);  // Trả về thông tin chi tiết của người dùng
        }

        // Phương thức đăng ký người dùng mới
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Email))
                return BadRequest("Username and Email are required.");  // Kiểm tra tên người dùng và email

            if (userDto.UserName.Length < 7)
                return BadRequest("Username must have longer than 7 characters.");  // Kiểm tra độ dài tên người dùng

            if (!userDto.Email.IsValidEmail()) return BadRequest("Email is not valid");  // Kiểm tra định dạng email hợp lệ

            var existingUser = await userManager.FindByNameAsync(userDto.UserName);  // Kiểm tra tên người dùng đã tồn tại chưa
            if (existingUser != null) return BadRequest("User with this Name already exists");

            var existingEmail = await userManager.FindByEmailAsync(userDto.Email);  // Kiểm tra email đã tồn tại chưa
            if (existingEmail != null) return BadRequest("User with this Email already exists");

            var guestRole = await GetGuestRoleAsync();  // Lấy vai trò khách (Guest)
            if (guestRole == null) return BadRequest($"Role {RoleName.User} not found.");  // Nếu không tìm thấy vai trò

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
            return await CreateUserAsync(user, userDto.Password);  // Tạo người dùng mới
        }


        // Cập nhật thông tin người dùng trong cơ sở dữ liệu
        public async Task<IActionResult> UpdateUserAsync(Guid id, UserPutDTO userDto)
        {
            // Lấy thông tin người dùng theo ID
            var user = await userRepository.GetByIdAsync(id);
            if (user == null) return NotFound("User not found"); // Nếu không tìm thấy người dùng, trả về lỗi 404
            if (!ModelState.IsValid) return BadRequest(ModelState); // Nếu trạng thái model không hợp lệ, trả về lỗi 400 với thông tin lỗi

            // Lấy role từ cơ sở dữ liệu dựa trên tên role đã cung cấp
            var role = await context.Roles.FirstOrDefaultAsync(r => r.Name!.ToLower() == userDto.Role!.ToLower());
            if (role == null) return BadRequest($"Role {userDto.Role} not found."); // Nếu không tìm thấy role, trả về lỗi 400

            // Cập nhật thông tin người dùng với dữ liệu từ DTO
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.ProfileName = userDto.ProfileName;
            user.Role = role;
            user.DateOfBirth = userDto.DateOfBirth?.ToDateTime(); // Chuyển đổi ngày sinh thành DateTime
            user.Gender = userDto.Gender;
            user.Email = userDto.Email;
            user.ProfileName = userDto.ProfileName; // Cập nhật lại tên hồ sơ

            // Nếu có ảnh đại diện mới, cập nhật URL ảnh đại diện
            if (userDto.Avatar != null)
                user.AvatarUrl = await FileHelper.UpdateAvatarAsync(_webHostEnvironment, user, userDto);

            // Lưu thông tin người dùng đã được cập nhật
            await userRepository.UpdateAsync(user);

            // Tạo thông báo cho việc cập nhật người dùng
            await notificationService.CreateUpdateNotificationForEntityChange(user, user.Id);
            return Ok("Update Successfully"); // Trả về phản hồi thành công
        }

        // Thêm người dùng mới vào hệ thống
        public async Task<IActionResult> AddUserAsync(UserAddDTO userDto)
        {
            // Kiểm tra xem role có tồn tại hay không
            var role = await context.Roles.FirstOrDefaultAsync(r => r.Name!.ToLower() == userDto.Role!.ToLower());
            if (role == null) return BadRequest($"Role {userDto.Role} not found.");

            // Kiểm tra nếu tên người dùng hoặc email trống
            if (string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Email))
                return BadRequest("Username and Email are required."); // Nếu tên người dùng hoặc email trống, trả về lỗi 400

            // Kiểm tra tính hợp lệ của email
            if (!userDto.Email.IsValidEmail()) return BadRequest("Email is not valid"); // Nếu email không hợp lệ, trả về lỗi 400

            // Kiểm tra nếu người dùng đã tồn tại theo tên người dùng
            var existingUser = await userManager.FindByNameAsync(userDto.UserName);
            if (existingUser != null) return BadRequest("User with this Name already exists"); // Nếu tên người dùng đã tồn tại, trả về lỗi 400

            // Kiểm tra nếu người dùng đã tồn tại theo email
            var existingEmail = await userManager.FindByEmailAsync(userDto.Email);
            if (existingEmail != null) return BadRequest("User with this Email already exists"); // Nếu email đã tồn tại, trả về lỗi 400

            // Tạo người dùng mới
            var user = CreateNewUser(
                userName: userDto.UserName,
                email: userDto.Email,
                firstName: userDto.FirstName,
                lastName: userDto.LastName,
                dateOfBirth: userDto.DateOfBirth.ToDateTime(),
                guestRole: role,
                gender: userDto.Gender,
                isExternalLogin: false
            );

            // Tạo người dùng trong hệ thống
            return await CreateUserAsync(user, userDto.Password);
        }

// Xác thực người dùng thông qua Google
        public async Task<IActionResult> GoogleAuthen(HttpContext httpContext)
        {
            // Xác thực người dùng thông qua cookie
            var result = await httpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Nếu xác thực thất bại hoặc không có thông tin người dùng, trả về lỗi
            if (!result.Succeeded || result.Principal == null)
                return BadRequest("Can't authenticate.");

            // Lấy thông tin người dùng từ Google
            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var firstName = result.Principal.FindFirstValue(ClaimTypes.GivenName) ?? "Unknown";
            var lastName = result.Principal.FindFirstValue(ClaimTypes.Surname) ?? "Unknown";
            var googleId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var avatarUrl = string.Empty;

            // Nếu có ảnh đại diện trong thông tin Google, lấy ảnh đại diện
            if (result.Principal.HasClaim(c => c.Type == "urn:google:picture"))
            {
                avatarUrl = result.Principal.FindFirst("urn:google:picture")?.Value ?? null;
            }
            if (email == null) return BadRequest("Can't get email from Google.");

            // Lấy role người dùng
            var guestRole = await GetGuestRoleAsync();
            if (guestRole == null) return BadRequest($"Role {RoleName.User} not found.");

            // Kiểm tra xem người dùng đã tồn tại chưa
            var existingUser = await userManager.FindByEmailAsync(email);
            if (existingUser == null)
            {
                // Nếu người dùng chưa tồn tại, tạo người dùng mới
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

                await CreateUserAsync(existingUser);
            }
            else
            {
                // Nếu người dùng đã tồn tại, cập nhật thông tin người dùng
                await userRepository.UpdateAsync(existingUser);
        }

            // Đăng nhập người dùng bằng cookie
            await SignInWithCookies(existingUser, httpContext, true);

            // Chuyển hướng người dùng về trang chủ
            var redirectUrl = $"{MyURL.ClientURL}/";
            return Redirect(redirectUrl);
        }

        // Xóa người dùng hiện tại
        public async Task<IActionResult> DeleteUserByUserAsync(HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return BadRequest("User ID is required."); // Nếu không có ID người dùng, trả về lỗi 400
            var user = await userRepository.GetByIdAsync(Guid.Parse(userId));
            if (user == null) return BadRequest("User not found."); // Nếu không tìm thấy người dùng, trả về lỗi 400

            // Xóa người dùng và tạo thông báo xóa
            if (await userRepository.DeleteAsync(Guid.Parse(userId)))
            {
                await notificationService.CreateNotificationForEntityDelete(user);
                return Ok("Delete Succesfully"); // Trả về phản hồi thành công
            }
            return BadRequest("Delete Failed"); // Trả về lỗi nếu xóa không thành công
        }

        // Xóa người dùng bởi quản trị viên
        public async Task<IActionResult> DeleteUserByAdminAsync(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null) return NotFound("User not found"); // Nếu không tìm thấy người dùng, trả về lỗi 404

            // Xóa người dùng và tạo thông báo xóa
            if (await userRepository.DeleteAsync(id))
            {
                await notificationService.CreateNotificationForEntityDelete(user);
                return Ok("Delete Succesfully"); // Trả về phản hồi thành công
            }
            return BadRequest("Delete Failed"); // Trả về lỗi nếu xóa không thành công
        }

        // Đăng xuất người dùng
        public async Task<IActionResult> SignOutUser(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // Đăng xuất người dùng
            return Ok("Sign Out Successfully"); // Trả về phản hồi thành công
        }

        public async Task<IActionResult> ChangePassword(string? email, string? newPassword)
        {
            // Kiểm tra xem email và mật khẩu mới có trống không
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(newPassword))
            {
                return BadRequest("Email and new password are required."); // Trả về lỗi nếu không có email hoặc mật khẩu mới
            }

            // Tìm người dùng theo email
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest("User not found."); // Nếu không tìm thấy người dùng, trả về lỗi
            if (user.IsExternalLogin == true) return BadRequest("User is external login."); // Nếu người dùng đăng nhập bằng tài khoản bên ngoài (Google, Facebook, etc.), không thể thay đổi mật khẩu

            // Tạo mã thông báo (token) để thiết lập lại mật khẩu
            var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, resetToken, newPassword); // Gọi hàm để thiết lập lại mật khẩu

            if (result.Succeeded)
            {
                return Ok("Password reset successfully."); // Nếu thành công, trả về thông báo thành công
            }

            // Nếu có lỗi, trả về lỗi chi tiết
            return BadRequest(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<IActionResult> ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            // Tìm người dùng theo userId
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null) return BadRequest("User not found."); // Nếu không tìm thấy người dùng, trả về lỗi
            if (currentPassword == newPassword) return BadRequest("New password cannot be the same as the current password."); // Nếu mật khẩu mới giống mật khẩu cũ, trả về lỗi
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword)) return BadRequest("Current password and new password are required."); // Nếu mật khẩu hiện tại hoặc mới trống, trả về lỗi

            // Kiểm tra mật khẩu hiện tại với mật khẩu lưu trữ
            var result = await userManager.CheckPasswordAsync(user, currentPassword);
            if (!result) return BadRequest("Current password is incorrect."); // Nếu mật khẩu hiện tại không đúng, trả về lỗi

            if (user.IsExternalLogin == true) return BadRequest("User is external login."); // Nếu người dùng đăng nhập bằng tài khoản bên ngoài, không thể thay đổi mật khẩu

            // Kiểm tra xem người dùng có mật khẩu chưa
            var IsHasPassword = await userManager.HasPasswordAsync(user);
            if (IsHasPassword)
            {
                // Tạo mã thông báo và thiết lập mật khẩu mới
                var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                var result_check = await userManager.ResetPasswordAsync(user, resetToken, newPassword);

                if (result_check.Succeeded)
                {
                    return Ok("Password changed successfully."); // Nếu thay đổi mật khẩu thành công
                }

                // Trả về lỗi nếu có lỗi trong quá trình thay đổi mật khẩu
                return BadRequest(string.Join(", ", result_check.Errors.Select(e => e.Description)));
            }

            // Trả về lỗi nếu người dùng chưa có mật khẩu
            return BadRequest("User does not have a password.");
        }

        private async Task<IActionResult> CreateUserAsync(User user, string? password = null)
        {
            IdentityResult result;
            // Nếu có mật khẩu thì tạo người dùng với mật khẩu, nếu không thì tạo không có mật khẩu
            result = string.IsNullOrEmpty(password) ? await userManager.CreateAsync(user) : await userManager.CreateAsync(user, password);

            if (!result.Succeeded) return BadRequest(
            string.Join(";", result.Errors.Select(e => e.Description))); // Nếu có lỗi trong quá trình tạo người dùng, trả về lỗi

            // Gửi thông báo khi tạo người dùng mới
            await notificationService.CreateNotificationForNewUser(user);
            return Ok(password != null ? "Created Successfully" : "User Created without Password"); // Trả về thông báo thành công
        }

        private User CreateNewUser(string userName, string email, string firstName = "Unknown",
                string lastName = "Unknown", DateTime? dateOfBirth = null,
                Role? guestRole = null, string providerName = "Local",
                bool isExternalLogin = false, bool? gender = null, string? avatarUrl = null)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                UserName = userName.Trim(),
                NormalizedUserName = userName.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                Gender = gender,
                ProfileName = $"{firstName} {lastName}",
                AvatarUrl = avatarUrl ?? $"/images/avatars/noavatar.png", // Nếu không có ảnh đại diện, gán ảnh mặc định
                DateOfBirth = dateOfBirth,
                Role = guestRole,
                ProviderName = providerName,
                IsExternalLogin = isExternalLogin,
                EmailConfirmed = isExternalLogin, // Nếu là đăng nhập bên ngoài, coi như email đã xác nhận
                TotalMoney = 0 // Khởi tạo số tiền cho người dùng
            };
        }

        public async Task<Role?> GetGuestRoleAsync()
        {
            // Lấy thông tin role "User" từ cơ sở dữ liệu
            return await context.Roles.FirstOrDefaultAsync(r => r.Name == RoleName.User);
        }
    }
}
