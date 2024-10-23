using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;

public interface IOrderRepository
{
    Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
    Task<OrderDTO?> GetOrderByIdAsync(Guid? id);
    Task<Order> AddOrderAsync(Order order);
    Task<Order> UpdateOrderAsync(Order order);
    Task<bool> DeleteOrderAsync(Guid id);
}

