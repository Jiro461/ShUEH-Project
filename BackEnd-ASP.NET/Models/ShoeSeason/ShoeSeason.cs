using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("ShoeSeasons")]
public class ShoeSeason
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Season is required.")]
    public string? Season { get; set; }

    [ForeignKey("Shoe")]
    public Guid? ShoeId { get; set; }
    public Shoe? Shoe { get; set; }
}