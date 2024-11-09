using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;

public class ChatMessageRepository : IChatMessageRepository
{
    private readonly ShUEHContext _context;  // Đối tượng DbContext để tương tác với cơ sở dữ liệu

    // Constructor nhận vào ShUEHContext để sử dụng cho các truy vấn cơ sở dữ liệu
    public ChatMessageRepository(ShUEHContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Thêm một tin nhắn vào cơ sở dữ liệu.
    /// </summary>
    public async Task AddAsync(ChatMessage message)
    {
        _context.ChatMessages.Add(message);  // Thêm tin nhắn vào DbSet ChatMessages
        await _context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
    }

    /// <summary>
    /// Lấy danh sách tin nhắn cho người dùng theo phân trang.
    /// </summary>
    public async Task<IEnumerable<ChatMessage>?> GetMessagesForUserAsync(Guid userId, int page, int pageSize)
    {
        // Lọc tin nhắn giữa người dùng và Admin (hoặc Admin với người dùng)
        var messages = await _context.ChatMessages
            .Where(m => (m.FromUserId == userId.ToString() && m.ToUserId == "AdminGroup") ||  // Tin nhắn từ người dùng gửi đến Admin
                        (m.FromUserId == "AdminGroup" && m.ToUserId == userId.ToString()))  // Tin nhắn từ Admin gửi đến người dùng
            .OrderByDescending(m => m.Timestamp)  // Sắp xếp theo thời gian tin nhắn (mới nhất trước)
            .Skip((page - 1) * pageSize)  // Bỏ qua các tin nhắn của các trang trước (phân trang)
            .Take(pageSize)  // Lấy số lượng tin nhắn theo pageSize
            .ToListAsync();  // Chuyển kết quả thành danh sách
        return messages;
    }

    /// <summary>
    /// Lấy danh sách tin nhắn của người dùng theo phân trang.
    /// </summary>
    public async Task<List<ChatMessage>> GetMessagesByUserIdAsync(Guid userId, int page, int pageSize)
    {
        // Lọc tất cả tin nhắn mà người dùng tham gia (từ người dùng hoặc gửi đến người dùng)
        return await _context.ChatMessages
                            .Where(m => m.ToUserId == userId.ToString() || m.FromUserId == userId.ToString())  // Tin nhắn gửi đi hoặc nhận về
                            .OrderByDescending(m => m.Timestamp)  // Sắp xếp theo thời gian giảm dần
                            .Skip((page - 1) * pageSize)  // Phân trang, bỏ qua tin nhắn của các trang trước
                            .Take(pageSize)  // Lấy số tin nhắn cho trang hiện tại
                            .ToListAsync();  // Chuyển thành danh sách
    }

    /// <summary>
    /// Lấy danh sách tin nhắn của Admin theo phân trang.
    /// </summary>
    public async Task<List<ChatMessage>> GetMessagesForAdminAsync(int page, int pageSize)
    {
        // Lọc tin nhắn mà Admin tham gia (Admin gửi và nhận tin nhắn)
        var messages = await _context.ChatMessages
                                    .Where(m => m.ToUserId == "AdminGroup" || m.FromUserId == "AdminGroup")  // Tin nhắn liên quan đến Admin
                                    .OrderByDescending(m => m.Timestamp)  // Sắp xếp theo thời gian giảm dần
                                    .Skip((page - 1) * pageSize)  // Bỏ qua tin nhắn của các trang trước
                                    .Take(pageSize)  // Lấy số tin nhắn cho trang hiện tại
                                    .ToListAsync();  // Chuyển kết quả thành danh sách

        return messages;
    }
}
