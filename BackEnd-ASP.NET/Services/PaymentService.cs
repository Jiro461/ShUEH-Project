using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ASP.NET.Services
{
    public class PaymentService :  ControllerBase, IPaymentService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ShUEHContext context;
        private readonly INotificationService notificationService;
        public PaymentService(IOrderRepository orderRepository, ShUEHContext context, INotificationService notificationService)
        {
            this.orderRepository = orderRepository;
            this.context = context;
            this.notificationService = notificationService;
        }

    
        public async Task<IActionResult> HandleSuccessfulPaymentAsync(Guid orderId)
        {
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            if (order == null || order.Status != OrderStatus.Pending)
                return NotFound("Order not found or not in pending state.");
            if(order.IsUsingDiscount)
            {
                var discount = await context.Discounts.FindAsync(order.DiscountId);
                if(discount == null) return NotFound("Discount not found");
                discount.Quantity -= 1;
                if (discount.Quantity == 0)
                {

                    return await HandleFailedPaymentAsync(orderId, true);
                }
                context.Discounts.Update(discount);
            }
            //Giảm số lượng sản phẩm trong kho
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

            await notificationService.CreateNotificationForOrder(order, order.UserId);
            return Ok("Order confirmed and inventory updated.");
        }

        public async Task<IActionResult> HandleFailedPaymentAsync(Guid orderId, bool isOutOfStock = false)
        {
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            if (order == null || order.Status != OrderStatus.Pending)
                return NotFound("Order not found or not in pending state.");

            // Hủy đơn hàng và không giảm tồn kho
            await orderRepository.DeleteOrderAsync(order.Id);

            await context.SaveChangesAsync();
            if(isOutOfStock) return BadRequest("Discount is out of stock");
            return Ok("Order cancelled due to failed payment.");
        }
    }

}
