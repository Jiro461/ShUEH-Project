using System.ComponentModel.DataAnnotations;
using BackEnd_ASP.NET.Models.ShoeDetail;
using BackEnd_ASP_NET.Models;

namespace BackEnd_ASP.NET.Models
{
    public class ShoeGetDTO
    {
        public Guid Id { get; set; }
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
        public string Material { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "Category cannot be longer than 50 characters")]
        public string Category { get; set; } = string.Empty;
        [Required]
        [Url(ErrorMessage = "Image URL must be a valid URL")]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        [MaxLength(1000, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be between 0 and 10000")]
        public decimal Price { get; set; }
        public bool IsSale { get; set; }
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100")]
        public decimal Discount { get; set; }
        [Required(ErrorMessage = "Other images are required.")]
        public ICollection<ShoeImage>? OtherImages { get; set; } = new HashSet<ShoeImage>();
        [Required(ErrorMessage = "Seasons are required.")]
        public ICollection<ShoeSeason>? Seasons { get; set; } = new HashSet<ShoeSeason>();
        [Required(ErrorMessage = "ShoeDetail are required.")]
        public ICollection<ShoeDetailDTO>? shoeDetails { get; set; } = new HashSet<ShoeDetailDTO>();
        [Required(ErrorMessage = "Colors are required.")]
        public ICollection<ShoeColorDTO>? Colors { get; set; } = new HashSet<ShoeColorDTO>();
        public DateTime CreatedAt { get; set; }
    }

    public class ShoePostDTO
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
        public string Material { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "Category cannot be longer than 50 characters")]
        public string Category { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public IFormFile? MainImage { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be between 0 and 10000")]
        public decimal Price { get; set; }
        public bool IsSale { get; set; }
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100")]
        public decimal Discount { get; set; }

        // You might want to include these if they can be updated directly
        public List<IFormFile?>? AdditionalImages { get; set; }

        [Required(ErrorMessage = "Seasons are required.")]
        public ICollection<ShoeSeasonDTO> Seasons { get; set; } = new HashSet<ShoeSeasonDTO>();

        [Required(ErrorMessage = "Shoe Detail are required.")]
        public ICollection<ShoeDetailDTO> shoeDetails { get; set; } = new HashSet<ShoeDetailDTO>();
        [Required(ErrorMessage = "Colors are required.")]
        public ICollection<ShoeColorDTO> Colors { get; set; } = new HashSet<ShoeColorDTO>();
    }

}
