using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Đây là bảng lưu trữ thông tin xem trang của người dùng
[Table("SiteViews")]
public class SiteView
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Ipaddress { get; set; } = string.Empty;
    public string Device { get; set; } = string.Empty;
    public DateTime ViewedDate { get; set; }
}
