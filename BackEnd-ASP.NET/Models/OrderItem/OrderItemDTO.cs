using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackEnd_ASP.NET.Models.ShoeDetail;
using BackEnd_ASP.NET.Models;
namespace BackEnd_ASP_NET.Models
{
    public class OrderItemDTO
    {
        public Guid ShoeId { get; set; }
        public string ShoeName { get; set; } = string.Empty;
        public string ShoeImage { get; set; } = string.Empty;
        public IEnumerable<ShoeColorDTO> ShoeColorDTO { get; set; } = new HashSet<ShoeColorDTO>();
        public int Size { get; set; }
        public int Quantity { get; set; }
        public decimal ShoePrice { get; set; }
        public decimal TotalPrice { get; set; } 
    }
}