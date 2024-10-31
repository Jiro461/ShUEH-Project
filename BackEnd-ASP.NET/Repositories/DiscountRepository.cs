using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DiscountRepository : IDiscountRepository
{
    private readonly ShUEHContext context;
    private readonly DbSet<Discount> dbSet;

    public DiscountRepository(ShUEHContext context)
    {
        this.context = context;
        dbSet = context.Discounts;
    }
    public async Task<bool> AddDiscountAsync(Discount discount)
    {
        await dbSet.AddAsync(discount);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteDiscountAsync(Guid id)
    {
        var discount = await dbSet.FindAsync(id);
        if (discount == null) return false;
        dbSet.Remove(discount);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Discount>> GetAllDiscountsAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<Discount?> GetDiscountByIdAsync(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<bool> UpdateDiscountAsync(Discount discount)
    {
        dbSet.Update(discount);
        await context.SaveChangesAsync();
        return true;
    }
}