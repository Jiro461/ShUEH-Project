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

        public async Task<IEnumerable<ChatMessage>?> GetMessagesForUserAsync(Guid userId)
        {
            var messages = await _context.ChatMessages
                .Where(m => (m.FromUserId == userId.ToString() && m.ToUserId == "AdminGroup") ||
                            (m.FromUserId == "AdminGroup" && m.ToUserId == userId.ToString()))
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
            return messages;
        }
        public async Task<IEnumerable<ChatMessage>> GetMessagesForAdminAsync()
        {
            return await _context.ChatMessages
                .Where(m => m.ToUserId == "AdminGroup" && m.FromUserId != "AdminGroup")
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }
    }