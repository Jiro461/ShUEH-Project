using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly ShUEHContext context;
    private readonly DbSet<Order> dbSet;

    public OrderRepository(ShUEHContext context)
    {
        this.context = context;
        dbSet = context.Orders;
    }

    public async Task<Order> AddOrderAsync(Order order)
    {
        await dbSet.AddAsync(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId)
    {
        return await dbSet.Where(order => order.UserId == userId)
        .Include(order => order.OrderItems!)
        .ThenInclude(item => item.Shoe!)
        .ThenInclude(shoe => shoe.Colors)
        .Include(order => order.User!)
        .ToListAsync();
    }
    public async Task<bool> DeleteOrderAsync(Guid id)
    {
        var order = await dbSet.FindAsync(id);
        if(order == null) return false;
        context.OrderItems.RemoveRange(context.OrderItems.Where(od => od.OrderId == id));
        dbSet.Remove(order);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await dbSet
        .Include(order => order.OrderItems!)
        .ThenInclude(item => item.Shoe!)
        .Include(order => order.User!)
        .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        return await dbSet.Where(order => order.Status == status)
        .Include(order => order.OrderItems!)
        .ThenInclude(item => item.Shoe!)
        .Include(order => order.User!)
        .Include(order => order.Status)
        .ToListAsync();
    }
    public Task<Order?> GetOrderByIdAsync(Guid? id)
    {
        return dbSet.Where(order => order.Id == id)
        .Include(order => order.OrderItems!)
        .ThenInclude(item => item.Shoe!)
        .Include(order => order.User!)
        .Include(order => order.Status)
        .FirstOrDefaultAsync();
    }

    public async Task<Order> UpdateOrderAsync(Order order)
    {
        dbSet.Update(order);
        await context.SaveChangesAsync();
        return order;
    }
}