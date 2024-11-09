using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ASP.NET.Services
{
    // Lớp dịch vụ thanh toán, kế thừa từ ControllerBase và triển khai IPaymentService
    public class PaymentService : ControllerBase, IPaymentService
    {
        // Khai báo các biến thành viên cho repository và context
        private readonly IOrderRepository orderRepository; // Repository để thao tác với dữ liệu đơn hàng
        private readonly ShUEHContext context; // Context của EF Core
        private readonly INotificationService notificationService; // Dịch vụ thông báo

        // Hàm khởi tạo, nhận vào các đối tượng cần thiết
        public PaymentService(IOrderRepository orderRepository, ShUEHContext context, INotificationService notificationService)
        {
            this.orderRepository = orderRepository;
            this.context = context;
            this.notificationService = notificationService;
        }

        // Phương thức xử lý thanh toán thành công
        public async Task<IActionResult> HandleSuccessfulPaymentAsync(Guid orderId)
        {
            // Tìm đơn hàng theo ID
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            if (order == null || order.Status != OrderStatus.Pending)
                return NotFound("Order not found or not in pending state.");

            // Kiểm tra và xử lý giảm giá nếu có
            if (order.IsUsingDiscount)
            {
                var discount = await context.Discounts.FindAsync(order.DiscountId);
                if (discount == null) return NotFound("Discount not found");
                discount.Quantity -= 1;
                if (discount.Quantity < 0)
                {
                    return await HandleFailedPaymentAsync(orderId, true);
                }
                context.Discounts.Update(discount);
            }

            // Giảm số lượng sản phẩm trong kho
            foreach (var item in order.OrderItems)
            {
                var shoeDetail = await context.ShoeDetails
                    .FirstOrDefaultAsync(detail => detail.ShoeId == item.ShoeId && detail.Size == item.Size);

                if (shoeDetail == null)
                    return NotFound($"Shoe detail with size {item.Size} not found.");

                if (shoeDetail.Quantity < item.Quantity)
                    return BadRequest("Not enough quantity.");

                shoeDetail.Quantity -= item.Quantity;
                context.ShoeDetails.Update(shoeDetail);

                var shoe = await context.Shoes.FindAsync(item.ShoeId);
                if (shoe == null) return NotFound("Shoe not found");
                shoe.Sold += item.Quantity;
                context.Shoes.Update(shoe);
            }

            // Cập nhật trạng thái đơn hàng
            await context.SaveChangesAsync();

            // Tạo thông báo cho đơn hàng
            await notificationService.CreateNotificationForOrder(order, order.UserId);
            return Ok("Order confirmed and inventory updated.");
        }

        // Phương thức xử lý thanh toán thất bại
        public async Task<IActionResult> HandleFailedPaymentAsync(Guid orderId, bool isOutOfStock = false)
        {
            // Tìm đơn hàng theo ID
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            if (order == null || order.Status != OrderStatus.Pending)
                return NotFound("Order not found or not in pending state.");

            // Hủy đơn hàng và không giảm tồn kho
            await orderRepository.DeleteOrderAsync(order.Id);

            await context.SaveChangesAsync();
            if (isOutOfStock) return BadRequest("Discount is out of stock");
            return Ok("Order cancelled due to failed payment.");
        }
    }
}