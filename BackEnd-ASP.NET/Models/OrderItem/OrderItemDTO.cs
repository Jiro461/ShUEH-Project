using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackEnd_ASP.NET.Models.ShoeDetail;
namespace BackEnd_ASP_NET.Models
{
    public class OrderItemDTO
    {
        public Guid ShoeId { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public decimal ShoePrice { get; set; }
        public decimal TotalPrice { get; set; } 
    }
}