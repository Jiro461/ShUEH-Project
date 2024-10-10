using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("Replies")]
public class Reply : IDateTracking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey("Comment")]
    public Guid? CommentId { get; set; }
    public Comment? Comment { get; set; }

    [ForeignKey("User")]
    public Guid? UserId { get; set; }
    public User? User { get; set; }

    [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
    public string? Description { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastModifiedDate { get; set; }
}