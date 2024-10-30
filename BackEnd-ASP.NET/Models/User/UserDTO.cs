using System.ComponentModel.DataAnnotations;
using BackEnd_ASP_NET.Models;

namespace BackEnd_ASP.NET.Models.User
{
    public class UserPutDTO
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
        public IFormFile? Avatar { get; set; } = null;
        [Required(ErrorMessage = "Gender is required.")]
        public bool? Gender { get; set; }
    }
    public sealed class UserGetDTO
    {
        public Guid Id { get; set; }
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
        public string? AvatarUrl { get; set; }
        public bool? Gender { get; set; }
        public decimal? TotalMoney { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? EmailConfirmed { get; set; }
        public bool? IsExternalLogin { get; set; }
    }

    public class UserInfoDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? ProfileName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public bool? EmailConfirmed { get; set; }
        public bool? IsExternalLogin { get; set; }
    }
}