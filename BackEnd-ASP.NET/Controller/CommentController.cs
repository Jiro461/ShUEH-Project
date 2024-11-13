using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Services;
using BackEnd_ASP_NET.Models;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Controllers
{
    // Controller xử lý các chức năng liên quan đến bình luận và trả lời bình luận
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        // Các dịch vụ cần thiết: dịch vụ bình luận và context cho cơ sở dữ liệu
        private readonly ICommentService _commentService;
        private readonly ShUEHContext _context;

        // Constructor để khởi tạo dịch vụ và context
        public CommentController(ICommentService commentService, ShUEHContext context)
        {
            _commentService = commentService;
            _context = context;
        }

        // API để thêm trả lời bình luận (Reply)
        [HttpPost("reply")]
        public async Task<IActionResult> AddReplyAsync(ReplyDTO replyDTO)
        {
            // Gọi phương thức dịch vụ để thêm trả lời bình luận
            return await _commentService.AddReplyAsync(replyDTO, HttpContext);
        }

        // API để xóa trả lời bình luận (Reply)
        [HttpDelete("reply/{id}")]
        public async Task<IActionResult> DeleteReplyAsync(Guid id)
        {
            // Gọi phương thức dịch vụ để xóa trả lời bình luận
            return await _commentService.DeleteReplyAsync(id, HttpContext);
        }

        // API để lấy các bình luận trên trang chủ (những bình luận có đánh giá >= 4.5)
        [HttpGet("home")]
        public async Task<IActionResult> GetHomeCommentsAsync()
        {
            // Lấy các bình luận từ cơ sở dữ liệu có đánh giá >= 4.5 và bao gồm thông tin người dùng và giày
            var comments = await _context.Comments
                .Where(c => c.Rate >= 4.5M)  // Lọc bình luận có đánh giá >= 4.5
                .Include(c => c.User)  // Bao gồm thông tin người dùng
                .Include(c => c.Shoe)  // Bao gồm thông tin giày
                .ToListAsync();

            // Chuyển các bình luận thành định dạng cần thiết để trả về (chỉ lấy các thông tin cần thiết)
            var response = comments.Select(comment => new
            {
                userName = comment.User!.UserName,  // Tên người dùng
                userAvatar = comment.User!.AvatarUrl,  // URL ảnh đại diện của người dùng
                Description = comment.Description,  // Nội dung bình luận
                Rate = comment.Rate,  // Đánh giá
                ShoeName = comment.Shoe!.Name  // Tên giày
            }).ToList();

            // Trả về danh sách bình luận đã được định dạng
            return Ok(response);
        }

        // API để cập nhật trả lời bình luận (Reply)
        [HttpPut("reply")]
        public async Task<IActionResult> UpdateReplyAsync(ReplyDTO replyDTO)
        {
            // Gọi phương thức dịch vụ để cập nhật trả lời bình luận
            return await _commentService.UpdateReplyAsync(replyDTO, HttpContext);
        }

        // API để lấy tất cả bình luận của một đôi giày theo shoeId
        [HttpGet("all/{shoeId}")]
        public async Task<IActionResult> GetAllCommentsAsync(Guid shoeId)
        {
            // Gọi phương thức dịch vụ để lấy tất cả bình luận của một đôi giày
            return await _commentService.GetAllCommentsAsync(shoeId, HttpContext);
        }

        // API để thêm bình luận cho giày
        [HttpPost]
        public async Task<IActionResult> AddCommentAsync([FromForm] CommentPostDTO commentDTO)
        {
            // Gọi phương thức dịch vụ để thêm bình luận cho giày
            return await _commentService.AddCommentAsync(commentDTO, HttpContext);
        }

        // API để xóa bình luận của giày
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentAsync(Guid id)
        {
            // Gọi phương thức dịch vụ để xóa bình luận theo id
            return await _commentService.DeleteCommentAsync(id, HttpContext);
        }

        // API để thích (like) hoặc bỏ thích (unlike) bình luận
        [HttpPost("like")]
        public async Task<IActionResult> ToggleLikeCommentAsync(CommentLikeDTO commentLikeDTO)
        {
            // Gọi phương thức dịch vụ để toggle (like/unlike) bình luận
            return await _commentService.ToggleLikeCommentAsync(commentLikeDTO, HttpContext);
        }
    }
}
