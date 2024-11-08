using System.Security.Claims;
using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;
using BackEnd_ASP_NET.Utilities.Extensions;
using Microsoft.AspNetCore.Authentication;
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
                    Guid userId = Guid.Empty;
                    var authenticated = await context.AuthenticateAsync("Cookies");
                    if (authenticated.Succeeded)
                    {
                        string? userIdFromClaims = authenticated!.Principal!.Claims!.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                        userId = Guid.Parse(string.IsNullOrEmpty(userIdFromClaims) ? Guid.Empty.ToString() : userIdFromClaims);
                        if (userId == Guid.Empty)
                        {
                            userId = Guid.NewGuid();
                            context.Session.SetString("UserId", userId.ToString());
                        }
                    }
                    else
                    {
                        string? userIdFromSession = context.Session.GetString("UserId");
                        userId = Guid.Parse(string.IsNullOrEmpty(userIdFromSession) ? Guid.NewGuid().ToString() : userIdFromSession);
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

        private async Task IncrementViewCountIfNotViewedToday(ShUEHContext dbContext, Guid productId, Guid userId)
        {
            var today = DateTime.UtcNow.Date;
            var user = await dbContext.Users.FindAsync(userId);
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
                if (user != null)
                {
                    var shoe = await dbContext.Shoes.FindAsync(productId);
                    dbContext.Notifications.Add(new Notification
                    {
                        UserMessage = $"Bạn đã xem sản phẩm {shoe?.Name}.",
                        AdminMessage = $"{user?.UserName} đã xem sản phẩm {shoe?.Name}.",
                        User = user,
                        Product = shoe,
                        CreateDate = MyDateTime.VietNam.DateTime
                    });
                }
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
