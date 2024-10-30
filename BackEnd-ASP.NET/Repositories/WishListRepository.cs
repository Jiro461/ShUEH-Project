using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class WishListRepository : IWishListRepository
{
    private readonly ShUEHContext _context;
    private readonly DbSet<WishlistItem> _dbSet;

    public WishListRepository(ShUEHContext context)
    {
        _context = context;
        _dbSet = context.WishlistItems; 
    }
    public async Task<IEnumerable<WishlistItem>> GetWishList(Guid userId)
    {
        return await _dbSet.Where(wishlistItem => wishlistItem.UserId == userId).ToListAsync();
    }
    public async Task<bool> AddToWishList(Guid userId, Guid shoeId)
    {
        try{
            await _dbSet.AddAsync(new WishlistItem { UserId = userId, ShoeId = shoeId });
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<bool> RemoveFromWishList(Guid userId, Guid shoeId)
    {
        var wishlistItem = await _dbSet.FirstOrDefaultAsync(wishlistItem => wishlistItem.UserId == userId && wishlistItem.ShoeId == shoeId);
        if (wishlistItem != null)
        {
            _dbSet.Remove(wishlistItem);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
