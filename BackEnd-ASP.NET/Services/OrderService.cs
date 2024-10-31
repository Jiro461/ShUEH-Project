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
        private readonly IPaymentService paymentService;
        private readonly ShUEHContext context; // Context của EF Core
        private readonly INotificationService notificationService;

        public OrderService(IOrderRepository orderRepository, 
            IUserRepository userRepository, 
            ShUEHContext context, 
            INotificationService notificationService,
            IPaymentService paymentService)
        {
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.context = context;
            this.notificationService = notificationService;
            this.paymentService = paymentService;
        }
        //User xác nhận đặt hàng
        public async Task<IActionResult> AddOrderAsync(OrderPostDTO order, Guid userId)
        {
            var user = await context.Users.FindAsync(userId);
            if (user == null) return NotFound("User not found");
            if (order.OrderItems.Count == 0) return BadRequest("Order items are empty");
            
            decimal totalPrice = order.OrderItems.Sum(item => item.TotalPrice);
            var orderId = Guid.NewGuid();
            //Tạo đơn hàng mới
            var newOrder = new Order
            {
                Id = orderId,
                UserId = userId,
                OrderDate = order.OrderDate,
                TotalPrice = totalPrice,
                Status = OrderStatus.Pending,
                PaymentMethod = order.PaymentMethod,
                OrderItems = order.OrderItems.Select(item => new OrderItem
                {
                    ShoeId = item.ShoeId,
                    ShoePrice = item.ShoePrice,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice
                }).ToList(),
            };
            await orderRepository.AddOrderAsync(newOrder);
            if (order.PaymentMethod == PaymentMethod.Cash) 
                await paymentService.HandleSuccessfulPaymentAsync(newOrder.Id);
        
            return Ok(new { orderId = orderId, Message = "Create order successfully" });
        }

        public async Task<IActionResult> GetOrdersByUserIdAsync(Guid userId)
        {
            var orders = await orderRepository.GetOrdersByUserIdAsync(userId);
            if (orders == null) return NotFound("Orders not found");
            var orderDTOs = orders.Select(order => new OrderGetDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                PaymentMethod = order.PaymentMethod,
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
            if (order == null) return NotFound("Order not found");
            if (await orderRepository.DeleteOrderAsync(id))
            {
                await notificationService.CreateNotificationForEntityDelete(order);
                return Ok("Delete order successfully");
            }
            return BadRequest("Delete order failed");
        }

        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders = await orderRepository.GetAllOrdersAsync();
            if (orders == null) return NotFound("Orders not found");
            var orderDTOs = orders.Select(order => new OrderGetDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                UserId = order.UserId,
                UserName = order.User?.UserName ?? string.Empty,
                UserEmail = order.User?.Email ?? string.Empty,
                ImageUrl = order.User?.AvatarUrl ?? "/noavatar.png",
                Status = order.Status,
                PaymentMethod = order.PaymentMethod,
                TotalPrice = order.TotalPrice,
                TotalItems = order.OrderItems.Sum(item => item.Quantity),
            });

            var response = new {
                OrderDTOs = orderDTOs,
                Total = orderDTOs.Count()
            };
            return Ok(response);
        }

        public async Task<IActionResult> GetOrdersByStatusAsync(OrderStatus status)
        {
            if (!Enum.IsDefined(typeof(OrderStatus), status)) return BadRequest("Invalid status");
            var orders = await orderRepository.GetOrdersByStatusAsync(status);
            if (orders == null) return NotFound("Orders not found");
            var orderDTOs = orders.Select(order => new OrderGetDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                PaymentMethod = order.PaymentMethod,
                UserId = order.UserId,
                UserName = order.User?.UserName ?? string.Empty,
                UserEmail = order.User?.Email ?? string.Empty,
                ImageUrl = order.User?.AvatarUrl ?? "/noavatar.png",
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
            if (order == null) return NotFound("Order not found");
            var orderDTO = new OrderGetDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                PaymentMethod = order.PaymentMethod,
                UserId = order.UserId,
                UserName = order.User?.UserName ?? string.Empty,
                UserEmail = order.User?.Email ?? string.Empty,
                ImageUrl = order.User?.AvatarUrl ?? "/noavatar.png",
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

        public async Task<IActionResult> UpdateOrderAsync(Guid orderId, OrderStatus status)
        {
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) return NotFound("Order not found");
            order.Status = status;
            await orderRepository.UpdateOrderAsync(order);
            await notificationService.CreateUpdateNotificationForEntityChange(order);
            return Ok("Update order successfully");
        }

        
    }
}