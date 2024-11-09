public interface IChatMessageRepository
    {
        Task AddAsync(ChatMessage message);
        Task<IEnumerable<ChatMessage>?> GetMessagesForUserAsync(Guid userId, int page, int pageSize);
        Task<List<ChatMessage>> GetMessagesByUserIdAsync(Guid userId, int page, int pageSize);
        Task<List<ChatMessage>> GetMessagesForAdminAsync(int page, int pageSize);
    }