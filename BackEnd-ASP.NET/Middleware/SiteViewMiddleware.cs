using Microsoft.EntityFrameworkCore;
using DeviceDetectorNET;
using BackEnd_ASP.NET.Data;

namespace BackEnd_ASP_NET.Middleware
{
    public class SiteViewMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public SiteViewMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Kiểm tra nếu request bắt đầu bằng "api/"
            if (context.Request.Path.StartsWithSegments("/api", out _))
            {
                // Lấy địa chỉ IP của người dùng
                var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";

                // Phân tích chuỗi User-Agent để lấy thông tin thiết bị
                var userAgent = context.Request.Headers["User-Agent"].ToString() ?? "Unknown";
                var deviceInfo = GetDeviceType(userAgent);

                // Kiểm tra và lưu bản ghi SiteView mới nếu cần
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ShUEHContext>();
                    await IncrementSiteViewIfNewMonth(dbContext, ipAddress, deviceInfo);
                }
            }

            // Tiếp tục xử lý middleware tiếp theo
            await _next(context);
        }

        private async Task IncrementSiteViewIfNewMonth(ShUEHContext dbContext, string ipAddress, string deviceInfo)
        {
            var currentMonth = DateTime.UtcNow.Date;

            // Kiểm tra nếu đã tồn tại bản ghi cho IP và thiết bị trong tháng này
            var existingSiteView = await dbContext.SiteViews
                .FirstOrDefaultAsync(v => v.Ipaddress == ipAddress &&
                                          v.Device == deviceInfo &&
                                          v.ViewedDate.Month == currentMonth.Month &&
                                          v.ViewedDate.Year == currentMonth.Year);

            // Nếu chưa tồn tại bản ghi trong tháng, tạo mới
            if (existingSiteView == null)
            {
                var siteView = new SiteView
                {
                    Id = Guid.NewGuid(),
                    Ipaddress = ipAddress,
                    Device = deviceInfo,
                    ViewedDate = currentMonth
                };

                dbContext.SiteViews.Add(siteView);
                await dbContext.SaveChangesAsync();
            }
        }

        private string GetDeviceType(string userAgent)
        {
            var deviceDetector = new DeviceDetector(userAgent);
            deviceDetector.Parse();

            // Kiểm tra nếu là bot
            if (deviceDetector.IsBot())
            {
                return "Bot";
            }

            // Kiểm tra loại thiết bị
            if (deviceDetector.IsMobile())
            {
                return "Mobile";
            }
            else if (deviceDetector.IsTablet())
            {
                return "Tablet";
            }
            else if (deviceDetector.IsDesktop())
            {
                // Kiểm tra nếu là laptop
                var client = deviceDetector.GetClient();
                var os = deviceDetector.GetOs();
                // Dựa vào thông tin hệ điều hành và nhà sản xuất để xác định laptop
                if (os.Success && client.Success 
                        && os.Match.Family == "Windows" 
                        && (client.Match.Name == "Dell" 
                        || client.Match.Name == "HP" 
                        || client.Match.Name == "Lenovo"))
                {
                    return "Laptop";
                }
                return "Desktop"; // Nếu không xác định là laptop, trả về desktop
            }

            // Nếu không xác định được
            return "Unknown";
        }
    }
}
