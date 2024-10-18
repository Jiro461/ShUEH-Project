using System.ComponentModel.DataAnnotations;
using BackEnd_ASP_NET.Models;

namespace BackEnd_ASP.NET.Models.User
{
    public class UserDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Profile name is required.")]
        [MaxLength(50, ErrorMessage = "Profile name cannot exceed 50 characters.")]
        public string? ProfileName { get; set; }
        [Url(ErrorMessage = "Avatar URL must be a valid URL.")]
        public string? AvatarUrl { get; set; } = null;
        [Required(ErrorMessage = "Gender is required.")]
        public bool? Gender { get; set; }
        public decimal? TotalMoney { get; set; }
        public Wishlist? Wishlist { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}