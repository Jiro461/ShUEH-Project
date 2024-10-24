using BackEnd_ASP_NET.Models;
namespace BackEnd_ASP.NET.Services
{
    public interface INotificationService
    {
        Task CreateNotificationForNewUser(User newUser);
        Task CreateNotificationForComment(Comment comment, Guid? userId);
        Task CreateNotificationForOrder(Order order, Guid? userId);
        Task CreateNotificationForWishlist(WishlistItem wishlistItem, Guid? userId);
        Task CreateNotificationForReply(Reply reply, Guid? userId);
        Task CreateUpdateNotificationForEntityChange<T>(T entity, Guid? userId = null) where T : class;
        Task CreateNotificationForShoe(Shoe shoe);
        Task CreateNotificationForEntityDelete<T>(T entity) where T : class;
    }
}