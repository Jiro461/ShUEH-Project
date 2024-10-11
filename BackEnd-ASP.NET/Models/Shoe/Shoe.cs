using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    [Table("Shoes")]
    public class Shoe : IDateTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Shoe name is required.")]
        [MaxLength(100, ErrorMessage = "Shoe name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [MaxLength(50, ErrorMessage = "Brand cannot exceed 50 characters.")]
        public string? Brand { get; set; }

        public bool Gender { get; set; }

        [MaxLength(100, ErrorMessage = "Material cannot exceed 100 characters.")]
        public string? Material { get; set; }

        [MaxLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        public string? Category { get; set; }

        public string? ImageUrl { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required.")]
        public int Stock { get; set; }

        public int Sold { get; set; }

        public decimal AverageRating { get; set; }

        public int TotalRatings { get; set; }

        public bool IsSale { get; set; }

        public decimal Discount { get; set; }

        public ICollection<ShoeColor>? Colors { get; set; }
        public ICollection<ShoeImage>? OtherImages { get; set; }
        public ICollection<ShoeSeason>? Seasons { get; set; }
        public ICollection<ShoeSize>? Sizes { get; set; }
        public ICollection<Comment>? Comments { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}