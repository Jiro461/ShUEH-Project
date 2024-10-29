using BackEnd_ASP.NET.Data;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CommentRepository : ICommentRepository
{
    private readonly ShUEHContext context;
    private readonly DbSet<Comment> dbSet;

    public CommentRepository(ShUEHContext context)
    {
        this.context = context;
        dbSet = context.Comments;
    }
    #region Reply
    public async Task<Reply?> GetReplyByIdAsync(Guid id)
    {
        return await context.Replies.FindAsync(id);
    }
    public async Task<bool> AddReplyAsync(Reply reply)
    {
        await context.Replies.AddAsync(reply);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteReplyAsync(Guid id)
    {
        var reply = await context.Replies.FindAsync(id);
        if (reply == null) return false;
        context.Replies.Remove(reply);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateReplyAsync(Reply reply)
    {
        context.Replies.Update(reply);
        await context.SaveChangesAsync();
        return true;
    }
    #endregion

    #region Comment
    public async Task<bool> AddCommentAsync(Comment comment)
    {
        try
        {
            await dbSet.AddAsync(comment);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<Comment?> GetCommentByIdAsync(Guid id)
    {
        return await dbSet
        .Include(c => c.CommentLikes)
        .Include(c => c.Replies)
        .Include(c => c.User)
        .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> DeleteCommentAsync(Guid id)
    {
        try
        {
            var comment = await dbSet.FindAsync(id);
            if (comment == null) return false;
            var replies = await context.Replies.Where(r => r.CommentId == id).ToListAsync();
            var commentLikes = await context.CommentLikes.Where(cl => cl.CommentId == id).ToListAsync();
            context.Replies.RemoveRange(replies);
            context.CommentLikes.RemoveRange(commentLikes);
            dbSet.Remove(comment);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Comment>> GetAllCommentsAsync(Guid shoeId)
    {
        var comments = await dbSet
        .Include(c => c.Replies)
        .Include(c => c.User)
        .Include(c => c.CommentLikes)
        .Where(c => c.ShoeId == shoeId).ToListAsync();
        return comments;
    }
    #endregion

    #region Like Comment
    public async Task<CommentLike?> GetCommentLikeByCommentIdAndUserIdAsync(Guid commentId, Guid userId)
    {
        return await context.CommentLikes.FirstOrDefaultAsync(cl => cl.CommentId == commentId && cl.UserId == userId);
    }

    public async Task<bool> AddCommentLikeAsync(CommentLike commentLike)
    {
        await context.CommentLikes.AddAsync(commentLike);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCommentLikeAsync(Guid commentId, Guid userId)
    {
        var commentLike = await GetCommentLikeByCommentIdAndUserIdAsync(commentId, userId);
        if (commentLike == null) return false;
        context.CommentLikes.Remove(commentLike);
        await context.SaveChangesAsync();
        return true;
    }
    #endregion
}