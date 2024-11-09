using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;
using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly ShUEHContext context;  // DbContext để tương tác với cơ sở dữ liệu
    private readonly DbSet<Order> dbSet;  // DbSet cho bảng Orders

    public OrderRepository(ShUEHContext context)
    {
        this.context = context;
        dbSet = context.Orders;  // Khởi tạo DbSet từ context
    }

    #region Add Order
    public async Task<Order> AddOrderAsync(Order order)
    {
        await dbSet.AddAsync(order);  // Thêm đơn hàng mới vào DbSet
        await context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return order;
    }
    #endregion

    #region Get Orders
    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId)
    {
        return await dbSet.Where(order => order.UserId == userId)  // Lọc đơn hàng theo UserId
            .Include(order => order.OrderItems!)  // Bao gồm các OrderItems liên quan đến đơn hàng
            .ThenInclude(item => item.Shoe!)  // Bao gồm thông tin về giày trong mỗi OrderItem
            .ThenInclude(shoe => shoe.Colors)  // Bao gồm các màu sắc của giày
            .Include(order => order.User!)  // Bao gồm thông tin về người dùng
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync(int page, int pageSize)
    {
        var orders = await dbSet
            .Include(order => order.OrderItems!)  // Bao gồm các OrderItems
            .ThenInclude(item => item.Shoe!)  // Bao gồm thông tin về giày trong mỗi OrderItem
            .Include(order => order.User!)  // Bao gồm thông tin người dùng
            .ToListAsync();
        
        // Nếu có phân trang, áp dụng phân trang lên kết quả
        if(page != -1 && pageSize != -1)
        {
            return orders.Skip(page * pageSize).Take(pageSize).ToList();
        }

        return orders;
    }

    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        return await dbSet.Where(order => order.Status == status)  // Lọc theo trạng thái đơn hàng
            .Include(order => order.OrderItems!)  // Bao gồm các OrderItems
            .ThenInclude(item => item.Shoe!)  // Bao gồm thông tin giày trong mỗi OrderItem
            .Include(order => order.User!)  // Bao gồm thông tin người dùng
            .ToListAsync();
    }

    public Task<Order?> GetOrderByIdAsync(Guid? id)
    {
        return dbSet.Where(order => order.Id == id)  // Tìm đơn hàng theo ID
            .Include(order => order.OrderItems!)  // Bao gồm các OrderItems
            .ThenInclude(item => item.Shoe!)  // Bao gồm thông tin giày trong mỗi OrderItem
            .Include(order => order.User!)  // Bao gồm thông tin người dùng
            .FirstOrDefaultAsync();  // Trả về đơn hàng đầu tiên tìm thấy hoặc null
    }
    #endregion

    #region Delete Order
    public async Task<bool> DeleteOrderAsync(Guid id)
    {
        var order = await dbSet.FindAsync(id);  // Tìm đơn hàng theo ID
        if (order == null) return false;  // Nếu không tìm thấy đơn hàng, trả về false

        context.OrderItems.RemoveRange(context.OrderItems.Where(od => od.OrderId == id));  // Xóa các OrderItems liên quan
        dbSet.Remove(order);  // Xóa đơn hàng khỏi DbSet
        await context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return true;
    }
    #endregion

    #region Update Order
    public async Task<Order> UpdateOrderAsync(Order order)
    {
        dbSet.Update(order);  // Cập nhật đơn hàng trong DbSet
        await context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return order;
    }
    #endregion
}
