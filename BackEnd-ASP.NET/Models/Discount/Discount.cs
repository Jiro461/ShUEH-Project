using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    [Table("Discounts")]
    public class Discount : IDateTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        [MaxLength(20, ErrorMessage = "Code cannot exceed 20 characters.")]
        public string? Code { get; set; }

        [Required(ErrorMessage = "Percentage is required.")]
        public decimal Percentage { get; set; }

        public DateTime ExpiryDate { get; set; }

        [NotMapped]
        public bool IsValid
        {
            get
            {
                return DateTime.Now <= ExpiryDate;
            }
        }

        public DateTime CreateDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}