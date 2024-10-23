public interface IDateTracking // Cập nhật lúc SaveChangeAsync()
{
    DateTime CreateDate { get; set; }
    DateTime LastModifiedDate { get; set; }
}