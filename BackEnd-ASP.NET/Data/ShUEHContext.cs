using BackEnd_ASP_NET.Models;
using BackEnd_ASP_NET.Utilities.Extensions;
using BackEnd_ASP_NET.Utilities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
                var vietnamTime = MyDateTime.VietNam; // UTC+7

                if (entry.State == EntityState.Added)
                {
                    dateTrackingEntity.CreateDate = vietnamTime.DateTime; // Cập nhật thời gian tạo
                }

                dateTrackingEntity.LastModifiedDate = vietnamTime.DateTime; // Cập nhật thời gian sửa đổi
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Roles
            var adminRoleId = Guid.NewGuid();
            var userRoleId = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = adminRoleId, Name = "Admin", Description = "Role Admin với đầy đủ các quyền hạn" },
                new Role { Id = userRoleId, Name = "User", Description = "Role User với các quyền hạn có giới hạn và mua hàng" }
            );

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mach",
                    LastName = "Gia Huy",
                    DateOfBirth = "14/11/2204".ToDateTime(), // Adjust your date creation here
                    Gender = true,
                    TotalMoney = 1000m,
                    RoleId = adminRoleId, // Use RoleId here
                    Email = "machgiahuy@gmail.com",
                    NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                    UserName = "Mach Gia Huy",
                    NormalizedUserName = "JOHN.DOE",
                    EmailConfirmed = false,
                    PasswordHash = "12345678".ToSHA256() // Adjust your hashing method here
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = "10/05/2004".ToDateTime(), // Adjust your date creation here
                    Gender = false,
                    TotalMoney = 1500m,
                    RoleId = userRoleId, // Use RoleId here
                    Email = "jane.smith@example.com",
                    NormalizedEmail = "JANE.SMITH@EXAMPLE.COM",
                    UserName = "jane.smith",
                    NormalizedUserName = "JANE.SMITH",
                    EmailConfirmed = false,
                    PasswordHash = "12345678".ToSHA256() // Adjust your hashing method here
                }
            );

            ShoeSeeding(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }

        private void ShoeSeeding(ModelBuilder modelBuilder)
        {
            Guid IDGiay_1 = Guid.NewGuid();
            Guid IDGiay_2 = Guid.NewGuid();
            Guid IDGiay_3 = Guid.NewGuid();
            Guid IDGiay_4 = Guid.NewGuid();
            Guid IDGiay_5 = Guid.NewGuid();
            Guid IDGiay_6 = Guid.NewGuid();
            Guid IDGiay_7 = Guid.NewGuid();
            Guid IDGiay_8 = Guid.NewGuid();
            Guid IDGiay_9 = Guid.NewGuid();
            Guid IDGiay_10 = Guid.NewGuid();
            Guid IDGiay_11 = Guid.NewGuid();
            Guid IDGiay_12 = Guid.NewGuid();
            Guid IDGiay_13 = Guid.NewGuid();
            Guid IDGiay_14 = Guid.NewGuid();
            Guid IDGiay_15 = Guid.NewGuid();
            Guid IDGiay_16 = Guid.NewGuid();
            Guid IDGiay_17 = Guid.NewGuid();
            Guid IDGiay_18 = Guid.NewGuid();
            Guid IDGiay_19 = Guid.NewGuid();
            Guid IDGiay_20 = Guid.NewGuid();
            Guid IDGiay_21 = Guid.NewGuid();
            Guid IDGiay_22 = Guid.NewGuid();
            Guid IDGiay_23 = Guid.NewGuid();
            Guid IDGiay_24 = Guid.NewGuid();
            Guid IDGiay_25 = Guid.NewGuid();
            Guid IDGiay_26 = Guid.NewGuid();
            Guid IDGiay_27 = Guid.NewGuid();
            Guid IDGiay_28 = Guid.NewGuid();
            Guid IDGiay_29 = Guid.NewGuid();
            // Seed data shoe
            modelBuilder.Entity<Shoe>().HasData(

                // NIKE 1
                new Shoe
                {
                    Id = IDGiay_1,
                    Name = "Giannis Immortality 4",
                    Brand = "Nike",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Gym & Training",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "On any given night, Giannis can impact a game from any position. " +
                    "Lace up his latest signature shoe and leave your own mark, whatever the playing surface. " +
                    "Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. " +
                    "Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n",
                    Price = 1909000m,
                    Stock = 72,
                    Sold = 28,
                    AverageRating = 4.5M,
                    TotalRatings = 20,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                // NIKE 2
                new Shoe
                {
                    Id = IDGiay_2,
                    Name = "Nike G.T. Cut 3",
                    Brand = "Nike",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Basketball",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. " +
                    "Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. " +
                    "The light and springy foam helps cushion every step so you can cut and create space in comfort. " +
                    "Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.",
                    Price = 2419000m,
                    Stock = 80,
                    Sold = 50,
                    AverageRating = 4.7M,
                    TotalRatings = 45,
                    IsSale = true,
                    Discount = 15.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                // NIKE 3
                new Shoe
                {
                    Id = IDGiay_3,
                    Name = "Jr. Mercurial Vapor 16 Pro",
                    Brand = "Nike",
                    Gender = 1,
                    Material = "Leather, fabric and rubber.",
                    Category = "Football",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Serious about your game? Wanna run fast so you can score goals? " +
                     "The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. " +
                     "It gives you and those devoted to the game the propulsive feel needed to break through the back line. " +
                     "Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.",
                    Price = 4109000m,
                    Stock = 92,
                    Sold = 13,
                    AverageRating = 4.8M,
                    TotalRatings = 10,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                // NIKE 4
                new Shoe
                {
                    Id = IDGiay_4,
                    Name = "NikeCourt Legacy",
                    Brand = "Nike",
                    Gender = 1,
                    Material = "Leather, fabric, and rubber.",
                    Category = "Tennis",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "The NikeCourt Legacy serves up style rooted in tennis culture. " +
                    "They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.",
                    Price = 1279000m,
                    Stock = 40,
                    Sold = 7,
                    AverageRating = 4.2M,
                    TotalRatings = 5,
                    IsSale = true,
                    Discount = 30.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                // NIKE 5
                new Shoe
                {
                    Id = IDGiay_5,
                    Name = "Luka 2",
                    Brand = "Nike",
                    Gender = 2,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Yoga",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. " +
                    "A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. " +
                    "Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. " +
                    "With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.",
                    Price = 1784299m,
                    Stock = 156,
                    Sold = 89,
                    AverageRating = 4.9M,
                    TotalRatings = 66,
                    IsSale = true,
                    Discount = 30.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                // ADIDAS 1
                new Shoe
                {
                    Id = IDGiay_6,
                    Name = "TRAE YOUNG 3 BASKETBALL SHOES",
                    Brand = "Adidas",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Basketball",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. " +
                    "Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. " +
                    "The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.",
                    Price = 4200000m,
                    Stock = 700,
                    Sold = 456,
                    AverageRating = 4.8M,
                    TotalRatings = 381,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                // ADIDAS 2
                new Shoe
                {
                    Id = IDGiay_7,
                    Name = "Predator Club Sock Turf Football Boots",
                    Brand = "Adidas",
                    Gender = 1,
                    Material = "Leather, fabric, and rubber.",
                    Category = "Football",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "The game's all about goals, and these football boots are crafted to find the net. " +
                    "Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. " +
                    "Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\n" +
                    "This product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.",
                    Price = 1600000m,
                    Stock = 100,
                    Sold = 44,
                    AverageRating = 4.4M,
                    TotalRatings = 37,
                    IsSale = true,
                    Discount = 15.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                // ADIDAS 3
                new Shoe
                {
                    Id = IDGiay_8,
                    Name = "Dropset 3 Shoes",
                    Brand = "Adidas",
                    Gender = 2,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Gym & Training",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.",
                    Price = 3500000m,
                    Stock = 200,
                    Sold = 120,
                    AverageRating = 4.4M,
                    TotalRatings = 84,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                // ADIDAS 4
                new Shoe
                {
                    Id = IDGiay_9,
                    Name = "Dropset 2 Trainer",
                    Brand = "Adidas",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Gym & Training",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.",
                    Price = 2450000m,
                    Stock = 500,
                    Sold = 390,
                    AverageRating = 4.6M,
                    TotalRatings = 268,
                    IsSale = true,
                    Discount = 30.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                // ADIDAS 5
                new Shoe
                {
                    Id = IDGiay_10,
                    Name = "D.O.N. Issue 6 Shoes",
                    Brand = "Adidas",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Basketball",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.",
                    Price = 3200000m,
                    Stock = 50,
                    Sold = 23,
                    AverageRating = 4.7M,
                    TotalRatings = 3,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //PUMA 1
                new Shoe
                {
                    Id = IDGiay_11,
                    Name = "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes",
                    Brand = "Puma",
                    Gender = 1,
                    Material = "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile",
                    Category = "Basketball",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.",
                    Price = 3300000m,
                    Stock = 100,
                    Sold = 32,
                    AverageRating = 4.0M,
                    TotalRatings = 21,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //PUMA 2
                new Shoe
                {
                    Id = IDGiay_12,
                    Name = "ATTACANTO Turf Training Men's Soccer Cleats",
                    Brand = "Puma",
                    Gender = 1,
                    Material = "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile",
                    Category = "Football",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball",
                    Price = 1800000m,
                    Stock = 100,
                    Sold = 76,
                    AverageRating = 4.2M,
                    TotalRatings = 17,
                    IsSale = true,
                    Discount = 30.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //PUMA 3
                new Shoe
                {
                    Id = IDGiay_13,
                    Name = "PWRSPIN Indoor Cycling Shoes",
                    Brand = "Puma",
                    Gender = 1,
                    Material = "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile",
                    Category = "Gym & Training",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n",
                    Price = 2900000m,
                    Stock = 100,
                    Sold = 54,
                    AverageRating = 4.5M,
                    TotalRatings = 23,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //PUMA 4
                new Shoe
                {
                    Id = IDGiay_14,
                    Name = "Easy Rider Supertifo Women's Sneakers",
                    Brand = "Puma",
                    Gender = 2,
                    Material = "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.",
                    Category = "Yoga",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic",
                    Price = 2300000m,
                    Stock = 100,
                    Sold = 65,
                    AverageRating = 4.1M,
                    TotalRatings = 22,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //PUMA 5
                new Shoe
                {
                    Id = IDGiay_15,
                    Name = "SOFTRIDE Divine Running Shoes Women",
                    Brand = "Puma",
                    Gender = 2,
                    Material = "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile",
                    Category = "Gym & Training",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n",
                    Price = 1750000m,
                    Stock = 200,
                    Sold = 123,
                    AverageRating = 4.7M,
                    TotalRatings = 87,
                    IsSale = true,
                    Discount = 40.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //REEBOK 1
                new Shoe
                {
                    Id = IDGiay_16,
                    Name = "Reebok NFX Trainer",
                    Brand = "Reebok",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Gym & Training",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.",
                    Price = 2490000m,
                    Stock = 90,
                    Sold = 30,
                    AverageRating = 4.5M,
                    TotalRatings = 25,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //REEBOK 2
                new Shoe
                {
                    Id = IDGiay_17,
                    Name = "Unisex Reebok Club C Bulc",
                    Brand = "Reebok",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Tennis",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n",
                    Price = 2690000m,
                    Stock = 100,
                    Sold = 41,
                    AverageRating = 4.6M,
                    TotalRatings = 20,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //REBOK 3
                new Shoe
                {
                    Id = IDGiay_18,
                    Name = "Club C 85",
                    Brand = "Reebok",
                    Gender = 2,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Tennis",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.",
                    Price = 1990000m,
                    Stock = 100,
                    Sold = 35,
                    AverageRating = 4.3M,
                    TotalRatings = 12,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //REEBOK 4
                new Shoe
                {
                    Id = IDGiay_19,
                    Name = "Unisex Reebok The Blast",
                    Brand = "Reebok",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Basketball",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n",
                    Price = 3990000m,
                    Stock = 200,
                    Sold = 134,
                    AverageRating = 4.8M,
                    TotalRatings = 111,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //REEBOK 5
                new Shoe
                {
                    Id = IDGiay_20,
                    Name = "QUESTION LOW",
                    Brand = "Reebok",
                    Gender = 2,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Basketball",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.",
                    Price = 3590000m,
                    Stock = 100,
                    Sold = 22,
                    AverageRating = 4.7M,
                    TotalRatings = 10,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //CONVERSE 1
                new Shoe
                {
                    Id = IDGiay_21,
                    Name = "Run Star Trainer",
                    Brand = "Converse",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Gym & Training",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos",
                    Price = 1900000m,
                    Stock = 100,
                    Sold = 20,
                    AverageRating = 4.3M,
                    TotalRatings = 10,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //CONVERSE 2
                new Shoe
                {
                    Id = IDGiay_22,
                    Name = "Chuck 70 AT-CX",
                    Brand = "Converse",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Gym & Training",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel",
                    Price = 2500000m,
                    Stock = 80,
                    Sold = 67,
                    AverageRating = 4.9M,
                    TotalRatings = 45,
                    IsSale = false,
                    Discount = 0.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //CONVERSE 3
                new Shoe
                {
                    Id = IDGiay_23,
                    Name = "Converse x OLD MONEY Weapon\r\n",
                    Brand = "Converse",
                    Gender = 1,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Basketball",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.",
                    Price = 2170000m,
                    Stock = 120,
                    Sold = 56,
                    AverageRating = 4.4M,
                    TotalRatings = 34,
                    IsSale = true,
                    Discount = 20.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //CONVERSE 4
                new Shoe
                {
                    Id = IDGiay_24,
                    Name = "Weapon",
                    Brand = "Converse",
                    Gender = 2,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Gym & Training",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy",
                    Price = 2500000m,
                    Stock = 200,
                    Sold = 156,
                    AverageRating = 4.9M,
                    TotalRatings = 100,
                    IsSale = true,
                    Discount = 10.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                //CONVERSE5
                new Shoe
                {
                    Id = IDGiay_25,
                    Name = "Converse Cruise",
                    Brand = "Converse",
                    Gender = 2,
                    Material = "Leather, fabric, foam, and rubber.",
                    Category = "Yoga",
                    ImageUrl = "images/shoes/noimage.webp",
                    Description = "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy",
                    Price = 1520000m,
                    Stock = 70,
                    Sold = 60,
                    AverageRating = 4.7M,
                    TotalRatings = 30,
                    IsSale = true,
                    Discount = 22.0M,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                },

                 // ( Lil Nas X)
                 new Shoe
                 {
                     Id = IDGiay_26,
                     Name = "Satan ",
                     Brand = "Nike",
                     Gender = 1,
                     Material = "Leather, fabric, foam, and rubber.",
                     Category = "Basketball",
                     ImageUrl = "images/shoes/noimage.webp",
                     Description = "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”",
                     Price = 10460000m,
                     Stock = 17,
                     Sold = 7,
                     AverageRating = 7M,
                     TotalRatings = 5,
                     IsSale = false,
                     Discount = 0.0M,
                     CreateDate = DateTime.Now,
                     LastModifiedDate = DateTime.Now
                 },

                 // Transparent Nike
                 new Shoe
                 {
                     Id = IDGiay_27,
                     Name = "Jordan 1 Low Bred Toe 2.0",
                     Brand = "Nike",
                     Gender = 1,
                     Material = "Leather, fabric, foam, and rubber.",
                     Category = "Basketball",
                     ImageUrl = "images/shoes/noimage.webp",
                     Description = "One of the best shoes for basketball and the symbol of Nike's World. You won't be able to take your eyes off of this brand new Jordan, where every details have been scopefully arted.",
                     Price = 1813000m,
                     Stock = 100,
                     Sold = 45,
                     AverageRating = 4.6M,
                     TotalRatings = 23,
                     IsSale = true,
                     Discount = 20.0M,
                     CreateDate = DateTime.Now,
                     LastModifiedDate = DateTime.Now
                 },

                 // Transparent Adidas
                 new Shoe
                 {
                     Id = IDGiay_28,
                     Name = "Adidas Original StanSmith",
                     Brand = "Adidas",
                     Gender = 1,
                     Material = "Leather, fabric, foam, and rubber.",
                     Category = "Basketball",
                     ImageUrl = "images/shoes/noimage.webp",
                     Description = "One of the best shoes for basketball and the symbol of Adidas's World. You won't be able to take your eyes off of this brand new SuperStan, where every details have been scopefully arted.",
                     Price = 1713000m,
                     Stock = 100,
                     Sold = 65,
                     AverageRating = 4.2M,
                     TotalRatings = 33,
                     IsSale = true,
                     Discount = 20.0M,
                     CreateDate = DateTime.Now,
                     LastModifiedDate = DateTime.Now
                 },

                 // Transparent Puma
                 new Shoe
                 {
                     Id = IDGiay_29,
                     Name = "Puma FUTURE 7 Ultimate FG/AG The Forever Faster",
                     Brand = "Puma",
                     Gender = 1,
                     Material = "Leather, fabric, foam, and rubber.",
                     Category = "Football",
                     ImageUrl = "images/shoes/noimage.webp",
                     Description = "One of the best shoes for football and the symbol of Puma's World. You won't be able to take your eyes off of this brand new FUTURE, where every details have been scopefully arted.",
                     Price = 2713000m,
                     Stock = 100,
                     Sold = 78,
                     AverageRating = 4.7M,
                     TotalRatings = 55,
                     IsSale = true,
                     Discount = 20.0M,
                     CreateDate = DateTime.Now,
                     LastModifiedDate = DateTime.Now
                 }
            );

            //ShoeColor Seeding
            modelBuilder.Entity<ShoeColor>().HasData(
            // NIKE 1 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Color = "Blue"
                },
                new ShoeColor
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                },
                new ShoeColor
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),

                    Color = "White"
                },
                new ShoeColor
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),

                    Color = "Purple"
                },
                // NIKE 2 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),

                    Color = "Red"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),

                    Color = "Black"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),

                    Color = "White"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),

                    Color = "Blue"
                },
                // NIKE 3 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_3,
                    Id = Guid.NewGuid(),

                    Color = "Yellow"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_3,
                    Id = Guid.NewGuid(),

                    Color = "White"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_3,
                    Id = Guid.NewGuid(),

                    Color = "Black"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_3,
                    Id = Guid.NewGuid(),

                    Color = "Pink"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_3,
                    Id = Guid.NewGuid(),

                    Color = "Blue"
                },
                // NIKE 4 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Color = "White"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Color = "Brown"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                },
                // NIKE 5 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_5,
                    Id = Guid.NewGuid(),
                    Color = "White"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_5,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_5,
                    Id = Guid.NewGuid(),
                    Color = "Orange"
                },
                // ADIDAS 1 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Color = "Orange"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Color = "Green"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Color = "Blue"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Color = "White"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Color = "Red"
                },
                // ADIDAS 2 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Color = "Red"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Color = "Yellow"
                },
                new ShoeColor
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Color = "Pink"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),

                    Color = "White"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Color = "Red"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Color = "Blue"
                },
                // ADIDAS 4 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_9,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                },
                // ADIDAS 5 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Color = "Pink"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Color = "Purple"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Color = "White"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                },
                // PUMA 1 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_11,
                    Id = Guid.NewGuid(),
                    Color = "Orange"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_11,
                    Id = Guid.NewGuid(),
                    Color = "Purple"
                },
                // PUMA 2 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_12,
                    Id = Guid.NewGuid(),
                    Color = "Blue"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_12,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_12,
                    Id = Guid.NewGuid(),
                    Color = "Green"
                },
                // PUMA 3 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_13,
                    Id = Guid.NewGuid(),
                    Color = "Orange"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_13,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                },
                // PUMA 4 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_14,
                    Id = Guid.NewGuid(),
                    Color = "Pink"
                },
                // PUMA 5 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_15,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_15,
                    Id = Guid.NewGuid(),
                    Color = "White"
                },
                // REEBOK 1 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Color = "White"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Color = "Grey"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Color = "Blue"
                },
                // REEBOK 2 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_17,
                    Id = Guid.NewGuid(),
                    Color = "Blue"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_17,
                    Id = Guid.NewGuid(),
                    Color = "Pink"
                },
                // REEBOK 3 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_18,
                    Id = Guid.NewGuid(),
                    Color = "Blue"
                },
                // REEBOK 4 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_19,
                    Id = Guid.NewGuid(),
                    Color = "White"
                },
                // REEBOK 5 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_20,
                    Id = Guid.NewGuid(),
                    Color = "Blue"
                },
                // CONVERSE 1 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_21,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                },
                // CONVERSE 2 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Color = "Black"
                },
                // CONVERSE 3 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_23,
                    Id = Guid.NewGuid(),
                    Color = "Blue"
                },
                // CONVERSE 4 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_24,
                    Id = Guid.NewGuid(),
                    Color = "Brown"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_24,
                    Id = Guid.NewGuid(),
                    Color = "White"
                },
                // CONVERSE 5 Colors
                new ShoeColor
                {
                    ShoeId = IDGiay_25,
                    Id = Guid.NewGuid(),
                    Color = "Green"
                }, new ShoeColor
                {
                    ShoeId = IDGiay_25,
                    Id = Guid.NewGuid(),
                    Color = "Brown"
                }
            );
            //ShoeSeason Seeding
            modelBuilder.Entity<ShoeSeason>().HasData(
                new ShoeSeason
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                },

                //2
                new ShoeSeason
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),
                    Season = "Winter"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),
                    Season = "Fall"
                },

                //3
                new ShoeSeason
                {
                    ShoeId = IDGiay_3,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                },

                //4
                new ShoeSeason
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Season = "Fall"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Season = "Winter"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },

                //5
                new ShoeSeason
                {
                    ShoeId = IDGiay_5,
                    Id = Guid.NewGuid(),
                    Season = "Fall"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_5,
                    Id = Guid.NewGuid(),
                    Season = "Winter"
                },

                //6
                new ShoeSeason
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },

                //7
                new ShoeSeason
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Season = "Fall"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Season = "Winter"
                },

                //8
                new ShoeSeason
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                },

                //9
                new ShoeSeason
                {
                    ShoeId = IDGiay_9,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_9,
                    Id = Guid.NewGuid(),
                    Season = "Winter"
                },

                //10
                new ShoeSeason
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                },

                //11
                new ShoeSeason
                {
                    ShoeId = IDGiay_11,
                    Id = Guid.NewGuid(),
                    Season = "Fall"
                },

                //12
                new ShoeSeason
                {
                    ShoeId = IDGiay_12,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_12,
                    Id = Guid.NewGuid(),
                    Season = "Fall"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_12,
                    Id = Guid.NewGuid(),
                    Season = "Winter"
                },

                //13
                new ShoeSeason
                {
                    ShoeId = IDGiay_13,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },

                //14
                new ShoeSeason
                {
                    ShoeId = IDGiay_14,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_14,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },

                //15
                new ShoeSeason
                {
                    ShoeId = IDGiay_15,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                },

                //16
                new ShoeSeason
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                },
                new ShoeSeason
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Season = "Fall"
                },

                new ShoeSeason
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Season = "Winter"
                },

                //17
                new ShoeSeason
                {
                    ShoeId = IDGiay_17,
                    Id = Guid.NewGuid(),
                    Season = "Winter"
                },

                //18
                new ShoeSeason
                {
                    ShoeId = IDGiay_18,
                    Id = Guid.NewGuid(),
                    Season = "Summer"
                },
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_18,
                        Id = Guid.NewGuid(),
                        Season = "Spring"
                    },

                        //19
                        new ShoeSeason
                        {
                            ShoeId = IDGiay_19,
                            Id = Guid.NewGuid(),
                            Season = "Winter"
                        },

                    //20
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_20,
                        Id = Guid.NewGuid(),
                        Season = "Spring"
                    },
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_20,
                        Id = Guid.NewGuid(),
                        Season = "Summer"
                    },
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_20,
                        Id = Guid.NewGuid(),
                        Season = "Winter"
                    },

                    //21
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_21,
                        Id = Guid.NewGuid(),
                        Season = "Spring"
                    },
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_21,
                        Id = Guid.NewGuid(),
                        Season = "Summer"
                    },
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_21,
                        Id = Guid.NewGuid(),
                        Season = "Fall"
                    },
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_21,
                        Id = Guid.NewGuid(),
                        Season = "Winter"
                    },

                    //22
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_22,
                        Id = Guid.NewGuid(),
                        Season = "Summer"
                    },
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_22,
                        Id = Guid.NewGuid(),
                        Season = "Winter"
                    },

                    //23
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_23,
                        Id = Guid.NewGuid(),
                        Season = "Winter"
                    },

                    //24
                    new ShoeSeason
                    {
                        ShoeId = IDGiay_24,
                        Id = Guid.NewGuid(),
                        Season = "Spring"
                    },
                new ShoeSeason
                {
                    ShoeId = IDGiay_24,
                    Id = Guid.NewGuid(),
                    Season = "Fall"
                },

                //25
                new ShoeSeason
                {
                    ShoeId = IDGiay_25,
                    Id = Guid.NewGuid(),
                    Season = "Spring"
                }
            );

            //ShoeSize Seeding
            modelBuilder.Entity<ShoeSize>().HasData(
                //NIKE 1
                new ShoeSize
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_1,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                //NIKE 2
                new ShoeSize
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_2,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                //NIKE 3
                new ShoeSize
                {
                    ShoeId = IDGiay_3,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_3,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_3,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_3,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                //NIKE 4
                new ShoeSize
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_4,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                //NIKE 5
                new ShoeSize
                {
                    ShoeId = IDGiay_5,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_5,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_5,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_5,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_5,
                    Id = Guid.NewGuid(),
                    Size = 44
                },

                //ADIDAS 1
                new ShoeSize
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_6,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                //ADIDAS 2
                new ShoeSize
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_7,
                    Id = Guid.NewGuid(),
                    Size = 42
                },

                //ADIDAS 3
                new ShoeSize
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_8,
                    Id = Guid.NewGuid(),
                    Size = 42
                },

                // ADIDAS 4
                new ShoeSize
                {
                    ShoeId = IDGiay_9,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_9,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_9,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_9,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_9,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                // ADIDAS 5
                new ShoeSize
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_10,
                    Id = Guid.NewGuid(),
                    Size = 42
                },

                // PUMA 1
                new ShoeSize
                {
                    ShoeId = IDGiay_11,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_11,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_11,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                // PUMA 2
                new ShoeSize
                {
                    ShoeId = IDGiay_12,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_12,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_12,
                    Id = Guid.NewGuid(),
                    Size = 42
                },

                // PUMA 3
                new ShoeSize
                {
                    ShoeId = IDGiay_13,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_13,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_13,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_13,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_13,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_13,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_13,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                // PUMA 4
                new ShoeSize
                {
                    ShoeId = IDGiay_14,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_14,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_14,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_14,
                    Id = Guid.NewGuid(),
                    Size = 41
                },

                // PUMA 5
                new ShoeSize
                {
                    ShoeId = IDGiay_15,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_15,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                // REEBOK 1
                new ShoeSize
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_16,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                // REEBOK 2
                new ShoeSize
                {
                    ShoeId = IDGiay_17,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_17,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_17,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_17,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_17,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_17,
                    Id = Guid.NewGuid(),
                    Size = 41
                },

                // REEBOK 3
                new ShoeSize
                {
                    ShoeId = IDGiay_18,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_18,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_18,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_18,
                    Id = Guid.NewGuid(),
                    Size = 39
                },

                //REEBOK 4
                new ShoeSize
                {
                    ShoeId = IDGiay_19,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_19,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                //REEBOK 5   
                new ShoeSize
                {
                    ShoeId = IDGiay_20,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_20,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_20,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_20,
                    Id = Guid.NewGuid(),
                    Size = 40
                },

                //CONVERSE 1
                new ShoeSize
                {
                    ShoeId = IDGiay_21,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_21,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_21,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_21,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_21,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_21,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_21,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_21,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_21,
                    Id = Guid.NewGuid(),
                    Size = 45
                },
                //CONVERSE 2
                new ShoeSize
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Size = 39
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Size = 43
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_22,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                //CONVERSE 3
                new ShoeSize
                {
                    ShoeId = IDGiay_23,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_23,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_23,
                    Id = Guid.NewGuid(),
                    Size = 38
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_23,
                    Id = Guid.NewGuid(),
                    Size = 40
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_23,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_23,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_23,
                    Id = Guid.NewGuid(),
                    Size = 43
                },

                //CONVERSE 4
                new ShoeSize
                {
                    ShoeId = IDGiay_24,
                    Id = Guid.NewGuid(),
                    Size = 42
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_24,
                    Id = Guid.NewGuid(),
                    Size = 44
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_24,
                    Id = Guid.NewGuid(),
                    Size = 45
                },

                //CONVERSE 5
                new ShoeSize
                {
                    ShoeId = IDGiay_25,
                    Id = Guid.NewGuid(),
                    Size = 36
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_25,
                    Id = Guid.NewGuid(),
                    Size = 37
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_25,
                    Id = Guid.NewGuid(),
                    Size = 41
                },
                new ShoeSize
                {
                    ShoeId = IDGiay_25,
                    Id = Guid.NewGuid(),
                    Size = 44
                }
        );
        modelBuilder.Entity<ShoeImage>().HasData(
 // NIKE 1
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_1,
                            Url = "images/shoes/[IDGiay_1]_AnhChinh.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_1,
                            Url = "images/shoes/[IDGiay_1]_AnhPhu_1.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_1,
                            Url = "images/shoes/[IDGiay_1]_AnhPhu_2.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_1,
                            Url = "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_1,
                            Url = "images/shoes/[IDGiay_1]_AnhPhu_4.png"
                        },

                        //NIKE 2
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_2,
                            Url = "images/shoes/[IDGiay_2]_AnhChinh.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_2,
                            Url = "images/shoes/[IDGiay_2]_AnhPhu_1.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_2,
                            Url = "images/shoes/[IDGiay_2]_AnhPhu_2.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_2,
                            Url = "images/shoes/[IDGiay_2]_AnhPhu_3.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_2,
                            Url = "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg"
                        },

                        //NIKE 3
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_3,
                            Url = "images/shoes/[IDGiay_3]_AnhChinh.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_3,
                            Url = "images/shoes/[IDGiay_3]_AnhPhu_1.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_3,
                            Url = "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_3,
                            Url = "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_3,
                            Url = "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg"
                        },


                        //NIKE 4
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_4,
                            Url = "images/shoes/[IDGiay_4]_AnhChinh.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_4,
                            Url = "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_4,
                            Url = "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_4,
                            Url = "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_4,
                            Url = "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg"
                        },

                        //NIKE 5
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_5,
                            Url = "images/shoes/[IDGiay_5]_AnhChinh.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_5,
                            Url = "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_5,
                            Url = "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_5,
                            Url = "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_5,
                            Url = "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg"
                        },
                        //ADIDAS 1
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_6,
                            Url = "images/shoes/[IDGiay_6]_AnhChinh.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_6,
                            Url = "images/shoes/[IDGiay_6]_AnhPhu_1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_6,
                            Url = "images/shoes/[IDGiay_6]_AnhPhu_2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_6,
                            Url = "images/shoes/[IDGiay_6]_AnhPhu_3.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_6,
                            Url = "images/shoes/[IDGiay_6]_AnhPhu_4.jpg"
                        },

                        //ADIDAS 2
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_7,
                            Url = "images/shoes/[IDGiay_7]_AnhChinh.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_7,
                            Url = "images/shoes/[IDGiay_7]_AnhPhu_1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_7,
                            Url = "images/shoes/[IDGiay_7]_AnhPhu_2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_7,
                            Url = "images/shoes/[IDGiay_7]_AnhPhu_3.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_7,
                            Url = "images/shoes/[IDGiay_7]_AnhPhu_4.jpg"
                        },

                        //ADIDAS 3
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_8,
                            Url = "images/shoes/[IDGiay_8]_AnhChinh.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_8,
                            Url = "images/shoes/[IDGiay_8]_AnhPhu_1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_8,
                            Url = "images/shoes/[IDGiay_8]_AnhPhu_2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_8,
                            Url = "images/shoes/[IDGiay_8]_AnhPhu_3.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_8,
                            Url = "images/shoes/[IDGiay_8]_AnhPhu_4.jpg"
                        },

                        //ADIDAS 4
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_9,
                            Url = "images/shoes/[IDGiay_9]_AnhChinh.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_9,
                            Url = "images/shoes/[IDGiay_9]_AnhPhu_1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_9,
                            Url = "images/shoes/[IDGiay_9]_AnhPhu_2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_9,
                            Url = "images/shoes/[IDGiay_9]_AnhPhu_3.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_9,
                            Url = "images/shoes/[IDGiay_9]_AnhPhu_4.jpg"
                        },

                        //ADIDAS 5
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_10,
                            Url = "images/shoes/[IDGiay_10]_AnhChinh.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_10,
                            Url = "images/shoes/[IDGiay_10]_AnhPhu_1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_10,
                            Url = "images/shoes/[IDGiay_10]_AnhPhu_2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_10,
                            Url = "images/shoes/[IDGiay_10]_AnhPhu_3.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_10,
                            Url = "images/shoes/[IDGiay_10]_AnhPhu_4.jpg"
                        },

                        //PUMA 1
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_11,
                            Url = "images/shoes/[IDGiay_11]_AnhChinh.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_11,
                            Url = "images/shoes/[IDGiay_11]_AnhPhu_1.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_11,
                            Url = "images/shoes/[IDGiay_11]_AnhPhu_2.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_11,
                            Url = "images/shoes/[IDGiay_11]_AnhPhu_3.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_11,
                            Url = "images/shoes/[IDGiay_11]_AnhPhu_4.png"
                        },

                        //PUMA 2
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_12,
                            Url = "images/shoes/[IDGiay_12]_AnhChinh.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_12,
                            Url = "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_12,
                            Url = "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_12,
                            Url = "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_12,
                            Url = "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg"
                        },

                        //PUMA 3
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_13,
                            Url = "images/shoes/[IDGiay_13]_AnhChinh.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_13,
                            Url = "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_13,
                            Url = "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_13,
                            Url = "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_13,
                            Url = "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg"
                        },

                        //PUMA 4
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_14,
                            Url = "images/shoes/[IDGiay_14]_AnhChinh.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_14,
                            Url = "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_14,
                            Url = "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_14,
                            Url = "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_14,
                            Url = "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg"
                        },

                        //PUMA 5
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_15,
                            Url = "images/shoes/[IDGiay_15]_AnhChinh.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_15,
                            Url = "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_15,
                            Url = "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_15,
                            Url = "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_15,
                            Url = "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg"
                        },
                        // REBOK 1 
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_16,
                            Url = "images/shoes/[IDGiay_16]_AnhChinh.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_16,
                            Url = "images/shoes/[IDGiay_16]_AnhPhu_1.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_16,
                            Url = "images/shoes/[IDGiay_16]_AnhPhu_2.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_16,
                            Url = "images/shoes/[IDGiay_16]_AnhPhu_3.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_16,
                            Url = "images/shoes/[IDGiay_16]_AnhPhu_4.png"
                        },

                        // REBOK 2
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_17,
                            Url = "images/shoes/[IDGiay_17]_AnhChinh.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_17,
                            Url = "images/shoes/[IDGiay_17]_AnhPhu_1.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_17,
                            Url = "images/shoes/[IDGiay_17]_AnhPhu_2.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_17,
                            Url = "images/shoes/[IDGiay_17]_AnhPhu_3.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_17,
                            Url = "images/shoes/[IDGiay_17]_AnhPhu_4.png"
                        },

                        // REBOK 3
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_18,
                            Url = "images/shoes/[IDGiay_18]_AnhChinh.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_18,
                            Url = "images/shoes/[IDGiay_18]_AnhPhu_1.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_18,
                            Url = "images/shoes/[IDGiay_18]_AnhPhu_2.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_18,
                            Url = "images/shoes/[IDGiay_18]_AnhPhu_3.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_18,
                            Url = "images/shoes/[IDGiay_18]_AnhPhu_4.png"
                        },

                        // REBOK 4
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_19,
                            Url = "images/shoes/[IDGiay_19]_AnhChinh.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_19,
                            Url = "images/shoes/[IDGiay_19]_AnhPhu_1.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_19,
                            Url = "images/shoes/[IDGiay_19]_AnhPhu_2.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_19,
                            Url = "images/shoes/[IDGiay_19]_AnhPhu_3.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_19,
                            Url = "images/shoes/[IDGiay_19]_AnhPhu_4.png"
                        },

                        // REBOK 5
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_20,
                            Url = "images/shoes/[IDGiay_20]_AnhChinh.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_20,
                            Url = "images/shoes/[IDGiay_20]_AnhPhu_1.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_20,
                            Url = "images/shoes/[IDGiay_20]_AnhPhu_2.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_20,
                            Url = "images/shoes/[IDGiay_20]_AnhPhu_3.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_20,
                            Url = "images/shoes/[IDGiay_20]_AnhPhu_4.png"
                        },

                        // CONVERSE 1
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_21,
                            Url = "images/shoes/[IDGiay_21]_AnhChinh.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_21,
                            Url = "images/shoes/[IDGiay_21]_AnhPhu_1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_21,
                            Url = "images/shoes/[IDGiay_21]_AnhPhu_2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_21,
                            Url = "images/shoes/[IDGiay_21]_AnhPhu_3.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_21,
                            Url = "images/shoes/[IDGiay_21]_AnhPhu_4.jpg"
                        },

                        // CONVERSE 2
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_22,
                            Url = "images/shoes/[IDGiay_22]_AnhChinh.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_22,
                            Url = "images/shoes/[IDGiay_22]_AnhPhu_1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_22,
                            Url = "images/shoes/[IDGiay_22]_AnhPhu_2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_22,
                            Url = "images/shoes/[IDGiay_22]_AnhPhu_3.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_22,
                            Url = "images/shoes/[IDGiay_22]_AnhPhu_4.jpg"
                        },

                        // CONVERSE 3
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_23,
                            Url = "images/shoes/[IDGiay_23]_AnhChinh.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_23,
                            Url = "images/shoes/[IDGiay_23]_AnhPhu_1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_23,
                            Url = "images/shoes/[IDGiay_23]_AnhPhu_2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_23,
                            Url = "images/shoes/[IDGiay_23]_AnhPhu_3.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_23,
                            Url = "images/shoes/[IDGiay_23]_AnhPhu_4.jpg"
                        },

                        // CONVERSE 4
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_24,
                            Url = "images/shoes/[IDGiay_24]_AnhChinh.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_24,
                            Url = "images/shoes/[IDGiay_24]_AnhPhu_1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_24,
                            Url = "images/shoes/[IDGiay_24]_AnhPhu_2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_24,
                            Url = "images/shoes/[IDGiay_24]_AnhPhu_3.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_24,
                            Url = "images/shoes/[IDGiay_24]_AnhPhu_4.jpg"
                        },

                        // CONVERSE 5
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_25,
                            Url = "images/shoes/[IDGiay_25]_AnhChinh.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_25,
                            Url = "images/shoes/[IDGiay_25]_AnhPhu_1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_25,
                            Url = "images/shoes/[IDGiay_25]_AnhPhu_2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_25,
                            Url = "images/shoes/[IDGiay_25]_AnhPhu_3.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_25,
                            Url = "images/shoes/[IDGiay_25]_AnhPhu_4.jpg"
                        },
                        //
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_26,
                            Url = "https://gossipdergi.com/wp-content/uploads/2021/04/nikeayakkabi.gif"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_26,
                            Url = "https://i.pinimg.com/originals/c0/cf/d1/c0cfd1545f10c56793e888e991b60487.png"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_26,
                            Url = "https://c.files.bbci.co.uk/1081F/production/_117751676_satan-shoes2.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_26,
                            Url = "https://media.cnn.com/api/v1/images/stellar/prod/210328223753-03-lil-nas-x-satan-shoes.jpg?q=w_3000,h_3000,x_0,y_0,c_fill"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_26,
                            Url = "https://photo.znews.vn/w660/Uploaded/rohunwa/2021_03_26/SHOES3.jpeg"
                        },
            // Transparent Nike
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_27,
                            Url = "https://dmpkickz.com/cdn/shop/files/6_78fd24e0-cd30-400a-8fa1-e5e6cd3c5b0b.png?v=1696679846&width=480"
                        },

                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_27,
                            Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNBQXFHswxHuyjT_e8rb5XOaWUzEe3pphPPw&s"
                        },

                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_27,
                            Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQPenW_eiwOe1RkKeaF_kg5TraxKiem6NJ_Q&s"
                        },

                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_27,
                            Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3rZPCUSKRHdQA5_g3YBJRdcmIf_6PpZcNZg&s"
                        },
            // Transparent Nike
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_28,
                            Url = "https://likelihood.us/cdn/shop/files/stansmith_angle_1200x.png?v=1691430477"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_28,
                            Url = "https://assets.adidas.com/images/w_1880,f_auto,q_auto/e53b9a57b0a745be924bac1e00f54427_9366/FX5502_42_detail.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_28,
                            Url = "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-1.jpg"
                        },
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_28,
                            Url = "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-3.jpg"
                        },
                        // Transparent PUMA
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_29,
                            Url = "https://thumblr.uniid.it/product/336262/8307c19dcf3d.jpg?width=3840&format=webp&q=75"
                        },  
            
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_29,
                            Url = "https://thumblr.uniid.it/product/336262/a92a6cadc8a6.jpg?width=3840&format=webp&q=75"
                        },  
            
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_29,
                            Url = "https://thumblr.uniid.it/product/336262/57daee260d2a.jpg?width=3840&format=webp&q=75"
                        },  
            
                        new ShoeImage
                        {
                            Id = Guid.NewGuid(),
                            ShoeId = IDGiay_29,
                            Url = "https://www.prosoccer.com/cdn/shop/files/PumaFuture7UltimateFGAG-ForeverFasterPack_SP24_Model1_1500x.png?v=1713488175"
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
        public DbSet<Notification> Notifications { get; set; }
    }
}
