using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    [Table("WishlistItems")]
    public class WishlistItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Wishlist")]
        public Guid? WishlistId { get; set; }
        public Wishlist? Wishlist { get; set; }

        [ForeignKey("Shoe")]
        public Guid? ShoeId { get; set; }
        public Shoe? Shoe { get; set; }
    }
}
