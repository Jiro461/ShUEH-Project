using BackEnd_ASP_NET.Models;

public interface IShoeRepository
{
    Task<IEnumerable<Shoe>> GetAllShoesAsync();
    Task<Shoe> GetShoeByIdAsync(Guid id);
    Task<Shoe> AddShoeAsync(Shoe shoe);
    Task<Shoe> UpdateShoeAsync(Shoe shoe);
    Task<bool> DeleteShoeAsync(Guid id);
}

