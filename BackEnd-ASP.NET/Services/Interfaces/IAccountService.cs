using BackEnd_ASP.NET.Models.User;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_ASP.NET.Services
{
    public interface IAccountService
    {
        Task<IActionResult> Register(UserRegisterDto model);
        Task<IActionResult> GetByIdAsync(Guid id);
        Task<IActionResult> Login(UserLoginDto userLoginDto, HttpContext httpContext);
        Task<IActionResult> GoogleAuthen(HttpContext httpContext);

        Task<IActionResult> UpdateUserAsync(Guid id, UserPutDTO userDto);
        Task<IActionResult> DeleteUserAsync(HttpContext httpContext);
        // Add more methods as needed
        Task<IActionResult> SignOutUser(HttpContext httpContext);
        Task<IActionResult> GetUsersInfo();
    }
}