using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BackEnd_ASP_NET.Models;

public class OrderDTO
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid UserId { get; set; }
    public OrderStatus Status { get; set; }
    public ICollection<OrderItemDTO> OrderItems { get; set; } = new HashSet<OrderItemDTO>();
    public decimal TotalPrice { get; set; } //Co kem theo ship fee (neu co)
}


