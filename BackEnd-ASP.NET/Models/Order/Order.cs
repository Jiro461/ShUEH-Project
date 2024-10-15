using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackEnd_ASP_NET.Models;

[Table("Orders")]
public class Order : IDateTracking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey("User")]
    [Required(ErrorMessage = "User ID is required.")]
    public Guid? UserId { get; set; }
    public User? User { get; set; }

    public DateTime OrderDate { get; set; } 

    [Required(ErrorMessage = "Total price is required.")]
    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

    public DateTime CreateDate { get; set; }

    public DateTime LastModifiedDate { get; set; }
}