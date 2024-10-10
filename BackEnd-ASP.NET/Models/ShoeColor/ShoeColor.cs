using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("ShoeColors")]
public class ShoeColor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Color is required.")]
    public string? Color { get; set; }

    [ForeignKey("Shoe")]
    public Guid? ShoeId { get; set; }
    public Shoe? Shoe { get; set; }
}