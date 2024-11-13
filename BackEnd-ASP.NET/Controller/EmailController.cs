using BackEnd_ASP.NET.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BackEnd_ASP.NET.Controller.Email
{
    // Controller xử lý các yêu cầu liên quan đến email, đặc biệt là quên mật khẩu và xác minh OTP
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        // Dịch vụ gửi email (thường sử dụng EmailSender)
        private readonly IEmailSender _emailSender;
        
        // Dịch vụ tài khoản để thay đổi mật khẩu
        private readonly IAccountService _accountService;

        // Bộ nhớ cache để lưu trữ mã OTP tạm thời
        private readonly IMemoryCache _cache;

        // Constructor để khởi tạo các dịch vụ
        public EmailController(IEmailSender emailSender, IMemoryCache cache, IAccountService accountService)
        {
            _emailSender = emailSender;
            _cache = cache;
            _accountService = accountService;
        }

        // API để gửi mã OTP vào email khi người dùng quên mật khẩu
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            // Kiểm tra xem email người dùng có hợp lệ không
            if (string.IsNullOrWhiteSpace(request.Email))
                return BadRequest("Email is required.");

            // Sinh mã OTP ngẫu nhiên 6 chữ số
            var otp = GenerateOtp();

            // Cấu hình nội dung email chứa mã OTP
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

            // Gửi email với mã OTP
            await _emailSender.SendEmailAsync(request.Email, subject, body);

            // Lưu mã OTP vào bộ nhớ cache với thời gian sống là 5 phút
            _cache.Set(request.Email, otp, TimeSpan.FromMinutes(5));

            // Trả về phản hồi cho người dùng
            return Ok("OTP sent to your email.");
        }

        // API để xác minh mã OTP người dùng nhập vào
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpVerificationRequest request)
        {
            // Kiểm tra xem email có tồn tại trong cache không (tức là mã OTP có còn hiệu lực)
            if (!_cache.TryGetValue(request.Email, out string? storedOtp))
            {
                return BadRequest("OTP expired or email not found.");
            }

            // So sánh mã OTP người dùng nhập vào với mã OTP trong cache
            if (storedOtp != request.Otp)
            {
                return BadRequest("Invalid OTP.");
            }

            // Nếu OTP hợp lệ, thực hiện thay đổi mật khẩu cho người dùng
            return (await _accountService.ChangePassword(request.Email, request.NewPassword));
        }

        // Hàm sinh mã OTP ngẫu nhiên 6 chữ số
        private string GenerateOtp()
        {
            var random = new Random();
            return string.Join("", Enumerable.Range(0, 6).Select(_ => random.Next(0, 10)));
        }
    }

    // Lớp DTO yêu cầu người dùng nhập email khi quên mật khẩu
    public class ForgotPasswordRequest
    {
        public string Email { get; set; } = string.Empty;
    }

    // Lớp DTO yêu cầu thông tin xác minh OTP
    public class OtpVerificationRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Otp { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
