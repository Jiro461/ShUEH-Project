using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Utilities.FileHelpers;
using BackEnd_ASP.NET.Models.ShoeDetail;
using BackEnd_ASP_NET.Utilities.Extensions;
using System.Security.Claims;
using BackEnd_ASP.NET.Services.VnPay;

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

        public async Task<IActionResult> HandleFailedPaymentAsync(Guid orderId)
        {
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            if (order == null || order.Status != OrderStatus.Pending)
                return NotFound("Order not found or not in pending state.");

            // Hủy đơn hàng và không giảm tồn kho
            await orderRepository.DeleteOrderAsync(order.Id);

            await context.SaveChangesAsync();

            return Ok("Order cancelled due to failed payment.");
        }
    }

}
