using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Utilities.FileHelpers;

namespace BackEnd_ASP.NET.Services
{
    public class OrderService : ControllerBase, IOrderService
    {
        private readonly IOrderRepository orderRepository; // Repository để thao tác với dữ liệu giày
        private readonly ShUEHContext context; // Context của EF Core
        private readonly INotificationService notificationService;

        public OrderService(IOrderRepository orderRepository, ShUEHContext context, INotificationService notificationService)
        {
            this.orderRepository = orderRepository;
            this.context = context;
            this.notificationService = notificationService;
        }

        public async Task<IActionResult> AddOrderAsync(OrderDTO order, Guid userId)
        {
            Guid newOrderId = Guid.NewGuid();
            var newOrder = new Order
            {
                Id = newOrderId,
                UserId = userId,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = OrderStatus.Pending,
                OrderItems = order.OrderItems.Select(item => new OrderItem
                {
                    OrderId = newOrderId,
                    ShoeId = item.ShoeId,
                    Quantity = item.Quantity,
                    UnitPrice = item.ShoePrice,
                    ShoeColor = item.ShoeColor,
                    ShoeSize = item.ShoeSize,
                    TotalPrice = item.TotalPrice,
                }).ToList(),
            };
            await orderRepository.AddOrderAsync(newOrder);
            await notificationService.CreateNotificationForOrder(newOrder, userId);
            return CreatedAtAction(nameof(GetOrderByIdAsync), new { id = newOrder.Id }, newOrder);
        }

        public Task<IActionResult> DeleteOrderAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetOrderByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateOrderAsync(Guid orderId, OrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}