using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    public class WishlistItemDTO
    {
        public Guid? ShoeId { get; set; }
        public string? ShoeName { get; set; }
        public string? ShoeBrand { get; set; }
        public string? ShoeImageUrl { get; set; }
        public decimal? ShoePrice { get; set; }
        public bool IsSale { get; set; }
        public decimal? SalePrice { get; set; }
        public bool IsNew { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
