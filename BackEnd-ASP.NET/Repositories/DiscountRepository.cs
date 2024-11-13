using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;
using Microsoft.EntityFrameworkCore;

public class DiscountRepository : IDiscountRepository
{
    private readonly ShUEHContext context;  // DbContext để tương tác với cơ sở dữ liệu
    private readonly DbSet<Discount> dbSet;  // Đối tượng DbSet cho Discounts

    // Constructor nhận vào ShUEHContext để sử dụng cho các thao tác cơ sở dữ liệu
    public DiscountRepository(ShUEHContext context)
    {
        this.context = context;
        dbSet = context.Discounts;  // Khởi tạo DbSet từ context
    }

    /// <summary>
    /// Thêm một giảm giá mới vào cơ sở dữ liệu.
    /// </summary>
    public async Task<bool> AddDiscountAsync(Discount discount)
    {
        await dbSet.AddAsync(discount);  // Thêm giảm giá vào DbSet
        await context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return true;
    }

    /// <summary>
    /// Xóa giảm giá theo ID.
    /// </summary>
    public async Task<bool> DeleteDiscountAsync(Guid id)
    {
        var discount = await dbSet.FindAsync(id);  // Tìm giảm giá theo ID
        if (discount == null) return false;  // Nếu không tìm thấy giảm giá, trả về false
        dbSet.Remove(discount);  // Xóa giảm giá khỏi DbSet
        await context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return true;
    }

    /// <summary>
    /// Lấy tất cả các giảm giá trong cơ sở dữ liệu.
    /// </summary>
    public async Task<IEnumerable<Discount>> GetAllDiscountsAsync()
    {
        return await dbSet.ToListAsync();  // Lấy tất cả các giảm giá
    }

    /// <summary>
    /// Lấy thông tin giảm giá theo ID.
    /// </summary>
    public async Task<Discount?> GetDiscountByIdAsync(Guid id)
    {
        return await dbSet.FindAsync(id);  // Lấy giảm giá theo ID
    }

    /// <summary>
    /// Cập nhật thông tin giảm giá.
    /// </summary>
    public async Task<bool> UpdateDiscountAsync(Discount discount)
    {
        dbSet.Update(discount);  // Cập nhật giảm giá trong DbSet
        await context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return true;
    }
}
