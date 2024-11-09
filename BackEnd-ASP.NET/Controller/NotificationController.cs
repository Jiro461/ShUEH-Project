using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services;

namespace BackEnd_ASP.NET.Controller
{
    // Controller xử lý các yêu cầu liên quan đến thông báo cho người dùng và quản trị viên
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        // Dịch vụ xử lý các logic thông báo
        private readonly INotificationService _notificationService;

        // Constructor để khởi tạo dịch vụ
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // API lấy thông báo của người dùng, phân trang
        [HttpGet("user/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetUserNotifications(int pageNumber, int pageSize)
        {
            // Gọi phương thức trong service để lấy thông báo người dùng, phân trang theo pageNumber và pageSize
            return await _notificationService.GetUserNotifications(HttpContext, pageNumber, pageSize);
        }

        // API lấy thông báo của quản trị viên, phân trang
        [HttpGet("admin/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAdminNotifications(int pageNumber, int pageSize)
        {
            // Gọi phương thức trong service để lấy thông báo của quản trị viên, phân trang theo pageNumber và pageSize
            return await _notificationService.GetAdminNotifications(HttpContext, pageNumber, pageSize);
        }

        // API lấy thông báo của người dùng từ phía quản trị viên
        [HttpGet("admin/user/{userId}")]
        public async Task<IActionResult> AdminGetUserNotifications(Guid userId)
        {
            // Gọi phương thức trong service để lấy thông báo của người dùng từ phía quản trị viên
            return await _notificationService.AdminGetUserNotifications(HttpContext, userId);
        }
    }
}
