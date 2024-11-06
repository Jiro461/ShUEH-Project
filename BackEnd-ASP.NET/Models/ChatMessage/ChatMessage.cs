using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEnd_ASP_NET.Utilities.Extensions;

public class ChatMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? FromUserId { get; set; }
        public string? FromUserName { get; set; }
        public string? FromUserImage { get; set; }
        public string? ToUserId { get; set; }
        public string? ToUserName { get; set; }
        public string? ToUserImage { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; } = MyDateTime.VietNam.DateTime;
    }