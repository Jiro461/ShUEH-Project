using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;

public interface ICommentRepository
{
    #region Reply
    Task<Reply?> GetReplyByIdAsync(Guid id);
    Task<bool> AddReplyAsync(Reply reply);
    Task<bool> DeleteReplyAsync(Guid id);
    Task<bool> UpdateReplyAsync(Reply reply);
    #endregion

    #region Comment
    Task<IEnumerable<Comment>> GetAllCommentsAsync(Guid shoeId);
    Task<bool> AddCommentAsync(Comment comment);
    Task<bool> DeleteCommentAsync(Guid id);
    Task<Comment?> GetCommentByIdAsync(Guid id);
    #endregion

    #region Like Comment
    Task<CommentLike?> GetCommentLikeByCommentIdAndUserIdAsync(Guid commentId, Guid userId);
    Task<bool> AddCommentLikeAsync(CommentLike commentLike);
    Task<bool> DeleteCommentLikeAsync(Guid commentId, Guid userId);
    #endregion
}

