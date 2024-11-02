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
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
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
                    IsUsingDiscount = table.Column<bool>(type: "bit", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                table: "Shoes",
                columns: new[] { "Id", "AverageRating", "Brand", "Category", "CreateDate", "Description", "Discount", "Gender", "ImageUrl", "IsSale", "LastModifiedDate", "Material", "Name", "Price", "Sold", "TotalRatings", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9662), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/[IDGiay_1]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9676), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20, 0 },
                    { new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9801), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/[IDGiay_16]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9801), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25, 0 },
                    { new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9902), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/[IDGiay_19]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9903), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111, 0 },
                    { new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da"), 4.7m, "Converse", "Yoga", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9930), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/[IDGiay_25]_AnhChinh.png", true, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9931), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30, 0 },
                    { new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9711), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/[IDGiay_9]_AnhChinh.png", true, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9711), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268, 0 },
                    { new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9707), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/[IDGiay_8]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9707), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84, 0 },
                    { new Guid("26aef868-118f-4131-bdbd-022a3734bd5f"), 4.0m, "Puma", "Basketball", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9719), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/[IDGiay_11]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9719), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21, 0 },
                    { new Guid("27548a71-8946-46cd-80b7-f320e1c9828f"), 4.1m, "Puma", "Yoga", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9793), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/[IDGiay_14]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9793), "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22, 0 },
                    { new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9797), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/[IDGiay_15]_AnhChinh.png", true, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9797), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87, 0 },
                    { new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9789), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/[IDGiay_13]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9789), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23, 0 },
                    { new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9912), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/[IDGiay_21]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9912), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10, 0 },
                    { new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 3, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9984), "Nike Youth React Presto Extreme combines lightweight React technology and a flexible upper to provide comfort and support for everyday activities and gym training.", 40m, 2, "images/shoes/[IDGiay_Home_1]_AnhChinh_1.png", true, new DateTime(2024, 10, 3, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9991), "Rubber, yarns and textiles.", "Nike Youth React Presto Extreme", 2069000m, 78, 60, 0 },
                    { new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9916), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/[IDGiay_22]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9917), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45, 0 },
                    { new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f"), 4.8m, "Nike", "Football", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9685), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/[IDGiay_3]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9685), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10, 0 },
                    { new Guid("780c2bf5-e317-4470-a609-82158666e5c4"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9699), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/[IDGiay_6]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9699), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381, 0 },
                    { new Guid("791285b0-00de-4669-a045-de32235375a3"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 3, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9995), "Nike's first lifestyle Air Max brings you style, comfort and big attitude in the Nike Air Max 270. The design draws inspiration from Air Max icons, showcasing Nike's greatest innovation with its large window and fresh array of colors.", 40m, 1, "images/shoes/[IDGiay_Home_2]_AnhChinh_1.png", true, new DateTime(2024, 10, 3, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9996), "Plastics, yarns and textiles.", "Nike Air Max 270", 4059000m, 8, 3, 0 },
                    { new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483"), 4.4m, "Adidas", "Football", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9703), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/[IDGiay_7]_AnhChinh.png", true, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9704), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37, 0 },
                    { new Guid("95b446f0-b228-4821-823a-8df2c66f7b01"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9715), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/[IDGiay_10]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9715), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3, 0 },
                    { new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b"), 4.7m, "Nike", "Basketball", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9681), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/[IDGiay_2]_AnhChinh.png", true, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9681), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45, 0 },
                    { new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9926), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/[IDGiay_24]_AnhChinh.png", true, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9927), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100, 0 },
                    { new Guid("a66baa12-420e-4043-888a-57bb4ba66b97"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 3, 11, 49, 35, 797, DateTimeKind.Local), "Whether you're starting your running journey or an expert eager to switch up your pace, the Downshifter 13 is down for the ride. With a revamped upper, cushioning and durability, it helps you find that extra gear or take that first stride towards chasing down your goals.", 40m, 1, "images/shoes/[IDGiay_Home_3]_AnhChinh_1.png", true, new DateTime(2024, 10, 3, 11, 49, 35, 797, DateTimeKind.Local).AddTicks(1), "Plastics, yarns and textiles.", "Nike Downshifter 13", 2069000m, 78, 20, 0 },
                    { new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9806), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/[IDGiay_17]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9807), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20, 0 },
                    { new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9"), 4.2m, "Nike", "Tennis", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9689), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/[IDGiay_4]_AnhChinh.png", true, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9689), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5, 0 },
                    { new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9908), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/[IDGiay_20]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9908), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10, 0 },
                    { new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9810), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/[IDGiay_18]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9811), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12, 0 },
                    { new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d"), 4.2m, "Puma", "Football", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9784), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/[IDGiay_12]_AnhChinh.png", true, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9785), "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17, 0 },
                    { new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67"), 4.4m, "Converse", "Basketball", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9922), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/[IDGiay_23]_AnhChinh.png", true, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9923), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34, 0 },
                    { new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c"), 7m, "Nike", "Basketball", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9934), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/[IDGiay_26]_AnhChinh.png", false, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9935), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5, 0 },
                    { new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b"), 4.9m, "Nike", "Yoga", new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9693), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/[IDGiay_5]_AnhChinh.png", true, new DateTime(2024, 11, 2, 11, 49, 35, 796, DateTimeKind.Local).AddTicks(9693), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66, 0 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("0066fd28-1e1e-4883-a417-4516e66adf66"), new Guid("791285b0-00de-4669-a045-de32235375a3"), "images/shoes/[IDGiay_Home_2]_AnhPhu_3.png" },
                    { new Guid("01130635-fed5-459b-8d58-61d7f18dc9b4"), new Guid("791285b0-00de-4669-a045-de32235375a3"), "images/shoes/[IDGiay_Home_2]_AnhPhu_2.png" },
                    { new Guid("020bdedb-1aff-4504-8e13-d990f6edc9c9"), new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("021a19a6-9db2-46a1-b929-374af5d5c92a"), new Guid("a66baa12-420e-4043-888a-57bb4ba66b97"), "images/shoes/[IDGiay_Home_3]_AnhPhu_1.png" },
                    { new Guid("02e1dcab-504f-4f2e-9f42-0e6d02c705be"), new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("04d15aa0-c8a0-4612-b314-2c022f0f65ac"), new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("071c1c4a-fe58-40a7-ac0b-860c898ab1c5"), new Guid("26aef868-118f-4131-bdbd-022a3734bd5f"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("08e55005-584f-40b7-b7ba-f7800a019cad"), new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("091f994e-90c2-4390-a791-bcc0489d2a54"), new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("0d7db4a8-08cd-40e4-88f7-2ab3d37349a3"), new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("0da6d29c-3051-4a98-97b5-07087f9b7da5"), new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("0edd89f5-5881-40a6-bdc6-d65f09b21e45"), new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("10759841-0949-456d-8b9f-ac1080608779"), new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("11c9cb94-11cd-44ff-b463-688ab223520a"), new Guid("791285b0-00de-4669-a045-de32235375a3"), "images/shoes/[IDGiay_Home_2]_AnhPhu_1.png" },
                    { new Guid("18fad1a1-a0a0-45a4-b5c6-300fe516621a"), new Guid("26aef868-118f-4131-bdbd-022a3734bd5f"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("19157908-edec-42d1-9527-c95b4c7b5c93"), new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("1aa36f0c-0f77-44b1-9edf-97c4e15acc9f"), new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("1e4beb35-89cc-4238-8414-bb6451a1561d"), new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("1e4d2721-9618-47a0-9979-0aeebf767c2d"), new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("1f5d5ea0-4c88-4da7-97c8-ad809551028a"), new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("23e88ba2-2e55-46a0-aa56-7791f56fbef4"), new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("243f8f54-818b-4427-b912-9c65ffcbe1d7"), new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("246c016d-24b8-4d26-b476-20c0d00648da"), new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("254952b2-31ea-4d9c-a294-5d8da066a7a1"), new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("262295f6-9d20-41d1-922d-2f26f9404b41"), new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c"), "images/shoes/[IDGiay_26]_AnhPhu_3.jpg" },
                    { new Guid("285bd9a2-1c6e-4645-a1da-7c6e79427d97"), new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b"), "images/shoes/[IDGiay_Home_1]_AnhPhu_3.jpg" },
                    { new Guid("2b6bc465-2eea-4520-843f-9a99d2cae358"), new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("2e0f9118-197f-44c2-bf09-ee2cdb439169"), new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("32885d27-33b9-4547-b1f2-9c6751ed262a"), new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("35ec4da7-eecf-4c79-b319-cf6b121ca56d"), new Guid("27548a71-8946-46cd-80b7-f320e1c9828f"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("37dec9e5-79bd-41d9-9fc7-5bd3c44b1fae"), new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("3944a22a-41dc-4bec-9799-894d744a67b3"), new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("3de01a6b-4911-469e-a1e9-3fcd7b35a406"), new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("4808a78c-c19c-4f2a-afa5-14705feb98f5"), new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("498b691b-751d-4d4f-b9c2-d3a590bfd221"), new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("4dc57f3d-4242-4372-9739-b565a3984170"), new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("4ef0b5b3-4349-40a3-b001-fe1e9f5f3b14"), new Guid("95b446f0-b228-4821-823a-8df2c66f7b01"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("51362dff-02e4-4c86-ae1d-442f4d78da7c"), new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("526a8da9-2318-46f2-bf61-4ae03a3b7217"), new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("53a96d30-227d-4077-9e1b-8a5ebe379dba"), new Guid("27548a71-8946-46cd-80b7-f320e1c9828f"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("56272415-e680-4df4-bc0f-e1caa8aca152"), new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("5735da01-3864-4dac-bf6b-4cff2941fb32"), new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("5a2469bf-b4bc-46cb-9f88-ca997696c26f"), new Guid("780c2bf5-e317-4470-a609-82158666e5c4"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("5a3a6df6-71d4-4a09-a62d-2f59c67639d0"), new Guid("26aef868-118f-4131-bdbd-022a3734bd5f"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("5b4a428b-9bbc-49d4-a269-06d6172ddaae"), new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("5b5cb0c4-60c6-4dd2-8edf-9549d27c0c7e"), new Guid("a66baa12-420e-4043-888a-57bb4ba66b97"), "images/shoes/[IDGiay_Home_3]_AnhPhu_4.png" },
                    { new Guid("5d01da28-fb34-4fc3-9b68-35f69e409270"), new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("5db73d7b-4d5c-41d8-a3d6-1d8262eaa4a1"), new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("5ed3ff46-becf-4f13-a866-9e3f55ddcc5c"), new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c"), "images/shoes/[IDGiay_26]_AnhPhu_4.jpg" },
                    { new Guid("60ffc4ab-bc4e-47d0-b9b0-fdf12dbb26ac"), new Guid("27548a71-8946-46cd-80b7-f320e1c9828f"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("62abc73b-6895-4fe5-a457-3e21cc96e625"), new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("6534f105-7a31-4cbe-bca5-09ac9637571f"), new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("65b57590-4cc1-4ce4-986e-a96d5b973583"), new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("661cedf5-1683-40b1-b73e-815f236872ba"), new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("6e1d677a-bc34-4526-961c-db2134e8ec2c"), new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("6f588821-a063-4c6d-9060-f662660a0267"), new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("6f76720d-0601-42dc-97c0-391034d80ac3"), new Guid("95b446f0-b228-4821-823a-8df2c66f7b01"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("6ff5eb31-932b-42e3-bff7-d4709d3e9b61"), new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("72ea79bb-a9b7-4863-aff5-d1cd6276eb85"), new Guid("791285b0-00de-4669-a045-de32235375a3"), "images/shoes/[IDGiay_Home_2]_AnhPhu_4.png" },
                    { new Guid("7534b06a-89f8-4a78-a97f-fe6a8a84c4b9"), new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c"), "images/shoes/[IDGiay_26]_AnhPhu_2.png" },
                    { new Guid("792289f5-0d7b-43a3-8174-af77b4f34d9b"), new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("82e34e91-c47c-4334-ab09-0ee541ed8155"), new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("865d7491-e643-4b12-88b3-1769ec2024fe"), new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("8733b129-e91a-4515-b9b9-48f22e38f006"), new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("884e43a9-b007-413a-8e5e-7706865b03a7"), new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("8aad3e64-e967-4cce-b792-f41ed6c66970"), new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("8b104ceb-8805-406e-8396-e881dfd0d184"), new Guid("26aef868-118f-4131-bdbd-022a3734bd5f"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("8db36999-eea9-474d-9800-2be6f827bde2"), new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("8f0efb99-9cfe-4fba-8ad8-7844580cefdd"), new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("8fe14606-cdc9-4790-94fc-25f9413342e6"), new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("90266350-d620-4d42-a497-ab43b5b5c19f"), new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("91e11e39-af57-4afc-80a0-4434df32f7cd"), new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("966768e4-ec3c-439d-82fb-efd5c38708c9"), new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("9bd37485-8b60-4cfc-88bb-60c15735aaab"), new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("9cb143d8-a72e-48e9-97be-1a73011971df"), new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("9cdf7f51-5ce2-4e24-a55b-6905ffeef0d7"), new Guid("780c2bf5-e317-4470-a609-82158666e5c4"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("9eae9f89-73e6-47ff-b5d0-9ee852d92299"), new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("a19ec85d-3cb1-43fd-92db-9ab3774daaca"), new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("a3077fee-d3c2-4fa0-bb31-476d704b3e87"), new Guid("a66baa12-420e-4043-888a-57bb4ba66b97"), "images/shoes/[IDGiay_Home_3]_AnhPhu_2.png" },
                    { new Guid("a7f3990d-a825-471e-84b4-459e2f288b6b"), new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("ab4b1e35-3fa9-4cd4-9b00-4964df364ab8"), new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("ac22e21b-c85d-45b0-a253-ef0f7952dc67"), new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("ad1e8c61-4fd1-486c-828b-1e3d447d63ef"), new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("ad753cef-1a4a-4df7-b342-2e1b2d6d77ca"), new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("b2ee031a-a106-441d-864e-ceb697161fe5"), new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("b3644039-012a-4992-a45c-f0bc90598f45"), new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("b5d60be5-646f-40ba-a25c-c4d8650407ea"), new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("b6a20984-03f3-4a9f-ad0a-f240571d2103"), new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b"), "images/shoes/[IDGiay_Home_1]_AnhPhu_4.jpg" },
                    { new Guid("bba744dc-baa9-4e31-bf9a-a6964fcef43f"), new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("bdc0d6e7-4f38-4906-893c-c60726d8a936"), new Guid("95b446f0-b228-4821-823a-8df2c66f7b01"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("cdb8cc99-3a7b-4018-82fc-ac43ac3d01d4"), new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("d1109b71-510f-4b04-a314-632a1f381824"), new Guid("780c2bf5-e317-4470-a609-82158666e5c4"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("d1f147c5-9df5-4ae6-ada8-4b00ce226eeb"), new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("d2d3bd7b-8071-4e65-b4ff-826f9d9e76c4"), new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("d4bf4c7d-cdde-48f8-babb-b418015da889"), new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("d6504dca-addc-43c8-8043-7921211ec2ef"), new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("d7877741-ee78-4b3e-a3de-7ccc40b72145"), new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("d93ae56a-4ddc-46ce-bd51-33f045b94aa4"), new Guid("95b446f0-b228-4821-823a-8df2c66f7b01"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("dc6aaf99-6ef3-4a70-92d0-dc1579ce5be2"), new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b"), "images/shoes/[IDGiay_Home_1]_AnhPhu_1.jpg" },
                    { new Guid("dce34488-749e-4ddc-ae4c-7d5298ded038"), new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("dd086247-d3fc-4470-8e3f-04059310b8ce"), new Guid("780c2bf5-e317-4470-a609-82158666e5c4"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("ded4e8a5-b2a4-452b-aa75-1b3e79d4161d"), new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("dfd823c0-a152-4575-8349-2df0f9e6bb9a"), new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("e9668542-8467-444f-8ee7-8a770dd0f598"), new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("ec4f20f2-5471-49ad-88f9-d5e926a075b1"), new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("ec7ab4d4-e4f9-4f51-9ab5-4392bbe10a5f"), new Guid("27548a71-8946-46cd-80b7-f320e1c9828f"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("ed746446-ff19-404f-b481-6bb24bdbb08b"), new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("ee5437e8-ff55-4476-98f3-de58dd9c7065"), new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b"), "images/shoes/[IDGiay_Home_1]_AnhPhu_2.jpg" },
                    { new Guid("ef2d983b-161b-45aa-8a77-ee83595786b7"), new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("f0c58a83-b999-47ae-ac3b-ba01c4efdbbc"), new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("f2f1a3f9-6548-4f65-b816-3adb5a50e204"), new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("f7e9d15a-9fe5-4e91-85af-67d89e49f8dd"), new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("fae0a960-2097-49f1-84a7-27e01b9a5fec"), new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c"), "images/shoes/[IDGiay_26]_AnhPhu_1.png" },
                    { new Guid("fbfe63fd-a607-4014-ba19-7622253e58d2"), new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("fdd6df1a-b551-4e93-8a0a-e02fea41049b"), new Guid("a66baa12-420e-4043-888a-57bb4ba66b97"), "images/shoes/[IDGiay_Home_3]_AnhPhu_3.png" },
                    { new Guid("fe350078-1c0b-46ae-96be-9e00cbb6dd7a"), new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("0a25afe2-24bf-4ac2-9885-55e6201388bd"), "Fall", new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c") },
                    { new Guid("0b9467b5-1914-4369-832f-c25499092356"), "Winter", new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67") },
                    { new Guid("12d3a12c-ae89-4ec1-90d0-d5a007be3b5e"), "Spring", new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e") },
                    { new Guid("136ac3a3-4e49-409f-a0b3-d9e94d197be3"), "Winter", new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c") },
                    { new Guid("19642b5f-c3a1-462f-9d04-cfa290cc9591"), "Summer", new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9") },
                    { new Guid("1dd0d621-1f6a-49ef-9cbb-4718a355f561"), "Fall", new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d") },
                    { new Guid("1ddd8ccc-9051-4d21-b006-f561b3a1c36a"), "Winter", new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb") },
                    { new Guid("1fb17da7-1616-43a5-838d-db3028c732d9"), "Spring", new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914") },
                    { new Guid("206d668a-e1df-44e0-a378-40d18b62546d"), "Spring", new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9") },
                    { new Guid("248189a4-04bf-4254-a6e7-084bc90a4158"), "Fall", new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914") },
                    { new Guid("2c4a0fca-0c4d-46e1-afd6-4bf708211dd0"), "Fall", new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b") },
                    { new Guid("2c8077fe-1df7-4b8b-b61e-97f1a383f77e"), "Summer", new Guid("27548a71-8946-46cd-80b7-f320e1c9828f") },
                    { new Guid("3341fea0-8d87-461d-a6a5-2389af7b76c4"), "Summer", new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745") },
                    { new Guid("35faaa33-e70d-4f6d-bbe6-0e4ac1f83ae1"), "Winter", new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9") },
                    { new Guid("3aa64dcf-1493-4d20-9802-f1ae5b183bfd"), "Spring", new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f") },
                    { new Guid("422a91bc-d68c-4535-934f-42bfac716fb5"), "Summer", new Guid("a66baa12-420e-4043-888a-57bb4ba66b97") },
                    { new Guid("4429e77a-e6e4-45a2-a1b2-7f767e61e9aa"), "Spring", new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da") },
                    { new Guid("45b6988c-a8e9-4680-b978-60c59d00f136"), "Spring", new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb") },
                    { new Guid("47033df6-9697-428a-aaca-6649586bc86d"), "Summer", new Guid("95b446f0-b228-4821-823a-8df2c66f7b01") },
                    { new Guid("4fdcfafb-3be0-4b89-bfcd-1471bcfaf712"), "Summer", new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483") },
                    { new Guid("522bf56f-ec5f-43a1-b27a-9ad6ab1ab0f6"), "Fall", new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b") },
                    { new Guid("526e3998-f5f3-4ee2-a88b-df3b1c4dbada"), "Summer", new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976") },
                    { new Guid("533df698-1e7b-4f3d-bb90-e885851aecea"), "Winter", new Guid("a66baa12-420e-4043-888a-57bb4ba66b97") },
                    { new Guid("545267d8-4d52-49e2-b44b-cbdeff31c548"), "Winter", new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976") },
                    { new Guid("596ad577-3404-4cae-9be9-7523df855cb9"), "Winter", new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b") },
                    { new Guid("599474a8-b67c-4e76-9b9f-f575237c1b0c"), "Spring", new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c") },
                    { new Guid("61096b24-d8d1-43b0-b252-a007fdf1b153"), "Summer", new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b") },
                    { new Guid("611c6e2b-0708-4a05-adfc-fb5135aee4b2"), "Winter", new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745") },
                    { new Guid("6649fca5-032d-4425-9813-b8a4183e3403"), "Spring", new Guid("95b446f0-b228-4821-823a-8df2c66f7b01") },
                    { new Guid("693e6ed8-6417-4920-87ec-fe8cfa477855"), "Summer", new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993") },
                    { new Guid("69498f54-58a0-4b4a-822e-e354b8dac476"), "Spring", new Guid("791285b0-00de-4669-a045-de32235375a3") },
                    { new Guid("69870033-e144-40f3-9951-c1ae2530ede0"), "Fall", new Guid("26aef868-118f-4131-bdbd-022a3734bd5f") },
                    { new Guid("7c9eb0a7-ca91-46f9-8d87-6a7fc5c51ba0"), "Fall", new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9") },
                    { new Guid("7d4d6e7f-8272-459c-9202-3ef9c56a0eee"), "Winter", new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b") },
                    { new Guid("817ea4f9-c778-4f4b-9018-f6d1c98bbc27"), "Fall", new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745") },
                    { new Guid("8806e8cb-e192-496d-8034-13448b6d512b"), "Spring", new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb") },
                    { new Guid("88f6d467-acb1-4cc2-a2d4-c17542c999a3"), "Winter", new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c") },
                    { new Guid("8af9a030-099c-4043-911b-d73472791e74"), "Fall", new Guid("791285b0-00de-4669-a045-de32235375a3") },
                    { new Guid("8d3659fa-14a0-4d51-9cc3-82e3955afb9d"), "Fall", new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b") },
                    { new Guid("8f6cf7b9-7e6f-4a1e-b4b7-3fcc9d269cc9"), "Summer", new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b") },
                    { new Guid("91eb456f-154d-4c03-a0e0-2c40ba4e115d"), "Winter", new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483") },
                    { new Guid("9675d6a8-822e-466f-b57c-6f5c0ea2077b"), "Spring", new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f") },
                    { new Guid("a2cf7bae-dbae-4f54-88e4-7d65c5ee1c7b"), "Spring", new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b") },
                    { new Guid("a6bd4c8f-a7d5-406d-8740-5ab0b316fbc7"), "Summer", new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e") },
                    { new Guid("a6c1dd02-f151-4ca0-91f4-301a1bcb7696"), "Summer", new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb") },
                    { new Guid("b47b9d52-346b-4b0d-8b2c-4e15d1b4d0f0"), "Winter", new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993") },
                    { new Guid("b480e699-a836-4f71-907d-3d258503fbfe"), "Summer", new Guid("791285b0-00de-4669-a045-de32235375a3") },
                    { new Guid("b71e41b5-cbd2-4894-bc81-4bcdacc5d38c"), "Summer", new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee") },
                    { new Guid("b8441e4a-9840-4747-a30e-1286b8f33444"), "Spring", new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d") },
                    { new Guid("bbe8cbaa-1312-4c6c-90e1-cf66a202e196"), "Summer", new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f") },
                    { new Guid("bc330de4-4c1b-4d04-9b5a-6ef89ca48a1c"), "Fall", new Guid("a66baa12-420e-4043-888a-57bb4ba66b97") },
                    { new Guid("c057eff9-ded7-4b79-9ba1-c0f5d5d8d835"), "Fall", new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483") },
                    { new Guid("c18fe3ec-39a8-402e-a424-050b29d59d31"), "Spring", new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b") },
                    { new Guid("c7f8cf5e-a95a-4acb-b7d0-d05be4ab6b04"), "Spring", new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745") },
                    { new Guid("c8de6f4c-d1bb-4d56-b7a7-783d4f5a5560"), "Spring", new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e") },
                    { new Guid("e53ef629-a80e-4d58-833a-00fb9184a342"), "Summer", new Guid("780c2bf5-e317-4470-a609-82158666e5c4") },
                    { new Guid("e576c7f0-638c-4f70-9f2e-cb1d6ce74c5d"), "Spring", new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483") },
                    { new Guid("ee19197e-804e-458f-99f3-97a99d84d4f2"), "Spring", new Guid("27548a71-8946-46cd-80b7-f320e1c9828f") },
                    { new Guid("f19f29ef-82ca-4974-b6ec-27e19c830acd"), "Winter", new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d") },
                    { new Guid("f861a83c-d46c-4014-a886-3d0e4911abf1"), "Winter", new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a") },
                    { new Guid("fd0e188d-99b8-4798-9d0b-b6e3583bc492"), "Winter", new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914") },
                    { new Guid("fdfe8f0b-ec7a-4651-bafc-c6998a0c4a77"), "Summer", new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("06ee5481-ae15-4326-aabd-d2f4e0754b77"), "Pink", new Guid("27548a71-8946-46cd-80b7-f320e1c9828f") },
                    { new Guid("0b17017e-3b42-4d34-b798-a5f107edd5d6"), "White", new Guid("780c2bf5-e317-4470-a609-82158666e5c4") },
                    { new Guid("0e3dc9e1-cb9b-4e97-981c-40e627819de9"), "Blue", new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e") },
                    { new Guid("0f158c20-35ae-46fe-86e2-cdc002399b55"), "Blue", new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914") },
                    { new Guid("0ff11e82-e964-4ba9-9375-1f701f38207f"), "Blue", new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb") },
                    { new Guid("1080a4b6-5058-4951-a5dc-ccc18f8a2e1d"), "Black", new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f") },
                    { new Guid("10cf8c71-58e9-47bc-8681-f3ac49353a6d"), "White", new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb") },
                    { new Guid("12628113-18ab-4d97-93c4-0a0ad6e0c454"), "Brown", new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da") },
                    { new Guid("1cc85cbe-6c07-4926-a058-ccb717669f86"), "Green", new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da") },
                    { new Guid("1cdc9e14-c850-4dab-9283-a3aa45d1279c"), "Blue", new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d") },
                    { new Guid("1fa6d899-443a-4557-a0f6-e30a95a6c621"), "Green", new Guid("780c2bf5-e317-4470-a609-82158666e5c4") },
                    { new Guid("1fc3df2d-8ae0-48d9-9cb6-d9fe0dad3d32"), "Green", new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d") },
                    { new Guid("264a5d2c-da87-4fa1-a507-e9e260b2a369"), "White", new Guid("95b446f0-b228-4821-823a-8df2c66f7b01") },
                    { new Guid("2cc34f80-c4f9-488f-b62f-09b906240ae0"), "White", new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b") },
                    { new Guid("31e025fa-c43b-48a9-823f-baea671e0995"), "Blue", new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f") },
                    { new Guid("340340e0-7559-4f04-96c0-2826cea093af"), "Black", new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e") },
                    { new Guid("3516a64f-4714-4636-ad0a-adc8947ae1b7"), "Black", new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c") },
                    { new Guid("3663e92e-eaa6-476c-a705-822f68bd49ab"), "Black", new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee") },
                    { new Guid("38a82779-e9bf-4d4b-8ede-9ef7f79e7d82"), "White", new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f") },
                    { new Guid("39eccba5-3fee-4e74-9fb4-e70b700fc041"), "White", new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9") },
                    { new Guid("3e9d98d3-48e4-4d17-9e17-ff19a784d2b5"), "Red", new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c") },
                    { new Guid("435b215e-43e0-4cff-a3d7-8741acf3bd29"), "Blue", new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67") },
                    { new Guid("4a6c1fea-4cea-4d34-b11b-c63aff1002ff"), "Yellow", new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483") },
                    { new Guid("4d123027-7162-4328-a20f-e4ab733fbce0"), "Blue", new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b") },
                    { new Guid("4f327072-0b15-4dc8-951d-d7f6882ad43f"), "Red", new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb") },
                    { new Guid("53768ff8-0f0b-4630-b6f8-7140e3c66121"), "Yellow", new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f") },
                    { new Guid("54621b45-732e-49aa-8a0b-46dba3d928d9"), "Black", new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976") },
                    { new Guid("5d008e1b-2321-4f95-829a-2eecf7535822"), "Blue", new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb") },
                    { new Guid("6127f2a7-69b2-4480-8072-b695bc835d50"), "Orange", new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee") },
                    { new Guid("650e98cc-322c-47b9-b349-720e3e8d6c18"), "Brown", new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b") },
                    { new Guid("6853abc1-70ee-450a-a6fb-b80cc856ac7b"), "Purple", new Guid("26aef868-118f-4131-bdbd-022a3734bd5f") },
                    { new Guid("6e35b071-a678-411d-b28c-28fabb85202b"), "Black", new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745") },
                    { new Guid("7c06946f-c107-4de7-b728-c1557a1f3628"), "Black", new Guid("95b446f0-b228-4821-823a-8df2c66f7b01") },
                    { new Guid("807d08e2-a72c-4634-ac47-0a7e5b367843"), "Black", new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb") },
                    { new Guid("80bf9adf-1d53-4d72-a54e-9dabb212da54"), "Orange", new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b") },
                    { new Guid("8113ebc2-56b9-42cb-83f6-2483b4179f73"), "Black", new Guid("a66baa12-420e-4043-888a-57bb4ba66b97") },
                    { new Guid("8aac5981-abd3-44f3-9932-8f82972c4b2e"), "Blue", new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f") },
                    { new Guid("8e959b26-825b-4c3a-94b3-7c670fac0ec9"), "Blue", new Guid("780c2bf5-e317-4470-a609-82158666e5c4") },
                    { new Guid("8fa05799-17e6-4ea6-8897-6cd5c31274f8"), "White", new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914") },
                    { new Guid("94af7445-99cd-4983-89c6-df7a8d62f120"), "White", new Guid("791285b0-00de-4669-a045-de32235375a3") },
                    { new Guid("963d0d44-5a8b-46ed-9fdc-e8207a199148"), "Pink", new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f") },
                    { new Guid("979126b1-bd8f-4863-86d4-7068a97420c2"), "Brown", new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9") },
                    { new Guid("99375738-8ffe-4316-ad4e-c0015acb599f"), "Pink", new Guid("791285b0-00de-4669-a045-de32235375a3") },
                    { new Guid("9aa9f9e6-fa43-426a-8d6f-a2454d1f7b2a"), "Black", new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d") },
                    { new Guid("a0d41a54-1aa1-4cc4-9a77-6437fdb0aea7"), "Orange", new Guid("26aef868-118f-4131-bdbd-022a3734bd5f") },
                    { new Guid("a397b608-d191-4a8e-9df1-3b29b77f9267"), "Orange", new Guid("780c2bf5-e317-4470-a609-82158666e5c4") },
                    { new Guid("a699d53e-8fc7-4da8-bd0e-c977785168e6"), "Red", new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483") },
                    { new Guid("a9075577-aaa7-4be3-8408-314920abdab6"), "Grey", new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914") },
                    { new Guid("af2f7058-f90c-4300-9cce-1d07b2a51ed0"), "Blue", new Guid("791285b0-00de-4669-a045-de32235375a3") },
                    { new Guid("b1545aa0-b8db-4010-a813-746caad767f1"), "Purple", new Guid("95b446f0-b228-4821-823a-8df2c66f7b01") },
                    { new Guid("b25dfe00-97c9-4be7-a5f4-50f2a32e84e2"), "Black", new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993") },
                    { new Guid("b402da79-9723-46d3-886b-5cef31076bc7"), "White", new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b") },
                    { new Guid("b6b78be3-10cb-4a80-93e1-fcef0b6a0e0d"), "Pink", new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c") },
                    { new Guid("b84080f7-95a8-42b1-9320-faaa59b19227"), "Purple", new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f") },
                    { new Guid("bc38b6f3-9181-4d03-b939-3695793a1d77"), "White", new Guid("a66baa12-420e-4043-888a-57bb4ba66b97") },
                    { new Guid("c40d23e9-fb8a-4f44-ae73-2042ee92eee3"), "Black", new Guid("791285b0-00de-4669-a045-de32235375a3") },
                    { new Guid("cbda8689-d807-4a35-8bb3-a9002b384bbb"), "White", new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b") },
                    { new Guid("cf87161b-2b83-43ea-9428-8b97a14d339a"), "Red", new Guid("a66baa12-420e-4043-888a-57bb4ba66b97") },
                    { new Guid("d5180f06-8991-4a0c-926f-206f4d2c2afd"), "Black", new Guid("780c2bf5-e317-4470-a609-82158666e5c4") },
                    { new Guid("d6d022cf-fed8-4c18-86d1-61d4c3e5b727"), "White", new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b") },
                    { new Guid("d6e6a037-9a10-4d84-b911-0aaa438866b3"), "Black", new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f") },
                    { new Guid("e62fdce5-a1ca-4dfa-a3bf-ac073d2a2e7b"), "Black", new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b") },
                    { new Guid("ebc4da56-074d-4239-aea2-ca6da51d8967"), "Black", new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914") },
                    { new Guid("ec061152-b3d9-4171-9d0e-cca63857183f"), "White", new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f") },
                    { new Guid("ee75ec4c-e772-44f0-bb6d-835517d7831a"), "Red", new Guid("780c2bf5-e317-4470-a609-82158666e5c4") },
                    { new Guid("f0d092a0-c77f-4df2-b1bb-0322c6bde0aa"), "Pink", new Guid("95b446f0-b228-4821-823a-8df2c66f7b01") },
                    { new Guid("f4aee979-4bd5-4ddc-9d5b-f770779f500c"), "Black", new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9") },
                    { new Guid("f4de918a-5403-4e49-bd88-fb4a85bd58d7"), "Black", new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b") },
                    { new Guid("f5082129-fd1e-4776-8d89-9f12f41ef477"), "White", new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e") },
                    { new Guid("f70c8875-4eb8-4eb8-9f55-664f02030bcc"), "Red", new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b") },
                    { new Guid("f8aa0df2-4b63-4409-8147-973c55560668"), "Blue", new Guid("a66baa12-420e-4043-888a-57bb4ba66b97") },
                    { new Guid("fa0161dd-d391-4db1-b36a-72a185cccc84"), "Blue", new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c") },
                    { new Guid("fd9fdee3-108e-4669-8bd5-c25c6aa86c28"), "Pink", new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb") },
                    { new Guid("fe323c1a-666d-4277-b705-6009bb613ba7"), "Black", new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b") },
                    { new Guid("ff48bb9c-1a04-48f3-929e-b8e54f068446"), "White", new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("02a14428-5a57-4786-a6ea-11f7502f86bb"), 107, new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e"), 38 },
                    { new Guid("03395d6a-3161-4237-bb49-c411dfa14632"), 144, new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b"), 40 },
                    { new Guid("076b1745-59cb-4e44-8aad-a7a899f598f1"), 81, new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f"), 43 },
                    { new Guid("07a2afe3-674f-43e8-a78f-78af415e15bb"), 63, new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da"), 43 },
                    { new Guid("0a7b6061-1aa2-440c-a061-7720d637fdf8"), 19, new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976"), 38 },
                    { new Guid("18542633-044f-4493-abd8-31b15f5c5d43"), 133, new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f"), 45 },
                    { new Guid("1a46d2f5-2f40-4821-b3cf-9383d02c14c1"), 107, new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e"), 42 },
                    { new Guid("1c2ffcea-8a5c-45c3-9447-1743b780a024"), 124, new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da"), 42 },
                    { new Guid("1d056a1e-81db-4182-b265-fd44e8a364f4"), 129, new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb"), 44 },
                    { new Guid("1d20deef-9640-41fe-b42e-514da79acf06"), 5, new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f"), 44 },
                    { new Guid("1eafcbc1-0244-442a-9d24-410454ffc273"), 7, new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee"), 45 },
                    { new Guid("1f153739-1a70-4361-a4a6-fdac845c4973"), 68, new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67"), 42 },
                    { new Guid("20c4fac2-dfe3-459d-8c12-211082e9a964"), 107, new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914"), 40 },
                    { new Guid("29c3f3dd-d4af-4e06-aa65-2754e6019ed1"), 1, new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b"), 37 },
                    { new Guid("2b8308d3-4692-442f-810f-328ae5acf498"), 2, new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b"), 39 },
                    { new Guid("2cb31ef3-f18a-401c-8d4c-ea12f5a62d70"), 25, new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb"), 45 },
                    { new Guid("2cc9a051-c628-4907-bee0-30fe46373de9"), 128, new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b"), 37 },
                    { new Guid("2f5d0c5b-96da-44a8-a498-d5c39c652397"), 147, new Guid("95b446f0-b228-4821-823a-8df2c66f7b01"), 40 },
                    { new Guid("34974fa8-e5a7-41aa-92f0-55c992be3db5"), 16, new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b"), 38 },
                    { new Guid("371dea43-e1a4-4e22-8d0c-ab90ef8c1c2d"), 21, new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914"), 39 },
                    { new Guid("378fd1da-6e2a-4482-af0d-b0ce8f4285f4"), 133, new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e"), 44 },
                    { new Guid("3912b852-87aa-45d0-979c-6e5b4d672795"), 44, new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b"), 39 },
                    { new Guid("399db2c1-54e6-48ef-9990-beda306a54d0"), 19, new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb"), 45 },
                    { new Guid("3a23d389-2579-4443-b8a6-524156e11f1d"), 43, new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb"), 42 },
                    { new Guid("3a5b301b-f603-4457-a1da-544fe5a5968a"), 56, new Guid("780c2bf5-e317-4470-a609-82158666e5c4"), 41 },
                    { new Guid("40f8a143-085c-4e6c-b492-310d19c14ffd"), 1, new Guid("0f37ad87-cdc4-4844-a060-2331e2c2ad6f"), 46 },
                    { new Guid("437c5a54-5e11-4e13-bb2e-24854073ddcd"), 86, new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745"), 43 },
                    { new Guid("439623ec-f835-4fcb-8d32-acafb9cdd751"), 2, new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b"), 40 },
                    { new Guid("43db6313-f0f0-4c58-b1d9-bf577390e636"), 23, new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb"), 46 },
                    { new Guid("46377e49-dfc8-437b-b04c-ebe0ef9308a2"), 62, new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67"), 41 },
                    { new Guid("4b529bf3-e17f-4f18-9369-0cb68c2b6ccf"), 13, new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745"), 42 },
                    { new Guid("4bda3210-b902-4c48-bd5a-d8046619a69a"), 125, new Guid("a66baa12-420e-4043-888a-57bb4ba66b97"), 42 },
                    { new Guid("4d66802d-5361-4a73-8e39-15e8ca7be096"), 144, new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b"), 41 },
                    { new Guid("4e54e995-841c-4f6e-80da-ba54f4c46525"), 93, new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976"), 37 },
                    { new Guid("5172dc39-a858-4bc4-b7aa-9142cd662b97"), 23, new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745"), 44 },
                    { new Guid("5193167b-c27e-4179-848a-8b5bf91e1938"), 85, new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e"), 39 },
                    { new Guid("53d27b3c-274c-4ab1-b4f5-cab343afc3da"), 90, new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb"), 43 },
                    { new Guid("54938633-11af-4c22-988e-43945103b39d"), 123, new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b"), 37 },
                    { new Guid("55f433ac-4b32-48f6-960f-7df4d0847c86"), 26, new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a"), 44 },
                    { new Guid("598549d3-9fe5-4ca8-92c9-4c1765b0b143"), 13, new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483"), 38 },
                    { new Guid("5a1fc120-0191-4728-8d37-82c7e97369c5"), 52, new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483"), 40 },
                    { new Guid("63aa6421-b2f8-40c4-8f4a-b0dc9f3852e7"), 123, new Guid("95b446f0-b228-4821-823a-8df2c66f7b01"), 41 },
                    { new Guid("64ccf3bc-48c3-4cb0-b514-22fd09622248"), 105, new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b"), 38 },
                    { new Guid("6598ea1f-c568-4dc3-bc6c-8095b7dda01b"), 16, new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9"), 45 },
                    { new Guid("66099994-7b55-476a-85d3-c0be75b2b427"), 27, new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d"), 47 },
                    { new Guid("689af242-dbcf-40b9-8f2c-331b472d9c61"), 42, new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67"), 45 },
                    { new Guid("6a2d27f9-c36c-4f18-af50-6cf8e3ce197c"), 117, new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b"), 39 },
                    { new Guid("6d95295d-2b7a-4ce6-b452-cbcbce46d720"), 143, new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e"), 40 },
                    { new Guid("6e0378d5-5a18-4cd9-aafd-58883c8c6dbe"), 2, new Guid("a2e5aa45-f7be-481c-955c-579fdaba153b"), 41 },
                    { new Guid("6eb6a4b3-5dd4-4cba-bd10-75a9858336aa"), 25, new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e"), 43 },
                    { new Guid("6fa2bb39-fd98-4683-9529-430d6965fcaf"), 119, new Guid("27548a71-8946-46cd-80b7-f320e1c9828f"), 37 },
                    { new Guid("72102d74-ee70-4ea3-9080-df1e6c1eba43"), 29, new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c"), 38 },
                    { new Guid("723c887b-ffa4-4328-b0c3-832c2f14fe5d"), 48, new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c"), 39 },
                    { new Guid("7db8d0e4-0fa5-410d-a4af-b4280f2adcbd"), 4, new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d"), 45 },
                    { new Guid("7dddd3f9-aa9c-4c13-800e-fe47c450cfa9"), 23, new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da"), 40 },
                    { new Guid("8037a949-36d4-4791-ae30-0a855c96fc86"), 35, new Guid("27548a71-8946-46cd-80b7-f320e1c9828f"), 38 },
                    { new Guid("8063a43c-19f7-4ee4-8d51-3078a289ca55"), 77, new Guid("26aef868-118f-4131-bdbd-022a3734bd5f"), 39 },
                    { new Guid("80b68463-fdd3-4072-9c6d-71974654d956"), 64, new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c"), 46 },
                    { new Guid("822615eb-f825-40ac-9668-ce13f1bfe91e"), 6, new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c"), 47 },
                    { new Guid("8443d950-9ee0-4dff-8e3e-5af5e7e5b513"), 34, new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993"), 46 },
                    { new Guid("84ef8112-9110-44e9-a9e2-d1537cb81d34"), 57, new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b"), 40 },
                    { new Guid("8a144e64-c950-4f5a-96cb-21715623ce43"), 81, new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e"), 36 },
                    { new Guid("8b3716e9-b954-4074-9c89-e56f0bb0e677"), 44, new Guid("26aef868-118f-4131-bdbd-022a3734bd5f"), 40 },
                    { new Guid("8c3236b6-41b9-439e-91a0-955dd2bf04a6"), 147, new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f"), 44 },
                    { new Guid("8d418693-ffc7-44c1-83ea-3be1f5defafa"), 33, new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da"), 41 },
                    { new Guid("8f8629b2-8bce-4a0a-8bd6-998a69802feb"), 147, new Guid("a66baa12-420e-4043-888a-57bb4ba66b97"), 45 },
                    { new Guid("9214ba85-9235-44aa-b4f2-cb272cfdc4ed"), 136, new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee"), 46 },
                    { new Guid("929855c0-afb7-4b5d-a095-60731da1240b"), 143, new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f"), 43 },
                    { new Guid("9b7a5c36-4d03-4d7c-821a-5303beaab203"), 17, new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9"), 48 },
                    { new Guid("9f824127-8592-465c-bd72-88dadf3b7b5c"), 15, new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a"), 47 },
                    { new Guid("a0301df9-da20-4f58-98cd-3803c040b110"), 107, new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b"), 39 },
                    { new Guid("a47ec5b9-e9e8-48d2-8381-45e103f3a1d8"), 11, new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d"), 48 },
                    { new Guid("a706fb1a-36c6-409f-922b-3d10ff289b31"), 32, new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483"), 37 },
                    { new Guid("a8bddbde-a7ab-4311-a262-cabf34ef590b"), 9, new Guid("c6d3d29a-a07d-4e39-83f8-3da4b1e7347d"), 46 },
                    { new Guid("a99fcfc3-3535-44be-9008-5aead558f46a"), 63, new Guid("27548a71-8946-46cd-80b7-f320e1c9828f"), 39 },
                    { new Guid("aa48e26d-4c96-4574-a4af-b18ab81f5ae4"), 78, new Guid("780c2bf5-e317-4470-a609-82158666e5c4"), 42 },
                    { new Guid("aef1afaf-1c8c-41ff-8f44-6767067be1b2"), 139, new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee"), 44 },
                    { new Guid("afd33853-48b0-4bfa-86bb-e058938d5dd1"), 54, new Guid("780c2bf5-e317-4470-a609-82158666e5c4"), 40 },
                    { new Guid("b164d545-9633-4d73-82cf-39a836392f1a"), 20, new Guid("b6f3b330-b40a-4c00-a4cd-4db91a7dfc7e"), 45 },
                    { new Guid("b1b02e01-23e5-4243-82f3-074aa4581e36"), 143, new Guid("26aef868-118f-4131-bdbd-022a3734bd5f"), 38 },
                    { new Guid("b25f2ff2-0ffc-427b-ae2d-4bd04d51487d"), 83, new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9"), 46 },
                    { new Guid("b56cd5a6-c743-437c-83c3-b909b9c1f6ae"), 11, new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976"), 36 },
                    { new Guid("b58769c9-5be6-4f25-9185-e0b8c6e3f008"), 1, new Guid("95b446f0-b228-4821-823a-8df2c66f7b01"), 42 },
                    { new Guid("b596bb9b-575f-4860-83ba-0cf8992a4794"), 27, new Guid("fcfcce10-6bc6-4a69-8bc9-60769ae14f9b"), 38 },
                    { new Guid("b5b92156-cc0c-4e49-8b98-649832cefa06"), 74, new Guid("612c03aa-30eb-49c0-af2b-aea06a56d87b"), 41 },
                    { new Guid("b5bc3014-f43d-49b6-9e8b-67322a4056bd"), 42, new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67"), 43 },
                    { new Guid("b7469c3f-fb34-4526-804a-2d12ffbb2c2a"), 4, new Guid("791285b0-00de-4669-a045-de32235375a3"), 42 },
                    { new Guid("b957e7da-1df7-45d7-8ab7-b7f722b902d2"), 10, new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb"), 41 },
                    { new Guid("bf6a0c1c-2a96-4730-aa9d-dee8105ab39f"), 40, new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b"), 40 },
                    { new Guid("c1d89f3f-9c0e-499d-aac5-dfdd5e327bbf"), 81, new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb"), 43 },
                    { new Guid("c835dc46-dcbc-49a7-87d1-9400e88fe56d"), 120, new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914"), 41 },
                    { new Guid("c9c80838-7148-4c57-8320-12e95ad991ca"), 117, new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993"), 48 },
                    { new Guid("cbb46ed4-ec54-4eb2-be44-65ae46dd3222"), 103, new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a"), 45 },
                    { new Guid("cc8e4140-de05-47a9-a3e4-3f2bf5c69b3e"), 80, new Guid("791285b0-00de-4669-a045-de32235375a3"), 44 },
                    { new Guid("cca8b5b6-2432-4bb5-a1cd-6d715b3c0f0f"), 100, new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976"), 39 },
                    { new Guid("cdfb7c73-5aad-4e16-a0d5-0485c545270f"), 98, new Guid("b267250a-7df4-4cee-8054-55f1bce61fdb"), 44 },
                    { new Guid("ce8b1484-efcc-4b32-9322-3d74cf4f9924"), 128, new Guid("791285b0-00de-4669-a045-de32235375a3"), 45 },
                    { new Guid("ceb8e2d2-0790-4a9d-8395-d58d4b93e859"), 124, new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993"), 45 },
                    { new Guid("d12d50d0-cc3c-4ceb-bab9-4a287952fb0f"), 80, new Guid("791285b0-00de-4669-a045-de32235375a3"), 43 },
                    { new Guid("d280b647-e7ba-4e63-a26d-4250eda44fbe"), 31, new Guid("a66baa12-420e-4043-888a-57bb4ba66b97"), 44 },
                    { new Guid("d32ed01c-9f5d-4455-9783-5174c3b9aac9"), 15, new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993"), 47 },
                    { new Guid("d33daa46-4f65-449e-b89e-347f74296919"), 5, new Guid("1af3bb17-85dc-4ec2-b416-31b216c08976"), 40 },
                    { new Guid("d562ef1c-3ab3-483b-bee5-ca56820517fc"), 100, new Guid("1e88bf33-39b9-4e31-9fc5-a58473919dcb"), 47 },
                    { new Guid("d763e542-b467-4501-a2bf-9d41246a15f9"), 53, new Guid("26aef868-118f-4131-bdbd-022a3734bd5f"), 41 },
                    { new Guid("d88df62e-8a16-44cd-b9ca-5ebda45a04d3"), 72, new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914"), 38 },
                    { new Guid("ddb1e8d8-3537-4595-ae8e-97fccb30a796"), 109, new Guid("a66baa12-420e-4043-888a-57bb4ba66b97"), 43 },
                    { new Guid("de888a55-ca5a-4c1f-a870-d84755df20f5"), 22, new Guid("95b446f0-b228-4821-823a-8df2c66f7b01"), 39 },
                    { new Guid("e0b9438d-bf28-4175-a77e-63e8f5479c44"), 97, new Guid("19584a7f-6ca0-446a-8ed4-6d1caca7f6da"), 39 },
                    { new Guid("e201b361-f40c-4369-bf98-4bff97c437d9"), 123, new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f"), 46 },
                    { new Guid("e2b7fb0d-f3a7-4945-b281-56f36fffca1f"), 68, new Guid("173aaf4e-2ad5-4829-9c2b-dd00e156b85a"), 46 },
                    { new Guid("e54d9c12-a0dd-4d04-bc12-88a12b1a8c48"), 133, new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c"), 45 },
                    { new Guid("e77db1b2-ccd8-474c-9d34-87c609051f5f"), 119, new Guid("2e55d318-77da-4a58-af95-5b0a87b3598e"), 37 },
                    { new Guid("e82da0b0-9974-4231-ad7d-156b7eab0faa"), 122, new Guid("82fe2ed9-fdda-4369-ad21-70c108e39483"), 39 },
                    { new Guid("e9299e86-a73d-4f70-9afd-4cbe3d50997f"), 136, new Guid("780c2bf5-e317-4470-a609-82158666e5c4"), 39 },
                    { new Guid("ec73302f-662a-4e0a-8d7b-69186d2bc47a"), 20, new Guid("76bb5e66-8452-4e93-8f70-6df9592c795f"), 45 },
                    { new Guid("ecbf6d37-7f8f-44b0-be55-f0a58bdd7e4a"), 132, new Guid("f2270f55-4949-4939-b8bb-3bdda6b5ff0c"), 48 },
                    { new Guid("ef9ba1e0-7aed-4483-92c5-9d1ae9cad5c7"), 49, new Guid("ab214f0f-057c-419a-964a-f2f51777c2c9"), 47 },
                    { new Guid("f27c6fa3-89d0-492b-80e2-19114417d39c"), 98, new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c"), 36 },
                    { new Guid("f2c78630-ffc0-47a2-93e2-25fdc9c2816c"), 125, new Guid("a7f5df38-8ebe-47c3-a7c6-df1afe354c6c"), 37 },
                    { new Guid("fab47a5e-1ca8-4850-874e-13a8dbcb51bd"), 60, new Guid("71874a63-2e29-40fb-a1fb-9e6c36927993"), 49 },
                    { new Guid("fabc901e-2862-4549-9d8d-125fa3f5e50b"), 3, new Guid("cbd5e960-a3c8-46e7-9691-3c685ced9c67"), 44 },
                    { new Guid("fc367c57-813c-4dde-be31-ce54d81db530"), 115, new Guid("26aef868-118f-4131-bdbd-022a3734bd5f"), 37 },
                    { new Guid("fc74235c-0c96-4b91-8b88-47b4f35e21ea"), 4, new Guid("27548a71-8946-46cd-80b7-f320e1c9828f"), 40 },
                    { new Guid("fc9cf9c0-e749-457b-934c-232ab8af213a"), 85, new Guid("49ce5ea9-de8b-44f9-b0b2-e37f8c8fa0ee"), 43 },
                    { new Guid("febcf1f0-f8ec-42ce-a3bc-9e6d33094234"), 76, new Guid("559c0bbd-24a9-4dda-ae98-6f35d2fc4745"), 41 },
                    { new Guid("ff4afb1a-7ef4-430c-9759-2194fc363a06"), 80, new Guid("0ff6837f-789c-4807-9ee8-60ba00e48914"), 37 },
                    { new Guid("fffa2392-553b-4443-a423-86ffd56caf04"), 7, new Guid("9cc2bbbf-e272-41f4-8555-000768c5c18b"), 42 }
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
                name: "CommentLikes");

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
                name: "SiteViews");

            migrationBuilder.DropTable(
                name: "WishlistItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
