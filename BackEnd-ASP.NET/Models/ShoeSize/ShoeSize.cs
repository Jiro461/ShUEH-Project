using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    [Table("ShoeSizes")]
    public class ShoeSize
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        public int Size { get; set; }

        [ForeignKey("Shoe")]
        public Guid? ShoeId { get; set; }
        public Shoe? Shoe { get; set; }
    }
}