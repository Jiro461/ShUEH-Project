using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP.NET.Models.ShoeDetail;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ShoeRepository : IShoeRepository
{
    private readonly ShUEHContext _context;  // DbContext để tương tác với cơ sở dữ liệu
    private readonly DbSet<Shoe> _dbSet;  // DbSet cho bảng Shoes

    public ShoeRepository(ShUEHContext context)
    {
        _context = context;
        _dbSet = context.Shoes;  // Khởi tạo DbSet từ context
    }

    #region Get All Shoes
    public async Task<IEnumerable<Shoe>> GetAllShoesAsync(int page, int pageSize)
    {
        var query = await _dbSet.Include(shoe => shoe.shoeDetails.OrderBy(detail => detail.Size))  // Bao gồm các chi tiết của giày và sắp xếp theo kích thước
                                .Include(shoe => shoe.Seasons)  // Bao gồm các mùa liên quan đến giày
                                .Include(shoe => shoe.Colors)  // Bao gồm các màu sắc của giày
                                .Include(shoe => shoe.OtherImages)  // Bao gồm các hình ảnh khác của giày
                                .ToListAsync();
        if(page == -1 && pageSize == -1) return query;  // Nếu phân trang không được yêu cầu, trả về toàn bộ dữ liệu
        return query.Skip(page * pageSize).Take(pageSize);  // Áp dụng phân trang
    }
    #endregion

    #region Get Shoe By Id
    public async Task<Shoe?> GetShoeByIdAsync(Guid id)
    {
        return await _dbSet.Where(shoe => shoe.Id == id)  // Lọc theo ID giày
                            .Include(shoe => shoe.shoeDetails.OrderBy(detail => detail.Size))  // Bao gồm chi tiết giày và sắp xếp theo kích thước
                            .Include(shoe => shoe.Seasons)  // Bao gồm các mùa
                            .Include(shoe => shoe.Colors)  // Bao gồm các màu sắc
                            .Include(shoe => shoe.OtherImages)  // Bao gồm các hình ảnh khác
                            .Include(shoe => shoe.Comments.OrderByDescending(comment => comment.CreateDate))  // Bao gồm các bình luận, sắp xếp theo ngày tạo
                            .FirstOrDefaultAsync();  // Trả về giày đầu tiên hoặc null nếu không tìm thấy
    }
    #endregion

    #region Add Shoe
    public async Task<Shoe> AddShoeAsync(Shoe shoe)
    {
        _dbSet.Add(shoe);  // Thêm giày mới vào DbSet
        await _context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return shoe;
    }
    #endregion

    #region Update Shoe
    public async Task<Shoe> UpdateShoeAsync(Shoe shoe)
    {
        _dbSet.Update(shoe);  // Cập nhật giày trong DbSet
        await _context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return shoe;
    }
    #endregion

    #region Delete Shoe
    public async Task<bool> DeleteShoeAsync(Guid id)
    {
        var shoe = await _dbSet.FindAsync(id);  // Tìm giày theo ID
        if (shoe == null)
            return false;  // Nếu không tìm thấy giày, trả về false

        // Xóa tất cả các liên kết và dữ liệu liên quan đến giày này
        _context.ShoeImages.RemoveRange(_context.ShoeImages.Where(s => s.ShoeId == id));  // Xóa hình ảnh của giày
        _context.ShoeColors.RemoveRange(_context.ShoeColors.Where(s => s.ShoeId == id));  // Xóa các màu sắc của giày
        _context.ShoeSeasons.RemoveRange(_context.ShoeSeasons.Where(s => s.ShoeId == id));  // Xóa các mùa của giày
        _context.ShoeDetails.RemoveRange(_context.ShoeDetails.Where(s => s.ShoeId == id));  // Xóa các chi tiết của giày

        // Lấy và xóa các bình luận và các phần tử liên quan
        var shoeComments = await _context.Comments.Where(s => s.ShoeId == id)
                                                    .Include(s => s.CommentLikes)
                                                    .ToListAsync();
        foreach (var comment in shoeComments)
        {
            _context.CommentLikes.RemoveRange(_context.CommentLikes.Where(s => s.CommentId == comment.Id));  // Xóa like của bình luận
            _context.Replies.RemoveRange(_context.Replies.Where(r => r.CommentId == comment.Id));  // Xóa các phản hồi cho bình luận
        }

        // Xóa bình luận và thông báo liên quan đến giày
        _context.Comments.RemoveRange(shoeComments);
        _context.Notifications.RemoveRange(_context.Notifications.Where(n => n.ShoeId == id));  // Xóa thông báo
        _dbSet.Remove(shoe);  // Xóa giày khỏi DbSet

        await _context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return true;
    }
    #endregion
}
