using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_ASP_NET.Models
{
    [Table("CommentLikes")]
    public class CommentLike
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }

        [Required]
        [ForeignKey("Comment")]
        public Guid CommentId { get; set; }
        public Comment? Comment { get; set; }
    }
}