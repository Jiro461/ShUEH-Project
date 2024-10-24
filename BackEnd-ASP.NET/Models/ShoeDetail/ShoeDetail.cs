using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEnd_ASP.NET.Models.ShoeDetail;
using BackEnd_ASP_NET.Models;

namespace BackEnd_ASP.NET.Models.ShoeDetail
{
    [Table("ShoesDetail")]
    public class ShoeDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Shoe")]
        public Guid ShoeId { get; set; }
        public Shoe? Shoe { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
    }

}

