using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    public class DiscountDTO
    {
        public Guid? Id { get; set; }
        //Mã giảm giá
        public string? Code { get; set; }
        //Phần trăm giảm giá
        public decimal? Percentage { get; set; }
        //Mã giảm giá có phải là mã giảm giá phổ biến không
        public bool IsPublic { get; set; } = false;
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
    }
}