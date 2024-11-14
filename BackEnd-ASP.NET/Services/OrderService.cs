using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;

namespace BackEnd_ASP.NET.Services
{
    // Lớp dịch vụ đơn hàng, kế thừa từ ControllerBase và triển khai IOrderService
    public class OrderService : ControllerBase, IOrderService
    {
        // Khai báo các biến thành viên cho các repository và dịch vụ cần thiết
        private readonly IOrderRepository orderRepository; // Repository để thao tác với dữ liệu đơn hàng
        private readonly IUserRepository userRepository;
        private readonly IPaymentService paymentService;
        private readonly ShUEHContext context; // Context của EF Core
        private readonly INotificationService notificationService;

        // Hàm khởi tạo, nhận vào các đối tượng cần thiết
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

        // Phương thức thêm đơn hàng mới
        public async Task<Tuple<Guid, string>> AddOrderAsync(OrderPostDTO order, Guid userId)
        {
            // Tìm người dùng theo userId
            var user = await context.Users.FindAsync(userId);
            if (user == null) return Tuple.Create(Guid.Empty, "User not found");
            if (order.OrderItems.Count == 0) return Tuple.Create(Guid.Empty, "Order items are empty");

            // Tính tổng giá của đơn hàng
            decimal totalPrice = order.OrderItems.Sum(item => item.TotalPrice);
            var orderId = Guid.NewGuid();

            // Tạo đối tượng Order mới
            var newOrder = new Order
            {
                Id = orderId,
                UserId = userId,
                OrderDate = order.OrderDate,
                TotalPrice = totalPrice,
                Status = OrderStatus.Pending,
                PaymentMethod = order.PaymentMethod,
                DetailOrder = order.DetailOrder,
                OrderItems = order.OrderItems.Select(item => new OrderItem
                {
                    ShoeId = item.ShoeId,
                    ShoePrice = item.ShoePrice,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice
                }).ToList(),
            };

            // Thêm đơn hàng vào repository
            await orderRepository.AddOrderAsync(newOrder);

            // Xử lý thanh toán nếu phương thức là tiền mặt
            if (order.PaymentMethod == PaymentMethod.Cash)
                await paymentService.HandleSuccessfulPaymentAsync(newOrder.Id);

            return Tuple.Create(orderId, "Create order successfully");
        }

        // Phương thức lấy đơn hàng theo userId
        public async Task<IActionResult> GetOrdersByUserIdAsync(Guid userId)
        {
            // Lấy danh sách đơn hàng từ repository
            var orders = await orderRepository.GetOrdersByUserIdAsync(userId);
            if (orders == null) return NotFound("Orders not found");

            // Chuyển đổi danh sách Order thành OrderDTO
            var orderDTOs = orders.Select(MapOrderToDTO);
            return Ok(orderDTOs);
        }

        // Phương thức xóa đơn hàng theo ID
        public async Task<IActionResult> DeleteOrderAsync(Guid id)
        {
            // Tìm đơn hàng theo ID
            var order = await orderRepository.GetOrderByIdAsync(id);
            if (order == null) return NotFound("Order not found");

            // Xóa đơn hàng từ repository
            if (await orderRepository.DeleteOrderAsync(id))
            {
                // Tạo thông báo cho việc xóa đơn hàng
                await notificationService.CreateNotificationForEntityDelete(order);
                return Ok("Delete order successfully");
            }
            return BadRequest("Delete order failed");
        }

        // Phương thức lấy tất cả đơn hàng với phân trang
        public async Task<IActionResult> GetAllOrdersAsync(int page, int pageSize)
        {
            // Lấy danh sách đơn hàng từ repository
            var orders = await orderRepository.GetAllOrdersAsync(page, pageSize);
            if (orders == null) return NotFound("Orders not found");

            // Chuyển đổi danh sách Order thành OrderDTO
            var orderDTOs = orders.Select(MapOrderToDTO);
            var response = new
            {
                OrderDTOs = orderDTOs,
                Total = orderDTOs.Count()
            };
            return Ok(response);
        }

        // Phương thức lấy đơn hàng theo trạng thái
        public async Task<IActionResult> GetOrdersByStatusAsync(OrderStatus status)
        {
            // Kiểm tra trạng thái hợp lệ
            if (!Enum.IsDefined(typeof(OrderStatus), status)) return BadRequest("Invalid status");

            // Lấy danh sách đơn hàng từ repository
            var orders = await orderRepository.GetOrdersByStatusAsync(status);
            if (orders == null) return NotFound("Orders not found");

            // Chuyển đổi danh sách Order thành OrderDTO
            var orderDTOs = orders.Select(MapOrderToDTO);
            return Ok(orderDTOs);
        }

        // Phương thức lấy đơn hàng theo ID
        public async Task<IActionResult> GetOrderByIdAsync(Guid id)
        {
            // Tìm đơn hàng theo ID
            var order = await orderRepository.GetOrderByIdAsync(id);
            if (order == null) return NotFound("Order not found");

            // Chuyển đổi Order thành OrderDTO
            var orderDTO = MapOrderToDTO(order);
            return Ok(orderDTO);
        }

        // Phương thức cập nhật trạng thái đơn hàng
        public async Task<IActionResult> UpdateOrderAsync(Guid orderId, OrderStatus status)
        {
            // Tìm đơn hàng theo ID
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) return NotFound("Order not found");

            // Cập nhật trạng thái đơn hàng
            order.Status = status;
            await orderRepository.UpdateOrderAsync(order);

            // Tạo thông báo cho việc cập nhật đơn hàng
            await notificationService.CreateUpdateNotificationForEntityChange(order);
            return Ok("Update order successfully");
        }

        // Phương thức chuyển đổi từ Order sang OrderGetDTO
        private OrderGetDTO MapOrderToDTO(Order order)
        {
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
                DetailOrder = order.DetailOrder,
                OrderItems = order.OrderItems.Select(item => new OrderItemDTO
                {
                    Id = item.Id,
                    ShoeId = item.ShoeId,
                    ShoePrice = item.ShoePrice,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    ShoeName = item.Shoe?.Name ?? string.Empty,
                    ShoeImage = item.Shoe?.ImageUrl ?? "/noimage.webp",
                    IsReviewed = item.IsReviewed
                }).ToList(),
                TotalItems = order.OrderItems.Sum(item => item.Quantity),
            };
            return orderDTO;
        }
    }
}