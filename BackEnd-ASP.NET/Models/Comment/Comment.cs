using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("Comments")]
public class Comment : IDateTracking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey("User")]
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
    public string? Description { get; set; }

    [Range(1, 5, ErrorMessage = "Rate must be between 1 and 5.")]
    public decimal Rate { get; set; }

    [ForeignKey("Shoe")]
    public Guid? ShoeId { get; set; }
    public Shoe? Shoe { get; set; }

    public ICollection<Reply>? Replies { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastModifiedDate { get; set; }
}
