using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP_NET.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly ShUEHContext _context;  // Context của cơ sở dữ liệu
    private readonly DbSet<User> _dbSet;     // DbSet cho bảng Users
    private readonly INotificationService notificationService;  // Dịch vụ thông báo

    // Constructor: Khởi tạo UserRepository với ShUEHContext và INotificationService
    public UserRepository(ShUEHContext context, INotificationService notificationService)
    {
        _context = context;
        _dbSet = context.Users;  // Truy cập bảng Users
        this.notificationService = notificationService;  // Để có thể gửi thông báo nếu cần
    }

    // Thêm mới một User vào cơ sở dữ liệu
    public async Task AddAsync(User entity, Guid? userId = null)
    {
        await _dbSet.AddAsync(entity);  // Thêm người dùng vào DbSet
        await _context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
    }

    // Xóa một User dựa trên ID
    public async Task<bool> DeleteAsync(Guid id, Guid? userId = null)
    {
        var user = await _dbSet.FindAsync(id);  // Tìm người dùng theo ID
        if (user == null) return false;  // Nếu không tìm thấy người dùng, trả về false

        // Xóa các mục liên quan đến người dùng này từ các bảng khác
        _context.WishlistItems.RemoveRange(_context.WishlistItems.Where(s => s.UserId == id));  // Xóa các mục yêu thích
        _context.Orders.RemoveRange(_context.Orders.Where(s => s.UserId == id));  // Xóa các đơn hàng
        _context.Comments.RemoveRange(_context.Comments.Where(s => s.UserId == id));  // Xóa các bình luận
        _context.Notifications.RemoveRange(_context.Notifications.Where(s => s.UserId == id));  // Xóa các thông báo

        // Xóa người dùng khỏi bảng Users
        _dbSet.Remove(user);  
        await _context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return true;  // Trả về true nếu xóa thành công
    }

    // Lấy danh sách tất cả người dùng
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbSet
            .Select(user => new User  // Chọn thông tin người dùng cần thiết
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
                Role = user.Role != null ? new Role  // Nếu có role, lấy thông tin role
                {
                    Id = user.Role.Id,
                    Name = user.Role.Name
                } : null
            })
            .ToListAsync();  // Trả về danh sách người dùng
    }

    // Lấy thông tin một người dùng theo ID
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Where(user => user.Id == id)  // Tìm người dùng theo ID
            .Include(user => user.Orders!).ThenInclude(order => order.OrderItems!)  // Bao gồm thông tin đơn hàng và các mục trong đơn hàng
            .Include(user => user.WishlistItems!)  // Bao gồm danh sách các mục yêu thích
            .Include(user => user.Role)  // Bao gồm thông tin vai trò
            .FirstOrDefaultAsync();  // Trả về người dùng đầu tiên hoặc null nếu không có
    }

    // Cập nhật thông tin của một người dùng
    public async Task UpdateAsync(User entity, Guid? userId = null)
    {
        _dbSet.Update(entity);  // Cập nhật thông tin người dùng trong DbSet
        await _context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
    }
}
