using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ASP.NET.Services
{
    public interface IShoeService
    {
        Task<IActionResult> GetAllShoesAsync(Guid? userId = null, int page = 0, int pageSize = 10);
        Task<IActionResult> GetShoeByIdAsync(Guid id, Guid? userId = null);
        Task<IActionResult> AddShoeAsync(ShoePostDTO shoe);
        Task<IActionResult> UpdateShoeAsync(Guid shoeId, ShoePostDTO shoe);
        Task<IActionResult> DeleteShoeAsync(Guid id);
        List<ShoeGetDTO> ConvertToShoeGetDTO(List<Shoe> shoes, Guid? userId = null);
        List<ShoeGetAllDTO> ConvertToShoeGetAllDTO(List<Shoe> shoes, Guid? userId = null);
    }
}
