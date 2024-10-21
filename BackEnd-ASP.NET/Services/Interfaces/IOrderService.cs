using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ASP.NET.Services
{
    public interface IOrderService
    {
        Task<IActionResult> GetAllOrdersAsync();
        Task<IActionResult> GetOrderByIdAsync(Guid id);
        Task<IActionResult> AddOrderAsync(OrderDTO order, Guid userId);
        Task<IActionResult> UpdateOrderAsync(Guid orderId, OrderDTO order);
        Task<IActionResult> DeleteOrderAsync(Guid id);
    }
}
