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
        private readonly RequestDelegate _next;  // Chứa delegate tiếp theo trong pipeline của middleware
        private readonly IServiceProvider _serviceProvider; // Cung cấp dịch vụ cho middleware

        // Constructor nhận vào next middleware và service provider
        public ProductViewMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;  // Khởi tạo next middleware
            _serviceProvider = serviceProvider; // Khởi tạo service provider
        }

        // Phương thức xử lý chính của middleware
        public async Task InvokeAsync(HttpContext context)
        {
            // Kiểm tra nếu là request GET và yêu cầu chi tiết sản phẩm (API /api/shoe)
            if (context.Request.Method == HttpMethods.Get &&
                context.Request.Path.StartsWithSegments("/api/shoe", out var remaining))
            {
                // Kiểm tra xem có phải productId hợp lệ không
                if (Guid.TryParse(remaining!.Value?.Trim('/'), out Guid productId))
                {
                    Guid userId = Guid.Empty;  // Khởi tạo userId mặc định
                    var authenticated = await context.AuthenticateAsync("Cookies"); // Xác thực thông tin user từ cookie
                    if (authenticated.Succeeded)
                    {
                        // Lấy userId từ claim trong cookie nếu đã xác thực thành công
                        string? userIdFromClaims = authenticated!.Principal!.Claims!.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                        userId = Guid.Parse(string.IsNullOrEmpty(userIdFromClaims) ? Guid.Empty.ToString() : userIdFromClaims);

                        // Nếu userId không hợp lệ, tạo mới userId và lưu vào session
                        if (userId == Guid.Empty)
                        {
                            userId = Guid.NewGuid();
                            context.Session.SetString("UserId", userId.ToString());
                        }
                    }
                    else
                    {
                        // Nếu không xác thực, lấy userId từ session hoặc tạo mới
                        string? userIdFromSession = context.Session.GetString("UserId");
                        userId = Guid.Parse(string.IsNullOrEmpty(userIdFromSession) ? Guid.NewGuid().ToString() : userIdFromSession);
                        context.Session.SetString("UserId", userId.ToString());
                    }

                    // Tạo scope để sử dụng các dịch vụ trong dependency injection
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<ShUEHContext>(); // Lấy DbContext từ service provider
                        await IncrementViewCountIfNotViewedToday(dbContext, productId, userId); // Tăng số lượt xem cho sản phẩm nếu chưa xem hôm nay
                    }
                }
            }

            // Chuyển tiếp request đến middleware tiếp theo trong pipeline
            await _next(context);
        }

        // Phương thức tăng số lượng view cho sản phẩm nếu người dùng chưa xem trong ngày
        private async Task IncrementViewCountIfNotViewedToday(ShUEHContext dbContext, Guid productId, Guid userId)
        {
            var today = DateTime.UtcNow.Date;  // Lấy ngày hiện tại theo giờ UTC
            var user = await dbContext.Users.FindAsync(userId); // Lấy thông tin người dùng từ DbContext

            // Kiểm tra nếu người dùng chưa xem sản phẩm hôm nay (dựa trên ngày xem và userId)
            var productView = await dbContext.ProductViews
                .FirstOrDefaultAsync(v => v.ProductId == productId &&
                                          (v.UserId == userId));

            // Nếu chưa xem hoặc xem từ tháng khác, thêm bản ghi mới cho lần xem này
            if (productView == null || productView.ViewedDate.Month < today.Month)
            {
                productView = new ProductView
                {
                    ProductId = productId, // Gán productId cho bản ghi view
                    UserId = userId, // Gán userId cho bản ghi view
                    ViewedDate = today // Gán ngày hôm nay cho ViewedDate
                };
                dbContext.ProductViews.Add(productView); // Thêm bản ghi vào DbContext

                // Thêm thông báo cho người dùng khi họ xem sản phẩm
                if (user != null)
                {
                    var shoe = await dbContext.Shoes.FindAsync(productId); // Lấy thông tin sản phẩm
                    dbContext.Notifications.Add(new Notification
                    {
                        UserMessage = $"Bạn đã xem sản phẩm {shoe?.Name}.", // Tin nhắn gửi đến người dùng
                        AdminMessage = $"{user?.UserName} đã xem sản phẩm {shoe?.Name}.", // Tin nhắn gửi đến admin
                        User = user, // Gán thông tin người dùng
                        Product = shoe, // Gán thông tin sản phẩm
                        CreateDate = MyDateTime.VietNam.DateTime // Thời gian tạo thông báo
                    });
                }
            }

            // Tăng số lượng view của sản phẩm
            var product = await dbContext.Shoes.FindAsync(productId); 
            if (product != null)
            {
                product.ViewCount++;  // Tăng view count
                dbContext.Shoes.Update(product); // Cập nhật lại sản phẩm trong DbContext
            }

            await dbContext.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
        }
    }
}
