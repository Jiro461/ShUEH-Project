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
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromUserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToUserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MaximumDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MinimumOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductViews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductViews", x => x.Id);
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
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteViews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Device = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteViews", x => x.Id);
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsUsingDiscount = table.Column<bool>(type: "bit", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DetailOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_WishlistItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsReviewed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    GeneralReview = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalLike = table.Column<int>(type: "int", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id");
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
                name: "CommentLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "AverageRating", "Brand", "Category", "CreateDate", "Description", "Discount", "Gender", "ImageUrl", "IsSale", "LastModifiedDate", "Material", "Name", "Price", "Sold", "TotalRatings", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("01903349-0db9-455e-9991-9348e3664df1"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2689), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/[IDGiay_22]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2690), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45, 0 },
                    { new Guid("0beafae7-bbce-4745-8005-5ab818afcecf"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2685), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/[IDGiay_21]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2686), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10, 0 },
                    { new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2672), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/[IDGiay_18]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2672), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12, 0 },
                    { new Guid("112cdd93-39ec-4260-a710-f05b049e43b0"), 4.7m, "Converse", "Yoga", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2702), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/[IDGiay_25]_AnhChinh.png", true, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2703), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30, 0 },
                    { new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2681), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/[IDGiay_20]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2682), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10, 0 },
                    { new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e"), 4.2m, "Nike", "Tennis", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2547), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/[IDGiay_4]_AnhChinh.png", true, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2547), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5, 0 },
                    { new Guid("28022637-653a-4246-829a-90e33ba9655b"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2663), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/[IDGiay_16]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2664), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25, 0 },
                    { new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2555), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/[IDGiay_6]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2555), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381, 0 },
                    { new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7"), 4.9m, "Nike", "Yoga", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2551), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/[IDGiay_5]_AnhChinh.png", true, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2551), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66, 0 },
                    { new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab"), 4.8m, "Nike", "Football", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2542), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/[IDGiay_3]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2543), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10, 0 },
                    { new Guid("339eca22-fd76-45c9-8595-555c3d3838b1"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2677), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/[IDGiay_19]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2678), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111, 0 },
                    { new Guid("34e83d10-ff04-48c1-9127-387847c39642"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2698), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/[IDGiay_24]_AnhChinh.png", true, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2699), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100, 0 },
                    { new Guid("47500b25-003c-4085-8aef-8d35b20f22e8"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 8, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2720), "Nike's first lifestyle Air Max brings you style, comfort and big attitude in the Nike Air Max 270. The design draws inspiration from Air Max icons, showcasing Nike's greatest innovation with its large window and fresh array of colors.", 40m, 1, "images/shoes/[IDGiay_Home_2]_AnhChinh_1.png", true, new DateTime(2024, 10, 8, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2720), "Plastics, yarns and textiles.", "Nike Air Max 270", 4059000m, 8, 3, 0 },
                    { new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2517), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/[IDGiay_1]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2533), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20, 0 },
                    { new Guid("678cce81-7921-4888-9643-21ba861b47d2"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 8, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2710), "Nike Youth React Presto Extreme combines lightweight React technology and a flexible upper to provide comfort and support for everyday activities and gym training.", 40m, 2, "images/shoes/[IDGiay_Home_1]_AnhChinh_1.png", true, new DateTime(2024, 10, 8, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2716), "Rubber, yarns and textiles.", "Nike Youth React Presto Extreme", 2069000m, 78, 60, 0 },
                    { new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c"), 4.4m, "Adidas", "Football", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2560), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/[IDGiay_7]_AnhChinh.png", true, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2561), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37, 0 },
                    { new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25"), 4.1m, "Puma", "Yoga", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2654), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/[IDGiay_14]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2655), "Leather, fabric, foam, and rubber.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22, 0 },
                    { new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2568), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/[IDGiay_9]_AnhChinh.png", true, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2569), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268, 0 },
                    { new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2564), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/[IDGiay_8]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2565), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84, 0 },
                    { new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d"), 4.2m, "Puma", "Football", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2580), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/[IDGiay_12]_AnhChinh.png", true, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2581), "Leather, fabric, foam, and rubber.", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17, 0 },
                    { new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036"), 4.0m, "Puma", "Basketball", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2576), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/[IDGiay_11]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2577), "Leather, fabric, foam, and rubber.", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21, 0 },
                    { new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b"), 7m, "Nike", "Basketball", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2706), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/[IDGiay_26]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2707), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5, 0 },
                    { new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab"), 4.7m, "Nike", "Basketball", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2538), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/[IDGiay_2]_AnhChinh.png", true, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2539), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45, 0 },
                    { new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2667), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/[IDGiay_17]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2668), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20, 0 },
                    { new Guid("e0a49743-f199-4e69-bea6-971f379c02b0"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2590), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/[IDGiay_13]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2590), "Leather, fabric, foam, and rubber.", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23, 0 },
                    { new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2658), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/[IDGiay_15]_AnhChinh.png", true, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2659), "Leather, fabric, foam, and rubber.", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87, 0 },
                    { new Guid("ea502478-c3eb-4054-841a-98867578a8b5"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2572), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/[IDGiay_10]_AnhChinh.png", false, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2573), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3, 0 },
                    { new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29"), 4.4m, "Converse", "Basketball", new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2693), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/[IDGiay_23]_AnhChinh.png", true, new DateTime(2024, 11, 7, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2694), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34, 0 },
                    { new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 8, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2772), "Whether you're starting your running journey or an expert eager to switch up your pace, the Downshifter 13 is down for the ride. With a revamped upper, cushioning and durability, it helps you find that extra gear or take that first stride towards chasing down your goals.", 40m, 1, "images/shoes/[IDGiay_Home_3]_AnhChinh_1.png", true, new DateTime(2024, 10, 8, 14, 23, 44, 634, DateTimeKind.Local).AddTicks(2773), "Plastics, yarns and textiles.", "Nike Downshifter 13", 2069000m, 78, 20, 0 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("004d8394-9cc1-4527-a7f4-7a25b88c9a8d"), new Guid("e0a49743-f199-4e69-bea6-971f379c02b0"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("01945284-e81e-4963-a97f-e8ccfb12b970"), new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("04474233-b6fc-44ed-b50c-ca58272d4ecf"), new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("06cf9e73-16f3-4100-b055-3221d6643133"), new Guid("01903349-0db9-455e-9991-9348e3664df1"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("0a0d2f8e-6d7a-4e05-8d93-5f2c88018774"), new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("0b5bde4e-a9f4-4fdf-ac75-7abe83e0776c"), new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("0c3025e4-e5b0-4081-9bf0-f751883e12cc"), new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("0ff03582-a606-414b-9f7b-b2f993bfefc8"), new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("0ff78fdb-fa35-4f22-831e-f9d96cf9929d"), new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b"), "images/shoes/[IDGiay_Home_3]_AnhPhu_1.png" },
                    { new Guid("1699bca6-f939-4fef-ac35-8e1b983d8651"), new Guid("47500b25-003c-4085-8aef-8d35b20f22e8"), "images/shoes/[IDGiay_Home_2]_AnhPhu_3.png" },
                    { new Guid("183c5d3a-40e7-4a04-ab5d-594f611ae7dd"), new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("184a07b3-9376-40d5-b8d9-098a6b91e0a9"), new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("1874b325-e4bd-4e26-a270-e166c7414932"), new Guid("01903349-0db9-455e-9991-9348e3664df1"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("18cb0ee5-0584-439c-a82d-81ac99714360"), new Guid("0beafae7-bbce-4745-8005-5ab818afcecf"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("1a09811f-e3c9-43af-be3c-da06be5c644b"), new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("1a353718-bbc7-40f2-ab4d-e7683798e667"), new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("1d76f17f-6dd0-48c8-842c-6cf16caf7dc6"), new Guid("678cce81-7921-4888-9643-21ba861b47d2"), "images/shoes/[IDGiay_Home_1]_AnhPhu_4.jpg" },
                    { new Guid("204d8262-4002-46be-87b0-add22f733299"), new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b"), "images/shoes/[IDGiay_26]_AnhPhu_3.jpg" },
                    { new Guid("215c47e5-4cd2-4b92-bd92-8fe33d10a745"), new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b"), "images/shoes/[IDGiay_Home_3]_AnhPhu_4.png" },
                    { new Guid("2399c0ca-e98e-48f8-bba4-eed76e68cbcb"), new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("260fc8a0-7121-4436-8749-2351f08fa3e0"), new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b"), "images/shoes/[IDGiay_26]_AnhPhu_4.jpg" },
                    { new Guid("306e4947-8902-448b-866c-4dc8e438fb28"), new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("370fc098-d357-4657-aa59-6a34518936c7"), new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("3f3047c6-7fde-4019-8dca-b4f5588a6c82"), new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("411a1846-8912-4f27-9494-aaf03b5285b1"), new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b"), "images/shoes/[IDGiay_26]_AnhPhu_2.png" },
                    { new Guid("43f6f1e4-8ad5-4784-93ce-cdc5ea9b098c"), new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("46ed7da3-a260-4ea7-87d0-5a67e30256d3"), new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("48546dc6-e590-45a1-8414-bbe91d9c5245"), new Guid("678cce81-7921-4888-9643-21ba861b47d2"), "images/shoes/[IDGiay_Home_1]_AnhPhu_1.jpg" },
                    { new Guid("4b7c85f8-3917-48be-bb1a-ea1a94c46fcc"), new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("53257371-fb7b-4060-993f-a2912263badc"), new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("55641d27-8e0e-4556-a1cd-71de5a26247d"), new Guid("34e83d10-ff04-48c1-9127-387847c39642"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("588b18a2-8e55-46c1-ae51-d671d8143184"), new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("5c273475-14c1-466b-8c8e-8434447e4107"), new Guid("e0a49743-f199-4e69-bea6-971f379c02b0"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("5ed81eea-39e3-407e-be93-e7254da98173"), new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("62ceebc2-16b5-49bc-b816-e464072ebf26"), new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("69aeb3e0-48c1-49be-bd2e-6016171040c8"), new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("6aa23d03-6756-4f0e-8d01-ed81d2734a24"), new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("6b1bf4ce-4ae2-46e1-ae63-71a2d48a74b8"), new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("6bd3892e-99d3-45a9-ac72-ac0132e2e71f"), new Guid("ea502478-c3eb-4054-841a-98867578a8b5"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("6cf7d114-5685-415b-94e6-381797207871"), new Guid("112cdd93-39ec-4260-a710-f05b049e43b0"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("6da25eac-1568-44b4-9f82-5451cab56308"), new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("6f28f40e-e24a-4be0-9278-1685fcefb3ec"), new Guid("ea502478-c3eb-4054-841a-98867578a8b5"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("709bd3c4-428e-4051-9dbc-0a0f31dfb690"), new Guid("0beafae7-bbce-4745-8005-5ab818afcecf"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("738cefce-2cf9-4509-ab35-b18f71be3b3c"), new Guid("28022637-653a-4246-829a-90e33ba9655b"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("73c49a3d-c44f-46ae-8189-e9560726b3ce"), new Guid("339eca22-fd76-45c9-8595-555c3d3838b1"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("74b121fe-0214-41aa-8460-68a5a41fe30e"), new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("75742824-5350-4e5d-9b4e-e044facf7c87"), new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("78885aa0-489b-46ec-8812-551534fca3bf"), new Guid("678cce81-7921-4888-9643-21ba861b47d2"), "images/shoes/[IDGiay_Home_1]_AnhPhu_2.jpg" },
                    { new Guid("78e4c723-d3cf-4dbb-8a65-e8422130d784"), new Guid("ea502478-c3eb-4054-841a-98867578a8b5"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("7b07df26-095e-48d7-b3aa-80f9ef44e387"), new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("7c9e95a9-0af0-48bd-b4f4-573feef40450"), new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("7d920d5a-9280-4937-a5d4-2417162f94dc"), new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b"), "images/shoes/[IDGiay_Home_3]_AnhPhu_3.png" },
                    { new Guid("7e2036ed-041a-4365-b777-59d319439be2"), new Guid("e0a49743-f199-4e69-bea6-971f379c02b0"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("80e6d3cc-5fef-495c-a3f0-515b8a25d867"), new Guid("0beafae7-bbce-4745-8005-5ab818afcecf"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("85d84a3c-e44f-4009-8417-fd342f4e92df"), new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("85ebe3c4-c705-4c8e-a4e0-f277a765d490"), new Guid("112cdd93-39ec-4260-a710-f05b049e43b0"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("877e1cdf-3f5b-4416-80f7-6f3dff5c7a57"), new Guid("28022637-653a-4246-829a-90e33ba9655b"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("88e178f1-b9cd-4a94-80b6-f8437a5b416b"), new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("89fcf2a4-5dd8-4550-bad6-d3ce2b999eb7"), new Guid("34e83d10-ff04-48c1-9127-387847c39642"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("8aa4d79b-4a39-4402-9149-cf8c277b9138"), new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("8ad80bdf-45ac-4129-85e5-7b62a5459362"), new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("8bb96a0c-209c-4674-bb24-869d445e611c"), new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("92c5f2d8-f100-4bb1-b7f5-00adccfeeaf2"), new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("92c713c8-c361-42b0-8a1f-7682a24af904"), new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("936e957f-74d3-48c5-a5ff-fa87a2c59645"), new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("983e5e93-4c9b-48bd-8a15-c2e8cc244959"), new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("99ffbf06-6a1c-4f33-a1ba-a78c15f37908"), new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("9d81c83c-67fd-4f1a-ac11-1f11ec735b02"), new Guid("34e83d10-ff04-48c1-9127-387847c39642"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("a3765718-1e8d-4c73-8f43-9deb9f577cad"), new Guid("28022637-653a-4246-829a-90e33ba9655b"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("a42c85fe-2e5c-4384-bab8-b25a5ac16d1d"), new Guid("339eca22-fd76-45c9-8595-555c3d3838b1"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("abe843db-1db5-4015-96d1-6cb731d74957"), new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("abed1530-9b93-4936-9c65-0fdf3f4df2ca"), new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("adb41722-b877-40e8-8421-f842a335562e"), new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("b09ef81d-3fe3-4e52-aeb2-54d6910b470c"), new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("b174703d-baec-4fdc-8bd7-63336e4f3af4"), new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("b2dec80d-0ef7-4f55-a3ae-9e64909f521b"), new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("b33d4108-49cf-41c4-981d-31d426444662"), new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("b8c6d038-bcdd-45ea-bb72-8877a70930aa"), new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("bdb27430-9ac5-43f8-8d8b-ce97f4d833fc"), new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("c3a58a60-5fd1-41ef-b03b-a1cd1feb90e6"), new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("c9f3ee40-fd5d-4f3c-ba48-44113d61ecf3"), new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("ca7bc7a0-1684-408e-bc81-8f6e86ccb80a"), new Guid("112cdd93-39ec-4260-a710-f05b049e43b0"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("cb9eb310-a87c-42b6-bda7-0c0a01e3496f"), new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("d1504f52-7043-42d7-9566-4695db641d85"), new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("d48eea20-2b70-48d0-b589-0483d38cd1e8"), new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b"), "images/shoes/[IDGiay_26]_AnhPhu_1.png" },
                    { new Guid("d56246b6-23eb-425e-83b2-70260fce2182"), new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("d5d1025e-5feb-469f-9471-e41076cec54b"), new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("d8fc3b95-3256-4a15-b8ee-79d62f4b0f6c"), new Guid("339eca22-fd76-45c9-8595-555c3d3838b1"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("db9acf7b-1687-460f-9274-6df630a71f96"), new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("dc6900c7-638c-422c-98a3-218a4b44ae2a"), new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("e0cb8229-6f92-4b90-abde-450068132359"), new Guid("28022637-653a-4246-829a-90e33ba9655b"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("e139ad74-9f90-4a19-8cac-3d48007438a5"), new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("e180145b-4332-43de-b0b0-7dafa2fc9e70"), new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("e2f4b58d-0233-405f-931d-7b2dd93f45fe"), new Guid("01903349-0db9-455e-9991-9348e3664df1"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("e59821ba-bdcf-405f-ae1d-2f2ecce7b4eb"), new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("e85c4c6e-2294-4402-baf4-f2f7e4ad9924"), new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("e8e93223-3431-451d-beae-39fa2af9251d"), new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("e929dedb-a55d-4b69-a9a8-ff1406097692"), new Guid("112cdd93-39ec-4260-a710-f05b049e43b0"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("eb273cde-4ac2-493d-aaf9-4dd2703d03a8"), new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("ebfc3e68-ecf8-4739-aa3a-8373c2854bf3"), new Guid("339eca22-fd76-45c9-8595-555c3d3838b1"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("f0182967-3516-465c-91aa-909fb1904419"), new Guid("ea502478-c3eb-4054-841a-98867578a8b5"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("f1d1fad6-20b3-4a1e-ae53-7729d6e8e8f6"), new Guid("678cce81-7921-4888-9643-21ba861b47d2"), "images/shoes/[IDGiay_Home_1]_AnhPhu_3.jpg" },
                    { new Guid("f1dbd7d2-1715-4c29-8bd3-a5eeee97faa6"), new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("f433b20c-0d33-4b68-8563-dc270cb2cae3"), new Guid("34e83d10-ff04-48c1-9127-387847c39642"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("f4cef342-f419-42b1-a87b-48625cd1e5f8"), new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("f5f57ef8-61da-4afb-a715-e4edeffce768"), new Guid("47500b25-003c-4085-8aef-8d35b20f22e8"), "images/shoes/[IDGiay_Home_2]_AnhPhu_4.png" },
                    { new Guid("f68404f5-fd53-4a49-aeec-018f37e4a921"), new Guid("47500b25-003c-4085-8aef-8d35b20f22e8"), "images/shoes/[IDGiay_Home_2]_AnhPhu_1.png" },
                    { new Guid("f72ff3a5-9fb0-46c4-a983-cb6004787626"), new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("f740326a-02ec-488c-9b1b-ac145149eb10"), new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b"), "images/shoes/[IDGiay_Home_3]_AnhPhu_2.png" },
                    { new Guid("f828985f-d6cf-49f8-80bf-48d955fece7f"), new Guid("47500b25-003c-4085-8aef-8d35b20f22e8"), "images/shoes/[IDGiay_Home_2]_AnhPhu_2.png" },
                    { new Guid("f8815ac4-cc1a-4e97-8def-05526a17468c"), new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("f8973adb-4fed-4ada-83ca-014464a82773"), new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("fcca11dd-9cd5-42f9-9dac-0a67f09d45ea"), new Guid("e0a49743-f199-4e69-bea6-971f379c02b0"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("fd6bc05d-88d4-4bdd-9ad0-8acbd74c3c23"), new Guid("01903349-0db9-455e-9991-9348e3664df1"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("fe767498-a04b-44e1-9cb2-6e61e0f39142"), new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("fea9ce2d-c33a-4990-8fdd-39aef3f45c19"), new Guid("0beafae7-bbce-4745-8005-5ab818afcecf"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("0297e223-b909-490e-b3de-f4a6fb48e33e"), "Fall", new Guid("28022637-653a-4246-829a-90e33ba9655b") },
                    { new Guid("0909a5cf-a2eb-4735-b146-d42d63d40ae4"), "Spring", new Guid("28022637-653a-4246-829a-90e33ba9655b") },
                    { new Guid("0ba19698-9e2f-49d6-aff5-e57c874a6cba"), "Spring", new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0") },
                    { new Guid("1b323127-63f3-437a-a6c4-f0783ac58991"), "Winter", new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b") },
                    { new Guid("1bdd6fff-fa94-4db0-b27e-a0e2aaab9b12"), "Winter", new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b") },
                    { new Guid("1c6208cc-0a2f-4b22-a62f-2f6eb8a41b32"), "Summer", new Guid("e0a49743-f199-4e69-bea6-971f379c02b0") },
                    { new Guid("2368b1b2-d641-4011-ac19-c9b120eafb3f"), "Winter", new Guid("0beafae7-bbce-4745-8005-5ab818afcecf") },
                    { new Guid("250c32ad-2aeb-4cc1-a793-23f8fcb2f68d"), "Fall", new Guid("34e83d10-ff04-48c1-9127-387847c39642") },
                    { new Guid("2567cc89-9b9a-4aed-ab3e-e24a3d21f571"), "Summer", new Guid("01903349-0db9-455e-9991-9348e3664df1") },
                    { new Guid("27d12e47-fa03-4be1-8233-94b2c75534d0"), "Winter", new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89") },
                    { new Guid("29baccb6-6a5d-434e-8388-526161626bb8"), "Summer", new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73") },
                    { new Guid("2bf4ce6e-b833-422b-8eff-9fdd3576a762"), "Fall", new Guid("47500b25-003c-4085-8aef-8d35b20f22e8") },
                    { new Guid("2c9ea2b7-bb02-4654-be32-d105cb8af4d9"), "Summer", new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac") },
                    { new Guid("307354ef-c02b-4360-9d55-19c05730cc90"), "Spring", new Guid("678cce81-7921-4888-9643-21ba861b47d2") },
                    { new Guid("31590d5a-f2ce-4e80-96af-ff4ede7c7bd0"), "Summer", new Guid("678cce81-7921-4888-9643-21ba861b47d2") },
                    { new Guid("3181899a-ff71-42cd-a0e2-b6f65ad969a6"), "Spring", new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73") },
                    { new Guid("40e22fe6-e7df-4426-89f3-c288f79bcd11"), "Fall", new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7") },
                    { new Guid("42b65e08-71e1-4cee-93ea-62f0968174e7"), "Fall", new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d") },
                    { new Guid("4a2e1ea6-afa6-4f40-bf45-02faf57f11f4"), "Spring", new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad") },
                    { new Guid("4edc3e70-2a47-4181-8006-c34f0828417d"), "Winter", new Guid("28022637-653a-4246-829a-90e33ba9655b") },
                    { new Guid("4ef049f8-7e74-4865-b0e9-846387ec41bb"), "Winter", new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff") },
                    { new Guid("5307fda5-c7c3-4925-89e3-06995744b546"), "Summer", new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25") },
                    { new Guid("56e63c7b-fbf3-4086-9dee-168b02f13802"), "Winter", new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e") },
                    { new Guid("585cec98-09ab-4baf-ae80-da1517644ebd"), "Spring", new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b") },
                    { new Guid("59ff0453-3321-46f3-b2da-3f6525f24419"), "Summer", new Guid("28022637-653a-4246-829a-90e33ba9655b") },
                    { new Guid("5b73898f-748e-4017-91d5-4841db2b5eb0"), "Winter", new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d") },
                    { new Guid("5f48d3c6-d608-4757-a8be-43aa328e335f"), "Fall", new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b") },
                    { new Guid("6400108b-bf94-4a28-908d-66ccea45f5e9"), "Summer", new Guid("0beafae7-bbce-4745-8005-5ab818afcecf") },
                    { new Guid("65b481e2-9689-4dbb-9afa-553e1c8fbed2"), "Fall", new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e") },
                    { new Guid("6a86d533-dc8f-456a-9f21-c05513960ce2"), "Spring", new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e") },
                    { new Guid("6c975a6b-a63c-442f-8ae0-1d2a0efb2edd"), "Summer", new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7") },
                    { new Guid("6efc265f-32c7-45a1-8627-174234fcdd4a"), "Fall", new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c") },
                    { new Guid("78a6a028-7257-486e-92ec-b74c25c69fa2"), "Fall", new Guid("0beafae7-bbce-4745-8005-5ab818afcecf") },
                    { new Guid("7aa6d1a0-d7fc-4b6d-8b6e-42718857cf82"), "Spring", new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d") },
                    { new Guid("7acc0260-7ddd-4eb7-a6b0-3031f7ffbbba"), "Fall", new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b") },
                    { new Guid("7f61c44b-1209-404b-95eb-30680c30e92b"), "Summer", new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0") },
                    { new Guid("81dec256-b5e1-4d26-bdbc-ebb28c62aac6"), "Spring", new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7") },
                    { new Guid("8f672ea9-c131-49f8-acbe-f9dff6d0a57d"), "Winter", new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73") },
                    { new Guid("93f1162f-51ac-48c7-9cf2-ffaf92b3735f"), "Spring", new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c") },
                    { new Guid("a2dac861-6dfb-4330-9308-150e158776f3"), "Spring", new Guid("47500b25-003c-4085-8aef-8d35b20f22e8") },
                    { new Guid("a5347107-a6c5-449b-a04a-dcc9b192c7c5"), "Spring", new Guid("34e83d10-ff04-48c1-9127-387847c39642") },
                    { new Guid("a6c85856-7e71-44ac-8fee-ad0a1119a608"), "Winter", new Guid("339eca22-fd76-45c9-8595-555c3d3838b1") },
                    { new Guid("aa9b8547-9a41-4ceb-bb54-69cb369f1b39"), "Spring", new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25") },
                    { new Guid("b08cd04e-b858-4af3-b2dc-4576dac91687"), "Spring", new Guid("ea502478-c3eb-4054-841a-98867578a8b5") },
                    { new Guid("b56ef475-f0d8-42e5-ad00-3a3c83e7e61b"), "Summer", new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e") },
                    { new Guid("b8818d68-eb19-4e85-8851-1e90a01d93b2"), "Spring", new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe") },
                    { new Guid("bb8f4982-7be2-4bc9-9374-5014b44ca375"), "Winter", new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29") },
                    { new Guid("c20ce401-7526-496d-b77f-7d981dd25db5"), "Summer", new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab") },
                    { new Guid("c6ecde3b-c2e2-4f96-9a25-9156e251191b"), "Spring", new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab") },
                    { new Guid("c8fe68d6-b199-4ff2-b939-0dce1b2bf0a0"), "Summer", new Guid("ea502478-c3eb-4054-841a-98867578a8b5") },
                    { new Guid("cb1e4d6f-370f-4e32-9b74-b788b5282b08"), "Winter", new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab") },
                    { new Guid("cb446c0c-4929-4a5b-8578-3c6f9f480a55"), "Summer", new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89") },
                    { new Guid("cc3f8062-df87-4ce2-a42e-3a9211e320ea"), "Summer", new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c") },
                    { new Guid("cd799cf5-7b87-45cf-bf47-c2d7ab134590"), "Fall", new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036") },
                    { new Guid("cdcdc71b-fb9f-4614-8226-7393e724c19f"), "Spring", new Guid("0beafae7-bbce-4745-8005-5ab818afcecf") },
                    { new Guid("dbbede69-0c1b-4585-9a38-c1d0f61bfefc"), "Fall", new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab") },
                    { new Guid("e43eaa06-6167-4298-a41d-4acb34cb902a"), "Summer", new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b") },
                    { new Guid("e4bd5b48-7cb2-4ac2-861b-5fae00b8c7d9"), "Winter", new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7") },
                    { new Guid("eb02582b-138a-488d-8085-5278c9742978"), "Winter", new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c") },
                    { new Guid("ecaa4cdc-23bc-46b7-93a4-24f4cf2c75c7"), "Summer", new Guid("47500b25-003c-4085-8aef-8d35b20f22e8") },
                    { new Guid("ee9c361e-2920-403d-8d8b-77606ccc9317"), "Winter", new Guid("01903349-0db9-455e-9991-9348e3664df1") },
                    { new Guid("fb76e446-c1bf-4f1f-9dcc-b64ab2ca90c7"), "Spring", new Guid("112cdd93-39ec-4260-a710-f05b049e43b0") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("0410a0c0-e055-4063-83c9-73ab2712660b"), "Black", new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac") },
                    { new Guid("0831ece7-785f-4964-bd2a-c2e437f449e7"), "White", new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac") },
                    { new Guid("089e3a73-27bf-4493-a42f-7114e75bfee1"), "Blue", new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73") },
                    { new Guid("0a582958-8df3-46d1-b659-28d38dce7437"), "Black", new Guid("0beafae7-bbce-4745-8005-5ab818afcecf") },
                    { new Guid("10386820-c9a4-4c82-9818-6b992879154a"), "Pink", new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab") },
                    { new Guid("13919948-aead-456f-88ec-fdcfbfd50df9"), "Blue", new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d") },
                    { new Guid("15ce8c6d-972f-40ec-a479-e77253a4be95"), "Black", new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0") },
                    { new Guid("1956f59e-f806-4ed0-9325-1bcb9dcc81c8"), "White", new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0") },
                    { new Guid("1ea43e8e-c458-4d6d-88d9-f4fa30af2555"), "White", new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad") },
                    { new Guid("1fab3a71-849e-4baa-9cca-9a8074174280"), "White", new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7") },
                    { new Guid("23aad3b4-0188-4451-86ac-138449ef7dd6"), "Black", new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7") },
                    { new Guid("2ddc9251-bf94-46cc-b231-5dbdbd211830"), "Black", new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d") },
                    { new Guid("2f66f264-e2f0-4a44-89b8-fa057ec9e3b5"), "White", new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b") },
                    { new Guid("317c4c4f-31b8-4d64-bb0f-3d10c3535601"), "Red", new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac") },
                    { new Guid("340f0413-58c4-4580-8b23-dcf12f83165b"), "Orange", new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac") },
                    { new Guid("35606880-8342-4cb7-81fb-277280eabd05"), "Brown", new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e") },
                    { new Guid("36322b4a-a2c7-404e-9cab-04bf1ee26831"), "White", new Guid("47500b25-003c-4085-8aef-8d35b20f22e8") },
                    { new Guid("36f51755-b0ec-4312-8e91-5fe312ad1c36"), "Green", new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d") },
                    { new Guid("39ba8e34-5ce0-4326-b9a0-9e2c62618d80"), "Blue", new Guid("28022637-653a-4246-829a-90e33ba9655b") },
                    { new Guid("3af12451-39aa-488a-a8eb-a8f2275839cf"), "Pink", new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff") },
                    { new Guid("3ee46b2a-0c70-40ab-b28e-e5f1d022014b"), "Purple", new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036") },
                    { new Guid("4374d974-508f-4a0d-8f8b-2becc84ec6e7"), "White", new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab") },
                    { new Guid("4562e5c1-b28d-4966-b682-14dd032c8dc3"), "Purple", new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0") },
                    { new Guid("4b3da47d-df4e-4055-aafc-0bfce31ce653"), "Red", new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b") },
                    { new Guid("4c068d0b-68a4-4808-b40b-e5cb2525fa70"), "Orange", new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7") },
                    { new Guid("4c281620-6756-49ec-b94e-151b62644e36"), "Blue", new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab") },
                    { new Guid("55b44467-ab7c-4a22-8bb7-58b7a93a1572"), "Green", new Guid("112cdd93-39ec-4260-a710-f05b049e43b0") },
                    { new Guid("58e8a246-b1c3-48ad-b9c8-7299ec5aea33"), "Blue", new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac") },
                    { new Guid("5d4a07d6-b3df-4034-9af6-74ff27c8b028"), "Blue", new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7") },
                    { new Guid("5ec54af8-9c5d-40f4-aef0-18f9f27ff451"), "Red", new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c") },
                    { new Guid("6551c854-daa0-4bee-848b-88674f8d6afb"), "Black", new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e") },
                    { new Guid("6890b626-bde2-478c-bff1-578c77a42622"), "Black", new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89") },
                    { new Guid("6c09c41f-875b-465b-9096-e9494a41b00a"), "Pink", new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe") },
                    { new Guid("702bd200-12b7-4766-aa58-655ccfadcb8b"), "Red", new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab") },
                    { new Guid("75a9a9cb-0b92-4e36-9232-d135506c1dc4"), "Pink", new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25") },
                    { new Guid("7d16c45e-ab56-4b7f-8b1f-adbea5848436"), "Yellow", new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c") },
                    { new Guid("85899598-a5bf-473c-844f-3e9958768120"), "White", new Guid("34e83d10-ff04-48c1-9127-387847c39642") },
                    { new Guid("8880f645-a1ac-445c-85c7-67a7a14e478d"), "Black", new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b") },
                    { new Guid("8ec6169e-4fc8-46d5-bcd9-bd7d1dbc1ffa"), "Black", new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab") },
                    { new Guid("94784473-325f-415c-a63d-13d66ed3d658"), "Black", new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b") },
                    { new Guid("9632f4b6-c272-4bf3-bf86-642223258aa5"), "Brown", new Guid("34e83d10-ff04-48c1-9127-387847c39642") },
                    { new Guid("97e60dd1-42ef-4e21-b6e7-7d8ed5d6f017"), "Black", new Guid("e0a49743-f199-4e69-bea6-971f379c02b0") },
                    { new Guid("9df61719-ca2b-495e-8ecc-f3e78eb4f3f5"), "White", new Guid("28022637-653a-4246-829a-90e33ba9655b") },
                    { new Guid("9e5d2b3d-9719-41b0-8565-e35759ede523"), "Blue", new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff") },
                    { new Guid("a020f5f6-29bb-44b3-b640-33d2507f9ebb"), "Yellow", new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab") },
                    { new Guid("a5d925d6-6edb-4ea0-b7b9-5d8932245a39"), "Blue", new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29") },
                    { new Guid("aa891639-9d9d-44ec-af79-4c7fa309dc9b"), "White", new Guid("678cce81-7921-4888-9643-21ba861b47d2") },
                    { new Guid("ac21ef43-594a-4a4f-ae92-b87260b827b9"), "Black", new Guid("678cce81-7921-4888-9643-21ba861b47d2") },
                    { new Guid("acf6d5be-fb61-45bb-a726-1150247fd2f7"), "Black", new Guid("47500b25-003c-4085-8aef-8d35b20f22e8") },
                    { new Guid("ad53ca17-e28d-482f-b3cb-193128a9ff06"), "White", new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe") },
                    { new Guid("b0bcf122-81f0-4f22-8c92-b96abaa7f76d"), "Orange", new Guid("e0a49743-f199-4e69-bea6-971f379c02b0") },
                    { new Guid("b7e28888-34ca-419f-93d7-e1e17fdab735"), "Pink", new Guid("47500b25-003c-4085-8aef-8d35b20f22e8") },
                    { new Guid("b88d27c2-b087-4571-9a46-650500fa6518"), "White", new Guid("ea502478-c3eb-4054-841a-98867578a8b5") },
                    { new Guid("b9da6dd9-da1e-488d-843f-60363b081b92"), "Black", new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe") },
                    { new Guid("bda28dfe-51c0-4283-b883-ae498d59120a"), "Black", new Guid("28022637-653a-4246-829a-90e33ba9655b") },
                    { new Guid("be335faf-4262-4f68-896c-038bbdf25f24"), "White", new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab") },
                    { new Guid("c3dca073-6b13-47c8-96e9-d2d13200ee34"), "Brown", new Guid("112cdd93-39ec-4260-a710-f05b049e43b0") },
                    { new Guid("cc2a965b-921e-4f4b-8d22-61594a5fb655"), "Grey", new Guid("28022637-653a-4246-829a-90e33ba9655b") },
                    { new Guid("d05e3832-c291-4b41-82a3-6379c0ec96ec"), "Red", new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b") },
                    { new Guid("d4c8d668-91dc-41dc-9a21-dc5db3a37764"), "Blue", new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b") },
                    { new Guid("d77ad0e6-0c2b-43da-85a1-9f9b69960ab1"), "Black", new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad") },
                    { new Guid("da272fdd-b839-4c15-bff3-8095d38e1136"), "Pink", new Guid("ea502478-c3eb-4054-841a-98867578a8b5") },
                    { new Guid("da9df9aa-c8e6-4fff-9563-32dc0329b40a"), "White", new Guid("339eca22-fd76-45c9-8595-555c3d3838b1") },
                    { new Guid("dad55ceb-2f18-49af-baa4-5045310681ed"), "Purple", new Guid("ea502478-c3eb-4054-841a-98867578a8b5") },
                    { new Guid("dd431535-60fd-4ea8-a6cc-b6d5f1f1c607"), "White", new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e") },
                    { new Guid("de83e540-39fa-4a39-9584-5d6a41e052a2"), "Black", new Guid("ea502478-c3eb-4054-841a-98867578a8b5") },
                    { new Guid("e4678e9f-ac04-4431-b815-38048afb8d18"), "Blue", new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab") },
                    { new Guid("e7702636-52e8-4138-b253-f12d2fb0301a"), "Black", new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab") },
                    { new Guid("e890555b-8193-4934-b062-6095363f2066"), "Blue", new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe") },
                    { new Guid("e89940e7-9f0f-43e2-b643-51e1a19ebd9a"), "Blue", new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0") },
                    { new Guid("ed0e2652-f77d-4d7b-a886-8c183c1cb083"), "Orange", new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036") },
                    { new Guid("ef55f9a3-3e3f-467e-a297-ca41c7f5e697"), "Black", new Guid("01903349-0db9-455e-9991-9348e3664df1") },
                    { new Guid("f29ab7b6-a3a3-4737-bb01-375537133b56"), "Red", new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe") },
                    { new Guid("f890f0b4-ca05-4fd0-a4c9-612c372a5af6"), "Blue", new Guid("47500b25-003c-4085-8aef-8d35b20f22e8") },
                    { new Guid("fab28650-c586-47c8-81ec-524555cd31f8"), "Green", new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("01ad85a1-7f69-4e4a-b6e8-cf09f2aa0985"), 91, new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7"), 41 },
                    { new Guid("0584c2c0-a66c-46f1-9207-8d8772dd8149"), 17, new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d"), 45 },
                    { new Guid("07c69157-ec30-49e0-aa83-21cc8765c4c8"), 116, new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b"), 45 },
                    { new Guid("07f9c686-c84d-44eb-a9ae-c10a9f95b1b4"), 37, new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c"), 40 },
                    { new Guid("0a19b519-4d04-4337-b82a-bcf9803f071e"), 99, new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7"), 43 },
                    { new Guid("0a4cab1b-6e3a-479e-bff5-5b7b009cc87f"), 28, new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036"), 38 },
                    { new Guid("10d0563d-3ac3-4fa8-bc24-484546599ca1"), 26, new Guid("112cdd93-39ec-4260-a710-f05b049e43b0"), 47 },
                    { new Guid("11474668-0ce8-4312-b17e-f2aa684be022"), 125, new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad"), 41 },
                    { new Guid("14533a4d-3091-4c83-a4bb-f6465ed7a9e4"), 109, new Guid("e0a49743-f199-4e69-bea6-971f379c02b0"), 42 },
                    { new Guid("15e2feb3-f7ef-4e4a-9d9b-1cf8bf0ffa9f"), 49, new Guid("ea502478-c3eb-4054-841a-98867578a8b5"), 39 },
                    { new Guid("18eeb417-2baa-4809-868a-a523b9feb52a"), 30, new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25"), 46 },
                    { new Guid("1bb55c29-e63b-485c-aa2d-5093865e7f7d"), 98, new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b"), 42 },
                    { new Guid("1d1d8a56-1555-4356-8f63-970e985c51ca"), 15, new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff"), 47 },
                    { new Guid("1d4e25db-2870-4b35-a1d3-660d65bdd716"), 34, new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0"), 40 },
                    { new Guid("1d62444f-6757-43df-a5d8-65b740951ad2"), 3, new Guid("ea502478-c3eb-4054-841a-98867578a8b5"), 37 },
                    { new Guid("1f5a6bc7-e017-4cb9-b82a-12e9cc528c5a"), 87, new Guid("678cce81-7921-4888-9643-21ba861b47d2"), 43 },
                    { new Guid("22de6acd-9930-4d05-b89e-154433dcc97d"), 114, new Guid("ea502478-c3eb-4054-841a-98867578a8b5"), 38 },
                    { new Guid("2482850e-2209-4675-bb38-bc87aa155d1b"), 148, new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036"), 40 },
                    { new Guid("25d1dd78-85dd-4d27-9f74-5127de1f060e"), 27, new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac"), 38 },
                    { new Guid("28cfdb48-767b-44f4-8e12-66f90ad3cee2"), 67, new Guid("47500b25-003c-4085-8aef-8d35b20f22e8"), 44 },
                    { new Guid("3672cb82-a1a0-48b1-8746-df82cca4a43a"), 145, new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c"), 39 },
                    { new Guid("3696a1a1-d2e1-4bb9-9be7-bfa4c6510f42"), 66, new Guid("112cdd93-39ec-4260-a710-f05b049e43b0"), 45 },
                    { new Guid("36d078cc-312d-4f1b-bee5-9d7fd492648b"), 71, new Guid("339eca22-fd76-45c9-8595-555c3d3838b1"), 39 },
                    { new Guid("36dfc7db-cee7-4255-93c5-ed8edacab5d5"), 25, new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7"), 38 },
                    { new Guid("38447e64-6b3e-4638-a62d-9ba4c139d533"), 68, new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7"), 39 },
                    { new Guid("3b74fe84-3d77-49f4-90fb-3fc87f856841"), 11, new Guid("28022637-653a-4246-829a-90e33ba9655b"), 44 },
                    { new Guid("3c1dfa90-1a6c-4612-8b95-bc0ab0c3c127"), 95, new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e"), 44 },
                    { new Guid("3c1e7b99-0e9c-40b2-8ef5-5acb4573dc7a"), 80, new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7"), 42 },
                    { new Guid("42dc4156-3965-4faf-a7bd-d27c60ffc3da"), 139, new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29"), 38 },
                    { new Guid("43f84042-f73d-4ea2-83e3-446646046287"), 94, new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0"), 37 },
                    { new Guid("461174e7-5f37-4674-82de-0262335f28fa"), 81, new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b"), 46 },
                    { new Guid("4a12a12c-224c-4aa1-bb89-468bc89dc0cc"), 102, new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29"), 40 },
                    { new Guid("4a7c4cb4-4954-4b26-bc26-2490c42f89a2"), 86, new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff"), 46 },
                    { new Guid("4cfd7e6b-d7cf-4612-9ee7-0ba7f1e6ebb3"), 1, new Guid("339eca22-fd76-45c9-8595-555c3d3838b1"), 41 },
                    { new Guid("4e31e568-dcbc-4cbf-a289-06a3c59da58d"), 71, new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab"), 36 },
                    { new Guid("4fdc48e3-4dfd-4922-85f7-51f4302a9aad"), 114, new Guid("678cce81-7921-4888-9643-21ba861b47d2"), 41 },
                    { new Guid("50a20641-314d-4627-ac1f-a4cae9cbf715"), 70, new Guid("47500b25-003c-4085-8aef-8d35b20f22e8"), 46 },
                    { new Guid("50c40df0-ad75-486c-b4b5-edb9b6750536"), 133, new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89"), 42 },
                    { new Guid("50e2dada-25c5-483d-8bb2-88f6be18bb89"), 8, new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b"), 44 },
                    { new Guid("52ea7dc2-124a-42cf-b761-ead1f8a2771e"), 29, new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe"), 47 },
                    { new Guid("54f7a14c-4d23-4bf6-9af1-04b6fd9e7445"), 117, new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7"), 36 },
                    { new Guid("55618a8f-bfee-431e-8b0c-ecee5c27a4ad"), 112, new Guid("e0a49743-f199-4e69-bea6-971f379c02b0"), 41 },
                    { new Guid("55ed3d13-51db-4f25-baec-aaf434c93b24"), 53, new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b"), 45 },
                    { new Guid("56d5b71d-1de2-405b-a33a-cb4863538d31"), 95, new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d"), 46 },
                    { new Guid("58d35b17-5ad0-4f44-bffb-99f283aab889"), 23, new Guid("47500b25-003c-4085-8aef-8d35b20f22e8"), 45 },
                    { new Guid("5901561f-cf5f-4eb9-a357-eccac731c69f"), 129, new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25"), 43 },
                    { new Guid("5a9949a8-fa07-46f7-92a8-99bdda2a0758"), 17, new Guid("ea502478-c3eb-4054-841a-98867578a8b5"), 41 },
                    { new Guid("617682be-ed45-4b76-b0c9-547710316473"), 8, new Guid("678cce81-7921-4888-9643-21ba861b47d2"), 42 },
                    { new Guid("61a9527a-9926-446e-82f5-21415a315d6f"), 32, new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73"), 36 },
                    { new Guid("6375ebd9-6054-4787-8c50-2d3ef73105a6"), 141, new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25"), 44 },
                    { new Guid("65e5d8ed-f2ba-495f-b875-70925192dd78"), 118, new Guid("34e83d10-ff04-48c1-9127-387847c39642"), 43 },
                    { new Guid("67de1cba-b9d6-4a07-a571-9a0c29c8b66f"), 76, new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7"), 37 },
                    { new Guid("6a098b56-04fb-4efa-b6a0-1dab5cb30c71"), 102, new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac"), 39 },
                    { new Guid("6b10a81f-28a7-4468-8b2e-083584d46a53"), 126, new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e"), 41 },
                    { new Guid("6ea1b277-8dd0-48b2-bb7a-464a8a4ebf18"), 111, new Guid("ea502478-c3eb-4054-841a-98867578a8b5"), 40 },
                    { new Guid("6fdf1696-8708-4eed-94ba-fc67676f519f"), 28, new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c"), 41 },
                    { new Guid("72f57cee-e2da-4451-ba65-06311e11fd77"), 126, new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab"), 40 },
                    { new Guid("73baafde-483d-4063-9b82-c281c76da16e"), 58, new Guid("01903349-0db9-455e-9991-9348e3664df1"), 43 },
                    { new Guid("74712ba9-11d7-4584-8231-bbd6b1fe8e1d"), 120, new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29"), 39 },
                    { new Guid("75dcca99-ac66-49e4-8a6c-3b0698602224"), 26, new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29"), 41 },
                    { new Guid("765f4c93-59a2-448b-9f2c-7f3829cf2dc5"), 130, new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0"), 39 },
                    { new Guid("79b53389-99ef-4e34-b28a-d8737513b56f"), 39, new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe"), 46 },
                    { new Guid("7dc0a8cc-e40b-40b2-a952-73a9b48bbe1a"), 71, new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0"), 41 },
                    { new Guid("8032cd19-c3ea-4199-80e8-c90dcaf302d5"), 102, new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036"), 39 },
                    { new Guid("813642b2-a71e-49c6-9a9f-ac07add1c056"), 60, new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e"), 45 },
                    { new Guid("85ff73a7-6fea-40b8-9d55-316a38895300"), 116, new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab"), 43 },
                    { new Guid("8670ea1e-dc48-4f25-80b6-9c5971f9576e"), 46, new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac"), 41 },
                    { new Guid("8ad46e76-1de3-40fc-abda-200eaf40e892"), 119, new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89"), 41 },
                    { new Guid("8ec937f1-0a89-48b4-818f-5b2944d32eac"), 130, new Guid("678cce81-7921-4888-9643-21ba861b47d2"), 40 },
                    { new Guid("9c571c56-1657-45d0-a7f0-a5c97a4f41ac"), 38, new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e"), 42 },
                    { new Guid("9d0d9fa9-0480-4cc3-929c-c0b90f0214a4"), 75, new Guid("2268be6b-3e9a-4ce6-82af-6770b702299e"), 43 },
                    { new Guid("a19c0e4c-123c-4644-8472-ad76a6fd9361"), 14, new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff"), 45 },
                    { new Guid("a1a68c2b-cb03-47d3-b62d-ffbd51c0ca0d"), 27, new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73"), 38 },
                    { new Guid("a3d9f594-4b1d-424e-9715-eb186f4482d5"), 88, new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73"), 40 },
                    { new Guid("a6e70b7c-e70e-4ff0-aa81-be220c9291d5"), 128, new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b"), 44 },
                    { new Guid("a7d342ff-48c4-47d9-a7da-5b18715127ee"), 54, new Guid("34e83d10-ff04-48c1-9127-387847c39642"), 44 },
                    { new Guid("ac6ca68e-b3db-4240-89b7-becdf8fc0ef1"), 69, new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab"), 46 },
                    { new Guid("af3d0a34-4820-4f4c-9f48-2d942b2adf6f"), 129, new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d"), 44 },
                    { new Guid("b15765b9-bbc5-4dc7-ad16-9b6e5d0dfeeb"), 92, new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25"), 47 },
                    { new Guid("b1d83982-02d1-4b7c-8553-61d9d418dc49"), 104, new Guid("0beafae7-bbce-4745-8005-5ab818afcecf"), 41 },
                    { new Guid("b311fd33-5ff9-4f5f-bf9d-684e25334239"), 80, new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad"), 42 },
                    { new Guid("b3792e0e-90ad-4872-bb21-03b3d62a5c6e"), 4, new Guid("0beafae7-bbce-4745-8005-5ab818afcecf"), 42 },
                    { new Guid("b443b4c8-e87a-4c54-9ab5-2787394a7fc7"), 95, new Guid("112cdd93-39ec-4260-a710-f05b049e43b0"), 44 },
                    { new Guid("b4a13e95-2990-4f5a-89c3-bbb946061647"), 3, new Guid("2c18d21b-ea58-4128-8fbc-b05e309ff7ac"), 40 },
                    { new Guid("b5e720ee-6059-4739-9ec9-fdcd53b0ed70"), 53, new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab"), 44 },
                    { new Guid("b5fb8e2c-09f2-4812-b97b-c99dcfc6d711"), 42, new Guid("73a6fe80-2f4f-4f77-b669-2a4e194b611c"), 42 },
                    { new Guid("ba4035e8-4a4e-473b-9882-ba36f5d6eb90"), 9, new Guid("01903349-0db9-455e-9991-9348e3664df1"), 41 },
                    { new Guid("bb696571-099d-4248-9de5-71e0e8f3b7a7"), 86, new Guid("a3c959bf-5c50-4d4f-ab07-df700983f19d"), 47 },
                    { new Guid("bd84a2d5-5c63-41b8-9c25-14b20136da1f"), 19, new Guid("47500b25-003c-4085-8aef-8d35b20f22e8"), 48 },
                    { new Guid("bd8eb305-6e25-4b7c-9968-ef5006dc256a"), 84, new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b"), 48 },
                    { new Guid("be3c1884-031f-448b-a6cb-af3063b26029"), 92, new Guid("8b29b49a-d1c2-4056-b9a6-d6dbbd89bd25"), 45 },
                    { new Guid("be5d5ef9-6505-4ce6-888f-2c17b759b9b3"), 72, new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b"), 41 },
                    { new Guid("be8a57df-7e44-4aaa-84fb-d30ba07f3b09"), 121, new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73"), 37 },
                    { new Guid("c00be706-55c0-41ce-b7b7-19a09e464717"), 77, new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad"), 40 },
                    { new Guid("c0558f98-117b-42c7-8c6d-a1182e044fd3"), 121, new Guid("e56b4366-b51e-4449-ad1c-70a853b69fad"), 43 },
                    { new Guid("c19cc104-a813-44fc-884c-d5a63de5994c"), 17, new Guid("339eca22-fd76-45c9-8595-555c3d3838b1"), 40 },
                    { new Guid("c409179e-340e-41b2-94ce-7a19b216aacf"), 107, new Guid("0beafae7-bbce-4745-8005-5ab818afcecf"), 45 },
                    { new Guid("c7349eef-cf36-411d-bfcc-3ad7ea2420cc"), 148, new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe"), 43 },
                    { new Guid("c7f0defe-467d-4f31-9372-cf7b2c2db420"), 33, new Guid("0beafae7-bbce-4745-8005-5ab818afcecf"), 44 },
                    { new Guid("c952b925-47b3-4520-a728-441a739cc40a"), 87, new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe"), 44 },
                    { new Guid("cb1cd3e2-8140-4c22-934b-76d042734fb1"), 76, new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab"), 39 },
                    { new Guid("cd0be6c0-a133-459f-9d0e-c1e2ddfeace1"), 20, new Guid("d17a41eb-21c2-4f79-8d64-49fe91bcbd9b"), 47 },
                    { new Guid("ce4da5e4-4fd0-426b-9d01-3125f339eaf7"), 87, new Guid("0beafae7-bbce-4745-8005-5ab818afcecf"), 43 },
                    { new Guid("cfbf263f-0fe5-42e7-a564-2aaa4ce81cff"), 121, new Guid("28022637-653a-4246-829a-90e33ba9655b"), 46 },
                    { new Guid("cfd8723c-4b2b-444b-a09c-ec7dee1dd224"), 64, new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7"), 40 },
                    { new Guid("d0d7196c-db79-449e-bc2a-2f99fa161551"), 134, new Guid("59a3e7e3-dfcc-49d1-952a-2e34a48213a0"), 38 },
                    { new Guid("d2686293-2c3c-4b91-ab79-412a4daa3a4c"), 2, new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036"), 37 },
                    { new Guid("d36ad6fe-7b21-4ba1-aa98-4f2fd27153fb"), 10, new Guid("e0a49743-f199-4e69-bea6-971f379c02b0"), 43 },
                    { new Guid("d4c2d969-5405-4e9b-97af-082687381f5a"), 45, new Guid("339eca22-fd76-45c9-8595-555c3d3838b1"), 37 },
                    { new Guid("d5471053-9d49-4731-845f-f10b4d2be6e0"), 124, new Guid("01903349-0db9-455e-9991-9348e3664df1"), 45 },
                    { new Guid("d9823a02-4fec-4bd6-8d0b-5f8ba956b36f"), 84, new Guid("01903349-0db9-455e-9991-9348e3664df1"), 42 },
                    { new Guid("d987aeee-44bc-4eb5-a041-a302c26903f7"), 87, new Guid("d7476de6-baa9-43ba-b93c-4b26c743c3ab"), 45 },
                    { new Guid("d9a37d5d-9a16-44c9-8e01-697f5f39c1b5"), 1, new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89"), 39 },
                    { new Guid("dc1e0ea5-e465-4c1c-9316-d45b8fa10c8f"), 22, new Guid("fb346c62-0004-48a3-8c85-3e8dc2a1438b"), 43 },
                    { new Guid("e0816399-8a48-4bfd-a192-c177a8bc6963"), 143, new Guid("0c8c9a2e-aaae-4d44-8365-7fa770dabee7"), 39 },
                    { new Guid("e248cae4-531d-4e6f-9446-fe78ca5e16f1"), 30, new Guid("ec89835a-189f-4a3a-b3dc-27cc3aa3aa29"), 37 },
                    { new Guid("e2ebecda-06a0-4947-bd6b-eebefc641c1c"), 80, new Guid("e0a49743-f199-4e69-bea6-971f379c02b0"), 40 },
                    { new Guid("e4304649-8c1f-4971-ae5d-fe0047ed97d4"), 139, new Guid("34e83d10-ff04-48c1-9127-387847c39642"), 45 },
                    { new Guid("e5086803-fb04-4864-80b8-fb7b51ea939c"), 92, new Guid("2fab6a10-104e-4720-94c3-6b9a2ab13fe7"), 40 },
                    { new Guid("e6d49956-5bbe-4eac-9397-1cd46f485f8c"), 15, new Guid("e0a49743-f199-4e69-bea6-971f379c02b0"), 39 },
                    { new Guid("e7024424-cbb9-40fb-a3cd-a1fe9ddca881"), 31, new Guid("dcdff775-6c50-4d28-8ba5-dbcf1e4bafff"), 44 },
                    { new Guid("e8b96a43-aa78-4239-aacd-24aba289c2f4"), 0, new Guid("678cce81-7921-4888-9643-21ba861b47d2"), 44 },
                    { new Guid("ed3b121f-d26e-44b0-953c-aff991762681"), 2, new Guid("c50d9592-2533-47cd-b7ea-9109e76d9036"), 41 },
                    { new Guid("ee67bed0-711b-446d-9689-bd61265accd0"), 79, new Guid("01903349-0db9-455e-9991-9348e3664df1"), 44 },
                    { new Guid("f1776009-c104-4d27-8a4a-81a69a6070f5"), 112, new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab"), 37 },
                    { new Guid("f4969647-2a89-4fc7-9fa4-b845fc51b99e"), 55, new Guid("28022637-653a-4246-829a-90e33ba9655b"), 45 },
                    { new Guid("f4b1e154-f629-45f2-9a65-9358eade5586"), 26, new Guid("339eca22-fd76-45c9-8595-555c3d3838b1"), 38 },
                    { new Guid("f4bf8735-88db-409b-b93b-58fea97e447f"), 30, new Guid("47500b25-003c-4085-8aef-8d35b20f22e8"), 47 },
                    { new Guid("f6c0b76f-16e7-4df5-9dbb-7da65292dd98"), 72, new Guid("32ccd7ee-bf32-4340-8ae9-75a51fae97ab"), 38 },
                    { new Guid("f7c79b79-015b-4e1c-ae73-81cc0cfbd47b"), 54, new Guid("910e909b-8a8b-4a7b-a9c6-6a4835214f89"), 40 },
                    { new Guid("f7ee1456-20f9-4d77-a7b8-67ff55cbc88f"), 67, new Guid("28022637-653a-4246-829a-90e33ba9655b"), 47 },
                    { new Guid("f8bfbed5-796d-4904-8367-9fd3cea483ac"), 116, new Guid("34e83d10-ff04-48c1-9127-387847c39642"), 42 },
                    { new Guid("fb4bbe01-d39a-4218-9edb-87c3501bf2cb"), 142, new Guid("9d9e93e6-4c0d-4356-8a2d-7f5265de5dbe"), 45 },
                    { new Guid("fe56d030-a2be-473d-9881-9727ce0c0579"), 18, new Guid("17383ac2-b4d9-4bf1-89dc-4dbb597eca73"), 39 },
                    { new Guid("feaafda4-4821-4418-a565-b126fa2f5dc5"), 108, new Guid("112cdd93-39ec-4260-a710-f05b049e43b0"), 46 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ShoeId",
                table: "Carts",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_CommentId",
                table: "CommentLikes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserId",
                table: "CommentLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OrderItemId",
                table: "Comments",
                column: "OrderItemId");

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
                name: "IX_OrderItems_ShoeId",
                table: "OrderItems",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountId",
                table: "Orders",
                column: "DiscountId");

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
                name: "IX_WishlistItems_UserId",
                table: "WishlistItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProductViews");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "ShoeImages");

            migrationBuilder.DropTable(
                name: "ShoesColor");

            migrationBuilder.DropTable(
                name: "ShoesDetail");

            migrationBuilder.DropTable(
                name: "ShoeSeasons");

            migrationBuilder.DropTable(
                name: "SiteViews");

            migrationBuilder.DropTable(
                name: "WishlistItems");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
