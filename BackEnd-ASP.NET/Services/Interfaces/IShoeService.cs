using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ASP.NET.Services
{
    public interface IShoeService
    {
        Task<ICollection<Shoe>> GetAllShoesAsync();
        Task<IActionResult> GetShoeByIdAsync(Guid id);
        Task<IActionResult> AddShoeAsync(Shoe shoe);
        Task<IActionResult> UpdateShoeAsync(Guid shoeId, Shoe shoe);
        Task<IActionResult> DeleteShoeAsync(Guid id);
    }
}
