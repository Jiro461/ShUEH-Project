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
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { new Guid("00e5d435-4344-4250-85c8-95afb1882347"), 4.8m, "Nike", "Football", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1832), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/[IDGiay_3]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1832), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10, 0 },
                    { new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1966), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/[IDGiay_16]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1967), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25, 0 },
                    { new Guid("0e98afcc-5728-4446-853a-342035b5bd9e"), 4.1m, "Puma", "Yoga", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1958), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/[IDGiay_14]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1959), "Leather, fabric, foam, and rubber.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22, 0 },
                    { new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1962), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/[IDGiay_15]_AnhChinh.png", true, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1963), "Leather, fabric, foam, and rubber.", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87, 0 },
                    { new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c"), 4.2m, "Nike", "Tennis", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1837), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/[IDGiay_4]_AnhChinh.png", true, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1837), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5, 0 },
                    { new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e"), 4.0m, "Puma", "Basketball", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1946), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/[IDGiay_11]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1946), "Leather, fabric, foam, and rubber.", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21, 0 },
                    { new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79"), 4.4m, "Adidas", "Football", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1851), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/[IDGiay_7]_AnhChinh.png", true, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1851), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37, 0 },
                    { new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 9, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2061), "Nike's first lifestyle Air Max brings you style, comfort and big attitude in the Nike Air Max 270. The design draws inspiration from Air Max icons, showcasing Nike's greatest innovation with its large window and fresh array of colors.", 40m, 1, "images/shoes/[IDGiay_Home_2]_AnhChinh_1.png", true, new DateTime(2024, 10, 9, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2061), "Plastics, yarns and textiles.", "Nike Air Max 270", 4059000m, 8, 3, 0 },
                    { new Guid("39c49022-ee64-43ba-b14b-a557c4b86396"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1972), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/[IDGiay_17]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1973), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20, 0 },
                    { new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318"), 4.4m, "Converse", "Basketball", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2033), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/[IDGiay_23]_AnhChinh.png", true, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2034), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34, 0 },
                    { new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1940), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/[IDGiay_10]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1941), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3, 0 },
                    { new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc"), 4.7m, "Nike", "Basketball", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1825), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/[IDGiay_2]_AnhChinh.png", true, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1826), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45, 0 },
                    { new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1954), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/[IDGiay_13]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1955), "Leather, fabric, foam, and rubber.", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23, 0 },
                    { new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830"), 4.7m, "Converse", "Yoga", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2042), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/[IDGiay_25]_AnhChinh.png", true, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2043), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30, 0 },
                    { new Guid("77ece808-5744-459a-af69-c2b2ae864415"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2038), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/[IDGiay_24]_AnhChinh.png", true, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2038), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100, 0 },
                    { new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a"), 4.2m, "Puma", "Football", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1950), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/[IDGiay_12]_AnhChinh.png", true, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1951), "Leather, fabric, foam, and rubber.", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17, 0 },
                    { new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1977), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/[IDGiay_18]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1977), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12, 0 },
                    { new Guid("9397c206-1d9e-4921-a76d-4d180962a705"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1847), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/[IDGiay_6]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1847), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381, 0 },
                    { new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1989), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/[IDGiay_21]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1989), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10, 0 },
                    { new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 9, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2050), "Nike Youth React Presto Extreme combines lightweight React technology and a flexible upper to provide comfort and support for everyday activities and gym training.", 40m, 2, "images/shoes/[IDGiay_Home_1]_AnhChinh_1.png", true, new DateTime(2024, 10, 9, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2056), "Rubber, yarns and textiles.", "Nike Youth React Presto Extreme", 2069000m, 78, 60, 0 },
                    { new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 9, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2065), "Whether you're starting your running journey or an expert eager to switch up your pace, the Downshifter 13 is down for the ride. With a revamped upper, cushioning and durability, it helps you find that extra gear or take that first stride towards chasing down your goals.", 40m, 1, "images/shoes/[IDGiay_Home_3]_AnhChinh_1.png", true, new DateTime(2024, 10, 9, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2065), "Plastics, yarns and textiles.", "Nike Downshifter 13", 2069000m, 78, 20, 0 },
                    { new Guid("c35452d1-3695-448f-ad3b-d364db21fcec"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1993), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/[IDGiay_22]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1993), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45, 0 },
                    { new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc"), 4.9m, "Nike", "Yoga", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1841), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/[IDGiay_5]_AnhChinh.png", true, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1842), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66, 0 },
                    { new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c"), 7m, "Nike", "Basketball", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2046), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/[IDGiay_26]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(2047), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5, 0 },
                    { new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1928), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/[IDGiay_8]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1929), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84, 0 },
                    { new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1981), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/[IDGiay_19]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1981), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111, 0 },
                    { new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1933), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/[IDGiay_9]_AnhChinh.png", true, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1933), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268, 0 },
                    { new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1985), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/[IDGiay_20]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1985), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10, 0 },
                    { new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1806), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/[IDGiay_1]_AnhChinh.png", false, new DateTime(2024, 11, 8, 20, 16, 50, 575, DateTimeKind.Local).AddTicks(1821), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20, 0 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("00f69489-f4ea-4243-9825-c3b0430f9bd0"), new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("027410c5-01cf-47a2-a331-e0e65b83df02"), new Guid("c35452d1-3695-448f-ad3b-d364db21fcec"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("0425f8d2-15d1-4890-a9b7-a6860c63a00b"), new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96"), "images/shoes/[IDGiay_Home_1]_AnhPhu_4.jpg" },
                    { new Guid("04aec58f-4153-4afb-9d43-d034895871d0"), new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("081a99b8-6d21-4f24-b7b3-ad67fe06226e"), new Guid("9397c206-1d9e-4921-a76d-4d180962a705"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("08b2297b-4e3b-4a40-9a80-66323bedac78"), new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("1187b964-65fe-4414-b98d-5e37febac80f"), new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("12a550ac-25c5-49e8-ad29-b30fe711267f"), new Guid("c35452d1-3695-448f-ad3b-d364db21fcec"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("12bebaee-1cf1-4fba-b2ca-4ac293ac3e37"), new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552"), "images/shoes/[IDGiay_Home_3]_AnhPhu_2.png" },
                    { new Guid("15fbdd8b-414d-489f-a0af-957a84352d13"), new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("17ddc262-e37e-4ddd-9de8-3831f5271cdd"), new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("195fd534-65e4-472e-a243-fa5a7301411c"), new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("1992c249-395d-41b6-90dc-9bcfac10574f"), new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("1a30cae1-0889-41f6-8544-3fe8f7e50750"), new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818"), "images/shoes/[IDGiay_Home_2]_AnhPhu_1.png" },
                    { new Guid("1d9c8c36-3891-4671-9f68-626a4652c589"), new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("1f53735e-6cc9-4dbf-a5cb-c9c0baff2109"), new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552"), "images/shoes/[IDGiay_Home_3]_AnhPhu_4.png" },
                    { new Guid("20dc067f-ccc7-4e1a-9ba3-479cd3502fb9"), new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("2144599a-d840-4f80-8a3e-4be9c04bf8b4"), new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("224b35f2-91d2-47ab-9465-135b27f2b680"), new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("25d709be-9875-4824-a8ac-a37ca573c849"), new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("26387179-8012-4dea-9f69-dff5a60dd315"), new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("26ad7fb8-878c-47a7-9fc0-8d91b7521fc1"), new Guid("00e5d435-4344-4250-85c8-95afb1882347"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("281f44be-63f9-4db8-b19d-e9321a3d4eff"), new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("29869ae2-cacd-4cb4-ae4a-3b4734c30abd"), new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("2acbe4cb-ebbe-4c10-9a4e-6b84c9ad2ac4"), new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("2fd9de00-f37c-442a-af80-9863e2cd9fcc"), new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("30f82432-b797-4c3a-b25b-1f5d8dd07947"), new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("31da74be-5be6-46c1-86eb-4865927ecbe5"), new Guid("9397c206-1d9e-4921-a76d-4d180962a705"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("38f9caa5-cec7-4643-a27b-2323d39c8fa6"), new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("402b5362-3062-4917-a20b-960557c2a92e"), new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96"), "images/shoes/[IDGiay_Home_1]_AnhPhu_2.jpg" },
                    { new Guid("410a935e-2f5d-4da8-8617-39771d151513"), new Guid("9397c206-1d9e-4921-a76d-4d180962a705"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("4164c26f-8d82-49a8-9ee1-96001062016b"), new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("416f2686-c994-42ef-b875-d87b4c88ca5f"), new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c"), "images/shoes/[IDGiay_26]_AnhPhu_4.jpg" },
                    { new Guid("45358506-17aa-4be5-98ca-3e05a7de9545"), new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("48306ae0-14a5-49a5-ba3f-ffa1236083e0"), new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("4e761d59-61a4-4209-ac69-d725d7201524"), new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("54a43951-6386-41db-ba67-d5b2119ec7dc"), new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("54ab8106-ebd0-4551-81bb-585787a5af0c"), new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("59b68c11-d55a-4fa0-a1e2-d8dd8955c944"), new Guid("77ece808-5744-459a-af69-c2b2ae864415"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("5d78909c-649b-46d2-b696-45dc93dc0e77"), new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("63398097-3d3c-4535-a0f7-8d9fd1735200"), new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("63786af9-073b-4837-8048-825d6ce28dbb"), new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("659c30fe-49d2-4c30-85d1-0d7e8854215a"), new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c"), "images/shoes/[IDGiay_26]_AnhPhu_1.png" },
                    { new Guid("66c3d991-e751-46fb-9c9e-bd2bac7e03f4"), new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("69178e10-be90-4100-ad37-a7ae9b1bf1c3"), new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c"), "images/shoes/[IDGiay_26]_AnhPhu_3.jpg" },
                    { new Guid("6ab3c4d9-83fc-4892-a65c-e42c4081113e"), new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("6d9c4323-6d13-47e4-9458-8ece1cb03604"), new Guid("0e98afcc-5728-4446-853a-342035b5bd9e"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("6e53a6ad-5ad5-4cb1-a516-23f777b43b71"), new Guid("0e98afcc-5728-4446-853a-342035b5bd9e"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("70d44744-2dbb-481f-a803-cf35b3b1b607"), new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("71c133d5-59b2-41ec-815b-e14b64533645"), new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("72f9678a-6cb9-44b1-803d-1ae8bda1282f"), new Guid("9397c206-1d9e-4921-a76d-4d180962a705"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("72fc2380-88c3-43d9-b156-cc45ae8dd113"), new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("7fb5913b-e08b-4870-a6c1-1fd612783758"), new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818"), "images/shoes/[IDGiay_Home_2]_AnhPhu_2.png" },
                    { new Guid("80af7db1-c44a-46bd-9af6-b3760b265a93"), new Guid("0e98afcc-5728-4446-853a-342035b5bd9e"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("842e2a95-e840-4fc6-9e49-6c3f4ece12ed"), new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("892deba7-c751-4027-be9a-b3e0ca89a894"), new Guid("77ece808-5744-459a-af69-c2b2ae864415"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("8a7a50f3-9760-4989-9d5b-d072a52d25d9"), new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("8eb7a744-ca2f-4686-9613-6baff655b86e"), new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("8fc5993d-63e0-419e-80ed-c94a5dc6795a"), new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("912186ac-bfbf-447e-9894-2ff61d1d6f43"), new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("918fc165-9068-46ea-a4e4-8a8ee557de8f"), new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("92f67096-bbfb-4818-afb2-9bee3d1bafbc"), new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("973cd7e1-1136-41da-aa26-9f80dfe620b7"), new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("9a170cba-9e5b-4d90-8d7f-c582f53d9f5a"), new Guid("00e5d435-4344-4250-85c8-95afb1882347"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("9a800ae2-8380-4e60-8b22-64ed0e427016"), new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("9aa04c1f-a595-4944-a1f6-f72a2de5130c"), new Guid("39c49022-ee64-43ba-b14b-a557c4b86396"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("9c6b5d23-56a8-423a-898a-0e07ac928dbd"), new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("9c78eece-c704-4ec8-8fdc-33486d8e0dae"), new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552"), "images/shoes/[IDGiay_Home_3]_AnhPhu_3.png" },
                    { new Guid("9d5a8663-cab1-4ff0-9c56-3d619a25ea9d"), new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("9d79122c-009b-4a89-8e2a-cd2f64191324"), new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("9dc7e7a8-8315-4c31-93b7-d7c7acae83b6"), new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96"), "images/shoes/[IDGiay_Home_1]_AnhPhu_1.jpg" },
                    { new Guid("9f704dd0-41d7-475a-b535-51a9e6a1df83"), new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("a09f5f6e-887e-456b-b596-9544570aa32a"), new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("a0c42fc0-6363-4c07-bb82-8048e6b496bf"), new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96"), "images/shoes/[IDGiay_Home_1]_AnhPhu_3.jpg" },
                    { new Guid("a0e0ce4e-79d9-4291-b3b5-7a9d6dce6588"), new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("a1ea4664-0b2f-4f87-b341-756a4a706264"), new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552"), "images/shoes/[IDGiay_Home_3]_AnhPhu_1.png" },
                    { new Guid("a27a45ca-9c28-4bee-8794-5ff3f88528e4"), new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("a50016d3-8aeb-4c93-8f18-da036e8f0307"), new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("a5db874a-431a-4e60-9524-e224865aa7f6"), new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("a9e6a841-0c1f-4bf3-b188-7cf7b1382686"), new Guid("0e98afcc-5728-4446-853a-342035b5bd9e"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("ad9bea86-5fb3-4860-b127-c68d831d0da0"), new Guid("c35452d1-3695-448f-ad3b-d364db21fcec"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("adf883fa-95d9-4f71-a1be-02519d0abc6b"), new Guid("00e5d435-4344-4250-85c8-95afb1882347"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("b09a1c20-9aae-4b3d-9e1b-e72f2e474000"), new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("b0ff3f41-4c0e-4f70-a85c-ca087cbfadf9"), new Guid("c35452d1-3695-448f-ad3b-d364db21fcec"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("b16f0d2e-75c6-4402-8bf0-a509e3e7b748"), new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818"), "images/shoes/[IDGiay_Home_2]_AnhPhu_3.png" },
                    { new Guid("b1cbad23-1e4e-4897-8173-431636c0f677"), new Guid("00e5d435-4344-4250-85c8-95afb1882347"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("b500a63b-e922-4a98-9e27-4fae16afa9ef"), new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("b8d59cb7-3073-43fc-90ee-43f18ca16a70"), new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("ba08cdbc-68c5-4403-a916-36efa75ab69b"), new Guid("77ece808-5744-459a-af69-c2b2ae864415"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("bc3c331b-fd29-4923-b64b-f86db621c5cd"), new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("bc65c630-b5cf-4586-8302-991ca585425f"), new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("c9d5686d-3daf-4402-b0d1-1e9298508b98"), new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("caf87c5d-6764-4f49-830d-238c1795225b"), new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("cc264bca-6d17-42ba-9ccd-870900a7ac9d"), new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c"), "images/shoes/[IDGiay_26]_AnhPhu_2.png" },
                    { new Guid("cc28001c-22f8-479a-86b1-0fcbd8bf596c"), new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("ceca2933-a15b-42da-8c6a-eb37959a2d72"), new Guid("39c49022-ee64-43ba-b14b-a557c4b86396"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("d08b0eeb-6382-4936-abe7-8327ecd9a507"), new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("d15723ad-4cef-47ce-9455-a4d9b14ba0ec"), new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("d18323f9-f5ca-46ba-b432-04fa7cdc2c2f"), new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("d2ae48ad-b51a-450d-b0f6-23fda2d6fd31"), new Guid("39c49022-ee64-43ba-b14b-a557c4b86396"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("d43cc5fa-bf13-451e-a4c3-bf5e8e513660"), new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("d6b37354-da1b-4182-bcd9-5df393c0fe93"), new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("d79a329a-ac45-497a-883d-2aa60c764aa2"), new Guid("77ece808-5744-459a-af69-c2b2ae864415"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("d9c92139-3f57-4ed2-91f2-165ef8590d2c"), new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("de17d347-6872-426c-93b1-66645ad9f35a"), new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("e020bc1b-09c8-4260-858f-8d8650460bc8"), new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("e456cfe8-2231-4b4b-989f-5cb8e833baa8"), new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("ea3a5d56-bcb7-48ea-9d1c-e5cb2c21e0da"), new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("eb6f9d49-0d6f-4356-a12f-9649270ac3e2"), new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("f0cf8b6e-c6aa-4e92-81ca-d867b4581029"), new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818"), "images/shoes/[IDGiay_Home_2]_AnhPhu_4.png" },
                    { new Guid("f424f17a-bbdf-440a-942d-214a76fbd9f1"), new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("f4467472-92b2-4957-9a08-aab3a0bdf664"), new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("f4c87ed7-0522-45c1-9418-19dbe8ae142f"), new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("f6459893-5bc4-425e-b511-f0bc39f45082"), new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("fe10cb72-aab9-4f88-aa8c-c24554459670"), new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("ff8f1891-54a5-4c0e-be71-1fc75e3dae57"), new Guid("39c49022-ee64-43ba-b14b-a557c4b86396"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("0157d262-f682-40b8-b50a-86f3f8ff56ab"), "Summer", new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f") },
                    { new Guid("05aa31e4-d93c-4c98-82be-ae2ebb09235e"), "Spring", new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a") },
                    { new Guid("0ad1fa8d-01e2-4788-ac32-4348b7bb2d7d"), "Winter", new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a") },
                    { new Guid("0f175413-0c36-4b4c-85ed-0226c2901307"), "Winter", new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495") },
                    { new Guid("10cec5bd-910f-4bb1-913d-4ff95e26bd0b"), "Winter", new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51") },
                    { new Guid("13a29b7a-3b38-4ac3-800c-adc6c9dfda91"), "Spring", new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a") },
                    { new Guid("1627d20f-80b3-42ec-a296-a0a214634edf"), "Spring", new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818") },
                    { new Guid("162a6684-2c8a-4597-8904-728f27489248"), "Winter", new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33") },
                    { new Guid("165b7af1-9e01-4660-9e6d-5bbe05c43b8d"), "Summer", new Guid("9397c206-1d9e-4921-a76d-4d180962a705") },
                    { new Guid("1739c49a-5017-4dc3-986b-029113fb8732"), "Spring", new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96") },
                    { new Guid("1e02cafd-827a-458c-8e65-49ab3de05fa0"), "Summer", new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c") },
                    { new Guid("1e2c4637-6abc-4d9e-8c0b-78d894f73eda"), "Summer", new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3") },
                    { new Guid("2bc329f1-87ea-46a7-a315-8c43a6efc04e"), "Fall", new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79") },
                    { new Guid("38350e7a-7afa-427a-bcb3-d43e11d151de"), "Fall", new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33") },
                    { new Guid("3b2571c2-8bea-4a4d-b042-e19fe2e4872a"), "Summer", new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d") },
                    { new Guid("3be3d623-64be-4576-b966-dfed9dc8ad45"), "Spring", new Guid("00e5d435-4344-4250-85c8-95afb1882347") },
                    { new Guid("3d30bd2c-fd1a-48bc-ae90-252118a0b7c3"), "Winter", new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318") },
                    { new Guid("3da4c67c-6ad2-4d80-9db0-4b77058e7f2a"), "Winter", new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc") },
                    { new Guid("408f8bfe-7cd0-4c30-a5f8-957d950f7ae9"), "Summer", new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e") },
                    { new Guid("46ab4eb9-a324-423c-80a6-1f4b567257a1"), "Summer", new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818") },
                    { new Guid("47d82388-8b06-4a2e-a988-e88597101acd"), "Winter", new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c") },
                    { new Guid("49703db6-e5a8-46d0-9ad8-49c997ef8f0c"), "Summer", new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552") },
                    { new Guid("4a84d17b-8700-4c92-9f7a-030a44e4668d"), "Fall", new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818") },
                    { new Guid("4ce755d8-f26c-4d0b-94a0-42b133ba4dd9"), "Winter", new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552") },
                    { new Guid("5269ce46-6c0e-4f97-8aa4-3405be8f6a00"), "Spring", new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c") },
                    { new Guid("555c37e7-3ec3-4fae-9773-fa19d5eb4826"), "Spring", new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495") },
                    { new Guid("58838faa-0111-4b98-9687-e67f0cca3f69"), "Summer", new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc") },
                    { new Guid("599c2488-152b-4731-b0a8-0e586e68ed42"), "Winter", new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79") },
                    { new Guid("5ed0133e-ef31-4df5-b0c5-4a45a4bef607"), "Fall", new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a") },
                    { new Guid("682e0b18-f295-4209-9444-a04e4052a3b9"), "Winter", new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c") },
                    { new Guid("6872e59b-6f21-4fca-855b-b2c0c94c92cb"), "Summer", new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79") },
                    { new Guid("6aa9bf7c-c9b6-43fb-b753-e212d17536f4"), "Summer", new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c") },
                    { new Guid("6b04c922-4c67-4d62-aad8-38b0dda14f0e"), "Spring", new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c") },
                    { new Guid("79b31db7-fd1b-4945-97f1-843e2cada17b"), "Spring", new Guid("0e98afcc-5728-4446-853a-342035b5bd9e") },
                    { new Guid("7bcfaabc-c777-4b32-aa6f-c8fba12bdafb"), "Fall", new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552") },
                    { new Guid("80983dc2-00b0-497d-9e6e-9decd195cc8b"), "Winter", new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc") },
                    { new Guid("83e3d5fe-ebc9-4dc6-920a-d1154b87e246"), "Fall", new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c") },
                    { new Guid("86ff7b3f-6273-4d78-ac01-377f9043e080"), "Spring", new Guid("77ece808-5744-459a-af69-c2b2ae864415") },
                    { new Guid("88daf7f2-e210-4949-959d-d59b1dc7d864"), "Winter", new Guid("c35452d1-3695-448f-ad3b-d364db21fcec") },
                    { new Guid("89e50e85-3720-4b5c-9ed5-dbff982f1100"), "Spring", new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e") },
                    { new Guid("90b966cd-830a-4a95-9970-61ed1ea937e6"), "Fall", new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e") },
                    { new Guid("9e8b0c85-ad1a-420a-bd1d-812b7c74589b"), "Fall", new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c") },
                    { new Guid("a083461d-b3e3-4d7d-a478-3e22ebc43876"), "Fall", new Guid("77ece808-5744-459a-af69-c2b2ae864415") },
                    { new Guid("a930b950-e9b6-4f8e-a2df-be8b7f7b6a53"), "Fall", new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495") },
                    { new Guid("aae76939-a1d1-4554-9ae0-4ac75b1414f7"), "Summer", new Guid("c35452d1-3695-448f-ad3b-d364db21fcec") },
                    { new Guid("b8c396df-df49-40c2-b3da-4a3c89ecee8a"), "Spring", new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33") },
                    { new Guid("b96933e6-bd71-4293-9471-7d16fb0403e2"), "Winter", new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c") },
                    { new Guid("badadc61-da33-4ce7-a513-84cce04897ef"), "Spring", new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b") },
                    { new Guid("bd343f75-ed4d-46f9-9f52-eca468060f6b"), "Winter", new Guid("39c49022-ee64-43ba-b14b-a557c4b86396") },
                    { new Guid("bd67e3e0-7b79-4981-bf8a-5a1d67a2b3c4"), "Winter", new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc") },
                    { new Guid("c082f4b6-0778-47ae-ad1e-1576e4800259"), "Summer", new Guid("0e98afcc-5728-4446-853a-342035b5bd9e") },
                    { new Guid("c82ecfba-3866-463b-b658-a0443a26da62"), "Spring", new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3") },
                    { new Guid("c9c28397-2c79-47be-8a72-d022ce29a4ce"), "Spring", new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830") },
                    { new Guid("d9e4ba89-fb3c-4d06-a88e-5dd884adb6e1"), "Summer", new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495") },
                    { new Guid("dcd5f6d3-7f2a-4a18-973e-709ec6a6aaa2"), "Spring", new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79") },
                    { new Guid("e1aee4d0-5441-4121-ba9a-f4728c28317f"), "Spring", new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51") },
                    { new Guid("e4a31961-3070-41e7-a615-db4219239501"), "Summer", new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51") },
                    { new Guid("e5383153-ab69-43d8-9e78-dd87ef9601b9"), "Fall", new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc") },
                    { new Guid("e8745758-a5c0-4107-997d-c843bbbdb95e"), "Summer", new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33") },
                    { new Guid("eb468a24-e9fb-4bab-98d1-3b35841f6672"), "Fall", new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc") },
                    { new Guid("eca5d6ba-cef7-4a98-b8fc-bd2fbb07b73d"), "Spring", new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f") },
                    { new Guid("f8bdd24a-5e57-4b79-8146-876be886226f"), "Summer", new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("02bf5132-32a9-4676-a7b2-ae3feb4e96c6"), "Green", new Guid("9397c206-1d9e-4921-a76d-4d180962a705") },
                    { new Guid("08e0d80d-2e23-435b-818a-2c77807214e1"), "White", new Guid("00e5d435-4344-4250-85c8-95afb1882347") },
                    { new Guid("0ec20c8b-e11c-456b-9edc-51d4058d8b46"), "Green", new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830") },
                    { new Guid("0ef5efcb-bcd1-4504-b87c-f0d1fdaaa2ef"), "Orange", new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d") },
                    { new Guid("11105a89-cdb3-4de3-b30a-414f8928127c"), "Pink", new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818") },
                    { new Guid("132441c7-a5a4-4681-b26a-308f16b529ce"), "Blue", new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a") },
                    { new Guid("1343033b-8f1a-4271-bf8e-e9acfb12cc0a"), "Orange", new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc") },
                    { new Guid("13bdeed4-a850-4733-afed-b01df73c8eea"), "White", new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a") },
                    { new Guid("17e9f52c-b7f6-4935-bfe0-3eacb4f5ba10"), "Black", new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc") },
                    { new Guid("1960d44a-1bd6-4e10-b3d1-63fe3ed3bc95"), "Brown", new Guid("77ece808-5744-459a-af69-c2b2ae864415") },
                    { new Guid("21ed89a3-b5ed-46ff-b291-efd9c416b040"), "Black", new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d") },
                    { new Guid("26862ae0-6d00-4265-abda-480937529ce3"), "Brown", new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c") },
                    { new Guid("2947c176-4cd7-4c51-be0e-e6024e554174"), "Black", new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f") },
                    { new Guid("2c784e61-09fd-484d-bfce-a028e3a1b7da"), "Black", new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33") },
                    { new Guid("2f872e2c-ddd9-4915-bb82-82e5207d56ca"), "Brown", new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830") },
                    { new Guid("32a5ceba-545c-4b0f-91fd-73da8eb807df"), "White", new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc") },
                    { new Guid("35a8eabd-0653-47c4-a646-c361b056de77"), "White", new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc") },
                    { new Guid("35fa8480-3aea-4acf-9127-1d0503a2834f"), "Red", new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79") },
                    { new Guid("3905d19f-59f4-4d37-95b7-b7a25960ee26"), "Orange", new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e") },
                    { new Guid("3ee5450e-5d2b-43aa-971a-2898d6682a04"), "Black", new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c") },
                    { new Guid("41411a0d-111b-4c17-9180-f9705e3ca72c"), "Black", new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a") },
                    { new Guid("42b64055-0991-47a9-9ffb-ae6ff2cffc26"), "White", new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818") },
                    { new Guid("4593609f-1d28-4275-b3cc-0559f40df208"), "Blue", new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552") },
                    { new Guid("46030b4f-541d-46c4-bd7e-9800643b2f4d"), "Pink", new Guid("39c49022-ee64-43ba-b14b-a557c4b86396") },
                    { new Guid("4cdf44d7-c5e0-4a93-bb12-2b179353af44"), "White", new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e") },
                    { new Guid("52db70bb-bedb-441f-9786-2906e34ad78d"), "Black", new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a") },
                    { new Guid("5519ad73-ddb1-4368-b62f-7532bf7566ca"), "Black", new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c") },
                    { new Guid("57c810b7-0ab6-4b73-bf18-7bc3c53eda39"), "Orange", new Guid("9397c206-1d9e-4921-a76d-4d180962a705") },
                    { new Guid("57d2a17e-3ac0-40e1-8b33-b7a3d8828c0f"), "Black", new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96") },
                    { new Guid("5ba98720-31f0-42fb-8b40-e088e8ab6268"), "Yellow", new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79") },
                    { new Guid("5f79eacd-2f07-4b30-950d-bb0f0101b412"), "White", new Guid("77ece808-5744-459a-af69-c2b2ae864415") },
                    { new Guid("65cb287c-111e-4bc4-b47b-35335263464b"), "Black", new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552") },
                    { new Guid("6f76c609-c40a-408d-a059-a586aa42fa29"), "Black", new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b") },
                    { new Guid("71a240dc-7c0f-48c0-b2f0-ccf23c8a35bf"), "Pink", new Guid("0e98afcc-5728-4446-853a-342035b5bd9e") },
                    { new Guid("751fc621-5394-4f04-957f-147f31ee35a3"), "Black", new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c") },
                    { new Guid("77bb8863-a49c-431c-bba0-f17d4927b883"), "Black", new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495") },
                    { new Guid("79c4e193-ffdd-4ebf-8ff2-b88c0c730968"), "Pink", new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f") },
                    { new Guid("7b3922cd-25c3-41cb-adb5-48063cd3ecc5"), "Red", new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc") },
                    { new Guid("82a6398f-e43d-4134-a15b-25c404f04e8f"), "Blue", new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318") },
                    { new Guid("86806fe8-157b-416c-9c54-f9d7acc2b1f0"), "Blue", new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc") },
                    { new Guid("9761e945-2df6-4194-918f-888b174dfdd2"), "White", new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33") },
                    { new Guid("98008c58-075d-4d1a-9dff-5c3788188005"), "Yellow", new Guid("00e5d435-4344-4250-85c8-95afb1882347") },
                    { new Guid("9875033d-0600-42b5-a11a-021742ca56f3"), "Blue", new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33") },
                    { new Guid("98e34f14-0309-4154-8335-182699e3d654"), "Black", new Guid("c35452d1-3695-448f-ad3b-d364db21fcec") },
                    { new Guid("a1b3d8d0-eadb-4fde-b160-3dac46abf1c2"), "Black", new Guid("9397c206-1d9e-4921-a76d-4d180962a705") },
                    { new Guid("a250aedd-beb1-4e23-bc15-8d6acebafa75"), "Black", new Guid("00e5d435-4344-4250-85c8-95afb1882347") },
                    { new Guid("a3e4c3a9-28c6-442b-a2c7-555e7cf55d8c"), "Blue", new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818") },
                    { new Guid("a61f798d-f626-4edb-99a7-3e024497ca49"), "Blue", new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a") },
                    { new Guid("aee54b3d-fd0c-44cc-8b3c-bffb3c9815a1"), "Green", new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a") },
                    { new Guid("b01395bf-3ae3-4b09-bae3-0d852b427e92"), "Blue", new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3") },
                    { new Guid("b045b27b-8ef1-4181-9b80-7074a647db31"), "Blue", new Guid("9397c206-1d9e-4921-a76d-4d180962a705") },
                    { new Guid("b16a6832-160e-477e-93da-856408b82079"), "White", new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b") },
                    { new Guid("b8fb211b-31f1-4f6d-9193-04bf0d8c8a3b"), "White", new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f") },
                    { new Guid("bf2134e2-aae0-4fbd-9ab3-1ca5aa18c7a1"), "Red", new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c") },
                    { new Guid("c0138261-36d0-48e7-86ab-ffbcbde5bfae"), "White", new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c") },
                    { new Guid("c5bef3d7-d033-4721-86b9-128043ae03e8"), "Blue", new Guid("39c49022-ee64-43ba-b14b-a557c4b86396") },
                    { new Guid("d0cc0e51-e735-41f0-b148-c66b35554018"), "Black", new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc") },
                    { new Guid("d1e2edb3-a841-447a-87bd-a2e936826b20"), "Grey", new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33") },
                    { new Guid("d1fd2d57-e9e4-4e70-8cfd-807e5eecefeb"), "Pink", new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a") },
                    { new Guid("d4771c25-99c7-461e-b50b-7e1a77dca278"), "Blue", new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e") },
                    { new Guid("d5ec2210-1209-4621-8b0e-45d179f5398a"), "White", new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96") },
                    { new Guid("d85220a5-a2aa-474e-b926-0c457ce728ad"), "Red", new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a") },
                    { new Guid("d9118a3e-1ae8-4ef2-871e-ba6840dc7ae2"), "White", new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552") },
                    { new Guid("db60e350-e210-4328-a7be-cd29342c5736"), "Red", new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552") },
                    { new Guid("dd509928-40df-4e12-9fcd-212a553542b1"), "Purple", new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e") },
                    { new Guid("dfe5cbda-dc1c-434c-9acc-8b2b8430b26c"), "White", new Guid("9397c206-1d9e-4921-a76d-4d180962a705") },
                    { new Guid("e0e7557c-6898-4ad6-b8a9-36fd200e2ce0"), "Red", new Guid("9397c206-1d9e-4921-a76d-4d180962a705") },
                    { new Guid("e19422a1-6a22-4ffb-9c80-dafd2294cf1e"), "Blue", new Guid("00e5d435-4344-4250-85c8-95afb1882347") },
                    { new Guid("e6571d55-83a6-4e60-b7d6-a4ec4ca93081"), "Pink", new Guid("00e5d435-4344-4250-85c8-95afb1882347") },
                    { new Guid("e667a52f-e121-4e10-88c2-27ebd4f2f414"), "White", new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc") },
                    { new Guid("eae7eb03-6b67-4957-933f-c37b551f23c1"), "Purple", new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f") },
                    { new Guid("f20ea84f-f0ae-4a32-b5c4-2bb05a5e4ff3"), "Black", new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818") },
                    { new Guid("f2aacb0f-bb49-419e-a346-85906c4b49e6"), "Blue", new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51") },
                    { new Guid("f2bc051e-cbf9-4a95-aa12-2a6ca0919c51"), "Black", new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e") },
                    { new Guid("f7b72a8e-c944-4ea7-adfe-e539f768825e"), "Purple", new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("01305a06-cdc1-459e-b5b0-5c3caa1713bf"), 16, new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c"), 44 },
                    { new Guid("03177cd0-4c30-410d-aff2-d5a6d630d537"), 126, new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c"), 38 },
                    { new Guid("062f0bd1-7a02-4f66-a737-79b6ae57d0a8"), 67, new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c"), 41 },
                    { new Guid("0709b1fd-4096-49fe-b70d-e5ad998f6e08"), 25, new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a"), 43 },
                    { new Guid("08ab4ff0-961d-4b35-b337-69bbf4e5b121"), 103, new Guid("c35452d1-3695-448f-ad3b-d364db21fcec"), 43 },
                    { new Guid("09d1aad3-69a2-4937-bfad-35a4eed0544e"), 103, new Guid("c35452d1-3695-448f-ad3b-d364db21fcec"), 46 },
                    { new Guid("0eba2d3d-88d4-4dd8-8b4e-d00466cd45f0"), 144, new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818"), 47 },
                    { new Guid("0f15b53d-53c9-49d8-908d-4cd216f4fcfe"), 32, new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a"), 43 },
                    { new Guid("0fcee958-8dca-4ff9-8ff5-f3cd92690a62"), 38, new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33"), 46 },
                    { new Guid("16652d0b-2d2e-41a9-b1cf-c8d05a615611"), 103, new Guid("39c49022-ee64-43ba-b14b-a557c4b86396"), 46 },
                    { new Guid("1f2a7e7c-6f81-4325-a7d7-c7f560201f43"), 46, new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc"), 41 },
                    { new Guid("1fb6cc6a-533b-4583-8ccc-2b82d9ed5b96"), 121, new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a"), 44 },
                    { new Guid("20c959b9-2889-4eb6-ad15-f8abd6919863"), 24, new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495"), 43 },
                    { new Guid("266265ae-dcb1-4e6c-a9f6-ad737238a978"), 127, new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830"), 42 },
                    { new Guid("2957fe62-bc2b-41da-b75e-fcd223b627b1"), 71, new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b"), 44 },
                    { new Guid("2a4fd2d2-a1d7-40ca-8f27-c64be716569e"), 76, new Guid("9397c206-1d9e-4921-a76d-4d180962a705"), 39 },
                    { new Guid("2b9eeeea-388f-4f70-8f37-6d77fcb138a1"), 85, new Guid("0e98afcc-5728-4446-853a-342035b5bd9e"), 42 },
                    { new Guid("2fb918dd-edf6-457e-bb93-9885e00a0b56"), 110, new Guid("9397c206-1d9e-4921-a76d-4d180962a705"), 38 },
                    { new Guid("300514c2-76c2-4545-aefc-86c3ec806eb2"), 145, new Guid("39c49022-ee64-43ba-b14b-a557c4b86396"), 43 },
                    { new Guid("31d31001-dcc1-4e89-87ec-6b3a68c8622a"), 56, new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552"), 43 },
                    { new Guid("31f1fbb2-f12b-433d-bd7c-e7f1a6f39832"), 34, new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc"), 46 },
                    { new Guid("33be0725-c8f9-47ad-bc9b-7f7bdb5ffc90"), 94, new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c"), 41 },
                    { new Guid("3993cdf5-fba0-415e-ab03-9a0379eb557f"), 108, new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96"), 39 },
                    { new Guid("39e68cce-44b7-4085-8465-744daa391708"), 37, new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e"), 41 },
                    { new Guid("3cc72ffc-9374-477d-8956-132c97c7c048"), 18, new Guid("77ece808-5744-459a-af69-c2b2ae864415"), 37 },
                    { new Guid("3f32e145-f71a-42ff-8381-3065b549a8b2"), 60, new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318"), 47 },
                    { new Guid("403cbc23-534a-4657-b945-3c7cd6b6dfb3"), 13, new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318"), 46 },
                    { new Guid("417ae5f9-768d-4d54-bcbc-24976294cc5a"), 9, new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51"), 42 },
                    { new Guid("418f2d2b-06e1-4057-aacc-d643da4543dd"), 25, new Guid("00e5d435-4344-4250-85c8-95afb1882347"), 45 },
                    { new Guid("45c66785-1c16-45ab-967c-6191b00ed4fb"), 131, new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830"), 40 },
                    { new Guid("48c1ba90-4c02-460d-9866-9f2e35ef99ef"), 121, new Guid("0e98afcc-5728-4446-853a-342035b5bd9e"), 40 },
                    { new Guid("4907dde0-bfcf-44f6-9f7f-96af91ac6242"), 16, new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c"), 45 },
                    { new Guid("4c793964-3d01-40fe-928e-479addc60eb0"), 70, new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51"), 40 },
                    { new Guid("4fc110f4-0335-461d-a9ba-0e9648c1ca87"), 132, new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3"), 43 },
                    { new Guid("51dd3b95-39ca-4b16-b5a8-ce424e0302d6"), 133, new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33"), 44 },
                    { new Guid("51e69fc3-3c28-4197-9b04-7cae6a74b174"), 121, new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c"), 46 },
                    { new Guid("5286cea7-26e8-4c29-9748-040a6218a371"), 20, new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3"), 44 },
                    { new Guid("55d5dde9-97df-416b-a11d-586c7229e37b"), 91, new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc"), 45 },
                    { new Guid("56cbaa1e-618b-4a81-ad81-2ca9ce62d5e2"), 16, new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33"), 43 },
                    { new Guid("57873582-5665-4d7b-bca4-36dc0a03a61c"), 63, new Guid("0e98afcc-5728-4446-853a-342035b5bd9e"), 38 },
                    { new Guid("591c704e-7b9d-4e6f-a41b-e485c618d5c5"), 145, new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d"), 45 },
                    { new Guid("5a139558-47fc-4d49-b99a-9c0ca7e0c88d"), 27, new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc"), 42 },
                    { new Guid("5ba96f30-a445-4b83-9ba8-4084d51d4479"), 49, new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552"), 47 },
                    { new Guid("5ee6043d-dcf3-442b-b5cd-880144ccd50d"), 128, new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc"), 40 },
                    { new Guid("5fe6ad2f-619a-4e15-aafa-314e734fe638"), 26, new Guid("39c49022-ee64-43ba-b14b-a557c4b86396"), 44 },
                    { new Guid("5fff85d5-e7b4-4a56-bb25-93c5688091e6"), 139, new Guid("0e98afcc-5728-4446-853a-342035b5bd9e"), 39 },
                    { new Guid("62c649e5-ae0d-41b1-b613-d00117f7ed9b"), 63, new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e"), 44 },
                    { new Guid("657195cb-a1b6-46db-b0b5-af945f3e9c3d"), 119, new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318"), 45 },
                    { new Guid("697e9fc5-5853-4bab-9092-645cf6856eed"), 81, new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51"), 39 },
                    { new Guid("6b8a4424-f4a0-42f4-beb2-110f695f805e"), 104, new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818"), 46 },
                    { new Guid("6f8ee4c4-9597-43b5-9afe-b8e0c3f82118"), 67, new Guid("c35452d1-3695-448f-ad3b-d364db21fcec"), 42 },
                    { new Guid("724faee0-c36f-4a34-a9df-01f9838fed50"), 55, new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d"), 49 },
                    { new Guid("73339790-e723-429c-a78b-572930f64f9d"), 89, new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d"), 48 },
                    { new Guid("75755150-5db7-42a3-bfc7-b1aed605f6b9"), 110, new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96"), 38 },
                    { new Guid("75cc272c-43f8-4d4a-95aa-f9e4d1a53f12"), 65, new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b"), 45 },
                    { new Guid("7701b8fb-b906-4479-980a-838ca1c47423"), 125, new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc"), 41 },
                    { new Guid("7787356c-ef9f-42a9-92bb-ba9d2fe791f9"), 90, new Guid("c35452d1-3695-448f-ad3b-d364db21fcec"), 45 },
                    { new Guid("78041aaf-5618-46c7-bddd-73b1fb955cf6"), 144, new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a"), 45 },
                    { new Guid("7b63da28-13da-4e18-b718-eb98784add76"), 77, new Guid("c35452d1-3695-448f-ad3b-d364db21fcec"), 44 },
                    { new Guid("7e4cf48f-d7d4-45ae-ac59-891dcc1daeb7"), 63, new Guid("77ece808-5744-459a-af69-c2b2ae864415"), 38 },
                    { new Guid("7f23fe24-878f-4f76-9b37-55d5f78a741c"), 8, new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3"), 45 },
                    { new Guid("81b05b3e-62ad-428d-b1fe-1d0ee15d3434"), 99, new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d"), 46 },
                    { new Guid("834ab8c4-86eb-4497-8b8e-df7c6f94f525"), 145, new Guid("77ece808-5744-459a-af69-c2b2ae864415"), 40 },
                    { new Guid("83f625f9-cde2-46b8-aea5-3879a34ba879"), 67, new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c"), 49 },
                    { new Guid("8434d5b3-c02d-45c4-af0d-740748be6c39"), 127, new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e"), 38 },
                    { new Guid("8918c50c-c3c2-4122-8665-55251399d382"), 149, new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318"), 48 },
                    { new Guid("89bb7909-8422-4a3d-a32b-1b1691801977"), 67, new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e"), 40 },
                    { new Guid("8a41f195-f659-4b5c-b320-35432213ac41"), 17, new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc"), 39 },
                    { new Guid("8d4852ed-8f74-4ee4-a1a0-6fe535d89321"), 107, new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c"), 42 },
                    { new Guid("8e5a7806-10b9-4342-85f1-0dab085398a0"), 54, new Guid("16945fd5-a7ee-41a5-b162-e9b8d7c0815c"), 43 },
                    { new Guid("8fe78f6e-2cba-4012-9cb5-4a00dbf36b45"), 130, new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e"), 36 },
                    { new Guid("90dbfb7d-019c-41aa-b950-9019065f1fbe"), 97, new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818"), 45 },
                    { new Guid("91cdccd2-9a31-452a-bed4-4fa09fdf8584"), 138, new Guid("0e98afcc-5728-4446-853a-342035b5bd9e"), 41 },
                    { new Guid("92eaed63-b46e-4bd9-a3b6-53ad973fbe7e"), 45, new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51"), 41 },
                    { new Guid("9621952b-0c38-45d1-93dd-2141943d98c8"), 32, new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c"), 48 },
                    { new Guid("96263e25-8a8b-4ed1-acfb-f2b5e5909b70"), 141, new Guid("77ece808-5744-459a-af69-c2b2ae864415"), 39 },
                    { new Guid("96b0a654-0efa-45e0-add4-33852f01ebb4"), 41, new Guid("5b8a8bc7-68c3-442b-b26e-64c90e717f5d"), 47 },
                    { new Guid("97951a71-fee4-4580-ac3b-5f54537756bb"), 125, new Guid("00e5d435-4344-4250-85c8-95afb1882347"), 46 },
                    { new Guid("990bac90-89f9-41ba-b29d-c7e51e644cb6"), 75, new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79"), 45 },
                    { new Guid("9bc66158-4659-47e5-8f01-971a5164a212"), 127, new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552"), 46 },
                    { new Guid("a0b6531e-7d1c-40bb-b452-c77e2b32be85"), 74, new Guid("00e5d435-4344-4250-85c8-95afb1882347"), 47 },
                    { new Guid("a416ea28-b878-454b-bae8-fb722b352671"), 100, new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c"), 47 },
                    { new Guid("a6738c21-40ce-4427-a800-d1076f567eef"), 43, new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e"), 37 },
                    { new Guid("a7c0b512-58ca-4531-8e09-b8940af7eec6"), 18, new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a"), 45 },
                    { new Guid("a86def72-337a-42ab-944c-07841722f0b2"), 4, new Guid("39c49022-ee64-43ba-b14b-a557c4b86396"), 45 },
                    { new Guid("a89bab28-b186-4b4b-b8ce-4dd4c9c24af7"), 63, new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495"), 47 },
                    { new Guid("aa3636bc-4b35-4d9d-afeb-bf47f66a770c"), 24, new Guid("ceb861f0-9534-4f15-b5d1-c4f451f6e8fc"), 38 },
                    { new Guid("ab012c9b-c984-46a7-8c11-e743a6f6a125"), 19, new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830"), 41 },
                    { new Guid("acd00f9f-4881-414f-970c-f1f8f91e7d8a"), 105, new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495"), 45 },
                    { new Guid("ae457d78-3094-45e4-b7b3-f0af38c2cacd"), 46, new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e"), 43 },
                    { new Guid("aecf19f6-256d-46f3-9652-cc7ea65aeea3"), 131, new Guid("ea9d6ad5-5437-438f-97cc-1c919b0ebb0c"), 45 },
                    { new Guid("b3ec20b5-7a7f-4777-991a-686fd351454e"), 28, new Guid("77ece808-5744-459a-af69-c2b2ae864415"), 36 },
                    { new Guid("b4cdeb03-f92e-4244-84ee-9912e9e7193a"), 31, new Guid("00e5d435-4344-4250-85c8-95afb1882347"), 48 },
                    { new Guid("b87c039a-6564-4829-be9f-6c01e088f70f"), 40, new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495"), 46 },
                    { new Guid("b93bad51-a664-4b4d-b64c-a32f87758700"), 44, new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f"), 41 },
                    { new Guid("ba50a844-03fc-49c0-8252-2af485bb9ab7"), 105, new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a"), 46 },
                    { new Guid("be683519-b9e9-4503-91c8-fa29e723dddb"), 122, new Guid("9397c206-1d9e-4921-a76d-4d180962a705"), 40 },
                    { new Guid("bfc1260d-b6cf-4c35-84fd-fbcaa3f540da"), 144, new Guid("83828ad7-4e27-411c-abe7-b4bf311d321a"), 42 },
                    { new Guid("c0d96059-a044-4d0d-ad49-6117d4cf33f6"), 7, new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33"), 45 },
                    { new Guid("c0e46795-351e-4cc4-83e2-0dea83fca734"), 123, new Guid("9397c206-1d9e-4921-a76d-4d180962a705"), 36 },
                    { new Guid("c2402325-ced5-461c-90b1-a01b19a11db9"), 107, new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f"), 39 },
                    { new Guid("c394ee66-f53b-4368-8f61-fa8ce8e39932"), 8, new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552"), 44 },
                    { new Guid("c4030591-c963-44e1-a76e-14aa19ba2d5d"), 64, new Guid("906f02bd-2ded-4dcb-9521-513d4ad075a3"), 46 },
                    { new Guid("c6a62b25-2aea-4ea8-ad20-575429f9ff50"), 106, new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b"), 41 },
                    { new Guid("c83340d6-072b-4df5-90a2-251a17d79c7b"), 61, new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96"), 37 },
                    { new Guid("c90d5229-f1a3-405e-84c5-0606e18d8dd5"), 26, new Guid("3f7a12c0-8563-4747-b08a-bbe50d119318"), 49 },
                    { new Guid("ce402ed5-2c7f-4c58-985e-6d6838e5e1b7"), 114, new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc"), 48 },
                    { new Guid("cebf8c3e-9519-43eb-afda-05d68c7837ae"), 33, new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830"), 39 },
                    { new Guid("d539fc3a-8407-400d-8c77-a4c60f3f0e7c"), 58, new Guid("de3c44f6-4a53-423e-9c72-47a7c3de743a"), 44 },
                    { new Guid("d5effaa6-2b97-40ee-a32b-b90cc99645e4"), 125, new Guid("c0107bd8-e8e8-41b7-9c7b-2f272bff5552"), 45 },
                    { new Guid("d7fda52b-2cc9-4c92-ab69-86a81d363b46"), 83, new Guid("9397c206-1d9e-4921-a76d-4d180962a705"), 37 },
                    { new Guid("da48614f-e62c-499a-90da-cfa21fa91662"), 142, new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e"), 45 },
                    { new Guid("da7f0fbd-d509-4a48-8426-fa03e836bf2e"), 22, new Guid("f0dec0a5-2b67-46b0-9883-33578f0b1b51"), 38 },
                    { new Guid("db10ddaa-2b13-48fa-bc04-f66ee6a92b96"), 20, new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c"), 40 },
                    { new Guid("dbe587cf-ab7f-4dfc-95c8-ffdeda8122cb"), 122, new Guid("00e5d435-4344-4250-85c8-95afb1882347"), 44 },
                    { new Guid("def06485-6798-43db-8edd-d887326d64cb"), 132, new Guid("6748d4c5-5aac-43f5-ae16-50cd1644d830"), 43 },
                    { new Guid("df353116-46d0-4a19-8afd-2eb36e97471d"), 97, new Guid("0c2687b7-8563-4264-93f0-4fd4072fdd33"), 47 },
                    { new Guid("e36bd7f9-11dc-4ecf-a7dd-d9a4b76bfae9"), 11, new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79"), 42 },
                    { new Guid("e6ecbc55-2536-4dea-b906-442f74ed0d6b"), 65, new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b"), 43 },
                    { new Guid("e94d597d-c7a3-40cd-ad6c-1aa72af1080f"), 26, new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc"), 47 },
                    { new Guid("e9854905-7958-4f04-a805-aa5d8de30c1f"), 73, new Guid("a8977f7d-40a9-48aa-9fdf-a44762ff8a96"), 36 },
                    { new Guid("e9f3914d-aa15-4e70-b5f4-4dcc188675be"), 17, new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f"), 40 },
                    { new Guid("eacddadf-d29c-4bcc-b41a-d2af16e7afa2"), 88, new Guid("d403b807-aee9-47f7-a7da-d4169a23fd8c"), 39 },
                    { new Guid("eb4506d1-92b4-4629-beb2-c38a29d24680"), 144, new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79"), 44 },
                    { new Guid("f475143d-694c-41cb-afea-0135e03a1083"), 115, new Guid("a02a5046-45f6-4cc6-a2a2-4e63c4bad495"), 44 },
                    { new Guid("f62be967-a6f8-4373-bab1-6c668f294093"), 104, new Guid("55c4f67e-a30b-49cf-9a6a-ab5b9696f8fc"), 49 },
                    { new Guid("f67ef4be-0b5e-4313-89c1-f3f967cc9370"), 51, new Guid("279e8474-87b0-4c48-91d6-a5e93da1eb79"), 43 },
                    { new Guid("f6ce664a-30cb-481d-b6fc-7b4f6e494bab"), 148, new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc"), 44 },
                    { new Guid("f7365d0c-6527-4646-b7fe-bd23195c7dc7"), 95, new Guid("13fe4716-ba7c-4702-bb73-68eb79e83c2b"), 42 },
                    { new Guid("f8f0e1a0-4041-4b86-a684-6fbe599fb445"), 103, new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc"), 40 },
                    { new Guid("fa808839-6b70-4dd2-84c1-d32d6465623a"), 93, new Guid("4e2071fb-5c00-48ac-ae43-e7bd18536a6f"), 38 },
                    { new Guid("fb6c1aa4-54e1-45ac-8790-660021b29978"), 73, new Guid("f4505836-b0d5-4aad-8be8-d9530c70ae3e"), 39 },
                    { new Guid("fc33fe18-8e45-4392-b555-11dbd5545362"), 74, new Guid("e95d91f6-5802-44fa-b832-fbd878c639cc"), 43 },
                    { new Guid("feaaa849-2a4e-444f-a80b-67e07cf4953a"), 128, new Guid("1f4c690d-58bd-4f1f-8599-3b6d6480ff3e"), 42 },
                    { new Guid("ff10c3d1-9b94-45a6-b5f7-ac44f0fed1e9"), 130, new Guid("2e296918-9a26-42d6-a7cf-37f9a565b818"), 48 }
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
