using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;

public interface ICommentRepository
{
    Task<IEnumerable<CommentDTO>> GetAllCommentsAsync();
    Task<Comment> GetCommentByIdAsync(Guid? id);
    Task<Comment> AddCommentAsync(Comment comment);
    Task<bool> DeleteCommentAsync(Guid id);
}

