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
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalLike = table.Column<int>(type: "int", nullable: false),
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
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
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
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("274f9a96-baf5-4ff0-919e-fb0cd3e8ba8f"), "Role User với các quyền hạn có giới hạn và mua hàng", "User" },
                    { new Guid("7e8882cd-e91e-441a-8e2c-c67cb6a512aa"), "Role Admin với đầy đủ các quyền hạn", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "AverageRating", "Brand", "Category", "CreateDate", "Description", "Discount", "Gender", "ImageUrl", "IsSale", "LastModifiedDate", "Material", "Name", "Price", "Sold", "TotalRatings", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0554d8f5-8438-416f-be71-7664450c0b26"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4723), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/[IDGiay_21]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4724), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10, 0 },
                    { new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4627), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/[IDGiay_9]_AnhChinh.png", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4628), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268, 0 },
                    { new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4"), 0.7m, "Puma", "Tennis", new DateTime(2024, 9, 12, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(2397), "Breathable material keeps your feet cool and dry.", 29m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(2397), "Mesh", "Puma Model QS5U2", 3871039m, 112, 34, 0 },
                    { new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 9, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4833), "Nike Youth React Presto Extreme combines lightweight React technology and a flexible upper to provide comfort and support for everyday activities and gym training.", 40m, 2, "images/shoes/[IDGiay_Home_1]_AnhChinh_1.png", true, new DateTime(2024, 9, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4839), "Rubber, yarns and textiles.", "Nike Youth React Presto Extreme", 2069000m, 78, 60, 0 },
                    { new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955"), 3.3m, "Puma", "Tennis", new DateTime(2024, 10, 27, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(9693), "Perfect for all sports activities.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(9694), "Rubber", "Puma Model HPUHY", 2986871m, 169, 67, 0 },
                    { new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f"), 0.4m, "Nike", "Tennis", new DateTime(2024, 10, 27, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(8899), "Enhances performance and boosts confidence.", 36m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(8900), "Canvas", "Nike Model PLA5B", 1040646m, 316, 178, 0 },
                    { new Guid("13036b39-1228-4529-8487-4e644cf0096b"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4674), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/[IDGiay_13]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4674), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23, 0 },
                    { new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb"), 0.5m, "Puma", "Football", new DateTime(2024, 10, 17, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(3946), "Lightweight and durable for high-performance.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(3947), "Rubber", "Puma Model 170TQ", 1935049m, 133, 168, 0 },
                    { new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4622), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/[IDGiay_8]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4622), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84, 0 },
                    { new Guid("1dd25236-d258-40c3-a5f3-5526731750f0"), 0.2m, "Adidas", "Football", new DateTime(2024, 9, 13, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(1900), "Provides excellent comfort and support.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(1900), "Leather", "Adidas Model RY3VN", 2283060m, 236, 83, 0 },
                    { new Guid("1e221695-a730-48eb-99c9-b418ffd45e55"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4705), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/[IDGiay_18]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4706), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12, 0 },
                    { new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b"), 3.7m, "Under Armour", "Football", new DateTime(2024, 10, 18, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(9983), "Lightweight and durable for high-performance.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(9984), "Canvas", "Under Armour Model 1PC5O", 3029700m, 66, 28, 0 },
                    { new Guid("20bad046-339f-44b6-836b-23c304fe605e"), 7m, "Nike", "Basketball", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4753), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/[IDGiay_26]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4754), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5, 0 },
                    { new Guid("247825fa-2a6a-43ac-a2c6-074eec278876"), 0.7m, "Under Armour", "Tennis", new DateTime(2024, 9, 29, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(6508), "Perfect for all sports activities.", 31m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(6510), "Canvas", "Under Armour Model K10AG", 1491126m, 336, 60, 0 },
                    { new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa"), 4.0m, "Under Armour", "Football", new DateTime(2024, 10, 5, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(488), "Lightweight and durable for high-performance.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(488), "Canvas", "Under Armour Model LBVUQ", 3925308m, 81, 93, 0 },
                    { new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4742), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/[IDGiay_24]_AnhChinh.png", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4743), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100, 0 },
                    { new Guid("31c12708-925e-42f1-8d01-7efda2860860"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4711), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/[IDGiay_19]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4712), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111, 0 },
                    { new Guid("3662d5c3-42df-4124-82da-363c9fbe8add"), 4.7m, "Converse", "Yoga", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4747), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/[IDGiay_25]_AnhChinh.png", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4748), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30, 0 },
                    { new Guid("380563b8-5488-4561-95b7-f5d032278c60"), 4.0m, "Puma", "Basketball", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4639), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/[IDGiay_11]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4640), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21, 0 },
                    { new Guid("38958eac-d376-460f-b611-064e65a293bf"), 1.1m, "Puma", "Running", new DateTime(2024, 10, 22, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(1040), "A versatile shoe for any occasion.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(1040), "Synthetic", "Puma Model BBQSW", 2090361m, 329, 196, 0 },
                    { new Guid("3ee0604f-5eb2-4e5b-8fdb-65bb30ceab61"), 4.6m, "Nike", "Basketball", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4759), "One of the best shoes for basketball and the symbol of Nike's World. You won't be able to take your eyes off of this brand new Jordan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4760), "Leather, fabric, foam, and rubber.", "Jordan 1 Low Bred Toe 2.0", 1813000m, 45, 23, 0 },
                    { new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653"), 2.3m, "Puma", "Football", new DateTime(2024, 10, 2, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(9173), "Breathable material keeps your feet cool and dry.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(9174), "Mesh", "Puma Model X9T1W", 2545619m, 241, 53, 0 },
                    { new Guid("46e31437-4562-487e-a16b-347a0168de06"), 4.8m, "Nike", "Football", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4589), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/[IDGiay_3]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4589), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10, 0 },
                    { new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d"), 1.6m, "Under Armour", "Running", new DateTime(2024, 10, 28, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(7943), "Designed for optimum traction on various surfaces.", 41m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(7944), "Rubber", "Under Armour Model 8Y6HC", 1027977m, 343, 182, 0 },
                    { new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea"), 1.9m, "Under Armour", "Basketball", new DateTime(2024, 10, 1, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(3187), "A versatile shoe for any occasion.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(3187), "Mesh", "Under Armour Model PTD5E", 3929416m, 45, 196, 0 },
                    { new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4717), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/[IDGiay_20]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4718), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10, 0 },
                    { new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d"), 3.5m, "Nike", "Football", new DateTime(2024, 9, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(7153), "Stylish design for both casual and athletic wear.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(7154), "Synthetic", "Nike Model 06N1I", 1434601m, 47, 170, 0 },
                    { new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4"), 0.7m, "Under Armour", "Running", new DateTime(2024, 9, 19, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(7639), "Stylish design for both casual and athletic wear.", 18m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(7640), "Mesh", "Under Armour Model SNF6N", 3093180m, 257, 33, 0 },
                    { new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2"), 4.7m, "Nike", "Basketball", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4582), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/[IDGiay_2]_AnhChinh.png", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4583), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45, 0 },
                    { new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f"), 2.2m, "Nike", "Tennis", new DateTime(2024, 9, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(3448), "Enhances performance and boosts confidence.", 41m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(3449), "Canvas", "Nike Model V2FVK", 3847379m, 135, 163, 0 },
                    { new Guid("6384c424-0892-43ee-af48-7090bb5f38b9"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4609), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/[IDGiay_6]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4610), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381, 0 },
                    { new Guid("7493af94-8f29-4024-bba9-d930949a216e"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4633), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/[IDGiay_10]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4634), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3, 0 },
                    { new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4700), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/[IDGiay_17]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4700), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20, 0 },
                    { new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad"), 0.6m, "Reebok", "Basketball", new DateTime(2024, 10, 9, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(8422), "A versatile shoe for any occasion.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(8422), "Synthetic", "Reebok Model 41O9E", 3130731m, 233, 19, 0 },
                    { new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53"), 4.2m, "Puma", "Football", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4645), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/[IDGiay_12]_AnhChinh.png", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4646), "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17, 0 },
                    { new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4729), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/[IDGiay_22]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4730), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45, 0 },
                    { new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 9, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4851), "Whether you're starting your running journey or an expert eager to switch up your pace, the Downshifter 13 is down for the ride. With a revamped upper, cushioning and durability, it helps you find that extra gear or take that first stride towards chasing down your goals.", 40m, 1, "images/shoes/[IDGiay_Home_3]_AnhChinh_1.png", true, new DateTime(2024, 9, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4852), "Plastics, yarns and textiles.", "Nike Downshifter 13", 2069000m, 78, 20, 0 },
                    { new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231"), 1.7m, "Puma", "Gym & Training", new DateTime(2024, 9, 14, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(8678), "Perfect for all sports activities.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(8678), "Leather", "Puma Model 7R357", 2194311m, 309, 84, 0 },
                    { new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3"), 4.1m, "Puma", "Yoga", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4680), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/[IDGiay_14]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4681), "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22, 0 },
                    { new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209"), 1.4m, "Reebok", "Running", new DateTime(2024, 10, 21, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(3706), "Enhances performance and boosts confidence.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(3707), "Rubber", "Reebok Model WLGR2", 1498769m, 207, 25, 0 },
                    { new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7"), 1.5m, "Adidas", "Football", new DateTime(2024, 9, 25, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(7422), "Perfect for all sports activities.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(7423), "Leather", "Adidas Model FMD1K", 3617146m, 190, 164, 0 },
                    { new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4692), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/[IDGiay_16]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4693), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25, 0 },
                    { new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0"), 2.3m, "Nike", "Basketball", new DateTime(2024, 10, 25, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(2676), "Lightweight and durable for high-performance.", 11m, 0, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(2677), "Rubber", "Nike Model PYDS0", 3280482m, 145, 81, 0 },
                    { new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd"), 4.4m, "Adidas", "Football", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4615), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/[IDGiay_7]_AnhChinh.png", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4616), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37, 0 },
                    { new Guid("aea8f861-0d82-4e98-b348-d230303c0377"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 9, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4845), "Nike's first lifestyle Air Max brings you style, comfort and big attitude in the Nike Air Max 270. The design draws inspiration from Air Max icons, showcasing Nike's greatest innovation with its large window and fresh array of colors.", 40m, 1, "images/shoes/[IDGiay_Home_2]_AnhChinh_1.png", true, new DateTime(2024, 9, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4846), "Plastics, yarns and textiles.", "Nike Air Max 270", 4059000m, 8, 3, 0 },
                    { new Guid("b82e76c3-348c-4696-a49a-34c9f24c98d6"), 4.2m, "Adidas", "Basketball", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4820), "One of the best shoes for basketball and the symbol of Adidas's World. You won't be able to take your eyes off of this brand new SuperStan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4822), "Leather, fabric, foam, and rubber.", "Adidas Original StanSmith", 1713000m, 65, 33, 0 },
                    { new Guid("bac09f6d-fa8c-4262-9501-992aa8399807"), 0.5m, "Nike", "Running", new DateTime(2024, 10, 23, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(6908), "Perfect for all sports activities.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(6909), "Mesh", "Nike Model RHU2K", 1106225m, 62, 66, 0 },
                    { new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337"), 4.2m, "Nike", "Tennis", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4595), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/[IDGiay_4]_AnhChinh.png", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4596), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5, 0 },
                    { new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f"), 4.9m, "Nike", "Yoga", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4602), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/[IDGiay_5]_AnhChinh.png", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4602), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66, 0 },
                    { new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9"), 0.2m, "Adidas", "Running", new DateTime(2024, 10, 27, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(9392), "Provides excellent comfort and support.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(9393), "Rubber", "Adidas Model YFJU8", 3249246m, 77, 18, 0 },
                    { new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e"), 2.7m, "Adidas", "Basketball", new DateTime(2024, 10, 15, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(2918), "Provides excellent comfort and support.", 36m, 0, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(2918), "Canvas", "Adidas Model 2ALMG", 2905443m, 190, 114, 0 },
                    { new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4686), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/[IDGiay_15]_AnhChinh.png", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4687), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87, 0 },
                    { new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4"), 4.4m, "Converse", "Basketball", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4736), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/[IDGiay_23]_AnhChinh.png", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4737), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34, 0 },
                    { new Guid("df05c39f-463c-4fbd-b716-e35109510f34"), 1.9m, "Under Armour", "Gym & Training", new DateTime(2024, 10, 10, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(8205), "A versatile shoe for any occasion.", 40m, 0, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(8206), "Rubber", "Under Armour Model Q92QP", 3723173m, 105, 144, 0 },
                    { new Guid("e02caea8-b235-41c8-879a-d58ef35d8683"), 4.7m, "Under Armour", "Tennis", new DateTime(2024, 10, 12, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(223), "Lightweight and durable for high-performance.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(224), "Mesh", "Under Armour Model 56MNS", 3280465m, 216, 198, 0 },
                    { new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4564), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/[IDGiay_1]_AnhChinh.png", false, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4575), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20, 0 },
                    { new Guid("e56e8da8-9477-4da8-88e0-898700185bef"), 2.6m, "Puma", "Basketball", new DateTime(2024, 10, 16, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(1585), "Provides excellent comfort and support.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(1586), "Mesh", "Puma Model 8N9XX", 1472377m, 172, 47, 0 },
                    { new Guid("f44db049-91fa-4df8-a155-6c2eed2dbb1c"), 4.8m, "Nike", "Running", new DateTime(2024, 9, 23, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(2191), "Enhances performance and boosts confidence.", 6m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(2191), "Mesh", "Nike Model JR2PM", 2667740m, 184, 102, 0 },
                    { new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023"), 1.2m, "Puma", "Tennis", new DateTime(2024, 10, 28, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(753), "Provides excellent comfort and support.", 36m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(753), "Rubber", "Puma Model 44DNH", 1044973m, 324, 49, 0 },
                    { new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326"), 2.5m, "Puma", "Running", new DateTime(2024, 10, 10, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(1273), "Breathable material keeps your feet cool and dry.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 30, 22, 30, 26, 646, DateTimeKind.Local).AddTicks(1274), "Leather", "Puma Model O0YNE", 3105283m, 268, 49, 0 },
                    { new Guid("fc75303c-9701-4a92-8398-fa6a9039bcb3"), 4.7m, "Puma", "Football", new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4827), "One of the best shoes for football and the symbol of Puma's World. You won't be able to take your eyes off of this brand new FUTURE, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 30, 22, 30, 26, 645, DateTimeKind.Local).AddTicks(4828), "Leather, fabric, foam, and rubber.", "Puma FUTURE 7 Ultimate FG/AG The Forever Faster", 2713000m, 78, 55, 0 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("01ccf426-447f-4790-84dc-e8a4d64f6665"), new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea"), "images/shoes/noimage.webp" },
                    { new Guid("05098835-dc39-4bc2-86e4-43cc6f73d1a1"), new Guid("fc75303c-9701-4a92-8398-fa6a9039bcb3"), "https://thumblr.uniid.it/product/336262/8307c19dcf3d.jpg?width=3840&format=webp&q=75" },
                    { new Guid("05e4849c-acf3-4f5e-ba4a-bae1912a2c68"), new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("06289563-aed5-4a12-ba79-8194e1f0bfa5"), new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("0bdb7006-9d2a-42d8-be3d-aa09f0790d6d"), new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("0c69d607-207f-49cd-954e-20240fee9c08"), new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f"), "images/shoes/noimage.webp" },
                    { new Guid("0dc5e642-81b8-4cca-87bd-430e5567b51c"), new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("0df16708-0e14-4af2-b383-b3f067d3bfd5"), new Guid("7493af94-8f29-4024-bba9-d930949a216e"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("0e4b83e1-20f6-42d8-9282-48ff697c0eaf"), new Guid("380563b8-5488-4561-95b7-f5d032278c60"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("0e62a7e6-b7f0-4978-95b7-598d2729045b"), new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("100307aa-35d7-41f4-aa43-63b90f7e0785"), new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("10ace1fa-96a1-4c55-bcba-77a17d2da89e"), new Guid("3662d5c3-42df-4124-82da-363c9fbe8add"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("11c3528f-78ca-4180-9c10-3070e59823a3"), new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("148db9d8-2ea1-49a6-b7b8-f998af5bd094"), new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("15c05378-2d34-49d6-ae36-45dc2396f417"), new Guid("20bad046-339f-44b6-836b-23c304fe605e"), "https://c.files.bbci.co.uk/1081F/production/_117751676_satan-shoes2.jpg" },
                    { new Guid("15dfa65a-2c0d-4059-9abe-93c8ad9ce349"), new Guid("1e221695-a730-48eb-99c9-b418ffd45e55"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("18f356d4-172e-43f4-b602-900d4daf5130"), new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("1ada4a38-c73f-4ed1-867a-249675985870"), new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("1b82ece6-2245-41ed-b483-99abe5d9cbaf"), new Guid("6384c424-0892-43ee-af48-7090bb5f38b9"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("1bc9fe3c-2362-4eb9-a4fc-08bf8e9f63ab"), new Guid("1dd25236-d258-40c3-a5f3-5526731750f0"), "images/shoes/noimage.webp" },
                    { new Guid("1ce6ace9-a4e0-4f1f-a445-d51d066fac84"), new Guid("fc75303c-9701-4a92-8398-fa6a9039bcb3"), "https://thumblr.uniid.it/product/336262/57daee260d2a.jpg?width=3840&format=webp&q=75" },
                    { new Guid("1d90fb21-410f-45ce-8416-a52a22f8ac8a"), new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("1f0581ac-b26a-4f65-b4cc-f357f5bf95f2"), new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("1feef6e3-3e40-4155-98b3-b76643b593a4"), new Guid("46e31437-4562-487e-a16b-347a0168de06"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("20347150-ec14-4964-a5ea-f0dba5084750"), new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9"), "images/shoes/[IDGiay_Home_1]_AnhPhu_1.jpg" },
                    { new Guid("2446040d-f75b-4863-9ce2-269e8a70f962"), new Guid("3662d5c3-42df-4124-82da-363c9fbe8add"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("25412349-f52e-4433-bbbd-206700095781"), new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("25b0757d-9629-439f-b558-b2e494fd0587"), new Guid("1e221695-a730-48eb-99c9-b418ffd45e55"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("2e3defe1-4069-414c-990b-7e9c62e74287"), new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("2e9bde15-7768-45bc-bf83-934ef5bb04f4"), new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e"), "images/shoes/noimage.webp" },
                    { new Guid("2fb23879-c303-4f42-8cf1-424c786afa27"), new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("329beeb3-4cd5-4698-bd07-87c72b42d23c"), new Guid("e02caea8-b235-41c8-879a-d58ef35d8683"), "images/shoes/noimage.webp" },
                    { new Guid("3359a394-fd54-45a4-b1dc-b33883c8251d"), new Guid("b82e76c3-348c-4696-a49a-34c9f24c98d6"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-1.jpg" },
                    { new Guid("354be953-9c7b-4c2b-86ca-a59f6f9af153"), new Guid("1e221695-a730-48eb-99c9-b418ffd45e55"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("36a6f198-fee4-4d02-ba34-a14a3c2268d6"), new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("371a8b15-ff52-4915-aa2e-928cffe91d54"), new Guid("20bad046-339f-44b6-836b-23c304fe605e"), "https://photo.znews.vn/w660/Uploaded/rohunwa/2021_03_26/SHOES3.jpeg" },
                    { new Guid("38ca8d2b-6544-4541-ad49-9f237ddace32"), new Guid("fc75303c-9701-4a92-8398-fa6a9039bcb3"), "https://thumblr.uniid.it/product/336262/a92a6cadc8a6.jpg?width=3840&format=webp&q=75" },
                    { new Guid("395d7585-66c4-4087-81e9-6bfe9ac6c552"), new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("3a56266b-6012-4b3b-a5d8-482f33c9d2b8"), new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("3b84ce09-2f42-4dff-ba2c-45f09c254751"), new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4"), "images/shoes/noimage.webp" },
                    { new Guid("3ccfdc24-b097-4d54-8161-b765f70eb148"), new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("3f85157c-3f13-460c-8e04-fa85a7610f88"), new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("3f9428a0-7997-42b8-8a05-e867d43dfb3f"), new Guid("3ee0604f-5eb2-4e5b-8fdb-65bb30ceab61"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNBQXFHswxHuyjT_e8rb5XOaWUzEe3pphPPw&s" },
                    { new Guid("40b84f53-fcc0-492e-b883-19b7ae6882e6"), new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("413b5982-865b-489a-b819-f08701aa4d8c"), new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f"), "images/shoes/noimage.webp" },
                    { new Guid("4591d1ce-4352-4d61-8bbe-dff1f1120a25"), new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa"), "images/shoes/noimage.webp" },
                    { new Guid("496508d8-06b3-498b-9adf-2beba7ea699b"), new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("49bdf895-45da-4071-9b5d-9988ee0e0628"), new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("4aa140c3-936d-418e-a180-6008edd151e2"), new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023"), "images/shoes/noimage.webp" },
                    { new Guid("4ae2ad0b-8340-4132-83a0-fd2e3d2ca5d1"), new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("4c1f8c42-dd88-4fe5-8726-f9ed79bf0b9d"), new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("4ec9faa4-4032-4f0e-8da8-92d7e5f0f7b4"), new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("529dbc9d-6369-40bf-8228-cbdd2608e71a"), new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653"), "images/shoes/noimage.webp" },
                    { new Guid("52ffa9f2-391c-49f8-9331-e6d403e3d682"), new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422"), "images/shoes/[IDGiay_Home_3]_AnhPhu_2.png" },
                    { new Guid("567ab537-7b66-4784-9c8b-316b755ce7e4"), new Guid("38958eac-d376-460f-b611-064e65a293bf"), "images/shoes/noimage.webp" },
                    { new Guid("56d2f678-77a1-4c9b-8d6b-d38d545cce1c"), new Guid("b82e76c3-348c-4696-a49a-34c9f24c98d6"), "https://likelihood.us/cdn/shop/files/stansmith_angle_1200x.png?v=1691430477" },
                    { new Guid("575ed832-d718-43c9-9326-67ac8b2bf4f6"), new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("5e25517c-e9e0-4df5-acdf-18c31234ff40"), new Guid("247825fa-2a6a-43ac-a2c6-074eec278876"), "images/shoes/noimage.webp" },
                    { new Guid("606eeade-e212-4d7c-9711-761e01b76fd8"), new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad"), "images/shoes/noimage.webp" },
                    { new Guid("60721b25-0be2-492b-bd11-7c9b8e5c2475"), new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("60a5e562-17fe-4bfd-9b9a-4a64835031e3"), new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7"), "images/shoes/noimage.webp" },
                    { new Guid("61e6da84-d67a-400f-b3b2-93617c817eef"), new Guid("46e31437-4562-487e-a16b-347a0168de06"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("6660303b-ccc1-4702-80f2-b71f03614f05"), new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("67fb98cb-348a-4c32-be31-3a6b0f11f678"), new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4"), "images/shoes/noimage.webp" },
                    { new Guid("683b7d86-09a0-413b-b64e-263d4c883fa3"), new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("6b63be74-7e04-48dd-84e3-5f6ea927b926"), new Guid("380563b8-5488-4561-95b7-f5d032278c60"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("6e1d4f82-166f-4e69-808c-114f3bc17b2b"), new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("70fa14a5-acef-4e30-897a-ada014c668b5"), new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("71b9828d-df4e-425a-b583-4198d37a8b5e"), new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("732c70af-57be-4e61-aa32-e657f76edc26"), new Guid("20bad046-339f-44b6-836b-23c304fe605e"), "https://media.cnn.com/api/v1/images/stellar/prod/210328223753-03-lil-nas-x-satan-shoes.jpg?q=w_3000,h_3000,x_0,y_0,c_fill" },
                    { new Guid("73409ce1-a993-4083-b7db-0bf3d9707ac4"), new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("73c167e3-9dba-4edf-be06-c090df028ed4"), new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("74c6fa9f-eb99-41f2-b46d-7c858a1c0638"), new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb"), "images/shoes/noimage.webp" },
                    { new Guid("7583a096-a2c3-4391-bc93-70960b8dc41a"), new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d"), "images/shoes/noimage.webp" },
                    { new Guid("75a43726-8f6e-4a2d-a0dc-092e9c3efd75"), new Guid("6384c424-0892-43ee-af48-7090bb5f38b9"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("7630dc2a-a5be-41ee-9ab7-0b2749b0172a"), new Guid("31c12708-925e-42f1-8d01-7efda2860860"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("763497a8-2c94-43a8-9fd3-5b5696735d82"), new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422"), "images/shoes/[IDGiay_Home_3]_AnhPhu_3.png" },
                    { new Guid("76ac36fd-255d-4c57-ac82-4f0fadfa0514"), new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("77873424-d745-452e-a370-363c95959ff1"), new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b"), "images/shoes/noimage.webp" },
                    { new Guid("78707cb4-71d5-49d4-a998-266a8329382d"), new Guid("3ee0604f-5eb2-4e5b-8fdb-65bb30ceab61"), "https://dmpkickz.com/cdn/shop/files/6_78fd24e0-cd30-400a-8fa1-e5e6cd3c5b0b.png?v=1696679846&width=480" },
                    { new Guid("78ceaff6-2053-49a4-a74a-771a7851427b"), new Guid("20bad046-339f-44b6-836b-23c304fe605e"), "https://i.pinimg.com/originals/c0/cf/d1/c0cfd1545f10c56793e888e991b60487.png" },
                    { new Guid("78fabf87-9bd1-4c4d-983e-44c8e9014e2c"), new Guid("1e221695-a730-48eb-99c9-b418ffd45e55"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("79a21b64-6d11-42ee-b2f8-95ccd60ab917"), new Guid("aea8f861-0d82-4e98-b348-d230303c0377"), "images/shoes/[IDGiay_Home_2]_AnhPhu_4.png" },
                    { new Guid("7b515e2d-1cb5-4adb-a74b-178aa3d95c55"), new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("7cd96c74-8aa3-4b1e-989e-11d81d7b4cdc"), new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("7fe1abb1-6517-4d03-ac1b-3f047ffa7fd5"), new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("828ee4ed-8eae-4466-97da-9bf56a01ddab"), new Guid("380563b8-5488-4561-95b7-f5d032278c60"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("83006e7e-998e-4ecc-b319-453cb4143e60"), new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9"), "images/shoes/noimage.webp" },
                    { new Guid("86b105e7-5ffa-44f5-b74e-f2ad2de999f4"), new Guid("46e31437-4562-487e-a16b-347a0168de06"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("88754571-77c8-4a88-bded-64c3aaebf430"), new Guid("bac09f6d-fa8c-4262-9501-992aa8399807"), "images/shoes/noimage.webp" },
                    { new Guid("891675ef-7952-4d49-aab5-f2f8fd4aa7a0"), new Guid("6384c424-0892-43ee-af48-7090bb5f38b9"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("8d1b9fa5-f8c4-4c15-aae6-b77d581dce42"), new Guid("0554d8f5-8438-416f-be71-7664450c0b26"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("8da7f83e-f40a-485e-a52f-ae4c32845499"), new Guid("b82e76c3-348c-4696-a49a-34c9f24c98d6"), "https://assets.adidas.com/images/w_1880,f_auto,q_auto/e53b9a57b0a745be924bac1e00f54427_9366/FX5502_42_detail.jpg" },
                    { new Guid("8e31fa34-9984-4e28-a173-d1bebd2921aa"), new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0"), "images/shoes/noimage.webp" },
                    { new Guid("950784be-774f-4c40-9136-63d2b57ac194"), new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("952dc3e2-4b96-4eb1-9fcc-35cf62379026"), new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955"), "images/shoes/noimage.webp" },
                    { new Guid("95897e60-a479-4f9e-8d10-627cc6f15283"), new Guid("7493af94-8f29-4024-bba9-d930949a216e"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("95de186c-1b4a-45a7-985c-a6f3121fa931"), new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("96636523-7de9-4a79-b695-a77502507237"), new Guid("7493af94-8f29-4024-bba9-d930949a216e"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("97cbacd7-39e4-4c5f-a31f-f2091eff297b"), new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("98cb688c-c442-42f4-9794-b8c5c2c7a176"), new Guid("3ee0604f-5eb2-4e5b-8fdb-65bb30ceab61"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3rZPCUSKRHdQA5_g3YBJRdcmIf_6PpZcNZg&s" },
                    { new Guid("99efea1a-4920-4dac-9e02-d533e79b63ce"), new Guid("20bad046-339f-44b6-836b-23c304fe605e"), "https://gossipdergi.com/wp-content/uploads/2021/04/nikeayakkabi.gif" },
                    { new Guid("9b97b336-52a9-47a9-be7b-3fe53b91f6b1"), new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("9c2c8ffe-a5df-4708-aac5-7c9bd292e5ee"), new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("a15f9d5b-f531-45e9-b344-b12ed5208ff2"), new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231"), "images/shoes/noimage.webp" },
                    { new Guid("a1dcbe79-765c-4cb6-ab29-2194959b3382"), new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("a38b94ae-1e88-40bc-9fc6-266d05d8257d"), new Guid("13036b39-1228-4529-8487-4e644cf0096b"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("a4915158-0354-4160-808b-cdb791c90cb9"), new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("a62886e2-ccef-4544-97ba-5789301a59ce"), new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9"), "images/shoes/[IDGiay_Home_1]_AnhPhu_4.jpg" },
                    { new Guid("a63f889c-21c0-429e-b53e-4728fd1cc807"), new Guid("0554d8f5-8438-416f-be71-7664450c0b26"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("a6c163d3-4bf6-43c9-9fa6-b0cd7c28da66"), new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("a7db36a0-e722-4cff-8720-1410eef8a66f"), new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("a7de84eb-c575-42f0-a368-db848a46fcde"), new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("a8f81922-7c14-4850-b6cd-bed3ea41abe6"), new Guid("13036b39-1228-4529-8487-4e644cf0096b"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("a911da75-9ea2-4cea-97d2-7d2186d5756a"), new Guid("380563b8-5488-4561-95b7-f5d032278c60"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("aa706243-cdba-476d-8698-66a8511ca3b3"), new Guid("46e31437-4562-487e-a16b-347a0168de06"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("aafb0758-7109-4898-a57b-3e79a9639c6c"), new Guid("7493af94-8f29-4024-bba9-d930949a216e"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("ad3c3a50-51e0-4c40-95a8-75a39f804605"), new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9"), "images/shoes/[IDGiay_Home_1]_AnhPhu_2.jpg" },
                    { new Guid("adc771b5-63db-413c-99de-d26af226527d"), new Guid("f44db049-91fa-4df8-a155-6c2eed2dbb1c"), "images/shoes/noimage.webp" },
                    { new Guid("af2343cf-e826-408b-8f7e-424a20043fd7"), new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("b1b457e0-a2c8-48d8-8b3b-93ad00cd7112"), new Guid("e56e8da8-9477-4da8-88e0-898700185bef"), "images/shoes/noimage.webp" },
                    { new Guid("bad9176a-3274-4a87-9674-a01a08d6739b"), new Guid("0554d8f5-8438-416f-be71-7664450c0b26"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("bae4e9b2-5e1d-4066-ac1f-78c15fc329d7"), new Guid("b82e76c3-348c-4696-a49a-34c9f24c98d6"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-3.jpg" },
                    { new Guid("bd02544f-5c4a-4701-828b-b75acc858197"), new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422"), "images/shoes/[IDGiay_Home_3]_AnhPhu_1.png" },
                    { new Guid("bd959f66-6002-441f-99ce-2c78ceba4b4e"), new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("c14258ae-bb99-4569-be33-67d16d9d3735"), new Guid("13036b39-1228-4529-8487-4e644cf0096b"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("c152b7cd-652a-481f-b65f-12785a5f3f1b"), new Guid("3662d5c3-42df-4124-82da-363c9fbe8add"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("c36a077e-1972-4734-a4ab-7b37d6a39b32"), new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("c44b64eb-db7d-4557-b012-d67937b5fc23"), new Guid("3662d5c3-42df-4124-82da-363c9fbe8add"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("c566ef87-2567-43de-8caa-1dbaf1469890"), new Guid("31c12708-925e-42f1-8d01-7efda2860860"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("c58c2f08-603e-4cd3-915c-2111432744f1"), new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("c7953e8f-390c-41fa-93df-9fe09ef8a571"), new Guid("aea8f861-0d82-4e98-b348-d230303c0377"), "images/shoes/[IDGiay_Home_2]_AnhPhu_1.png" },
                    { new Guid("c935a4c1-f6cd-48f9-9e99-c347fcb52d29"), new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("c9ffff35-763b-4916-8532-7b2edb976a0d"), new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("cadab2e3-3dee-4208-8fe4-d7dc53399188"), new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("cc35220a-ced7-41bb-ba0f-0a8668d85dd2"), new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326"), "images/shoes/noimage.webp" },
                    { new Guid("d12a8c37-b593-4a77-b987-04e715aafe8c"), new Guid("aea8f861-0d82-4e98-b348-d230303c0377"), "images/shoes/[IDGiay_Home_2]_AnhPhu_2.png" },
                    { new Guid("d3b26c51-d171-41a4-ac6a-076ea82bd8ba"), new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209"), "images/shoes/noimage.webp" },
                    { new Guid("d4c5836d-ddf1-48b7-9cff-d34d7dd0278e"), new Guid("aea8f861-0d82-4e98-b348-d230303c0377"), "images/shoes/[IDGiay_Home_2]_AnhPhu_3.png" },
                    { new Guid("d8de9616-4f70-469e-8619-614d2cfa6a74"), new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9"), "images/shoes/[IDGiay_Home_1]_AnhPhu_3.jpg" },
                    { new Guid("db337a66-f424-42ad-9d80-32b58e40f39b"), new Guid("31c12708-925e-42f1-8d01-7efda2860860"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("de518b78-075f-4856-9bc6-c2d330f60bb9"), new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("df438eaf-3e92-4de5-88a4-73b38c6bb2d4"), new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("df6164b8-a1b0-4a6f-a3a1-52fa49a68c7a"), new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("e1d98163-df7b-4831-b05b-d9c3fd03efe1"), new Guid("31c12708-925e-42f1-8d01-7efda2860860"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("e4a0b612-c63a-46e0-9216-cb0e1a760ec1"), new Guid("13036b39-1228-4529-8487-4e644cf0096b"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("e55dffed-af6f-4f51-87f8-d0621925ddd5"), new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d"), "images/shoes/noimage.webp" },
                    { new Guid("ed3718db-2edf-4637-94bb-6782d361be10"), new Guid("6384c424-0892-43ee-af48-7090bb5f38b9"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("f181a1d8-81dc-4b56-ae96-c6e822ccf02f"), new Guid("3ee0604f-5eb2-4e5b-8fdb-65bb30ceab61"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQPenW_eiwOe1RkKeaF_kg5TraxKiem6NJ_Q&s" },
                    { new Guid("f4cda9ab-afa6-4df4-8f66-45d8a17eb550"), new Guid("fc75303c-9701-4a92-8398-fa6a9039bcb3"), "https://www.prosoccer.com/cdn/shop/files/PumaFuture7UltimateFGAG-ForeverFasterPack_SP24_Model1_1500x.png?v=1713488175" },
                    { new Guid("f79386b7-014f-4ed9-bff0-c881e1ad071d"), new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("f91eb26c-842a-4572-99fd-7a67e1a873c2"), new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422"), "images/shoes/[IDGiay_Home_3]_AnhPhu_4.png" },
                    { new Guid("fa0597a3-c8cf-4b0c-a46a-c7f78127164e"), new Guid("df05c39f-463c-4fbd-b716-e35109510f34"), "images/shoes/noimage.webp" },
                    { new Guid("fc99916e-d8ba-4220-9c59-b32b13b7b7e2"), new Guid("0554d8f5-8438-416f-be71-7664450c0b26"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("fe0b338a-6dab-42d9-acce-a7c416f18574"), new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("feb4e042-1d37-40a8-97e0-8c4b9198883e"), new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("ff57d874-f545-4e57-ac83-83ee0c8db3d1"), new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("ff818c6b-cc3c-4664-b8a7-862144ed665d"), new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("0021766c-c116-46f2-aa81-bad8699249b3"), "Winter", new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f") },
                    { new Guid("02e6860e-4666-4c40-b16c-63ceffb5798e"), "Spring", new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d") },
                    { new Guid("03315419-f1bf-454b-8019-d7a9fb8e293b"), "Spring", new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9") },
                    { new Guid("0356325e-22c6-4b32-8356-eda8ae2c0fde"), "Summer", new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209") },
                    { new Guid("03e560a7-a7bf-4242-ace1-1d10c380a9f3"), "Autumn", new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9") },
                    { new Guid("04eb2375-26db-4929-b97d-2bfd2a72cf6c"), "Spring", new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd") },
                    { new Guid("05016813-5123-4a3a-b4b7-562b2b6fb0af"), "Winter", new Guid("38958eac-d376-460f-b611-064e65a293bf") },
                    { new Guid("06475a3b-8d25-4559-849d-5b37a29aed46"), "Spring", new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9") },
                    { new Guid("06abed1a-c5e1-4aed-9c4a-9ecb7b419e27"), "Winter", new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2") },
                    { new Guid("06facd1f-140c-4a4f-bda2-00e375a8d117"), "Summer", new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f") },
                    { new Guid("0b7ec9ae-3ebf-4eee-be79-825e9e872f54"), "Winter", new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4") },
                    { new Guid("0c0b1ad5-9832-446b-8f72-fb3005fc5c3d"), "Spring", new Guid("aea8f861-0d82-4e98-b348-d230303c0377") },
                    { new Guid("100ac15b-5939-45d5-9573-edfe3b70c83e"), "Summer", new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d") },
                    { new Guid("1264b8db-d64a-4167-8ac7-7fcd96e34e00"), "Summer", new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9") },
                    { new Guid("130ef798-f5f1-440f-96a1-eada0b2ee847"), "Winter", new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad") },
                    { new Guid("134dd396-0e6f-445a-a3f0-13e4a17d47eb"), "Summer", new Guid("1e221695-a730-48eb-99c9-b418ffd45e55") },
                    { new Guid("178fe2b5-037b-4be7-acf3-0fe7469bca9b"), "Spring", new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53") },
                    { new Guid("17ec6a00-222d-419a-b63b-2970427779da"), "Winter", new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4") },
                    { new Guid("1a0d82b3-bd47-4a46-b02b-eafcc6777246"), "Summer", new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e") },
                    { new Guid("1c793440-08bc-44a8-b059-5363f1c4162c"), "Spring", new Guid("20bad046-339f-44b6-836b-23c304fe605e") },
                    { new Guid("1d276868-b0c7-463a-a7a3-8efa6fd45d7d"), "Summer", new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c") },
                    { new Guid("1eac298e-6c54-4f73-b3a1-ea82a9e2f3c1"), "Winter", new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4") },
                    { new Guid("1f4a15c6-e075-49d2-9225-0a43ab6e0da9"), "Spring", new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f") },
                    { new Guid("219ec8a6-0cca-4a74-a6e9-38b1ad20fc42"), "Autumn", new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955") },
                    { new Guid("22e16f46-ed0b-44b5-860f-e35c337b8a4c"), "Spring", new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b") },
                    { new Guid("263c2648-3959-4361-a14a-40a2adc48fb0"), "Winter", new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf") },
                    { new Guid("2690d499-00a5-490b-b5d2-5808ed59b886"), "Autumn", new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d") },
                    { new Guid("28ce1d5d-1f97-484f-8433-436d128d495f"), "Summer", new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7") },
                    { new Guid("2aef3237-53ca-450b-bfb4-a416ee81f3eb"), "Winter", new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9") },
                    { new Guid("2af0d705-746b-496c-ac38-73056a7f8149"), "Summer", new Guid("df05c39f-463c-4fbd-b716-e35109510f34") },
                    { new Guid("2bcaf36a-6127-466f-b58c-031c4373c2c8"), "Summer", new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955") },
                    { new Guid("2cbb5dff-0dba-4cdb-b048-15413aca9592"), "Autumn", new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209") },
                    { new Guid("2d40582c-afc4-4b7f-88c6-eb990fe10764"), "Spring", new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa") },
                    { new Guid("2ddbe97e-7bb9-43b3-ac59-41820b84a011"), "Fall", new Guid("aea8f861-0d82-4e98-b348-d230303c0377") },
                    { new Guid("2fd86dab-2412-4d0d-beaa-f48d889773fd"), "Summer", new Guid("38958eac-d376-460f-b611-064e65a293bf") },
                    { new Guid("30068d49-b5db-4877-a84d-1238980c652f"), "Spring", new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209") },
                    { new Guid("30ed0e5b-75a2-470e-8598-8f8c212a5f3a"), "Fall", new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337") },
                    { new Guid("313bbed1-b045-49b5-af6d-737228803a87"), "Fall", new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f") },
                    { new Guid("32463ec9-9c53-42bf-9662-353093540b99"), "Winter", new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326") },
                    { new Guid("33173f5f-f4cd-4abc-927d-9257eb2b4024"), "Winter", new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea") },
                    { new Guid("34e31480-0473-4bf0-9bb2-506f625a392c"), "Summer", new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4") },
                    { new Guid("382868f0-65a3-4105-9870-098b8daa9242"), "Spring", new Guid("1e221695-a730-48eb-99c9-b418ffd45e55") },
                    { new Guid("3f5e0f0a-4b3b-4b64-880e-24418c2a42a7"), "Winter", new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0") },
                    { new Guid("3fffdd74-fddf-42ef-97e3-6a7f279bc9c8"), "Summer", new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b") },
                    { new Guid("40293b66-e578-411c-ad5d-39f55eafc7f8"), "Summer", new Guid("e56e8da8-9477-4da8-88e0-898700185bef") },
                    { new Guid("415a5ef6-2f4e-43ac-8e41-85f5903c346d"), "Summer", new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb") },
                    { new Guid("42ac42f8-d418-452f-9a0a-f47fbc76e8a8"), "Summer", new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d") },
                    { new Guid("44c46d53-e2ab-4649-a590-6908bee40a92"), "Summer", new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa") },
                    { new Guid("473c3a6c-e68e-405d-805a-06b5000834c3"), "Summer", new Guid("247825fa-2a6a-43ac-a2c6-074eec278876") },
                    { new Guid("487fdf9f-0ea5-49fc-aadc-b5839149f641"), "Spring", new Guid("7493af94-8f29-4024-bba9-d930949a216e") },
                    { new Guid("4b9f538e-0b06-47ba-ba0c-dff8758d0a01"), "Summer", new Guid("e02caea8-b235-41c8-879a-d58ef35d8683") },
                    { new Guid("4c2e385a-2620-4a3d-b0ef-6686cce2a8f5"), "Spring", new Guid("1dd25236-d258-40c3-a5f3-5526731750f0") },
                    { new Guid("4f8f408d-1a73-48bf-a092-8cdce271c7c2"), "Fall", new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2") },
                    { new Guid("5194d3d0-adbc-41d8-b447-9990b4d7a506"), "Summer", new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337") },
                    { new Guid("5261f9aa-75eb-4efd-98cb-59e822d1274e"), "Autumn", new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0") },
                    { new Guid("53d79d8c-dfe9-41bd-b89c-3a69db1c3786"), "Spring", new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337") },
                    { new Guid("55a4c53b-e76a-48a6-aece-925c3986a6ed"), "Winter", new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955") },
                    { new Guid("55eef409-0f78-4d7d-bdb5-272a8183b4db"), "Summer", new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585") },
                    { new Guid("57b2d7fe-fa01-42b7-a7de-e13ed24401f9"), "Winter", new Guid("0554d8f5-8438-416f-be71-7664450c0b26") },
                    { new Guid("5842476b-1d50-4462-962f-31d44f6b3c36"), "Spring", new Guid("3662d5c3-42df-4124-82da-363c9fbe8add") },
                    { new Guid("5cebd2c8-8556-4069-8dd2-60110122e2e1"), "Autumn", new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea") },
                    { new Guid("5d48bae2-b224-4c0e-876a-0fc9299495c3"), "Spring", new Guid("0554d8f5-8438-416f-be71-7664450c0b26") },
                    { new Guid("60e5f2e4-389d-4aec-9615-51858dbcd749"), "Winter", new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71") },
                    { new Guid("61392840-8ff1-40c0-b8a8-91bd0e70a09f"), "Summer", new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad") },
                    { new Guid("62edaadc-95fd-4753-a9c4-3b70317a290b"), "Fall", new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53") },
                    { new Guid("6321c5c7-eade-49bc-a596-3eb27a7596a5"), "Winter", new Guid("f44db049-91fa-4df8-a155-6c2eed2dbb1c") },
                    { new Guid("64f04c6b-624c-4ec9-9f6a-52c7c6e99553"), "Spring", new Guid("46e31437-4562-487e-a16b-347a0168de06") },
                    { new Guid("677da933-3e2e-48e8-ab13-7c35154e181f"), "Spring", new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66") },
                    { new Guid("67c19841-32d1-438e-9242-fae4d0763e56"), "Autumn", new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f") },
                    { new Guid("67db3a3f-69e9-40c4-a486-7eece555224e"), "Autumn", new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f") },
                    { new Guid("6e54b156-91e3-4634-9b4e-707e2125f5b8"), "Winter", new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f") },
                    { new Guid("714df752-5bf7-4d46-a153-8adf45707ee5"), "Fall", new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd") },
                    { new Guid("71c3e67f-24a9-4a6d-87dd-9e7ea05e6fe0"), "Summer", new Guid("6384c424-0892-43ee-af48-7090bb5f38b9") },
                    { new Guid("71cc1050-4b73-4941-bc29-d2234be2b130"), "Autumn", new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023") },
                    { new Guid("725f2006-6db9-4e96-a793-0a1354526297"), "Winter", new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd") },
                    { new Guid("73928a48-03cc-4a40-8e24-67ca7eeb8949"), "Winter", new Guid("bac09f6d-fa8c-4262-9501-992aa8399807") },
                    { new Guid("76aff64a-d842-4143-94e1-c20ff3961242"), "Winter", new Guid("e56e8da8-9477-4da8-88e0-898700185bef") },
                    { new Guid("7d70ab8a-a6a1-4c62-b5f0-2931a53a6389"), "Spring", new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad") },
                    { new Guid("7e9f05f3-9575-4c96-808e-9ac72881be35"), "Winter", new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7") },
                    { new Guid("7eac8032-0a03-4d35-9e07-6dd13e226eb2"), "Summer", new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f") },
                    { new Guid("7f24c8c1-5885-4daa-a0f1-785d9c86a7bf"), "Fall", new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422") },
                    { new Guid("7f810c3b-3b09-4ee5-9582-6bfc677b7aeb"), "Summer", new Guid("aea8f861-0d82-4e98-b348-d230303c0377") },
                    { new Guid("805c3259-f1ad-43d2-920c-6ea1f4323577"), "Fall", new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698") },
                    { new Guid("83355edb-47e4-44a8-a0fa-4c22004bc1dc"), "Autumn", new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4") },
                    { new Guid("83d3f507-06be-4404-9992-190efa44ebd6"), "Fall", new Guid("20bad046-339f-44b6-836b-23c304fe605e") },
                    { new Guid("85fdaf55-a298-45b7-8a7c-0ea2a6d09347"), "Spring", new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f") },
                    { new Guid("8720910a-90ad-4434-9b80-982185e328a1"), "Summer", new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9") },
                    { new Guid("87d1bed7-897a-4ce6-9ee3-ce3fc5118fe8"), "Spring", new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326") },
                    { new Guid("8d227710-4c88-4718-ac1b-588eca4b8922"), "Winter", new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb") },
                    { new Guid("8f00e248-af92-4946-9149-84ce8a5c89c0"), "Autumn", new Guid("f44db049-91fa-4df8-a155-6c2eed2dbb1c") },
                    { new Guid("8f260057-d0d8-4a01-9487-5ec7b551561c"), "Summer", new Guid("bac09f6d-fa8c-4262-9501-992aa8399807") },
                    { new Guid("8f72d392-6940-4c7b-9795-e360af5f3b55"), "Winter", new Guid("31c12708-925e-42f1-8d01-7efda2860860") },
                    { new Guid("93a70a99-2778-43ab-9cde-9131e925db95"), "Spring", new Guid("247825fa-2a6a-43ac-a2c6-074eec278876") },
                    { new Guid("9424e97c-42cd-494d-be1a-c496ec03b322"), "Spring", new Guid("e56e8da8-9477-4da8-88e0-898700185bef") },
                    { new Guid("94663b42-173c-4aa6-9596-16ce02795272"), "Summer", new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9") },
                    { new Guid("963808ec-fb98-4b25-b106-fc12c25752f7"), "Autumn", new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb") },
                    { new Guid("967db575-7675-41c6-84b3-679b391bef0f"), "Autumn", new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7") },
                    { new Guid("96be8860-7860-493f-ae25-668d8acea04b"), "Spring", new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698") },
                    { new Guid("9a97a43a-24a9-4308-bf02-24e18585c8f2"), "Summer", new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023") },
                    { new Guid("9ad3417b-7ed0-4b93-8574-35c81f9ccbc3"), "Winter", new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585") },
                    { new Guid("9d104d6a-2b97-4505-a5ac-7f08fb2a1028"), "Winter", new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422") },
                    { new Guid("9e7bcd00-d4e6-4c6a-9a90-652a3fdaf5e9"), "Summer", new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326") },
                    { new Guid("9e7c2f20-e543-4538-953c-47ea9de6aca7"), "Winter", new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209") },
                    { new Guid("9fa992a7-2c2c-4557-a46f-09b886b26566"), "Autumn", new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326") },
                    { new Guid("9fd51b83-92f3-426f-85ff-9a2082f1d97f"), "Spring", new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c") },
                    { new Guid("9ffa6ea9-9ba8-4680-b28b-e0140b9626da"), "Winter", new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337") },
                    { new Guid("a2663c9f-f0b2-4389-a981-174f4cdc39f0"), "Autumn", new Guid("e02caea8-b235-41c8-879a-d58ef35d8683") },
                    { new Guid("a298227f-59b3-4f9f-98bd-0b914ca4bffd"), "Spring", new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c") },
                    { new Guid("a3bfa764-c07c-496b-b8f7-83f1e5b39c1b"), "Winter", new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231") },
                    { new Guid("a3f9afca-0f2c-42b2-ae1c-a7a962effc02"), "Summer", new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd") },
                    { new Guid("a7bd3257-df63-4324-af0c-3449635b3cc3"), "Autumn", new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4") },
                    { new Guid("a902b3c9-247c-424c-979d-3fdb840567b7"), "Winter", new Guid("1dd25236-d258-40c3-a5f3-5526731750f0") },
                    { new Guid("ac288271-c85b-49ad-8100-b0ba9a306b96"), "Winter", new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66") },
                    { new Guid("accc318b-7557-43a4-a4c3-d5ae9c3e5503"), "Winter", new Guid("247825fa-2a6a-43ac-a2c6-074eec278876") },
                    { new Guid("add47208-ef9d-430c-ab12-9159096b6f55"), "Winter", new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b") },
                    { new Guid("b0085cca-64c8-41b2-ac4f-ef2b1acc20d7"), "Summer", new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2") },
                    { new Guid("b329dd1f-6f84-45ce-867d-dbbd7bf791a0"), "Fall", new Guid("0554d8f5-8438-416f-be71-7664450c0b26") },
                    { new Guid("b4a7b8a0-9ca8-4f54-af12-6207ed05ca80"), "Winter", new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c") },
                    { new Guid("b64f77cc-4800-4b1c-aba2-a0ceef41d083"), "Spring", new Guid("38958eac-d376-460f-b611-064e65a293bf") },
                    { new Guid("b782b311-72bf-4cde-95bc-b18f9f67718a"), "Autumn", new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad") },
                    { new Guid("b8e84b92-a775-424c-8946-c39e684d82e0"), "Fall", new Guid("380563b8-5488-4561-95b7-f5d032278c60") },
                    { new Guid("b9554358-61fe-4681-8221-d09e0226525e"), "Summer", new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66") },
                    { new Guid("bb0b5eb8-0312-4eff-8628-6d66ed817102"), "Winter", new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa") },
                    { new Guid("bd754ab8-6abc-44de-93f3-c35570d39175"), "Summer", new Guid("13036b39-1228-4529-8487-4e644cf0096b") },
                    { new Guid("be7b4ab6-31b4-42d9-a6c8-cb9206a9e8ea"), "Autumn", new Guid("38958eac-d376-460f-b611-064e65a293bf") },
                    { new Guid("c091fd8d-6506-497e-9059-0fb32f1c12b3"), "Spring", new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb") },
                    { new Guid("c26220e0-0d43-4ffa-ac00-cbca4120c5f3"), "Autumn", new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231") },
                    { new Guid("c39eb6cc-eb1d-4fc2-aa5c-90dfdf8b76b2"), "Autumn", new Guid("1dd25236-d258-40c3-a5f3-5526731750f0") },
                    { new Guid("c3d3e553-f0d6-4ee0-b184-84b593f5a968"), "Winter", new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f") },
                    { new Guid("c537cfe3-8843-453b-82b9-ec33632de5e5"), "Autumn", new Guid("bac09f6d-fa8c-4262-9501-992aa8399807") },
                    { new Guid("c6ac6b89-e56d-424b-bd28-480ea3372d57"), "Spring", new Guid("df05c39f-463c-4fbd-b716-e35109510f34") },
                    { new Guid("cb106228-bfb5-4816-a5ba-e1f7280dc52c"), "Summer", new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf") },
                    { new Guid("ccfe57b4-a12e-45c6-9f30-0df78c5ac238"), "Spring", new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4") },
                    { new Guid("d494f091-7797-477a-ad5c-5fb9eb8f85dc"), "Summer", new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422") },
                    { new Guid("d4cff100-4b05-4f5c-89aa-d7d8e7b77368"), "Summer", new Guid("7493af94-8f29-4024-bba9-d930949a216e") },
                    { new Guid("d54be673-0230-4c05-8f88-cea3e993ef3a"), "Autumn", new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa") },
                    { new Guid("d88bf360-9300-4671-b9e6-51c2eecd1847"), "Summer", new Guid("0554d8f5-8438-416f-be71-7664450c0b26") },
                    { new Guid("da0e3166-217f-432f-bd4f-b6ebd830d14a"), "Autumn", new Guid("247825fa-2a6a-43ac-a2c6-074eec278876") },
                    { new Guid("db09f570-5c3e-40db-8f74-14cd8bd41c3f"), "Winter", new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53") },
                    { new Guid("dfd813c4-6a7d-467c-a316-10a0ea119521"), "Autumn", new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d") },
                    { new Guid("e3049e63-fcfc-4e8f-b81d-d39a29d32bf2"), "Spring", new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3") },
                    { new Guid("e37daa4e-3df2-4f81-803c-2230ba91aea0"), "Autumn", new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b") },
                    { new Guid("e4f3a9a2-0be0-48ae-914d-cfc660377bb4"), "Summer", new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0") },
                    { new Guid("ed2e589b-a489-4f5b-9212-721227f93252"), "Autumn", new Guid("e56e8da8-9477-4da8-88e0-898700185bef") },
                    { new Guid("ee738bca-3134-48c2-864d-d9e9d7eb3011"), "Summer", new Guid("1dd25236-d258-40c3-a5f3-5526731750f0") },
                    { new Guid("f0499a3e-4664-4e1c-b763-11d23a9c4ca2"), "Spring", new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea") },
                    { new Guid("f064d449-f54e-456c-87ee-e7aba498a0c1"), "Spring", new Guid("e02caea8-b235-41c8-879a-d58ef35d8683") },
                    { new Guid("f17ed92f-cfc2-4abb-a239-69abfc34750f"), "Summer", new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653") },
                    { new Guid("f1d5f9c9-c84b-4ff9-8461-5fa5d126fd2b"), "Spring", new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955") },
                    { new Guid("f2fc0838-bf39-4a60-a3f0-7f4307b0be9c"), "Winter", new Guid("20bad046-339f-44b6-836b-23c304fe605e") },
                    { new Guid("f8bd1b58-c8ef-44aa-b1e2-cda6f903118a"), "Spring", new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653") },
                    { new Guid("f982e5c2-d4df-44a6-baa1-c236a5c5d447"), "Summer", new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3") },
                    { new Guid("f985c5d9-bece-4311-b3b1-66cc41290704"), "Fall", new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66") },
                    { new Guid("fab28806-0bc5-4b6e-93db-f63594b6e205"), "Winter", new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e") },
                    { new Guid("fcefe37e-dee0-4429-b382-001ca9a91290"), "Spring", new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("022f1e26-5a2b-4d7e-8632-6499b2229075"), "Blue", new Guid("aea8f861-0d82-4e98-b348-d230303c0377") },
                    { new Guid("03188ee2-4dd9-4db5-b07e-41966e5964b7"), "White", new Guid("31c12708-925e-42f1-8d01-7efda2860860") },
                    { new Guid("03c98382-26f6-400c-b43a-5748017e2751"), "White", new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b") },
                    { new Guid("040464ed-e503-4c5a-8c5f-e3727cb2c9e8"), "Orange", new Guid("13036b39-1228-4529-8487-4e644cf0096b") },
                    { new Guid("043ae2c5-8202-4db9-9b5f-e8c4e16af5af"), "Orange", new Guid("6384c424-0892-43ee-af48-7090bb5f38b9") },
                    { new Guid("0467ad66-0fd9-4416-86cb-8d1930901ead"), "Black", new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c") },
                    { new Guid("0743e051-b09f-424c-bd62-198edd85862a"), "Black", new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955") },
                    { new Guid("079ee860-743d-4675-bb93-ea3d7aaef01d"), "Black", new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53") },
                    { new Guid("0904b9e3-2048-490a-bd1b-fb0b7b5e5c46"), "Blue", new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b") },
                    { new Guid("0b7253bd-e244-4479-ad83-15796a3b7480"), "White", new Guid("46e31437-4562-487e-a16b-347a0168de06") },
                    { new Guid("0b887906-8c71-4ff5-bee6-d5ad497edff1"), "Pink", new Guid("7493af94-8f29-4024-bba9-d930949a216e") },
                    { new Guid("0d664836-c057-465d-b4c3-68356cb9a6cc"), "Yellow", new Guid("1dd25236-d258-40c3-a5f3-5526731750f0") },
                    { new Guid("1049272a-e70c-4c32-bdb2-71ecfc6870dd"), "Yellow", new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9") },
                    { new Guid("1153f0f3-bfd8-449c-85e6-5371d99c9f8c"), "Black", new Guid("6384c424-0892-43ee-af48-7090bb5f38b9") },
                    { new Guid("125edc29-1f9e-41a9-b03d-3b85061c38ea"), "White", new Guid("38958eac-d376-460f-b611-064e65a293bf") },
                    { new Guid("1749e146-b8b9-41d9-88af-f1d1cde96ffd"), "White", new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66") },
                    { new Guid("1a9f4987-f97f-48b9-9f37-be37e9a73852"), "Orange", new Guid("df05c39f-463c-4fbd-b716-e35109510f34") },
                    { new Guid("1af0e8b2-8806-4594-823a-3cea083e6c93"), "Blue", new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e") },
                    { new Guid("1b071e71-e1b5-4d46-aa71-67c63e05f11a"), "Black", new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf") },
                    { new Guid("1c2e57f3-8549-4410-95dd-58143ab70306"), "Blue", new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66") },
                    { new Guid("1d08ced4-0911-4747-a76d-29c09756e9e9"), "Orange", new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f") },
                    { new Guid("1f2b8673-0e5c-4e13-baf5-de6aa8d95a5f"), "Pink", new Guid("46e31437-4562-487e-a16b-347a0168de06") },
                    { new Guid("2140a43a-5f9a-4202-82b5-6f1736f6696a"), "Pink", new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3") },
                    { new Guid("2205c7be-26aa-4e3f-bdbc-76e732e7b78e"), "Red", new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b") },
                    { new Guid("22810133-bf0f-4306-ae75-867d4d4862af"), "Blue", new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2") },
                    { new Guid("2441d926-abb9-4349-b5b6-916295b011a1"), "Red", new Guid("38958eac-d376-460f-b611-064e65a293bf") },
                    { new Guid("24728275-6215-4b6b-beec-c7c9a7e468d8"), "Red", new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422") },
                    { new Guid("2637b6a0-31ba-4e11-87d5-ab0dc43137e6"), "Blue", new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422") },
                    { new Guid("26c3cbd3-9de6-43ea-8bcd-c97a8f671774"), "Orange", new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b") },
                    { new Guid("28a40b53-c2e7-499a-9081-c014ff01321f"), "Black", new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023") },
                    { new Guid("2dd45372-dafa-46ce-bdd8-cef4ff6fdb49"), "Blue", new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653") },
                    { new Guid("2e03c1fb-d8bb-46c2-9c94-333162404d1d"), "White", new Guid("e56e8da8-9477-4da8-88e0-898700185bef") },
                    { new Guid("2e8c3a01-1d79-4880-a5da-6890c6738032"), "Blue", new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71") },
                    { new Guid("2ff4fe96-5e96-4afc-81bc-93a67d371bcc"), "Orange", new Guid("380563b8-5488-4561-95b7-f5d032278c60") },
                    { new Guid("345d7871-c624-48df-b961-299e3c92b0ce"), "Red", new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2") },
                    { new Guid("35320d44-809e-44f6-8158-45d9ca30f0e5"), "Black", new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023") },
                    { new Guid("354b176a-22b5-44f7-b2bb-9a48fe594462"), "Orange", new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7") },
                    { new Guid("38c8e3aa-6954-4cce-8a1a-510f29c3574f"), "Pink", new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71") },
                    { new Guid("39fef7e5-c741-491b-9b57-578b3218203e"), "White", new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9") },
                    { new Guid("3ce64eb1-9e81-49f1-9ecf-14724ba14f02"), "Green", new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f") },
                    { new Guid("3e696af7-e3d2-430d-a167-8cb7de2473b0"), "Brown", new Guid("3662d5c3-42df-4124-82da-363c9fbe8add") },
                    { new Guid("3eb6d3d1-c239-410c-bba6-79d556e41d67"), "Purple", new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa") },
                    { new Guid("43b085a6-0f7e-45e4-8d37-883ae7bb09e5"), "Purple", new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231") },
                    { new Guid("44c1b3d0-1606-45ce-b223-d67984d80746"), "Black", new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337") },
                    { new Guid("450ffa13-a9db-4dd3-8cd7-b7e7aa31effb"), "Red", new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4") },
                    { new Guid("4bac9562-ddc1-4555-a6ae-4fd106cebf1a"), "Purple", new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9") },
                    { new Guid("4d7468b9-58ec-455c-8144-42de6abf4c19"), "Orange", new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f") },
                    { new Guid("4dc27c8e-82bc-4508-8d4d-dcfa82b2a10f"), "Blue", new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9") },
                    { new Guid("4eba2ea6-9233-4827-adc9-e382c596ef26"), "Blue", new Guid("1e221695-a730-48eb-99c9-b418ffd45e55") },
                    { new Guid("50eddaa7-77b5-4e36-9d25-fe1ffc0a427c"), "Red", new Guid("20bad046-339f-44b6-836b-23c304fe605e") },
                    { new Guid("514018e1-ee87-4229-a256-8f09dfbcd419"), "Grey", new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66") },
                    { new Guid("56c6f712-2805-409c-8716-18a3251b46ec"), "Green", new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231") },
                    { new Guid("5939a358-14fa-4434-9bc5-c0843422c486"), "Black", new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66") },
                    { new Guid("5f043710-a564-4fb2-9fb3-bdb5e6f6f3a6"), "Orange", new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209") },
                    { new Guid("61237684-fc21-4f20-bcc9-5a381e0f805b"), "Red", new Guid("6384c424-0892-43ee-af48-7090bb5f38b9") },
                    { new Guid("615aafae-5491-4ead-b363-fe1933a01dd8"), "Yellow", new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4") },
                    { new Guid("640a2ef8-43d8-4779-a729-79e3fc3f3aff"), "Green", new Guid("6384c424-0892-43ee-af48-7090bb5f38b9") },
                    { new Guid("65bcf445-3870-48b8-99ab-d86958db287f"), "Purple", new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4") },
                    { new Guid("684fe785-77a1-4d5f-98d1-a94b16f52ba6"), "White", new Guid("6384c424-0892-43ee-af48-7090bb5f38b9") },
                    { new Guid("6e10dac5-7e11-4d4f-92ad-c66193f0348f"), "Black", new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9") },
                    { new Guid("6fd3e08a-e3d5-4e90-aed5-2a6eb454ec55"), "Blue", new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231") },
                    { new Guid("712759a0-19b1-4856-a469-ff8fca282679"), "Red", new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd") },
                    { new Guid("73e8a324-43aa-4441-9d64-e7c2aead41ad"), "Blue", new Guid("46e31437-4562-487e-a16b-347a0168de06") },
                    { new Guid("74b2406b-d462-467e-94f5-8b8d8ec05fa8"), "Yellow", new Guid("1dd25236-d258-40c3-a5f3-5526731750f0") },
                    { new Guid("755a077f-9ce8-455e-a202-b517bdfd3935"), "Black", new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d") },
                    { new Guid("7726b6cc-ee0c-444d-afe0-001a9ff86720"), "Green", new Guid("e02caea8-b235-41c8-879a-d58ef35d8683") },
                    { new Guid("77e9d5ad-41ef-4447-a7cd-7f9bfe4c65b9"), "Purple", new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d") },
                    { new Guid("7809a307-ed7f-4c64-841a-232b87e6a101"), "Black", new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0") },
                    { new Guid("7c5164dd-c8ab-4c5d-bc49-1ef97aee01e7"), "Green", new Guid("e02caea8-b235-41c8-879a-d58ef35d8683") },
                    { new Guid("80c88d70-36b4-477b-92c6-4667a25b05ec"), "Purple", new Guid("7493af94-8f29-4024-bba9-d930949a216e") },
                    { new Guid("829d6e03-082f-4cba-bd5c-2b3eb7a2c4d5"), "Black", new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422") },
                    { new Guid("82d08368-294c-4f92-bb41-e57c991f804e"), "Black", new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9") },
                    { new Guid("84454a11-46ba-4dd8-87ba-1d04bef06a4c"), "Black", new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f") },
                    { new Guid("84cbff95-9749-4c3e-ac47-53dbbc28358c"), "Orange", new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326") },
                    { new Guid("853e1606-f350-41a8-9c97-75d615a84a4e"), "White", new Guid("7493af94-8f29-4024-bba9-d930949a216e") },
                    { new Guid("8617fa52-61f7-41b8-8bbe-86265740dca6"), "Black", new Guid("0554d8f5-8438-416f-be71-7664450c0b26") },
                    { new Guid("8738639a-e6e6-4f62-8a93-923206501bd0"), "Blue", new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea") },
                    { new Guid("87a95184-0dc2-4297-9f6d-97ea51aeb6cb"), "White", new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209") },
                    { new Guid("888d28be-dd9d-4a68-b3c4-ae3b4a89af54"), "White", new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f") },
                    { new Guid("88f86955-175c-4f36-98f6-ca4b45977791"), "Yellow", new Guid("bac09f6d-fa8c-4262-9501-992aa8399807") },
                    { new Guid("8ccfb563-b3f4-493a-a973-49a7cc0a23a4"), "White", new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337") },
                    { new Guid("9103eefb-eb33-411c-9b72-8b4b5ef1b55a"), "Blue", new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023") },
                    { new Guid("92ad1ea2-e555-43a8-a147-e16b7d24dc4b"), "Orange", new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0") },
                    { new Guid("96cc5a86-b304-4df7-996e-f247ef385de0"), "Red", new Guid("e56e8da8-9477-4da8-88e0-898700185bef") },
                    { new Guid("97290eab-5881-414a-9ad6-604b59128dfb"), "Orange", new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb") },
                    { new Guid("9891ce1e-b79c-4ba2-a549-0b9ef58f3bf7"), "Purple", new Guid("380563b8-5488-4561-95b7-f5d032278c60") },
                    { new Guid("9bbbe189-970d-4643-bb75-d8e5709f1278"), "Black", new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad") },
                    { new Guid("9f272b6d-08a8-4c5a-a90f-f61764f10fe5"), "Blue", new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53") },
                    { new Guid("9fefbf71-86dc-4b97-8c5b-248e5215c617"), "Purple", new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653") },
                    { new Guid("a1a281f0-bd0f-48b2-bb5d-e7cebb6b7bfe"), "White", new Guid("aea8f861-0d82-4e98-b348-d230303c0377") },
                    { new Guid("a2ec9fb9-de5a-4a43-aba7-c5ccdab41ed1"), "Black", new Guid("7493af94-8f29-4024-bba9-d930949a216e") },
                    { new Guid("a446af23-0198-410c-a984-152db73d9cce"), "Green", new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b") },
                    { new Guid("aa493247-5830-4bf1-a069-0d2463a61c47"), "Green", new Guid("3662d5c3-42df-4124-82da-363c9fbe8add") },
                    { new Guid("ab3fe220-3bde-45ac-9f49-246153d3aabc"), "Black", new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b") },
                    { new Guid("adc03869-da21-4bf7-ae66-ca6c2eca695f"), "Red", new Guid("bac09f6d-fa8c-4262-9501-992aa8399807") },
                    { new Guid("afbf669b-9c4a-4232-809d-b02240a7c71d"), "White", new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698") },
                    { new Guid("b2fa1737-d19b-47cb-a9d5-85ca96112ea6"), "Red", new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4") },
                    { new Guid("b3201411-e5ce-4d4c-acb0-203682701c5e"), "Blue", new Guid("f44db049-91fa-4df8-a155-6c2eed2dbb1c") },
                    { new Guid("b3bef5ff-3619-4a4d-94c1-ff731914fa79"), "Black", new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9") },
                    { new Guid("b3d795d2-cd0b-4206-aa94-a10d52c71b42"), "Red", new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0") },
                    { new Guid("b5703543-b268-4cf4-94a2-6cce2d536352"), "Black", new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2") },
                    { new Guid("b58f49ac-cb9b-4dba-b0a7-e75ab7faab46"), "Black", new Guid("20bad046-339f-44b6-836b-23c304fe605e") },
                    { new Guid("b5c2ad02-2b02-422e-a1ef-2dea99866bc5"), "Black", new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d") },
                    { new Guid("b7858bfb-c9f4-4546-9598-4fcd5653d31d"), "White", new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2") },
                    { new Guid("bd9c7c94-6787-4738-a5d0-e79a162aa5ee"), "Yellow", new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326") },
                    { new Guid("c61d4ff0-5706-4c34-9820-28b432a835a8"), "Yellow", new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd") },
                    { new Guid("c78163e2-b90e-49d0-a3f4-4ec5a8542607"), "Black", new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585") },
                    { new Guid("c8b3c8be-e443-4da3-8619-de391b219d0a"), "Blue", new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653") },
                    { new Guid("ca219bc4-4637-4641-b56e-90de846d061f"), "Brown", new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698") },
                    { new Guid("ca6a9261-4ea1-4e23-b2f4-17a2e2bf7382"), "Yellow", new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa") },
                    { new Guid("ca948aea-7c09-4bc5-8625-87b4787d15c4"), "Green", new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023") },
                    { new Guid("cb9f0577-b6c9-41c1-bf4a-3730f31a8b99"), "Red", new Guid("bac09f6d-fa8c-4262-9501-992aa8399807") },
                    { new Guid("cf845bd7-94eb-4e79-b2cd-b6f59df46946"), "White", new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422") },
                    { new Guid("d1e0eeea-610d-4d7a-ac9f-3684d0755d37"), "Blue", new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4") },
                    { new Guid("d4b6832d-5403-4958-a319-d0377f3c2dad"), "Brown", new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337") },
                    { new Guid("d924a538-8835-4d52-877a-18c3be2a70aa"), "Blue", new Guid("6384c424-0892-43ee-af48-7090bb5f38b9") },
                    { new Guid("d9cc8367-d743-4da6-97e2-0dd958aa00bd"), "White", new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c") },
                    { new Guid("db838e51-a73a-48ad-a92b-b12e3654f96f"), "Yellow", new Guid("46e31437-4562-487e-a16b-347a0168de06") },
                    { new Guid("dc16f59a-2bbe-4166-b15c-3d0e1a3e42ab"), "Orange", new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d") },
                    { new Guid("dc73dd7b-c3d1-4081-8d90-fe284b8847c0"), "Pink", new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b") },
                    { new Guid("e0ec2bc5-aa66-43cb-920c-96d4ab8ffae1"), "Blue", new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e") },
                    { new Guid("e202b49b-41c7-4338-ad09-3d3a6849ca6d"), "Black", new Guid("13036b39-1228-4529-8487-4e644cf0096b") },
                    { new Guid("e36602b1-678c-44ce-92e3-66d433a4c0a3"), "Black", new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f") },
                    { new Guid("e49bce7a-dc46-4137-88dd-ed0168c27672"), "Green", new Guid("df05c39f-463c-4fbd-b716-e35109510f34") },
                    { new Guid("e84be307-3383-405c-831e-d6a10630d9c7"), "Pink", new Guid("aea8f861-0d82-4e98-b348-d230303c0377") },
                    { new Guid("e88298c3-effb-4804-82d9-701f0330fc91"), "Black", new Guid("aea8f861-0d82-4e98-b348-d230303c0377") },
                    { new Guid("ea59d041-feae-4dce-9465-66396efc255f"), "Blue", new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c") },
                    { new Guid("f0012d8b-17a6-43f6-a5b4-f96e0fccad2d"), "Orange", new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955") },
                    { new Guid("f0935d75-d433-4c6e-884d-3a4655a28952"), "White", new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9") },
                    { new Guid("f1bfec7a-6d88-4b7f-998b-56191ea4ef97"), "Yellow", new Guid("247825fa-2a6a-43ac-a2c6-074eec278876") },
                    { new Guid("f27d8e43-de71-4e6f-9883-fb0d4662b150"), "Black", new Guid("46e31437-4562-487e-a16b-347a0168de06") },
                    { new Guid("f92da63b-b597-4a7d-8c5d-385e1b37cd25"), "Green", new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53") },
                    { new Guid("f9ed069b-3fd5-497e-ac7a-75b5f76cdd4a"), "Yellow", new Guid("df05c39f-463c-4fbd-b716-e35109510f34") },
                    { new Guid("fa71e1ad-bbf3-4b16-a5fa-303ca48a94a6"), "Red", new Guid("247825fa-2a6a-43ac-a2c6-074eec278876") },
                    { new Guid("fb0e0843-9bdd-49ae-8133-b595681fa1a3"), "White", new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("0189ccb2-472e-4391-8bc8-48a1696fb58c"), 5, new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3"), 42 },
                    { new Guid("03b96b05-d696-4824-bef1-684e82e92168"), 58, new Guid("7493af94-8f29-4024-bba9-d930949a216e"), 43 },
                    { new Guid("04a3034a-5319-4237-bbb2-5c91d097c164"), 16, new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad"), 39 },
                    { new Guid("0515235d-8713-4dfe-9417-5ada6e766bbd"), 12, new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c"), 38 },
                    { new Guid("05dfce7a-2b7d-4ff0-8fa2-8b4e490b7a5f"), 10, new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698"), 43 },
                    { new Guid("05ed6f26-8bcd-461b-8561-1fb237ff83fc"), 57, new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f"), 41 },
                    { new Guid("0727815d-68e3-499d-aea4-26bdad453ec4"), 142, new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c"), 39 },
                    { new Guid("07d649fd-fb6f-4450-8a5e-2f79482a98c7"), 133, new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9"), 40 },
                    { new Guid("0a79063f-328a-432a-8efa-2d190bdabc70"), 11, new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698"), 40 },
                    { new Guid("0aff9de6-8ddd-49df-a992-219787d2bc2e"), 130, new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698"), 41 },
                    { new Guid("0b1691ba-8f20-4b65-9c4e-90354cb6ab90"), 66, new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71"), 44 },
                    { new Guid("0bb1fe42-3ff0-4101-8248-27f5d4b856b0"), 67, new Guid("aea8f861-0d82-4e98-b348-d230303c0377"), 43 },
                    { new Guid("0bfd9a9c-7bca-4d59-a30e-932752f1219e"), 6, new Guid("1e221695-a730-48eb-99c9-b418ffd45e55"), 46 },
                    { new Guid("0dedd84c-bee6-4040-b56c-16a0f2c65adc"), 19, new Guid("f44db049-91fa-4df8-a155-6c2eed2dbb1c"), 44 },
                    { new Guid("1211f8bb-4510-4842-8542-197dcb2f24ec"), 5, new Guid("38958eac-d376-460f-b611-064e65a293bf"), 44 },
                    { new Guid("13c62f61-ec0e-481c-8d78-27ae4f4a9a90"), 62, new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71"), 41 },
                    { new Guid("1601fa30-3b92-40a3-a9c2-0ec38830df20"), 19, new Guid("7493af94-8f29-4024-bba9-d930949a216e"), 44 },
                    { new Guid("163cd4bd-fc07-4dd3-a05a-3b66ce4ca931"), 13, new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209"), 40 },
                    { new Guid("164ab377-163d-46a1-99c0-be340850f4b4"), 90, new Guid("13036b39-1228-4529-8487-4e644cf0096b"), 38 },
                    { new Guid("173feb07-8994-40f4-8e9d-ec9eb0c8fb6a"), 8, new Guid("46e31437-4562-487e-a16b-347a0168de06"), 43 },
                    { new Guid("176c3e16-8e48-4cea-b98e-53aa9f504786"), 109, new Guid("6384c424-0892-43ee-af48-7090bb5f38b9"), 43 },
                    { new Guid("1790c492-4aaf-41ef-b95c-78cf7c92628c"), 11, new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326"), 42 },
                    { new Guid("185f0d02-8879-4901-bfa6-d4f5cf9c9a76"), 8, new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3"), 38 },
                    { new Guid("19b79411-e9a3-498a-bf78-5387aa467d74"), 0, new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4"), 40 },
                    { new Guid("1a44577b-7c72-4466-8c58-7763171f3c27"), 27, new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb"), 41 },
                    { new Guid("1a4bc284-ea1d-471e-814b-692bb0dc45cd"), 51, new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e"), 41 },
                    { new Guid("1a92774f-5a96-49b0-a391-3a3765d87c5c"), 110, new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71"), 42 },
                    { new Guid("1afea1b4-9f28-4eac-ad4f-74158a2dbb6a"), 14, new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d"), 44 },
                    { new Guid("1b52dac3-741f-44ee-b5eb-e7c63d8294a5"), 0, new Guid("46e31437-4562-487e-a16b-347a0168de06"), 46 },
                    { new Guid("1ba4ec99-a973-47ff-88e5-417a4c8ed243"), 47, new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea"), 41 },
                    { new Guid("1c72401b-e8a7-439f-9c2e-1b5b97c8340c"), 53, new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7"), 38 },
                    { new Guid("1cbbc27e-6541-4342-944a-db8d3779e43f"), 93, new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3"), 41 },
                    { new Guid("1cc5bc38-038c-4be6-80bd-cf1e2429a086"), 39, new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa"), 44 },
                    { new Guid("1d03e49a-00d0-436b-89b2-50b2a08fbe02"), 107, new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f"), 39 },
                    { new Guid("1d4af7f7-7f35-4881-9fd6-7304b55fa67e"), 105, new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422"), 42 },
                    { new Guid("1d82e8b4-1450-4a7b-83a9-cfe42ea6adb6"), 42, new Guid("1dd25236-d258-40c3-a5f3-5526731750f0"), 39 },
                    { new Guid("1e0c52ad-4c74-4a56-bb23-d397e353cd0e"), 10, new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4"), 42 },
                    { new Guid("1ed0bd80-4779-4b51-b3da-5a5588c6a318"), 36, new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea"), 42 },
                    { new Guid("201cef25-9c6e-44bb-a1ec-7a3e53daa744"), 26, new Guid("df05c39f-463c-4fbd-b716-e35109510f34"), 40 },
                    { new Guid("20a900ff-1ae2-4b82-b143-8673231630bc"), 16, new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4"), 37 },
                    { new Guid("20c50c26-43fe-4b21-be41-2e32904eacdd"), 99, new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337"), 41 },
                    { new Guid("2144e2dd-bff3-47a8-a7db-ef93181bf693"), 140, new Guid("380563b8-5488-4561-95b7-f5d032278c60"), 44 },
                    { new Guid("2152eba9-8361-4b74-8c49-2c527160b0c1"), 32, new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2"), 41 },
                    { new Guid("222a3318-029b-421f-957c-b7ad663d3b5e"), 125, new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4"), 42 },
                    { new Guid("23e416f4-a350-4579-be18-186c97397dc1"), 136, new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9"), 42 },
                    { new Guid("24044bf0-eb6f-4ce3-8cf6-3b9cd8be55b9"), 131, new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2"), 43 },
                    { new Guid("2456f315-2253-4c24-bdd2-4cfa9f43d97b"), 47, new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea"), 40 },
                    { new Guid("25c2807e-f953-404e-8859-993f41ac2745"), 148, new Guid("31c12708-925e-42f1-8d01-7efda2860860"), 45 },
                    { new Guid("262b7bfc-00b2-4b2a-995a-d8bdb03c3a4a"), 8, new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b"), 41 },
                    { new Guid("26d1125e-468f-43e9-915f-b1af7baeed03"), 85, new Guid("20bad046-339f-44b6-836b-23c304fe605e"), 39 },
                    { new Guid("28edfa3d-e807-4a8e-97df-81285c574d2b"), 97, new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf"), 40 },
                    { new Guid("28fa42cf-8a17-45f1-a664-322a83035928"), 25, new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209"), 39 },
                    { new Guid("2b5abe15-917f-444a-a6ac-e9034f820657"), 49, new Guid("bac09f6d-fa8c-4262-9501-992aa8399807"), 42 },
                    { new Guid("2cb84902-6385-4bd8-8978-fdf02dc6010f"), 119, new Guid("aea8f861-0d82-4e98-b348-d230303c0377"), 41 },
                    { new Guid("2ce8b7eb-56ee-45f2-b7e7-2f6a30ea505b"), 49, new Guid("df05c39f-463c-4fbd-b716-e35109510f34"), 39 },
                    { new Guid("2d67b943-a8b9-4c56-af43-02531a9ee2eb"), 118, new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b"), 43 },
                    { new Guid("2d746d66-e731-4caa-abb4-fc5a29d3c885"), 48, new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad"), 38 },
                    { new Guid("2ddebd50-b64d-403b-9c41-31a299476ffc"), 86, new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c"), 42 },
                    { new Guid("2e083af9-9156-4af2-9545-a7359946a79e"), 50, new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0"), 38 },
                    { new Guid("2ecab583-c211-4804-8a9e-ef71fdce9e65"), 25, new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa"), 41 },
                    { new Guid("31c7d0aa-e052-436f-a8e4-4fd9c4436444"), 6, new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf"), 37 },
                    { new Guid("31f32a61-7367-476c-b3f3-1bda79f86fe7"), 147, new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66"), 39 },
                    { new Guid("320c2aae-fa5d-431a-89cc-36b909a30a00"), 14, new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231"), 45 },
                    { new Guid("32686d80-3600-4f99-b138-3ba24367fb64"), 57, new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c"), 40 },
                    { new Guid("3269c631-b845-472e-9222-70fff6261b8e"), 119, new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585"), 45 },
                    { new Guid("3289b140-ad36-476c-a23b-1e35ad8d168b"), 38, new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d"), 45 },
                    { new Guid("37928aa4-ae04-4877-b4ed-af02f5d36d93"), 37, new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad"), 41 },
                    { new Guid("384c2e68-5359-457a-84cf-56784c66a6a2"), 45, new Guid("df05c39f-463c-4fbd-b716-e35109510f34"), 41 },
                    { new Guid("39881384-7530-4b4d-9965-f481bcace615"), 50, new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d"), 46 },
                    { new Guid("39926a52-6d70-41e2-bfde-dd539614b74d"), 45, new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231"), 42 },
                    { new Guid("3a5168c3-a095-451b-b7a2-cb8410d14e18"), 3, new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231"), 44 },
                    { new Guid("3d0e9e7a-8bb2-480f-92fb-8513f94d1bbb"), 75, new Guid("3662d5c3-42df-4124-82da-363c9fbe8add"), 39 },
                    { new Guid("3d510460-0411-46d1-b295-2a1647b99852"), 31, new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d"), 42 },
                    { new Guid("3d74760c-1842-43b4-b1f9-beaa049668a6"), 30, new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7"), 39 },
                    { new Guid("3d79e278-cc36-466f-b234-1291b9257063"), 48, new Guid("247825fa-2a6a-43ac-a2c6-074eec278876"), 39 },
                    { new Guid("3f2e0b36-864e-4e34-9dd4-c737f7edcddf"), 25, new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023"), 43 },
                    { new Guid("449c3400-d0fd-4d91-9480-45dd2a8181ef"), 25, new Guid("e56e8da8-9477-4da8-88e0-898700185bef"), 42 },
                    { new Guid("44b676da-e817-47b5-9de8-ca87caadd986"), 31, new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f"), 38 },
                    { new Guid("451c3172-4f1a-415a-b261-4b76442dc133"), 36, new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9"), 40 },
                    { new Guid("45652d59-2a86-4adc-8b40-1adab0e1ca05"), 45, new Guid("13036b39-1228-4529-8487-4e644cf0096b"), 41 },
                    { new Guid("47365cf3-0563-4a4b-a8eb-bbc1d685d861"), 28, new Guid("f44db049-91fa-4df8-a155-6c2eed2dbb1c"), 42 },
                    { new Guid("481003a3-480f-499f-9a98-b7bbecd984d8"), 13, new Guid("aea8f861-0d82-4e98-b348-d230303c0377"), 44 },
                    { new Guid("49fad637-8ec3-405e-9c3b-f7667ac47e3f"), 10, new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326"), 44 },
                    { new Guid("4be5f41b-f840-4b9e-85fb-96f5079f3ca4"), 55, new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9"), 39 },
                    { new Guid("4da495f9-4325-4e09-8c40-d179512ec4d1"), 45, new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd"), 42 },
                    { new Guid("4e9edb63-2ed0-4b8e-9f3c-8e5eacf31aa5"), 54, new Guid("247825fa-2a6a-43ac-a2c6-074eec278876"), 40 },
                    { new Guid("4f8fcd6c-4382-4173-b968-dbf49dd9f6d5"), 50, new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d"), 43 },
                    { new Guid("4fe1ab27-f763-4009-8131-e462d4eff04f"), 24, new Guid("247825fa-2a6a-43ac-a2c6-074eec278876"), 41 },
                    { new Guid("50e1a14e-a0f0-4af3-8d12-5b86b8d0f02c"), 83, new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd"), 45 },
                    { new Guid("52438ef8-8957-476b-8ae5-7c70917f5a0d"), 49, new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209"), 38 },
                    { new Guid("52b351fd-1cdb-4560-a274-ce851fadf47d"), 8, new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955"), 41 },
                    { new Guid("541a7c49-65bc-4e30-bbc0-bdc7460a14d7"), 147, new Guid("20bad046-339f-44b6-836b-23c304fe605e"), 42 },
                    { new Guid("54715943-cf0c-4348-aa50-e240d0e11a97"), 19, new Guid("38958eac-d376-460f-b611-064e65a293bf"), 43 },
                    { new Guid("54d116e5-dd91-43a2-95d5-43ee8b34f311"), 25, new Guid("6384c424-0892-43ee-af48-7090bb5f38b9"), 45 },
                    { new Guid("54de5063-8102-4b91-ae06-184198ef33a3"), 43, new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f"), 40 },
                    { new Guid("55ba8097-cd26-4494-b96a-6d5c36ae9195"), 10, new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4"), 38 },
                    { new Guid("561288d4-17e2-4aa2-bce4-91ab9446f918"), 31, new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9"), 38 },
                    { new Guid("57059738-17c0-4d5d-9229-46acf4985866"), 17, new Guid("87d76fa7-cb99-4c4c-b6c0-57c6f2d36231"), 43 },
                    { new Guid("5817c586-d568-4601-96b9-8b5a57602add"), 1, new Guid("bac09f6d-fa8c-4262-9501-992aa8399807"), 43 },
                    { new Guid("5a31a7c3-ba4a-443d-ad7c-34867f49dfe2"), 107, new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422"), 43 },
                    { new Guid("5a571bcd-ce16-4c02-abbf-28e1be29afe6"), 46, new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0"), 41 },
                    { new Guid("5a6865cc-8f2b-41d7-96ef-7cd2316fe80e"), 49, new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b"), 43 },
                    { new Guid("5b567dae-2347-419b-bcba-a7313d1dfef3"), 48, new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337"), 42 },
                    { new Guid("5b5e6210-3dd8-4607-9bf4-0a1714841311"), 46, new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653"), 41 },
                    { new Guid("5b6a1011-bc68-49fa-942e-c9f39ea8ed03"), 111, new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd"), 46 },
                    { new Guid("5c152d2d-b5f6-40fe-a985-f67b2b5e7ce5"), 44, new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb"), 40 },
                    { new Guid("5c1e5483-5c56-4f81-bb17-ca4ea0ee8d3e"), 37, new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7"), 41 },
                    { new Guid("5ca10898-5321-4094-9741-6619f5b16193"), 17, new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337"), 45 },
                    { new Guid("5eef5dd2-75f5-4fe1-a967-9d134531df96"), 0, new Guid("8123cf16-4e49-48ba-9db3-5d1c5fd378ad"), 40 },
                    { new Guid("5fbf52f7-68bd-4331-97a6-2f55b82964d0"), 29, new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c"), 40 },
                    { new Guid("60479c26-2347-41e6-bad0-6e36ef5eb66b"), 15, new Guid("1dd25236-d258-40c3-a5f3-5526731750f0"), 38 },
                    { new Guid("6226fa04-4a63-49a2-9f6e-50798f4285b5"), 9, new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f"), 41 },
                    { new Guid("62e929e2-67f2-4421-8021-3e7e38363aad"), 29, new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955"), 42 },
                    { new Guid("6375420a-9c7d-406f-9322-f081c0d38547"), 42, new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653"), 40 },
                    { new Guid("66f6be1a-83cf-452c-957b-eeb45b0f0fd2"), 53, new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023"), 41 },
                    { new Guid("676d4116-df21-4744-a6ea-d5bcb5acd25e"), 47, new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955"), 40 },
                    { new Guid("67c37fef-c6bc-40a2-9d09-acbd0b1d33aa"), 15, new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9"), 37 },
                    { new Guid("68f941b6-80d4-4f0d-aa60-51ba54f3e56b"), 52, new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d"), 44 },
                    { new Guid("6b0095e3-ab19-46f3-9c84-868570b529c0"), 7, new Guid("8cb349ad-f6ce-4447-be07-c1d9fada0209"), 41 },
                    { new Guid("6df513d1-c714-4011-8572-d1fcea473abc"), 35, new Guid("7493af94-8f29-4024-bba9-d930949a216e"), 42 },
                    { new Guid("6e6a6f63-c59d-4b31-acba-bee6188b8fa2"), 42, new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d"), 42 },
                    { new Guid("74ac0b4e-29fa-412f-bf72-1d9fa4d14223"), 103, new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337"), 43 },
                    { new Guid("79d48b8a-4cad-491a-9f78-0bee1f6c065d"), 35, new Guid("46e31437-4562-487e-a16b-347a0168de06"), 45 },
                    { new Guid("7a3dcfb0-86e6-44f3-9de4-f2d9025eef25"), 131, new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3"), 40 },
                    { new Guid("7b46c097-b266-4fe1-8c42-ea6af81bbb36"), 62, new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4"), 44 },
                    { new Guid("7b9f8f14-2f3e-49c1-99c9-da1cecd46521"), 38, new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b"), 39 },
                    { new Guid("7c8d504e-8c1b-4d39-8238-a2dc44a69774"), 19, new Guid("e02caea8-b235-41c8-879a-d58ef35d8683"), 42 },
                    { new Guid("7dd44086-a77f-4aba-a922-2d85601286e5"), 5, new Guid("bac09f6d-fa8c-4262-9501-992aa8399807"), 41 },
                    { new Guid("7ef253e6-f502-4bdc-8e3a-6d6d49266de8"), 61, new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9"), 41 },
                    { new Guid("808f75f0-178f-47aa-8559-9dba17cd3f9a"), 3, new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c"), 41 },
                    { new Guid("8145428b-64e1-4b36-96dd-ee860c2009eb"), 3, new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0"), 39 },
                    { new Guid("8161b425-2c37-457a-81ca-be8312b82f8a"), 110, new Guid("20bad046-339f-44b6-836b-23c304fe605e"), 41 },
                    { new Guid("81ba6e1a-1881-45a5-9948-7d4f390c01c0"), 73, new Guid("380563b8-5488-4561-95b7-f5d032278c60"), 43 },
                    { new Guid("82422fad-bacc-431a-bad0-5b0218c6201e"), 79, new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd"), 43 },
                    { new Guid("8518d743-0c38-4796-b637-3274f8370453"), 85, new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f"), 37 },
                    { new Guid("85de278f-b556-4eb3-8435-1a3afa980023"), 139, new Guid("0fefd3f6-2119-4730-a58f-394ee3c5e8e9"), 42 },
                    { new Guid("861f8cda-41c5-4101-bbe4-cdc73dd5bff0"), 30, new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa"), 40 },
                    { new Guid("87d7500f-d1d4-4789-9fdf-6554efd9e71b"), 29, new Guid("e56e8da8-9477-4da8-88e0-898700185bef"), 39 },
                    { new Guid("881d960c-0eb5-4c01-b5c7-86afddb210cc"), 29, new Guid("6384c424-0892-43ee-af48-7090bb5f38b9"), 44 },
                    { new Guid("88483d7d-539b-4bb7-b2e4-943ccac0d55c"), 27, new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e"), 43 },
                    { new Guid("88ddd092-4524-4dc5-a1da-be084340ed2c"), 27, new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e"), 42 },
                    { new Guid("8982140f-7097-4d51-b62b-bd6353f64546"), 8, new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4"), 38 },
                    { new Guid("89bd759f-fd4f-4347-9d78-3f4169827fc9"), 101, new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66"), 37 },
                    { new Guid("8ad81155-187d-4d7f-a0bd-bd39960564c7"), 95, new Guid("0554d8f5-8438-416f-be71-7664450c0b26"), 45 },
                    { new Guid("8c1ba064-c937-499a-baec-c9552282d9cf"), 14, new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d"), 41 },
                    { new Guid("8e511a71-6b87-46d8-9163-80d9b3f6d024"), 71, new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66"), 38 },
                    { new Guid("8f92f149-616c-442a-b7d2-3133dabd8dd6"), 17, new Guid("1dd25236-d258-40c3-a5f3-5526731750f0"), 40 },
                    { new Guid("901a8068-19ff-411f-b076-f471f95e533c"), 24, new Guid("38958eac-d376-460f-b611-064e65a293bf"), 41 },
                    { new Guid("923bca87-c424-4dc2-9649-28482037d01a"), 48, new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f"), 41 },
                    { new Guid("932ed1f6-e493-4a1f-b751-9beb20469969"), 3, new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585"), 46 },
                    { new Guid("9352398c-20ce-49c3-8acd-1fc698a23d75"), 29, new Guid("0e84c6c1-8ab9-4b8a-80e7-9f1b1bf3a3d4"), 39 },
                    { new Guid("95c0c39c-febf-4cd4-98ad-ad9ad697ac5b"), 29, new Guid("e56e8da8-9477-4da8-88e0-898700185bef"), 40 },
                    { new Guid("95c39398-29cf-47fe-973d-a989385b2890"), 80, new Guid("13036b39-1228-4529-8487-4e644cf0096b"), 42 },
                    { new Guid("95d7cb97-9721-4e98-8ea7-4139f478c62f"), 15, new Guid("e02caea8-b235-41c8-879a-d58ef35d8683"), 41 },
                    { new Guid("96009b4a-2132-4e1c-8249-1de4974af420"), 21, new Guid("f44db049-91fa-4df8-a155-6c2eed2dbb1c"), 45 },
                    { new Guid("96039e15-e09c-4bbc-b055-e25aae04b6e1"), 17, new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326"), 43 },
                    { new Guid("9749ddf7-bd0e-45b7-a565-43a61393b20a"), 33, new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4"), 39 },
                    { new Guid("99fcdab3-8939-488a-88c9-f0b8300da35f"), 101, new Guid("1e221695-a730-48eb-99c9-b418ffd45e55"), 42 },
                    { new Guid("9b95309c-3085-4bcf-9a31-1406a3dbc3fe"), 8, new Guid("f8011f11-730e-4dfe-819c-e9b52b32a326"), 41 },
                    { new Guid("9c86d0b9-20b9-4107-b04c-6a9c0b376078"), 23, new Guid("1dd25236-d258-40c3-a5f3-5526731750f0"), 37 },
                    { new Guid("9d332e7d-6bef-42c7-b3e3-6a0c277be130"), 25, new Guid("f44db049-91fa-4df8-a155-6c2eed2dbb1c"), 43 },
                    { new Guid("a02def55-e7fe-4c9b-ace9-0a450246d52a"), 32, new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b"), 42 },
                    { new Guid("a050ffd3-d332-41ca-987d-f163818ddeed"), 24, new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7"), 42 },
                    { new Guid("a369c8d3-ec2c-4fc7-a9f6-5e1dea312df8"), 146, new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71"), 43 },
                    { new Guid("a42ef37a-a190-4ef6-a2f3-d233c8ca3945"), 47, new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653"), 42 },
                    { new Guid("a4fec41a-dd4f-4fbb-a1eb-93dc91e97f9b"), 36, new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53"), 41 },
                    { new Guid("a5824e7a-7c9a-4eab-aa2d-974519bd1852"), 36, new Guid("3fee6520-4560-4c0e-bf44-4af2614d9653"), 39 },
                    { new Guid("a683f171-3853-4cc7-8df1-417a0e12425f"), 5, new Guid("3662d5c3-42df-4124-82da-363c9fbe8add"), 41 },
                    { new Guid("a7d88880-1b85-4b19-bc49-57f3ea403d57"), 0, new Guid("13036b39-1228-4529-8487-4e644cf0096b"), 39 },
                    { new Guid("a813522e-3af5-425a-b129-018d434636ee"), 0, new Guid("bac09f6d-fa8c-4262-9501-992aa8399807"), 40 },
                    { new Guid("a8995521-b472-4d0d-9c50-f6699fb39dd9"), 7, new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53"), 40 },
                    { new Guid("a8f2b1ef-ff00-43a3-b03c-c3bf97e84652"), 34, new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4"), 41 },
                    { new Guid("a9899258-10d3-46dd-99e6-f8718f793bb1"), 139, new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b"), 41 },
                    { new Guid("a9c623d2-1f5e-4ade-8cc7-6236813d8d1f"), 22, new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f"), 40 },
                    { new Guid("aa144038-b554-47f4-96bc-6a21d8192570"), 8, new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e"), 44 },
                    { new Guid("aa63ac39-12a3-4827-8a76-f237fc0f1a4b"), 88, new Guid("1b5c0eab-3b20-43ef-b125-67962309c72b"), 40 },
                    { new Guid("aaa9d7c3-c8c3-4d2f-b720-a6f2c0d0e533"), 118, new Guid("3662d5c3-42df-4124-82da-363c9fbe8add"), 42 },
                    { new Guid("abc145b0-5aca-4e3c-9402-1c92a2a6a8f3"), 19, new Guid("31c12708-925e-42f1-8d01-7efda2860860"), 42 },
                    { new Guid("acd107e3-82d9-4b13-9e02-dd50b8cea891"), 17, new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea"), 44 },
                    { new Guid("ad6efc2d-2f20-46da-925e-5350aaacf1ff"), 32, new Guid("107337ff-35d6-41b3-a1fd-1aa7c5b2d955"), 39 },
                    { new Guid("b018f539-fb63-4004-a871-00730d8da564"), 49, new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585"), 44 },
                    { new Guid("b0a4962f-5248-4a30-b627-96976855f951"), 43, new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb"), 43 },
                    { new Guid("b1b460d7-feee-4495-b337-603fea263026"), 147, new Guid("6384c424-0892-43ee-af48-7090bb5f38b9"), 41 },
                    { new Guid("b1e78dc9-53e6-47fb-b5d1-81ffb112a4f3"), 0, new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf"), 39 },
                    { new Guid("b258d5ac-eeb4-473e-a46d-e293252aaaa1"), 0, new Guid("1dd25236-d258-40c3-a5f3-5526731750f0"), 41 },
                    { new Guid("b30de794-d13f-403f-be10-14b6ce07d85b"), 4, new Guid("0554d8f5-8438-416f-be71-7664450c0b26"), 46 },
                    { new Guid("b3c817cf-5e7a-4709-8121-3c883d4b41b8"), 5, new Guid("d7aede69-dbd2-4727-94f6-5f2f2221905e"), 45 },
                    { new Guid("b41629f1-cd63-4aef-8ef2-f048ef789fbf"), 119, new Guid("1e221695-a730-48eb-99c9-b418ffd45e55"), 44 },
                    { new Guid("b6b97fba-d838-4373-a79b-00af36bad1fc"), 30, new Guid("1a99d83d-0584-4c64-9255-e6543b7b19eb"), 42 },
                    { new Guid("b747d457-6579-4054-b27d-4569b6649bee"), 60, new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2"), 44 },
                    { new Guid("b7d642ad-58be-419e-8b80-29cc5d912aff"), 21, new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585"), 42 },
                    { new Guid("b8697120-18ae-4f25-b144-5199e31103c9"), 119, new Guid("2f31d075-b20d-4c4a-94a5-5a649a76e698"), 42 },
                    { new Guid("b9d786bb-4730-4726-8214-7f13433cba47"), 46, new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f"), 39 },
                    { new Guid("b9db47ee-d45b-4f6a-b302-8cf19c2031ae"), 12, new Guid("6384c424-0892-43ee-af48-7090bb5f38b9"), 42 },
                    { new Guid("bbbe59f4-42c7-4c83-a4c9-75e143618024"), 145, new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53"), 42 },
                    { new Guid("bc4ee15f-c8cb-4e30-8e39-f21deb70a740"), 135, new Guid("82ea6ca2-348e-407b-b5dd-6afbf6716585"), 43 },
                    { new Guid("bfe3737d-b269-4e8b-94b9-20a14c19c7d1"), 140, new Guid("1e221695-a730-48eb-99c9-b418ffd45e55"), 43 },
                    { new Guid("c3fb20ce-2017-4eb9-bf08-e7622288a00f"), 18, new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4"), 46 },
                    { new Guid("c431739c-43fe-41a0-aa47-bbdc34a557fe"), 26, new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f"), 40 },
                    { new Guid("c617870a-801f-47a2-896f-95e70c02491b"), 25, new Guid("e56e8da8-9477-4da8-88e0-898700185bef"), 41 },
                    { new Guid("c6c39fea-4110-4223-9dba-f32ec6c355fe"), 5, new Guid("df05c39f-463c-4fbd-b716-e35109510f34"), 42 },
                    { new Guid("c70370cc-7a53-4653-96a6-eaa48b230123"), 3, new Guid("38958eac-d376-460f-b611-064e65a293bf"), 42 },
                    { new Guid("c75ca4b1-8077-4697-8c87-a18ee737a0d1"), 4, new Guid("1e221695-a730-48eb-99c9-b418ffd45e55"), 45 },
                    { new Guid("c7c8eff3-44f8-4072-923f-9374b16d80d8"), 29, new Guid("9d0991b0-83f4-4d42-b07c-99f5ac9f0f66"), 40 },
                    { new Guid("c81d96f8-04da-436b-a5cd-8f7564f3e4d2"), 119, new Guid("380563b8-5488-4561-95b7-f5d032278c60"), 41 },
                    { new Guid("c84607ff-9f64-4b7c-9432-eb66b02d3b58"), 59, new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4"), 45 },
                    { new Guid("c869befb-6bd5-454b-88bb-2a340898d9bf"), 27, new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa"), 43 },
                    { new Guid("c8817675-1d2e-44db-938a-ec19eccb08c3"), 29, new Guid("28f2c8ea-ce14-440b-bd57-d2bc936fa9fa"), 42 },
                    { new Guid("c9c5e4bc-a813-42d4-8ef7-39a9a91fb894"), 44, new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f"), 38 },
                    { new Guid("ca6f5c22-fa29-4024-8c19-838ee97fc87d"), 40, new Guid("972ab427-0a7e-45e8-a42e-65a6a91bd2f7"), 40 },
                    { new Guid("caf10373-8fa9-4389-b20f-3630eae2af59"), 50, new Guid("9ff35288-5c9f-44d4-8a82-be5bfb9670bd"), 44 },
                    { new Guid("cb8a4ee3-9249-4deb-b4c3-0f0444fef620"), 14, new Guid("5d3fbfdb-a5b8-4d30-b6b3-98f7f2dbaa9d"), 40 },
                    { new Guid("cce7fc61-bb05-4ff1-b644-5af5a136308b"), 25, new Guid("1076bfd1-d62d-44b6-b3c5-01f5bd1bbf8f"), 37 },
                    { new Guid("cd7a38d1-7770-4e12-a330-bfa3216dd20a"), 72, new Guid("46e31437-4562-487e-a16b-347a0168de06"), 42 },
                    { new Guid("cfd32557-bc26-482a-bd3a-dae5c5277b51"), 15, new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2"), 42 },
                    { new Guid("cff88d0d-34a6-4cdd-9684-6a8185696a93"), 45, new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023"), 42 },
                    { new Guid("d0844bcb-cb54-4052-875e-46b6df9352fe"), 55, new Guid("3662d5c3-42df-4124-82da-363c9fbe8add"), 40 },
                    { new Guid("d14815f5-1876-416e-a619-b863c565f5ff"), 28, new Guid("6235ade4-cc2c-404a-ac7b-9438f292613f"), 39 },
                    { new Guid("d1ba031a-685e-40d5-98aa-820753baa712"), 42, new Guid("9e14953b-54f0-4c2d-b62e-c2349fe89fa0"), 40 },
                    { new Guid("d4247b0e-75a3-487a-a1ae-6547a8758a5d"), 129, new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422"), 41 },
                    { new Guid("d4638ba4-e668-4b00-a894-4dc69d5bda83"), 65, new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53"), 43 },
                    { new Guid("d750a759-56b1-40b4-b10d-2fcc833411e6"), 45, new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b"), 44 },
                    { new Guid("d841bc71-e5f5-4a1a-aa8a-e3e5dac40561"), 139, new Guid("46e31437-4562-487e-a16b-347a0168de06"), 44 },
                    { new Guid("d8afdaea-0ef6-43ad-bba5-3cdd93bdcc96"), 5, new Guid("e02caea8-b235-41c8-879a-d58ef35d8683"), 43 },
                    { new Guid("d9527370-6e8a-439c-84fa-6f0adbcf9682"), 98, new Guid("dbc8b26e-f009-4ecc-abf8-b796c507146c"), 38 },
                    { new Guid("d9a70cff-beb3-4117-b932-03cb796f6b02"), 147, new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c"), 37 },
                    { new Guid("da63ca1a-a2fa-435f-acf6-cc1b3d15c254"), 20, new Guid("f44db049-91fa-4df8-a155-6c2eed2dbb1c"), 41 },
                    { new Guid("dc5d95ed-61e2-4047-80bb-065a0fa9816c"), 94, new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9"), 43 },
                    { new Guid("ddf9163f-7e4b-4588-ad2d-9f8a894a3090"), 44, new Guid("31c12708-925e-42f1-8d01-7efda2860860"), 43 },
                    { new Guid("ddf9b455-9e64-4342-969e-c221fe137f12"), 48, new Guid("e56e8da8-9477-4da8-88e0-898700185bef"), 38 },
                    { new Guid("de7eddcf-42df-43b6-95e8-7befad0b57c8"), 103, new Guid("aea8f861-0d82-4e98-b348-d230303c0377"), 40 },
                    { new Guid("dea28c64-3fc2-46d0-afcf-0a79caa08f14"), 134, new Guid("09597b53-a86f-4b9b-8f22-647476dc5adf"), 38 },
                    { new Guid("df742ed4-18b2-438f-be51-44802923ea16"), 85, new Guid("60fd75df-37a1-47eb-92fd-02345d8e5fa2"), 40 },
                    { new Guid("dfaeb51d-57e5-427f-9de5-6eeec20a9354"), 91, new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422"), 39 },
                    { new Guid("e0e98606-365d-4197-a3e6-a7e7017a0261"), 7, new Guid("0554d8f5-8438-416f-be71-7664450c0b26"), 42 },
                    { new Guid("e16dde65-ef27-4c1b-9199-3db7f90e4a61"), 50, new Guid("20bad046-339f-44b6-836b-23c304fe605e"), 38 },
                    { new Guid("e1953b78-72bd-46ae-8e01-7466556e8a5b"), 13, new Guid("0554d8f5-8438-416f-be71-7664450c0b26"), 43 },
                    { new Guid("e38abb7a-8559-414d-a27b-35a15df6a3e3"), 122, new Guid("31c12708-925e-42f1-8d01-7efda2860860"), 44 },
                    { new Guid("e58d9648-b6a9-4b08-b52c-ab28ab758d32"), 62, new Guid("80c95f71-5f4d-4f77-ab73-261db2e21e71"), 45 },
                    { new Guid("e5d4243c-dea2-44c6-b82d-2851b73694fd"), 59, new Guid("7493af94-8f29-4024-bba9-d930949a216e"), 45 },
                    { new Guid("e638ebb4-1606-481f-81ce-e0373b5d2cfc"), 27, new Guid("4ded6ae9-98dd-413b-a3b3-eb9d81f7000d"), 43 },
                    { new Guid("e80ab763-ed2b-48c7-9fb9-b4fa485f0255"), 79, new Guid("88f9c8d3-6e3f-4bff-9133-2a18ee5c09f3"), 39 },
                    { new Guid("e83df132-042f-428d-8b81-b2e787603a14"), 26, new Guid("d5fc62e8-796b-4f37-b6ab-c3607b35f4f9"), 39 },
                    { new Guid("e84d62ef-94d3-4b78-b283-3dcae5985e59"), 14, new Guid("cabcd72f-48ea-4c1b-a4d3-a1249e81be3f"), 38 },
                    { new Guid("ecd942c4-3bd3-4813-9c70-110dc4e39dd6"), 89, new Guid("0554d8f5-8438-416f-be71-7664450c0b26"), 44 },
                    { new Guid("ed01ca33-d7c9-4fd2-9fa9-bcccce674404"), 134, new Guid("dcde2944-53f9-4a28-9c89-62de3750d5c4"), 43 },
                    { new Guid("eeab17b5-7c3a-446f-a534-04bf64b7ba22"), 108, new Guid("bd9b4f8d-eff1-4883-9ce8-94796927d337"), 44 },
                    { new Guid("ef6263d6-05ab-4b96-bf53-88edb86498fd"), 136, new Guid("aea8f861-0d82-4e98-b348-d230303c0377"), 42 },
                    { new Guid("f0187c04-3542-486c-b01e-72ce83fbf9a8"), 33, new Guid("13036b39-1228-4529-8487-4e644cf0096b"), 40 },
                    { new Guid("f0bc8b8f-c9f4-47a6-8521-988baaffd601"), 15, new Guid("60aa7369-2005-4a5f-b19d-a5508cc5fbb4"), 40 },
                    { new Guid("f3ee679f-9bc9-443e-9178-01b3228212ae"), 16, new Guid("507f3354-4060-48fe-beb5-d86c6ecdb2ea"), 43 },
                    { new Guid("f3fd3fc0-02f1-4759-b85c-f2390c2479c0"), 55, new Guid("380563b8-5488-4561-95b7-f5d032278c60"), 40 },
                    { new Guid("f4613218-dbdc-4d72-8fd7-eb7bafa87237"), 30, new Guid("f66c3d22-75b9-4861-9dab-cee9ba769023"), 40 },
                    { new Guid("f57ff418-0024-43c6-a0f7-d5c9cf30f9c3"), 16, new Guid("5bbd28e0-17f7-411e-b634-00357a9b523c"), 39 },
                    { new Guid("f7bd5fb3-23f2-4e65-bccb-0caf79eb47fc"), 148, new Guid("20bad046-339f-44b6-836b-23c304fe605e"), 40 },
                    { new Guid("f7cd873c-6f6a-4ba3-ae01-12712c70a4a2"), 47, new Guid("e02caea8-b235-41c8-879a-d58ef35d8683"), 40 },
                    { new Guid("f8a1c833-92f4-48bd-8256-a55cf64b22a6"), 10, new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b"), 40 },
                    { new Guid("faa177ec-b0a1-4eb3-a67d-3dc1c0f85cd0"), 21, new Guid("31c12708-925e-42f1-8d01-7efda2860860"), 41 },
                    { new Guid("fbe94f93-96f5-4ff7-af60-59ac3148f5e5"), 131, new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9"), 41 },
                    { new Guid("fcce7415-b819-46e1-a55b-965b64564117"), 54, new Guid("e4381823-6897-4e64-bc8f-ecc2a3be12c9"), 44 },
                    { new Guid("fdfa3f75-7a1f-4f5c-9cb0-330a97e05f29"), 4, new Guid("247825fa-2a6a-43ac-a2c6-074eec278876"), 38 },
                    { new Guid("fe57f021-f349-4d37-bcdd-102fd4d1c881"), 35, new Guid("1ea0f545-baf8-48a5-9ab2-2dee6561799b"), 42 },
                    { new Guid("fe7f4521-ef33-46fe-b9e0-b203bd496f5e"), 78, new Guid("380563b8-5488-4561-95b7-f5d032278c60"), 42 },
                    { new Guid("feaae7d7-9399-4720-bd32-9eeffe20f2a6"), 118, new Guid("81b0e01e-b6eb-442f-afba-681f3d6d3f53"), 39 },
                    { new Guid("ffe04e15-ab01-4bfc-86f3-bf4d5cca4fcd"), 97, new Guid("855ac80a-a284-4dec-9f56-45a3eeca0422"), 40 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "CreateDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "IsExternalLogin", "LastModifiedDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileName", "ProviderName", "RoleId", "SecurityStamp", "TotalMoney", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7e5e7151-f863-4f44-b7e7-5d601a9471f8"), 0, null, "16f37536-4379-424a-86fc-771dd60edb5f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2204, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "machgiahuy@gmail.com", false, "Mach", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gia Huy", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("7e8882cd-e91e-441a-8e2c-c67cb6a512aa"), null, 1000m, false, "Mach Gia Huy" },
                    { new Guid("d4f2e2be-bb63-4b9b-a0b2-59da18b1ee2a"), 0, null, "2b7f13d3-f3b9-44aa-90a9-f4bc42d29efd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, "Jane", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("274f9a96-baf5-4ff0-919e-fb0cd3e8ba8f"), null, 1500m, false, "jane.smith" }
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
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OrderItems");

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
                name: "WishlistItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
