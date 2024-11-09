using Microsoft.EntityFrameworkCore;
using DeviceDetectorNET;
using BackEnd_ASP.NET.Data;

namespace BackEnd_ASP_NET.Middleware
{
    public class SiteViewMiddleware
    {
        private readonly RequestDelegate _next;  // Delegate cho middleware tiếp theo trong pipeline
        private readonly IServiceProvider _serviceProvider; // Dịch vụ để lấy DbContext trong scope

        // Constructor để khởi tạo middleware với next middleware và service provider
        public SiteViewMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;  // Khởi tạo next middleware
            _serviceProvider = serviceProvider;  // Khởi tạo service provider
        }

        // Phương thức xử lý middleware chính
        public async Task InvokeAsync(HttpContext context)
        {
            // Kiểm tra nếu request là API (bắt đầu bằng "/api")
            if (context.Request.Path.StartsWithSegments("/api", out _))
            {
                // Lấy địa chỉ IP của người dùng
                var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";

                // Lấy thông tin User-Agent để xác định loại thiết bị của người dùng
                var userAgent = context.Request.Headers["User-Agent"].ToString() ?? "Unknown";
                var deviceInfo = GetDeviceType(userAgent);  // Phân tích User-Agent để xác định thiết bị

                // Kiểm tra và lưu bản ghi SiteView mới nếu chưa có trong tháng này
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ShUEHContext>();  // Lấy DbContext từ service provider
                    await IncrementSiteViewIfNewMonth(dbContext, ipAddress, deviceInfo);  // Tăng số lần xem trang nếu chưa có bản ghi trong tháng
                }
            }

            // Chuyển tiếp request đến middleware tiếp theo trong pipeline
            await _next(context);
        }

        // Phương thức tăng số lần xem trang nếu chưa có bản ghi SiteView trong tháng này
        private async Task IncrementSiteViewIfNewMonth(ShUEHContext dbContext, string ipAddress, string deviceInfo)
        {
            var currentMonth = DateTime.UtcNow.Date;  // Lấy ngày hiện tại theo giờ UTC

            // Kiểm tra nếu đã có bản ghi SiteView cho IP và thiết bị trong tháng này
            var existingSiteView = await dbContext.SiteViews
                .FirstOrDefaultAsync(v => v.Ipaddress == ipAddress &&
                                          v.Device == deviceInfo &&
                                          v.ViewedDate.Month == currentMonth.Month &&
                                          v.ViewedDate.Year == currentMonth.Year);

            // Nếu chưa có bản ghi trong tháng này, tạo mới
            if (existingSiteView == null)
            {
                var siteView = new SiteView
                {
                    Id = Guid.NewGuid(),  // Tạo ID mới cho bản ghi
                    Ipaddress = ipAddress,  // Gán địa chỉ IP
                    Device = deviceInfo,  // Gán thông tin thiết bị
                    ViewedDate = currentMonth  // Gán ngày hiện tại làm ngày xem
                };

                dbContext.SiteViews.Add(siteView);  // Thêm bản ghi vào DbContext
                await dbContext.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
            }
        }

        // Phương thức phân tích User-Agent để xác định loại thiết bị của người dùng
        private string GetDeviceType(string userAgent)
        {
            var deviceDetector = new DeviceDetector(userAgent);  // Khởi tạo đối tượng DeviceDetector với chuỗi User-Agent
            deviceDetector.Parse();  // Phân tích chuỗi User-Agent

            // Kiểm tra nếu thiết bị là bot
            if (deviceDetector.IsBot())
            {
                return "Bot";
            }

            // Kiểm tra các loại thiết bị: mobile, tablet, desktop, laptop
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
                var client = deviceDetector.GetClient();  // Lấy thông tin client (nhà sản xuất thiết bị)
                var os = deviceDetector.GetOs();  // Lấy thông tin hệ điều hành của thiết bị

                // Kiểm tra nếu thiết bị là laptop dựa trên hệ điều hành và nhà sản xuất
                if (os.Success && client.Success 
                        && os.Match.Family == "Windows" 
                        && (client.Match.Name == "Dell" 
                        || client.Match.Name == "HP" 
                        || client.Match.Name == "Lenovo"))
                {
                    return "Laptop";  // Nếu thiết bị là laptop
                }

                return "Desktop";  // Nếu không phải laptop, coi như là desktop
            }

            // Nếu không xác định được thiết bị, trả về Unknown
            return "Unknown";
        }
    }
}
