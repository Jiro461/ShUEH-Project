using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BackEnd_ASP.NET.Services
{
    // Lớp EmailSender triển khai giao diện IEmailSender
    public class EmailSender : IEmailSender
    {
        // Biến thành viên để lưu trữ cấu hình
        private readonly IConfiguration _configuration;

        // Hàm khởi tạo, nhận vào một đối tượng IConfiguration
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Phương thức gửi email không đồng bộ
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // Lấy cấu hình email từ file cấu hình
            var emailSettings = _configuration.GetSection("EmailSettings");

            // Lấy thông tin cấu hình SMTP
            var smtpServer = emailSettings["SmtpServer"];
            var smtpPort = int.Parse(emailSettings["SmtpPort"] ?? "587"); // Nếu null thì lấy 587
            var smtpUser = emailSettings["SmtpUser"];
            var smtpPass = emailSettings["SmtpPass"];
            var senderName = emailSettings["SenderName"];
            var senderEmail = emailSettings["SenderEmail"] ?? "No Indentify"; // Nếu null thì lấy "No Indentify"

            // Tạo đối tượng SmtpClient với thông tin cấu hình
            var client = new SmtpClient(smtpServer)
            { 
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            };

            // Tạo đối tượng MailMessage với thông tin email
            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail, senderName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            // Thêm địa chỉ email người nhận
            mailMessage.To.Add(new MailAddress(email));

            // Gửi email không đồng bộ
            await client.SendMailAsync(mailMessage);
        }
    }
}