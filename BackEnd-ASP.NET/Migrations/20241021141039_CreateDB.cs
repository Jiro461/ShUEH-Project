using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEnd_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sold = table.Column<int>(type: "int", nullable: false),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalRatings = table.Column<int>(type: "int", nullable: false),
                    IsSale = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    IsExternalLogin = table.Column<bool>(type: "bit", nullable: true),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoeImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoeImages_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoesColor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoesColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoesColor_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoesDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoesDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoesDetail_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoeSeasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoeSeasons_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShoeDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_ShoesDetail_ShoeDetailId",
                        column: x => x.ShoeDetailId,
                        principalTable: "ShoesDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WishlistItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistItems_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WishlistItems_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("841c88ea-5020-4ca9-ba23-668b564514b7"), "Role User với các quyền hạn có giới hạn và mua hàng", "User" },
                    { new Guid("c14ae901-91eb-4fdc-be92-622250d013e2"), "Role Admin với đầy đủ các quyền hạn", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "AverageRating", "Brand", "Category", "CreateDate", "Description", "Discount", "Gender", "ImageUrl", "IsSale", "LastModifiedDate", "Material", "Name", "Price", "Sold", "TotalRatings" },
                values: new object[,]
                {
                    { new Guid("0169631e-aad8-4aef-ba37-19c51fca1567"), 4.4m, "Converse", "Basketball", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4214), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4216), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34 },
                    { new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4110), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4110), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84 },
                    { new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4068), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4082), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20 },
                    { new Guid("1831d69a-711f-47d4-9b6e-6fb35fd9cec9"), 4.7m, "Puma", "Football", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4239), "One of the best shoes for football and the symbol of Puma's World. You won't be able to take your eyes off of this brand new FUTURE, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4239), "Leather, fabric, foam, and rubber.", "Puma FUTURE 7 Ultimate FG/AG The Forever Faster", 2713000m, 78, 55 },
                    { new Guid("1910b7fa-cdc1-4a52-b846-9bedc063e1de"), 4.2m, "Adidas", "Basketball", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4234), "One of the best shoes for basketball and the symbol of Adidas's World. You won't be able to take your eyes off of this brand new SuperStan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4234), "Leather, fabric, foam, and rubber.", "Adidas Original StanSmith", 1713000m, 65, 33 },
                    { new Guid("2953a508-72cb-4c65-a512-31f0a15e2826"), 4.1m, "Puma", "Yoga", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4178), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4179), "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22 },
                    { new Guid("38f37e90-2ccf-4e37-8d9e-3c8b3284b47c"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4130), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4131), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23 },
                    { new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef"), 4.9m, "Nike", "Yoga", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4097), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4097), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66 },
                    { new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b"), 4.2m, "Nike", "Tennis", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4093), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4094), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5 },
                    { new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242"), 4.2m, "Puma", "Football", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4126), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4127), "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17 },
                    { new Guid("5b7595bd-b173-4203-8469-932fe3fb7603"), 4.6m, "Nike", "Basketball", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4230), "One of the best shoes for basketball and the symbol of Nike's World. You won't be able to take your eyes off of this brand new Jordan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4231), "Leather, fabric, foam, and rubber.", "Jordan 1 Low Bred Toe 2.0", 1813000m, 45, 23 },
                    { new Guid("641637cd-8ad5-40b9-89d2-9483c76e8c8f"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4183), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4183), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87 },
                    { new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4207), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4208), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10 },
                    { new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4117), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4118), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3 },
                    { new Guid("7f8fd7a1-b24f-41f2-883a-2eaa6389bfae"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4203), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4204), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10 },
                    { new Guid("84544985-372a-4f1b-a0a0-25dc47aa7ece"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4113), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4114), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268 },
                    { new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4"), 4.8m, "Nike", "Football", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4089), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4090), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10 },
                    { new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1"), 4.4m, "Adidas", "Football", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4106), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4107), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37 },
                    { new Guid("a9118c5e-d66a-413a-be09-69211a56249d"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4196), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4196), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12 },
                    { new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4211), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4211), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45 },
                    { new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), 4.0m, "Puma", "Basketball", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4121), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4121), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21 },
                    { new Guid("b6d7fc0c-b5c9-49bc-b4e4-df9544510bed"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4190), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4191), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20 },
                    { new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4101), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4102), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381 },
                    { new Guid("c3d04a55-3869-49db-811b-695393e9756e"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4187), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4187), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25 },
                    { new Guid("c5ca193f-d2fc-4eb1-980e-79b1fb9b6d98"), 7m, "Nike", "Basketball", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4227), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4227), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5 },
                    { new Guid("d0cc4a4a-cf8e-401f-8972-4f3c199c0e07"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4200), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4200), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111 },
                    { new Guid("ddda7675-e334-418f-8165-61c7f47843b2"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4220), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4220), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100 },
                    { new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b"), 4.7m, "Nike", "Basketball", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4086), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4086), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45 },
                    { new Guid("fa4af5bb-5089-4d07-b88a-153f702f0a87"), 4.7m, "Converse", "Yoga", new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4223), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 10, 35, 739, DateTimeKind.Local).AddTicks(4224), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("022ddb58-b457-4fb7-8c3e-0cc914c6bcd6"), new Guid("0169631e-aad8-4aef-ba37-19c51fca1567"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("042e3422-cc05-4c0d-8cb1-8f6778153d6f"), new Guid("2953a508-72cb-4c65-a512-31f0a15e2826"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("06c97c7f-9295-494f-8090-da4403ca0cba"), new Guid("5b7595bd-b173-4203-8469-932fe3fb7603"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNBQXFHswxHuyjT_e8rb5XOaWUzEe3pphPPw&s" },
                    { new Guid("098638c3-d43b-4dbb-8e80-df2ce9ac17cb"), new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("0a070a40-384f-47f0-a342-2c4d0bc9b6b2"), new Guid("7f8fd7a1-b24f-41f2-883a-2eaa6389bfae"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("0a0927f4-6897-400b-97a1-106200c7ca86"), new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("0bd3420c-7e81-45c5-a15c-3fa8d2a53c84"), new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("0df6fb4e-8c7d-4850-b1b8-ccfde3aa0e97"), new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("0e627a04-78b8-4c16-9793-557a6a6acd87"), new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("0f870ea0-84e4-42fa-a42e-0e0d9dc89c76"), new Guid("1831d69a-711f-47d4-9b6e-6fb35fd9cec9"), "https://thumblr.uniid.it/product/336262/a92a6cadc8a6.jpg?width=3840&format=webp&q=75" },
                    { new Guid("0fc0d9a7-e3e0-45c1-9944-f97c0eb15604"), new Guid("d0cc4a4a-cf8e-401f-8972-4f3c199c0e07"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("112e9335-8466-48e2-b0a6-06e74f133934"), new Guid("ddda7675-e334-418f-8165-61c7f47843b2"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("12024185-1111-4aa8-8ae8-fb50b01ad128"), new Guid("7f8fd7a1-b24f-41f2-883a-2eaa6389bfae"), "images/shoes/[IDGiay_20]_AnhChinh.png" },
                    { new Guid("1500e63b-5503-447e-85a3-7ea1f8df9ff3"), new Guid("641637cd-8ad5-40b9-89d2-9483c76e8c8f"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("1678f104-fe5f-42c6-b906-1707b57a05d8"), new Guid("c3d04a55-3869-49db-811b-695393e9756e"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("1cd1b07e-6dff-4187-aff8-d4c472eebd0d"), new Guid("c3d04a55-3869-49db-811b-695393e9756e"), "images/shoes/[IDGiay_16]_AnhChinh.png" },
                    { new Guid("1d390a90-d8fd-4a19-93f5-3a8415c3960b"), new Guid("0169631e-aad8-4aef-ba37-19c51fca1567"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("22f824ac-905d-47eb-94c0-a43ba5b489b3"), new Guid("0169631e-aad8-4aef-ba37-19c51fca1567"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("232d689e-cadd-4932-b24e-29a4169200ca"), new Guid("1910b7fa-cdc1-4a52-b846-9bedc063e1de"), "https://assets.adidas.com/images/w_1880,f_auto,q_auto/e53b9a57b0a745be924bac1e00f54427_9366/FX5502_42_detail.jpg" },
                    { new Guid("26b29bc1-6cb5-4e4a-aa54-bfbfce4d69e7"), new Guid("38f37e90-2ccf-4e37-8d9e-3c8b3284b47c"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("27a36810-de8a-4d67-b616-bbee1561a6e4"), new Guid("84544985-372a-4f1b-a0a0-25dc47aa7ece"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("27a4e6b9-a416-4e81-a5f7-e251f5dd1073"), new Guid("ddda7675-e334-418f-8165-61c7f47843b2"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("280a4f0a-9a65-4b25-836f-31f45d0c4e26"), new Guid("b6d7fc0c-b5c9-49bc-b4e4-df9544510bed"), "images/shoes/[IDGiay_17]_AnhChinh.png" },
                    { new Guid("28376223-f84a-4cf5-bb89-6d8fd97ee5a8"), new Guid("c3d04a55-3869-49db-811b-695393e9756e"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("29222de0-d5e8-4b99-b954-5bd51f2367c7"), new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4"), "images/shoes/[IDGiay_3]_AnhChinh.jpeg" },
                    { new Guid("2b3f6c46-78da-47bc-91b4-da849876147d"), new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), "images/shoes/[IDGiay_1]_AnhChinh.png" },
                    { new Guid("2d66c102-bdc5-4b99-86bc-adc74ecfac9e"), new Guid("2953a508-72cb-4c65-a512-31f0a15e2826"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("2db11bae-aa51-46be-8b7f-eb913ac54774"), new Guid("2953a508-72cb-4c65-a512-31f0a15e2826"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("2f8596c4-2e08-4fae-b95a-d7f4163be37c"), new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("31556814-4fe6-4541-bbfd-47bb1a0aa765"), new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242"), "images/shoes/[IDGiay_12]_AnhChinh.jpeg" },
                    { new Guid("324b32a5-206b-436a-81f7-fef341b8a02e"), new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("334e0c79-29d0-41ff-9594-af2848675c42"), new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("33ac3f79-209d-4ab6-b99e-77cc15c925ee"), new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("38afe8d1-d49f-4ad8-a017-ccd156c65545"), new Guid("7f8fd7a1-b24f-41f2-883a-2eaa6389bfae"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("39287087-f390-471b-b0e4-3d6dac8c201e"), new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("3a3f741d-4b09-4502-b28e-01e93cc55541"), new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("3bc6635f-bceb-44bd-9a29-70ee6f2723de"), new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("3c3553b3-c55f-4004-8a93-487b5c4bd0c1"), new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("3c84dee9-8b58-4482-807a-e92784c084ae"), new Guid("38f37e90-2ccf-4e37-8d9e-3c8b3284b47c"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("3e826b14-ad2b-4ba8-a591-b94cf20d1923"), new Guid("2953a508-72cb-4c65-a512-31f0a15e2826"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("406dc302-c456-43d7-9d22-9f3c52d3217a"), new Guid("5b7595bd-b173-4203-8469-932fe3fb7603"), "https://dmpkickz.com/cdn/shop/files/6_78fd24e0-cd30-400a-8fa1-e5e6cd3c5b0b.png?v=1696679846&width=480" },
                    { new Guid("41dfe750-3d73-4998-877a-baa0087e1cb0"), new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242"), "images/shoes/[IDGiay_8]_AnhChinh.jpg" },
                    { new Guid("44f5832e-08f6-49d0-9607-dbad7630faf1"), new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("4688aa70-0582-4420-bc8d-0c1d5f17839c"), new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("48c7f8a9-41e4-4409-9061-ba424acddd37"), new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("4a4fb7e5-5a1e-4585-a4e4-cdad16c9f663"), new Guid("fa4af5bb-5089-4d07-b88a-153f702f0a87"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("4c325a2b-ce65-4291-a796-82ab0bf5e3b8"), new Guid("0169631e-aad8-4aef-ba37-19c51fca1567"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("505052a9-606a-41b2-894a-b33960ec23b6"), new Guid("a9118c5e-d66a-413a-be09-69211a56249d"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("50caca2d-a80f-4ac4-b463-56cd48567230"), new Guid("fa4af5bb-5089-4d07-b88a-153f702f0a87"), "images/shoes/[IDGiay_25]_AnhChinh.jpg" },
                    { new Guid("5399c5fd-3ca7-4094-8ed2-919bf241ece8"), new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b"), "images/shoes/[IDGiay_4]_AnhChinh.jpeg" },
                    { new Guid("5687eba2-e7ef-4854-beab-6b47b6b11202"), new Guid("84544985-372a-4f1b-a0a0-25dc47aa7ece"), "images/shoes/[IDGiay_9]_AnhChinh.jpg" },
                    { new Guid("576bacb4-e956-46d5-8177-cc2b77acd2b1"), new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("57e2c130-1def-47e5-b664-c5abb7aae840"), new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("5d1e2d0e-5f71-4330-832a-dcc9b4a850c3"), new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("61910b89-f5ea-4fed-82c3-b518f2a193dd"), new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b"), "images/shoes/[IDGiay_2]_AnhChinh.png" },
                    { new Guid("62111389-e42c-4d49-825d-763c01a652e5"), new Guid("a9118c5e-d66a-413a-be09-69211a56249d"), "images/shoes/[IDGiay_18]_AnhChinh.png" },
                    { new Guid("64bf39e0-b635-4989-841b-f37676ff9eab"), new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("67dfefc2-d419-475f-a3e7-abcee14ef7d9"), new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("68edc5cd-1e18-4d67-9895-eb1c0a297061"), new Guid("fa4af5bb-5089-4d07-b88a-153f702f0a87"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("69d528f6-7888-4f89-a137-a4c8a27baf0b"), new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), "images/shoes/[IDGiay_6]_AnhChinh.jpg" },
                    { new Guid("69d61645-55b4-4f36-b350-3a7385cd53c4"), new Guid("84544985-372a-4f1b-a0a0-25dc47aa7ece"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("6d1e08e2-777a-4c08-8179-12766c94101e"), new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("6de41122-402f-4033-b291-ddc73be68b43"), new Guid("c5ca193f-d2fc-4eb1-980e-79b1fb9b6d98"), "https://i.pinimg.com/originals/c0/cf/d1/c0cfd1545f10c56793e888e991b60487.png" },
                    { new Guid("72fee934-a6c5-47f8-b4b1-809b92a5ad96"), new Guid("c3d04a55-3869-49db-811b-695393e9756e"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("73642749-5445-49cf-96f9-34a29ebc5c8a"), new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), "images/shoes/[IDGiay_11]_AnhChinh.png" },
                    { new Guid("7403e72b-1655-4378-b66e-cc5b51363ee8"), new Guid("5b7595bd-b173-4203-8469-932fe3fb7603"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3rZPCUSKRHdQA5_g3YBJRdcmIf_6PpZcNZg&s" },
                    { new Guid("7420e858-5109-474c-b03d-ad30b8062b4a"), new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("786a3afb-5320-4d97-87e5-a8d9679e8e5a"), new Guid("c3d04a55-3869-49db-811b-695393e9756e"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("7b0d57ab-f85a-4bb1-be7b-dcd6dedd69c6"), new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("7c05c0b3-4620-4ae3-84bc-2f4fe012f604"), new Guid("641637cd-8ad5-40b9-89d2-9483c76e8c8f"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("7cd3ecaf-0865-47d0-bb17-6b70b1f148bd"), new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("7edc59d1-96ec-48a9-915f-d74b729d48f3"), new Guid("a9118c5e-d66a-413a-be09-69211a56249d"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("7f239ecf-b532-4362-a85a-a38105dc363e"), new Guid("b6d7fc0c-b5c9-49bc-b4e4-df9544510bed"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("814c1045-2623-42d9-8e0e-8da91a54cac5"), new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("81b2b6f5-ff0f-495c-a3d2-3b39759503ba"), new Guid("7f8fd7a1-b24f-41f2-883a-2eaa6389bfae"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("837735ef-18f6-465f-82b3-469e14bd5252"), new Guid("641637cd-8ad5-40b9-89d2-9483c76e8c8f"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("859bd4af-fcbd-44f7-a595-a4becf1b3d2e"), new Guid("c5ca193f-d2fc-4eb1-980e-79b1fb9b6d98"), "https://media.cnn.com/api/v1/images/stellar/prod/210328223753-03-lil-nas-x-satan-shoes.jpg?q=w_3000,h_3000,x_0,y_0,c_fill" },
                    { new Guid("86387908-1eb1-4cc9-8504-a8a7c0b767c4"), new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("8704831a-a6da-4558-9296-e71b3820394c"), new Guid("b6d7fc0c-b5c9-49bc-b4e4-df9544510bed"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("8af61908-d1ff-4a00-b558-0dfa5448abbb"), new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("8b4b4715-4256-48d7-b024-e9fcca4720d0"), new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("8b5cdb73-cf4e-4b05-adfb-41b4b0290962"), new Guid("ddda7675-e334-418f-8165-61c7f47843b2"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("8d2f8e8e-927f-4ee2-8930-fac5a5ef3493"), new Guid("1831d69a-711f-47d4-9b6e-6fb35fd9cec9"), "https://thumblr.uniid.it/product/336262/8307c19dcf3d.jpg?width=3840&format=webp&q=75" },
                    { new Guid("9307c089-be1f-446a-8a1e-21dd59d77dbd"), new Guid("38f37e90-2ccf-4e37-8d9e-3c8b3284b47c"), "images/shoes/[IDGiay_13]_AnhChinh.jpeg" },
                    { new Guid("95a2d3b8-6444-4063-8625-443904282d17"), new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("96e985e9-b9ae-4a5a-aa64-bdc45c7ca288"), new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("98370506-dbf2-4c7b-90a4-9ad5581c0410"), new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("9a156a06-a648-45f5-93d3-66a682537c46"), new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1"), "images/shoes/[IDGiay_7]_AnhChinh.jpg" },
                    { new Guid("9e4fffc1-371a-4c0d-aabd-a3b53cc80d41"), new Guid("641637cd-8ad5-40b9-89d2-9483c76e8c8f"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("a1054639-5c85-4a23-bccc-13bf3d84b605"), new Guid("fa4af5bb-5089-4d07-b88a-153f702f0a87"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("a2c4ce55-f23d-4f7c-a193-e9b8f05f2caa"), new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("a3ba1d7d-3668-414c-88df-9a6a5ec40a79"), new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("a4b25fda-b4c4-489a-9d46-dbd84aece651"), new Guid("7f8fd7a1-b24f-41f2-883a-2eaa6389bfae"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("a6fb7b3f-20db-434d-b0e6-95d4362249dd"), new Guid("fa4af5bb-5089-4d07-b88a-153f702f0a87"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("a7bd2a06-d066-4149-a3e2-b310efc66446"), new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("a815d5e5-37ec-46ae-b383-e7904e0470f3"), new Guid("ddda7675-e334-418f-8165-61c7f47843b2"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("a88b96c2-5745-47d4-b4a8-4419032d77c8"), new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), "images/shoes/[IDGiay_21]_AnhChinh.jpg" },
                    { new Guid("af9be5b8-4e76-4138-a5c6-189985a229da"), new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("afcfcfb7-6a88-497b-b179-fc73d7146f7a"), new Guid("1910b7fa-cdc1-4a52-b846-9bedc063e1de"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-1.jpg" },
                    { new Guid("b0f92e6e-8234-417e-8b18-6bc68da3b2ae"), new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("b1476d11-eb11-4ede-85f4-168717f8cbb8"), new Guid("a9118c5e-d66a-413a-be09-69211a56249d"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("b206013a-6941-4500-bba3-50d1b41f8a1d"), new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("b5e5353a-1b2e-4576-83e6-893d145280b1"), new Guid("84544985-372a-4f1b-a0a0-25dc47aa7ece"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("b679b698-c440-4924-b526-842a44a1e050"), new Guid("0169631e-aad8-4aef-ba37-19c51fca1567"), "images/shoes/[IDGiay_23]_AnhChinh.jpg" },
                    { new Guid("b932bfa9-240a-45d4-9396-d0f9b4c4cafc"), new Guid("b6d7fc0c-b5c9-49bc-b4e4-df9544510bed"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("bb3c6d18-e98d-4344-82f2-97cfe745b9c7"), new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("bc5e4056-d337-4f1b-b994-e01dc0123faf"), new Guid("1910b7fa-cdc1-4a52-b846-9bedc063e1de"), "https://likelihood.us/cdn/shop/files/stansmith_angle_1200x.png?v=1691430477" },
                    { new Guid("be7f2574-e9b7-4496-961a-bb0a7219ebf6"), new Guid("38f37e90-2ccf-4e37-8d9e-3c8b3284b47c"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("bf3bdd58-f515-4510-8480-4d4379a3f56a"), new Guid("c5ca193f-d2fc-4eb1-980e-79b1fb9b6d98"), "https://photo.znews.vn/w660/Uploaded/rohunwa/2021_03_26/SHOES3.jpeg" },
                    { new Guid("bf9a881b-65c6-4a36-b46d-2bd02d11ef68"), new Guid("2953a508-72cb-4c65-a512-31f0a15e2826"), "images/shoes/[IDGiay_14]_AnhChinh.jpeg" },
                    { new Guid("c36030c2-7d5b-4c61-b04b-43a06ed14da2"), new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("c6c2d571-0592-43e3-88a9-7c8653598a58"), new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("cb2a53b5-b49d-4eeb-b085-6430b3532a6f"), new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), "images/shoes/[IDGiay_22]_AnhChinh.jpg" },
                    { new Guid("cb702786-7520-46b9-9e87-386374579511"), new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef"), "images/shoes/[IDGiay_5]_AnhChinh.jpeg" },
                    { new Guid("cdb597bf-d60b-4850-8e4d-8ff99856a9c8"), new Guid("641637cd-8ad5-40b9-89d2-9483c76e8c8f"), "images/shoes/[IDGiay_15]_AnhChinh.jpeg" },
                    { new Guid("ce44bd4b-8b8b-4a16-a1cc-8a4a1c588978"), new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("d09c81a0-c3b9-41ab-9d40-836851fbc164"), new Guid("ddda7675-e334-418f-8165-61c7f47843b2"), "images/shoes/[IDGiay_24]_AnhChinh.jpg" },
                    { new Guid("d2b664ba-0e96-406c-8d84-b25c5b5e20e0"), new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("d31e39e7-c9d0-4ca8-ad73-989f68136ef5"), new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("d5bdc962-6a0e-452e-bc74-fc63232996e2"), new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699"), "images/shoes/[IDGiay_10]_AnhChinh.jpg" },
                    { new Guid("d8bd31fb-5e8b-440f-bcc4-5d175233224b"), new Guid("84544985-372a-4f1b-a0a0-25dc47aa7ece"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("db327dc3-52d2-40e1-a4a5-ca5266a808cf"), new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("de2785c4-c830-4db8-a46a-38e35cd3a49c"), new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("de434bf3-19a6-415e-a69e-c2a67e93fd5e"), new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("dfe23e3d-e1b1-48fd-9fc1-43dd04e112b1"), new Guid("1910b7fa-cdc1-4a52-b846-9bedc063e1de"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-3.jpg" },
                    { new Guid("dfee3bb5-150d-4174-b144-b777128d4ec8"), new Guid("b6d7fc0c-b5c9-49bc-b4e4-df9544510bed"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("e08b5741-c23e-402d-bc13-edd3c97e0bf4"), new Guid("d0cc4a4a-cf8e-401f-8972-4f3c199c0e07"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("e3fdb678-9dd2-42ef-8c90-8a7be9e33b48"), new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("e6d56633-372c-4cd0-9a0a-6eda72f46733"), new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("e71a6a38-7673-4df1-b796-c854a103e3df"), new Guid("c5ca193f-d2fc-4eb1-980e-79b1fb9b6d98"), "https://gossipdergi.com/wp-content/uploads/2021/04/nikeayakkabi.gif" },
                    { new Guid("ead65b72-af7a-4637-9e9a-0ac208c0c82c"), new Guid("a9118c5e-d66a-413a-be09-69211a56249d"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("eb813c8c-d090-40a3-a482-84cf20c08bd0"), new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("ec42db4f-acb5-44e8-b028-bce02cdee870"), new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("eed48b9d-c90a-4b32-841a-4b0b46675657"), new Guid("c5ca193f-d2fc-4eb1-980e-79b1fb9b6d98"), "https://c.files.bbci.co.uk/1081F/production/_117751676_satan-shoes2.jpg" },
                    { new Guid("ef43afcc-375f-4756-90fc-30fe5a97241e"), new Guid("d0cc4a4a-cf8e-401f-8972-4f3c199c0e07"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("f26ee9e9-afd9-42a5-a8bd-8f3f95ca7e54"), new Guid("5b7595bd-b173-4203-8469-932fe3fb7603"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQPenW_eiwOe1RkKeaF_kg5TraxKiem6NJ_Q&s" },
                    { new Guid("f5c0f8cf-ea55-4e5e-8f84-7001d13817e3"), new Guid("1831d69a-711f-47d4-9b6e-6fb35fd9cec9"), "https://www.prosoccer.com/cdn/shop/files/PumaFuture7UltimateFGAG-ForeverFasterPack_SP24_Model1_1500x.png?v=1713488175" },
                    { new Guid("f96fd307-063b-4fca-bc32-36276c674823"), new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("fb32da02-4eb1-4dc9-a400-ec13863cc062"), new Guid("d0cc4a4a-cf8e-401f-8972-4f3c199c0e07"), "images/shoes/[IDGiay_19]_AnhChinh.png" },
                    { new Guid("fbb30369-5141-440e-91d4-221696afb2e9"), new Guid("1831d69a-711f-47d4-9b6e-6fb35fd9cec9"), "https://thumblr.uniid.it/product/336262/57daee260d2a.jpg?width=3840&format=webp&q=75" },
                    { new Guid("ff88eabb-a54a-48ce-8cb0-b9fae5b625d0"), new Guid("38f37e90-2ccf-4e37-8d9e-3c8b3284b47c"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("ffaf9dc6-425c-40c6-8641-0e7eedf1a1e8"), new Guid("d0cc4a4a-cf8e-401f-8972-4f3c199c0e07"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("07d4b666-6b69-430b-9475-10dcf9e87083"), "Winter", new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef") },
                    { new Guid("08ef1544-584b-43cf-a756-77c140b9729b"), "Summer", new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b") },
                    { new Guid("0f079488-9462-4377-bde0-3b39215df855"), "Winter", new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b") },
                    { new Guid("10d4d59e-873e-41a6-a0d0-bb833940d3ff"), "Fall", new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b") },
                    { new Guid("114a53a1-0e03-4809-8caa-6b82af663c5b"), "Summer", new Guid("146ef5fa-0003-43aa-a851-db453637a6b1") },
                    { new Guid("160d8a0f-5d89-4eec-9ede-60e61c38fcd9"), "Fall", new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b") },
                    { new Guid("203eef4e-efcf-4a7c-8b75-4c1577adb9a6"), "Summer", new Guid("84544985-372a-4f1b-a0a0-25dc47aa7ece") },
                    { new Guid("2fe47141-1277-4042-a06a-ed68abd8904b"), "Summer", new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1") },
                    { new Guid("37df4f12-aac9-4d27-a7a6-62a2144b27fb"), "Winter", new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1") },
                    { new Guid("382e31e8-e752-45d6-a8c2-5b152c1e32f7"), "Winter", new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b") },
                    { new Guid("38eba8de-483f-4fce-a652-8b2dfa2110ab"), "Fall", new Guid("ddda7675-e334-418f-8165-61c7f47843b2") },
                    { new Guid("3bd751f6-9d55-41e3-9365-581cfc09c2db"), "Fall", new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242") },
                    { new Guid("545a22b1-604b-4907-bc25-bfa2e33896b4"), "Winter", new Guid("0169631e-aad8-4aef-ba37-19c51fca1567") },
                    { new Guid("54db6c25-2658-4c3b-88ce-c2b75a9bb0f2"), "Winter", new Guid("c3d04a55-3869-49db-811b-695393e9756e") },
                    { new Guid("5976de84-af65-4f17-a94f-dd381c271d6d"), "Winter", new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60") },
                    { new Guid("5bdc017c-e732-42b0-aa76-1d7ad6756ae3"), "Spring", new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242") },
                    { new Guid("60202f9e-21e1-496b-bb20-051d78c02ce4"), "Summer", new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a") },
                    { new Guid("6055bf1d-8c7e-4d1e-a917-abf0440e77bb"), "Spring", new Guid("2953a508-72cb-4c65-a512-31f0a15e2826") },
                    { new Guid("61094270-1752-48ce-af96-b3606dcf2739"), "Spring", new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242") },
                    { new Guid("63bbd48c-47d0-4f81-9bf0-9ae418d75609"), "Summer", new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60") },
                    { new Guid("6ad2276e-aaa5-4130-9643-789f5221863f"), "Winter", new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242") },
                    { new Guid("74544b40-fd4b-4a4d-87d5-176b6f01811c"), "Spring", new Guid("641637cd-8ad5-40b9-89d2-9483c76e8c8f") },
                    { new Guid("7469c2a6-2b5a-4a59-b497-1d4455f2cc61"), "Fall", new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a") },
                    { new Guid("76c86625-9784-44ce-a341-e20a0cb891b9"), "Winter", new Guid("7f8fd7a1-b24f-41f2-883a-2eaa6389bfae") },
                    { new Guid("7962d7b0-ba6b-4555-a94c-f5ed167f361e"), "Spring", new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b") },
                    { new Guid("7a010247-2204-4fe9-936b-12d5a7125608"), "Summer", new Guid("7f8fd7a1-b24f-41f2-883a-2eaa6389bfae") },
                    { new Guid("7ded12cc-141d-4357-b6ca-e9c0ac311933"), "Spring", new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1") },
                    { new Guid("82572d4d-60dc-4fab-8bc2-de8a493b9bf0"), "Winter", new Guid("84544985-372a-4f1b-a0a0-25dc47aa7ece") },
                    { new Guid("87eade11-698b-44e9-bce0-d0aa6bfbf61f"), "Spring", new Guid("146ef5fa-0003-43aa-a851-db453637a6b1") },
                    { new Guid("886ddb6e-2c4f-4031-9220-30f779d3fe25"), "Spring", new Guid("7f8fd7a1-b24f-41f2-883a-2eaa6389bfae") },
                    { new Guid("904d25b8-6b74-4066-930e-6679ad274e88"), "Fall", new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef") },
                    { new Guid("918453f2-1393-470a-9c00-8144e1e9e1ae"), "Fall", new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1") },
                    { new Guid("96b1fe95-7057-47eb-b58d-931c21781428"), "Winter", new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a") },
                    { new Guid("9774b174-9e3c-4322-b1e7-df5c625d46d3"), "Spring", new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4") },
                    { new Guid("99bb76f3-c0b2-4a16-9016-4b8527b3e0bb"), "Fall", new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a") },
                    { new Guid("b08c9670-cc07-45a3-9e3c-03b1cee02901"), "Summer", new Guid("38f37e90-2ccf-4e37-8d9e-3c8b3284b47c") },
                    { new Guid("ba1c37d7-9c1d-4ca5-88ef-44960600f363"), "Winter", new Guid("b6d7fc0c-b5c9-49bc-b4e4-df9544510bed") },
                    { new Guid("ba4b036e-29ad-4af2-a042-317371df6315"), "Summer", new Guid("a9118c5e-d66a-413a-be09-69211a56249d") },
                    { new Guid("bfe3ee09-5ba5-416c-b6e2-6f2bd8a2ae85"), "Spring", new Guid("a9118c5e-d66a-413a-be09-69211a56249d") },
                    { new Guid("c32153c6-a258-4034-bb9d-1a33af4f027a"), "Summer", new Guid("2953a508-72cb-4c65-a512-31f0a15e2826") },
                    { new Guid("c7a4294c-8dad-4fba-8545-f8a971bdf424"), "Summer", new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b") },
                    { new Guid("ce3c0e1d-9475-4688-9417-1703ffbb02eb"), "Spring", new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699") },
                    { new Guid("da854569-8d58-441d-8222-74f39ae8afa6"), "Spring", new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a") },
                    { new Guid("dd3094a9-3477-4f1f-8f44-37a57d217601"), "Summer", new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699") },
                    { new Guid("e2028660-1301-46c5-8474-a525c187e21d"), "Fall", new Guid("c3d04a55-3869-49db-811b-695393e9756e") },
                    { new Guid("e692ae0e-6231-4597-bb9e-e385df9c16f8"), "Spring", new Guid("fa4af5bb-5089-4d07-b88a-153f702f0a87") },
                    { new Guid("efa17e78-985f-47c0-9cda-cc38042ad6df"), "Spring", new Guid("ddda7675-e334-418f-8165-61c7f47843b2") },
                    { new Guid("f257b4fa-9170-4669-bc1a-461f50aab4fc"), "Summer", new Guid("c3d04a55-3869-49db-811b-695393e9756e") },
                    { new Guid("f6e40f4c-2a26-4a31-b536-d51356fef3ad"), "Winter", new Guid("d0cc4a4a-cf8e-401f-8972-4f3c199c0e07") },
                    { new Guid("f87e8ad7-1a73-4e04-9481-b47256f0863e"), "Summer", new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b") },
                    { new Guid("febe3995-5762-4894-94b3-cad6186a48dd"), "Spring", new Guid("c3d04a55-3869-49db-811b-695393e9756e") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("0040bdfc-e3b5-4996-b6e6-63551735858a"), "Brown", new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b") },
                    { new Guid("1593ebd2-647b-411a-9446-35fe061b3e18"), "Black", new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b") },
                    { new Guid("1d1aadad-408f-4176-b68c-91581cf1d41d"), "Orange", new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b") },
                    { new Guid("1ddf5583-b342-449f-89ba-5987692f34cb"), "Green", new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242") },
                    { new Guid("1e92bde5-959d-4da9-bd85-823d3b3b7828"), "Blue", new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242") },
                    { new Guid("27b1ca9b-d103-4eb9-990f-bb275dd322ff"), "Blue", new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b") },
                    { new Guid("2bfe6bd2-1b8a-4fab-b718-9547fc21e4fb"), "Black", new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4") },
                    { new Guid("2dd4caf0-a452-4a00-b6be-ad295b67d328"), "Purple", new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699") },
                    { new Guid("30b0e15a-6972-42b5-b47c-c18c2a348464"), "White", new Guid("641637cd-8ad5-40b9-89d2-9483c76e8c8f") },
                    { new Guid("354b98cc-8421-415e-ae07-9a01fe1dcbef"), "Blue", new Guid("c3d04a55-3869-49db-811b-695393e9756e") },
                    { new Guid("36b3265b-5475-447d-bba8-8445d51e415d"), "White", new Guid("d0cc4a4a-cf8e-401f-8972-4f3c199c0e07") },
                    { new Guid("3798e36d-20d5-47bc-bcc0-0e7dd2a97058"), "Black", new Guid("38f37e90-2ccf-4e37-8d9e-3c8b3284b47c") },
                    { new Guid("3bba757f-5d81-421c-9420-7de569df0631"), "Blue", new Guid("a9118c5e-d66a-413a-be09-69211a56249d") },
                    { new Guid("3c746e11-bf77-4f6a-8cea-360ab81accce"), "Yellow", new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4") },
                    { new Guid("3d8959a5-7324-4611-9ceb-c61a97fd6e83"), "Blue", new Guid("146ef5fa-0003-43aa-a851-db453637a6b1") },
                    { new Guid("40f13859-a601-4fec-80c0-1e20fb95cedd"), "Red", new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242") },
                    { new Guid("43b86799-371d-4d6a-a0dd-b6f2768c1cc6"), "Red", new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1") },
                    { new Guid("4725470a-c835-42f8-9eec-9667dd4d66a1"), "Brown", new Guid("fa4af5bb-5089-4d07-b88a-153f702f0a87") },
                    { new Guid("53e1c734-00df-491c-96f6-c4c84bfb9fc3"), "White", new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b") },
                    { new Guid("53ee62b1-50a3-4f84-ab4c-e32df6fc6de2"), "Pink", new Guid("2953a508-72cb-4c65-a512-31f0a15e2826") },
                    { new Guid("5744a4bf-e19d-47c3-9302-bf03fec4e691"), "Orange", new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a") },
                    { new Guid("58411e00-aedf-4a70-9c66-fd83ece6c687"), "Black", new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699") },
                    { new Guid("684850bf-d650-43b2-a7aa-88933159d942"), "Black", new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef") },
                    { new Guid("68f89224-06cd-4dd3-8413-cb2f124d64d5"), "Pink", new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4") },
                    { new Guid("6bcf27f1-3e39-4983-8242-762efe52069d"), "Red", new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b") },
                    { new Guid("75bbec08-39f1-4f8e-8d42-c1cb57e72f60"), "Purple", new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a") },
                    { new Guid("75c0ceb6-6e7c-49b2-ab4f-dca9d6a1a50d"), "Black", new Guid("c3d04a55-3869-49db-811b-695393e9756e") },
                    { new Guid("89c565b3-c139-49f4-848d-c781fd227876"), "Black", new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b") },
                    { new Guid("8bb8918a-43c4-4f10-8ed2-5a6d3a8f90eb"), "Black", new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60") },
                    { new Guid("8bf6cceb-ad09-4274-80f5-21362c47b307"), "Pink", new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699") },
                    { new Guid("8eb01ca5-2432-4f4b-840a-5aefb5f9cd64"), "White", new Guid("de5a65d8-684e-4d42-a5ac-01ce5fdf173b") },
                    { new Guid("9177b4fd-eb92-4188-9b20-0fccffc2b960"), "Black", new Guid("146ef5fa-0003-43aa-a851-db453637a6b1") },
                    { new Guid("9ccf6690-aa51-4fec-9456-da948e189c74"), "Blue", new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4") },
                    { new Guid("9f1828a7-b9f2-4047-adf5-21da3c41f794"), "White", new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef") },
                    { new Guid("a0f8d47d-36c6-4452-bf01-181f27aeaa10"), "Black", new Guid("84544985-372a-4f1b-a0a0-25dc47aa7ece") },
                    { new Guid("a740bdfc-d0b0-437b-acc4-9b4837a60272"), "Pink", new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242") },
                    { new Guid("aa45fc8b-c149-47fd-aded-df999e520ae0"), "White", new Guid("9868e163-0f3a-49a2-a883-426bd38d83a4") },
                    { new Guid("ace0bfc6-fdaa-4e5a-8a21-8da43b6df20e"), "Orange", new Guid("4063f14b-c97d-4fb4-8e87-9621f5d1b3ef") },
                    { new Guid("af959484-1b49-4cc6-8d72-1fe6efafd8bb"), "Black", new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a") },
                    { new Guid("b322daf4-8c22-442c-b55c-9ef136d19b37"), "Blue", new Guid("0169631e-aad8-4aef-ba37-19c51fca1567") },
                    { new Guid("b4a4aebf-f9d7-4b99-884a-0105adb82864"), "White", new Guid("c3d04a55-3869-49db-811b-695393e9756e") },
                    { new Guid("ba87746e-143c-439f-874c-7e6967c7859f"), "Blue", new Guid("b6d7fc0c-b5c9-49bc-b4e4-df9544510bed") },
                    { new Guid("bb4a4781-476b-4408-8bc8-2f2f2786aa46"), "White", new Guid("ddda7675-e334-418f-8165-61c7f47843b2") },
                    { new Guid("c9de7666-9b00-4481-a766-c9a8595c89f5"), "Yellow", new Guid("9ba0c988-6f6d-4f6b-83c8-1d658edabaa1") },
                    { new Guid("cbef8b4a-4558-4b69-a0e4-a5b478efcb2a"), "Purple", new Guid("146ef5fa-0003-43aa-a851-db453637a6b1") },
                    { new Guid("cc99ba88-6aaa-4b01-985d-ed41fd9f4f93"), "White", new Guid("7596ba34-6eb8-4eec-b90f-63383cdba699") },
                    { new Guid("d02882f5-20c1-4125-9368-fea74a11b7a4"), "White", new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b") },
                    { new Guid("d17b61ac-88be-4a6e-8f0f-21c552155a56"), "Grey", new Guid("c3d04a55-3869-49db-811b-695393e9756e") },
                    { new Guid("d5f6074e-85c2-4662-af5d-74a36083915c"), "Brown", new Guid("ddda7675-e334-418f-8165-61c7f47843b2") },
                    { new Guid("d6d24e8d-1605-4e14-a7c3-35d81e998661"), "White", new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242") },
                    { new Guid("d6fdb2d8-e89f-4111-bce5-09d1f9651ad7"), "Green", new Guid("fa4af5bb-5089-4d07-b88a-153f702f0a87") },
                    { new Guid("d8515565-738e-4ea4-b31e-3ae0fff43b7f"), "Black", new Guid("641637cd-8ad5-40b9-89d2-9483c76e8c8f") },
                    { new Guid("da789287-6984-4f39-9821-e49f1120bf43"), "Red", new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b") },
                    { new Guid("ddd04605-5dd4-448e-96f4-c7ba66043cad"), "White", new Guid("146ef5fa-0003-43aa-a851-db453637a6b1") },
                    { new Guid("df690cd6-21e7-409e-8e60-47f62330e7f3"), "Orange", new Guid("38f37e90-2ccf-4e37-8d9e-3c8b3284b47c") },
                    { new Guid("dfa90689-2ca4-499b-a76e-c04ee52d6ead"), "Black", new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242") },
                    { new Guid("e232d7ca-026b-4c03-a27c-3fb1b317cc81"), "Blue", new Guid("7f8fd7a1-b24f-41f2-883a-2eaa6389bfae") },
                    { new Guid("f1269950-ef4c-42d2-b2e3-f24033906d8b"), "Pink", new Guid("b6d7fc0c-b5c9-49bc-b4e4-df9544510bed") },
                    { new Guid("f148c30b-6221-4338-85b7-4d8ad6e1b5cc"), "Black", new Guid("533e7f4b-2d19-44f1-b4db-cdaec0e75242") },
                    { new Guid("f2ac1dc8-aee8-4a82-84b0-825054534ab0"), "Green", new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b") },
                    { new Guid("f3231e2f-530c-490d-863d-e4edf817def4"), "Black", new Guid("4e80b8af-91a4-445c-88ac-5c6e3cedbb3b") },
                    { new Guid("f496382f-af68-4c5d-8c68-ecd8be2e09a7"), "Blue", new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b") },
                    { new Guid("f4ad5622-50ce-47e0-a8d9-120f873e9318"), "Blue", new Guid("07d21ad5-fb87-4f28-add4-a3384ecf3242") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("138230e9-bd4d-4b45-a364-dfb295e654ba"), 5, new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), 43 },
                    { new Guid("18aaddd5-2332-4be5-beca-f6d5c6ebe3c4"), 0, new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), 42 },
                    { new Guid("192a867a-8369-458b-a0e1-1f85fc15387b"), 10, new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), 45 },
                    { new Guid("2d8e40bb-6021-4623-961d-0e0eeaf1dcde"), 1, new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), 36 },
                    { new Guid("3106af1f-f089-427c-85fd-9e41f0163def"), 10, new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), 38 },
                    { new Guid("321d3be7-a2d1-4000-93e6-7c9e5891077f"), 7, new Guid("c3d04a55-3869-49db-811b-695393e9756e"), 43 },
                    { new Guid("364c0f72-5473-470c-8e5c-95b02adbc1c3"), 3, new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), 44 },
                    { new Guid("375c725f-d62e-4c97-9c4b-0fc75bdec71c"), 1, new Guid("c3d04a55-3869-49db-811b-695393e9756e"), 45 },
                    { new Guid("42df4f77-70cf-4445-a6ec-6155852ac9f5"), 0, new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), 45 },
                    { new Guid("456df1b3-7310-4957-80c5-7164aedff439"), 4, new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), 38 },
                    { new Guid("4823445f-9ff3-4882-b87c-84edd74b42ef"), 4, new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), 43 },
                    { new Guid("4f8bbc88-3c73-4c03-9c1d-4b1a592cf82f"), 5, new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), 45 },
                    { new Guid("5627c613-8d77-4cb8-b60e-51e004c641f9"), 8, new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), 43 },
                    { new Guid("570f393f-b11b-4520-9652-b681f080ec5b"), 1, new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), 39 },
                    { new Guid("5c235585-5837-4c9a-beb2-d8111403cd22"), 10, new Guid("c3d04a55-3869-49db-811b-695393e9756e"), 40 },
                    { new Guid("5c2ce6e1-c192-4f26-83eb-f958c4dd525e"), 10, new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), 39 },
                    { new Guid("5c7020b4-2885-46d1-a9b4-8b187e47c0c2"), 10, new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), 40 },
                    { new Guid("673d9538-79ae-401d-8be6-b97dcb38176a"), 0, new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), 42 },
                    { new Guid("680178f8-b22d-46c8-9c73-cf39dd24fb38"), 0, new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), 44 },
                    { new Guid("754c65ed-fb47-4000-a4dd-f79b572ff817"), 7, new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), 37 },
                    { new Guid("7961312a-504a-450f-ab22-f47dd9b0a593"), 0, new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), 41 },
                    { new Guid("8433adfe-69f6-4c5f-89b9-4674607f0f52"), 10, new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), 39 },
                    { new Guid("843f7eca-c356-4ac1-853b-d0ed99131e46"), 10, new Guid("c3d04a55-3869-49db-811b-695393e9756e"), 44 },
                    { new Guid("8650f1f8-d598-44ac-8f9f-2108294b5c23"), 0, new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), 42 },
                    { new Guid("9e8ea892-3207-4719-8f8a-c1e77f33c17a"), 0, new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), 42 },
                    { new Guid("a0aa9962-da21-4e4b-a155-4ff0060f5fec"), 1, new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), 40 },
                    { new Guid("a544a97a-28a3-4362-a36c-7d344e33f1cd"), 3, new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), 40 },
                    { new Guid("a57b76cb-19d1-42b6-a2e1-1b8137f9fa7f"), 8, new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), 43 },
                    { new Guid("b0247a7f-17d9-4d43-9d5c-b059b079a588"), 1, new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), 40 },
                    { new Guid("b40651de-4871-4cac-9202-f300f95b079e"), 9, new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), 37 },
                    { new Guid("be839327-1271-4b84-a260-f0036b87813c"), 5, new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), 44 },
                    { new Guid("bf69461b-3501-413c-9523-abf7ec921ca2"), 0, new Guid("c3d04a55-3869-49db-811b-695393e9756e"), 42 },
                    { new Guid("c11aee0b-0b21-42bc-a2cd-27d867acb796"), 2, new Guid("c3d04a55-3869-49db-811b-695393e9756e"), 41 },
                    { new Guid("c6c97467-47ea-4e33-80fb-0d6302a59449"), 4, new Guid("146ef5fa-0003-43aa-a851-db453637a6b1"), 41 },
                    { new Guid("cf23b65b-e842-4c6f-99bf-270c4b5df689"), 1, new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), 45 },
                    { new Guid("d189f6a4-bc46-45ec-bd33-ff289fd7c5e4"), 5, new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), 44 },
                    { new Guid("d4eb0672-1d76-4fb5-8583-058de1b0ded4"), 1, new Guid("c3d04a55-3869-49db-811b-695393e9756e"), 39 },
                    { new Guid("e1e56f82-d875-4533-bbb5-dbc7c220c050"), 3, new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), 41 },
                    { new Guid("e5bab283-6186-4208-99fc-7b8d331d3203"), 5, new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), 42 },
                    { new Guid("e94f5565-9daf-4167-a2c3-d951b280b71e"), 1, new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), 43 },
                    { new Guid("e9c26497-32ff-4f50-8ddc-0ea12c8b6427"), 1, new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), 41 },
                    { new Guid("eb1c851e-eb90-400e-a708-dd78562a8715"), 5, new Guid("b4a61797-b823-47fb-8818-8e6b698cba1a"), 41 },
                    { new Guid("eb4a88a6-acaa-4a3d-8345-8a584b62ad83"), 4, new Guid("afe193c8-4b14-4ecf-a487-2501196c5c60"), 39 },
                    { new Guid("f08b2182-9578-42c9-94e4-b65c343a952c"), 2, new Guid("645f3f7c-f68d-4f59-8c02-6fe385aaaa9a"), 39 },
                    { new Guid("f773ab4e-d036-44c4-87df-074a0a90bba5"), 10, new Guid("c022bcf3-d5dc-4745-a48d-47625a0c957b"), 40 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "CreateDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "IsExternalLogin", "LastModifiedDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileName", "ProviderName", "RoleId", "SecurityStamp", "TotalMoney", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("d961cc80-020a-46bb-ad17-1890a68cbc0f"), 0, null, "72fb5b3b-e5b6-4ed2-9720-af9163bca0ff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, "Jane", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("841c88ea-5020-4ca9-ba23-668b564514b7"), null, 1500m, false, "jane.smith" },
                    { new Guid("e2f1674b-6db8-4428-9e8d-54cc03438a3e"), 0, null, "bd388f97-ccbe-411d-b971-30aa105b8ffa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2204, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "machgiahuy@gmail.com", false, "Mach", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gia Huy", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("c14ae901-91eb-4fdc-be92-622250d013e2"), null, 1000m, false, "Mach Gia Huy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ShoeId",
                table: "Comments",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CommentId",
                table: "Notifications",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OrderId",
                table: "Notifications",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ShoeId",
                table: "Notifications",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ShoeDetailId",
                table: "OrderItems",
                column: "ShoeDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ShoeId",
                table: "OrderItems",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CommentId",
                table: "Replies",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeImages_ShoeId",
                table: "ShoeImages",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesColor_ShoeId",
                table: "ShoesColor",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesDetail_ShoeId",
                table: "ShoesDetail",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSeasons_ShoeId",
                table: "ShoeSeasons",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_ShoeId",
                table: "WishlistItems",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_WishlistId",
                table: "WishlistItems",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlists",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "ShoeImages");

            migrationBuilder.DropTable(
                name: "ShoesColor");

            migrationBuilder.DropTable(
                name: "ShoeSeasons");

            migrationBuilder.DropTable(
                name: "WishlistItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoesDetail");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
