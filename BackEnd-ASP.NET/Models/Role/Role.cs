using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
        [MaxLength(50, ErrorMessage = "Role name cannot exceed 50 characters.")]
        public string? Name { get; set; }

        [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string? Description { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}