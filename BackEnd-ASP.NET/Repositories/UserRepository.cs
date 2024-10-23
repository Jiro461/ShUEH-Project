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
    public async Task<bool> DeleteAsync(Guid id, Guid? userId = null)
    {
        var user = await _dbSet.FindAsync(id);
        if (user == null) return false;
        _context.WishlistItems.RemoveRange(_context.WishlistItems.Where(s => s.UserId == id));
        _dbSet.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbSet
        .Select(user => new User
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DateOfBirth = user.DateOfBirth,
            Gender = user.Gender,
            PhoneNumber = user.PhoneNumber,
            CreateDate = user.CreateDate,
            Email = user.Email,
            ProfileName = user.ProfileName,
            AvatarUrl = user.AvatarUrl,
            TotalMoney = user.TotalMoney,
            EmailConfirmed = user.EmailConfirmed,
            Role = user.Role != null ? new Role
            {
                Id = user.Role.Id,
                Name = user.Role.Name
            } : null
        })
        .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbSet
        .Where(user => user.Id == id)
        .Include(user => user.Orders!).ThenInclude(order => order.OrderItems!)
        .Include(user => user.WishlistItems!)
        .FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(User entity, Guid? userId = null)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}
