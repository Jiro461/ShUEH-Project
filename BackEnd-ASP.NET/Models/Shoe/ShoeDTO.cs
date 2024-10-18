using System.ComponentModel.DataAnnotations;
using BackEnd_ASP_NET.Models;

namespace BackEnd_ASP.NET.Models
{
    public class ShoeUpdateDTO
    {
        [Required(ErrorMessage = "Shoe name is required.")]
        [MaxLength(100, ErrorMessage = "Shoe name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [MaxLength(50, ErrorMessage = "Brand cannot exceed 50 characters.")]
        public string? Brand { get; set; }

        [Required]
        [Range(0, 2, ErrorMessage = "Gender must be between 0 and 2")]
        public int Gender { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Material cannot be longer than 50 characters")]
        public string Material { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Category cannot be longer than 50 characters")]
        public string Category { get; set; }
        [Required]
        [Url(ErrorMessage = "Image URL must be a valid URL")]
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be between 0 and 10000")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be between 0 and 10000")]
        
        public int Stock { get; set; }
        [Required]
        public bool IsSale { get; set; }
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100")]
        public decimal Discount { get; set; }

        // You might want to include these if they can be updated directly
        public ICollection<ShoeColor> Colors { get; set; } = new HashSet<ShoeColor>();
        public ICollection<ShoeImage> OtherImages { get; set; } = new HashSet<ShoeImage>();
        public ICollection<ShoeSeason> Seasons { get; set; } = new HashSet<ShoeSeason>();
        public ICollection<ShoeSize> Sizes { get; set; } = new HashSet<ShoeSize>();
    }
}
