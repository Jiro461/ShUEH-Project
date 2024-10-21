using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    public class OrderItemDTO
    {
        public Guid ShoeId { get; set; }
        public ShoeSizeDTO? ShoeSize { get; set; }
        public ShoeColorDTO? ShoeColor { get; set; }
        public int Quantity { get; set; }
        public decimal ShoePrice { get; set; }
        public decimal TotalPrice { get; set; } 
    }
}