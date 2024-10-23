using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    [Table("ShoeImages")]
    public class ShoeImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "URL is required.")]
        public string? Url { get; set; }

        [ForeignKey("Shoe")]
        public Guid? ShoeId { get; set; }
        public Shoe? Shoe { get; set; }
    }
}