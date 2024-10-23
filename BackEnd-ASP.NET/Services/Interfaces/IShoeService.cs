using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ASP.NET.Services
{
    public interface IShoeService
    {
        Task<IActionResult> GetAllShoesAsync(Guid? userId = null);
        Task<IActionResult> GetShoeByIdAsync(Guid id);
        Task<IActionResult> AddShoeAsync(ShoePostDTO shoe);
        Task<IActionResult> UpdateShoeAsync(Guid shoeId, ShoePostDTO shoe);
        Task<IActionResult> DeleteShoeAsync(Guid id);
    }
}
