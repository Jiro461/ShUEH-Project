public interface IUserRepository : IGenericRepository<User>
{
    Task AddWishlistAsync(Wishlist wishlist); 
}