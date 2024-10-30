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
                    { new Guid("36192faa-c226-4dba-a224-c5f4ca77595f"), "Role Admin với đầy đủ các quyền hạn", "Admin" },
                    { new Guid("c9cdcdc3-2e5d-4911-8e9f-201f0ce9fc44"), "Role User với các quyền hạn có giới hạn và mua hàng", "User" }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "AverageRating", "Brand", "Category", "CreateDate", "Description", "Discount", "Gender", "ImageUrl", "IsSale", "LastModifiedDate", "Material", "Name", "Price", "Sold", "TotalRatings", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e"), 7m, "Nike", "Basketball", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6642), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/[IDGiay_26]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6643), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5, 0 },
                    { new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a"), 4.1m, "Puma", "Yoga", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6579), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/[IDGiay_14]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6579), "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22, 0 },
                    { new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 1, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6658), "Nike's first lifestyle Air Max brings you style, comfort and big attitude in the Nike Air Max 270. The design draws inspiration from Air Max icons, showcasing Nike's greatest innovation with its large window and fresh array of colors.", 40m, 1, "images/shoes/[IDGiay_Home_2]_AnhChinh_1.png", true, new DateTime(2024, 10, 1, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6659), "Plastics, yarns and textiles.", "Nike Air Max 270", 4059000m, 8, 3, 0 },
                    { new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22"), 4.4m, "Converse", "Basketball", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6630), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/[IDGiay_23]_AnhChinh.png", true, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6630), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34, 0 },
                    { new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 1, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6649), "Nike Youth React Presto Extreme combines lightweight React technology and a flexible upper to provide comfort and support for everyday activities and gym training.", 40m, 2, "images/shoes/[IDGiay_Home_1]_AnhChinh_1.png", true, new DateTime(2024, 10, 1, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6654), "Rubber, yarns and textiles.", "Nike Youth React Presto Extreme", 2069000m, 78, 60, 0 },
                    { new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6583), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/[IDGiay_15]_AnhChinh.png", true, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6584), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87, 0 },
                    { new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4"), 4.9m, "Nike", "Yoga", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6537), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/[IDGiay_5]_AnhChinh.png", true, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6537), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66, 0 },
                    { new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6555), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/[IDGiay_9]_AnhChinh.png", true, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6556), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268, 0 },
                    { new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6593), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/[IDGiay_17]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6594), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20, 0 },
                    { new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6598), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/[IDGiay_18]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6598), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12, 0 },
                    { new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6489), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/[IDGiay_1]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6501), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20, 0 },
                    { new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6589), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/[IDGiay_16]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6590), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25, 0 },
                    { new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6621), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/[IDGiay_21]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6621), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10, 0 },
                    { new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6575), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/[IDGiay_13]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6575), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23, 0 },
                    { new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861"), 4.2m, "Puma", "Football", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6570), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/[IDGiay_12]_AnhChinh.png", true, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6571), "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17, 0 },
                    { new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6"), 4.7m, "Nike", "Basketball", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6506), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/[IDGiay_2]_AnhChinh.png", true, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6507), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45, 0 },
                    { new Guid("88cce454-97e8-4e2c-88f0-db5412135c66"), 4.7m, "Converse", "Yoga", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6638), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/[IDGiay_25]_AnhChinh.png", true, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6639), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30, 0 },
                    { new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9"), 4.8m, "Nike", "Football", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6513), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/[IDGiay_3]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6514), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10, 0 },
                    { new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6606), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/[IDGiay_20]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6607), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10, 0 },
                    { new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6"), 4.0m, "Puma", "Basketball", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6566), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/[IDGiay_11]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6567), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21, 0 },
                    { new Guid("c4d0e491-7479-40f3-bef6-e36381cab264"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6634), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/[IDGiay_24]_AnhChinh.png", true, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6634), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100, 0 },
                    { new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6602), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/[IDGiay_19]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6602), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111, 0 },
                    { new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158"), 4.4m, "Adidas", "Football", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6546), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/[IDGiay_7]_AnhChinh.png", true, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6547), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37, 0 },
                    { new Guid("cdeb9991-309a-4a9f-9376-07458763de5b"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6551), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/[IDGiay_8]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6551), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84, 0 },
                    { new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6542), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/[IDGiay_6]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6542), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381, 0 },
                    { new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e"), 4.2m, "Nike", "Tennis", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6519), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/[IDGiay_4]_AnhChinh.png", true, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6520), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5, 0 },
                    { new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6625), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/[IDGiay_22]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6626), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45, 0 },
                    { new Guid("e28108df-171b-44a8-8971-b422ac0e53f3"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 1, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6662), "Whether you're starting your running journey or an expert eager to switch up your pace, the Downshifter 13 is down for the ride. With a revamped upper, cushioning and durability, it helps you find that extra gear or take that first stride towards chasing down your goals.", 40m, 1, "images/shoes/[IDGiay_Home_3]_AnhChinh_1.png", true, new DateTime(2024, 10, 1, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6663), "Plastics, yarns and textiles.", "Nike Downshifter 13", 2069000m, 78, 20, 0 },
                    { new Guid("f1c14f0a-477a-42af-9707-383fb976ce12"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6562), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/[IDGiay_10]_AnhChinh.png", false, new DateTime(2024, 10, 31, 0, 11, 7, 750, DateTimeKind.Local).AddTicks(6562), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("064ba27d-b109-4b7c-ae64-f7bf2af05670"), new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("07c2a593-554e-4147-ac50-72a1abce12f8"), new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("0a6584c8-4020-467e-9790-08efd1c11a2c"), new Guid("88cce454-97e8-4e2c-88f0-db5412135c66"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("0e8a0727-4e59-4fca-b8b4-f102d81b177c"), new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("0f0d0c28-846c-4b87-a1bf-d23b435b19c9"), new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("140909af-f62c-40b5-af66-1e918602bfef"), new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("16543539-993e-4002-bdd8-c0cd2576008d"), new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("16d0be58-782b-458d-b425-9947463028b7"), new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("170fe923-17b5-4e03-8b74-79bc42e8cb2e"), new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("17f98931-62ef-4519-b122-2fd192c81aa9"), new Guid("c4d0e491-7479-40f3-bef6-e36381cab264"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("1932a213-89e0-4589-9190-cdc796c97f54"), new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("1b7e3665-6e87-4e31-9e9e-dc30862e472c"), new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("1be31621-ef5c-4e79-b27d-9e528c3399c2"), new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("1cd90d45-58fa-4f33-8471-482afae06134"), new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("209f6106-ff88-45e2-906f-ac497133de11"), new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("25938e98-5a02-4474-8d0d-5ef484bcf4a4"), new Guid("f1c14f0a-477a-42af-9707-383fb976ce12"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("27e72065-5d2f-4065-8ef5-8c51f425ce48"), new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("2d7cd6dc-c66e-4cca-a88d-fe9d717e724a"), new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("304ce5b6-b11a-4a51-a3fe-068e30eaf64e"), new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("31d9c7e5-751e-467f-8657-eb9e5fc648a0"), new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("338800d5-6621-4fa8-87f9-0c753e113322"), new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("33aec26a-5af2-4a6d-973b-cdf914f2360e"), new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("3959faf6-7ba1-45d2-98be-d5c3e811866e"), new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f"), "images/shoes/[IDGiay_Home_2]_AnhPhu_3.png" },
                    { new Guid("409c2707-80f0-4d75-8334-70a0c27f18ba"), new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("4200b44d-1af8-44a6-8d2f-23529a7a1488"), new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("454a8fa2-6a0f-4d43-95b4-30ac877ea075"), new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("467e3401-79a3-4106-95f4-167553e96fd8"), new Guid("cdeb9991-309a-4a9f-9376-07458763de5b"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("477ae333-509a-465b-906f-28fb09319252"), new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("49b585ef-f835-4ed9-831c-172ca3a6c67b"), new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("49b82f46-d7e0-494c-a973-2fe99fc83227"), new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("49c3b431-99d5-4d11-8ea1-67350cdea0db"), new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("4aca486f-03b3-4852-9480-86eb4a9b939a"), new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("510d1b0f-619e-4df7-b345-78762570195d"), new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("526291db-f2f7-457e-ad7e-0ef879b94ea3"), new Guid("cdeb9991-309a-4a9f-9376-07458763de5b"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("537522a9-b150-4956-94d0-0c2103f97af9"), new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("55f436a0-a805-47da-90aa-6dfeee31058e"), new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("58c3aa3a-6ee4-4920-b8ed-2d47875644a3"), new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("5ab429c4-2722-4749-8407-e6a0cd43bd84"), new Guid("e28108df-171b-44a8-8971-b422ac0e53f3"), "images/shoes/[IDGiay_Home_3]_AnhPhu_3.png" },
                    { new Guid("5b2f15bc-8b87-4f17-9d37-a92461e7eb87"), new Guid("c4d0e491-7479-40f3-bef6-e36381cab264"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("5d203fe0-e42c-4102-9e83-b7fbd94f2a42"), new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("5f0ff492-c1f2-4dc8-8fc9-74c2a7f69717"), new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("60431e00-aa4b-45ca-95a3-707e3116cbf9"), new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("611e7956-d415-410c-b6a5-e4cd7fddf5c2"), new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("6355880a-0f63-46f8-9f8d-5d182668c32b"), new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e"), "images/shoes/[IDGiay_26]_AnhPhu_1.png" },
                    { new Guid("63e1bd34-1706-4d59-a6b0-4b0802be6719"), new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("63fa7509-e166-43ba-916c-40a27f25961b"), new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("69b75878-14f2-4a7a-8f16-9a2bb102aad3"), new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f"), "images/shoes/[IDGiay_Home_2]_AnhPhu_1.png" },
                    { new Guid("69f52d53-8f32-4899-bbb7-7d34b56cd307"), new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f"), "images/shoes/[IDGiay_Home_2]_AnhPhu_2.png" },
                    { new Guid("6b4a169e-0cca-43c2-9dd2-2118772e5923"), new Guid("c4d0e491-7479-40f3-bef6-e36381cab264"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("6c44cbc2-8107-443c-9697-c54de35706d3"), new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("6ff3db32-8031-4a30-886f-664bfc95f55a"), new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("706d7143-3e7f-4921-b65c-40b8622c822d"), new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("70b055f9-4f60-4e16-80d9-3605b778c730"), new Guid("88cce454-97e8-4e2c-88f0-db5412135c66"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("72017c6c-c701-4e74-a119-bbf042d119ba"), new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("74dae01c-766f-4fdb-bc53-64a9039a7460"), new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("7b8e82d2-8565-4a99-af4b-3bc5ba71b222"), new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("7c7ab1fb-a721-483b-9f3c-ddc176f390e8"), new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("7cf4c17f-214f-489e-8b6a-663aa160ad9e"), new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("7f4a6abe-521a-458d-bd5d-4b16a9c46ac5"), new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("7fed4d96-8132-4e9c-a4e2-1aebf9a809ca"), new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e"), "images/shoes/[IDGiay_26]_AnhPhu_2.png" },
                    { new Guid("85b9cb14-f505-4f88-af7d-1a7610cc1d89"), new Guid("88cce454-97e8-4e2c-88f0-db5412135c66"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("85fba376-6b35-41cd-b51b-8e26660bfe63"), new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("862b9d83-10a3-49bd-9224-11398928eb45"), new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48"), "images/shoes/[IDGiay_Home_1]_AnhPhu_2.jpg" },
                    { new Guid("8a670891-fd6e-4067-a62e-13dbcff39d56"), new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("8c93de19-d923-469b-ae8e-cc347c09f201"), new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48"), "images/shoes/[IDGiay_Home_1]_AnhPhu_1.jpg" },
                    { new Guid("8cfcc8e6-1fb7-4265-a1fd-fa7e3913c1bd"), new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("9269a8ab-1c7c-4ef5-8b2b-32012694fe69"), new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("93a9cacc-0b70-4945-b0dc-04935d3bf8d6"), new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f"), "images/shoes/[IDGiay_Home_2]_AnhPhu_4.png" },
                    { new Guid("93b23546-9f6b-4422-9081-36ffac69ca17"), new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("93fd4a59-e451-45c1-aaf9-397b266f11ba"), new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("95acaa43-ed92-4f7a-84e7-af15e3ce2c90"), new Guid("cdeb9991-309a-4a9f-9376-07458763de5b"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("988e86e2-7cb3-4236-9cf7-cdaa38d8d5c7"), new Guid("f1c14f0a-477a-42af-9707-383fb976ce12"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("99561616-51b6-4efb-8619-ae46af254730"), new Guid("e28108df-171b-44a8-8971-b422ac0e53f3"), "images/shoes/[IDGiay_Home_3]_AnhPhu_4.png" },
                    { new Guid("9b77c29d-59bf-4c1e-9a07-1aff2c25e690"), new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("9dba4152-7648-48e4-a3a3-ac78c493c00e"), new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("9dba55be-53b1-41ad-a62b-e5921911fee9"), new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("9ddd34a8-b766-4a73-8d24-ebcfabcf6da7"), new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48"), "images/shoes/[IDGiay_Home_1]_AnhPhu_4.jpg" },
                    { new Guid("a34008c9-e6c8-486e-a5d8-cb8e78b3c894"), new Guid("88cce454-97e8-4e2c-88f0-db5412135c66"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("a6ee47e5-1d63-4953-8342-0f2171edfdd4"), new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("a7298114-97ae-47cd-baa6-eb395e3d4395"), new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("a9363eac-ade5-4c32-a5a5-1fdaa0239d12"), new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("aa260313-31aa-4aa6-98e0-27d5ad403803"), new Guid("cdeb9991-309a-4a9f-9376-07458763de5b"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("acec06b8-afeb-494d-be27-bb3d3531bf40"), new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e"), "images/shoes/[IDGiay_26]_AnhPhu_4.jpg" },
                    { new Guid("af93bee8-06c3-4ce5-af05-25ea2a9f7350"), new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("b2387ffe-b91d-4f95-a115-f3abe8c672e0"), new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e"), "images/shoes/[IDGiay_26]_AnhPhu_3.jpg" },
                    { new Guid("b7e35065-16d2-44e3-8428-c9c1a4cff58b"), new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("b8c4edfb-2f89-4f0d-b70d-45deeb49f43a"), new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("baa63ba5-156f-4668-ab17-cf0252e8cc4e"), new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("c1d5884f-3d93-4952-b6b4-64bc1c60dcfe"), new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("c3970a4c-682c-4d0f-b53a-007540537741"), new Guid("f1c14f0a-477a-42af-9707-383fb976ce12"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("c45f753e-0165-4bf4-97b3-64ef529a71bb"), new Guid("f1c14f0a-477a-42af-9707-383fb976ce12"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("d7c7532a-6823-4ed0-8daf-39db3299dd5c"), new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("d8e1628d-3936-4656-be09-72660a012314"), new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("d9d1ea03-0c80-417e-9d0e-16ee271f513a"), new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("defa6939-ec0b-4116-990b-6626431b0649"), new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("e021a5ef-2dc4-4f1e-a65c-3084a21971b3"), new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("e0eed629-71e0-4d86-a4ff-06a1f52414f3"), new Guid("c4d0e491-7479-40f3-bef6-e36381cab264"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("e4d178f3-5420-4d36-9ee5-2551a9b3633a"), new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("e5e60d8b-64e0-412d-a682-ac7d5d6cc4ed"), new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("e72a7f07-4cde-430d-bccd-106db15f768d"), new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("e781abdf-f8d2-490e-b1cb-965bc830251d"), new Guid("e28108df-171b-44a8-8971-b422ac0e53f3"), "images/shoes/[IDGiay_Home_3]_AnhPhu_2.png" },
                    { new Guid("e973cc8c-1942-430d-9f61-fb186ebf642a"), new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("ea90f21d-58db-47ee-bb85-b8ea13f586f5"), new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("eb06c35f-d49a-439c-984c-c2b35e3182e6"), new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("ecc6ca57-6601-4259-ab52-26d7890af384"), new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("ed906c0a-2479-4979-9319-605d91f39925"), new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("f17a5aef-42c0-47d6-adae-a8f992dcee7b"), new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("f1a3056d-df3f-4cb1-b36c-bbfbff8cdac0"), new Guid("e28108df-171b-44a8-8971-b422ac0e53f3"), "images/shoes/[IDGiay_Home_3]_AnhPhu_1.png" },
                    { new Guid("f4a5ef8d-2f1f-46b6-8b6d-1d2bcb298d55"), new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("f4c1eef0-8097-415c-877e-d0cd7c6126d9"), new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("f60220d5-5476-4016-ae25-2ddbe0894cdb"), new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("f674f106-8992-4603-9b7f-b114d41f632c"), new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("f8ed27ad-d491-4349-8174-17e6aa22da01"), new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48"), "images/shoes/[IDGiay_Home_1]_AnhPhu_3.jpg" },
                    { new Guid("fc105fe8-c36a-408c-9e06-55580dda3275"), new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("fd1dc75e-8816-400b-aa71-7f8e29bc8bfe"), new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("fd52bab7-c29e-4017-9528-606167bd45c4"), new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("0630b555-936c-4332-bb2f-5c88df77115d"), "Summer", new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379") },
                    { new Guid("0677f71e-77f9-415c-a20e-3452c630d8c9"), "Summer", new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12") },
                    { new Guid("0dfc3398-0e41-4b74-b3ac-6d5db68f08b3"), "Winter", new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861") },
                    { new Guid("11a1801d-4b50-45dc-9ce0-eb15c3e4fefa"), "Spring", new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a") },
                    { new Guid("151469b1-6427-46da-93a4-63e53f944537"), "Spring", new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158") },
                    { new Guid("1d1eb511-3f99-4b0f-b8c5-681129e065be"), "Spring", new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3") },
                    { new Guid("1e78e14e-3064-4ab8-99bf-ae86b497dcd6"), "Summer", new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48") },
                    { new Guid("1e822e93-f801-4fd7-9177-2ccc225f56d1"), "Spring", new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e") },
                    { new Guid("216e48ec-6f95-47d1-a544-7a3535825fbe"), "Winter", new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b") },
                    { new Guid("2478352c-189a-44b7-bdb2-a32b5853afa4"), "Fall", new Guid("c4d0e491-7479-40f3-bef6-e36381cab264") },
                    { new Guid("2551d276-8592-441b-ba92-604dad5b638e"), "Spring", new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa") },
                    { new Guid("27d108e9-6d41-4a32-a790-a43359a43ac2"), "Spring", new Guid("c4d0e491-7479-40f3-bef6-e36381cab264") },
                    { new Guid("346dd189-41b3-40b3-bff2-f2165a04e8f0"), "Fall", new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861") },
                    { new Guid("4285018e-c822-41c6-b94f-57e54448ab74"), "Fall", new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6") },
                    { new Guid("44d64c7c-0779-4be1-89c1-fc6a71b87ecd"), "Winter", new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b") },
                    { new Guid("47549c41-7dd1-4832-b99c-2fabf0c717d0"), "Spring", new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f") },
                    { new Guid("4871bf43-2321-49bf-92fd-6ec4342a3e4e"), "Winter", new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4") },
                    { new Guid("4cbf8270-6b45-425f-9579-1a9604599aec"), "Fall", new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e") },
                    { new Guid("5418902a-b35d-44e9-9818-690a709838bd"), "Spring", new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e") },
                    { new Guid("66d86de9-3d4a-42f6-95e6-6b211ed3e975"), "Fall", new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3") },
                    { new Guid("6a10af22-9220-401e-8997-afbca08f1653"), "Spring", new Guid("88cce454-97e8-4e2c-88f0-db5412135c66") },
                    { new Guid("6a42ba76-a5aa-4360-847d-694687ddff62"), "Spring", new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861") },
                    { new Guid("71da941f-684f-4568-9fec-9a81e3c68f2d"), "Winter", new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e") },
                    { new Guid("81407542-f7d3-4e47-b7d7-e2ea221c3f73"), "Summer", new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3") },
                    { new Guid("83acc622-7e6e-45e5-8d59-0947471a47c6"), "Summer", new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f") },
                    { new Guid("86e7f0e6-c13c-4cd1-a2fb-e24218ce64c1"), "Winter", new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158") },
                    { new Guid("9188f833-9274-4fc1-a8a0-3591215c222c"), "Spring", new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379") },
                    { new Guid("92878e32-385e-47bb-bd39-b9a5c5a2094b"), "Fall", new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f") },
                    { new Guid("92a880c9-4d19-4e63-8121-f73c4db97c31"), "Winter", new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22") },
                    { new Guid("96bc0ffc-cddb-4f70-b887-2c34f8fd22f2"), "Fall", new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6") },
                    { new Guid("9c86be8b-5cce-490a-9ddc-330cf10481c6"), "Winter", new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682") },
                    { new Guid("9e75d4d1-5694-453c-a93d-32fbe0727179"), "Winter", new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e") },
                    { new Guid("a34d33dd-8479-4d30-8add-eb6d2dcbee28"), "Spring", new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152") },
                    { new Guid("a8fe90ef-a28f-49f7-a1de-8f4467aa8db4"), "Spring", new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a") },
                    { new Guid("ab6cc54e-fd11-407d-9248-ddc84410e2f2"), "Summer", new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e") },
                    { new Guid("ac541324-8bad-4799-aeae-56a8e8154a22"), "Spring", new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48") },
                    { new Guid("acb93bfa-c80a-4966-9b9e-866d90c505ff"), "Summer", new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa") },
                    { new Guid("b28d59af-bb6b-4d7b-8984-c08ca1b316f9"), "Summer", new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c") },
                    { new Guid("b4b72a3c-96b0-4abb-ab85-60944bc0a841"), "Spring", new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9") },
                    { new Guid("b5c91e86-9426-41ec-8eed-e6b5e339507a"), "Summer", new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a") },
                    { new Guid("bd786bdc-5241-4a8f-8525-ffcbd548bf62"), "Winter", new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448") },
                    { new Guid("be3f29b7-9d52-452b-8bee-5253b8757753"), "Summer", new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448") },
                    { new Guid("c14bd608-9deb-41a5-8d2a-788decf9bf3a"), "Summer", new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b") },
                    { new Guid("cbc968b6-ce5a-4a4b-9705-f72aaffeb359"), "Spring", new Guid("cdeb9991-309a-4a9f-9376-07458763de5b") },
                    { new Guid("cdc56323-137b-4fbf-9744-3197b26af915"), "Winter", new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3") },
                    { new Guid("d03be551-e201-45df-a270-103932d72257"), "Summer", new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158") },
                    { new Guid("d3eb7e3e-8565-4a9d-adf8-c72793976f1f"), "Fall", new Guid("e28108df-171b-44a8-8971-b422ac0e53f3") },
                    { new Guid("d5b1b3ca-660c-478a-8f0b-6a72c96cb88f"), "Fall", new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4") },
                    { new Guid("d9303357-5f5c-4262-8f20-b52cbdd39ed6"), "Spring", new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12") },
                    { new Guid("da8666d6-eab1-4298-ac1b-ddb3892f5741"), "Winter", new Guid("e28108df-171b-44a8-8971-b422ac0e53f3") },
                    { new Guid("dff6edec-2d52-4f45-8c52-60626fb4b3dd"), "Summer", new Guid("e28108df-171b-44a8-8971-b422ac0e53f3") },
                    { new Guid("ecc2a5d8-7131-4be0-a899-1a18fedbe277"), "Summer", new Guid("f1c14f0a-477a-42af-9707-383fb976ce12") },
                    { new Guid("eff14483-f390-4db9-a9af-54d9d208a65a"), "Summer", new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380") },
                    { new Guid("f04b779f-3a16-4509-943d-30000f4ed6ce"), "Fall", new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e") },
                    { new Guid("f0b25d88-b1bc-4917-a0dd-683728867651"), "Spring", new Guid("f1c14f0a-477a-42af-9707-383fb976ce12") },
                    { new Guid("f3511fe8-abc3-41ff-af64-ee03ea8b773e"), "Fall", new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379") },
                    { new Guid("f8e80912-ac5c-439f-a195-05b75dea7b7e"), "Winter", new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6") },
                    { new Guid("fa08a084-ad22-4ac1-9403-bb12bf51899f"), "Winter", new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a") },
                    { new Guid("fc666078-757e-4a9c-b45a-dac0b4b05a72"), "Winter", new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379") },
                    { new Guid("fe97a5ad-60fa-457c-8144-91d7476d8271"), "Summer", new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6") },
                    { new Guid("ffa45828-f7d2-4c9f-b256-8ffad9515434"), "Summer", new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a") },
                    { new Guid("fff6e41b-a7be-4a63-8146-de96174acae2"), "Fall", new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("0170c5ec-998e-4171-ac6a-f7b78d763c47"), "Pink", new Guid("f1c14f0a-477a-42af-9707-383fb976ce12") },
                    { new Guid("057c06ba-a546-4b61-9f37-697d6ea874bc"), "Black", new Guid("e28108df-171b-44a8-8971-b422ac0e53f3") },
                    { new Guid("09b4f880-8ce3-4bcf-a8c8-abc748ad5f83"), "Black", new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e") },
                    { new Guid("0b908b6f-c27b-402a-9fcb-5c760977479b"), "Black", new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3") },
                    { new Guid("0bbff932-d0e1-4b12-86b3-c544d78037eb"), "Black", new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152") },
                    { new Guid("0fa6ac73-e37d-4de2-9aaa-73fd1e980741"), "Black", new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448") },
                    { new Guid("0ffe9272-8e5d-4b03-ab4e-320126610075"), "Blue", new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380") },
                    { new Guid("10db31cd-16b7-4504-b63a-181744dca4cd"), "Orange", new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6") },
                    { new Guid("1311c1bc-90ad-4de9-8529-f2bd8324f282"), "White", new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b") },
                    { new Guid("15deea0a-d1bb-4136-a065-6e2cf13f2053"), "Black", new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6") },
                    { new Guid("1c51f639-d06d-4137-b991-37c0e2ca8b33"), "Black", new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379") },
                    { new Guid("1ce90b8c-822a-48a2-b7bb-3aadcb4b3d39"), "Purple", new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12") },
                    { new Guid("1f71aace-7993-4e01-a1d3-79d708fb9673"), "Brown", new Guid("c4d0e491-7479-40f3-bef6-e36381cab264") },
                    { new Guid("20b0b022-1ec8-4f3e-8870-32b8511694d3"), "White", new Guid("f1c14f0a-477a-42af-9707-383fb976ce12") },
                    { new Guid("28c0e506-1b7b-458f-8628-a8d5d88a4801"), "Blue", new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa") },
                    { new Guid("28c741ba-ecf7-4842-b6eb-896ed8635c7f"), "Yellow", new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9") },
                    { new Guid("295c1748-9171-463c-9a4f-395c7926d4f6"), "White", new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9") },
                    { new Guid("34e190a1-6d44-4e31-884f-428637daad52"), "Orange", new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380") },
                    { new Guid("356a2f01-8fab-422a-91be-b087af56577f"), "Yellow", new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158") },
                    { new Guid("36c407bc-a90f-40b7-8a53-b7883645207c"), "Orange", new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c") },
                    { new Guid("3870de95-2f72-4439-ac07-25d416521a67"), "White", new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152") },
                    { new Guid("3e45fe76-e00d-4422-8323-a4658394d076"), "Orange", new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4") },
                    { new Guid("3e795e99-5214-48da-83ac-1e86489f22da"), "Blue", new Guid("e28108df-171b-44a8-8971-b422ac0e53f3") },
                    { new Guid("3f1ef307-7563-405a-8ff5-a8386a9adb31"), "White", new Guid("cdeb9991-309a-4a9f-9376-07458763de5b") },
                    { new Guid("401002d1-321c-4bdb-b0d1-c1a82c37e474"), "Red", new Guid("cdeb9991-309a-4a9f-9376-07458763de5b") },
                    { new Guid("424bec30-5154-44f8-923f-799788acbc32"), "White", new Guid("c4d0e491-7479-40f3-bef6-e36381cab264") },
                    { new Guid("48bc6fba-4fa3-4eb5-aa41-7dd0182dfb79"), "Grey", new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3") },
                    { new Guid("4e3bf25d-f193-427a-8787-075be6611bfa"), "Blue", new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12") },
                    { new Guid("51135315-83f3-4727-9334-b90cf86d1d83"), "Blue", new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3") },
                    { new Guid("53ce48c9-8226-4350-871c-c7a16d6e1443"), "White", new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12") },
                    { new Guid("54df2edf-8eb9-414a-85c0-5db049df0ac7"), "Pink", new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9") },
                    { new Guid("5676bbd7-0be0-4b4e-8cd0-a6846a6cf76a"), "Black", new Guid("cdeb9991-309a-4a9f-9376-07458763de5b") },
                    { new Guid("59a29070-c5db-4af2-855f-ed186b8b0aee"), "White", new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380") },
                    { new Guid("5b40eeff-ca2b-410e-9211-21dbf117ed43"), "Blue", new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6") },
                    { new Guid("5c77e38f-666f-4e44-8779-51ed6dcc64cf"), "Green", new Guid("88cce454-97e8-4e2c-88f0-db5412135c66") },
                    { new Guid("603bb631-259b-45e5-a1f5-405443e755db"), "Black", new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48") },
                    { new Guid("61c92a58-b6e3-4efd-9227-a8cfc43eec63"), "Red", new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e") },
                    { new Guid("66450ff5-7489-4192-a8bb-1eb073e0341f"), "Black", new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861") },
                    { new Guid("691a7ec7-82f9-4b39-a769-cbe6da852ccd"), "Black", new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e") },
                    { new Guid("70e5091f-a582-4085-9a71-5fe67d7093c0"), "Blue", new Guid("cdeb9991-309a-4a9f-9376-07458763de5b") },
                    { new Guid("71b4618e-d149-40b4-adfd-c5bc80fb198e"), "White", new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4") },
                    { new Guid("72a536b9-bcd4-4f86-8c2f-50a97b5ac54b"), "Black", new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4") },
                    { new Guid("72d34548-a786-4bbc-bbba-d8c86da30bfb"), "Purple", new Guid("f1c14f0a-477a-42af-9707-383fb976ce12") },
                    { new Guid("7406c2bd-beec-408f-8034-7fde1930c5b9"), "Black", new Guid("f1c14f0a-477a-42af-9707-383fb976ce12") },
                    { new Guid("762a6730-c23c-4cb6-a14b-a49b628a64a3"), "Brown", new Guid("88cce454-97e8-4e2c-88f0-db5412135c66") },
                    { new Guid("77120e78-7c4f-4e40-91bc-315d97a54f4d"), "Red", new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158") },
                    { new Guid("7febb3bf-0ada-42bc-90be-f94a6340f92f"), "Pink", new Guid("cdeb9991-309a-4a9f-9376-07458763de5b") },
                    { new Guid("86b1055e-a71d-43ec-bcaf-ba71fd7d815e"), "Red", new Guid("e28108df-171b-44a8-8971-b422ac0e53f3") },
                    { new Guid("89339240-1d0f-443f-9edd-1f29af17cedc"), "White", new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6") },
                    { new Guid("8ebad489-817c-4c6a-ad36-5657b329fb12"), "White", new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3") },
                    { new Guid("9347181b-cedc-4cc4-a687-adb5acf4e793"), "Black", new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9") },
                    { new Guid("9abdf24b-54f7-4c8b-9421-24a539397ac3"), "Brown", new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e") },
                    { new Guid("9d45b872-b3ce-4599-8876-a22db6d1f7d0"), "White", new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48") },
                    { new Guid("a47e53dc-2b64-4d53-bfb4-c7f161e9f8ca"), "Blue", new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a") },
                    { new Guid("a6da8916-5f7e-4541-8137-fa723afcf112"), "Blue", new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9") },
                    { new Guid("aaf8f4a0-1987-4919-8188-a3398cbf403b"), "White", new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e") },
                    { new Guid("ac0b449a-43ed-47b6-bab4-28258e1a0e33"), "Green", new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380") },
                    { new Guid("ace6aa4d-25cc-49ca-a8a5-94e3b4e766b3"), "Blue", new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682") },
                    { new Guid("b5380538-5c51-4180-b031-f72c4bfba3bf"), "Green", new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861") },
                    { new Guid("b777267a-acc0-41c9-aba2-d251d05f2342"), "Pink", new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f") },
                    { new Guid("b87a743c-9661-43aa-a71f-9bd9220d5fa8"), "Pink", new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682") },
                    { new Guid("ba8e8e40-cdc1-4d28-a20d-d3ffc1266bd6"), "Blue", new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22") },
                    { new Guid("bd3bb1be-c5f1-43ff-be66-17233fe5852c"), "Blue", new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f") },
                    { new Guid("bff19138-1bba-4e9f-8183-62368889fc2b"), "Black", new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c") },
                    { new Guid("c05b1d99-347a-4c8d-a758-144aa73d01b0"), "Blue", new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861") },
                    { new Guid("c7e9464c-4e49-4157-a462-4e9a1ba8d8fd"), "Black", new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b") },
                    { new Guid("cb7ef92d-461c-4b89-b7ce-17c9b6d6efb0"), "Pink", new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a") },
                    { new Guid("d96f4439-0afe-4699-90a9-b953e1b47850"), "White", new Guid("e28108df-171b-44a8-8971-b422ac0e53f3") },
                    { new Guid("db2a4409-d0ad-471c-9bb3-92c9106c3ab1"), "Black", new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12") },
                    { new Guid("dc3dcacc-171d-45de-ae41-d9cb0f8efc6b"), "White", new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f") },
                    { new Guid("e547aec1-cbb9-40e3-8590-4d93e893bef3"), "Red", new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6") },
                    { new Guid("e7366896-0589-4a5a-aa9f-8b2142f96adb"), "Red", new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380") },
                    { new Guid("f4648c84-7492-4c06-aeb9-b89f995c93b8"), "Black", new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380") },
                    { new Guid("f551282e-6b44-48a5-90ff-7530743b1447"), "Black", new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f") },
                    { new Guid("f8dd45bb-565d-423d-8894-be062ba33a91"), "Purple", new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("00171364-7648-4a2e-a8b6-b26d9237b837"), 87, new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6"), 39 },
                    { new Guid("0069a6f4-7dba-429c-9d41-965cb74fef5b"), 100, new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4"), 43 },
                    { new Guid("020b0c0c-b173-4dff-82ba-ae852b1b7521"), 100, new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6"), 46 },
                    { new Guid("03b8f1ea-37fb-4074-ac88-6154fe16ac86"), 21, new Guid("c4d0e491-7479-40f3-bef6-e36381cab264"), 45 },
                    { new Guid("0616a3d1-17c5-4335-b4a2-13439927ca50"), 0, new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379"), 44 },
                    { new Guid("07b0f683-f22c-4158-84a7-ae5f631f3f88"), 45, new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379"), 42 },
                    { new Guid("095ac570-f3ef-4c76-adb3-437cbdf47c87"), 20, new Guid("88cce454-97e8-4e2c-88f0-db5412135c66"), 41 },
                    { new Guid("0b056d8c-693e-4da4-a916-3f5652cb1e8f"), 136, new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12"), 41 },
                    { new Guid("0dc5e495-fbad-4060-ad72-949a63650def"), 8, new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682"), 42 },
                    { new Guid("115e6e20-ef98-45cc-bdc8-cc4b1a70baa9"), 63, new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4"), 45 },
                    { new Guid("15be49f5-7dba-41d5-b6db-66c66750e605"), 113, new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c"), 41 },
                    { new Guid("15d47d26-e8ef-41e8-aebf-b002542d583f"), 143, new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f"), 43 },
                    { new Guid("16628950-9e47-4811-af10-aeb978ec840e"), 71, new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6"), 40 },
                    { new Guid("2037501b-0544-46d2-b3c4-5fc1d9043fef"), 107, new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b"), 41 },
                    { new Guid("216f51a4-86ec-45bf-8e59-5ab139b5abc0"), 102, new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48"), 45 },
                    { new Guid("21d67749-7aa4-49cf-b85e-7de5cbc248b5"), 140, new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a"), 39 },
                    { new Guid("22a6b1a4-21cf-430f-9109-e8c7d3f0cdb9"), 47, new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa"), 41 },
                    { new Guid("253b4e30-b661-4e38-bb19-a8e0a9b9d480"), 37, new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861"), 41 },
                    { new Guid("26e3ad99-975b-425a-b98e-739bc3241329"), 70, new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152"), 43 },
                    { new Guid("2aea42f6-25ad-4034-bae7-473b0274f36f"), 22, new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448"), 44 },
                    { new Guid("2d5d4ca3-3ba5-4d96-82e6-69ea0579a6c2"), 75, new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9"), 40 },
                    { new Guid("2d9b70fd-fa7e-45b9-ac93-a9bcc1dee261"), 57, new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a"), 42 },
                    { new Guid("2e5ca089-b16f-474c-97d7-51ce111a3826"), 125, new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c"), 38 },
                    { new Guid("300483a5-e5fd-4a99-bf2c-2158c8f38f0b"), 147, new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861"), 39 },
                    { new Guid("302b3663-ccd8-4183-8ca3-da300752c4c5"), 119, new Guid("e28108df-171b-44a8-8971-b422ac0e53f3"), 39 },
                    { new Guid("31cbace3-d68f-4913-8b93-99d8bb96d267"), 139, new Guid("cdeb9991-309a-4a9f-9376-07458763de5b"), 45 },
                    { new Guid("3a44eb0c-f994-4e90-a46e-ed127edfccfe"), 19, new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6"), 45 },
                    { new Guid("3bf5454d-d6c3-42dc-8582-9ee993e7820d"), 22, new Guid("88cce454-97e8-4e2c-88f0-db5412135c66"), 43 },
                    { new Guid("3d9fb7bd-0baa-49ba-9793-6c299e980846"), 107, new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3"), 41 },
                    { new Guid("43d2ff88-f42e-453b-bdc7-8e0df1e6dde1"), 85, new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682"), 43 },
                    { new Guid("447075ec-ee7d-41cf-b32b-1deca4b1e957"), 91, new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a"), 39 },
                    { new Guid("45982984-c2e8-4938-ba96-3874b9c2aee0"), 10, new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12"), 42 },
                    { new Guid("47cb161b-1c96-4764-b15a-d7ff4f94f063"), 62, new Guid("e28108df-171b-44a8-8971-b422ac0e53f3"), 38 },
                    { new Guid("4baf65a9-44c4-4510-b217-7187ea5dd0b3"), 142, new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152"), 44 },
                    { new Guid("4bb47e28-2d9f-45da-95c3-fb3125d493ed"), 18, new Guid("e28108df-171b-44a8-8971-b422ac0e53f3"), 37 },
                    { new Guid("4dcc3e9d-c145-4efb-9c7a-95b6eb5ba092"), 82, new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c"), 40 },
                    { new Guid("4e3da3ab-bd5e-41e2-85e7-7cc8c2f8a09f"), 25, new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa"), 43 },
                    { new Guid("4f3784df-c1ca-4595-8240-d20e0278e4f1"), 59, new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b"), 39 },
                    { new Guid("51bab53c-db84-451a-acb9-62016072d234"), 138, new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6"), 37 },
                    { new Guid("52f59742-de91-4ce4-8149-acf9dd998732"), 140, new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682"), 41 },
                    { new Guid("53462752-4b1d-47dd-8510-ad0c70d23057"), 12, new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152"), 42 },
                    { new Guid("536f4dcf-4fd9-4139-96f5-4aaee215a163"), 71, new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12"), 43 },
                    { new Guid("5826b121-3681-475c-945b-ecbab20a51b4"), 129, new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6"), 44 },
                    { new Guid("5943f2f1-ff94-49eb-b86f-36373a278912"), 108, new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4"), 46 },
                    { new Guid("5950ce9f-4e52-4403-90a6-63fbe180447d"), 27, new Guid("f1c14f0a-477a-42af-9707-383fb976ce12"), 41 },
                    { new Guid("5cd78a58-838b-475a-b7ad-3726d328772d"), 98, new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e"), 41 },
                    { new Guid("60579c85-8d17-4585-84e1-ddce666886dc"), 84, new Guid("c4d0e491-7479-40f3-bef6-e36381cab264"), 42 },
                    { new Guid("6274992e-af91-4333-97a1-379954bad1af"), 100, new Guid("88cce454-97e8-4e2c-88f0-db5412135c66"), 39 },
                    { new Guid("62c5f288-17f6-41de-b059-6a2d3cf55428"), 123, new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380"), 38 },
                    { new Guid("62ddf63e-6181-48ac-94d0-b00a904473b6"), 59, new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f"), 41 },
                    { new Guid("64c315c9-2fd4-4561-83c1-47aea4385ee6"), 128, new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a"), 38 },
                    { new Guid("693d0bdd-2892-4998-9ecd-bc21452c9080"), 80, new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e"), 43 },
                    { new Guid("6a1e52fe-637c-4dc4-84af-160380102b25"), 39, new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a"), 41 },
                    { new Guid("6c17e334-29fd-4581-9b6a-2c9b50e67e45"), 57, new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682"), 44 },
                    { new Guid("6ca508ac-7e12-4b08-8d38-e66cab188f58"), 127, new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380"), 39 },
                    { new Guid("6dc52d7f-04ce-4b33-9929-84f6b690e55b"), 147, new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861"), 40 },
                    { new Guid("704ca330-cac6-4053-bb67-633cb556d700"), 7, new Guid("f1c14f0a-477a-42af-9707-383fb976ce12"), 39 },
                    { new Guid("70ab487b-f850-4923-8432-5bc69c218a1a"), 77, new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b"), 37 },
                    { new Guid("715c7a1f-7125-41eb-8da8-6ea344bb2d1f"), 136, new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158"), 42 },
                    { new Guid("735aeb13-a396-4f25-b018-b7b625a75555"), 97, new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e"), 43 },
                    { new Guid("74060135-f8ce-438b-9580-d86791874712"), 93, new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158"), 39 },
                    { new Guid("75c1ef1d-f255-4ae2-8e12-5600db9b4b97"), 145, new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f"), 42 },
                    { new Guid("75f77759-1983-41d1-8af6-0e07488325d5"), 146, new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa"), 42 },
                    { new Guid("77c6081a-a50d-4b65-ae7c-65396ec1ff52"), 86, new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6"), 42 },
                    { new Guid("78828cf0-d41b-49ef-a18b-a417603895d9"), 96, new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448"), 42 },
                    { new Guid("79c638dd-ae88-4c48-9c66-a4640387ef85"), 143, new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48"), 46 },
                    { new Guid("7b75c9aa-c939-4fe7-a125-cb85f2bf8a29"), 35, new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48"), 42 },
                    { new Guid("7d99443e-1a25-4cd6-bcb6-cb6a3339ad29"), 5, new Guid("cdeb9991-309a-4a9f-9376-07458763de5b"), 43 },
                    { new Guid("80cb05a6-c9ad-43b8-ad0f-777511285720"), 148, new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3"), 37 },
                    { new Guid("8be99bd3-15d7-4359-9526-c117127b1e9e"), 7, new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4"), 42 },
                    { new Guid("8c9b246c-1d19-4673-9dd8-0ddf1ba9a1c2"), 130, new Guid("3e9610d8-5ace-4184-811b-0e1a7efaa5fa"), 40 },
                    { new Guid("90203bf8-59ab-44cd-9213-cfd003ba0310"), 49, new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a"), 37 },
                    { new Guid("9116bd49-0bec-4d6d-a030-81bd405fef44"), 15, new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e"), 45 },
                    { new Guid("91599248-43d2-4627-964c-4b1223273b7f"), 27, new Guid("6bbd98fc-5762-4b59-a39a-40d3cbee5861"), 42 },
                    { new Guid("93086d59-743a-4ef6-9dc7-8599e7103b27"), 70, new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12"), 44 },
                    { new Guid("93c2a56d-10da-4f52-b969-eb7c987892f1"), 39, new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158"), 40 },
                    { new Guid("987ec53f-f503-4699-8652-691a1624d3e2"), 0, new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448"), 41 },
                    { new Guid("9aec305d-cebd-4dfb-9b5f-34c03522c47a"), 105, new Guid("cdeb9991-309a-4a9f-9376-07458763de5b"), 44 },
                    { new Guid("9b7df719-e318-47c7-8b44-a374f3971c24"), 37, new Guid("2fb9df88-972a-487f-af2f-60ebf15773d4"), 44 },
                    { new Guid("9bc38dda-7ab3-4d31-97ea-17a2c139b6ac"), 65, new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3"), 39 },
                    { new Guid("a037f981-8093-4aa7-8e3c-488d8750fa12"), 23, new Guid("350bc79d-8712-49d7-8b59-f01f8b3c2448"), 43 },
                    { new Guid("a1821347-46d3-4147-9ad6-dd143889fc52"), 144, new Guid("88cce454-97e8-4e2c-88f0-db5412135c66"), 40 },
                    { new Guid("a1b49048-a16e-4f63-acdd-30124ea8a364"), 69, new Guid("3ee4331d-1cc6-44c8-a9e6-4c3051697b12"), 45 },
                    { new Guid("a1c1a374-dc5a-437e-9c83-b957a920a855"), 141, new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e"), 42 },
                    { new Guid("a5f7f89b-e52f-463e-b2b4-173a9b8e243b"), 23, new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9"), 41 },
                    { new Guid("a6315754-fe11-47b2-9f55-65ba2f281f92"), 42, new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e"), 44 },
                    { new Guid("a78d3386-2e13-452b-9601-089953bb8dd5"), 55, new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b"), 39 },
                    { new Guid("a9aac382-4121-4667-b26c-d6e902a9c19b"), 125, new Guid("e28108df-171b-44a8-8971-b422ac0e53f3"), 40 },
                    { new Guid("b0beebdc-3e7f-4315-9f49-1842f4aba9a8"), 140, new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22"), 41 },
                    { new Guid("b2abd2d4-ec8c-4c13-8a04-8f1051a51a90"), 55, new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9"), 38 },
                    { new Guid("b8aa5c50-4383-45c9-894f-c355906d11a1"), 138, new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b"), 40 },
                    { new Guid("b93657ff-4476-4c38-8f9f-cdedfc01c738"), 83, new Guid("c11f48dc-cc8a-4057-9daa-6dd9e7d71bc6"), 43 },
                    { new Guid("b9592637-7575-455c-895a-6f756bb96730"), 107, new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379"), 45 },
                    { new Guid("bc929ce1-ee1b-42d7-aee6-849ab6b81cf3"), 12, new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b"), 38 },
                    { new Guid("bcacc0d7-f3b1-478e-a4e5-c7cdd9381a86"), 43, new Guid("cdeb9991-309a-4a9f-9376-07458763de5b"), 46 },
                    { new Guid("bf26cf04-516a-4411-8aff-93b72284e5c3"), 109, new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3"), 40 },
                    { new Guid("bf39f0a6-4d5d-47a9-9f71-423067325df5"), 128, new Guid("5f27a1e1-1899-4ce9-86ce-2cbf37e7795c"), 39 },
                    { new Guid("bf8cdcc2-893f-4321-9ed1-d576ccc40b4b"), 26, new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380"), 42 },
                    { new Guid("c2c55629-66e9-4946-9c20-bbe62110247e"), 131, new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6"), 38 },
                    { new Guid("c3f30e60-6e3d-4d73-a9ec-558ce0368ce6"), 63, new Guid("458cf46a-ac19-4009-be36-f5cc5b25f4d3"), 38 },
                    { new Guid("c451a72d-8dbe-412b-b4e2-33c9d5a938b3"), 15, new Guid("496d4ace-a31d-48c3-a6f0-33aee8a37379"), 43 },
                    { new Guid("c51f6309-7d92-4c0b-937e-05bf9d9e2fd5"), 114, new Guid("88cce454-97e8-4e2c-88f0-db5412135c66"), 42 },
                    { new Guid("c5d6be92-6697-49e2-a820-d68eb7a8d0c0"), 43, new Guid("154bc6a9-13d9-45c3-a6d3-3620eab2a63f"), 40 },
                    { new Guid("c6879eee-4100-4b86-a228-d1267ff9aca6"), 147, new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a"), 40 },
                    { new Guid("c739b094-65e6-491e-a185-92fd6b1fd997"), 25, new Guid("d9156673-b3d5-438c-9e82-e5d447bab60b"), 40 },
                    { new Guid("c7d958a9-b558-4781-acfb-7a6f18717f96"), 72, new Guid("cdeb9991-309a-4a9f-9376-07458763de5b"), 42 },
                    { new Guid("c898b62d-5a13-4e8d-a2fd-6ec5b2994e91"), 45, new Guid("f1c14f0a-477a-42af-9707-383fb976ce12"), 40 },
                    { new Guid("c8a84fc0-1f96-466c-8f92-0cbf96eec778"), 90, new Guid("c4d0e491-7479-40f3-bef6-e36381cab264"), 43 },
                    { new Guid("cc3ae1b7-8025-4d1d-9442-a1275da529a3"), 27, new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48"), 44 },
                    { new Guid("cc8ad273-bc2f-4f17-a642-a85aad3f4e3a"), 149, new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22"), 40 },
                    { new Guid("cea801c6-7136-4044-8544-45573c1e1dbf"), 3, new Guid("b9bf87ec-b53b-42d2-b13f-1472b3a9465a"), 38 },
                    { new Guid("d4782d00-63d8-4979-a5cc-7dd2f58841e2"), 44, new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158"), 38 },
                    { new Guid("d47e649c-351c-47bd-8deb-8bd587965e53"), 79, new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9"), 39 },
                    { new Guid("d49c29db-114b-40d2-b0b1-1e3a31cc1263"), 145, new Guid("78315a11-2f8a-46ae-ab37-48eb419282f6"), 41 },
                    { new Guid("d743c8a7-a8c0-4318-ab9e-df6f177513f9"), 110, new Guid("c6fc1356-7278-4c31-81db-102ad229bf6b"), 38 },
                    { new Guid("db6d0f82-940b-44df-bee5-2e49fb04eff5"), 140, new Guid("cbb735ba-0f5b-421b-ad82-00ab3bf58158"), 41 },
                    { new Guid("dcb95db4-bcf0-4346-a942-1b409bca3afb"), 88, new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380"), 40 },
                    { new Guid("dcd82b1f-1637-4f45-a742-0a1ac85cc246"), 99, new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22"), 39 },
                    { new Guid("e03e39a6-d606-4886-ad2e-59fc4374f9a0"), 123, new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e"), 41 },
                    { new Guid("e5b38e97-77b3-4366-ad86-25ffc0f1c736"), 37, new Guid("f1c14f0a-477a-42af-9707-383fb976ce12"), 42 },
                    { new Guid("e7176e6e-846c-44ba-99d4-2e946b570055"), 92, new Guid("358a24cc-b1a9-45da-9c8c-8989f5e89682"), 40 },
                    { new Guid("e89071d9-c9bc-48b8-8015-0db5421a84fa"), 51, new Guid("1cd3c4b7-7114-41d8-8019-4a27889d4f22"), 38 },
                    { new Guid("ea8df92e-224c-4a28-9731-22b513892391"), 121, new Guid("2ee19549-5599-4a83-8628-b3e9cd5d9152"), 45 },
                    { new Guid("ee912309-c7d0-4bd9-94f5-59b5aebb1b60"), 59, new Guid("c4d0e491-7479-40f3-bef6-e36381cab264"), 44 },
                    { new Guid("f0848174-b5b5-4243-9922-56844308a555"), 136, new Guid("d44cfa78-ada0-46d4-b0e5-e472f89e477e"), 42 },
                    { new Guid("f1528d49-56d5-493c-adfb-7f161035b245"), 100, new Guid("0a29a6bf-3aa3-48fc-8724-b268099f8d1e"), 44 },
                    { new Guid("f16f07a7-df27-43fa-b95e-fad092ce5ac1"), 123, new Guid("0b9f10c3-bcb6-4316-ac59-0d49938d7e3a"), 40 },
                    { new Guid("f2823fdf-1310-41ec-b4d6-0432c7421d76"), 77, new Guid("d3aacf22-ad66-4b26-8e92-45d0d7ab6380"), 41 },
                    { new Guid("f96bb2d2-7b0e-4549-a416-400acc659292"), 44, new Guid("8d8e60c7-6321-4d6c-a9b0-194f642a83b9"), 37 },
                    { new Guid("fd219a61-b4bb-4020-a9f1-37ba49809beb"), 0, new Guid("2b8412f6-7c77-4174-9fd9-f569e653bb48"), 43 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "CreateDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "IsExternalLogin", "LastModifiedDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileName", "ProviderName", "RoleId", "SecurityStamp", "TotalMoney", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7fe148e0-c59d-46d3-bc11-e986ac1a8c81"), 0, null, "b736200c-93c3-4380-ab17-bfc482fcafba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, "Jane", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("c9cdcdc3-2e5d-4911-8e9f-201f0ce9fc44"), null, 1500m, false, "jane.smith" },
                    { new Guid("a3b63dd2-36b8-45d3-96d8-6d962ab36461"), 0, null, "dd81852c-cf4d-4814-97f8-9756c80a6587", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2204, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "machgiahuy@gmail.com", false, "Mach", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gia Huy", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("36192faa-c226-4dba-a224-c5f4ca77595f"), null, 1000m, false, "Mach Gia Huy" }
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
