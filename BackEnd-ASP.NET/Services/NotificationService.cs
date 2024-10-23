
using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;
using BackEnd_ASP_NET.Utilities.Extensions;

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
                User = newUser,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }
        public async Task CreateNotificationForComment(Comment comment, Guid? userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var notification = new Notification
            {
                UserMessage = $"Bạn đã bình luận trên sản phẩm {comment.Shoe?.Name}.",
                AdminMessage = $"User {comment.User?.UserName} đã bình luận trên sản phẩm {comment.Shoe?.Name}.",
                User = user,
                CommentId = comment.Id,
                ShoeId = comment.ShoeId,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNotificationForOrder(Order order, Guid? userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var notification = new Notification
            {
                UserMessage = $"Đơn hàng {order.Id} của bạn đã được tạo.",
                AdminMessage = $"User {order.User?.UserName} đã tạo Order {order.Id}.",
                User = user,
                OrderId = order.Id,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNotificationForWishlist(WishlistItem wishlistItem, Guid? userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var notification = new Notification
            {
                UserMessage = $"Bạn đã thêm giày {wishlistItem.Shoe?.Name} vào Wishlist.",
                AdminMessage = $"User {userId} đã thêm giày vào Wishlist.",
                User = user,
                ShoeId = wishlistItem.ShoeId,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNotificationForReply(Reply reply, Guid? userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var notification = new Notification
            {
                UserMessage = $"Bạn đã trả lời bình luận.",
                AdminMessage = $"User {reply.User?.ProfileName} đã trả lời bình luận.",
                User = user,
                CommentId = reply.CommentId,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task CreateUpdateNotificationForEntityChange<T>(T entity, Guid? userId = null) where T : class
        {
            var notification = new Notification();
            if(userId == null){
                var message = $"Bạn đã thay đổi {typeof(T).Name} với ID {entity.GetType().GetProperty("Id")?.GetValue(entity)}.";

                notification = new Notification
                {
                    AdminMessage = message,
                    CreateDate = MyDateTime.VietNam.DateTime
                };

            }
            else{
                var usermessage = $"Bạn đã cập nhật thông tin {typeof(T).Name}.";
                var adminmessage = $"User {userId} đã thay đổi thông tin {typeof(T).Name} với ID {entity.GetType().GetProperty("Id")?.GetValue(entity)}.";
                var user = await _context.Users.FindAsync(userId);
                notification = new Notification
                {
                    UserMessage = usermessage,
                    AdminMessage = adminmessage,
                    User = user,
                    CreateDate = MyDateTime.VietNam.DateTime
                };
            }
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNotificationForShoe(Shoe shoe){
            var notification = new Notification
            {
                AdminMessage = $"Bạn đã tạo mới sản phẩm {shoe.Name}.",
                Product = shoe,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task CreateNotificationForEntityDelete<T>(T entity) where T : class
        {
            var notification = new Notification
            {
                AdminMessage = $"Bạn đã xóa {typeof(T).Name} với ID {entity.GetType().GetProperty("Id")?.GetValue(entity)}.",
                CreateDate = MyDateTime.VietNam.DateTime
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }
    }
}
