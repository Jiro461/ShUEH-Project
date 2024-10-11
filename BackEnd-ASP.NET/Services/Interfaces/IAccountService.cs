using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_ASP.NET.Services
{
    public interface IAccountService
    {
        Task<IActionResult> Register(RegisterUserDto model);
        Task<User?> GetByIdAsync(Guid id);
        Task<IActionResult> Login(string username, string password);
        Task UpdateUserAsync(User user);
        // Add more methods as needed
    }
}