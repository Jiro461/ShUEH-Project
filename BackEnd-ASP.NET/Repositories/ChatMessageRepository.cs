using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;

public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly ShUEHContext _context;

        public ChatMessageRepository(ShUEHContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ChatMessage message)
        {
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChatMessage>?> GetMessagesForUserAsync(Guid userId, int page, int pageSize)
        {
            var messages = await _context.ChatMessages
                .Where(m => (m.FromUserId == userId.ToString() && m.ToUserId == "AdminGroup") ||
                            (m.FromUserId == "AdminGroup" && m.ToUserId == userId.ToString()))
                .OrderByDescending(m => m.Timestamp)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return messages;
        }
        public async Task<List<ChatMessage>> GetMessagesByUserIdAsync(Guid userId, int page, int pageSize)
        {
            return await _context.ChatMessages
                                .Where(m => m.ToUserId == userId.ToString() || m.FromUserId == userId.ToString())
                                .OrderByDescending(m => m.Timestamp) // Sắp xếp theo thời gian giảm dần
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        }
        public async Task<List<ChatMessage>> GetMessagesForAdminAsync(int page, int pageSize)
        {
            // Lấy tất cả các tin nhắn mà người dùng gửi cho Admin hoặc Admin gửi cho người dùng
            var messages = await _context.ChatMessages
                                        .Where(m => m.ToUserId == "AdminGroup" || m.FromUserId == "AdminGroup")
                                        .OrderByDescending(m => m.Timestamp) // Sắp xếp theo thời gian gửi tin nhắn
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();

            return messages;
        }
    }