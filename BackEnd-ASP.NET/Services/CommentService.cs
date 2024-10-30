using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd_ASP.NET.Models;
using BackEnd_ASP_NET.Utilities.FileHelpers;
using BackEnd_ASP.NET.Models.ShoeDetail;
using BackEnd_ASP_NET.Utilities.Extensions;
using System.Security.Claims;

namespace BackEnd_ASP.NET.Services
{
    public class CommentService : ControllerBase, ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        #region Reply
        public async Task<IActionResult> AddReplyAsync(ReplyDTO replyDTO, HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userId == null || userRole != "Admin") return Unauthorized();

            var reply = new Reply
            {
                Description = replyDTO.Description,
                CommentId = replyDTO.CommentId,
                UserId = Guid.Parse(userId)
            };
            if (await commentRepository.AddReplyAsync(reply))
                return Ok();
            return BadRequest();
        }

        public async Task<IActionResult> DeleteReplyAsync(Guid id, HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userId == null || userRole != "Admin") return Unauthorized();
            if (await commentRepository.DeleteReplyAsync(id))
                return Ok();
            return NotFound();
        }

        public async Task<IActionResult> UpdateReplyAsync(ReplyDTO replyDTO, HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userId == null || userRole != "Admin") return Unauthorized();
            var reply = await commentRepository.GetReplyByIdAsync(replyDTO.Id ?? Guid.Empty);
            if (reply == null) return NotFound();
            reply.Description = replyDTO.Description;
            if (await commentRepository.UpdateReplyAsync(reply))
                return Ok();
            return BadRequest();
        }
        #endregion

        #region Like Comment
        public async Task<IActionResult> ToggleLikeCommentAsync(CommentLikeDTO commentLikeDTO)
        {
            var commentLike = await commentRepository.GetCommentLikeByCommentIdAndUserIdAsync(commentLikeDTO.CommentId, commentLikeDTO.UserId); 
            if (commentLike == null)
            {
                var newCommentLike = new CommentLike
                {
                    CommentId = commentLikeDTO.CommentId,
                    UserId = commentLikeDTO.UserId
                };
                await commentRepository.AddCommentLikeAsync(newCommentLike);
            }
            else
            {
                await commentRepository.DeleteCommentLikeAsync(commentLikeDTO.CommentId, commentLikeDTO.UserId);
            }
            return Ok();
        }   
        #endregion

        #region Comment
        public async Task<IActionResult> GetAllCommentsAsync(Guid shoeId)
        {
            var comments = await commentRepository.GetAllCommentsAsync(shoeId);
            if (comments == null) return NotFound();
            var commentDTOs = comments.Select(comment => new CommentDTO 
            {
                Id = comment.Id,
                Comment = comment.Description ?? string.Empty,
                Rate = comment.Rate,
                ShoeId = comment.ShoeId ?? Guid.Empty,
                UserId = comment.UserId ?? Guid.Empty,
                UserName = comment.User?.UserName ?? string.Empty,
                UserAvatar = comment.User?.AvatarUrl ?? "noavatar.png",
                CreateDate = comment.CreateDate,
                TotalLike = comment.CommentLikes?.Count ?? 0,
                Replies = comment.Replies?.Select(reply => new ReplyDTO
                {
                    Id = reply.Id,
                    Description = reply.Description ?? string.Empty,
                    CreateDate = reply.CreateDate
                }).ToList()
            }).ToList();
            return Ok(commentDTOs);
        }

        public async Task<IActionResult> AddCommentAsync(CommentDTO commentDTO)
        {
            var comment = new Comment
            {
                Description = commentDTO.Comment,
                Rate = commentDTO.Rate,
                ShoeId = commentDTO.ShoeId,
                UserId = commentDTO.UserId,
                TotalLike = 0,
                CreateDate = MyDateTime.VietNam.DateTime,
            };
            var addedComment = await commentRepository.AddCommentAsync(comment);
            return Ok(addedComment);
        }
        
        public async Task<IActionResult> DeleteCommentAsync(Guid id)
        {
            if (await commentRepository.DeleteCommentAsync(id))
                return Ok();
            return NotFound();
        }
        #endregion
    }
}