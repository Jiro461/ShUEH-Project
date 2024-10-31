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
namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
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
        [HttpPut("reply")]
        public async Task<IActionResult> UpdateReplyAsync(ReplyDTO replyDTO)
        {
            return await _commentService.UpdateReplyAsync(replyDTO, HttpContext);
        }
        [HttpGet("all/{shoeId}")]
        public async Task<IActionResult> GetAllCommentsAsync(Guid shoeId)
        {
            return await _commentService.GetAllCommentsAsync(shoeId);
        }
        [HttpPost]
        public async Task<IActionResult> AddCommentAsync(CommentDTO commentDTO)
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

