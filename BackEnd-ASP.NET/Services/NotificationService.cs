
using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;

namespace BackEnd_ASP.NET.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ShUEHContext _context;

        public NotificationService(ShUEHContext context)
        {
            _context = context;
        }
        public async Task CreateNotificationForNewUser(User newUser)
        {
            var notification = new Notification
            {
                UserMessage = $"Chào mừng {newUser.FirstName} {newUser.LastName} đến với hệ thống!",
                AdminMessage = $"User {newUser.Email} đã đăng ký tài khoản mới.",
                UserId = newUser.Id,
                CreateDate = DateTime.UtcNow
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }
        public async Task CreateNotificationForComment(Comment comment, Guid? userId)
        {
            var notification = new Notification
            {
                UserMessage = $"Bạn đã bình luận trên sản phẩm {comment.Shoe?.Name}.",
                AdminMessage = $"User {comment.User?.UserName} đã bình luận trên sản phẩm {comment.Shoe?.Name}.",
                UserId = userId ?? comment.UserId,
                CommentId = comment.Id,
                ShoeId = comment.ShoeId,
                CreateDate = DateTime.UtcNow
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNotificationForOrder(Order order, Guid? userId)
        {
            var notification = new Notification
            {
                UserMessage = $"Đơn hàng {order.Id} của bạn đã được tạo.",
                AdminMessage = $"User {order.User?.UserName} đã tạo Order {order.Id}.",
                UserId = userId ?? order.UserId,
                OrderId = order.Id,
                CreateDate = DateTime.UtcNow
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNotificationForWishlist(WishlistItem wishlistItem, Guid? userId)
        {

            var notification = new Notification
            {
                UserMessage = $"Bạn đã thêm giày {wishlistItem.Shoe?.Name} vào Wishlist.",
                AdminMessage = $"User {userId} đã thêm giày vào Wishlist.",
                UserId = userId,
                ShoeId = wishlistItem.ShoeId,
                CreateDate = DateTime.UtcNow
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNotificationForReply(Reply reply, Guid? userId)
        {
            var notification = new Notification
            {
                UserMessage = $"Bạn đã trả lời bình luận.",
                AdminMessage = $"User {reply.User?.UserName} đã trả lời bình luận.",
                UserId = userId ?? reply.UserId,
                CommentId = reply.CommentId,
                CreateDate = DateTime.UtcNow
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNotificationForEntityChange<T>(T entity, Guid? adminUserId) where T : class
        {
            var message = $"Đã có sự thay đổi trên {typeof(T).Name} với ID {entity.GetType().GetProperty("Id")?.GetValue(entity)}.";

            var notification = new Notification
            {
                UserMessage = message,
                AdminMessage = message,
                UserId = adminUserId,
                CreateDate = DateTime.UtcNow
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }
    }
}
