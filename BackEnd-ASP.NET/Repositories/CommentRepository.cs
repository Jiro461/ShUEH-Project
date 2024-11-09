using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CommentRepository : ICommentRepository
{
    private readonly ShUEHContext context;  // DbContext để tương tác với cơ sở dữ liệu
    private readonly DbSet<Comment> dbSet;  // Đối tượng DbSet cho Comments (lớp lưu trữ các đối tượng Comment)

    // Constructor nhận vào ShUEHContext để sử dụng cho các thao tác cơ sở dữ liệu
    public CommentRepository(ShUEHContext context)
    {
        this.context = context;
        dbSet = context.Comments;  // Khởi tạo DbSet từ context
    }

    #region Reply

    /// <summary>
    /// Lấy phản hồi (reply) theo ID.
    /// </summary>
    public async Task<Reply?> GetReplyByIdAsync(Guid id)
    {
        return await context.Replies
                    .Include(r => r.Comment)  // Kết hợp thông tin về Comment
                    .ThenInclude(c => c!.Shoe)  // Tiếp tục kết hợp thông tin về giày (shoe) của comment
                    .FirstOrDefaultAsync(r => r.Id == id);  // Lấy phản hồi với ID cụ thể
    }

    /// <summary>
    /// Thêm phản hồi mới cho comment.
    /// </summary>
    public async Task<bool> AddReplyAsync(Reply reply)
    {
        await context.Replies.AddAsync(reply);  // Thêm phản hồi vào DbSet
        await context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return true;
    }

    /// <summary>
    /// Xóa phản hồi theo ID.
    /// </summary>
    public async Task<bool> DeleteReplyAsync(Guid id)
    {
        var reply = await context.Replies.FindAsync(id);  // Tìm phản hồi theo ID
        if (reply == null) return false;  // Nếu không tìm thấy phản hồi, trả về false
        context.Replies.Remove(reply);  // Xóa phản hồi khỏi DbSet
        await context.SaveChangesAsync();  // Lưu thay đổi
        return true;
    }

    /// <summary>
    /// Cập nhật thông tin phản hồi.
    /// </summary>
    public async Task<bool> UpdateReplyAsync(Reply reply)
    {
        context.Replies.Update(reply);  // Cập nhật thông tin phản hồi
        await context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return true;
    }

    #endregion

    #region Comment

    /// <summary>
    /// Thêm một bình luận mới vào cơ sở dữ liệu.
    /// </summary>
    public async Task<bool> AddCommentAsync(Comment comment)
    {
        try
        {
            await dbSet.AddAsync(comment);  // Thêm bình luận vào DbSet
            await context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
            return true;
        }
        catch (Exception)
        {
            return false;  // Nếu xảy ra lỗi, trả về false
        }
    }

    /// <summary>
    /// Lấy thông tin bình luận theo ID.
    /// </summary>
    public async Task<Comment?> GetCommentByIdAsync(Guid id)
    {
        return await dbSet
        .Include(c => c.CommentLikes)  // Kết hợp thông tin về các lượt thích bình luận
        .Include(c => c.Replies)  // Kết hợp thông tin về các phản hồi
        .Include(c => c.User)  // Kết hợp thông tin về người dùng tạo bình luận
        .Include(c => c.OrderItem)  // Kết hợp thông tin về sản phẩm trong đơn hàng
        .FirstOrDefaultAsync(c => c.Id == id);  // Lấy bình luận với ID cụ thể
    }

    /// <summary>
    /// Xóa bình luận và tất cả các phản hồi, lượt thích liên quan.
    /// </summary>
    public async Task<bool> DeleteCommentAsync(Guid id)
    {
        try
        {
            var comment = await dbSet.FindAsync(id);  // Tìm bình luận theo ID
            if (comment == null) return false;  // Nếu không tìm thấy bình luận, trả về false

            var replies = await context.Replies.Where(r => r.CommentId == id).ToListAsync();  // Lấy tất cả các phản hồi liên quan
            var commentLikes = await context.CommentLikes.Where(cl => cl.CommentId == id).ToListAsync();  // Lấy tất cả các lượt thích liên quan

            // Xóa các phản hồi và lượt thích
            context.Replies.RemoveRange(replies);
            context.CommentLikes.RemoveRange(commentLikes);

            dbSet.Remove(comment);  // Xóa bình luận khỏi DbSet
            await context.SaveChangesAsync();  // Lưu thay đổi
            return true;
        }
        catch (Exception)
        {
            return false;  // Nếu xảy ra lỗi, trả về false
        }
    }

    /// <summary>
    /// Lấy tất cả bình luận cho một sản phẩm theo ID giày.
    /// </summary>
    public async Task<IEnumerable<Comment>> GetAllCommentsAsync(Guid shoeId)
    {
        var comments = await dbSet
        .Include(c => c.Replies)  // Kết hợp thông tin về các phản hồi
        .Include(c => c.User)  // Kết hợp thông tin về người dùng tạo bình luận
        .Include(c => c.CommentLikes)  // Kết hợp thông tin về các lượt thích
        .Include(c => c.OrderItem)  // Kết hợp thông tin về sản phẩm trong đơn hàng
        .Where(c => c.ShoeId == shoeId).ToListAsync();  // Lọc bình luận theo ID sản phẩm
        return comments;
    }

    #endregion

    #region Like Comment

    /// <summary>
    /// Lấy thông tin lượt thích của một bình luận từ người dùng theo ID bình luận và người dùng.
    /// </summary>
    public async Task<CommentLike?> GetCommentLikeByCommentIdAndUserIdAsync(Guid commentId, Guid userId)
    {
        return await context.CommentLikes.FirstOrDefaultAsync(cl => cl.CommentId == commentId && cl.UserId == userId);
    }

    /// <summary>
    /// Thêm lượt thích cho một bình luận.
    /// </summary>
    public async Task<bool> AddCommentLikeAsync(CommentLike commentLike)
    {
        await context.CommentLikes.AddAsync(commentLike);  // Thêm lượt thích vào DbSet
        await context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        return true;
    }

    /// <summary>
    /// Xóa lượt thích của một bình luận.
    /// </summary>
    public async Task<bool> DeleteCommentLikeAsync(Guid commentId, Guid userId)
    {
        var commentLike = await GetCommentLikeByCommentIdAndUserIdAsync(commentId, userId);  // Lấy lượt thích của bình luận
        if (commentLike == null) return false;  // Nếu không tìm thấy lượt thích, trả về false
        context.CommentLikes.Remove(commentLike);  // Xóa lượt thích khỏi DbSet
        await context.SaveChangesAsync();  // Lưu thay đổi
        return true;
    }

    #endregion
}
