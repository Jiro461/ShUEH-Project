using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ShUEHContext _context;

    public UserRepository(ShUEHContext context) : base(context)
    {
        _context = context;
    }

    public async Task AddWishlistAsync(Wishlist wishlist)
    {
        await _context.Wishlists.AddAsync(wishlist);
        await _context.SaveChangesAsync();
    }
}