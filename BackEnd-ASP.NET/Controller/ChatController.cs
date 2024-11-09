using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.Caching.Memory;

namespace BackEnd_ASP.NET.Controller.Chat
{
    // API Controller cho chức năng chat
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        // Khai báo các biến cho ChatRepository, Cache và Logger
        private readonly IChatMessageRepository _chatRepository;
        public const string ChatSessionKey = "ChatSessionKey";  // Khóa phiên chat trong bộ nhớ
        private readonly IMemoryCache _cache;
        private readonly ILogger<ChatController> _logger;

        // Constructor để khởi tạo các dịch vụ cần thiết
        public ChatController(IChatMessageRepository chatRepository, IMemoryCache cache, ILogger<ChatController> logger)
        {
            _chatRepository = chatRepository;
            _cache = cache;
            _logger = logger;
        }

        // API để lấy tin nhắn cho người dùng với phân trang
        [HttpGet("user/{page}/{pageSize}")]
        public async Task<IActionResult> GetMessagesForUserAsync(int page, int pageSize)
        {
            // Lấy UserId từ Claims hoặc từ bộ nhớ Cache nếu chưa có trong Claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? _cache.Get<Guid>(ChatSessionKey).ToString();
            _logger.LogInformation("User ID: {userId}", userId);

            // Nếu không có userId, trả về danh sách tin nhắn trống
            if (string.IsNullOrEmpty(userId)) return Ok(new List<ChatMessage>());

            // Lấy danh sách tin nhắn từ repository theo UserId
            var messages = await _chatRepository.GetMessagesByUserIdAsync(Guid.Parse(userId), page, pageSize);

            // Nếu không có tin nhắn nào, trả về danh sách trống
            if (messages == null || !messages.Any()) return Ok(new List<ChatMessage>());

            // Nhóm tin nhắn theo người dùng gửi (admin hoặc người dùng)
            var chatHistory = messages
                .GroupBy(msg => msg.ToUserId == userId ? msg.FromUserId : msg.ToUserId)
                .Select(group => new
                {
                    UserId = group.Key,
                    Messages = group.Select(msg => new
                    {
                        Message = msg.Message,
                        From = msg.FromUserId == "AdminGroup" ? "Admin" : msg.FromUserName,  // Nếu là admin, hiển thị tên là Admin
                        Time = msg.Timestamp.ToString("yyyy-MM-ddTHH:mm:ssZ")  // Định dạng thời gian
                    }).OrderBy(msg => msg.Time).ToList() // Sắp xếp tin nhắn theo thời gian
                }).FirstOrDefault();

            // Trả về dữ liệu cuộc trò chuyện
            return Ok(chatHistory);
        }

        // API để lấy tin nhắn cho admin với phân trang
        [HttpGet("admin/{page}/{pageSize}")]
        public async Task<IActionResult> GetMessagesForAdminAsync(int page, int pageSize)
        {
            // Lấy tất cả tin nhắn cho admin
            var messages = await _chatRepository.GetMessagesForAdminAsync(page, pageSize);
            return Ok(messages);  // Trả về danh sách tin nhắn cho admin
        }

        // API để lấy lịch sử trò chuyện giữa User và Admin, theo userId với phân trang
        [HttpGet("history/{userId}/{page}/{pageSize}")]
        public async Task<IActionResult> GetChatHistory(string userId, int page, int pageSize)
        {
            // Lấy tất cả tin nhắn giữa UserId và Admin từ cơ sở dữ liệu, đã sắp xếp theo thời gian
            var chatMessages = await _chatRepository.GetMessagesByUserIdAsync(Guid.Parse(userId), page, pageSize);

            // Nhóm tin nhắn theo người gửi (admin hoặc người dùng)
            var chatHistory = chatMessages
                .GroupBy(msg => msg.ToUserId == userId ? msg.FromUserId : msg.ToUserId)  // Nhóm theo UserId
                .Select(group => new
                {
                    UserId = group.Key,
                    Messages = group.Select(msg => new
                    {
                        Message = msg.Message,
                        From = msg.FromUserId == "AdminGroup" ? "Admin" : msg.FromUserName,  // Xác định người gửi (Admin hoặc User)
                        Time = msg.Timestamp.ToString("yyyy-MM-ddTHH:mm:ssZ")  // Định dạng lại thời gian
                    }).OrderBy(msg => msg.Time)  // Sắp xếp theo thời gian
                    .ToList()
                }).FirstOrDefault();  // Trả về nhóm đầu tiên (nếu có)

            // Trả về kết quả dưới dạng JSON
            return Ok(chatHistory);
        }

        // API để lấy tóm tắt các cuộc trò chuyện, phân trang theo thời gian
        [HttpGet("conversations/{page}/{pageSize}")]
        public async Task<IActionResult> GetConversationsSummary(int page, int pageSize)
        {
            // Lấy tất cả tin nhắn giữa Admin và người dùng
            var chatMessages = await _chatRepository.GetMessagesForAdminAsync(page, pageSize);

            // Nhóm theo người gửi hoặc người nhận là Admin
            var conversations = chatMessages
                .GroupBy(msg => msg.ToUserId == "AdminGroup" ? msg.FromUserId : msg.ToUserId)  // Nhóm theo UserId
                .Select(group => new
                {
                    UserId = group.Key,
                    LastMessage = group.OrderByDescending(msg => msg.Timestamp).FirstOrDefault(),  // Lấy tin nhắn cuối cùng
                    LastMessageContent = group.OrderByDescending(msg => msg.Timestamp).FirstOrDefault()?.Message,  // Nội dung tin nhắn cuối cùng
                    LastMessageTime = group.OrderByDescending(msg => msg.Timestamp).FirstOrDefault()?.Timestamp.ToString("yyyy-MM-ddTHH:mm:ssZ")  // Thời gian của tin nhắn cuối cùng
                }).ToList();

            // Trả về danh sách các cuộc trò chuyện
            return Ok(conversations);
        }
    }
}
