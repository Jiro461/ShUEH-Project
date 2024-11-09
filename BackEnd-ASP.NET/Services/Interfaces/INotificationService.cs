using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_ASP.NET.Services
{
    public interface INotificationService
    {
        Task CreateNotificationForNewUser(User newUser);
        Task CreateNotificationForComment(Comment comment, Guid? userId);
        Task CreateNotificationForCommentLike(CommentLike commentLike, Guid? userId);
        Task CreateNotificationForOrder(Order order, Guid? userId);
        Task CreateNotificationForWishlist(WishlistItem wishlistItem, Guid? userId);
        Task CreateNotificationForReply(Reply reply, Guid? userId);
        Task CreateUpdateNotificationForEntityChange<T>(T entity, Guid? userId = null) where T : class;
        Task CreateNotificationForShoe(Shoe shoe);
        Task CreateNotificationForUserViewProduct(Guid productId, Guid userId);
        Task CreateNotificationForEntityDelete<T>(T entity) where T : class;
        Task<IActionResult> GetUserNotifications(HttpContext httpContext, int pageNumber, int pageSize);
        Task<IActionResult> GetAdminNotifications(HttpContext httpContext, int pageNumber, int pageSize);
        Task<IActionResult> AdminGetUserNotifications(HttpContext httpContext, Guid userId);
    }
}