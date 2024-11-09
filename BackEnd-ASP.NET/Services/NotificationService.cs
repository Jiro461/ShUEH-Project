using System.Security.Claims;
using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;
using BackEnd_ASP_NET.Utilities.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ASP.NET.Services
{
    // Lớp dịch vụ thông báo, kế thừa từ ControllerBase và triển khai INotificationService
    public class NotificationService : ControllerBase, INotificationService
    {
        // Biến thành viên để lưu trữ ngữ cảnh cơ sở dữ liệu
        private readonly ShUEHContext _context;

        // Hàm khởi tạo, nhận vào một đối tượng ShUEHContext
        public NotificationService(ShUEHContext context)
        {
            _context = context;
        }

        #region Create Notification
        // Phương thức tạo thông báo cho người dùng mới
        public async Task CreateNotificationForNewUser(User newUser)
        {
            // Tạo đối tượng Notification với thông tin người dùng mới
            var notification = new Notification
            {
                UserMessage = $"Chào mừng {newUser.FirstName} {newUser.LastName} đến với hệ thống!",
                AdminMessage = $"User {newUser.Email} đã đăng ký tài khoản mới.",
                User = newUser,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            // Thêm thông báo vào cơ sở dữ liệu
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        // Phương thức tạo thông báo khi người dùng thích bình luận
        public async Task CreateNotificationForCommentLike(CommentLike commentLike, Guid? userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var notification = new Notification
            {
                UserMessage = $"Bạn đã thích 1 bình luận.",
                AdminMessage = $"{user?.UserName} đã thích 1 bình luận.",
                User = user,
                CommentId = commentLike.CommentId,
                CreateDate = MyDateTime.VietNam.DateTime
            };
            // Thêm thông báo vào cơ sở dữ liệu
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        // Phương thức tạo thông báo khi người dùng bình luận
        public async Task CreateNotificationForComment(Comment comment, Guid? userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var notification = new Notification
            {
                UserMessage = $"Bạn đã bình luận trên sản phẩm {comment.Shoe?.Name}.",
                AdminMessage = $"{comment.User?.UserName} đã bình luận trên sản phẩm {comment.Shoe?.Name}.",
                User = user,
                CommentId = comment.Id,
                ShoeId = comment.ShoeId,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            // Thêm thông báo vào cơ sở dữ liệu
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        // Phương thức tạo thông báo khi người dùng đặt hàng
        public async Task CreateNotificationForOrder(Order order, Guid? userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var notification = new Notification
            {
                UserMessage = $"Đơn hàng {order.Id} của bạn đã được đặt.",
                AdminMessage = $"{order.User?.UserName} đã đặt đơn hàng {order.Id} với tổng giá {order.TotalPrice} với phương thức {order.PaymentMethod}.",
                User = user,
                OrderId = order.Id,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            // Thêm thông báo vào cơ sở dữ liệu
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        // Phương thức tạo thông báo khi người dùng thêm sản phẩm vào Wishlist
        public async Task CreateNotificationForWishlist(WishlistItem wishlistItem, Guid? userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var notification = new Notification
            {
                UserMessage = $"Bạn đã thêm giày {wishlistItem.Shoe?.Name} vào Wishlist.",
                AdminMessage = $"{user?.UserName} đã thêm giày {wishlistItem.Shoe?.Name} vào Wishlist.",
                User = user,
                ShoeId = wishlistItem.ShoeId,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            // Thêm thông báo vào cơ sở dữ liệu
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        // Phương thức tạo thông báo khi admin trả lời bình luận
        public async Task CreateNotificationForReply(Reply reply, Guid? userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var commentId = reply.CommentId;
            var comment = await _context.Comments
            .Include(c => c.Shoe)
            .FirstOrDefaultAsync(c => c.Id == commentId);
            var shoeName = comment?.Shoe?.Name;
            var notification = new Notification
            {
                UserMessage = $"Admin đã trả lời bình luận của bạn ở sản phẩm {shoeName}.",
                AdminMessage = $"Bạn đã trả lời bình luận của {user?.ProfileName} ở sản phẩm {shoeName}.",
                User = user,
                CommentId = reply.CommentId,
                ShoeId = comment?.ShoeId,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            // Thêm thông báo vào cơ sở dữ liệu
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        // Phương thức tạo thông báo khi cập nhật thông tin thực thể
        public async Task CreateUpdateNotificationForEntityChange<T>(T entity, Guid? userId = null) where T : class
        {
            var notification = new Notification();
            if (userId == null)
            {
                var message = $"Bạn đã cập nhật {typeof(T).Name} với ID {entity.GetType().GetProperty("Id")?.GetValue(entity)}.";

                notification = new Notification
                {
                    AdminMessage = message,
                    CreateDate = MyDateTime.VietNam.DateTime
                };

            }
            else
            {
                var user = await _context.Users.FindAsync(userId);
                var usermessage = $"Bạn đã cập nhật thông tin {typeof(T).Name}.";
                var adminmessage = $"{user?.UserName} đã thay đổi thông tin {typeof(T).Name} với ID {entity.GetType().GetProperty("Id")?.GetValue(entity)}.";
                notification = new Notification
                {
                    UserMessage = usermessage,
                    AdminMessage = adminmessage,
                    User = user,
                    CreateDate = MyDateTime.VietNam.DateTime
                };
            }
            // Thêm thông báo vào cơ sở dữ liệu
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        // Phương thức tạo thông báo khi người dùng xem sản phẩm
        public async Task CreateNotificationForUserViewProduct(Guid productId, Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var shoe = await _context.Shoes.FindAsync(productId);
            var notification = new Notification
            {
                UserMessage = $"Bạn đã xem sản phẩm {shoe?.Name}.",
                AdminMessage = $"{user?.UserName} đã xem sản phẩm {shoe?.Name}.",
                User = user,
                Product = shoe,
                CreateDate = MyDateTime.VietNam.DateTime
            };
            // Thêm thông báo vào cơ sở dữ liệu
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        // Phương thức tạo thông báo khi tạo mới sản phẩm
        public async Task CreateNotificationForShoe(Shoe shoe)
        {
            var notification = new Notification
            {
                AdminMessage = $"Bạn đã tạo mới sản phẩm {shoe.Name}.",
                Product = shoe,
                CreateDate = MyDateTime.VietNam.DateTime
            };

            // Thêm thông báo vào cơ sở dữ liệu
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        // Phương thức tạo thông báo khi xóa thực thể
        public async Task CreateNotificationForEntityDelete<T>(T entity) where T : class
        {
            var notification = new Notification
            {
                AdminMessage = $"Bạn đã xóa {typeof(T).Name} với ID {entity.GetType().GetProperty("Id")?.GetValue(entity)}.",
                CreateDate = MyDateTime.VietNam.DateTime
            };

            // Thêm thông báo vào cơ sở dữ liệu
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Get Notification API
        // Phương thức lấy thông báo của người dùng
        public async Task<IActionResult> GetUserNotifications(HttpContext httpContext, int pageNumber, int pageSize)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            // Lấy danh sách thông báo của người dùng từ cơ sở dữ liệu
            var notifications = await _context.Notifications.Where(notification => notification.UserId == Guid.Parse(userId)).Select(notification => new
            {
                notification.Id,
                notification.UserMessage,
                notification.CreateDate
            })
            .OrderByDescending(notification => notification.CreateDate)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            return Ok(notifications);
        }

        // Phương thức lấy thông báo của admin
        public async Task<IActionResult> GetAdminNotifications(HttpContext httpContext, int pageNumber, int pageSize)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userId == null || userRole!.ToLower() != "admin") return Unauthorized();

            // Lấy danh sách thông báo của admin từ cơ sở dữ liệu
            var notifications = await _context.Notifications.Select(notification => new
            {
                notification.Id,
                notification.AdminMessage,
                notification.CreateDate
            })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .OrderByDescending(notification => notification.CreateDate)
            .ToListAsync();
            return Ok(notifications);
        }

        // Phương thức admin lấy thông báo của người dùng
        public async Task<IActionResult> AdminGetUserNotifications(HttpContext httpContext, Guid userId)
        {
            var adminId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (adminId == null || userRole!.ToLower() != "admin") return Unauthorized();

            // Lấy danh sách thông báo của người dùng từ cơ sở dữ liệu
            var notifications = await _context.Notifications
            .Where(notification => notification.UserId == userId)
            .Select(notification => new
            {
                notification.Id,
                notification.AdminMessage,
                notification.UserMessage,
                notification.CreateDate
            })
            .OrderByDescending(notification => notification.CreateDate)
            .ToListAsync();
            return Ok(notifications);
        }
        #endregion
    }
}