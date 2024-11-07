// DatabaseSeeder.cs
using System.Net;
using BackEnd_ASP.NET.Data;
using BackEnd_ASP_NET.Models;
using BackEnd_ASP_NET.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;

public class DatabaseSeeder
{
    private readonly ShUEHContext _context;
    private readonly UserManager<User> _userManager;
    private readonly Random _random = new Random();

    public DatabaseSeeder(ShUEHContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task SeedData(List<Guid> shoeIds)
    {
        List<Guid> roleIds = CreateRole();
        List<Guid> userIds = await CreateUsersAsync(roleIds[1], roleIds[0]);
        RandomSiteViewAndProductView(shoeIds);
        List<OrderItem> orderItems = SeedOrders(userIds, shoeIds);
        RandomDiscountData();
        RandomCommentData(shoeIds, userIds, orderItems);
        _context.SaveChanges();
    }
    #region Seed Data
    private void RandomDiscountData(){
        var discount = new List<Discount>();
        
        for(int i = 0; i < 10; i++){
            decimal? percentage = _random.Next(0, 2) == 0 ? null : (decimal?)_random.Next(10, 50);
            discount.Add(new Discount{
                Id = Guid.NewGuid(),
                Code = GenerateRandomCode(),
                IsPublic = _random.Next(0, 2) == 0,
                Percentage = percentage,
                Amount = percentage == null ? (decimal)_random.Next(100000, 500000) : null,
                Type = (DiscountType)_random.Next(0, Enum.GetValues(typeof(DiscountType)).Length),
                Quantity = _random.Next(100, 200),
                MaximumDiscount = percentage != null ? (decimal?)_random.Next(100000, 500000) : null,
                MinimumOrder = _random.Next(1000000, 5000000),
                ExpiryDate = DateTime.UtcNow.AddMonths(_random.Next(1, 12)),
                CreateDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow
            });
        }
        _context.Discounts.AddRange(discount);
        _context.SaveChanges();
    }
    private void RandomCommentData(List<Guid> shoeIds, List<Guid> userIds, List<OrderItem> orderItems)
    {

        Random random = new Random();
        for (int i = 0; i < shoeIds.Count; i++)
        {
            Guid shoeId = shoeIds[i];
            int totalComments = random.Next(1, 7);
            for (int j = 0; j < totalComments; j++)
            {
                Guid commentId = Guid.NewGuid();
                decimal rate = Math.Round((decimal)random.NextDouble() * 5, 1);
                if (rate == 0) rate = 5;
                GeneralReview generalReview = rate switch
                {
                    >= 5 => GeneralReview.VeryGood,
                    >= 4 => GeneralReview.Good,
                    >= 3 => GeneralReview.Average,
                    >= 2 => GeneralReview.Bad,
                    _ => GeneralReview.VeryBad
                };
                
                OrderItem? orderItem = orderItems.Where(item => item.ShoeId == shoeId).FirstOrDefault();
                if (orderItem == null) continue;
                _context.Comments.Add(
                    new Comment
                    {
                        Id = commentId,
                        ShoeId = shoeId,
                        GeneralReview = generalReview,
                        UserId = userIds[random.Next(0, userIds.Count)],
                        Description = GenerateRandomDescription(),
                        OrderItemId = orderItem.Id,
                        Rate = rate,
                        Size = orderItem.Size,
                        CreateDate = DateTime.Now.AddDays(-random.Next(0, 50)),// Random date within the last 30 days
                        LastModifiedDate = DateTime.Now
                    }
                );
                _context.SaveChanges();
                int totalLike = random.Next(0, 25);
                for (int k = 0; k < totalLike; k++)
                {
                    _context.CommentLikes.Add(
                        new CommentLike { Id = Guid.NewGuid(), CommentId = commentId, UserId = userIds[random.Next(0, userIds.Count)] }
                    );
                }
                _context.SaveChanges();
            }

        }
        _context.SaveChanges();
    }
    private List<Guid> CreateRole()
    {
        var adminRoleId = Guid.NewGuid();
        var userRoleId = Guid.NewGuid();
        _context.Roles.Add(new Role { Id = adminRoleId, Name = "Admin", Description = "Role Admin với đầy đủ các quyền hạn" });
        _context.Roles.Add(new Role { Id = userRoleId, Name = "User", Description = "Role User với các quyền hạn có giới hạn và mua hàng" });
        _context.SaveChanges();
        return new List<Guid> { adminRoleId, userRoleId };
    }
    private async Task<List<Guid>> CreateUsersAsync(Guid userRoleId, Guid adminRoleId)
    {
        const int userCount = 178;
        var users = new List<User>();
        List<Guid> userIds = new List<Guid>();
        for (int i = 0; i < userCount; i++)
        {
            Guid userId = Guid.NewGuid();
            User user;
            if (i == 0)
            {
                user = new User
                {
                    Id = userId,
                    FirstName = "Mach Gia",
                    LastName = "Huy",
                    DateOfBirth = "14/11/2004".ToDateTime(), // Sử dụng hàm chuyển đổi
                    Gender = true,
                    TotalMoney = 1000m,
                    RoleId = adminRoleId, // Gán vai trò Admin
                    Email = "machgiahuy@gmail.com",
                    NormalizedEmail = "MACHGIAHUY@EXAMPLE.COM",
                    UserName = "machgiahuy",
                    NormalizedUserName = "MACHGIAHUY",
                    AvatarUrl = $"/images/avatars/noavatar.png",
                    ProfileName = $"Mach Gia Huy",
                    IsExternalLogin = false,
                    ProviderName = "Local",
                    EmailConfirmed = true, // Xác nhận email
                    CreateDate = GenerateRandomCreationDate(),
                    LastModifiedDate = DateTime.UtcNow
                };

            }
            else
            {
                // Sinh ra ngày sinh dạng chuỗi
                string dobString = GenerateRandomDateOfBirthString();
                string firstName = GenerateRandomFirstName();
                string lastName = GenerateRandomLastName();
                string userName = $"{firstName}{lastName}";

                // Tạo user
                user = new User
                {
                    Id = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dobString.ToDateTime(), // Sử dụng hàm chuyển đổi
                    Gender = _random.Next(0, 2) == 0, // Random giới tính
                    TotalMoney = 1000m,
                    RoleId = userRoleId, // Gán vai trò Guest
                    Email = $"{userName}@example.com",
                    NormalizedEmail = $"{userName.ToUpper()}@EXAMPLE.COM",
                    UserName = userName,
                    NormalizedUserName = userName.ToUpper(),
                    AvatarUrl = $"/images/avatars/noavatar.png",
                    ProfileName = $"{firstName} {lastName}",
                    IsExternalLogin = false,
                    ProviderName = "Local",
                    EmailConfirmed = true, // Xác nhận email
                    CreateDate = GenerateRandomCreationDate(),
                    LastModifiedDate = DateTime.UtcNow
                };
            }
            var result = await _userManager.CreateAsync(user, "Test123456");
            if (!result.Succeeded)
            {
                Console.WriteLine($"Error creating user {user.UserName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
            else
            {
                userIds.Add(userId);
                users.Add(user);
            }
        }

        Console.WriteLine($"Created {users.Count} users.");
        return userIds;
    }
    private void RandomSiteViewAndProductView(List<Guid> shoeIds)
    {
        const int minViewsPerProduct = 75;
        const int maxViewsPerProduct = 100;
        const int monthsBack = 6;

        for (int i = 0; i < monthsBack; i++)
        {
            DateTime month = DateTime.UtcNow.AddMonths(-i).Date;
            SeedSiteViews(month);
        }


        foreach (var shoeId in shoeIds)
        {
            for (int i = 0; i < monthsBack; i++)
            {
                DateTime month = DateTime.UtcNow.AddMonths(-i).Date;
                int viewsToGenerate = _random.Next(minViewsPerProduct, maxViewsPerProduct);
                SeedProductViews(shoeId, month, viewsToGenerate);
            }
        }
    }
    private void SeedSiteViews(DateTime month)
    {
        int numberOfRecords = _random.Next(150, 200);
        var siteViews = new List<SiteView>();

        for (int i = 0; i < numberOfRecords; i++)
        {
            siteViews.Add(new SiteView
            {
                Id = Guid.NewGuid(),
                Ipaddress = GenerateRandomPublicIpAddress(),
                Device = GenerateRandomDevice(),
                ViewedDate = month
            });
            if (i % 30 == 0)
            {
                _context.SiteViews.AddRange(siteViews);
                _context.SaveChanges();
                siteViews.Clear();
            }
        }

        if (siteViews.Any())
        {
            _context.SiteViews.AddRange(siteViews);
            _context.SaveChanges();
        }
    }
    private List<OrderItem> SeedOrders(List<Guid> userIds, List<Guid> shoeIds)
    {
        const int orderCount = 178; // số lượng đơn hàng cần seed
        var orders = new List<Order>();
        var _orderItems = new List<OrderItem>();
        for (int i = 0; i < orderCount; i++)
        {
            var orderId = Guid.NewGuid();
            var userId = userIds[_random.Next(userIds.Count)];
            DateTime orderDate = DateTime.UtcNow.AddMonths(-_random.Next(0, 6));
            var orderItems = GenerateOrderItems(orderId, shoeIds);

            var totalOrderPrice = orderItems.Sum(item => item.TotalPrice);

            var order = new Order
            {
                Id = orderId,
                UserId = userId,
                OrderDate = orderDate,
                TotalPrice = totalOrderPrice,
                Status = (OrderStatus)_random.Next(0, Enum.GetValues(typeof(OrderStatus)).Length),
                PaymentMethod = (PaymentMethod)_random.Next(0, Enum.GetValues(typeof(PaymentMethod)).Length),
                OrderItems = orderItems,
                CreateDate = orderDate,
                LastModifiedDate = DateTime.UtcNow
            };

            orders.Add(order);
            _orderItems.AddRange(orderItems);
            if (i % 10 == 0)
            {
                _context.Orders.AddRange(orders);
                _context.SaveChanges();
                orders.Clear();
            }
        }

        if (orders.Any())
        {
            _context.Orders.AddRange(orders);
            _context.SaveChanges();
        }
        return _orderItems;
    }
    private void SeedProductViews(Guid productId, DateTime month, int viewsToGenerate)
    {
        var productViews = new List<ProductView>();

        for (int i = 0; i < viewsToGenerate; i++)
        {
            productViews.Add(new ProductView
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                UserId = Guid.NewGuid(),
                IPAddress = null,
                ViewedDate = month.AddDays(_random.Next(1, 28)).AddHours(_random.Next(24)).AddMinutes(_random.Next(60))
            });
            if (i % 20 == 0)
            {
                _context.ProductViews.AddRange(productViews);
                _context.SaveChanges();
                productViews.Clear();
            }
        }

        if (productViews.Any())
        {
            _context.ProductViews.AddRange(productViews);
            _context.SaveChanges();
        }
    }
    private List<OrderItem> GenerateOrderItems(Guid orderId, List<Guid> shoeIds)
    {
        const int maxItemsPerOrder = 4;
        int itemCount = _random.Next(1, maxItemsPerOrder);

        var orderItems = new List<OrderItem>();

        for (int i = 0; i < itemCount; i++)
        {
            var shoeId = shoeIds[_random.Next(shoeIds.Count)];
            int quantity = _random.Next(1, 5);
            decimal shoePrice = _random.Next(1000000, 3000000); // Đơn giá của mỗi sản phẩm giày
            decimal totalPrice = shoePrice * quantity;

            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ShoeId = shoeId,
                Size = _random.Next(36, 46), // Giả sử các size từ 38-45
                Quantity = quantity,
                ShoePrice = shoePrice,
                TotalPrice = totalPrice,
                IsReviewed = _random.Next(0, 2) == 0
            };

            orderItems.Add(orderItem);
        }

        return orderItems;
    }
    #endregion
    #region Generate Extension
    
    private string GenerateRandomCode()
    {
        return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
    }
    // Tạo chuỗi ngày sinh ngẫu nhiên dạng "dd/MM/yyyy"
    private string GenerateRandomDateOfBirthString()
    {
        int yearsBack = _random.Next(18, 60);
        DateTime randomDob = DateTime.UtcNow.AddYears(-yearsBack).AddDays(_random.Next(-365, 365));
        return randomDob.ToString("dd/MM/yyyy");
    }

    // Các hàm khác (tạo tên, thời gian tạo ngẫu nhiên) giữ nguyên
    private string GenerateRandomFirstName()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Bảng chữ cái
        int nameLength = _random.Next(4, 8); // Độ dài tên từ 4-8 ký tự

        return GenerateRandomNameFromChars(chars, nameLength);
    }

    private string GenerateRandomLastName()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Bảng chữ cái
        int nameLength = _random.Next(4, 8); // Độ dài tên từ 4-8 ký tự

        return GenerateRandomNameFromChars(chars, nameLength);
    }

    private string GenerateRandomNameFromChars(string chars, int length)
    {
        char[] name = new char[length];
        for (int i = 0; i < length; i++)
        {
            name[i] = chars[_random.Next(chars.Length)];
        }
        return new string(name);
    }

    private DateTime GenerateRandomCreationDate()
    {
        return DateTime.UtcNow.AddMonths(-_random.Next(0, 6));
    }
    private static string GenerateRandomPublicIpAddress()
    {
        var random = new Random();
        byte[] data;

        do
        {
            data = new byte[4];
            random.NextBytes(data);
        } while (data[0] == 10 ||
                 (data[0] == 172 && (data[1] >= 16 && data[1] <= 31)) ||
                 (data[0] == 192 && data[1] == 168));

        IPAddress ip = new IPAddress(data);
        return ip.ToString();
    }

    private static string GenerateRandomDevice()
    {
        string[] devices = { "Laptop", "Desktop", "Mobile", "Tablet" };
        return devices[new Random().Next(devices.Length)];
    }
    private string GenerateRandomDescription()
    {
        string[] descriptions = {
                "Perfect for all sports activities.",
                "Provides excellent comfort and support.",
                "Stylish design for both casual and athletic wear.",
                "Lightweight and durable for high-performance.",
                "Designed for optimum traction on various surfaces.",
                "Breathable material keeps your feet cool and dry.",
                "A versatile shoe for any occasion.",
                "Enhances performance and boosts confidence."
            };
        Random random = new Random();
        // Chọn ngẫu nhiên một mô tả từ danh sách
        return descriptions[random.Next(descriptions.Length)];
    }
    #endregion
}
