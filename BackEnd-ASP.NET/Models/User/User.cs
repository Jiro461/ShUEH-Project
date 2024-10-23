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
        public DateTime? DateOfBirth { get; set; }
        public string? ProfileName { get; set; }
        public string? AvatarUrl { get; set; } = null;
        public bool? Gender { get; set; }
        public bool? IsExternalLogin { get; set; } = false;
        public string? ProviderName { get; set; }

        public decimal? TotalMoney { get; set; }
        // Foreign Key for Role
        public Guid? RoleId { get; set; }

        // Navigation property for Role
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }

        public Wishlist? Wishlist { get; set; }
        public ICollection<Order>? Orders { get; set; } = new HashSet<Order>();
        public ICollection<Comment>? Comments { get; set; } = new HashSet<Comment>();
        public ICollection<Reply>? Replies { get; set; } = new HashSet<Reply>();
        public ICollection<CommentLike>? CommentLikes { get; set; } = new HashSet<CommentLike>();
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}