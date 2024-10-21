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
    public async Task<IEnumerable<ShoeGetDTO>> GetAllShoesAsync()
    {
        return await _dbSet
                .Select(shoe => new ShoeGetDTO
                {
                    Id = shoe.Id,
                    Name = shoe.Name,
                    Brand = shoe.Brand,
                    Material = shoe.Material ?? string.Empty,
                    Category = shoe.Category ?? string.Empty,
                    ImageUrl = shoe.ImageUrl ?? string.Empty,
                    Gender = shoe.Gender,
                    Price = shoe.Price,
                    Description = shoe.Description ?? string.Empty,
                    OtherImages = shoe.OtherImages == null ? null : shoe.OtherImages.Select(image => new ShoeImage
                    {
                        Id = image.Id,
                        Url = image.Url ?? string.Empty
                    }).ToList(),
                    shoeDetails = shoe.shoeDetails == null ? null : shoe.shoeDetails.Select(detail => new ShoeDetailDTO
                    {
                        Size = detail.Size,
                        Quantity = detail.Quantity
                    }).ToList(),
                    Seasons = shoe.Seasons == null ? null : shoe.Seasons.Select(season => new ShoeSeason
                    {
                        Id = season.Id,
                        Season = season.Season
                    }).ToList(),
                    CreatedAt = shoe.CreateDate,
                    Colors = shoe.Colors == null ? null : shoe.Colors.Select(color => new ShoeColorDTO
                    {
                        Color = color.Color
                    }).ToList(),
                })
                .ToListAsync();
    }

    public async Task<ShoeGetDTO?> GetShoeByIdAsync(Guid? id)
    {
        if (id == null)
        {
            throw new ArgumentException("Invalid shoe ID");
        }
        return await _dbSet
                .Where(shoe => shoe.Id == id)
                .Select(shoe => new ShoeGetDTO
                {
                    Id = shoe.Id,
                    Name = shoe.Name,
                    Brand = shoe.Brand,
                    Gender = shoe.Gender,
                    Price = shoe.Price,
                    Material = shoe.Material ?? string.Empty,
                    Category = shoe.Category ?? string.Empty,
                    ImageUrl = shoe.ImageUrl ?? string.Empty,
                    Description = shoe.Description ?? string.Empty,
                    OtherImages = shoe.OtherImages == null ? null : shoe.OtherImages.Select(image => new ShoeImage
                    {
                        Id = image.Id,
                        Url = image.Url
                    }).ToList(),
                    shoeDetails = shoe.shoeDetails == null ? null : shoe.shoeDetails.Select(detail => new ShoeDetailDTO
                    {
                        Size = detail.Size,
                        Quantity = detail.Quantity
                    }).ToList(),
                    Seasons = shoe.Seasons == null ? null : shoe.Seasons.Select(season => new ShoeSeason
                    {
                        Id = season.Id,
                        Season = season.Season
                    }).ToList(),
                    Colors = shoe.Colors == null ? null : shoe.Colors.Select(color => new ShoeColorDTO
                    {
                        Color = color.Color
                    }).ToList(),
                }).SingleOrDefaultAsync();
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
        _context.ShoeImages.RemoveRange(_context.ShoeImages.Where(s => s.ShoeId == id));
        _context.ShoeColors.RemoveRange(_context.ShoeColors.Where(s => s.ShoeId == id));
        _context.ShoeSeasons.RemoveRange(_context.ShoeSeasons.Where(s => s.ShoeId == id));
        _context.ShoeDetails.RemoveRange(_context.ShoeDetails.Where(s => s.ShoeId == id));
        _dbSet.Remove(shoe);
        await _context.SaveChangesAsync();
        return true;
    }
}
