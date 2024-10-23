using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Utilities.FileHelpers;
using BackEnd_ASP.NET.Models.ShoeDetail;

namespace BackEnd_ASP.NET.Services
{
    public class OrderService : ControllerBase, IOrderService
    {
        private readonly IOrderRepository orderRepository; // Repository để thao tác với dữ liệu giày
        private readonly IUserRepository userRepository;
        private readonly ShUEHContext context; // Context của EF Core
        private readonly INotificationService notificationService;

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository, ShUEHContext context, INotificationService notificationService)
        {
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.context = context;
            this.notificationService = notificationService;
        }
        //User xác nhận đặt hàng
        public async Task<IActionResult> AddOrderAsync(OrderDTO order, Guid userId)
        {
            Guid newOrderId = Guid.NewGuid();
            var user = await context.Users.FindAsync(userId);
            if (user == null) return NotFound("User not found");
            if(order.OrderItems.Count == 0) return BadRequest("Order items is empty"); 
            decimal totalPrice = 0;
            foreach(var orderItem in order.OrderItems)
            {
                if(orderItem == null) return BadRequest("Order items is empty");
                var shoe = await context.Shoes.Where(shoe => shoe.Id == orderItem.ShoeId ).Include(shoe => shoe.shoeDetails).FirstOrDefaultAsync();
                if(shoe == null) return NotFound("Shoe with id " + orderItem.ShoeId + " not found");
                var shoeDetail = shoe.shoeDetails.FirstOrDefault(detail => detail.Size == orderItem.Size);
                if(shoeDetail == null || shoeDetail.Quantity < orderItem.Quantity) return NotFound("ShoeDetail with size " + orderItem.Size + " not found or quantity is not enough");
                shoeDetail.Quantity -= orderItem.Quantity;
                shoe.Sold += orderItem.Quantity;
                if(shoeDetail.Quantity < 0) return BadRequest("ShoeDetail quantity is not enough");
                context.ShoeDetails.Update(shoeDetail);
                context.Shoes.Update(shoe);
                totalPrice += orderItem.TotalPrice;
            }
            await context.SaveChangesAsync();

            var newOrder = new Order
            {
                Id = newOrderId,
                UserId = userId,
                OrderDate = order.OrderDate,
                TotalPrice = totalPrice,
                Status = OrderStatus.Pending,
                OrderItems = order.OrderItems.Select(item => new OrderItem
                {
                    OrderId = newOrderId,
                    ShoeId = item.ShoeId,
                    ShoePrice = item.ShoePrice,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                }).ToList(),
            };
            user.TotalMoney += order.TotalPrice;
            await userRepository.UpdateAsync(user);
            await orderRepository.AddOrderAsync(newOrder);
            await notificationService.CreateNotificationForOrder(newOrder, userId);
            return Ok("Create order successfully");
            
        }

        public async Task<IActionResult> GetOrdersByUserIdAsync(Guid userId)
        {
            var orders = await orderRepository.GetOrdersByUserIdAsync(userId);
            if(orders == null) return NotFound("Orders not found");
            var orderDTOs = orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                UserId = order.UserId,
                OrderItems = order.OrderItems.Select(item => new OrderItemDTO
                {
                    ShoeId = item.ShoeId,
                    ShoePrice = item.ShoePrice,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    ShoeName = item.Shoe?.Name ?? string.Empty,
                    ShoeImage = item.Shoe?.ImageUrl ?? "/noimage.webp",
                    ShoeColorDTO = item.Shoe?.Colors.Select(color => new ShoeColorDTO
                    {
                        Color = color.Color,
                    }).ToList() ?? new List<ShoeColorDTO>(),
                }).ToList(),
            });
            return Ok(orderDTOs);
        }

        public async Task<IActionResult> DeleteOrderAsync(Guid id)
        {
            var order = await orderRepository.GetOrderByIdAsync(id);
            if(order == null) return NotFound("Order not found");
            if(await orderRepository.DeleteOrderAsync(id)) {
                await notificationService.CreateNotificationForEntityDelete(order);
                return Ok("Delete order successfully");
            }
            return BadRequest("Delete order failed");
        }

        public async Task<IActionResult> GetAllOrdersAsync()
        {
            if(await orderRepository.GetAllOrdersAsync() == null) {
                return NotFound("Orders not found");
            }
            return Ok("Get all orders successfully");
        }

        public async Task<IActionResult> GetOrdersByStatusAsync(OrderStatus status)
        {
            if(!Enum.IsDefined(typeof(OrderStatus), status)) return BadRequest("Invalid status");
            var orders = await orderRepository.GetOrdersByStatusAsync(status);
            if(orders == null) return NotFound("Orders not found");
            var orderDTOs = orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                UserId = order.UserId,
                OrderItems = order.OrderItems.Select(item => new OrderItemDTO
                {
                    ShoeId = item.ShoeId,
                    ShoePrice = item.ShoePrice,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    ShoeName = item.Shoe?.Name ?? string.Empty,
                    ShoeImage = item.Shoe?.ImageUrl ?? "/noimage.webp",
                    ShoeColorDTO = item.Shoe?.Colors.Select(color => new ShoeColorDTO
                    {
                        Color = color.Color,
                    }).ToList() ?? new List<ShoeColorDTO>(),
                }).ToList(),
            });
            return Ok(orderDTOs);
        }

        public async Task<IActionResult> GetOrderByIdAsync(Guid id)
        {
            var order = await orderRepository.GetOrderByIdAsync(id);
            if(order == null) return NotFound("Order not found");
            var orderDTO = new OrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                UserId = order.UserId,
                OrderItems = order.OrderItems.Select(item => new OrderItemDTO
                {
                    ShoeId = item.ShoeId,
                    ShoePrice = item.ShoePrice,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    ShoeName = item.Shoe?.Name ?? string.Empty,
                    ShoeImage = item.Shoe?.ImageUrl ?? "/noimage.webp",
                    ShoeColorDTO = item.Shoe?.Colors.Select(color => new ShoeColorDTO
                    {
                        Color = color.Color,
                    }).ToList() ?? new List<ShoeColorDTO>(),
                }).ToList(),
            };
            return Ok(orderDTO);
        }

        public Task<IActionResult> UpdateOrderAsync(Guid orderId, OrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}