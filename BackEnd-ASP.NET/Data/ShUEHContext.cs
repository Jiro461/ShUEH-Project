using BackEnd_ASP_NET.Models;
using BackEnd_ASP_NET.Utilities.Extensions;
using BackEnd_ASP_NET.Utilities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace BackEnd_ASP.NET.Data
{
    public class ShUEHContext : DbContext
    {
        public ShUEHContext(DbContextOptions<ShUEHContext> options) : base(options)
        {

        }
        public override int SaveChanges()
        {
            UpdateDateTracking();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateDateTracking();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateDateTracking()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is IDateTracking &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var dateTrackingEntity = (IDateTracking)entry.Entity;

                // Sử dụng DateTimeOffset cho thời gian với múi giờ Việt Nam
                var vietnamTime = DateTimeOffset.UtcNow.AddHours(7); // UTC+7

                if (entry.State == EntityState.Added)
                {
                    dateTrackingEntity.CreateDate = vietnamTime.DateTime; // Cập nhật thời gian tạo
                }

                dateTrackingEntity.LastModifiedDate = vietnamTime.DateTime; // Cập nhật thời gian sửa đổi
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Thực hiện Seed Data
            // Seed Data cho Roles
            var adminRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = adminRoleId, Name = "Admin", Description = "Role Admin với đầy đủ các quyền hạn" },
                new Role { Id = userRoleId, Name = "User", Description = "Role User với các quyền hạn có giới hạn và mua hàng" }
            );

            // Seed Data cho Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mach",
                    LastName = "Gia Huy",
                    DateOfBirth = "14/11/2004".ToDateTime(), // Hoặc dùng phương thức ToDateTime của bạn
                    Gender = true,
                    TotalMoney = 1000m,
                    RoleId = adminRoleId,  // Gán RoleId cho Admin
                    WistlistId = null, // Nếu có Wishlist thì cung cấp WishlistId
                    Email = "john.doe@example.com",
                    NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                    UserName = "Mach Gia Huy",
                    NormalizedUserName = "JOHN.DOE",
                    EmailConfirmed = false,
                    PasswordHash = "12345678".ToSHA256() // Hàm ToSHA256() của bạn
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = "10/05/2004".ToDateTime(), // Hoặc dùng phương thức ToDateTime của bạn
                    Gender = false,
                    TotalMoney = 1500m,
                    RoleId = userRoleId, // Gán RoleId cho User
                    WistlistId = null, // Nếu có Wishlist thì cung cấp WishlistId
                    Email = "jane.smith@example.com",
                    NormalizedEmail = "JANE.SMITH@EXAMPLE.COM",
                    UserName = "jane.smith",
                    NormalizedUserName = "JANE.SMITH",
                    EmailConfirmed = false,
                    PasswordHash = "12345678".ToSHA256() // Hàm ToSHA256() của bạn
                }
            );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<ShoeColor> ShoeColors { get; set; }
        public DbSet<ShoeSeason> ShoeSeasons { get; set; }
        public DbSet<ShoeSize> ShoeSizes { get; set; }
        public DbSet<ShoeImage> ShoeImages { get; set; }
    }
}
