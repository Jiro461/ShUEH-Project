using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services;
using System.Security.Claims;
using Microsoft.Extensions.Caching.Memory;
namespace BackEnd_ASP.NET.Controller.Chat
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatMessageRepository _chatRepository;
        public const string ChatSessionKey = "ChatSessionKey";
        private readonly IMemoryCache _cache;
        private readonly ILogger<ChatController> _logger;

        public ChatController(IChatMessageRepository chatRepository, IMemoryCache cache, ILogger<ChatController> logger)
        {
            _chatRepository = chatRepository;
            _cache = cache;
            _logger = logger;
        }
        [HttpGet("user/{page}/{pageSize}")]
        public async Task<IActionResult> GetMessagesForUserAsync(int page, int pageSize)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? _cache.Get<Guid>(ChatSessionKey).ToString();
            _logger.LogInformation("User ID: {userId}", userId);
            if (string.IsNullOrEmpty(userId)) return Ok(new List<ChatMessage>());

            var messages = await _chatRepository.GetMessagesByUserIdAsync(Guid.Parse(userId), page, pageSize);
            if (messages == null || !messages.Any()) return Ok(new List<ChatMessage>());

            var chatHistory = messages
                .GroupBy(msg => msg.ToUserId == userId ? msg.FromUserId : msg.ToUserId)
                .Select(group => new
                {
                    UserId = group.Key,
                    Messages = group.Select(msg => new
                    {
                        Message = msg.Message,
                        From = msg.FromUserId == "AdminGroup" ? "Admin" : msg.FromUserName,
                        Time = msg.Timestamp.ToString("yyyy-MM-ddTHH:mm:ssZ")
                    }).OrderBy(msg => msg.Time).ToList()
                }).FirstOrDefault();

            return Ok(chatHistory);
        }
        [HttpGet("admin/{page}/{pageSize}")]
        public async Task<IActionResult> GetMessagesForAdminAsync(int page, int pageSize)
        {
            var messages = await _chatRepository.GetMessagesForAdminAsync(page, pageSize);
            return Ok(messages);
        }
        [HttpGet("history/{userId}/{page}/{pageSize}")]
        public async Task<IActionResult> GetChatHistory(string userId, int page, int pageSize)
        {
            // Lấy tất cả tin nhắn giữa UserId và Admin từ cơ sở dữ liệu, đã sắp xếp theo thời gian
            var chatMessages = await _chatRepository.GetMessagesByUserIdAsync(Guid.Parse(userId), page, pageSize);

            // Tạo cấu trúc tóm tắt cuộc trò chuyện
            var chatHistory = chatMessages
                .GroupBy(msg => msg.ToUserId == userId ? msg.FromUserId : msg.ToUserId) // Nhóm theo UserId
                .Select(group => new
                {
                    UserId = group.Key,
                    Messages = group.Select(msg => new
                    {
                        Message = msg.Message,
                        From = msg.FromUserId == "AdminGroup" ? "Admin" : msg.FromUserName, // Xác định người gửi (Admin hoặc User)
                        Time = msg.Timestamp.ToString("yyyy-MM-ddTHH:mm:ssZ") // Định dạng lại thời gian
                    }).OrderBy(msg => msg.Time) // Sắp xếp theo thời gian
                    .ToList()
                }).FirstOrDefault();

            // Trả về kết quả dưới dạng JSON
            return Ok(chatHistory);
        }
        [HttpGet("conversations/{page}/{pageSize}")]
        public async Task<IActionResult> GetConversationsSummary(int page, int pageSize)
        {
            // Lấy tất cả tin nhắn giữa Admin và người dùng
            var chatMessages = await _chatRepository.GetMessagesForAdminAsync(page, pageSize);

            // Nhóm theo ToUserId hoặc FromUserId (AdminGroup)
            var conversations = chatMessages
                .GroupBy(msg => msg.ToUserId == "AdminGroup" ? msg.FromUserId : msg.ToUserId) // Nhóm theo UserId
                .Select(group => new
                {
                    UserId = group.Key,
                    LastMessage = group.OrderByDescending(msg => msg.Timestamp).FirstOrDefault(), // Lấy tin nhắn cuối cùng
                    LastMessageContent = group.OrderByDescending(msg => msg.Timestamp).FirstOrDefault()?.Message, // Nội dung tin nhắn cuối cùng
                    LastMessageTime = group.OrderByDescending(msg => msg.Timestamp).FirstOrDefault()?.Timestamp.ToString("yyyy-MM-ddTHH:mm:ssZ") // Thời gian của tin nhắn cuối cùng
                }).ToList();

            // Trả về danh sách cuộc trò chuyện
            return Ok(conversations);
        }
    }
}