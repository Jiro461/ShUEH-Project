using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP.NET.Models.ShoeDetail;
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
    public async Task<List<Shoe>> GetShoesByIdsAsync(List<Guid> shoeIds)
    {
        return await _dbSet
                    .Where(shoe => shoeIds.Contains(shoe.Id))
                    .ToListAsync();
    }
    public async Task<IEnumerable<Shoe>> GetAllShoesAsync()
    {
        return await _dbSet.Include(shoe => shoe.shoeDetails)
                            .Include(shoe => shoe.Seasons)
                            .Include(shoe => shoe.Colors)
                            .Include(shoe => shoe.OtherImages)
                            .Include(shoe => shoe.Comments)
                            .ToListAsync();
    }

    public async Task<Shoe?> GetShoeByIdAsync(Guid id)
    {
        return await _dbSet.Where(shoe => shoe.Id == id)
                            .Include(shoe => shoe.shoeDetails)
                            .Include(shoe => shoe.Seasons)
                            .Include(shoe => shoe.Colors)
                            .Include(shoe => shoe.OtherImages)
                            .Include(shoe => shoe.Comments)
                            .FirstOrDefaultAsync();
    }

    public async Task<Shoe> AddShoeAsync(Shoe shoe)
    {
        _dbSet.Add(shoe);
        await _context.SaveChangesAsync();
        return shoe;
    }

    public async Task<Shoe> UpdateShoeAsync(Shoe shoe)
    {
        _dbSet.Update(shoe);
        await _context.SaveChangesAsync();
        return shoe;
    }

    public async Task<bool> DeleteShoeAsync(Guid id)
    {
        var shoe = await _dbSet.FindAsync(id);
        if (shoe == null)
            return false;
        //Xóa image của shoe
        _context.ShoeImages.RemoveRange(_context.ShoeImages.Where(s => s.ShoeId == id));
        //Xóa color của shoe
        _context.ShoeColors.RemoveRange(_context.ShoeColors.Where(s => s.ShoeId == id));
        //Xóa season của shoe
        _context.ShoeSeasons.RemoveRange(_context.ShoeSeasons.Where(s => s.ShoeId == id));
        //Xóa detail của shoe
        _context.ShoeDetails.RemoveRange(_context.ShoeDetails.Where(s => s.ShoeId == id));
        //Lấy comment của shoe
        var shoeComments = await _context.Comments.Where(s => s.ShoeId == id)
                                                .Include(s => s.CommentLikes)
                                                .ToListAsync();    
        //Xóa like của comment
        foreach (var comment in shoeComments)
        {
            _context.CommentLikes.RemoveRange(_context.CommentLikes.Where(s => s.CommentId == comment.Id));
        }
        //Xóa comment
        _context.Comments.RemoveRange(shoeComments);
        _dbSet.Remove(shoe);
        await _context.SaveChangesAsync();
        return true;
    }
}
