using BackEnd_ASP_NET.Utilities.Extensions;
using BackEnd_ASP_NET.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Utilities.Security;


namespace BackEnd_ASP.NET.Services
{
    public class AccountService : ControllerBase, IAccountService
    {

        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;
        private readonly ShUEHContext context;
        public AccountService(IUserRepository userRepository, UserManager<User> userManager, ShUEHContext context)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.context = context;
        }
        public Task<IActionResult> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Register(RegisterUserDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Email))
            {
                return BadRequest("Username and Email are required.");
            }

            // Tìm xem có tồn tại tài khoản trùng hay không
            var existingUser = await userManager.FindByNameAsync(userDto.UserName);
            if (existingUser != null)
                return BadRequest("User with this name already exists");

            // Lấy ra Role User
            var guestRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == RoleName.User);
            if (guestRole == null)
                return BadRequest("Role not found.");

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
                PasswordHash = userDto.Password.ToMD5() // Sử dụng phương thức băm an toàn
            };
            
            //Thêm người dùng vào cơ sở dữ liệu trước
            await userRepository.AddAsync(user);

            var wishList = new Wishlist
            {
                UserId = user.Id
            };
            //Thêm wishlist cho người dùng vào cơ sở dữ liệu
            await userRepository.AddWishlistAsync(wishList);

            user.WistlistId = wishList.Id;

            //Cập nhật wishlistId cho người dùng
            await userRepository.UpdateAsync(user);
            return Ok("Created successfully.");
        }


        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
