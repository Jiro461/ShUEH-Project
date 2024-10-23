using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);
    Task<Order?> GetOrderByIdAsync(Guid? id);
    Task<Order> AddOrderAsync(Order order);
    Task<Order> UpdateOrderAsync(Order order);
    Task<bool> DeleteOrderAsync(Guid id);
}

