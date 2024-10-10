using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("Wishlists")]
public class Wishlist
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey("User")]
    public Guid? UserId { get; set; }
    public User? User { get; set; }

    public ICollection<WishlistItem>? WishlistItems { get; set; }
}