using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ASP.NET.Services
{
    public interface IShoeService
    {
        Task<IEnumerable<ShoeGetAllDTO>?> GetAllShoesAsync(Guid? userId = null, int page = -1, int pageSize = -1);
        Task<IActionResult> GetShoeByIdFromUserAsync(Guid id, Guid? userId = null);
        Task<IActionResult> GetShoeByIdFromAdminAsync(Guid id);
        Task<IActionResult> AddShoeAsync(ShoePostDTO shoe);
        Task<IActionResult> UpdateShoeAsync(Guid shoeId, ShoePostDTO shoe);
        Task<IActionResult> DeleteShoeAsync(Guid id);
        Task<IEnumerable<ShoeGetAllDTO>> GetSimilarShoes(Guid shoeId);
        #region Convert
        ShoeGetDTO? ConvertShoeToShoeGetDTO(Shoe shoe, Guid? userId = null);
        List<ShoeGetAllDTO> ConvertListToListShoeGetAllDTOForAdmin(List<Shoe> shoes, Guid? userId = null);
        List<ShoeGetAllDTO> ConvertListToListShoeGetAllDTOForUser(List<Shoe> shoes, Guid? userId = null);
        #endregion
    }
}
