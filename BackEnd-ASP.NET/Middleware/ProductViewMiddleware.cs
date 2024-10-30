using System.Security.Claims;
using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ASP.NET.Middleware
{
    public class ProductViewMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public ProductViewMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Kiểm tra request có phải là API lấy chi tiết sản phẩm không
            if (context.Request.Method == HttpMethods.Get &&
                context.Request.Path.StartsWithSegments("/api/shoe", out var remaining))
            {
                if (Guid.TryParse(remaining!.Value?.Trim('/'), out Guid productId))
                {
                    Guid userId = context!.User!.Identity!.IsAuthenticated
                        ? Guid.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier)!.Value)
                        : Guid.Parse(context.Session.GetString("UserId") ?? Guid.Empty.ToString());
                    if (userId == Guid.Empty)
                    {
                        userId = Guid.NewGuid();
                        context.Session.SetString("UserId", userId.ToString());
                    }
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<ShUEHContext>();
                        await IncrementViewCountIfNotViewedToday(dbContext, productId, userId);
                    }
                }
            }

            await _next(context);
        }

        private async Task IncrementViewCountIfNotViewedToday(ShUEHContext dbContext, Guid productId, Guid? userId)
        {
            var today = DateTime.UtcNow.Date;

            // Tìm bản ghi ProductView nếu đã xem hôm nay
            var productView = await dbContext.ProductViews
                .FirstOrDefaultAsync(v => v.ProductId == productId &&
                                          (v.UserId == userId));

            if (productView == null || productView.ViewedDate.Month < today.Month)
            {
                productView = new ProductView
                {
                    ProductId = productId,
                    UserId = userId,
                    ViewedDate = today
                };
                dbContext.ProductViews.Add(productView);
            }
            // Tăng view count của sản phẩm
            var product = await dbContext.Shoes.FindAsync(productId);
            if (product != null)
            {
                product.ViewCount++;
                dbContext.Shoes.Update(product);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
