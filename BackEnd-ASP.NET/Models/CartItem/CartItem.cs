using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackEnd_ASP.NET.Models.ShoeDetail;

namespace BackEnd_ASP_NET.Models
{
    [Table("Carts")]
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [ForeignKey("Shoe")]
        public Guid ShoeId { get; set; }
        public Shoe? Shoe { get; set; }


        public int Size { get; set; }

    }
}