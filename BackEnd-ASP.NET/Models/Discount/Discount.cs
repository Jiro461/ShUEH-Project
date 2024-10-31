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
        //Mã giảm giá
        public string? Code { get; set; }
        //Mã giảm giá có phải là mã giảm giá phổ biến không
        public bool IsPublic { get; set; } = false;

        [Required(ErrorMessage = "Percentage is required.")]
        //Phần trăm giảm giá
        public decimal? Percentage { get; set; }
        //Số tiền giảm giá
        public decimal? Amount { get; set; }
        //Loại mã giảm giá
        public DiscountType Type { get; set; }
        //Số lượng mã giảm giá
        public int Quantity { get; set; }
        //Số tiền giảm giá tối đa
        public decimal? MaximumDiscount { get; set; }
        //Số tiền đơn hàng tối thiểu
        public decimal? MinimumOrder { get; set; }
        //Ngày hết hạn
        public DateTime ExpiryDate { get; set; }
        //Ngày tạo
        public DateTime CreateDate { get; set; }
        //Ngày sửa đổi
        public DateTime LastModifiedDate { get; set; }
        [NotMapped]
        //Kiểm tra mã giảm giá có hợp lệ không
        public bool IsValid
        {
            get
            {
                return DateTime.Now <= ExpiryDate;
            }
        }
    }
}