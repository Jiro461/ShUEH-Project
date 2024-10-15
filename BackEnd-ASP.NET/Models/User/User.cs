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
        // Foreign Key for Role
        public Guid? RoleId { get; set; }

        // Navigation property for Role
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }

        public Wishlist? Wishlist { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}