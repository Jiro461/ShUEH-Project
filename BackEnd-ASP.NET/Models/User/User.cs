using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BackEnd_ASP_NET.Models
{
    [Table("Users")]
    public class User : IdentityUser<Guid>, IDateTracking
    {
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public decimal? TotalMoney { get; set; }

        [ForeignKey("Role")]
        public Guid? RoleId { get; set; }
        public Role? Role { get; set; }
        [ForeignKey("Wistlist")]
        public Guid? WistlistId { get; set; }
        public Wishlist? Wishlist { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Reply>? Replies { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}