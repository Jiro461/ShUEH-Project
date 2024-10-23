using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BackEnd_ASP.NET.Controller.Email
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly IMemoryCache _cache;
        public EmailController(IEmailSender emailSender, IMemoryCache cache)
        {
            _emailSender = emailSender;
            _cache = cache;
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                return BadRequest("Email is required.");
            
            // Sinh mã OTP ngẫu nhiên 6 chữ số
            var otp = GenerateOtp();

            // Gửi email với mã OTP
            var subject = "OTP for Password Reset From SHUEH Website";
            var body = $@" <div style='font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;'>
                            <div style='max-width: 600px; margin: 0 auto; background-color: #fff; border-radius: 8px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);'>
                                <div style='padding: 20px; border-bottom: 1px solid #ddd;'>
                                    <h2 style='color: #333;'>Reset Your Password</h2>
                                </div>
                                <div style='padding: 20px;'>
                                    <p style='font-size: 16px; color: #555; text-align: center'>Dear User,</p>
                                    <p style='font-size: 16px; color: #555; text-align: center'>
                                        You have requested to reset your password. Please use the following OTP code to proceed:
                                    </p>
                                    <div style='text-align: center; margin: 20px 0;'>
                                        <span style='font-size: 24px; font-weight: bold; color: #FF626D;'>{otp}</span>
                                    </div>
                                    <p style='font-size: 16px; color: #555;'>This OTP code will expire in 5 minutes.</p>
                                    <p style='font-size: 16px; color: #555;'>If you did not request a password reset, please ignore this email.</p>
                                </div>
                                <div style='background: linear-gradient(to right, #FF646B, #FCAB73);
                    ; color: white; padding: 10px; text-align: center; border-radius: 0 0 8px 8px;'>
                                    <p style='margin: 0;'>Thank you,</p>
                                    <p style='margin: 0; font-weight: bold;'>SHUEH</p>
                                </div>
                            </div>
                        </div>";
            await _emailSender.SendEmailAsync(request.Email, subject, body);

            // Lưu OTP vào cache (tạm thời) hoặc cơ sở dữ liệu (bạn có thể tự triển khai)
            _cache.Set(request.Email, otp, TimeSpan.FromMinutes(5)); // Tạm thời dùng TempData cho ví dụ

            return Ok("OTP sent to your email.");
        }

        [HttpPost("verify-otp")]
        public IActionResult VerifyOtp([FromBody] OtpVerificationRequest request)
        {
            // Kiểm tra xem email có tồn tại trong cache không
            if (!_cache.TryGetValue(request.Email, out string? storedOtp))
            {
                return BadRequest("OTP expired or email not found.");
            }

            // So sánh OTP người dùng nhập với OTP trong cache
            if (storedOtp != request.Otp)
            {
                return BadRequest("Invalid OTP.");
            }

            // Xóa OTP khỏi cache sau khi xác nhận thành công
            _cache.Remove(request.Email);

            return Ok("OTP verified successfully.");
        }

        private string GenerateOtp()
        {
            var random = new Random();
            return string.Join("", Enumerable.Range(0, 6).Select(_ => random.Next(0, 10)));
        }
    }

    public class ForgotPasswordRequest
    {
        public string Email { get; set; } = string.Empty;
    }

    public class OtpVerificationRequest
{
    public string Email { get; set; } = string.Empty;
    public string Otp { get; set; } = string.Empty;
}
}
