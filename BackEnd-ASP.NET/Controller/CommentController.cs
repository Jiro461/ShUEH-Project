using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BackEnd_ASP.NET.Services.VnPay;
using Microsoft.AspNetCore.Cors;
using BackEnd_ASP.NET.Services;
using System.Security.Claims;
using BackEnd_ASP_NET.Models;
using System.Net;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;
namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly ShUEHContext _context;

        public CommentController(ICommentService commentService, ShUEHContext context)
        {
            _commentService = commentService;
            _context = context;
        }
        [HttpPost("reply")]
        public async Task<IActionResult> AddReplyAsync(ReplyDTO replyDTO)
        {
            return await _commentService.AddReplyAsync(replyDTO, HttpContext);
        }
        [HttpDelete("reply/{id}")]
        public async Task<IActionResult> DeleteReplyAsync(Guid id)
        {
            return await _commentService.DeleteReplyAsync(id, HttpContext);
        }
        [HttpGet("home")]
        public async Task<IActionResult> GetHomeCommentsAsync()
        {
            var comments = await _context.Comments.Where(c => c.Rate >= 4.5M).Include(c => c.User).Include(c => c.Shoe).ToListAsync();
            var response = comments.Select(comment => new
            {
                userName = comment.User!.UserName,
                userAvatar = comment.User!.AvatarUrl,
                Description = comment.Description,
                Rate = comment.Rate,
                ShoeName = comment.Shoe!.Name
            }).ToList();
            return Ok(response);
        }
        [HttpPut("reply")]
        public async Task<IActionResult> UpdateReplyAsync(ReplyDTO replyDTO)
        {
            return await _commentService.UpdateReplyAsync(replyDTO, HttpContext);
        }
        [HttpGet("all/{shoeId}")]
        public async Task<IActionResult> GetAllCommentsAsync(Guid shoeId)
        {
            return await _commentService.GetAllCommentsAsync(shoeId, HttpContext);
        }
        [HttpPost]
        public async Task<IActionResult> AddCommentAsync([FromForm] CommentPostDTO commentDTO)
        {
            return await _commentService.AddCommentAsync(commentDTO, HttpContext);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentAsync(Guid id)
        {
            return await _commentService.DeleteCommentAsync(id, HttpContext);
        }
        [HttpPost("like")]
        public async Task<IActionResult> ToggleLikeCommentAsync(CommentLikeDTO commentLikeDTO)
        {
            return await _commentService.ToggleLikeCommentAsync(commentLikeDTO, HttpContext);
        }

    }
}

