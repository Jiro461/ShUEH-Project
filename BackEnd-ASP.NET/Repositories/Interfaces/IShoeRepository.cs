using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;

public interface IShoeRepository
{
    Task<IEnumerable<ShoeGetDTO>> GetAllShoesAsync();
    Task<ShoeGetDTO?> GetShoeByIdAsync(Guid? id);
    Task<Shoe> AddShoeAsync(Shoe shoe);
    Task<Shoe> UpdateShoeAsync(Shoe shoe);
    Task<bool> DeleteShoeAsync(Guid id);
    Task AddShoeColorAsync(IEnumerable<ShoeColor> shoeColors);
    Task AddShoeImageAsync(IEnumerable<ShoeImage> shoeImages);
    Task AddShoeSeasonAsync(IEnumerable<ShoeSeason> shoeSeasons);
    Task AddShoeSizeAsync(IEnumerable<ShoeSize> shoeSizes);
}

