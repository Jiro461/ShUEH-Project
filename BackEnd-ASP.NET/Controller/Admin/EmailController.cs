using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ASP.NET.Controller.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.To) || string.IsNullOrWhiteSpace(request.Subject) || string.IsNullOrWhiteSpace(request.Body))
            {
                return BadRequest("Invalid email request.");
            }

            await _emailSender.SendEmailAsync(request.To, request.Subject, request.Body);
            return Ok("Email sent successfully.");
        }
    }

    public class EmailRequest
    {
        public string? To { get; set; } //Đến ai
        public string? Subject { get; set; } //Tựa đề
        public string? Body { get; set; } //Nội dung
    }
}
