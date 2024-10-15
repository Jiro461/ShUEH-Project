using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly ShUEHContext _context;
    private readonly DbSet<User> _dbSet;
    private readonly INotificationService notificationService;

    public UserRepository(ShUEHContext context, INotificationService notificationService)
    {
        _context = context;
        _dbSet = context.Users;
        this.notificationService = notificationService;
    }

    public async Task AddAsync(User entity, Guid? userId = null)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddWishlistAsync(Wishlist wishlist, Guid? userId = null)
    {
        await _context.Wishlists.AddAsync(wishlist);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id, Guid? userId = null)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(User entity, Guid? userId = null)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}