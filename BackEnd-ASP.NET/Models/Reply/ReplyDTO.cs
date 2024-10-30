public class ReplyDTO
{
    public Guid? Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid CommentId { get; set; }
    public DateTime CreateDate { get; set; }
}

