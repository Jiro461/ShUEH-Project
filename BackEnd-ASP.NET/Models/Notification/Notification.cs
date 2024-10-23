using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackEnd_ASP_NET.Utilities.Extensions;

namespace BackEnd_ASP_NET.Models
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string UserMessage { get; set; } = string.Empty;
        public string AdminMessage { get; set; } = string.Empty;

        // Trạng thái đã đọc hay chưa
        public bool IsRead { get; set; } = false;

        // Thời gian tạo thông báo
        public DateTime CreateDate { get; set; } = MyDateTime.VietNam.DateTime;

        // Liên kết đến người dùng nhận thông báo
        [ForeignKey("User")]
        public Guid? UserId { get; set; }
        public User? User { get; set; }

        // Liên kết đến comment (nếu có liên quan)
        [ForeignKey("Comment")]
        public Guid? CommentId { get; set; }
        public Comment? Comment { get; set; }

        // Liên kết đến sản phẩm (nếu có liên quan)
        [ForeignKey("Shoe")]
        public Guid? ShoeId { get; set; }
        public Shoe? Product { get; set; }

        // Liên kết đến Order (nếu có liên quan)

        [ForeignKey("Order")]
        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
