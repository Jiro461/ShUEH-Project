using BackEnd_ASP.NET.Models.User;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_ASP.NET.Services
{
    public interface IAccountService
    {
        Task<IActionResult> Register(UserRegisterDto model);
        Task<IActionResult> AddUserAsync(UserAddDTO userAddDTO);
        Task<IActionResult> GetUserByIdAsync(Guid id);
        Task<IActionResult> Login(UserLoginDto userLoginDto, HttpContext httpContext);
        Task<IActionResult> GoogleAuthen(HttpContext httpContext);

        Task<IActionResult> UpdateUserAsync(Guid id, UserPutDTO userDto);
        Task<IActionResult> DeleteUserByUserAsync(HttpContext httpContext);
        Task<IActionResult> DeleteUserByAdminAsync(Guid id);
        // Add more methods as needed
        Task<IActionResult> SignOutUser(HttpContext httpContext);
        Task<IActionResult> GetUsersInfo();
        Task<IActionResult> ChangePassword(string? email, string? newPassword);
        Task<IActionResult> ChangePassword(Guid userId, string currentPassword, string newPassword);
    }
}