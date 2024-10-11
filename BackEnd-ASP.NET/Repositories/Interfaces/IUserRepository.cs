using BackEnd_ASP_NET.Models;

public interface IUserRepository : IGenericRepository<User>
{
    Task AddWishlistAsync(Wishlist wishlist); 
}