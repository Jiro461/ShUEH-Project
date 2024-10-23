using BackEnd_ASP_NET.Models;

public class CommentDTO
{
    public Guid Id { get; set; }
    public string Comment { get; set; } = string.Empty; 
    public Guid UserId { get; set; }
    public decimal Rate { get; set; }
    public int TotalLike { get; set; }
    public Guid ShoeId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserAvatar { get; set; } = string.Empty;
    public ICollection<ReplyDTO>? Replies { get; set; }
    public ICollection<CommentLikeDTO>? CommentLikes { get; set; }
    public DateTime CreateDate { get; set; }
}