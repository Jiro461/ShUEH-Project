using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackEnd_ASP.NET.Models.ShoeDetail;
using BackEnd_ASP.NET.Models;
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

        public int Gender { get; set; }

        [MaxLength(200, ErrorMessage = "Material cannot exceed 100 characters.")]
        public string? Material { get; set; }

        [MaxLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        public string? Category { get; set; }

        public string? ImageUrl { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        public int Sold { get; set; }

        public decimal AverageRating { get; set; }

        public int TotalRatings { get; set; }

        public bool IsSale { get; set; }

        public decimal Discount { get; set; }

        public ICollection<ShoeImage> OtherImages { get; set; } = new HashSet<ShoeImage>();
        public ICollection<ShoeSeason> Seasons { get; set; } = new HashSet<ShoeSeason>();

        public ICollection<ShoeColor> Colors { get; set; } = new HashSet<ShoeColor>();
        public ICollection<ShoeDetail> shoeDetails { get; set; } = new HashSet<ShoeDetail>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public DateTime CreateDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }

}