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

    public Task<bool> DeleteOrderAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDTO?> GetOrderByIdAsync(Guid? id)
    {
        throw new NotImplementedException();
    }

    public async Task<Order> UpdateOrderAsync(Order order)
    {
        dbSet.Update(order);
        await context.SaveChangesAsync();
        return order;
    }
}