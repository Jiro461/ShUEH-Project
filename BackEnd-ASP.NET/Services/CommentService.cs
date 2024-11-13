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
        // Các phụ thuộc được tiêm qua constructor
        private readonly ICommentRepository commentRepository;
        private readonly IShoeRepository shoeRepository;
        private readonly ShUEHContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly INotificationService notificationService;

        public CommentService(ICommentRepository commentRepository, IShoeRepository shoeRepository,
        INotificationService notificationService, ShUEHContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.commentRepository = commentRepository;
            this.shoeRepository = shoeRepository;
            this.notificationService = notificationService;
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        #region Reply
        // Thêm một phản hồi vào bình luận
        public async Task<IActionResult> AddReplyAsync(ReplyDTO replyDTO, HttpContext httpContext)
        {
            // Lấy ID người dùng và vai trò từ ngữ cảnh HTTP
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userId == null || userRole != "Admin") return Unauthorized();

            // Tạo đối tượng Reply mới
            var reply = new Reply
            {
                Description = replyDTO.Description,
                CommentId = replyDTO.CommentId,
                UserId = Guid.Parse(userId)
            };
            // Thêm phản hồi vào kho lưu trữ
            if (await commentRepository.AddReplyAsync(reply))
                return Ok();
            return BadRequest();
        }

        // Xóa một phản hồi
        public async Task<IActionResult> DeleteReplyAsync(Guid id, HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userId == null || userRole != "Admin") return Unauthorized();
            if (await commentRepository.DeleteReplyAsync(id))
                return Ok();
            return NotFound();
        }

        // Cập nhật một phản hồi
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
        // Chuyển đổi trạng thái thích của bình luận
        public async Task<IActionResult> ToggleLikeCommentAsync(CommentLikeDTO commentLikeDTO, HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            var commentLike = await commentRepository.GetCommentLikeByCommentIdAndUserIdAsync(commentLikeDTO.CommentId, Guid.Parse(userId));
            if (commentLike == null)
            {
                var newCommentLike = new CommentLike
                {
                    CommentId = commentLikeDTO.CommentId,
                    UserId = Guid.Parse(userId)
                };
                await notificationService.CreateNotificationForCommentLike(newCommentLike, Guid.Parse(userId));
                await commentRepository.AddCommentLikeAsync(newCommentLike);
            }
            else
            {
                await commentRepository.DeleteCommentLikeAsync(commentLikeDTO.CommentId, Guid.Parse(userId));
            }
            return Ok();
        }
        #endregion

        #region Comment
        // Lấy tất cả các bình luận cho một sản phẩm
        public async Task<IActionResult> GetAllCommentsAsync(Guid shoeId, HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            var comments = await commentRepository.GetAllCommentsAsync(shoeId);

            if (comments == null) return NotFound();
            var commentDTOs = comments.Select(comment => new CommentGetDTO
            {
                Id = comment.Id,
                GeneralReview = GetGeneralReview(comment.Rate),
                Comment = comment.Description ?? string.Empty,
                Rate = comment.Rate,
                ShoeId = comment.ShoeId,
                UserId = comment.UserId,
                UserName = comment.User?.UserName ?? string.Empty,
                UserAvatar = comment.User?.AvatarUrl ?? "noavatar.png",
                ImageUrl = comment.Image,
                OrderItemId = comment.OrderItemId ?? Guid.Empty,
                Size = comment.OrderItem?.Size ?? 0,
                CreateDate = comment.CreateDate,
                TotalLike = comment.CommentLikes?.Count ?? 0,
                Replies = comment.Replies?.Select(reply => new ReplyDTO
                {
                    Id = reply.Id,
                    Description = reply.Description ?? string.Empty,
                    CreateDate = reply.CreateDate
                }).ToList(),
                IsUserPost = (userId == null) ? false : (userRole == "Admin" ? true : comment.UserId == Guid.Parse(userId))
            }).ToList();
            return Ok(commentDTOs);
        }

        // Thêm một bình luận mới
        public async Task<IActionResult> AddCommentAsync(CommentPostDTO commentDTO, HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            var shoe = await shoeRepository.GetShoeByIdAsync(commentDTO.ShoeId ?? Guid.Empty);
            if (shoe == null) return NotFound();
            var orderItem = await context.OrderItems.FindAsync(commentDTO.OrderItemId);
            if (orderItem == null) return NotFound("Order item not found");
            if (orderItem.IsReviewed) return BadRequest("You have already reviewed this product");
            shoe.AverageRating = ((shoe.AverageRating * shoe.TotalRatings) + commentDTO.Rate) / (shoe.TotalRatings + 1);
            shoe.TotalRatings++;
            var commentId = Guid.NewGuid();
            var comment = new Comment
            {
                Id = commentId,
                Description = commentDTO.Comment,
                GeneralReview = GetGeneralReview(commentDTO.Rate),
                Rate = commentDTO.Rate,
                OrderItemId = orderItem.Id,
                ShoeId = orderItem.ShoeId,
                UserId = Guid.Parse(userId),
                Image = await FileHelper.AddCommentImageAsync(webHostEnvironment, commentId, commentDTO.Image),
                TotalLike = 0,
                CreateDate = MyDateTime.VietNam.DateTime,
                Size = orderItem.Size
            };
            if (await commentRepository.AddCommentAsync(comment))
            {
                if (orderItem != null)
                {
                    orderItem.IsReviewed = true;
                    context.OrderItems.Update(orderItem);
                    await context.SaveChangesAsync();
                }
                await shoeRepository.UpdateShoeAsync(shoe);
                return Ok();
            }
            return BadRequest("Add comment failed");
        }

        // Xóa một bình luận
        public async Task<IActionResult> DeleteCommentAsync(Guid id, HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            var comment = await commentRepository.GetCommentByIdAsync(id);
            if (comment == null) return NotFound();
            var shoe = await shoeRepository.GetShoeByIdAsync(comment.ShoeId ?? Guid.Empty);
            if (shoe == null) return NotFound();
            shoe.AverageRating = ((shoe.AverageRating * shoe.TotalRatings) - comment.Rate) / (shoe.TotalRatings - 1);
            await shoeRepository.UpdateShoeAsync(shoe);
            if (await commentRepository.DeleteCommentAsync(id))
                return Ok("Delete comment successfully");
            return BadRequest("Delete comment failed");
        }
        #endregion

        // Lấy đánh giá tổng quát dựa trên điểm số
        private GeneralReview GetGeneralReview(decimal rate)
        {
            return rate switch
            {
                >= 5 => GeneralReview.VeryGood,
                >= 4 => GeneralReview.Good,
                >= 3 => GeneralReview.Average,
                >= 2 => GeneralReview.Bad,
                _ => GeneralReview.VeryBad
            };
        }
    }
}