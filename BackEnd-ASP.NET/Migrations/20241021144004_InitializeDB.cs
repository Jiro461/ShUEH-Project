using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEnd_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDB : Migration
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
                    { new Guid("1d5de0aa-0161-4c4e-9f6f-b2ef737a1ef9"), "Role Admin với đầy đủ các quyền hạn", "Admin" },
                    { new Guid("a49b1b99-be22-4f03-b9cf-20cba524a165"), "Role User với các quyền hạn có giới hạn và mua hàng", "User" }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "AverageRating", "Brand", "Category", "CreateDate", "Description", "Discount", "Gender", "ImageUrl", "IsSale", "LastModifiedDate", "Material", "Name", "Price", "Sold", "TotalRatings" },
                values: new object[,]
                {
                    { new Guid("0a26a72b-622f-42e4-aaa2-cefc17634ec5"), 4.6m, "Nike", "Basketball", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5903), "One of the best shoes for basketball and the symbol of Nike's World. You won't be able to take your eyes off of this brand new Jordan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5903), "Leather, fabric, foam, and rubber.", "Jordan 1 Low Bred Toe 2.0", 1813000m, 45, 23 },
                    { new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), 4.9m, "Nike", "Yoga", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5733), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5734), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66 },
                    { new Guid("178094dc-564b-47a8-bf9b-9f3da772e523"), 4.1m, "Puma", "Yoga", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5823), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5823), "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22 },
                    { new Guid("21b597b6-4049-4457-8414-413d2fd8226a"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5853), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5854), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10 },
                    { new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5849), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5850), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10 },
                    { new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4"), 4.4m, "Converse", "Basketball", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5861), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5862), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34 },
                    { new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5817), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5817), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23 },
                    { new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5752), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5753), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268 },
                    { new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7"), 4.2m, "Nike", "Tennis", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5729), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5730), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5 },
                    { new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), 4.0m, "Puma", "Basketball", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5808), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5809), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21 },
                    { new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5857), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5858), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45 },
                    { new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef"), 4.7m, "Converse", "Yoga", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5870), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5871), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30 },
                    { new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5843), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5845), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111 },
                    { new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5747), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5748), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84 },
                    { new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), 4.2m, "Puma", "Football", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5812), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5813), "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17 },
                    { new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5827), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5827), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87 },
                    { new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f"), 4.7m, "Nike", "Basketball", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5719), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5721), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45 },
                    { new Guid("9d34da5c-e479-490b-a07c-529975aca15b"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5803), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5804), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3 },
                    { new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5738), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5738), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381 },
                    { new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af"), 4.8m, "Nike", "Football", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5725), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5725), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10 },
                    { new Guid("b2fb9e8b-aac8-42a4-a618-69e68c86649b"), 4.7m, "Puma", "Football", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5911), "One of the best shoes for football and the symbol of Puma's World. You won't be able to take your eyes off of this brand new FUTURE, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5912), "Leather, fabric, foam, and rubber.", "Puma FUTURE 7 Ultimate FG/AG The Forever Faster", 2713000m, 78, 55 },
                    { new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5701), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5715), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20 },
                    { new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5831), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5831), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25 },
                    { new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063"), 4.4m, "Adidas", "Football", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5742), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5742), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37 },
                    { new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5839), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5839), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12 },
                    { new Guid("ddc8dcd6-295c-416f-b618-b379c76dba63"), 4.2m, "Adidas", "Basketball", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5907), "One of the best shoes for basketball and the symbol of Adidas's World. You won't be able to take your eyes off of this brand new SuperStan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5907), "Leather, fabric, foam, and rubber.", "Adidas Original StanSmith", 1713000m, 65, 33 },
                    { new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5865), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5866), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100 },
                    { new Guid("eddc8379-6a41-4ed1-90ad-7981e48742ce"), 7m, "Nike", "Basketball", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5898), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5899), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5 },
                    { new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5835), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 21, 21, 40, 3, 252, DateTimeKind.Local).AddTicks(5835), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("002cc3e5-f32d-4d2e-9e83-8e66644370a7"), new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("00f21f92-96fc-4808-86bf-2d03074c06eb"), new Guid("21b597b6-4049-4457-8414-413d2fd8226a"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("0153bfda-5ca6-4752-8531-aecb028bffb6"), new Guid("0a26a72b-622f-42e4-aaa2-cefc17634ec5"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQPenW_eiwOe1RkKeaF_kg5TraxKiem6NJ_Q&s" },
                    { new Guid("04a9b62e-4eec-417b-b60f-10c6e79be98f"), new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44"), "images/shoes/[IDGiay_24]_AnhChinh.jpg" },
                    { new Guid("0564b497-8ed4-4f81-9c03-847ae9d5c7b9"), new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("0791a105-d945-4646-81fe-dbe7841d4812"), new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), "images/shoes/[IDGiay_1]_AnhChinh.png" },
                    { new Guid("0f3a6c49-e7cd-4cde-8148-d5c9ccf64331"), new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c"), "images/shoes/[IDGiay_16]_AnhChinh.png" },
                    { new Guid("1108b953-baff-4761-8940-22cd3fe786a5"), new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("14d5759e-a536-4f70-96b5-b838ba606ebc"), new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("14d747e2-cf96-4dfa-80cf-fef67fcb9e16"), new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("16bed770-6bd7-402a-936d-0b02daf1b5b0"), new Guid("21b597b6-4049-4457-8414-413d2fd8226a"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("16faf82d-d01d-4188-abf6-69699509d874"), new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("1754affd-660a-43cb-b991-d2597502eec1"), new Guid("ddc8dcd6-295c-416f-b618-b379c76dba63"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-1.jpg" },
                    { new Guid("1972213a-85c2-4364-9e2a-21575f1c9c14"), new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("197a76ca-22b5-4ac0-a519-c925209b336d"), new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("1adf1b91-c708-48cf-9b7d-6c26f9c9aca2"), new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("1d076f34-8ec5-4020-a40d-95317c9c0239"), new Guid("ddc8dcd6-295c-416f-b618-b379c76dba63"), "https://assets.adidas.com/images/w_1880,f_auto,q_auto/e53b9a57b0a745be924bac1e00f54427_9366/FX5502_42_detail.jpg" },
                    { new Guid("1f9ae1af-2974-404d-9ea0-ba62b94f04c0"), new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("21cd26f0-3e84-4bfd-b835-37910d5423bb"), new Guid("eddc8379-6a41-4ed1-90ad-7981e48742ce"), "https://c.files.bbci.co.uk/1081F/production/_117751676_satan-shoes2.jpg" },
                    { new Guid("224cc53d-1d8a-4ef4-bee6-2e5710df7db3"), new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("23fa071d-7b02-4820-90a4-c593eedb7a25"), new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("259cf133-e7bd-410b-8aa7-8d08316fb45c"), new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("25df818a-bfbe-4a4b-a72b-dff68887e2b5"), new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063"), "images/shoes/[IDGiay_7]_AnhChinh.jpg" },
                    { new Guid("274501e9-3ff3-45c8-9454-8261b7e52a95"), new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("2ce48e3c-31e6-43ba-986c-e711dd33f73d"), new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("30add362-5908-4bf2-a930-0f4ad3b5231f"), new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("31e4f698-9e2b-47cc-bdaf-264e43edf726"), new Guid("21b597b6-4049-4457-8414-413d2fd8226a"), "images/shoes/[IDGiay_21]_AnhChinh.jpg" },
                    { new Guid("33cfc9ad-a79a-4874-b2b8-e85cf76a9f07"), new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("358a8f1d-5429-48a2-904e-e0de99eecaab"), new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("39c8991b-9215-4b66-9861-7d2dde8e8198"), new Guid("0a26a72b-622f-42e4-aaa2-cefc17634ec5"), "https://dmpkickz.com/cdn/shop/files/6_78fd24e0-cd30-400a-8fa1-e5e6cd3c5b0b.png?v=1696679846&width=480" },
                    { new Guid("3b5558c7-31db-4a98-991e-c72386cf3a90"), new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("3cd293aa-d645-41b0-adf8-f4f479e0a229"), new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7"), "images/shoes/[IDGiay_4]_AnhChinh.jpeg" },
                    { new Guid("3e742454-d073-43dc-8c9f-012f0612de42"), new Guid("eddc8379-6a41-4ed1-90ad-7981e48742ce"), "https://i.pinimg.com/originals/c0/cf/d1/c0cfd1545f10c56793e888e991b60487.png" },
                    { new Guid("3ea39b1e-24bb-4c41-b21e-d681a585510a"), new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("422bd580-b34b-42d4-ac8e-ac7912740b66"), new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), "images/shoes/[IDGiay_11]_AnhChinh.png" },
                    { new Guid("432a136c-3a9e-4d7f-abb0-fd38594c9750"), new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0"), "images/shoes/[IDGiay_17]_AnhChinh.png" },
                    { new Guid("47c03084-95e1-479c-9d71-fde7559d9b0f"), new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("47eea62f-9126-4779-a825-b4843040e095"), new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("48c4eb45-154c-4434-a2a3-6573387f5b05"), new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("4abec5ae-12ae-4819-b7cf-09bff3f3eeb4"), new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("4ea2e994-323b-435b-a650-0ea93b7db95a"), new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("4fcf12d2-0cc7-4e3f-8d84-5682ed9628b0"), new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("5361016a-a3e5-4d76-adaf-27b11d847b2b"), new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("53ade21b-16fd-44dd-a816-83225e0a25f3"), new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("56d9a257-da91-47b7-a297-bae054d4960a"), new Guid("0a26a72b-622f-42e4-aaa2-cefc17634ec5"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3rZPCUSKRHdQA5_g3YBJRdcmIf_6PpZcNZg&s" },
                    { new Guid("573485ee-5bc7-4591-81ed-a7bdfc29e616"), new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4"), "images/shoes/[IDGiay_23]_AnhChinh.jpg" },
                    { new Guid("5a8828ef-9dcc-4971-ad16-626c02820374"), new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("5cd4b3dd-df1b-4ab2-be51-24a732360fef"), new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("5e5ed15d-1462-4506-83a7-7f118465bd36"), new Guid("178094dc-564b-47a8-bf9b-9f3da772e523"), "images/shoes/[IDGiay_14]_AnhChinh.jpeg" },
                    { new Guid("60ec9c12-019f-4b0a-aa39-ea62e945b2de"), new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("614760b0-7d18-4343-881d-67b7e6a2ee7a"), new Guid("0a26a72b-622f-42e4-aaa2-cefc17634ec5"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNBQXFHswxHuyjT_e8rb5XOaWUzEe3pphPPw&s" },
                    { new Guid("62840e53-aec1-4baf-b2ef-70d3c16a1017"), new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("642e33c3-b972-46f9-8694-fe59c257c4d5"), new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("649506cc-133c-4387-a484-6f06ae7e3f14"), new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("675caf63-dd54-46a1-9a55-246d234cfb1f"), new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("691e5919-83aa-4d13-842b-692c69a79989"), new Guid("ddc8dcd6-295c-416f-b618-b379c76dba63"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-3.jpg" },
                    { new Guid("6a473350-06d8-43f5-888a-7fde2ac24445"), new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("6d962edb-1226-4697-8803-519ca57fcb6a"), new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), "images/shoes/[IDGiay_8]_AnhChinh.jpg" },
                    { new Guid("6df40e33-aadd-4ae4-acb0-83cd13e75b5f"), new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("6e9c48ca-cc0e-44ce-8e5b-3bde006cf5e2"), new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7"), "images/shoes/[IDGiay_6]_AnhChinh.jpg" },
                    { new Guid("70436d5d-80eb-49f4-a803-b917fc408faf"), new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("744f6bfe-c053-4610-95ac-732f0826e85e"), new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("74b8856c-e200-4d7b-8a43-40c42c7dd985"), new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("7550289e-abdd-4ec7-8974-fcb08254009e"), new Guid("21b597b6-4049-4457-8414-413d2fd8226a"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("75ce75ae-c6cd-4f26-a651-1771620a8bc7"), new Guid("178094dc-564b-47a8-bf9b-9f3da772e523"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("78088692-fe5a-4eb8-9fed-ca0b1752bbdb"), new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("7879c12a-33a3-4bf3-b221-9e8476c718f8"), new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("7b963066-d143-47d1-a01c-4dacbb7bbbbf"), new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("7cadd9f4-b208-42ef-98d0-24a3b1eac351"), new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("7cc53d69-9680-45d8-b26e-2f21c83380e3"), new Guid("9d34da5c-e479-490b-a07c-529975aca15b"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("7ddf8f94-ac99-4a95-ba0d-48df82538bf9"), new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4"), "images/shoes/[IDGiay_15]_AnhChinh.jpeg" },
                    { new Guid("7e124df1-48ff-434f-a99b-ae2e98a1db2f"), new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("7e934749-bd53-499b-a493-a34a88bf98ca"), new Guid("9d34da5c-e479-490b-a07c-529975aca15b"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("7f4d7a50-389d-4f04-b6b2-d0037961dcbe"), new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("80806e78-e49f-472c-9c4a-38ca535427af"), new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("81d1d1fe-2e15-45cc-9f47-3ba84a2b412f"), new Guid("eddc8379-6a41-4ed1-90ad-7981e48742ce"), "https://gossipdergi.com/wp-content/uploads/2021/04/nikeayakkabi.gif" },
                    { new Guid("858dd249-12e8-4825-b314-621ff5893f50"), new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3"), "images/shoes/[IDGiay_13]_AnhChinh.jpeg" },
                    { new Guid("868dbda2-1a3e-4dbb-b103-2c1d00dd24ff"), new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("8751e2d1-5448-45e7-ab24-191a95df6f29"), new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("8b3bb606-b208-4c6e-a99a-288896da50c6"), new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("8c0daee2-053c-42a7-a777-02492d9a4088"), new Guid("178094dc-564b-47a8-bf9b-9f3da772e523"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("8c44a0e2-7b8c-43df-83da-052637d806a8"), new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("8feb11bf-550c-4fc8-a9f7-c11d98450380"), new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), "images/shoes/[IDGiay_5]_AnhChinh.jpeg" },
                    { new Guid("92ff008c-6e12-4bf9-97a7-60d036ba3fdd"), new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35"), "images/shoes/[IDGiay_20]_AnhChinh.png" },
                    { new Guid("9478f919-c373-41f8-91a0-afa9ffe015d2"), new Guid("21b597b6-4049-4457-8414-413d2fd8226a"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("95379d7b-c9a0-4d75-a533-eba25f71d45e"), new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4"), "images/shoes/[IDGiay_9]_AnhChinh.jpg" },
                    { new Guid("96fa3b50-c12c-4607-b900-1daf20847c47"), new Guid("b2fb9e8b-aac8-42a4-a618-69e68c86649b"), "https://thumblr.uniid.it/product/336262/8307c19dcf3d.jpg?width=3840&format=webp&q=75" },
                    { new Guid("9a0ca80a-c79e-4fcc-b0d3-d59a7b1d1e6b"), new Guid("b2fb9e8b-aac8-42a4-a618-69e68c86649b"), "https://thumblr.uniid.it/product/336262/57daee260d2a.jpg?width=3840&format=webp&q=75" },
                    { new Guid("9d84f395-c238-4a32-9b25-0e1565a513ef"), new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("9e26b1f0-e771-4104-8606-7b7300bd9383"), new Guid("9d34da5c-e479-490b-a07c-529975aca15b"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("9e87c79d-6a3b-4f41-8eae-741567dbab66"), new Guid("9d34da5c-e479-490b-a07c-529975aca15b"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("9e8d2e9c-b46f-438e-9745-f771e1916595"), new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("a01d71fd-02b1-48e0-ad62-e098d10d421a"), new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("a05cb3b1-97ed-4ac7-a34e-95ffb30c7860"), new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("a06e8cc6-730a-403a-9d7c-c0391de1da1d"), new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af"), "images/shoes/[IDGiay_3]_AnhChinh.jpeg" },
                    { new Guid("a1906795-7aff-403a-997c-d1df9093cca7"), new Guid("b2fb9e8b-aac8-42a4-a618-69e68c86649b"), "https://thumblr.uniid.it/product/336262/a92a6cadc8a6.jpg?width=3840&format=webp&q=75" },
                    { new Guid("a296637b-645e-47ba-bade-e7bddce3b8eb"), new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("a296f704-957a-4679-85b2-89ba721e78a4"), new Guid("9d34da5c-e479-490b-a07c-529975aca15b"), "images/shoes/[IDGiay_10]_AnhChinh.jpg" },
                    { new Guid("a8f2dbde-3ff4-46b3-804c-274262af553e"), new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("a94d0f2d-f81d-4777-ab26-b1f79c9efe1f"), new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("aa549250-fc63-49ad-b34d-3dcdab6b9c4a"), new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef"), "images/shoes/[IDGiay_25]_AnhChinh.jpg" },
                    { new Guid("ac0e9dad-f17f-4d93-bfc6-4f816485bc54"), new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("ada5b1ae-6802-45b0-b6be-93e11cb31593"), new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("ae19fe8c-1e29-4abb-a9f1-3daaf388f62a"), new Guid("eddc8379-6a41-4ed1-90ad-7981e48742ce"), "https://photo.znews.vn/w660/Uploaded/rohunwa/2021_03_26/SHOES3.jpeg" },
                    { new Guid("b032f188-3820-475b-bad4-eb26dfa48800"), new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("b0c90155-82e6-4479-bb5b-94e9200b7b7f"), new Guid("b2fb9e8b-aac8-42a4-a618-69e68c86649b"), "https://www.prosoccer.com/cdn/shop/files/PumaFuture7UltimateFGAG-ForeverFasterPack_SP24_Model1_1500x.png?v=1713488175" },
                    { new Guid("b1ff4bd5-8351-44e3-b88c-1b896a0fda70"), new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("b2b2ae38-c4bf-4915-9bcc-9ba93100afa4"), new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("b2dcfda8-3ee5-40be-a30f-944a65526a31"), new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("b5fb6fc8-68b1-4a49-ae33-33ff9f3d59ab"), new Guid("178094dc-564b-47a8-bf9b-9f3da772e523"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("b6cc7548-639c-4cfc-9a96-8011a458d419"), new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("beacc3a1-86d1-4b33-8fe3-f56cb2441375"), new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("bff6d39f-e105-41b7-b6c4-d126cc6ae46b"), new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), "images/shoes/[IDGiay_18]_AnhChinh.png" },
                    { new Guid("c08bd008-6105-4199-9044-672533c41f08"), new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c"), "images/shoes/[IDGiay_19]_AnhChinh.png" },
                    { new Guid("c4a71735-28ba-4e6a-a1c6-928265a9d34c"), new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("c58804d2-1267-4d42-b7bc-2131b4afd03c"), new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("c69cda3b-88cf-48af-82c8-e19d1a847e37"), new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("ce910536-f541-4456-9870-996f09127d86"), new Guid("eddc8379-6a41-4ed1-90ad-7981e48742ce"), "https://media.cnn.com/api/v1/images/stellar/prod/210328223753-03-lil-nas-x-satan-shoes.jpg?q=w_3000,h_3000,x_0,y_0,c_fill" },
                    { new Guid("d11d7035-75a7-491f-9723-0a027fabe9dd"), new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("d253d4ba-dfb8-4308-a4a3-966de7709e0a"), new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("d2bf1846-f71c-4773-bef7-94915812602b"), new Guid("ddc8dcd6-295c-416f-b618-b379c76dba63"), "https://likelihood.us/cdn/shop/files/stansmith_angle_1200x.png?v=1691430477" },
                    { new Guid("d46e32e8-4949-49f6-8e05-33798bb45e1f"), new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("d5acd2bf-79df-4ce6-8897-9dd3a400e12e"), new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("d7e629ee-06a8-405c-9fd4-a5a40a56194b"), new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), "images/shoes/[IDGiay_12]_AnhChinh.jpeg" },
                    { new Guid("d8fef1ae-5b7d-40c9-9939-4eb892279acb"), new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("d98a030b-3863-4b9a-835f-7ff3f32ad862"), new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("db27aae1-fc8b-49d3-9ab6-2a05f15447ba"), new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("db5f7f75-340a-4d9a-b90b-04aaaa5558b6"), new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("e008d5f6-4dd1-4597-a5e4-408fe7cd225f"), new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f"), "images/shoes/[IDGiay_2]_AnhChinh.png" },
                    { new Guid("e2f6440c-36f0-4c3b-a9c4-28b077d62f61"), new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("e38f561d-af50-4a2d-84d3-f2e72ceaeab9"), new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("e487a17c-6130-4fd8-9ebb-1abd86d565a1"), new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("e4aa7486-fa62-4c54-9a0a-5cf709ef0ab7"), new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("eadb5b93-ebe2-40ac-9c03-2c589eab031b"), new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("ec0dc99b-c55d-48d4-a26f-0f17a2ca55c0"), new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("efd63bc4-5a2c-4aee-868e-ff5f361e6f41"), new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("f1fdd150-c062-4c31-a699-d7d9b0896911"), new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), "images/shoes/[IDGiay_22]_AnhChinh.jpg" },
                    { new Guid("f21e825a-593e-4a0d-9c5f-efe6078c96c7"), new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("f928bdc0-3364-49a4-b8e3-938b32ead1dd"), new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("fb499a50-6e25-4231-ad80-0980fe484559"), new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("fb80020f-891e-406c-bc43-c3f03818bc15"), new Guid("178094dc-564b-47a8-bf9b-9f3da772e523"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("fc30de11-93fa-4d25-8185-a009203220f0"), new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("05a82193-d91b-4c6f-a818-6cc971b16208"), "Summer", new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35") },
                    { new Guid("093ca10e-bd02-430e-b90a-971b54d1edf1"), "Summer", new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f") },
                    { new Guid("0baf060a-4d0c-43a7-a27f-31d320b62350"), "Summer", new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4") },
                    { new Guid("0fbd9c9c-4e38-4a9b-b3f8-382c1521738a"), "Summer", new Guid("9d34da5c-e479-490b-a07c-529975aca15b") },
                    { new Guid("1a5e48cb-f296-4e2f-bf13-b41c917bc594"), "Winter", new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08") },
                    { new Guid("1f01322b-fef0-488f-897d-11577dc4954b"), "Spring", new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7") },
                    { new Guid("205bd89f-a31d-4ad4-adf8-892d54b65fb7"), "Spring", new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44") },
                    { new Guid("23fdd47f-e70d-4b3c-9def-66feefc0dafe"), "Summer", new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f") },
                    { new Guid("3084c6fd-bc2a-4d97-affb-6c2ea6ca0763"), "Winter", new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7") },
                    { new Guid("31660023-2bb6-4f59-8c78-5a3597b5e2e9"), "Spring", new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af") },
                    { new Guid("316894e1-dbe3-4f39-b184-18dc85fbd496"), "Winter", new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0") },
                    { new Guid("33007bbe-3b0f-4b34-ad89-703c98826c82"), "Spring", new Guid("178094dc-564b-47a8-bf9b-9f3da772e523") },
                    { new Guid("3a22a26a-0694-4fbf-a1cb-374f480f9068"), "Summer", new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7") },
                    { new Guid("3c07f3b6-6705-4771-930f-a526052e8a2e"), "Summer", new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429") },
                    { new Guid("3c1f0c5b-3bf2-4463-be81-af1f0268d12c"), "Fall", new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44") },
                    { new Guid("42c55363-f3bf-4465-aa0d-5ab9ec6537b0"), "Spring", new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4") },
                    { new Guid("48338925-a544-4897-adc2-c90acba06c66"), "Fall", new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973") },
                    { new Guid("54067e71-8dfb-4e9c-9bb9-b999bccbbcce"), "Spring", new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c") },
                    { new Guid("543db967-21e2-4464-91d7-0781a25fe4e1"), "Winter", new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4") },
                    { new Guid("62ea7ad2-ff21-451e-9bc0-a4c4d7bf4d36"), "Fall", new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340") },
                    { new Guid("639f2bcd-e46c-4ae7-ba15-4169cb4b48ee"), "Summer", new Guid("c692523f-1436-41a6-ac9e-e101109de5f0") },
                    { new Guid("65f514fe-72f4-4de7-ae92-0724330f5c61"), "Spring", new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340") },
                    { new Guid("749751a0-1d60-4739-88c6-5a7b2edce1c5"), "Spring", new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35") },
                    { new Guid("7555ee23-1b5e-414c-8f1a-a79859b553e5"), "Fall", new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c") },
                    { new Guid("7abdd5dd-64a1-4a2e-b51c-5e80d265353b"), "Summer", new Guid("178094dc-564b-47a8-bf9b-9f3da772e523") },
                    { new Guid("7b30c05c-8606-480f-bbe3-591aace1a80b"), "Winter", new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f") },
                    { new Guid("7ece9bff-76f2-49a5-8bc3-4bbc29718bdb"), "Fall", new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7") },
                    { new Guid("7eefd11b-e3cb-46a2-8815-86921e25349d"), "Winter", new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35") },
                    { new Guid("8235347d-61a0-4491-ab45-88c3d1ecd258"), "Winter", new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f") },
                    { new Guid("865a8b72-e478-482e-bfc9-4940f767b49e"), "Winter", new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340") },
                    { new Guid("868d1c1d-7d30-44bc-9fa2-cad5617194d7"), "Winter", new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4") },
                    { new Guid("8f99413a-ced2-4d44-b5b6-1734d8a03cf7"), "Fall", new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063") },
                    { new Guid("9665ac68-b55d-46b1-8826-04b69e9e7e6e"), "Spring", new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429") },
                    { new Guid("96cf4f81-6473-4e79-a1cc-43a521eaa668"), "Summer", new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c") },
                    { new Guid("9a8b79ca-6f9d-4701-997a-876cc803a766"), "Winter", new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c") },
                    { new Guid("9d3bdec6-db25-4d65-ba2a-133ced4e884e"), "Winter", new Guid("21b597b6-4049-4457-8414-413d2fd8226a") },
                    { new Guid("a7109a7a-3c39-4223-ba35-a012566e945d"), "Summer", new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7") },
                    { new Guid("aa136d57-3f6c-4620-aa37-450262fc770a"), "Summer", new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3") },
                    { new Guid("ab6ccf8c-d125-421c-bef3-757e83fe44a8"), "Spring", new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef") },
                    { new Guid("ae915b68-9f9f-4b55-9372-91b629e664ea"), "Fall", new Guid("21b597b6-4049-4457-8414-413d2fd8226a") },
                    { new Guid("c0d16bab-3bc6-46c2-b6f1-05201046229a"), "Winter", new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c") },
                    { new Guid("c13f3e08-5f78-4bc2-8b82-0650f7343cf7"), "Fall", new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f") },
                    { new Guid("d4bd806e-3f3e-4ca3-aa28-101d6caea641"), "Spring", new Guid("9d34da5c-e479-490b-a07c-529975aca15b") },
                    { new Guid("d5c77425-dbcb-4737-8f9e-4829d7d96fd5"), "Spring", new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063") },
                    { new Guid("d767b77a-5fc1-48e8-ae9f-38da6e350783"), "Fall", new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08") },
                    { new Guid("f11d3106-5f29-4b78-9153-04f4a5c6c66b"), "Summer", new Guid("21b597b6-4049-4457-8414-413d2fd8226a") },
                    { new Guid("f2aeaefa-6245-4a20-b808-bb5a0b8f74d9"), "Summer", new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063") },
                    { new Guid("f34f6e0f-4b2b-407b-9f58-8959be3b72f7"), "Spring", new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4") },
                    { new Guid("f5ae5abd-672d-4b53-a63d-12d110b5e9ac"), "Winter", new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063") },
                    { new Guid("f6620a0e-7944-4dad-a250-56c545bfc300"), "Spring", new Guid("21b597b6-4049-4457-8414-413d2fd8226a") },
                    { new Guid("fecf1906-f4ec-4006-9202-c9e170528520"), "Spring", new Guid("c692523f-1436-41a6-ac9e-e101109de5f0") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("041adb9f-a3ee-4647-a0b9-0b939e6b5327"), "Pink", new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0") },
                    { new Guid("08c44f6a-3b7e-4806-ad04-19efddbeaf88"), "White", new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af") },
                    { new Guid("0bfd103b-323d-46ae-971d-ec987aae0def"), "Black", new Guid("9d34da5c-e479-490b-a07c-529975aca15b") },
                    { new Guid("0d442ce3-8985-4b9c-9ec1-16e585be9afc"), "Blue", new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f") },
                    { new Guid("106de0d4-8584-41fc-bce3-cf22da9a85ac"), "Black", new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08") },
                    { new Guid("10702af1-885a-4b41-be11-5dc98dc94d08"), "Red", new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7") },
                    { new Guid("10ea5ad7-0491-44ac-b832-35d01fa8c7b3"), "Purple", new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973") },
                    { new Guid("153798dc-cf27-4eba-9f2b-1faf3ffe272f"), "White", new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c") },
                    { new Guid("160d33f7-7e30-4cce-81c4-990de8303e27"), "Blue", new Guid("c692523f-1436-41a6-ac9e-e101109de5f0") },
                    { new Guid("171d8327-0537-44a8-ab7f-3832c2496d96"), "Black", new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f") },
                    { new Guid("1b393bb9-2ab2-4805-aaf4-8371d42a305c"), "Green", new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7") },
                    { new Guid("1f76fd77-be8a-407b-a293-6659700725bc"), "Orange", new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3") },
                    { new Guid("242f92d8-c92e-4341-8a37-c30e197b6536"), "Brown", new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef") },
                    { new Guid("277d9d9f-3894-49a0-a971-1183acdebce8"), "Pink", new Guid("178094dc-564b-47a8-bf9b-9f3da772e523") },
                    { new Guid("2a94b5cb-c6bb-48f6-8cca-6d68a827b420"), "Black", new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c") },
                    { new Guid("3006b5ac-0a16-48e8-ae5b-fcced7225b4b"), "Black", new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f") },
                    { new Guid("34de0719-a3c2-4055-90a4-50739b3a1d38"), "Blue", new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4") },
                    { new Guid("37d7bd59-82ef-4c76-a29b-7109b03e146b"), "Green", new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef") },
                    { new Guid("3cb82948-8c4e-40ea-93a2-9d8587e401f5"), "White", new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44") },
                    { new Guid("3d09f81a-71bd-4a87-9c4f-801938ba03fe"), "Blue", new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340") },
                    { new Guid("429d9709-a034-48f9-9781-3176584c3c6a"), "Black", new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af") },
                    { new Guid("450d29e6-e549-4220-a828-1420e8b6ff58"), "Black", new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7") },
                    { new Guid("48adfe78-c1da-42f1-b85c-df95cd24d382"), "Blue", new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7") },
                    { new Guid("4bb4a352-bcaa-40fa-bdb5-770d68825470"), "White", new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4") },
                    { new Guid("50c77410-aeb1-4e20-8a66-a71668491fa1"), "White", new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7") },
                    { new Guid("58e9edf2-3abd-4dcc-9f00-000b6376b49f"), "Purple", new Guid("9d34da5c-e479-490b-a07c-529975aca15b") },
                    { new Guid("5bb3cd18-2fa9-4773-8978-e796534baf26"), "Yellow", new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af") },
                    { new Guid("5fd044cf-bdb0-4b92-9683-23b6bf938fba"), "Grey", new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c") },
                    { new Guid("6158141b-480f-47bc-9e21-1b30699880c7"), "Blue", new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c") },
                    { new Guid("63d4af50-6f1a-4db5-9e0c-556025bfde04"), "Brown", new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44") },
                    { new Guid("6b7ab67a-ed4a-4422-8da6-a430715b6049"), "Pink", new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af") },
                    { new Guid("766c5d78-288b-408a-b733-45b72fe66667"), "Red", new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f") },
                    { new Guid("7f649f40-8750-4479-ba7a-e996d3fdd8ea"), "Yellow", new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063") },
                    { new Guid("7fce302d-f467-4d68-b5dd-8e60c7fc1428"), "Black", new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340") },
                    { new Guid("86a2fc76-1470-4914-8424-027cce7e8b77"), "Blue", new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0") },
                    { new Guid("8796618e-d044-407a-bd6e-d8584f80ff42"), "Orange", new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08") },
                    { new Guid("889a5486-8dbd-4674-a6d6-03a539fbb3f5"), "Brown", new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7") },
                    { new Guid("89123446-7b25-4d8c-95f0-04f05928d125"), "Purple", new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429") },
                    { new Guid("8a7d66ac-b7ac-468f-8ee8-9978220dd88c"), "Black", new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4") },
                    { new Guid("8e66bd25-1ccd-4c63-ae58-36d2603349a1"), "White", new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429") },
                    { new Guid("9218ae8b-f391-45b7-b5e6-0f84dc23f732"), "Pink", new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4") },
                    { new Guid("993653ea-add1-42cb-8cae-424553580482"), "White", new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f") },
                    { new Guid("996cc233-9d2c-4717-850a-4831f288b00b"), "Black", new Guid("21b597b6-4049-4457-8414-413d2fd8226a") },
                    { new Guid("a70c7455-9710-4d8e-a402-cc6cc51f44f4"), "Orange", new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973") },
                    { new Guid("b3c92905-8f42-4ee8-8780-4a9d57ecd368"), "Pink", new Guid("9d34da5c-e479-490b-a07c-529975aca15b") },
                    { new Guid("b4166c2e-bd68-4d2f-a8e6-ae6bb3ea7d35"), "Black", new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4") },
                    { new Guid("b83e23f5-1cfc-46fb-a498-616bb1f1fa5d"), "Blue", new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429") },
                    { new Guid("b9d62d77-88e1-4d0e-a9c0-1365b5ddae2a"), "Blue", new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35") },
                    { new Guid("d1210a2b-02e3-4da3-9d49-7414f6a623db"), "Red", new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4") },
                    { new Guid("d47c00a3-7fdf-4e9e-968f-5c623d160800"), "White", new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08") },
                    { new Guid("dd370cf7-2aa1-4e78-a8bb-1e001b9d0f6e"), "Black", new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7") },
                    { new Guid("df658318-9b36-448c-a94c-39274c58831c"), "Orange", new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7") },
                    { new Guid("e575dc64-6aa2-4dc9-b939-55a80e2f38ed"), "White", new Guid("9d34da5c-e479-490b-a07c-529975aca15b") },
                    { new Guid("e65ec087-6c74-4cfa-a008-7d073a1e4ada"), "Red", new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063") },
                    { new Guid("e91ca8d2-e7c6-4938-8ac9-f896e7eec1dc"), "Green", new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340") },
                    { new Guid("f299e738-4013-4500-bd39-a2b7f68eccbb"), "White", new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4") },
                    { new Guid("f4804234-d9cf-487d-9ad3-79e0795e17b7"), "Blue", new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af") },
                    { new Guid("f4f34b74-bb08-4e02-8f30-6f6b79ac14e6"), "White", new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7") },
                    { new Guid("f6225f2e-ff98-47e0-a483-178fe09b8e03"), "Blue", new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4") },
                    { new Guid("fa31b88a-b929-4da5-ba21-b00aa2a9f277"), "Black", new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429") },
                    { new Guid("fb1e0e5e-16f7-431d-8cd0-683000bed188"), "Black", new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3") },
                    { new Guid("fb7f922c-1e3b-4fb1-b920-784033e4ef65"), "Black", new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4") },
                    { new Guid("fe34b8f5-8785-4da3-b2e2-763a28b960e5"), "White", new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("00ddf616-5554-456c-89aa-124691f100b7"), 33, new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), 44 },
                    { new Guid("03986b87-f33e-4e9d-b8d1-75dab69bd2ab"), 24, new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c"), 39 },
                    { new Guid("05d733b7-89c7-4e34-8dfb-60b018fb648d"), 9, new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063"), 37 },
                    { new Guid("06b34c30-e37d-48b6-820a-e2f48ac22e99"), 13, new Guid("21b597b6-4049-4457-8414-413d2fd8226a"), 40 },
                    { new Guid("0ccfc4e7-3c13-4e7a-ab41-76cbe50c61dc"), 26, new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c"), 41 },
                    { new Guid("0d96b789-a687-42dd-9cce-bce5ee81b02d"), 42, new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), 40 },
                    { new Guid("1122a30d-ff60-47d7-be65-6305e5c5a3f5"), 8, new Guid("21b597b6-4049-4457-8414-413d2fd8226a"), 38 },
                    { new Guid("11cfe6e5-e9b6-44c2-9299-6bf49171b62e"), 41, new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), 41 },
                    { new Guid("13c75891-6c3d-48fb-b614-1f93f873b521"), 41, new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7"), 41 },
                    { new Guid("190fc1c6-31e8-49f1-aa45-655673c27b9e"), 25, new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), 37 },
                    { new Guid("1a52a2bc-01fa-4db6-969d-6f468a68dfd2"), 23, new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4"), 43 },
                    { new Guid("1c57771c-049f-4401-abd8-0be1dec68ff4"), 28, new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7"), 38 },
                    { new Guid("1f51a9a5-90e1-4744-b234-d10d217e854f"), 2, new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44"), 41 },
                    { new Guid("1f637352-797f-4460-9f05-8033db401625"), 47, new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7"), 42 },
                    { new Guid("1fbde733-fe03-4d4f-a73a-8caefb348ae2"), 47, new Guid("21b597b6-4049-4457-8414-413d2fd8226a"), 39 },
                    { new Guid("22916841-20ab-48c7-a3be-50e88c0b82bd"), 47, new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), 43 },
                    { new Guid("249fd163-9552-4c97-a67d-3ce06d0f41c5"), 34, new Guid("178094dc-564b-47a8-bf9b-9f3da772e523"), 41 },
                    { new Guid("26b0f831-1ff7-4e6f-bfa6-8bf1961c110e"), 18, new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c"), 40 },
                    { new Guid("28e56df8-3942-4f28-8a2d-9fadeac21b1c"), 41, new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), 38 },
                    { new Guid("31d51330-b87d-4d9c-832f-0995bbe012ff"), 7, new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4"), 39 },
                    { new Guid("345520db-96cc-44a7-86b9-93d8ed36f195"), 42, new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063"), 40 },
                    { new Guid("39d56a44-cb30-4a51-baeb-11ba519ae2fa"), 33, new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0"), 38 },
                    { new Guid("3a2ab908-b035-4ffb-b72b-6adb1a89c0ad"), 48, new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4"), 45 },
                    { new Guid("3e2795a8-530e-4e7f-93de-37dd46f10d0f"), 8, new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4"), 38 },
                    { new Guid("40032daa-c231-4fa3-a1b4-b123c888422a"), 40, new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c"), 38 },
                    { new Guid("4286fff8-81e2-4447-ba11-68a884195f3b"), 11, new Guid("21b597b6-4049-4457-8414-413d2fd8226a"), 37 },
                    { new Guid("4301d7a6-d6f0-4379-83d3-ebe004e6ef8f"), 26, new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4"), 37 },
                    { new Guid("47d9da92-f3ac-4c60-91cf-ffdac6b24353"), 18, new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), 44 },
                    { new Guid("48b84b80-b19f-421f-aa27-0af77c1f292e"), 29, new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), 42 },
                    { new Guid("48f0fb64-1219-4694-a543-51a94c0ea618"), 49, new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), 44 },
                    { new Guid("4fa41033-7386-4e23-b7fb-1506f29ee03e"), 24, new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f"), 39 },
                    { new Guid("50b9bd47-7efa-4fcf-814a-5116ee3f70ba"), 6, new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c"), 39 },
                    { new Guid("52d881eb-532b-4904-9f2b-117821aabf70"), 18, new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7"), 39 },
                    { new Guid("57463d5e-bbac-4e14-b709-69624939213f"), 2, new Guid("667909e0-8cc4-4619-a7a7-1d971ecc349c"), 40 },
                    { new Guid("5c0ff0f6-2f60-4db5-b7e3-f1a4f1310cc2"), 1, new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), 43 },
                    { new Guid("64a9e7d4-25c5-47cc-85db-b6794db5ed7c"), 40, new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), 45 },
                    { new Guid("65e9f6fb-8f4b-449f-846e-9f8c1aa663fd"), 48, new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), 43 },
                    { new Guid("6695532e-8b09-4b08-ba8c-87bac4178313"), 11, new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44"), 38 },
                    { new Guid("691e4fe0-ca84-4155-b8b4-00a5e3abe7c0"), 6, new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), 43 },
                    { new Guid("70a74e60-9af0-4993-858a-3212b022f4d4"), 49, new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063"), 38 },
                    { new Guid("718556a7-4398-462f-aed7-5b6594a568be"), 18, new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), 39 },
                    { new Guid("74967c79-64b0-4d42-a8fd-433737ae3b44"), 2, new Guid("178094dc-564b-47a8-bf9b-9f3da772e523"), 40 },
                    { new Guid("7c4d969a-22fd-4fff-98b2-3b1ec22f5263"), 16, new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44"), 39 },
                    { new Guid("7c6bd101-3398-493a-8abd-698b8a3d626f"), 46, new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), 42 },
                    { new Guid("819b0fc5-d8cc-4f22-8d9c-1c1a813f00c2"), 33, new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef"), 40 },
                    { new Guid("87438eb8-c737-4f42-a1e9-60937f720b41"), 20, new Guid("9d34da5c-e479-490b-a07c-529975aca15b"), 41 },
                    { new Guid("891c1947-a04d-49b9-b566-ba3a51a87e9d"), 30, new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0"), 40 },
                    { new Guid("89738cf8-fc1c-4f63-b8e7-7d71f2ee73f9"), 0, new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef"), 41 },
                    { new Guid("8be390ab-3540-42cd-9918-1b143847688f"), 27, new Guid("bb7e224c-10fd-44aa-b560-5cae8b99e93c"), 37 },
                    { new Guid("8c9843f3-91e6-497f-8207-4ef2ac8879f0"), 46, new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f"), 37 },
                    { new Guid("8d9d18f6-5236-44e9-a638-7fd4adbc3bbb"), 52, new Guid("ab4cee84-012d-4013-8faf-e660cda1fca7"), 40 },
                    { new Guid("905a6d93-91f5-4b5d-ac3f-fb4d13f06cbe"), 30, new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), 42 },
                    { new Guid("9188e3fe-7779-4e39-b948-818f5a102110"), 37, new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3"), 41 },
                    { new Guid("94839ec9-8d2b-49f0-b92b-4cf0023b83d3"), 54, new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), 45 },
                    { new Guid("98cd16c3-b26a-44ab-9e0c-8b4985287e59"), 38, new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), 39 },
                    { new Guid("9e5fb191-a156-436a-b031-bea71ed7427d"), 19, new Guid("9d34da5c-e479-490b-a07c-529975aca15b"), 40 },
                    { new Guid("9ef4e153-e146-4b4d-aac7-77d2dc1cd259"), 25, new Guid("9d34da5c-e479-490b-a07c-529975aca15b"), 42 },
                    { new Guid("a192b5fc-0e83-4a1d-8014-115e7716c3db"), 32, new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4"), 44 },
                    { new Guid("a1f3d102-8fa0-4b31-b88c-ea3521727a8a"), 24, new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4"), 40 },
                    { new Guid("a4aed2c0-d7cd-4fb3-8ad2-1b55849bb329"), 30, new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), 43 },
                    { new Guid("a4eb6cbc-caa1-46fc-9b7b-103166eef105"), 53, new Guid("362f30ba-8c18-4e81-a036-23165ad8f5b4"), 42 },
                    { new Guid("a5f11e05-a215-4c87-ae20-80fae6118cd7"), 8, new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), 41 },
                    { new Guid("a767325a-26ef-4731-8e6c-f335d7c84aaf"), 45, new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3"), 39 },
                    { new Guid("a7d99921-7a82-444a-a923-b88e1a2e1b82"), 3, new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0"), 39 },
                    { new Guid("adcba38e-f1f1-45a8-9b7a-66b0fce16f93"), 4, new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), 41 },
                    { new Guid("adf6bb95-9f11-41d5-a3b2-4000f99288d5"), 23, new Guid("178094dc-564b-47a8-bf9b-9f3da772e523"), 39 },
                    { new Guid("b2a1ba45-ff9e-47fd-92ee-5fd5667cb8f3"), 34, new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7"), 39 },
                    { new Guid("b6512afb-7ac5-4086-905d-2a1ca5c43646"), 49, new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4"), 37 },
                    { new Guid("bf00b259-5b7c-4864-824f-4c9ec94738fa"), 13, new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), 41 },
                    { new Guid("c17fb7a8-cf9d-485e-ba3c-c952cc9e60c2"), 36, new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), 42 },
                    { new Guid("c297f8ff-54fd-4224-9e0e-45cad0657bab"), 40, new Guid("89197c81-5d15-4d7a-a1cb-5b0a40ec8fb4"), 39 },
                    { new Guid("c3cd0128-8e4b-417e-b0c2-7a3bc1fc60bc"), 32, new Guid("fbe6527b-99b6-43d8-aa3d-b38df2b3d3d0"), 41 },
                    { new Guid("c48b1df1-0015-46be-a91a-b5aef32452a7"), 42, new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), 46 },
                    { new Guid("c53fd542-d8e5-42ac-a0d6-9c9b357a89f8"), 26, new Guid("49b2c377-7d9e-4c91-baf0-ff1f101cc973"), 44 },
                    { new Guid("cd448b98-6e4a-4c57-82b6-a844275557f6"), 29, new Guid("178094dc-564b-47a8-bf9b-9f3da772e523"), 42 },
                    { new Guid("d11e8828-424b-4bb9-a89f-b80e80c0aaf4"), 4, new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), 44 },
                    { new Guid("d40a3813-8d11-469f-b317-008b60329194"), 41, new Guid("3beebc53-8b61-4b6b-8341-6e620fdb01c3"), 40 },
                    { new Guid("d4143058-96ff-41a7-bbd6-ee89480c383a"), 38, new Guid("3e1edeb8-e5d6-455f-af85-75042dd6bfe4"), 38 },
                    { new Guid("d4e0fe77-b6d0-478f-a6e2-d459a453876f"), 26, new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), 42 },
                    { new Guid("d6c92f6e-a95a-4344-afa6-ce710606ab5c"), 25, new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35"), 39 },
                    { new Guid("d89edc46-bea4-4891-a5cf-d1a1f0ba8cbb"), 35, new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af"), 41 },
                    { new Guid("d8c1270d-9754-43a9-baa2-e3b00f8acf1a"), 54, new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), 45 },
                    { new Guid("d9c3a8c3-3f71-4c8b-afed-aabc2e28e5fd"), 33, new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35"), 37 },
                    { new Guid("dddcf40d-4937-4f1f-9c9f-c9108ae8aa8b"), 25, new Guid("bbd8684e-9b33-49b3-b096-7b69bf42c063"), 39 },
                    { new Guid("e2e2338e-9985-40f7-af0b-e8183fc2cfbe"), 20, new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af"), 40 },
                    { new Guid("e4b4c2a0-cb35-464a-8f67-2fc6c70ade3b"), 50, new Guid("46c1fd94-bbc3-4290-984a-2b9929291ca7"), 37 },
                    { new Guid("eaf1ad01-b883-46a2-b2fb-1979f8b8fa9e"), 47, new Guid("ba702c5f-bf56-4d5b-ba98-5aad27eb0429"), 46 },
                    { new Guid("edcd1c44-5592-4240-9610-2d904e71eae1"), 17, new Guid("595f023c-1fde-445c-9b4f-4518af4d88ef"), 42 },
                    { new Guid("f0d9df5f-802c-4ea6-94f9-470fc352539c"), 2, new Guid("0ccb4d47-0c78-4b74-b8d7-a21536a1ce08"), 42 },
                    { new Guid("f142650f-f609-4f23-a9a9-8733caa6a724"), 32, new Guid("c692523f-1436-41a6-ac9e-e101109de5f0"), 38 },
                    { new Guid("f1e10ed0-84dc-4f7d-96fd-cb1aca08a3e7"), 25, new Guid("4b583fac-3567-4821-a214-6ae29e8cf33f"), 45 },
                    { new Guid("f1e2f51a-c81d-4007-bbfb-ef31414c1365"), 38, new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), 40 },
                    { new Guid("f23df45c-4b86-4e21-b4bf-2f3c4284f37a"), 33, new Guid("2e6fa1c9-9b1d-49d0-a006-ca786169ad35"), 38 },
                    { new Guid("f6881d96-2d58-4422-b896-4136c0bbfe34"), 39, new Guid("b2e50506-bf7c-4dfc-b8d6-e5541a6357af"), 39 },
                    { new Guid("f732eed1-a469-49f4-bd89-b7f14858aaa5"), 25, new Guid("712cea1e-9860-4b7f-88f3-ee06c25a92f4"), 40 },
                    { new Guid("fbbdbfcd-2b0b-4672-b851-4741fd4c7855"), 20, new Guid("8bd76b6d-92a6-4247-b675-12e1c7c1b72f"), 38 },
                    { new Guid("fe3e8846-cc53-45d8-8a4c-f5767129e1b1"), 34, new Guid("7e61c6bb-6750-4785-9393-95ccb7ff4340"), 41 },
                    { new Guid("ff607e16-8458-4f8b-a81d-e3fd37f81c97"), 37, new Guid("eb3ad240-aef2-4b44-bee5-b80acd448c44"), 40 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "CreateDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "IsExternalLogin", "LastModifiedDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileName", "ProviderName", "RoleId", "SecurityStamp", "TotalMoney", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6e092fbf-e844-4370-a532-11510c9afa9f"), 0, null, "80eb9d79-c1eb-487d-acaf-c503d5f88431", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2204, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "machgiahuy@gmail.com", false, "Mach", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gia Huy", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("1d5de0aa-0161-4c4e-9f6f-b2ef737a1ef9"), null, 1000m, false, "Mach Gia Huy" },
                    { new Guid("e8063795-2a83-4ac4-858a-a60bddbc27c0"), 0, null, "60a01be4-0c26-4ed7-830a-fc024223cd31", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, "Jane", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("a49b1b99-be22-4f03-b9cf-20cba524a165"), null, 1500m, false, "jane.smith" }
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
