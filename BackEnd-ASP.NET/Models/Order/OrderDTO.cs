using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackEnd_ASP_NET.Models;

public class OrderGetDTO
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = "/noavatar.png";
    public int TotalItems { get; set; }
    public string DetailOrder { get; set; } = string.Empty;
    public OrderStatus Status { get; set; }
    public ICollection<OrderItemDTO> OrderItems { get; set; } = new HashSet<OrderItemDTO>();
    public decimal TotalPrice { get; set; } //Co kem theo ship fee (neu co)
    public PaymentMethod PaymentMethod { get; set; }
}

public class OrderPostDTO
{
    public bool IsUsingDiscount { get; set; } = false;
    public Guid? DiscountId { get; set; }
    public string DetailOrder { get; set; } = string.Empty;
    public ICollection<OrderItemDTO> OrderItems { get; set; } = new HashSet<OrderItemDTO>();
    public decimal TotalPrice { get; set; } //Co kem theo ship fee (neu co)
    public PaymentMethod PaymentMethod { get; set; }
    public DateTime OrderDate { get; set; }
}




