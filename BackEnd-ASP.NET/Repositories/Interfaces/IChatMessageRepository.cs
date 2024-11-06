public interface IChatMessageRepository
    {
        Task AddAsync(ChatMessage message);
        Task<IEnumerable<ChatMessage>?> GetMessagesForUserAsync(Guid userId);
        Task<IEnumerable<ChatMessage>> GetMessagesForAdminAsync();
    }