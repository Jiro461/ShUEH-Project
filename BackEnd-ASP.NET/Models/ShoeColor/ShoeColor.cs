using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackEnd_ASP_NET.Models;
namespace BackEnd_ASP.NET.Models
{
    [Table("ShoesColor")]
    public class ShoeColor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Shoe")]
        public Guid? ShoeId { get; set; }
        public Shoe? Shoe { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public string? Color { get; set; }
    }
}