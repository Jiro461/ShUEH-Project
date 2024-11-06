using BackEnd_ASP_NET.Models;

public class CommentPostDTO
{
    public string Comment { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public int TotalLike { get; set; }
    public Guid? ShoeId { get; set; }
    public Guid? UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserAvatar { get; set; } = string.Empty;
    public int Size { get; set; }
}

public class CommentGetDTO : CommentPostDTO
{
    public Guid Id { get; set; }
    public GeneralReview GeneralReview { get; set; }
    public ICollection<ReplyDTO>? Replies { get; set; }
    public bool IsUserPost { get; set; }
    public DateTime CreateDate { get; set; }
}
