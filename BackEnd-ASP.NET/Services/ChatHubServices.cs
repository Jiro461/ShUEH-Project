using System.Security.Claims;
using BackEnd_ASP_NET.Models;
using BackEnd_ASP_NET.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using BackEnd_ASP.NET.Data;
using Microsoft.Extensions.Caching.Memory;

namespace BackEnd_ASP.NET.Services
{
    public class ChatHubServices : Hub
    {
        private static readonly Dictionary<string, string> UserConnections = new();
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly ShUEHContext context;
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ChatHubServices> logger;

        public const string ChatSessionKey = "ChatSessionKey";
        public static readonly DateTime Timestamp = DateTime.SpecifyKind(MyDateTime.VietNam.DateTime, DateTimeKind.Utc);



        public ChatHubServices(IChatMessageRepository chatMessageRepository,
        IUserRepository userRepository, ILogger<ChatHubServices> logger, ShUEHContext context, IMemoryCache cache)
        {
            _chatMessageRepository = chatMessageRepository;
            _userRepository = userRepository;
            this.logger = logger;
            this.context = context;
            _cache = cache;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = GetChatId().ToString();

            if (Context.User!.IsInRole("Admin"))
            {
                // Thêm Admin vào nhóm "AdminGroup" để nhận tin nhắn từ người dùng
                await Groups.AddToGroupAsync(Context.ConnectionId, "AdminGroup");
            }
            else
            {
                // Lưu kết nối của người dùng
                UserConnections[userId] = Context.ConnectionId;
            }

            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                UserConnections.Remove(userId);
            }
            return base.OnDisconnectedAsync(exception);
        }
        //Admin send message to user
        public async Task<IActionResult> SendMessageToUser(string userId, string message)
        {
            logger.LogInformation("Sending message to user: {userId}, message: {message}", Context.User!.IsInRole("Admin"), message);
            var user = context.ChatMessages.FirstOrDefault(c => c.FromUserId == userId);
            if (user == null) return new BadRequestResult();
            // Kiểm tra xem admin có gửi không
            if (Context.User!.IsInRole("Admin"))
            {
                logger.LogInformation("Admin send message to user: {userId}, message: {message}", Context.User!.IsInRole("Admin"), message);
                var adminGroup = "AdminGroup"; // Sử dụng "AdminGroup" để đại diện cho tất cả admin

                // Lưu tin nhắn vào database
                var chatMessage = new ChatMessage
                {
                    FromUserId = adminGroup,
                    FromUserName = "Admin",
                    FromUserImage = "images/users/noavatar.png",
                    ToUserId = userId,
                    ToUserName = user!.FromUserName ?? "Guest",
                    ToUserImage = user!.FromUserImage ?? "images/users/noavatar.png",
                    Message = message,
                    Timestamp = Timestamp
                };
                await _chatMessageRepository.AddAsync(chatMessage);

                // Gửi tin nhắn đến user (nếu user đang kết nối)
                if (UserConnections.TryGetValue(userId, out var userConnectionId))
                {
                    await Clients.Client(userConnectionId).SendAsync("ReceiveMessage", "Admin", message);
                }
            }
            return new OkResult();
        }
        //User send message to admin
        public async Task<IActionResult> SendMessageToAdmin(string message)
        {
            var userId = GetChatId();
            User? user = await _userRepository.GetByIdAsync(userId) ?? null;
            logger.LogInformation("Sending message to admin: {userId}, message: {message}", userId, message);

            var chatMessage = new ChatMessage
            {
                FromUserId = userId.ToString(), // Nếu user chưa đăng nhập, coi họ như "Guest"
                FromUserImage = user?.AvatarUrl ?? "images/users/noavatar.png",
                FromUserName = user?.UserName ?? "Guest",
                ToUserId = "AdminGroup",
                ToUserName = "Admin",
                ToUserImage = "images/users/noavatar.png",
                Message = message,
                Timestamp = Timestamp
            };

            await _chatMessageRepository.AddAsync(chatMessage);
            // Gửi tin nhắn đến tất cả admin trong nhóm "AdminGroup"
            await Clients.Group("AdminGroup").SendAsync("ReceiveMessage", user?.UserName ?? "Guest", message);
            return new OkResult();
        }

        private Guid GetChatId()
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                return Guid.Parse(userId);
            }

            // Lấy ChatId từ cache nếu có, nếu không tạo mới
            if (!_cache.TryGetValue(Context.ConnectionId, out Guid chatId))
            {
                chatId = Guid.NewGuid();
                _cache.Set(Context.ConnectionId, chatId);
            }

            return chatId;
        }
    }
}