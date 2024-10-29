using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_ASP_NET.Models
{
    [Table("ProductViews")]
    public class ProductView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public Guid? UserId { get; set; }
        public string? IPAddress { get; set; }
        public DateTime ViewedDate { get; set; } = DateTime.Now;
    }
}
