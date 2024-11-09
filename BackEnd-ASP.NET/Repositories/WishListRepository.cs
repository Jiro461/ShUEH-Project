using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class WishListRepository : IWishListRepository
{
    private readonly ShUEHContext _context;  // Context của cơ sở dữ liệu
    private readonly DbSet<WishlistItem> _dbSet;  // DbSet cho bảng WishlistItems

    // Constructor: Khởi tạo WishListRepository với ShUEHContext
    public WishListRepository(ShUEHContext context)
    {
        _context = context;
        _dbSet = context.WishlistItems;  // Truy cập bảng WishlistItems
    }

    // Lấy danh sách các mục yêu thích của người dùng
    public async Task<IEnumerable<WishlistItem>> GetWishList(Guid userId)
    {
        return await _dbSet.Where(wishlistItem => wishlistItem.UserId == userId)  // Lọc danh sách yêu thích theo userId
                           .ToListAsync();  // Chuyển kết quả thành danh sách bất đồng bộ
    }

    // Thêm một giày vào danh sách yêu thích của người dùng
    public async Task<bool> AddToWishList(Guid userId, Guid shoeId)
    {
        try
        {
            // Thêm mục mới vào bảng WishlistItems
            await _dbSet.AddAsync(new WishlistItem { UserId = userId, ShoeId = shoeId });
            await _context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
            return true;  // Trả về true nếu thêm thành công
        }
        catch (Exception)
        {
            return false;  // Trả về false nếu có lỗi
        }
    }

    // Xóa một giày khỏi danh sách yêu thích của người dùng
    public async Task<bool> RemoveFromWishList(Guid userId, Guid shoeId)
    {
        // Tìm mục yêu thích dựa trên userId và shoeId
        var wishlistItem = await _dbSet.FirstOrDefaultAsync(wishlistItem => wishlistItem.UserId == userId && wishlistItem.ShoeId == shoeId);
        if (wishlistItem != null)
        {
            // Nếu tìm thấy, xóa mục khỏi danh sách yêu thích
            _dbSet.Remove(wishlistItem);
            await _context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
            return true;  // Trả về true nếu xóa thành công
        }
        return false;  // Trả về false nếu không tìm thấy mục
    }
}
