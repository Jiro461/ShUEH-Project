using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class ShoeRepository : IShoeRepository
{
    private readonly ShUEHContext _context;
    private readonly DbSet<Shoe> _dbSet;

    public ShoeRepository(ShUEHContext context)
    {
        _context = context;
        _dbSet = context.Shoes;
    }

    public async Task<IEnumerable<Shoe>> GetAllShoesAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Shoe> GetShoeByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<Shoe> AddShoeAsync(Shoe shoe)
    {
        _dbSet.Add(shoe);
        await _context.SaveChangesAsync();
        return shoe;
    }

    public async Task<Shoe> UpdateShoeAsync(Shoe shoe)
    {
        var existingShoe = await _dbSet.FindAsync(shoe.Id);
        if (existingShoe == null)
        {
            throw new KeyNotFoundException($"Shoe with ID {shoe.Id} not found.");
        }

        _context.Entry(existingShoe).CurrentValues.SetValues(shoe);
        await _context.SaveChangesAsync();
        return existingShoe;
    }

    public async Task<bool> DeleteShoeAsync(Guid id)
    {
        var shoe = await _dbSet.FindAsync(id);
        if (shoe == null)
            return false;

        _dbSet.Remove(shoe);
        await _context.SaveChangesAsync();
        return true;
    }
}
