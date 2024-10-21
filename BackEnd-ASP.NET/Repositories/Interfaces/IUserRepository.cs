using BackEnd_ASP_NET.Models;

public interface IUserRepository
{
    Task AddAsync(User entity, Guid? userId = null);
    Task UpdateAsync(User entity, Guid? userId = null);
    Task DeleteAsync(Guid id, Guid? userId = null);
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddWishlistAsync(Wishlist wishlist, Guid? userId = null);
}