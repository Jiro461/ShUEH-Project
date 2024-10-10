using Microsoft.AspNetCore.Mvc;

public interface IUserService
{
    Task<IActionResult> RegisterAsync(RegisterUserDto model);
    Task<User?> GetByIdAsync(Guid id);
    Task<IActionResult> AuthenticateAsync(string username, string password);
    Task UpdateUserAsync(User user);
    // Add more methods as needed
}