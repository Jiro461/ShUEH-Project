using BackEnd_ASP_NET.Models;

namespace BackEnd_ASP.NET.Models
{
    public class ShoeUpdateDTO
    {
        public string? Name { get; set; }
        public string? Brand { get; set; }

        public int Gender { get; set; }

        public string? Material { get; set; }

        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public bool IsSale { get; set; }

        public decimal Discount { get; set; }

        // You might want to include these if they can be updated directly
        public ICollection<ShoeColor> Colors { get; set; } = new HashSet<ShoeColor>();
        public ICollection<ShoeImage> OtherImages { get; set; } = new HashSet<ShoeImage>();
        public ICollection<ShoeSeason> Seasons { get; set; } = new HashSet<ShoeSeason>();
        public ICollection<ShoeSize> Sizes { get; set; } = new HashSet<ShoeSize>();
    }
}
