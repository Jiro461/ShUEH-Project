using BackEnd_ASP.NET.Models.User;
using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_ASP.NET.Services
{
    public interface ICommentService
    {
        #region Reply
        Task<IActionResult> AddReplyAsync(ReplyDTO replyDTO, HttpContext httpContext);
        Task<IActionResult> DeleteReplyAsync(Guid id, HttpContext httpContext);
        Task<IActionResult> UpdateReplyAsync(ReplyDTO replyDTO, HttpContext httpContext);
        #endregion

        #region Comment
        Task<IActionResult> GetAllCommentsAsync(Guid shoeId);
        Task<IActionResult> AddCommentAsync(CommentDTO commentDTO, HttpContext httpContext);
        Task<IActionResult> DeleteCommentAsync(Guid id, HttpContext httpContext);
        #endregion

        #region Like Comment
        Task<IActionResult> ToggleLikeCommentAsync(CommentLikeDTO commentLikeDTO, HttpContext httpContext);
        #endregion
    }
}