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
                    LastViewedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    { new Guid("58188164-95b3-403a-894f-ffedd494711d"), "Role User với các quyền hạn có giới hạn và mua hàng", "User" },
                    { new Guid("6fc14fa8-a9a5-4362-b8b4-c95cf5045516"), "Role Admin với đầy đủ các quyền hạn", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "AverageRating", "Brand", "Category", "CreateDate", "Description", "Discount", "Gender", "ImageUrl", "IsSale", "LastModifiedDate", "Material", "Name", "Price", "Sold", "TotalRatings", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d"), 4.1m, "Puma", "Yoga", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(601), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/[IDGiay_14]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(609), "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22, 0 },
                    { new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea"), 1.9m, "Adidas", "Tennis", new DateTime(2024, 10, 20, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(5511), "A versatile shoe for any occasion.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(5515), "Rubber", "Adidas Model WFZXM", 2866708m, 244, 89, 0 },
                    { new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7"), 1.3m, "Nike", "Basketball", new DateTime(2024, 9, 19, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(1481), "Perfect for all sports activities.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(1484), "Leather", "Nike Model C1Z0K", 2435883m, 37, 143, 0 },
                    { new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2"), 2.1m, "Puma", "Tennis", new DateTime(2024, 10, 10, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(5959), "Perfect for all sports activities.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(5962), "Leather", "Puma Model 0UX6B", 2647226m, 53, 138, 0 },
                    { new Guid("22963aac-57fb-4602-bfc0-d21547798aae"), 1.5m, "Adidas", "Tennis", new DateTime(2024, 9, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(6602), "Provides excellent comfort and support.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(6606), "Synthetic", "Adidas Model XAO9J", 3758499m, 232, 71, 0 },
                    { new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca"), 4.8m, "Under Armour", "Running", new DateTime(2024, 10, 7, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(7409), "Lightweight and durable for high-performance.", 37m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(7412), "Mesh", "Under Armour Model 49EEB", 1929728m, 83, 132, 0 },
                    { new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95"), 7m, "Nike", "Basketball", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(762), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/[IDGiay_26]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(763), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5, 0 },
                    { new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724"), 1.3m, "Puma", "Running", new DateTime(2024, 10, 23, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(4969), "Perfect for all sports activities.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(4974), "Mesh", "Puma Model B6UAL", 3830170m, 298, 150, 0 },
                    { new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462"), 4.9m, "Nike", "Yoga", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(516), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/[IDGiay_5]_AnhChinh.png", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(517), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66, 0 },
                    { new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(659), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/[IDGiay_20]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(660), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10, 0 },
                    { new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(640), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/[IDGiay_16]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(641), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25, 0 },
                    { new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(742), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/[IDGiay_22]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(743), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45, 0 },
                    { new Guid("5cc230da-917f-464e-8365-9b38877fc34b"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(571), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/[IDGiay_8]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(572), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84, 0 },
                    { new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45"), 4.2m, "Under Armour", "Football", new DateTime(2024, 9, 16, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(575), "A versatile shoe for any occasion.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(578), "Canvas", "Under Armour Model 38JJZ", 3564470m, 293, 41, 0 },
                    { new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(649), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/[IDGiay_18]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(650), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12, 0 },
                    { new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(520), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/[IDGiay_6]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(521), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381, 0 },
                    { new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170"), 4.7m, "Nike", "Basketball", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(500), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/[IDGiay_2]_AnhChinh.png", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(501), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45, 0 },
                    { new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(596), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/[IDGiay_13]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(596), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23, 0 },
                    { new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294"), 2.1m, "Nike", "Football", new DateTime(2024, 10, 23, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(8266), "Breathable material keeps your feet cool and dry.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(8269), "Mesh", "Nike Model TA7VA", 3277430m, 80, 62, 0 },
                    { new Guid("703dbd27-3273-4fc0-9141-0647bd53c414"), 3.5m, "Nike", "Gym & Training", new DateTime(2024, 9, 24, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(4918), "Lightweight and durable for high-performance.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(4921), "Rubber", "Nike Model KIG7J", 1602057m, 65, 168, 0 },
                    { new Guid("7293c05c-0f67-4c6a-8f61-98e028151aad"), 4.6m, "Nike", "Basketball", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(771), "One of the best shoes for basketball and the symbol of Nike's World. You won't be able to take your eyes off of this brand new Jordan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(772), "Leather, fabric, foam, and rubber.", "Jordan 1 Low Bred Toe 2.0", 1813000m, 45, 23, 0 },
                    { new Guid("7d5aaa86-5f96-4804-bd4f-84856744a28e"), 4.8m, "Under Armour", "Gym & Training", new DateTime(2024, 10, 25, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(3247), "A versatile shoe for any occasion.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(3250), "Canvas", "Under Armour Model IXQRJ", 1455590m, 6, 137, 0 },
                    { new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88"), 2.2m, "Puma", "Tennis", new DateTime(2024, 9, 10, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(4378), "Breathable material keeps your feet cool and dry.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(4381), "Canvas", "Puma Model C2XIN", 1773449m, 152, 181, 0 },
                    { new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), 4.8m, "Nike", "Football", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(507), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/[IDGiay_3]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(508), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10, 0 },
                    { new Guid("890ffc69-b7af-4218-b457-b27abe752233"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(620), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/[IDGiay_15]_AnhChinh.png", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(626), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87, 0 },
                    { new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), 4.2m, "Puma", "Football", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(591), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/[IDGiay_12]_AnhChinh.png", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(592), "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17, 0 },
                    { new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6"), 4.7m, "Converse", "Yoga", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(756), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/[IDGiay_25]_AnhChinh.png", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(756), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30, 0 },
                    { new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206"), 4.9m, "Puma", "Gym & Training", new DateTime(2024, 10, 24, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(3252), "Stylish design for both casual and athletic wear.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(3256), "Synthetic", "Puma Model V98XE", 3749654m, 241, 87, 0 },
                    { new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(578), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/[IDGiay_9]_AnhChinh.png", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(579), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268, 0 },
                    { new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c"), 4.5m, "Puma", "Running", new DateTime(2024, 9, 28, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(3681), "Lightweight and durable for high-performance.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(3684), "Mesh", "Puma Model W4LE1", 3549664m, 347, 169, 0 },
                    { new Guid("a4580586-dabc-474d-a130-8cad12e28efd"), 4.2m, "Nike", "Tennis", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(512), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/[IDGiay_4]_AnhChinh.png", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(512), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5, 0 },
                    { new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f"), 4.4m, "Converse", "Basketball", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(747), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/[IDGiay_23]_AnhChinh.png", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(748), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34, 0 },
                    { new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171"), 4.0m, "Adidas", "Football", new DateTime(2024, 9, 17, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(6970), "Enhances performance and boosts confidence.", 37m, 0, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(6974), "Canvas", "Adidas Model BA5HR", 1743648m, 21, 130, 0 },
                    { new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7"), 3.5m, "Nike", "Tennis", new DateTime(2024, 9, 17, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(2683), "A versatile shoe for any occasion.", 39m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(2686), "Canvas", "Nike Model 5ZFOL", 3683995m, 119, 24, 0 },
                    { new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae"), 2.1m, "Puma", "Basketball", new DateTime(2024, 10, 2, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(2527), "Designed for optimum traction on various surfaces.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(2535), "Synthetic", "Puma Model Y8N7U", 1428005m, 188, 144, 0 },
                    { new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2"), 4.4m, "Adidas", "Football", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(567), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/[IDGiay_7]_AnhChinh.png", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(568), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37, 0 },
                    { new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(583), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/[IDGiay_10]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(583), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3, 0 },
                    { new Guid("ba9ca9a4-8dce-40ee-af75-475b27e20773"), 4.7m, "Puma", "Football", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(779), "One of the best shoes for football and the symbol of Puma's World. You won't be able to take your eyes off of this brand new FUTURE, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(780), "Leather, fabric, foam, and rubber.", "Puma FUTURE 7 Ultimate FG/AG The Forever Faster", 2713000m, 78, 55, 0 },
                    { new Guid("c05a001f-2a93-4b89-aefa-65277083c58b"), 4.3m, "Reebok", "Running", new DateTime(2024, 9, 12, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(7214), "Breathable material keeps your feet cool and dry.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(7217), "Leather", "Reebok Model YD7M6", 1449111m, 96, 59, 0 },
                    { new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312"), 1.9m, "Reebok", "Tennis", new DateTime(2024, 9, 22, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(6465), "A versatile shoe for any occasion.", 0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(6468), "Leather", "Reebok Model 2JYHN", 1640012m, 175, 89, 0 },
                    { new Guid("c3691ff1-3925-4044-89bb-dd2e03913060"), 2.1m, "Puma", "Gym & Training", new DateTime(2024, 9, 19, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(4130), "Breathable material keeps your feet cool and dry.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(4133), "Rubber", "Puma Model 1ZYZB", 3495670m, 9, 143, 0 },
                    { new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c"), 0.9m, "Puma", "Football", new DateTime(2024, 10, 19, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(113), "Breathable material keeps your feet cool and dry.", 6m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(117), "Rubber", "Puma Model 1B57Y", 3022619m, 159, 79, 0 },
                    { new Guid("c408ebff-884e-482b-8690-2f87bcbe6404"), 4.2m, "Adidas", "Basketball", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(775), "One of the best shoes for basketball and the symbol of Adidas's World. You won't be able to take your eyes off of this brand new SuperStan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(776), "Leather, fabric, foam, and rubber.", "Adidas Original StanSmith", 1713000m, 65, 33, 0 },
                    { new Guid("c54216f3-b68f-40d3-a269-55a008e1089b"), 3.0m, "Nike", "Basketball", new DateTime(2024, 10, 10, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(3886), "Lightweight and durable for high-performance.", 8m, 0, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(3889), "Leather", "Nike Model 9JN47", 2304392m, 159, 172, 0 },
                    { new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3"), 1.9m, "Nike", "Basketball", new DateTime(2024, 9, 12, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(2267), "Lightweight and durable for high-performance.", 17m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(2272), "Leather", "Nike Model CUVQY", 1341719m, 63, 69, 0 },
                    { new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(752), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/[IDGiay_24]_AnhChinh.png", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(752), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100, 0 },
                    { new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(477), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/[IDGiay_1]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(494), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20, 0 },
                    { new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521"), 3.9m, "Nike", "Running", new DateTime(2024, 9, 9, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(1071), "Stylish design for both casual and athletic wear.", 9m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(1074), "Leather", "Nike Model OLO8U", 2008816m, 28, 49, 0 },
                    { new Guid("da812011-788d-4b76-8873-ecc88d25f1a9"), 1.5m, "Nike", "Tennis", new DateTime(2024, 10, 19, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(7887), "Lightweight and durable for high-performance.", 0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(7891), "Rubber", "Nike Model LI3IS", 3910961m, 40, 120, 0 },
                    { new Guid("e2448e25-38f6-4fd5-8197-7d6572176836"), 0.0m, "Puma", "Tennis", new DateTime(2024, 10, 15, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(5986), "Enhances performance and boosts confidence.", 26m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(5989), "Rubber", "Puma Model 6R09E", 2684734m, 16, 96, 0 },
                    { new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723"), 3.4m, "Under Armour", "Tennis", new DateTime(2024, 10, 21, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(8818), "Provides excellent comfort and support.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(8821), "Mesh", "Under Armour Model BDM49", 1548041m, 57, 182, 0 },
                    { new Guid("e37dd495-4ec8-40e6-85e9-217bed6a14df"), 0.9m, "Adidas", "Basketball", new DateTime(2024, 10, 12, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(9729), "Enhances performance and boosts confidence.", 0m, 0, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(9732), "Leather", "Adidas Model XD4JU", 2601294m, 302, 4, 0 },
                    { new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), 4.0m, "Puma", "Basketball", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(587), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/[IDGiay_11]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(588), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21, 0 },
                    { new Guid("ecc65355-5489-4368-8004-da6fe3240679"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(664), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/[IDGiay_21]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(664), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10, 0 },
                    { new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(653), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/[IDGiay_19]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(654), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111, 0 },
                    { new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254"), 3.1m, "Reebok", "Basketball", new DateTime(2024, 9, 13, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(9256), "A versatile shoe for any occasion.", 42m, 0, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(9260), "Canvas", "Reebok Model 122EL", 3020121m, 341, 145, 0 },
                    { new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c"), 2.4m, "Puma", "Basketball", new DateTime(2024, 9, 28, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(5486), "Provides excellent comfort and support.", 12m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 26, 23, 8, 28, 797, DateTimeKind.Local).AddTicks(5490), "Rubber", "Puma Model SMWHX", 3380091m, 308, 28, 0 },
                    { new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(645), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/[IDGiay_17]_AnhChinh.png", false, new DateTime(2024, 10, 26, 23, 8, 28, 796, DateTimeKind.Local).AddTicks(645), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20, 0 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("0006a404-d0a8-497e-93f9-5520e79f0383"), new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("03784f48-683a-4bba-82ce-cac110357167"), new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206"), "images/shoes/noimage.webp" },
                    { new Guid("0398787f-b71b-469d-b92b-83f02cf47e2f"), new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95"), "https://c.files.bbci.co.uk/1081F/production/_117751676_satan-shoes2.jpg" },
                    { new Guid("05544d99-51f8-451c-8dc1-0b4cda470375"), new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("055ca702-44b5-4911-93f1-651f9cb451d3"), new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2"), "images/shoes/noimage.webp" },
                    { new Guid("0584291e-01a2-45f0-9090-77fc1b6b569a"), new Guid("c408ebff-884e-482b-8690-2f87bcbe6404"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-3.jpg" },
                    { new Guid("05b7108f-20a8-44a2-ae18-8e084b51f3eb"), new Guid("c408ebff-884e-482b-8690-2f87bcbe6404"), "https://likelihood.us/cdn/shop/files/stansmith_angle_1200x.png?v=1691430477" },
                    { new Guid("0b13f7cd-2760-4263-8de5-ed8b465cea7c"), new Guid("ecc65355-5489-4368-8004-da6fe3240679"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("0b206844-b799-49e1-9b82-b0204f6d8c6e"), new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("0dfc1c44-78c7-42f3-98de-245123aff98c"), new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c"), "images/shoes/noimage.webp" },
                    { new Guid("0f6178d6-7d9c-4eda-8363-6a7e929d674e"), new Guid("22963aac-57fb-4602-bfc0-d21547798aae"), "images/shoes/noimage.webp" },
                    { new Guid("15ac0d87-bbac-44a8-8ed8-b3933a0bb2db"), new Guid("5cc230da-917f-464e-8365-9b38877fc34b"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("1835b5ad-0331-45ef-9c51-19be82fb0fe1"), new Guid("7293c05c-0f67-4c6a-8f61-98e028151aad"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNBQXFHswxHuyjT_e8rb5XOaWUzEe3pphPPw&s" },
                    { new Guid("1a92f216-4e62-4ccd-9067-0ff2671d3d5d"), new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("1bb88941-fde5-4369-b0b4-9fa72f85df6d"), new Guid("e2448e25-38f6-4fd5-8197-7d6572176836"), "images/shoes/noimage.webp" },
                    { new Guid("1c767a7a-fd74-46b8-8a96-3aeec884523b"), new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), "images/shoes/[IDGiay_3]_AnhChinh.jpeg" },
                    { new Guid("1f4d1ef7-83ea-428e-aacd-0e0fcf018922"), new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("200c918f-45b4-44ce-b4ae-2801fe1d4723"), new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("20751940-87fe-436d-ba48-681792d0b1b9"), new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("237ce604-11f2-489e-b948-944797eec599"), new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("25dca9df-549f-42e9-8eb6-70d1757f79e5"), new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("2628fd14-7bdd-4fd1-9aac-329d3747c4e3"), new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("26b9ff8c-6f2d-402e-8eda-97436cf87543"), new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("26e229cc-bd4f-4357-981a-b488add78718"), new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3"), "images/shoes/noimage.webp" },
                    { new Guid("28abdb5e-4e4c-453d-bc07-d7dadbee9f86"), new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("2b45b10e-a34e-479d-8482-2b49eefa5b96"), new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462"), "images/shoes/[IDGiay_5]_AnhChinh.jpeg" },
                    { new Guid("2c9f1498-7bfc-46e7-b4b6-59a792212f0b"), new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("389c86f8-9c14-4d77-8bfd-7dafecd5dce8"), new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("3d7e9ed9-39fc-4874-90aa-6a8483e086bf"), new Guid("ba9ca9a4-8dce-40ee-af75-475b27e20773"), "https://thumblr.uniid.it/product/336262/a92a6cadc8a6.jpg?width=3840&format=webp&q=75" },
                    { new Guid("455661cb-84bf-4bea-ae0b-c88edfb23640"), new Guid("890ffc69-b7af-4218-b457-b27abe752233"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("47364ca6-d345-4ea4-a803-7dec414a82a0"), new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("4741a3a8-f65e-4a4a-b642-371ee33bbc15"), new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("4750665b-9fd4-4b6e-9932-5f2d040ff413"), new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723"), "images/shoes/noimage.webp" },
                    { new Guid("47e1da3f-c6e1-4866-88a4-0c3a67775bb1"), new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2"), "images/shoes/[IDGiay_7]_AnhChinh.jpg" },
                    { new Guid("4865cca5-48a8-46c5-9258-eb292a3702b0"), new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("4a1d11ba-1385-4635-96ab-f814fb544994"), new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("4b03c528-c3d9-495f-9eef-f7b6b078d001"), new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), "images/shoes/[IDGiay_20]_AnhChinh.png" },
                    { new Guid("4cc79cbc-a8d5-4be2-8af2-fc00525027f1"), new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("4e16359d-ed12-4a66-8420-1b71c6f26e81"), new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("4f5be605-b469-462d-8bdf-8838dfd2cfad"), new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7"), "images/shoes/noimage.webp" },
                    { new Guid("5013e1f2-3eb8-4b47-af45-3a6b4a0e3d30"), new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("50887f93-269d-44ab-bdc9-6e45c0778b51"), new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("526897c7-428e-435b-978a-d3c117fd530f"), new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("537376f0-69d9-4462-afe3-50e42923b55e"), new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("53c9da61-02ec-4fc0-ac2e-c7c5ba1d041f"), new Guid("c408ebff-884e-482b-8690-2f87bcbe6404"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-1.jpg" },
                    { new Guid("54a569ce-4f2a-43ec-ad2c-4dbbbf661de3"), new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("5525e147-bef7-4429-9209-504d046b82d4"), new Guid("da812011-788d-4b76-8873-ecc88d25f1a9"), "images/shoes/noimage.webp" },
                    { new Guid("5580a6d2-9e14-4aa1-8b80-2b8cdcc6c8ce"), new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("5981218c-162c-41e9-a03d-2f49679be9e5"), new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95"), "https://media.cnn.com/api/v1/images/stellar/prod/210328223753-03-lil-nas-x-satan-shoes.jpg?q=w_3000,h_3000,x_0,y_0,c_fill" },
                    { new Guid("598898c8-204f-4aca-9443-e9d0c524dc7f"), new Guid("a4580586-dabc-474d-a130-8cad12e28efd"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("5a008430-9f14-4280-9e11-cefaa2976c78"), new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("5aaa006b-d850-45b6-8134-7012d1c109e0"), new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("5bc2648e-9873-4aca-8c24-ac4991f9db57"), new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95"), "https://photo.znews.vn/w660/Uploaded/rohunwa/2021_03_26/SHOES3.jpeg" },
                    { new Guid("5ce47deb-41f0-48b4-bdbb-a69de54dd04c"), new Guid("a4580586-dabc-474d-a130-8cad12e28efd"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("5d1d4585-b70e-411a-8ad7-4bd758bf5c94"), new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), "images/shoes/[IDGiay_6]_AnhChinh.jpg" },
                    { new Guid("5d91979d-bf12-488a-9667-3de300c65496"), new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("5f9d27c7-df12-469c-b134-c21b030c9d4f"), new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("61880a37-c351-47e9-b570-0e6268aa9872"), new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("62670fce-e315-44f9-83ac-203f47820528"), new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("64f7528e-7007-451e-a5c7-1b150f858550"), new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f"), "images/shoes/[IDGiay_23]_AnhChinh.jpg" },
                    { new Guid("65b2c24e-9e38-49d3-838f-1650dc94fa14"), new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), "images/shoes/[IDGiay_11]_AnhChinh.png" },
                    { new Guid("67357af1-25a8-40d8-a355-5627753a81a0"), new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88"), "images/shoes/noimage.webp" },
                    { new Guid("68f9a8c2-74a1-44f3-b29b-0071926471c6"), new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("6a2353b1-bd0b-4eca-bfa5-a80bac66d3b8"), new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("6ab74983-8407-46eb-acf3-218e9d2cce09"), new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("6af8df45-01d2-441a-be4c-5f2ed49fc394"), new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("6cc24f1c-d93b-427e-b56e-b9348da433f9"), new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254"), "images/shoes/noimage.webp" },
                    { new Guid("6d446213-2821-490c-b192-1fc3fd7d348a"), new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("6d4483cd-e7be-4dde-8b95-2ef3a20bd054"), new Guid("ecc65355-5489-4368-8004-da6fe3240679"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("6ec3f26f-c2ae-4978-9d40-2ae625ca1286"), new Guid("c408ebff-884e-482b-8690-2f87bcbe6404"), "https://assets.adidas.com/images/w_1880,f_auto,q_auto/e53b9a57b0a745be924bac1e00f54427_9366/FX5502_42_detail.jpg" },
                    { new Guid("70b0737e-1ae2-45a7-a301-3abec2acc6fd"), new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("71bdcfb2-fe5a-4e64-8d8e-60dbe60a674b"), new Guid("ecc65355-5489-4368-8004-da6fe3240679"), "images/shoes/[IDGiay_21]_AnhChinh.jpg" },
                    { new Guid("729959ff-2133-4acf-a89d-0224e7b481b2"), new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("72e7b683-3d43-4fb4-b63b-735faf33135b"), new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("7648a0f1-00e1-472d-8dce-66922d5ac29b"), new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), "images/shoes/[IDGiay_13]_AnhChinh.jpeg" },
                    { new Guid("765ec8fa-0e43-4c71-a065-a47a212fb278"), new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("77a9bf3d-0b83-4a55-a47f-29b4567ea365"), new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6"), "images/shoes/[IDGiay_25]_AnhChinh.jpg" },
                    { new Guid("78f906c4-84ea-481b-b277-78a45294547d"), new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30"), "images/shoes/[IDGiay_24]_AnhChinh.jpg" },
                    { new Guid("7c7d10d3-9228-4ab5-b809-2a66c1a75095"), new Guid("7293c05c-0f67-4c6a-8f61-98e028151aad"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3rZPCUSKRHdQA5_g3YBJRdcmIf_6PpZcNZg&s" },
                    { new Guid("7d0e3bea-cce9-4917-a55b-00db419c325e"), new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c"), "images/shoes/noimage.webp" },
                    { new Guid("7f7d152a-cd52-4180-9644-64a23daf61bd"), new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("7f9c0c56-2e82-4535-aaba-9bb07d9dc592"), new Guid("c05a001f-2a93-4b89-aefa-65277083c58b"), "images/shoes/noimage.webp" },
                    { new Guid("800c6f9b-08a0-4752-8e05-985aca74d2df"), new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("811f3009-e8cc-47b4-ae8d-fdee023db52b"), new Guid("890ffc69-b7af-4218-b457-b27abe752233"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("83000bdf-95f9-404a-bb46-e1d2cf5ad5e8"), new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("838c177b-b808-4672-9ba9-1fbdd2081a13"), new Guid("7293c05c-0f67-4c6a-8f61-98e028151aad"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQPenW_eiwOe1RkKeaF_kg5TraxKiem6NJ_Q&s" },
                    { new Guid("869ed652-5c4d-4d2d-9a18-ac0f3d7dccbb"), new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("86fb7507-bb44-4462-b074-229d274debda"), new Guid("890ffc69-b7af-4218-b457-b27abe752233"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("870c5148-28cb-439f-9523-b5e828b2f53e"), new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("893ab121-ba5d-4fba-b411-2619bbde538f"), new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), "images/shoes/[IDGiay_17]_AnhChinh.png" },
                    { new Guid("8e3bfa86-45e1-4ecc-bac5-f1f916dfc6dc"), new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("8e9b268c-1408-418e-8b34-0379f934ea6f"), new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("907b6b42-0fad-4243-8b51-756201ed15ae"), new Guid("7d5aaa86-5f96-4804-bd4f-84856744a28e"), "images/shoes/noimage.webp" },
                    { new Guid("936dea11-d95a-49fa-9a62-b104e232ba0d"), new Guid("a4580586-dabc-474d-a130-8cad12e28efd"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("93e80293-a76f-415a-b9de-984e20d22337"), new Guid("5cc230da-917f-464e-8365-9b38877fc34b"), "images/shoes/[IDGiay_8]_AnhChinh.jpg" },
                    { new Guid("96e63191-6f90-4356-ab3e-ccce9d4722f3"), new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("98195e33-94ad-42fa-980c-4f2a8dd0db37"), new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("988ab6b6-2d0c-4279-b8ef-0199d2d90625"), new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("99066e09-7763-418e-945c-1d4f1d7d7a2c"), new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("990e1973-f02d-4ec8-9c2a-862dcdc164fc"), new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("9a613f96-c61e-4277-a96f-2c28870da376"), new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0"), "images/shoes/[IDGiay_22]_AnhChinh.jpg" },
                    { new Guid("9b19f71b-da12-4223-9485-8c9962ad1203"), new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("9b386f97-2881-4f83-ba7d-da7a4fc1d8da"), new Guid("ba9ca9a4-8dce-40ee-af75-475b27e20773"), "https://thumblr.uniid.it/product/336262/57daee260d2a.jpg?width=3840&format=webp&q=75" },
                    { new Guid("9eec577d-4abf-4f45-b312-29e193f8fb9b"), new Guid("703dbd27-3273-4fc0-9141-0647bd53c414"), "images/shoes/noimage.webp" },
                    { new Guid("9f797461-d88d-469d-9435-1a108cd878e9"), new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("9f8474a1-2b21-4c20-8b78-1e948a5c54e7"), new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae"), "images/shoes/noimage.webp" },
                    { new Guid("9fabb979-def3-48c1-b559-0f6978a6cb36"), new Guid("7293c05c-0f67-4c6a-8f61-98e028151aad"), "https://dmpkickz.com/cdn/shop/files/6_78fd24e0-cd30-400a-8fa1-e5e6cd3c5b0b.png?v=1696679846&width=480" },
                    { new Guid("a093fe7c-3f66-4f3a-b2f7-f05fd359280d"), new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c"), "images/shoes/noimage.webp" },
                    { new Guid("a0ccafe7-6936-432d-98c4-584baa4abcf0"), new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00"), "images/shoes/[IDGiay_10]_AnhChinh.jpg" },
                    { new Guid("a25e375b-f0dc-4015-a4d0-02cfccbe9ec4"), new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724"), "images/shoes/noimage.webp" },
                    { new Guid("a7ac3921-593b-414f-b603-fad50db15b8e"), new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521"), "images/shoes/noimage.webp" },
                    { new Guid("aae8b7c4-35df-4f5f-980f-c6e001b7663a"), new Guid("ba9ca9a4-8dce-40ee-af75-475b27e20773"), "https://thumblr.uniid.it/product/336262/8307c19dcf3d.jpg?width=3840&format=webp&q=75" },
                    { new Guid("ae87139b-0b39-4411-9ab4-8cfc775525d6"), new Guid("5cc230da-917f-464e-8365-9b38877fc34b"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("af944b8d-b2da-40d6-8cc8-2884c34e6a07"), new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("b03e4a9e-5320-4780-8502-1ca14d15c553"), new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("b1db9b08-40c6-4551-b29c-be861bf22f06"), new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea"), "images/shoes/noimage.webp" },
                    { new Guid("b34b1784-0d66-4b95-bd61-e381f5e9cc82"), new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e"), "images/shoes/[IDGiay_9]_AnhChinh.jpg" },
                    { new Guid("b3822e86-d874-41cd-93aa-6e3336beae9e"), new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967"), "images/shoes/[IDGiay_16]_AnhChinh.png" },
                    { new Guid("b3b2b1da-54d9-4539-9b15-e21848d06475"), new Guid("890ffc69-b7af-4218-b457-b27abe752233"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("b5bf1ef9-cfe3-4970-86a9-1f49940ff58a"), new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("b6e15773-d14a-4eff-bd6c-a24998d8139f"), new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("b85229b0-9580-43b6-97e6-e3d65ea7ee46"), new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("b9257b94-0d2e-4801-9c9d-2ffe3ff23065"), new Guid("c54216f3-b68f-40d3-a269-55a008e1089b"), "images/shoes/noimage.webp" },
                    { new Guid("b93cb793-51fd-4a49-99ef-0d5e93bf1c4e"), new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("b9d67954-b97b-46f5-9537-01bd3ee900aa"), new Guid("ecc65355-5489-4368-8004-da6fe3240679"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("ba7ed994-230d-46bc-b5c4-964a57e5e99d"), new Guid("c3691ff1-3925-4044-89bb-dd2e03913060"), "images/shoes/noimage.webp" },
                    { new Guid("ba91cabf-0463-409e-bc3e-65e173880fa4"), new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca"), "images/shoes/noimage.webp" },
                    { new Guid("bb7c6f0f-baea-48f5-b07e-67853aa1fab6"), new Guid("5cc230da-917f-464e-8365-9b38877fc34b"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("bc63eac6-d7b6-40ae-abf0-f92fbad57aca"), new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), "images/shoes/[IDGiay_1]_AnhChinh.png" },
                    { new Guid("bc6b0efc-6015-40b6-a58c-9ad93343a44f"), new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d"), "images/shoes/[IDGiay_14]_AnhChinh.jpeg" },
                    { new Guid("bdcb9242-756a-439b-82b8-c9cfcbb1bd7c"), new Guid("890ffc69-b7af-4218-b457-b27abe752233"), "images/shoes/[IDGiay_15]_AnhChinh.jpeg" },
                    { new Guid("c0aa215c-6126-41ab-bdd3-0ee35018f537"), new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("c1d24375-2e0a-4675-b841-e65547bae920"), new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("c2cbfc64-a553-4079-bfd9-b1fc21133557"), new Guid("a4580586-dabc-474d-a130-8cad12e28efd"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("c65f2757-aceb-4fbe-8f8f-391b1168ae64"), new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("c7a37a72-e452-4f25-8504-fba1e466721a"), new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("ca9487c6-ab8e-4b3b-a680-22e9912c470d"), new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312"), "images/shoes/noimage.webp" },
                    { new Guid("cde8aafb-a02e-45e2-8fc4-cc5d3626409b"), new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("ce87c63e-16e9-44b0-9012-4b7e40e6e6cc"), new Guid("5cc230da-917f-464e-8365-9b38877fc34b"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("cf1f3429-cae1-4cc6-ae83-36fa5446640f"), new Guid("e37dd495-4ec8-40e6-85e9-217bed6a14df"), "images/shoes/noimage.webp" },
                    { new Guid("cf26f423-2912-4d27-bedf-481f7e580282"), new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171"), "images/shoes/noimage.webp" },
                    { new Guid("d0d031c7-7b29-4705-bcf9-4d34e190291c"), new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("d237cb28-14ef-4518-9832-3eb09ff62029"), new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("d2fec995-e44f-4a74-afbb-4824165575dd"), new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45"), "images/shoes/noimage.webp" },
                    { new Guid("d44ea27c-6bae-4927-99b7-f227c99cf89c"), new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("d4bc2b58-a00f-4f37-8685-d79173e86266"), new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("d64e300e-93bb-43d1-bc18-4d9dad86c89b"), new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("d6a82c91-77d2-4e9d-9791-baaa392a89cb"), new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087"), "images/shoes/[IDGiay_18]_AnhChinh.png" },
                    { new Guid("d862de50-b3ce-429b-9fd7-610b8ac4d84a"), new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("d997bea5-f700-42d4-b201-ee1c94740a82"), new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("dea1f46b-c2f2-49a8-a1fa-eb409cd802cc"), new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("dfbde253-64fa-4ad4-98b5-b2d2ddd1967f"), new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294"), "images/shoes/noimage.webp" },
                    { new Guid("dfdbb179-7cb4-48aa-b05f-4bcca543317f"), new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757"), "images/shoes/[IDGiay_19]_AnhChinh.png" },
                    { new Guid("e023f6a6-b530-4464-9607-2992d685dc17"), new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95"), "https://gossipdergi.com/wp-content/uploads/2021/04/nikeayakkabi.gif" },
                    { new Guid("e204295d-c8e8-4c86-896a-1e5ba5fa6f7b"), new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("e280644e-42bd-4cb8-919d-6fbb445212ac"), new Guid("ba9ca9a4-8dce-40ee-af75-475b27e20773"), "https://www.prosoccer.com/cdn/shop/files/PumaFuture7UltimateFGAG-ForeverFasterPack_SP24_Model1_1500x.png?v=1713488175" },
                    { new Guid("e2c80f50-f986-491f-9312-0b18e3abb383"), new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7"), "images/shoes/noimage.webp" },
                    { new Guid("e2cc5245-39bc-42a2-823f-5df1047c6ae9"), new Guid("ecc65355-5489-4368-8004-da6fe3240679"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("e78ba5ac-88d0-4e58-92ad-b9372ece02ee"), new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("e7b62f3b-18af-4754-a610-0948de144c31"), new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("ebee7949-0b3b-45fc-b983-a41410a3f432"), new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170"), "images/shoes/[IDGiay_2]_AnhChinh.png" },
                    { new Guid("edeb1bb5-8d78-4d34-97f6-5d0ecf705036"), new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), "images/shoes/[IDGiay_12]_AnhChinh.jpeg" },
                    { new Guid("eea38729-40de-45d5-aa24-77ddde6648a0"), new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("eec9e24d-437b-4728-9fc4-e69a40538d85"), new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("f0fc870d-f7c2-4fa2-8c82-4216bec8cc34"), new Guid("a4580586-dabc-474d-a130-8cad12e28efd"), "images/shoes/[IDGiay_4]_AnhChinh.jpeg" },
                    { new Guid("f143209d-15c3-40e9-b9a3-57d050ddd4ab"), new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("f2f662a9-f546-4761-aefa-a1df941e5ad5"), new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("fa9a7f0f-9480-4ce7-bc28-c690ae3535ef"), new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("fb4d5b65-0f65-4919-ad69-61bb39c39a44"), new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95"), "https://i.pinimg.com/originals/c0/cf/d1/c0cfd1545f10c56793e888e991b60487.png" },
                    { new Guid("fc34318d-b7df-4034-b4d2-769729d37555"), new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("fc6d4db1-85da-4a7e-8db2-4d1fcf38ed34"), new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("00b04eaa-854b-481b-82e3-3cd5414c46b9"), "Summer", new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2") },
                    { new Guid("01ee46eb-be36-465e-bed0-4e365d510517"), "Winter", new Guid("c05a001f-2a93-4b89-aefa-65277083c58b") },
                    { new Guid("050c7b78-7e57-46c8-b3f2-bcf9ae2284e3"), "Summer", new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7") },
                    { new Guid("089b6dc0-eb24-44c4-9e3e-cbfa26e91324"), "Spring", new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea") },
                    { new Guid("08e18e76-7871-4eb5-8449-73503b6fb919"), "Spring", new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88") },
                    { new Guid("09579021-c517-400d-8e93-c59efc3bea65"), "Winter", new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462") },
                    { new Guid("0aeb3a9c-4568-4718-9d60-bd52ba7b056e"), "Autumn", new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7") },
                    { new Guid("0b3fb871-4d79-4ebd-80c6-0a7d7fd28fb0"), "Winter", new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2") },
                    { new Guid("0b621b70-c035-4ea3-adb0-38fa2e5dcf88"), "Summer", new Guid("68425ec0-7343-4eda-ba44-de4aa5119190") },
                    { new Guid("0c134887-17a8-4a6c-8f27-7328fddb4c6a"), "Winter", new Guid("22963aac-57fb-4602-bfc0-d21547798aae") },
                    { new Guid("0cdc3eba-4457-4170-b171-935480b8dce3"), "Spring", new Guid("ecc65355-5489-4368-8004-da6fe3240679") },
                    { new Guid("0fe6d7e8-9f54-4304-99a2-5fd50f21fcdf"), "Spring", new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b") },
                    { new Guid("10ee85f1-5ac8-49c5-bae8-bb0b69cfd666"), "Spring", new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a") },
                    { new Guid("125436de-0be5-446f-9ce3-4762f8f5f271"), "Winter", new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7") },
                    { new Guid("13b0a789-0625-4a97-9a2c-866584e996c7"), "Spring", new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171") },
                    { new Guid("1655413f-bef6-4c4f-b76c-a880ac94f979"), "Summer", new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c") },
                    { new Guid("173f4867-b7d3-4352-8452-eccca764080c"), "Winter", new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c") },
                    { new Guid("1aa4deac-5b40-4b37-8197-67901fef4b40"), "Spring", new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294") },
                    { new Guid("1d51b1e0-a896-45c0-aec7-a1e98af4b537"), "Spring", new Guid("e2448e25-38f6-4fd5-8197-7d6572176836") },
                    { new Guid("22526b25-20c8-4ec0-9aa7-e27698a6e516"), "Summer", new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967") },
                    { new Guid("247d29d4-db41-454d-bec1-f4b978cbfa77"), "Winter", new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0") },
                    { new Guid("257078a0-9e5b-4751-aac1-9404713a5447"), "Spring", new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312") },
                    { new Guid("26c033ca-d460-4634-ab8d-4056eb3f4c1a"), "Spring", new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca") },
                    { new Guid("28495e9a-9ddb-4b2e-925c-4dbefc949147"), "Spring", new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e") },
                    { new Guid("2ca1546b-ddb3-4d4d-94ad-562b96b2a5ba"), "Spring", new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206") },
                    { new Guid("2d10b62e-e4e7-47ca-ae60-d37cfcec0903"), "Winter", new Guid("e37dd495-4ec8-40e6-85e9-217bed6a14df") },
                    { new Guid("2d41b79d-0718-445a-b360-1b64422f8ecf"), "Summer", new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087") },
                    { new Guid("2dea9572-f866-412e-aeee-2bb49a48930e"), "Spring", new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087") },
                    { new Guid("2e31762c-9496-419b-9fe6-b51f60cda6a0"), "Winter", new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7") },
                    { new Guid("2f0cf592-727f-4eff-bb27-1100d145e98f"), "Spring", new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d") },
                    { new Guid("2ff42d68-bebc-4e73-96bb-ae658f161653"), "Spring", new Guid("c3691ff1-3925-4044-89bb-dd2e03913060") },
                    { new Guid("305c6fef-f8e3-46db-b9cc-f3b7b79ee3f0"), "Spring", new Guid("7d5aaa86-5f96-4804-bd4f-84856744a28e") },
                    { new Guid("3156a5c2-83c7-4664-ab25-a13eba7a1be3"), "Spring", new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254") },
                    { new Guid("31625c61-164a-425a-aefc-9d35d51716e0"), "Winter", new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206") },
                    { new Guid("363bea71-3b93-4182-8f21-90c9eefd6225"), "Summer", new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7") },
                    { new Guid("38b6143c-6a65-4720-950c-37e1aa96fc57"), "Autumn", new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724") },
                    { new Guid("3968eb1c-1acf-4453-bd0a-1203fd12f82d"), "Spring", new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c") },
                    { new Guid("3b61c88c-aba3-4151-bd06-33b124d1df22"), "Spring", new Guid("a4580586-dabc-474d-a130-8cad12e28efd") },
                    { new Guid("3be05613-ff8e-4af5-ba1f-852f69eaa6be"), "Fall", new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170") },
                    { new Guid("3ce9715a-f004-47a8-a370-c53349ea8549"), "Autumn", new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae") },
                    { new Guid("3e76af5c-3f62-4e1d-ad5c-ecd85f92be59"), "Summer", new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e") },
                    { new Guid("459767f8-272e-421d-bc72-897d3be5b0a7"), "Autumn", new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206") },
                    { new Guid("50c54e3b-4f9f-4bbf-9c64-79382e8f41d9"), "Winter", new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312") },
                    { new Guid("516c1e78-690d-4c28-b1f2-e0bb2402e68c"), "Fall", new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e") },
                    { new Guid("52008d0b-f0c7-4c37-aa7c-56dbbc84f0d6"), "Spring", new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2") },
                    { new Guid("52e4a605-9a33-4f56-8b8f-79e89b445dca"), "Spring", new Guid("22963aac-57fb-4602-bfc0-d21547798aae") },
                    { new Guid("53c664ca-b62d-41e3-821f-15241ce5c8c9"), "Autumn", new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254") },
                    { new Guid("55ac2d72-6ead-458d-b124-6c4bd551535d"), "Autumn", new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171") },
                    { new Guid("56fbe8f1-1d18-4a45-acbe-081a7401cdf7"), "Summer", new Guid("ecc65355-5489-4368-8004-da6fe3240679") },
                    { new Guid("572466f6-6383-4aac-a96d-21848a95fa8a"), "Summer", new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197") },
                    { new Guid("57368ac6-8c07-4552-996d-2f7b8f0d3a11"), "Summer", new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae") },
                    { new Guid("585c6090-67cc-479e-ad24-fb7a05bf52d8"), "Summer", new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c") },
                    { new Guid("58af934d-1af5-4d80-b2b1-527118504e15"), "Autumn", new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312") },
                    { new Guid("5984b4a6-b2f5-4fda-a80a-7a3cdc34c01d"), "Spring", new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2") },
                    { new Guid("5a0055d1-f648-4ab2-ade4-2903e0c2689a"), "Autumn", new Guid("7d5aaa86-5f96-4804-bd4f-84856744a28e") },
                    { new Guid("5a99f841-e039-44a3-b523-b38e4b15feb6"), "Spring", new Guid("703dbd27-3273-4fc0-9141-0647bd53c414") },
                    { new Guid("5ad3b49e-4acd-428c-a54c-6179449ea718"), "Summer", new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36") },
                    { new Guid("5d98b629-88bf-4b89-b472-fddd6d1dcd8c"), "Winter", new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88") },
                    { new Guid("5dd955fb-3921-4cc1-95de-a60aac7581ab"), "Autumn", new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294") },
                    { new Guid("5dfbef2f-450c-4acb-874e-078b7c534247"), "Summer", new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521") },
                    { new Guid("61925f3a-e234-437d-952a-343fed81f2dd"), "Fall", new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95") },
                    { new Guid("628db7e8-12ea-403d-9a6e-4501741b5ef4"), "Spring", new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30") },
                    { new Guid("6abd309a-956d-4307-ac93-c16430b4b445"), "Autumn", new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88") },
                    { new Guid("6be070e7-cf25-4ece-9dca-a23effb640f5"), "Winter", new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c") },
                    { new Guid("6c4faa1c-30b8-45cf-a8f7-0ab35049c193"), "Spring", new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c") },
                    { new Guid("6d55c5cc-3a87-4189-a000-d50ef02e42c5"), "Winter", new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e") },
                    { new Guid("70704689-3c7f-4fce-93fb-3fc90f7941e6"), "Summer", new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170") },
                    { new Guid("70e9bc65-97b4-4b2e-b470-d88e99f65904"), "Autumn", new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c") },
                    { new Guid("72839f2e-4016-488b-917f-fe4868a63805"), "Fall", new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2") },
                    { new Guid("731744c0-2636-48d3-bd2f-5173bb1046dd"), "Winter", new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294") },
                    { new Guid("74378c25-3a5e-49a3-8d3e-4d7e8bbbfa71"), "Autumn", new Guid("22963aac-57fb-4602-bfc0-d21547798aae") },
                    { new Guid("753e705b-d7cd-4de7-b181-9fc30490ba33"), "Summer", new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00") },
                    { new Guid("7825ccda-739a-44da-a07b-430e326862b1"), "Summer", new Guid("c54216f3-b68f-40d3-a269-55a008e1089b") },
                    { new Guid("78da0316-a942-4fbd-a723-0d69ff6ddcfa"), "Spring", new Guid("890ffc69-b7af-4218-b457-b27abe752233") },
                    { new Guid("79045d50-b8db-4cf8-8974-32b7db1a4f22"), "Summer", new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a") },
                    { new Guid("79219c25-ec9b-4142-a160-e68f98256029"), "Winter", new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f") },
                    { new Guid("795abcd3-05bf-4340-8aab-462e279a8550"), "Autumn", new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c") },
                    { new Guid("7a75572e-0635-4c60-ba86-3207bbb8b423"), "Winter", new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170") },
                    { new Guid("7d860e2c-bf31-4b94-925d-9cda1ce321c7"), "Winter", new Guid("703dbd27-3273-4fc0-9141-0647bd53c414") },
                    { new Guid("7f1911a5-e700-45c4-8304-cf85a9549cb8"), "Summer", new Guid("a4580586-dabc-474d-a130-8cad12e28efd") },
                    { new Guid("7f484ed4-b591-4138-a610-83de140a4a94"), "Autumn", new Guid("c3691ff1-3925-4044-89bb-dd2e03913060") },
                    { new Guid("81127b7d-8742-4909-94de-c4260cff6a2d"), "Spring", new Guid("5cc230da-917f-464e-8365-9b38877fc34b") },
                    { new Guid("8231a21b-00a3-4c96-83ad-bf86582b6070"), "Fall", new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30") },
                    { new Guid("875855e8-59af-43fc-8677-0dc01497ce5a"), "Summer", new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723") },
                    { new Guid("8955de17-df76-4e65-b06e-44debeba43f9"), "Autumn", new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723") },
                    { new Guid("8c481833-b33d-422f-8653-08e9c38c81ed"), "Fall", new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5") },
                    { new Guid("8f30da63-42b8-4861-96f3-21a0ab828f87"), "Spring", new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95") },
                    { new Guid("9068be5e-19a1-41c6-b806-2e3ad6684af8"), "Summer", new Guid("c05a001f-2a93-4b89-aefa-65277083c58b") },
                    { new Guid("911936a1-8ee0-41bb-8103-3b55f09eed84"), "Fall", new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967") },
                    { new Guid("95908641-e964-49e6-8f94-61b128a3db98"), "Autumn", new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2") },
                    { new Guid("99c18101-42a8-411a-9fbe-4df330028cc7"), "Summer", new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312") },
                    { new Guid("9aaf4f1e-3497-49a0-9f46-0be4177c7a6e"), "Winter", new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521") },
                    { new Guid("9c0e9e41-6596-44ea-bfa7-d9b4abd4f94a"), "Winter", new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c") },
                    { new Guid("a048ca96-6144-49e1-8912-a3681193bf10"), "Summer", new Guid("e37dd495-4ec8-40e6-85e9-217bed6a14df") },
                    { new Guid("a22b272b-6d6a-493d-8b14-621eb3edc485"), "Winter", new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea") },
                    { new Guid("a29d2638-ad05-46f4-bab6-4264f34fc423"), "Summer", new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea") },
                    { new Guid("a37d159c-547e-474d-be42-a759e5432b8a"), "Spring", new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6") },
                    { new Guid("a4da1ff1-7310-44ff-94c3-3bf0f0f27b69"), "Summer", new Guid("703dbd27-3273-4fc0-9141-0647bd53c414") },
                    { new Guid("a54ddc40-dcad-431f-b66d-5220d36bc932"), "Autumn", new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3") },
                    { new Guid("a6d49ee8-dbc2-4a24-a23f-12f6e768a100"), "Fall", new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462") },
                    { new Guid("a7d5efe9-c1b1-4cad-a8bf-2ff74425f50f"), "Summer", new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3") },
                    { new Guid("a89dbd42-529a-4d41-ac93-3b39c0436c09"), "Winter", new Guid("ecc65355-5489-4368-8004-da6fe3240679") },
                    { new Guid("aac8978c-65f5-4376-88e9-003a357b8483"), "Autumn", new Guid("703dbd27-3273-4fc0-9141-0647bd53c414") },
                    { new Guid("ac8bb9d0-f154-41af-9daf-a0200132cd2d"), "Spring", new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724") },
                    { new Guid("ade5dd8a-d253-4a8a-9bcb-ef328a91b50a"), "Winter", new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca") },
                    { new Guid("ae083478-200d-41bc-b98f-e59361b44842"), "Spring", new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00") },
                    { new Guid("b06cf174-7021-47a1-ae72-0064506948e5"), "Summer", new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2") },
                    { new Guid("b21988de-ab1b-4dc9-a1bd-f98e25cc44b5"), "Winter", new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95") },
                    { new Guid("b504924c-d347-4358-a9c3-eb09527aee9f"), "Spring", new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7") },
                    { new Guid("b6981bba-3cee-4f6d-80b1-2de3056767e2"), "Summer", new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294") },
                    { new Guid("ba9d5497-e813-4dec-a989-eada3cd7d655"), "Spring", new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae") },
                    { new Guid("bc85023f-cb2c-4cce-8cfa-2d985b686f69"), "Winter", new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4") },
                    { new Guid("bca06f40-cb9c-41dd-a6ab-ea630ec1fdd6"), "Summer", new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171") },
                    { new Guid("bf258102-2af4-4044-b26a-e77047981756"), "Spring", new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3") },
                    { new Guid("c180dcd5-fd53-4548-a6cc-6e5b67d6afdf"), "Winter", new Guid("c3691ff1-3925-4044-89bb-dd2e03913060") },
                    { new Guid("c1bb5b80-dd54-4876-a5c7-d4c0e9e7caa7"), "Winter", new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967") },
                    { new Guid("c3dbdb9e-c063-4994-97d5-abd5afd47775"), "Winter", new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2") },
                    { new Guid("c5479e03-5706-4e55-8bcf-868ec35f463e"), "Summer", new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d") },
                    { new Guid("c76d8976-9e7a-4b0d-bec2-1221f908ec42"), "Winter", new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a") },
                    { new Guid("c8bf9017-e1ce-479a-b2fc-83d4c0802afe"), "Winter", new Guid("da812011-788d-4b76-8873-ecc88d25f1a9") },
                    { new Guid("ca09e715-6e43-4384-ac1d-b5a96189b47a"), "Spring", new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197") },
                    { new Guid("cbfe0ec1-79cb-48d4-88ce-21ed4982ed6a"), "Summer", new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0") },
                    { new Guid("ce5f47e7-071e-43b7-bb28-7b93614d8ce7"), "Winter", new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45") },
                    { new Guid("cf5fd88d-d23a-418e-88e4-1adbc97ad20a"), "Summer", new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724") },
                    { new Guid("cf8431f7-d6e8-4a5f-bf56-23f3c5395957"), "Spring", new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723") },
                    { new Guid("d164311d-cf19-470d-b6cd-906ea2be17aa"), "Spring", new Guid("da812011-788d-4b76-8873-ecc88d25f1a9") },
                    { new Guid("d1d77450-6354-4dcf-a4d5-d777c4fc2a32"), "Fall", new Guid("a4580586-dabc-474d-a130-8cad12e28efd") },
                    { new Guid("d43de453-d609-4a70-bacf-33e94de3f99f"), "Winter", new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae") },
                    { new Guid("d82e721e-bb3b-4caa-95c2-e0b5dd1b9831"), "Summer", new Guid("7d5aaa86-5f96-4804-bd4f-84856744a28e") },
                    { new Guid("d8a86ff1-af27-4b82-9c9e-f22d2b9eb2d9"), "Summer", new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206") },
                    { new Guid("db572d16-5f20-42a3-898a-0ce073398861"), "Spring", new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967") },
                    { new Guid("db9e428f-be79-4f98-93dd-360e5b8a7e90"), "Winter", new Guid("a4580586-dabc-474d-a130-8cad12e28efd") },
                    { new Guid("de9da683-886f-4941-9765-d18463a0a359"), "Winter", new Guid("c54216f3-b68f-40d3-a269-55a008e1089b") },
                    { new Guid("defe088c-25ec-4007-ae65-35dbcd2d8466"), "Autumn", new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521") },
                    { new Guid("e0b86fb7-28ac-4aa8-9b78-e025d1d67376"), "Autumn", new Guid("c54216f3-b68f-40d3-a269-55a008e1089b") },
                    { new Guid("eaf209ca-16ec-4c0d-a108-93192eb65144"), "Spring", new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45") },
                    { new Guid("ed61cffe-440b-414c-8133-bb37e7ea06d5"), "Winter", new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757") },
                    { new Guid("eea66904-62ac-4493-b2f2-e6aa2a08fe77"), "Summer", new Guid("c3691ff1-3925-4044-89bb-dd2e03913060") },
                    { new Guid("efa3fd74-6388-4142-ab10-b4db73440abc"), "Autumn", new Guid("e2448e25-38f6-4fd5-8197-7d6572176836") },
                    { new Guid("f023eba7-94f2-4ed1-8771-30a110c6eaff"), "Spring", new Guid("c54216f3-b68f-40d3-a269-55a008e1089b") },
                    { new Guid("f05e2e50-c9b2-4516-bb20-e44c8a9db163"), "Fall", new Guid("ecc65355-5489-4368-8004-da6fe3240679") },
                    { new Guid("f1764f33-ea9b-4d7d-9c04-b6167ebf44e6"), "Spring", new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c") },
                    { new Guid("f185eb22-12b9-4e3a-af75-3a870f44e7f6"), "Winter", new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e") },
                    { new Guid("f3578586-89d6-41ab-abf8-26d6b3335c2c"), "Summer", new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c") },
                    { new Guid("f6a0a672-5318-4ed6-83f7-a4e0b1c6bbd5"), "Summer", new Guid("22963aac-57fb-4602-bfc0-d21547798aae") },
                    { new Guid("f7668c82-19da-4c6b-833d-c5e7a671228a"), "Winter", new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724") },
                    { new Guid("fc1eaf6d-47ec-44b9-9ca6-93e99a4a7d4e"), "Autumn", new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea") },
                    { new Guid("fde3c046-edf5-47aa-a874-dc15214afd1b"), "Autumn", new Guid("c05a001f-2a93-4b89-aefa-65277083c58b") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("003e5d8b-dca1-4b5a-bf43-64de567b2383"), "Orange", new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae") },
                    { new Guid("005c0019-8624-4be6-8ac2-7f79dab277af"), "Purple", new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c") },
                    { new Guid("05a91a64-8b03-48f8-8025-7e127372067f"), "White", new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36") },
                    { new Guid("06bcad55-af99-4f60-a349-795fc5e848d8"), "Yellow", new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c") },
                    { new Guid("092e7245-5528-488d-96ed-dc1d2b925436"), "Black", new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170") },
                    { new Guid("0c4e3213-27e2-4f0a-a707-1544cbf11d02"), "Black", new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c") },
                    { new Guid("0d1906ff-3449-4f27-8f3c-658004381ed7"), "Blue", new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea") },
                    { new Guid("0d71b930-0362-4d75-928c-435e76dfd4d3"), "Red", new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95") },
                    { new Guid("0e9248d3-d80f-45a5-aba9-bf5f86341059"), "Yellow", new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45") },
                    { new Guid("0f0019ee-b06f-411c-b594-0e80fa78d22d"), "Green", new Guid("c3691ff1-3925-4044-89bb-dd2e03913060") },
                    { new Guid("100790a3-afcc-400c-a7dd-193f73ef9b5f"), "White", new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967") },
                    { new Guid("107afa14-3186-4394-82a9-45fbe22c7576"), "White", new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00") },
                    { new Guid("120d7f19-ccac-412a-b485-3aca2c53f99e"), "Orange", new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462") },
                    { new Guid("1240f3c3-f72a-401f-b24f-146ef50f390e"), "Pink", new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00") },
                    { new Guid("166bb5c7-5857-465b-8fb6-dcc916481388"), "White", new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170") },
                    { new Guid("185fba2d-0d50-428a-8e73-428d981ce958"), "White", new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462") },
                    { new Guid("1931c744-4616-41fd-bf59-589e6e3f7585"), "Black", new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312") },
                    { new Guid("1af385ec-6a2a-4ba5-b4ae-2f24dbc260bb"), "Green", new Guid("22963aac-57fb-4602-bfc0-d21547798aae") },
                    { new Guid("1b5ff555-d90b-4b0e-8efa-e8062b89305f"), "Green", new Guid("e2448e25-38f6-4fd5-8197-7d6572176836") },
                    { new Guid("1b7fb8ad-c26f-4e4c-b8bd-97ba7a0ffc90"), "Yellow", new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45") },
                    { new Guid("1d5f348a-3d12-4479-9565-0c590be3f2d7"), "Yellow", new Guid("c05a001f-2a93-4b89-aefa-65277083c58b") },
                    { new Guid("21920449-3ca9-486a-a7ee-3a1729719476"), "Orange", new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36") },
                    { new Guid("2a41722d-2915-4075-a967-ba7873f31dd5"), "Purple", new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea") },
                    { new Guid("2dc6ec93-65bc-43b7-b64c-8bf45e4651d3"), "Blue", new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4") },
                    { new Guid("2fffbfe8-2597-4295-a74c-530c917f070b"), "White", new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c") },
                    { new Guid("32297670-e6c6-4f48-a69d-50b842e10df5"), "Green", new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e") },
                    { new Guid("3a14f102-db67-4afa-a638-8b6292e46a90"), "Blue", new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36") },
                    { new Guid("3a2c093b-6834-45f4-855c-184c41c2f597"), "White", new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7") },
                    { new Guid("3d041a3e-26e4-40af-bfb6-276f712dda7b"), "Blue", new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a") },
                    { new Guid("4014ff33-5550-4059-b413-d8666578724a"), "White", new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7") },
                    { new Guid("417f5004-2d3f-4364-8df6-74e4ade451bb"), "Orange", new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5") },
                    { new Guid("41e0494c-6099-46ff-8639-d2e43fd834da"), "White", new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca") },
                    { new Guid("421e4ec8-cfc1-4d2e-8db1-2b4eafa94a21"), "Black", new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95") },
                    { new Guid("42d5d27c-d251-4d94-88d2-affe60d74ecd"), "White", new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757") },
                    { new Guid("43ed51cd-2a5f-450b-b8b9-5fa977e95cb7"), "Blue", new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f") },
                    { new Guid("47af583f-8ee6-41e5-a78e-e6d859949ac7"), "Black", new Guid("890ffc69-b7af-4218-b457-b27abe752233") },
                    { new Guid("4c3ab939-a59d-4de5-807d-a5e55b692eb1"), "Brown", new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30") },
                    { new Guid("4c5f551b-b415-41d8-b331-edb280c40100"), "Purple", new Guid("c3691ff1-3925-4044-89bb-dd2e03913060") },
                    { new Guid("504f785f-49f3-459d-8eb5-66cbcba25a05"), "Red", new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724") },
                    { new Guid("579c0b93-f018-472d-a15a-769dce1d587f"), "Yellow", new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254") },
                    { new Guid("583261c3-c2a1-4605-b1c2-65ea4c69bf73"), "Blue", new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88") },
                    { new Guid("586f1497-6b92-4799-a4cc-3cd3c80ab96b"), "White", new Guid("c54216f3-b68f-40d3-a269-55a008e1089b") },
                    { new Guid("58aa3a4e-c129-4b3b-9487-11ad7844a5e7"), "Purple", new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c") },
                    { new Guid("5c3309ae-a850-4660-a93a-b5c0909e58fb"), "Black", new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b") },
                    { new Guid("5faeea27-756d-437c-944e-673397b0320f"), "Black", new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e") },
                    { new Guid("5fd334f1-1977-4a0a-9cca-be36c2ee9b97"), "Black", new Guid("a4580586-dabc-474d-a130-8cad12e28efd") },
                    { new Guid("601b8f2c-a7a5-4738-b418-5c0678594bcf"), "White", new Guid("22963aac-57fb-4602-bfc0-d21547798aae") },
                    { new Guid("60d623d3-b8e1-418a-a78e-1e3c2a9013ea"), "Black", new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967") },
                    { new Guid("6208c3ee-f764-4618-98a6-087bf3062ad6"), "Green", new Guid("e37dd495-4ec8-40e6-85e9-217bed6a14df") },
                    { new Guid("62877bcd-9a8d-4c06-ab3b-d962d90cad90"), "Purple", new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca") },
                    { new Guid("6308e3af-c5e3-4ddf-b907-b0dbbe76646f"), "Red", new Guid("da812011-788d-4b76-8873-ecc88d25f1a9") },
                    { new Guid("6428ae15-b3d3-4bc9-b781-83e811b75e1f"), "Black", new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7") },
                    { new Guid("6505102e-7656-4d6a-80b8-54f0c309ba8f"), "Orange", new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7") },
                    { new Guid("6b8f47b4-71e8-489b-b0ef-a8bf01c87904"), "White", new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b") },
                    { new Guid("6ccbe869-9e59-4418-88d7-c594e7fe9c11"), "White", new Guid("890ffc69-b7af-4218-b457-b27abe752233") },
                    { new Guid("6dd5ea98-e522-4f58-9496-c4928065857c"), "Blue", new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170") },
                    { new Guid("701c07c6-7266-4fb5-a2e9-abfea4c70d7b"), "Red", new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2") },
                    { new Guid("71ffe527-c7bb-4473-a3f1-d493445a6e7c"), "Yellow", new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b") },
                    { new Guid("74249735-a297-4c3b-bb08-abe339916671"), "Blue", new Guid("c05a001f-2a93-4b89-aefa-65277083c58b") },
                    { new Guid("785d9f7f-54ae-42a7-baf6-89a23809a46f"), "Red", new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2") },
                    { new Guid("7a82ddd7-af2f-4b75-ae6d-4e0eafbf8aa0"), "Pink", new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b") },
                    { new Guid("7f4839e7-cc59-4526-ac4a-2d587d4bf6dc"), "Blue", new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197") },
                    { new Guid("81407385-7745-432f-a6c0-53576fdabe87"), "Black", new Guid("68425ec0-7343-4eda-ba44-de4aa5119190") },
                    { new Guid("81ea6c8f-9459-42f0-9caf-0a4fbf3695ff"), "Red", new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36") },
                    { new Guid("83926ccc-fa7e-4554-9eaf-333eb6760334"), "Red", new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170") },
                    { new Guid("8438d32e-65f2-427e-96e1-4070cd5b900c"), "Yellow", new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2") },
                    { new Guid("861a85ca-a9b9-43e2-a8bb-f0ddb7f341b9"), "White", new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197") },
                    { new Guid("862f8d5a-2f78-4250-b455-679a03f31c0b"), "Orange", new Guid("68425ec0-7343-4eda-ba44-de4aa5119190") },
                    { new Guid("88d6e6c9-1506-4165-b203-ed18396a7541"), "Red", new Guid("5cc230da-917f-464e-8365-9b38877fc34b") },
                    { new Guid("8ad13ea2-b3c7-467e-82c3-708921745b32"), "Brown", new Guid("a4580586-dabc-474d-a130-8cad12e28efd") },
                    { new Guid("8b434545-0c1c-404f-9487-ec928b68aa8f"), "Pink", new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4") },
                    { new Guid("8d310c38-6675-4a7a-8d8c-69ccfbe1f748"), "Purple", new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00") },
                    { new Guid("8e019a31-f88a-4ec5-b301-87a23787fd72"), "Orange", new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea") },
                    { new Guid("8e7b025a-a152-429a-b8ac-e44cb0f23098"), "Purple", new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5") },
                    { new Guid("8eb8e212-8f1f-4044-ab7e-08fa807ab507"), "Blue", new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087") },
                    { new Guid("8ec4232e-ee01-4460-9cd1-c3c3d45d1e8e"), "Orange", new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3") },
                    { new Guid("91768c39-05f6-40c1-9b25-3e6380cb086f"), "Blue", new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723") },
                    { new Guid("9292583f-f497-4700-9fa0-b340b6336521"), "Yellow", new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7") },
                    { new Guid("94eccffd-bc70-45b5-ad8c-8be367668d88"), "White", new Guid("22963aac-57fb-4602-bfc0-d21547798aae") },
                    { new Guid("9728044f-f535-4774-8010-16d2974ab363"), "Blue", new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b") },
                    { new Guid("979a105a-1844-43a1-87af-55a76afee8b1"), "Black", new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723") },
                    { new Guid("9cab58eb-471e-469b-bd39-20816792de34"), "Red", new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254") },
                    { new Guid("9e386455-caee-4e58-a0bc-e7620343fe06"), "Purple", new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45") },
                    { new Guid("9fb5c55d-438b-475b-9c39-8d3ffdb9ed6a"), "Yellow", new Guid("e2448e25-38f6-4fd5-8197-7d6572176836") },
                    { new Guid("9fc424f4-2069-45fd-b061-9f25e2bd2f70"), "Yellow", new Guid("c54216f3-b68f-40d3-a269-55a008e1089b") },
                    { new Guid("9ffc000e-63c3-467f-9ec9-f1b4b8f9b59b"), "Black", new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36") },
                    { new Guid("a273d80c-1877-4fd0-8b03-8d72ca077e44"), "Red", new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294") },
                    { new Guid("aa43174e-637c-4611-8833-b145a2840b93"), "Purple", new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197") },
                    { new Guid("ac20d05b-e006-4962-b267-eb5a49e80727"), "Purple", new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171") },
                    { new Guid("ac964fd0-7429-4654-8a1a-10468af69d37"), "Black", new Guid("ecc65355-5489-4368-8004-da6fe3240679") },
                    { new Guid("b1290f25-2d3c-4cb5-b3a1-f71e395deb15"), "Blue", new Guid("5cc230da-917f-464e-8365-9b38877fc34b") },
                    { new Guid("b1da7689-6324-47be-8cf4-ddd7c4bdcba7"), "Purple", new Guid("7d5aaa86-5f96-4804-bd4f-84856744a28e") },
                    { new Guid("b225d9ea-058b-4451-be51-042c55c92343"), "Black", new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e") },
                    { new Guid("b34343c7-6db5-4b61-8517-2e621ad81cdf"), "Black", new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00") },
                    { new Guid("b47b2083-5780-43db-8765-c40dde04caf6"), "Pink", new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d") },
                    { new Guid("b48bfad6-eac7-432d-9dd5-7d59d0118a58"), "White", new Guid("703dbd27-3273-4fc0-9141-0647bd53c414") },
                    { new Guid("b4ee915f-4485-4663-93cd-b3c46199afcc"), "White", new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca") },
                    { new Guid("b63dba1f-7834-4d29-8427-6da3cae49cf0"), "Blue", new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967") },
                    { new Guid("b8682f80-d775-4e39-9ee7-a50abe88241b"), "Purple", new Guid("e2448e25-38f6-4fd5-8197-7d6572176836") },
                    { new Guid("b9950b0c-d8cf-4378-a4fd-fc90de8708c7"), "Green", new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294") },
                    { new Guid("bba46c35-da5a-46eb-8383-aa3c1366bb7c"), "Black", new Guid("703dbd27-3273-4fc0-9141-0647bd53c414") },
                    { new Guid("be1b384e-ea07-43bf-8bad-7481d82618e7"), "Orange", new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2") },
                    { new Guid("c36a4df8-1f56-4922-9634-e6ca90ca7921"), "Blue", new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e") },
                    { new Guid("c4ca095f-dbe2-4ea9-830c-4cc6cdd8208e"), "Blue", new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c") },
                    { new Guid("c587abe2-7a5a-47d8-9853-9625b5c889fd"), "Orange", new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7") },
                    { new Guid("c9d3c2bc-bca0-40e1-9bb7-4da817e3b37d"), "White", new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30") },
                    { new Guid("cba28cd2-b02f-474c-b7cf-bcd975717f02"), "Yellow", new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206") },
                    { new Guid("cc519039-71b0-430c-a8af-546e2a0241ea"), "Purple", new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c") },
                    { new Guid("d35a78d1-3576-4341-81cc-78bacdd12e17"), "Orange", new Guid("da812011-788d-4b76-8873-ecc88d25f1a9") },
                    { new Guid("d4e3ae5e-7497-4e1d-921e-f5695ac81f47"), "Grey", new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967") },
                    { new Guid("d696c91b-41bf-4ec9-a0e4-3ce9a8a6e418"), "Green", new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36") },
                    { new Guid("d7c3e9d9-c566-4c1a-8df4-935128af31a6"), "White", new Guid("5cc230da-917f-464e-8365-9b38877fc34b") },
                    { new Guid("d9bd10ef-5f52-4bff-ad98-b192b44f104e"), "Red", new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521") },
                    { new Guid("dc6b0176-45f2-4cae-8209-d1433a7d4be6"), "Blue", new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171") },
                    { new Guid("e1f326e1-539a-4e8b-b539-75495fc6ca50"), "Pink", new Guid("5cc230da-917f-464e-8365-9b38877fc34b") },
                    { new Guid("e3e79999-75b4-4525-8303-f2520eef09fe"), "Brown", new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6") },
                    { new Guid("e675574e-fbe3-477c-a5cb-bf9812dc7b38"), "Black", new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197") },
                    { new Guid("e8456cd0-ce95-43f8-a191-bb3edf5d5a1e"), "Black", new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462") },
                    { new Guid("e9f88a6d-75d4-4667-858e-592c139c6d57"), "Green", new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6") },
                    { new Guid("eabca7b9-a684-440f-b74b-0a0e86f44171"), "Red", new Guid("c3691ff1-3925-4044-89bb-dd2e03913060") },
                    { new Guid("eb257e43-8779-4745-b7a4-9be4449e16d4"), "Yellow", new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724") },
                    { new Guid("f10a36ca-4309-4e78-b916-4fdcc1e6d15f"), "Yellow", new Guid("c54216f3-b68f-40d3-a269-55a008e1089b") },
                    { new Guid("f416c81e-af7e-41e7-ab0f-f5b8cc6cff6d"), "Black", new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521") },
                    { new Guid("f4a02c78-3698-48a4-a676-05dda26584c6"), "Green", new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206") },
                    { new Guid("f7829047-395a-45c1-bfb8-85f9baacf323"), "Purple", new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312") },
                    { new Guid("f883363f-8907-4276-b3a1-8d1e3e18063c"), "White", new Guid("703dbd27-3273-4fc0-9141-0647bd53c414") },
                    { new Guid("fb175427-09ce-4747-bfc4-a350f7209912"), "Black", new Guid("5cc230da-917f-464e-8365-9b38877fc34b") },
                    { new Guid("fba23026-502d-48d8-8b63-30c675886f23"), "Black", new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0") },
                    { new Guid("fbc6979a-2c48-4bb5-8b80-dbfb484e08a5"), "Purple", new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206") },
                    { new Guid("fd1b1dd1-20ff-42d4-bcc3-6c5f4ac2386e"), "White", new Guid("a4580586-dabc-474d-a130-8cad12e28efd") },
                    { new Guid("fe462af9-4ddb-4240-9e6d-fe6571e1dde4"), "Blue", new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("0232ba37-bc80-4ff1-9fb9-1a4a4a9429ac"), 32, new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c"), 43 },
                    { new Guid("02362370-2e22-4e82-ac4e-4d3f21778918"), 1, new Guid("22963aac-57fb-4602-bfc0-d21547798aae"), 45 },
                    { new Guid("029da90b-c2dc-4e45-aa25-f562bb93c2fb"), 4, new Guid("a4580586-dabc-474d-a130-8cad12e28efd"), 40 },
                    { new Guid("0343b029-553f-401b-b0eb-210e13875df9"), 38, new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), 44 },
                    { new Guid("0349e55e-12c9-4003-98d3-d86106a17f2e"), 46, new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), 45 },
                    { new Guid("0600bcff-d6aa-4253-a4d8-6664ed7d6c10"), 42, new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757"), 43 },
                    { new Guid("08aef8f7-9703-454c-a175-92650f431244"), 14, new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88"), 43 },
                    { new Guid("093db193-920d-44ad-b607-c233c83c1eec"), 39, new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757"), 42 },
                    { new Guid("0b341c00-1510-4dbb-88dd-107b1fbbf884"), 30, new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), 42 },
                    { new Guid("0cd8a816-b90d-4894-b423-eca7aa4a4fa5"), 17, new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7"), 41 },
                    { new Guid("0df53013-f551-4923-b25d-b755a6d22620"), 32, new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), 44 },
                    { new Guid("10101a82-4e85-4499-b8ab-23ee50354386"), 17, new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), 41 },
                    { new Guid("10c380b8-d1b7-4367-a0ec-ceac8e47e867"), 14, new Guid("ecc65355-5489-4368-8004-da6fe3240679"), 42 },
                    { new Guid("11801fb9-cf0f-46ef-a202-adac613071b2"), 31, new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), 44 },
                    { new Guid("11c0738b-c98e-4ca7-ab70-3ceb17f5b101"), 1, new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7"), 40 },
                    { new Guid("127023a4-6e31-44e2-8cd6-762a654f18ed"), 30, new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254"), 38 },
                    { new Guid("132a3dc7-dc98-418e-8cda-6941ab761753"), 4, new Guid("ecc65355-5489-4368-8004-da6fe3240679"), 41 },
                    { new Guid("13cc5090-3fd3-4a55-ba1d-5d452412fc37"), 1, new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3"), 41 },
                    { new Guid("13de4c3d-b3fd-4883-b8c2-ffceb1160a2b"), 42, new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d"), 45 },
                    { new Guid("159a1145-b4fb-417e-af01-cd9281be08ac"), 1, new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521"), 43 },
                    { new Guid("165bda33-6cb5-43b4-a4c4-a6f1c37f6e52"), 50, new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294"), 45 },
                    { new Guid("184998cf-f938-4741-9eef-85eb7623abfa"), 13, new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f"), 43 },
                    { new Guid("19b5796e-09a0-418a-8128-18fc8bd3b5db"), 1, new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca"), 41 },
                    { new Guid("1a9988aa-5cef-4141-bdb6-b36c5836e37b"), 45, new Guid("c05a001f-2a93-4b89-aefa-65277083c58b"), 39 },
                    { new Guid("1ab237a5-58dc-4e90-9850-36f7635c6e1c"), 29, new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), 43 },
                    { new Guid("1adbde64-9d77-4d91-b9b4-cac6ba992b36"), 0, new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0"), 41 },
                    { new Guid("1c26feb5-de6a-44c1-8516-8af577e4982c"), 53, new Guid("22963aac-57fb-4602-bfc0-d21547798aae"), 43 },
                    { new Guid("1cd21573-5d84-4a4f-9798-32109f659c51"), 4, new Guid("c3691ff1-3925-4044-89bb-dd2e03913060"), 41 },
                    { new Guid("1cd71beb-70f7-4a2e-a288-18b0fabe02f9"), 52, new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757"), 41 },
                    { new Guid("1d9da7cc-4204-4e20-855a-5e0e44cbccd5"), 37, new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254"), 37 },
                    { new Guid("1e0d945e-3921-43f6-985c-cd7046b896ea"), 21, new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae"), 42 },
                    { new Guid("1ec3cd79-fa69-4ae2-8c99-5f5d6b718946"), 32, new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171"), 39 },
                    { new Guid("1ee53677-2aa4-4a18-9210-2296e100aa5c"), 41, new Guid("c3691ff1-3925-4044-89bb-dd2e03913060"), 38 },
                    { new Guid("1f113200-3870-4997-8690-b4cee72bac35"), 40, new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), 43 },
                    { new Guid("1f8018ab-b1f1-4dbb-a2de-53ebd94b1a08"), 46, new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170"), 41 },
                    { new Guid("2031755b-9062-44cb-a836-a6e75872dc5f"), 15, new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723"), 41 },
                    { new Guid("21a2be09-1650-4592-be62-8880af040a79"), 30, new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e"), 40 },
                    { new Guid("2347bfd4-b523-4f29-a4ff-1de0c4da5bb3"), 12, new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30"), 40 },
                    { new Guid("258840fd-2aeb-4b79-b8ea-8a8ea99c703b"), 3, new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967"), 39 },
                    { new Guid("25cc1fa2-0874-4d70-88b1-e4dcdb50db5a"), 39, new Guid("ecc65355-5489-4368-8004-da6fe3240679"), 40 },
                    { new Guid("26b61dfc-9ad7-40ca-8f6f-4f68039132c6"), 39, new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521"), 44 },
                    { new Guid("26f0c070-f351-47a5-bd85-2647468d6240"), 0, new Guid("c3691ff1-3925-4044-89bb-dd2e03913060"), 37 },
                    { new Guid("278353f3-fbef-4b54-ab83-b87f1b75c01a"), 33, new Guid("22963aac-57fb-4602-bfc0-d21547798aae"), 42 },
                    { new Guid("283e4317-f4f5-40a7-8944-36b32d94dcc3"), 27, new Guid("ff206bc4-1581-40f1-a709-eaa3555c47f4"), 42 },
                    { new Guid("2a275da0-396c-4b19-bbca-d2cc698ff0c1"), 34, new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea"), 41 },
                    { new Guid("2b14cb06-9799-4fa9-be52-664967304845"), 44, new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294"), 42 },
                    { new Guid("2c096cf3-0c56-49f0-a56e-04e07c77d571"), 10, new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462"), 41 },
                    { new Guid("2c493b6f-6d73-4484-afa5-b1880561091f"), 12, new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2"), 43 },
                    { new Guid("2c8f139d-2b3f-4349-98c6-3ae6b24de4a9"), 16, new Guid("c54216f3-b68f-40d3-a269-55a008e1089b"), 43 },
                    { new Guid("2ceee96c-5c13-4166-a25e-38ae9f961547"), 34, new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6"), 38 },
                    { new Guid("2e75c8a5-40bd-42ee-a05e-653813ef91e6"), 25, new Guid("7d5aaa86-5f96-4804-bd4f-84856744a28e"), 37 },
                    { new Guid("32c29ca5-67d2-40dd-b419-4c94bdfb8790"), 32, new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae"), 43 },
                    { new Guid("33306327-94a4-4325-8fd3-f2b44d1f1d8d"), 14, new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171"), 41 },
                    { new Guid("33ae91ab-7509-4f9a-908a-5974db3d2a9d"), 11, new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724"), 39 },
                    { new Guid("34c8ae8b-4d0b-4f28-8ab1-31c520b84064"), 52, new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2"), 42 },
                    { new Guid("364cea11-6337-4c39-a045-114b3b47762f"), 35, new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087"), 45 },
                    { new Guid("36a5cd3f-6102-4e6b-a9a5-73402cfc8e71"), 5, new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087"), 44 },
                    { new Guid("36be30d1-3074-4424-946a-3c3463544c2b"), 18, new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6"), 39 },
                    { new Guid("3713de4f-bc4a-4b40-8dc1-728aa0c5b304"), 25, new Guid("c05a001f-2a93-4b89-aefa-65277083c58b"), 38 },
                    { new Guid("373ba27b-5619-413c-8e77-093684a1f155"), 5, new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7"), 43 },
                    { new Guid("3a312462-2670-4bd4-91cb-47c97a2dca59"), 47, new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206"), 44 },
                    { new Guid("3bd55674-e4d7-4078-b008-f2de98c7b96d"), 8, new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c"), 41 },
                    { new Guid("3caa4808-1ad2-43a7-a9c0-67e85e60d016"), 29, new Guid("ecc65355-5489-4368-8004-da6fe3240679"), 38 },
                    { new Guid("3e1fbd8c-b4b7-49b9-859e-b1fa0b1753ab"), 46, new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462"), 40 },
                    { new Guid("3f6b049e-9386-4b83-bdb8-8d2a25125dc3"), 7, new Guid("703dbd27-3273-4fc0-9141-0647bd53c414"), 42 },
                    { new Guid("404f5eb7-7b38-4052-9ea1-ed08d528d3d9"), 30, new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087"), 43 },
                    { new Guid("41a48408-9bfd-481b-81bb-7a4e57ae92ea"), 41, new Guid("22963aac-57fb-4602-bfc0-d21547798aae"), 46 },
                    { new Guid("42429782-d58d-4346-8838-d774c2b2d9b4"), 54, new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d"), 44 },
                    { new Guid("42f69b18-bd14-43d4-b664-089791cd98e6"), 16, new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d"), 42 },
                    { new Guid("43081c57-5fa7-48c4-aa2c-4a13de135f66"), 29, new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2"), 44 },
                    { new Guid("45bb61f1-f50d-47f4-adfc-5bc028670dcb"), 21, new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7"), 38 },
                    { new Guid("4681303b-351c-4cbb-8da6-e703b4fe2f9e"), 23, new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), 40 },
                    { new Guid("46d58b8e-7ece-44ce-b91a-eeae5adb36e4"), 6, new Guid("7d5aaa86-5f96-4804-bd4f-84856744a28e"), 39 },
                    { new Guid("49ffe0f4-bfec-40ea-845f-2e0e853391f8"), 3, new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2"), 45 },
                    { new Guid("4a1b41b6-494a-4d17-bf32-0939778b5a07"), 6, new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00"), 42 },
                    { new Guid("4a4d0cfa-5b7b-4566-8d64-da708c76c448"), 5, new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88"), 41 },
                    { new Guid("4b212da6-ee9e-4e53-b688-3e8161ef0e77"), 24, new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312"), 42 },
                    { new Guid("4b2c5efe-150e-4f63-907b-026cd4c321ba"), 21, new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2"), 44 },
                    { new Guid("4b7c9983-5f80-4dd7-b11a-8ee3f3e62e09"), 50, new Guid("703dbd27-3273-4fc0-9141-0647bd53c414"), 39 },
                    { new Guid("4c0dc823-a7b5-447e-a291-c3ec99c8e707"), 12, new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723"), 43 },
                    { new Guid("4d052efe-e8d2-45c2-aff0-072fee7372a0"), 14, new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88"), 44 },
                    { new Guid("4d2f609d-f6bc-4f69-a2b0-75b9b0d73d64"), 34, new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), 42 },
                    { new Guid("4e3e351f-ee2d-455c-94b8-8738c9fc4c23"), 51, new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea"), 44 },
                    { new Guid("505d756c-9cde-45b4-b7c7-0b15f1cc30f7"), 11, new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967"), 41 },
                    { new Guid("51bb1b57-35f0-4409-8bbd-ebfa405bfa50"), 13, new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), 41 },
                    { new Guid("51c393cc-0c60-4b2e-9075-cf5a7ccaad1b"), 3, new Guid("5cc230da-917f-464e-8365-9b38877fc34b"), 39 },
                    { new Guid("523d9769-e51e-48ef-8b6f-edea036f550a"), 41, new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45"), 41 },
                    { new Guid("52f5d034-4c36-48cf-b12f-6e222e1ed738"), 34, new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), 40 },
                    { new Guid("53a49478-87a5-46c7-8e13-c8a5c8311d44"), 13, new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c"), 44 },
                    { new Guid("5453ff5e-3d00-4006-9faf-b3d43dc3176d"), 12, new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7"), 37 },
                    { new Guid("550988ca-0264-4aa2-b499-1f2b878f1bec"), 35, new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), 42 },
                    { new Guid("56b4e0f6-402a-4418-ae08-8a27ed2efee7"), 11, new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170"), 42 },
                    { new Guid("58c69df0-308d-4bc7-9796-af8972483186"), 12, new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724"), 42 },
                    { new Guid("59d1a099-a21e-46fb-9311-a90962f118ff"), 45, new Guid("e37dd495-4ec8-40e6-85e9-217bed6a14df"), 40 },
                    { new Guid("5acf7504-fe45-48d7-bc8f-7e0048e8d396"), 36, new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea"), 42 },
                    { new Guid("5bba7290-7081-45fb-b84e-4553ba43bba7"), 39, new Guid("da812011-788d-4b76-8873-ecc88d25f1a9"), 40 },
                    { new Guid("5c24cf82-d048-4d5c-ac47-35d7325c3bcb"), 28, new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7"), 44 },
                    { new Guid("5f43fb71-1c0e-4cf9-840e-31cdd99d17a0"), 52, new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00"), 39 },
                    { new Guid("607a0408-84e6-4f7c-84e8-d4c592fd6e2e"), 1, new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), 45 },
                    { new Guid("6120bcbe-03fe-482b-baf4-900d6a23d3b7"), 22, new Guid("68425ec0-7343-4eda-ba44-de4aa5119190"), 43 },
                    { new Guid("61419142-edd8-420a-a722-0214f4f8b6f4"), 26, new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95"), 41 },
                    { new Guid("62e48413-1e60-49fd-b135-870f8486c14a"), 11, new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e"), 41 },
                    { new Guid("634d4c76-6a67-48b1-9ac6-1b96db04cbca"), 7, new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171"), 42 },
                    { new Guid("63643f88-293f-4b14-bf6e-2abc60405d99"), 34, new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), 41 },
                    { new Guid("63fdb1b3-9cd1-4404-8ca9-886a0a38d6d8"), 10, new Guid("a4580586-dabc-474d-a130-8cad12e28efd"), 39 },
                    { new Guid("69508f9e-4515-4f59-ba0d-0c08230438de"), 47, new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171"), 38 },
                    { new Guid("6a7e8a12-3c1e-437e-bd1a-a85146972bac"), 10, new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), 43 },
                    { new Guid("6ac01ab9-a723-4333-baa2-fe7798564165"), 38, new Guid("c05a001f-2a93-4b89-aefa-65277083c58b"), 40 },
                    { new Guid("6b760df4-b085-4105-8e10-3d6cc84b61c8"), 53, new Guid("ecc65355-5489-4368-8004-da6fe3240679"), 39 },
                    { new Guid("6c52c8bb-7764-4d9e-b527-29186f84910f"), 28, new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f"), 40 },
                    { new Guid("6d29dbfc-0549-4fdd-bc18-2b0545582d58"), 30, new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae"), 41 },
                    { new Guid("6f2778aa-ce12-43e7-bab7-b4e277feb20e"), 22, new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294"), 46 },
                    { new Guid("6ffb3543-0081-432b-a0f7-329bbf7ce6c8"), 33, new Guid("c05a001f-2a93-4b89-aefa-65277083c58b"), 41 },
                    { new Guid("701b65a3-f345-40a2-a7d6-d19ffde59743"), 27, new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3"), 38 },
                    { new Guid("7365671f-ac4a-45d0-a9d1-cb5a885c57a9"), 53, new Guid("c3691ff1-3925-4044-89bb-dd2e03913060"), 40 },
                    { new Guid("739d8eaf-67a3-4a20-8932-ccc58e48d24e"), 38, new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), 44 },
                    { new Guid("73b78814-3bf0-4e56-935e-d7d8cf7b9add"), 46, new Guid("e2448e25-38f6-4fd5-8197-7d6572176836"), 41 },
                    { new Guid("73c2e6eb-1860-4723-9c12-a345b7eac23b"), 43, new Guid("e37dd495-4ec8-40e6-85e9-217bed6a14df"), 42 },
                    { new Guid("753fbedb-fa4b-4aed-aee6-a0904c65b9c2"), 7, new Guid("a4580586-dabc-474d-a130-8cad12e28efd"), 38 },
                    { new Guid("7556bd83-8639-454e-9b4a-77a8e0c5f10b"), 7, new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88"), 45 },
                    { new Guid("758d2eef-2580-44fb-beb5-558eb5957e7b"), 21, new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312"), 43 },
                    { new Guid("76fab3b6-845d-470c-98ef-8b3f5bc000c2"), 34, new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), 46 },
                    { new Guid("775c831c-ee57-4ed4-b81f-6f9f28d5be95"), 2, new Guid("890ffc69-b7af-4218-b457-b27abe752233"), 37 },
                    { new Guid("77d1b37c-6395-43a4-b479-d5a9f68f5f4f"), 54, new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724"), 41 },
                    { new Guid("7a55418e-1fe7-45e0-bf17-abb2e09f910b"), 13, new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f"), 41 },
                    { new Guid("7be268dc-9239-4a7c-8509-862637305c11"), 16, new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), 43 },
                    { new Guid("7cca0a8c-195e-4969-b77e-662427867638"), 0, new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), 37 },
                    { new Guid("7cf3f5ce-175d-469b-8331-298659187eed"), 26, new Guid("e37dd495-4ec8-40e6-85e9-217bed6a14df"), 41 },
                    { new Guid("7e674ba0-f4bb-4be1-81ed-4b30bfd5b9fb"), 34, new Guid("5cc230da-917f-464e-8365-9b38877fc34b"), 37 },
                    { new Guid("80609849-ec72-4742-a3ad-522bbe8d371a"), 35, new Guid("622580d4-8558-401a-9ed6-1b3e1dde8087"), 42 },
                    { new Guid("80d716cd-d9aa-4915-8696-f5b3797419b2"), 43, new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), 37 },
                    { new Guid("812b3355-3a3a-4fe3-af25-0c2ed2a7a25b"), 48, new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0"), 38 },
                    { new Guid("81bb372d-c328-4468-9035-53d59df1be93"), 38, new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), 39 },
                    { new Guid("82a4b2ca-5b4a-4f6f-9a28-c451730415be"), 50, new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca"), 40 },
                    { new Guid("85468b04-fbe6-42e8-933a-32d95ea48ca3"), 47, new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45"), 40 },
                    { new Guid("8610776a-f181-47aa-accf-53e6dfacf553"), 6, new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7"), 42 },
                    { new Guid("87747615-fded-4a6a-a5bc-4af90c7d4cb4"), 0, new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170"), 44 },
                    { new Guid("880b4b88-7c2f-4cdd-87ff-ce323db038aa"), 35, new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), 45 },
                    { new Guid("88fcff83-7690-44aa-842c-2ed245440192"), 25, new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c"), 38 },
                    { new Guid("89819a5f-66aa-4553-8f64-351287e1b26e"), 36, new Guid("703dbd27-3273-4fc0-9141-0647bd53c414"), 43 },
                    { new Guid("89f3bfb8-7078-4ac5-ae24-3e363d71e297"), 33, new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae"), 40 },
                    { new Guid("8a1cb823-4920-46a8-88e2-fc4610be9ecf"), 22, new Guid("a4580586-dabc-474d-a130-8cad12e28efd"), 37 },
                    { new Guid("8b0c09f7-adc9-4c67-95b4-b33b256c7186"), 15, new Guid("da812011-788d-4b76-8873-ecc88d25f1a9"), 37 },
                    { new Guid("8b94c0ba-127c-4953-a33f-74e63c0169be"), 41, new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30"), 41 },
                    { new Guid("8cdbc34c-5687-4b7a-aeec-f8c5e949cdb1"), 44, new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca"), 39 },
                    { new Guid("8e3314eb-167f-4270-b6fa-01d74e694507"), 2, new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), 38 },
                    { new Guid("8e92dcd9-da91-47cd-8ebb-97980abcad15"), 42, new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294"), 43 },
                    { new Guid("900595ac-c053-4e7e-9ccc-124fa9391c81"), 27, new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6"), 40 },
                    { new Guid("9035537d-9185-4607-8314-8c99e0b99fae"), 18, new Guid("03044298-fd42-4b1c-aeb4-5eb31744b5a7"), 40 },
                    { new Guid("90452c5b-44d1-420f-b3da-28b86c4846a4"), 47, new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254"), 41 },
                    { new Guid("90cb1bf9-c609-48c5-ad18-0867bb409220"), 39, new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3"), 39 },
                    { new Guid("923669ab-9c15-4904-821f-ddefd82d753e"), 31, new Guid("b687c71d-af2c-43a6-8ed7-903476b6dbf2"), 41 },
                    { new Guid("923da7bb-c553-421a-86ba-0a1e47a93814"), 10, new Guid("da812011-788d-4b76-8873-ecc88d25f1a9"), 38 },
                    { new Guid("92833db0-d297-4b7a-8579-d0996c9d899e"), 31, new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c"), 37 },
                    { new Guid("92a8493d-94ed-4878-9aad-ccd1e0bf721c"), 33, new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c"), 41 },
                    { new Guid("948cfafb-c9d8-45ec-b6cc-79aa089667aa"), 3, new Guid("0086ae4f-aef8-4ed0-828e-49f6725ce76d"), 43 },
                    { new Guid("994f6c91-b75f-46c6-a6a0-20c922835695"), 45, new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723"), 42 },
                    { new Guid("9a557223-1c17-449a-a099-4c890efdffca"), 6, new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30"), 39 },
                    { new Guid("9b85f1aa-1fba-4c71-9ea1-694051a46571"), 19, new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), 39 },
                    { new Guid("9dc0f2fa-195c-4a08-8b18-061dc9beeb35"), 4, new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7"), 39 },
                    { new Guid("9ea0e075-1dd2-4953-a915-50fe721ae299"), 6, new Guid("b4cd49d1-b6f5-44b6-90e7-ed6598039aae"), 39 },
                    { new Guid("9ed8491f-fdad-4580-ada9-b7ce261d235c"), 9, new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2"), 43 },
                    { new Guid("a1313253-a89f-4961-b893-bb869b5fbca4"), 43, new Guid("890ffc69-b7af-4218-b457-b27abe752233"), 39 },
                    { new Guid("a1b50f08-86fc-4ec4-b716-0b48e5a9fa96"), 50, new Guid("b0d5868f-35a4-4242-87ed-beb210fc28f7"), 41 },
                    { new Guid("a27e758d-d170-4f5a-93d4-70cbe2a8eb66"), 40, new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0"), 39 },
                    { new Guid("a3a82657-8478-49fc-bb82-e12c638e9a3e"), 32, new Guid("6b9f5df4-c9a0-4d0c-a346-6a9050739294"), 44 },
                    { new Guid("a402d239-e70e-4ee0-a78a-ee3d7ec0ab47"), 23, new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), 41 },
                    { new Guid("a49a8ddd-ace0-4615-b802-ee4431deaf64"), 33, new Guid("a4d6ec19-e240-40fa-97a3-ed3cd10b8a0f"), 42 },
                    { new Guid("a76d89ed-d3e5-4039-a62f-03b436e20b54"), 10, new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e"), 39 },
                    { new Guid("a8154678-21a7-4d69-9f47-f023bfd5c627"), 22, new Guid("7d5aaa86-5f96-4804-bd4f-84856744a28e"), 40 },
                    { new Guid("a85564ff-73af-489f-8d57-189b922dc7c7"), 40, new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206"), 42 },
                    { new Guid("a9664e90-05d5-45f4-a2b4-9224e3daeba6"), 14, new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2"), 41 },
                    { new Guid("ac0082cb-5d51-4c12-b6b8-8bf97c0ac305"), 8, new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c"), 42 },
                    { new Guid("acd89604-c1f3-4705-921f-0b6d7a52294e"), 14, new Guid("c54216f3-b68f-40d3-a269-55a008e1089b"), 44 },
                    { new Guid("ad8c7a34-c3e3-4500-b572-37aefa625401"), 50, new Guid("7d5aaa86-5f96-4804-bd4f-84856744a28e"), 38 },
                    { new Guid("ae70f54d-e877-48e8-82f8-a41ab64a272b"), 35, new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), 40 },
                    { new Guid("af72fba8-a2a8-4ca3-8be8-13530a2c32c0"), 25, new Guid("9829ba2b-5c9d-4c5e-9b1b-dd87fe8f61e6"), 37 },
                    { new Guid("b0292ab4-d27d-43b8-9e0e-8d793b5a9d54"), 10, new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462"), 42 },
                    { new Guid("b072eb52-a189-4162-aaa3-bad6d97fe89f"), 24, new Guid("da812011-788d-4b76-8873-ecc88d25f1a9"), 39 },
                    { new Guid("b0f47f55-3ff9-47f3-8142-4bd1b835e95c"), 4, new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312"), 40 },
                    { new Guid("b51d7850-175a-4135-be44-c7ac281dba91"), 45, new Guid("547533a2-07af-4994-b20b-ea3adc8ab2a0"), 40 },
                    { new Guid("b8539b55-510f-4bb6-9e59-489724661072"), 43, new Guid("a631bcc6-7060-4a4a-b404-cdb1f1ff4171"), 40 },
                    { new Guid("b88a9384-c594-4c1d-b8ab-09066416140a"), 45, new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967"), 40 },
                    { new Guid("b8af8b22-0a81-402e-a678-a8d480af806b"), 26, new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), 45 },
                    { new Guid("b9644ced-bf3c-4fd2-b52d-b29c44582097"), 44, new Guid("2beb35e9-3a34-4c49-a77a-fd479648d724"), 40 },
                    { new Guid("b96ee972-4a7a-4a37-aea2-6c73cc8e2afe"), 33, new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723"), 39 },
                    { new Guid("baa6c83b-fc6b-45a8-b520-862aed060588"), 47, new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), 38 },
                    { new Guid("bc074244-dcc9-44a6-9f4e-f7b1e6bc0547"), 21, new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), 39 },
                    { new Guid("bc674224-fdf4-4d9e-b715-1d22adc3b2df"), 9, new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c"), 40 },
                    { new Guid("bcfc6e90-0c6f-4bdc-90d6-4c18e1cef158"), 39, new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c"), 38 },
                    { new Guid("bd6d3727-c89e-41a1-b058-613cf93e2550"), 51, new Guid("d43f8e2b-dcbe-4d02-80b2-0be5ef73fd30"), 38 },
                    { new Guid("be07f983-6577-4d2f-8db4-8da11d3f700b"), 34, new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c"), 39 },
                    { new Guid("c1d6c680-b9ff-40c7-82d0-377c6e515d77"), 26, new Guid("890ffc69-b7af-4218-b457-b27abe752233"), 38 },
                    { new Guid("c4b3a78f-2131-4907-92b0-8bdc87c716da"), 44, new Guid("01b34bb0-d68e-4e2b-9a46-5cab6cde20ea"), 43 },
                    { new Guid("c4f45992-ae07-49bf-8812-ac3e94d1c8f5"), 7, new Guid("9f6a44f8-4e1a-48ee-80e2-8618f3473c5e"), 38 },
                    { new Guid("c5cfad85-27c4-4710-9c99-4b2ff29157a0"), 50, new Guid("c54216f3-b68f-40d3-a269-55a008e1089b"), 41 },
                    { new Guid("c683def2-84a6-4a14-aa2b-95b3ca3e5fb9"), 52, new Guid("c54216f3-b68f-40d3-a269-55a008e1089b"), 42 },
                    { new Guid("c6acd740-6156-4294-85dc-43ffa4f5c760"), 10, new Guid("703dbd27-3273-4fc0-9141-0647bd53c414"), 40 },
                    { new Guid("c6eba448-b80c-493a-8dac-9eb3214a9896"), 39, new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95"), 42 },
                    { new Guid("c7317b2f-381b-4076-b8b0-87b2334f14ad"), 20, new Guid("5cc230da-917f-464e-8365-9b38877fc34b"), 40 },
                    { new Guid("c77dd0f8-9d35-4cc8-82aa-82e90e5df843"), 25, new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521"), 45 },
                    { new Guid("cc2305b1-2a3e-4350-84b7-eab8397d6601"), 0, new Guid("e3385c8f-8f20-4fcc-8204-f0e5baa6d723"), 40 },
                    { new Guid("ccefc8c4-aea1-42c0-bfef-3966b8452b88"), 49, new Guid("e37dd495-4ec8-40e6-85e9-217bed6a14df"), 39 },
                    { new Guid("cdc7c802-1928-4ec9-a134-6e1f6a1e051c"), 18, new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95"), 40 },
                    { new Guid("cedc7d74-f4a3-487d-b1f4-ac0a1bf9335f"), 41, new Guid("e2448e25-38f6-4fd5-8197-7d6572176836"), 39 },
                    { new Guid("d21cdcec-f8e8-4e56-b613-ec6b5afd1c81"), 52, new Guid("eeae75f3-e374-41e8-87bf-73970a6ba757"), 40 },
                    { new Guid("d286f7ca-1462-459e-9f3a-6ccfedcd8852"), 14, new Guid("5cc230da-917f-464e-8365-9b38877fc34b"), 38 },
                    { new Guid("d2f018e7-ddd4-4780-9764-3e81c1d502aa"), 4, new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254"), 39 },
                    { new Guid("d3b63e5b-0242-4205-822e-9bb7dab38954"), 21, new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45"), 38 },
                    { new Guid("d49ad440-605f-49c1-afbb-7c09ce23eb16"), 1, new Guid("4e7f6c13-8ab6-4a65-8441-6b6772857967"), 42 },
                    { new Guid("d4c75045-9e76-4872-ac62-fbef819e406b"), 14, new Guid("e2448e25-38f6-4fd5-8197-7d6572176836"), 42 },
                    { new Guid("d5531ccd-b1e6-4877-91a3-afe045cf74b2"), 6, new Guid("890ffc69-b7af-4218-b457-b27abe752233"), 40 },
                    { new Guid("d55d3f2f-7f84-436e-9e73-bbcd3486753d"), 36, new Guid("f0a494f3-b1d1-4f99-bfb6-50423b55f254"), 40 },
                    { new Guid("d6ee6a75-c55b-4c6f-b9a9-287a05b96a40"), 9, new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), 45 },
                    { new Guid("d95bd5fc-63f3-4af0-9e39-7fc6e98bc860"), 52, new Guid("5e660a8d-a647-49ac-adf5-dcf8d6761c45"), 39 },
                    { new Guid("d9be6b2e-143d-4aa0-8412-9c94e5aec792"), 16, new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3"), 40 },
                    { new Guid("d9e1a09e-6faf-4da0-8cdc-8e6147b8e83e"), 21, new Guid("860ee977-1126-4a9b-b990-da9e3d64f91b"), 42 },
                    { new Guid("d9f13583-da81-4b9d-b5c9-014de888db4f"), 30, new Guid("44fec708-a5f0-4131-bc19-d6ff0a524c2a"), 41 },
                    { new Guid("da8a18d8-c5fc-4094-9e50-14c7d593473e"), 6, new Guid("d0f6bb59-fe3a-4448-9bab-40e0146b98d3"), 37 },
                    { new Guid("daf809e6-b058-4853-bbdb-e406c50fbae1"), 10, new Guid("703dbd27-3273-4fc0-9141-0647bd53c414"), 41 },
                    { new Guid("dea8d474-33ef-440e-a61d-bcf931f139a2"), 14, new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00"), 40 },
                    { new Guid("e20e8aa6-128f-4102-9cea-df2d1e87837b"), 23, new Guid("c2c2a7f4-eb73-4af6-b0f2-3cf689ea4312"), 41 },
                    { new Guid("e215d555-6db7-45b5-ae19-c8552411977d"), 37, new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206"), 43 },
                    { new Guid("e343b4e3-2486-4829-b686-6b1b76c93c95"), 39, new Guid("664f4a58-b338-44e9-8320-bcc9e0e8c170"), 43 },
                    { new Guid("e37d9876-6e21-4c98-8ac0-b204b0f52d72"), 38, new Guid("ba645a04-03d3-4c16-8e87-388ee53afe00"), 41 },
                    { new Guid("e4c1990a-9183-48e7-b84f-9c3d0f6a724b"), 40, new Guid("9fb659e3-b6f4-440c-84a8-e58b54cb194c"), 40 },
                    { new Guid("e666491e-31ce-4641-b08c-2a8ee0d9b835"), 39, new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), 41 },
                    { new Guid("ea6cad9f-e6ad-431d-9593-b2edf82c9074"), 22, new Guid("9ed31e26-3c4b-4764-9092-9ee1e006b206"), 45 },
                    { new Guid("ec8bb53f-e9b9-4be7-b2c3-f8a8a3999303"), 36, new Guid("d9343eff-88d6-45ec-8c16-d84ac78bc521"), 42 },
                    { new Guid("ed20a33c-259b-45c5-b834-3288c7aa1bb0"), 50, new Guid("22af2483-c2fb-423c-9914-c9bfb36829ca"), 38 },
                    { new Guid("eda1dd5f-8dd7-4ca8-81ed-a9e87f50a1f7"), 51, new Guid("890ffc69-b7af-4218-b457-b27abe752233"), 41 },
                    { new Guid("f1427435-221b-4c74-8c6e-e93eb4df0b45"), 17, new Guid("e2448e25-38f6-4fd5-8197-7d6572176836"), 40 },
                    { new Guid("f40f4f9f-f96c-4fde-a47e-720d5f895dca"), 34, new Guid("09858e6c-5eac-4cb4-a68e-dbcf014232e2"), 42 },
                    { new Guid("f4778d45-725f-4402-b0d5-71b3ad81483d"), 52, new Guid("22963aac-57fb-4602-bfc0-d21547798aae"), 44 },
                    { new Guid("f48e2241-024d-4b86-9d12-a78888b703b7"), 54, new Guid("e9e76cfd-a5aa-49b6-8285-bc50c79958c5"), 42 },
                    { new Guid("f535b8f9-ebf8-4ce4-822b-7958d4409d6e"), 31, new Guid("80caaf6d-5d0c-4208-a567-f433472dfa88"), 42 },
                    { new Guid("f5a9c684-b675-43f2-b745-97cc9c37ccc2"), 28, new Guid("8d7f905c-05d5-47ee-9e06-5216037f9f9e"), 38 },
                    { new Guid("f66e7a05-2e57-4af3-9845-64b3ce1ea93a"), 53, new Guid("f3898d12-d8c4-4ad1-b20c-d8ed32a6809c"), 45 },
                    { new Guid("f8385a5a-310a-4a75-ab11-63bfabba05cf"), 15, new Guid("d6ae10df-f064-4e64-abd0-43d5f8eb0197"), 44 },
                    { new Guid("f87a0124-68f6-46f6-901e-6ed73c5deb36"), 19, new Guid("2349600e-4c21-47b4-aa6a-bd5900efef95"), 43 },
                    { new Guid("f960ea10-5b69-4b97-ac8e-a1cfa2359191"), 20, new Guid("63eb9775-b643-4254-ab54-a5321a0c6d36"), 41 },
                    { new Guid("f97aa997-c337-44e0-a6df-bb8accc9adcc"), 3, new Guid("c37d3dcd-08f2-42bd-aa5a-43919cd0390c"), 39 },
                    { new Guid("fbdb2f33-7ee8-4b8d-ac5f-bb38448bfe43"), 33, new Guid("3b3a20de-59e5-4b8d-9391-a24a1b793462"), 39 },
                    { new Guid("fee0b015-71ac-4ced-8245-2ecc27e85ddd"), 28, new Guid("c3691ff1-3925-4044-89bb-dd2e03913060"), 39 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "CreateDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "IsExternalLogin", "LastModifiedDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileName", "ProviderName", "RoleId", "SecurityStamp", "TotalMoney", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("166899de-762d-43eb-9650-4f7e9fcd85a2"), 0, null, "db008efc-e4cb-4ee5-a499-c03593af22b6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2204, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "machgiahuy@gmail.com", false, "Mach", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gia Huy", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("6fc14fa8-a9a5-4362-b8b4-c95cf5045516"), null, 1000m, false, "Mach Gia Huy" },
                    { new Guid("69742b85-840d-4e36-b3c2-d2acec969bba"), 0, null, "6970da42-0ff8-419e-9614-0491f9730d6a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, "Jane", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("58188164-95b3-403a-894f-ffedd494711d"), null, 1500m, false, "jane.smith" }
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
