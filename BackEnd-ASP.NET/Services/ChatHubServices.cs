using System.Security.Claims;
using BackEnd_ASP_NET.Models;
using BackEnd_ASP_NET.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
namespace BackEnd_ASP.NET.Services
{
    public class ChatHubServices : Hub
    { 
        private static readonly Dictionary<string, string> UserConnections = new();
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IUserRepository _userRepository;

        public string ChatSessionKey = "ChatSessionKey";


        public ChatHubServices(IChatMessageRepository chatMessageRepository, IUserRepository userRepository)
        {
            _chatMessageRepository = chatMessageRepository;
            _userRepository = userRepository;
        }

        public override Task OnConnectedAsync()
        {
            var userId = GetChatId();
            UserConnections[userId.ToString()] = Context.ConnectionId;
            return base.OnConnectedAsync();
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
            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));
            var adminId = Context.User!.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (adminId == null) return new BadRequestResult();
            var admin = await _userRepository.GetByIdAsync(Guid.Parse(adminId));
            if (admin == null) return new BadRequestResult();
            // Kiểm tra xem admin có gửi không
            if (Context.User!.IsInRole("Admin"))
            {
                var adminGroup = "AdminGroup"; // Sử dụng "AdminGroup" để đại diện cho tất cả admin

                // Lưu tin nhắn vào database
                var chatMessage = new ChatMessage
                {
                    FromUserId = adminGroup,
                    FromUserName = admin.UserName ?? "Unknown",
                    FromUserImage = admin.AvatarUrl ?? "Unknown",
                    ToUserId = userId,
                    ToUserName = user!.UserName ?? "Guest",
                    ToUserImage = user!.AvatarUrl ?? "images/users/noimage.png",
                    Message = message,
                    Timestamp = MyDateTime.VietNam.DateTime
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
            

            var chatMessage = new ChatMessage
            {
                FromUserId = userId.ToString(), // Nếu user chưa đăng nhập, coi họ như "Guest"
                FromUserImage = user?.AvatarUrl ?? "images/users/noimage.png",
                FromUserName = user?.UserName ?? "Guest",
                ToUserId = "AdminGroup",
                ToUserName = "Admin",
                ToUserImage = "images/users/noimage.png",
                Message = message,
                Timestamp = MyDateTime.VietNam.DateTime
            };

            await _chatMessageRepository.AddAsync(chatMessage);
            // Gửi tin nhắn đến tất cả admin trong nhóm "AdminGroup"
            await Clients.Group("AdminGroup").SendAsync("ReceiveMessage", user?.UserName ?? "Guest", message);
            return new OkResult();
        }

        private Guid GetChatId()
        {
            var session = Context.GetHttpContext()?.Session;
            if (session == null) return Guid.NewGuid();
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(userId == null) {
                if(string.IsNullOrEmpty(session.GetString(ChatSessionKey))) {
                    Guid tempChatId = Guid.NewGuid();
                    session.SetString(ChatSessionKey, tempChatId.ToString());
                    return tempChatId;
                }
                return Guid.Parse(session.GetString(ChatSessionKey) ?? Guid.NewGuid().ToString());
            }
            return Guid.Parse(userId);
        }
    }
}