using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    [Table("OrderItems")]
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Order")]
        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }

        [ForeignKey("Shoe")]
        public Guid? ShoeId { get; set; }

        public Shoe? Shoe { get; set; }

        public ShoeColorDTO? ShoeColor { get; set; }
        public ShoeSizeDTO? ShoeSize { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}