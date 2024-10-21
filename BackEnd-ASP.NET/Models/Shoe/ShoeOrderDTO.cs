using System.ComponentModel.DataAnnotations;
using BackEnd_ASP.NET.Models.ShoeDetail;
using BackEnd_ASP_NET.Models;

public class ShoeOrderDTO
    {
        public Guid ShoeId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Brand { get; set; } = string.Empty;
        public string? MainImageUrl { get; set; } = string.Empty;
        [Required]
        public ShoeDetailDTO Detail { get; set; } = new ShoeDetailDTO();
    }