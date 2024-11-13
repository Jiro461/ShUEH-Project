using BackEnd_ASP_NET.Models;

public class CommentPostDTO
{
    public string Comment { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public int TotalLike { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ShoeId {get; set;}
    public Guid OrderItemId { get; set; }
    public IFormFile? Image { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserAvatar { get; set; } = string.Empty;
}

public class CommentGetDTO : CommentPostDTO
{
    public Guid Id { get; set; }
    public GeneralReview GeneralReview { get; set; }
    public string? ImageUrl { get; set; }
    public ICollection<ReplyDTO>? Replies { get; set; }
    public bool IsUserPost { get; set; }
    public DateTime CreateDate { get; set; }
    public int Size { get; set; }
}
