﻿using System;
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
                    Stock = table.Column<int>(type: "int", nullable: false),
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
                name: "ShoeColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoeColors_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
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
                name: "ShoeSizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ShoeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoeSizes_Shoes_ShoeId",
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
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    { new Guid("6ad35d46-5478-44a2-9488-cee17edab89f"), "Role User với các quyền hạn có giới hạn và mua hàng", "User" },
                    { new Guid("b926c80b-af39-4157-9748-2ccdc040add1"), "Role Admin với đầy đủ các quyền hạn", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "AverageRating", "Brand", "Category", "CreateDate", "Description", "Discount", "Gender", "ImageUrl", "IsSale", "LastModifiedDate", "Material", "Name", "Price", "Sold", "Stock", "TotalRatings" },
                values: new object[,]
                {
                    { new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0"), 4.1m, "Puma", "Yoga", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6546), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6547), "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 100, 22 },
                    { new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), 4.7m, "Nike", "Basketball", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6413), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6414), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 80, 45 },
                    { new Guid("1b85b3c9-7b46-488d-810e-3ec01876ebb8"), 4.7m, "Puma", "Football", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6691), "One of the best shoes for football and the symbol of Puma's World. You won't be able to take your eyes off of this brand new FUTURE, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6692), "Leather, fabric, foam, and rubber.", "Puma FUTURE 7 Ultimate FG/AG The Forever Faster", 2713000m, 78, 100, 55 },
                    { new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), 4.9m, "Nike", "Yoga", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6495), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6496), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 156, 66 },
                    { new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6541), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6542), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 100, 23 },
                    { new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f"), 4.2m, "Puma", "Football", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6535), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6536), "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 100, 17 },
                    { new Guid("4dd36f0e-4565-4a1a-81d3-8076d9f573c6"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6575), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6576), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 200, 111 },
                    { new Guid("501db903-775b-4421-899a-0ba8f8900a60"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6565), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6566), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 100, 20 },
                    { new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), 4.4m, "Converse", "Basketball", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6660), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6661), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 120, 34 },
                    { new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 4.2m, "Nike", "Tennis", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6487), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6489), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 40, 5 },
                    { new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6551), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6552), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 200, 87 },
                    { new Guid("65609372-386a-452e-804e-308ebf56d5d5"), 4.7m, "Converse", "Yoga", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6670), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6671), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 70, 30 },
                    { new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6665), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6666), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 200, 100 },
                    { new Guid("669ecd2f-bfcb-429c-886d-8b2294f591cf"), 7m, "Nike", "Basketball", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6675), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6676), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 17, 5 },
                    { new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6647), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6648), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 100, 10 },
                    { new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6512), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6513), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 200, 84 },
                    { new Guid("91187975-a547-4548-9a0d-0a603073b473"), 4.0m, "Puma", "Basketball", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6530), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6531), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 100, 21 },
                    { new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b"), 4.8m, "Nike", "Football", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6419), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6420), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 92, 10 },
                    { new Guid("959d723f-8966-4875-9887-abf1c73a37ce"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6642), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6643), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 100, 10 },
                    { new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6501), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6502), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 700, 381 },
                    { new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6654), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6655), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 80, 45 },
                    { new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6559), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6559), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 90, 25 },
                    { new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6523), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6524), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 50, 3 },
                    { new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), 4.4m, "Adidas", "Football", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6507), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6508), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 100, 37 },
                    { new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6518), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6519), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 500, 268 },
                    { new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6395), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6407), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 72, 20 },
                    { new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6570), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/noimage.webp", false, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6571), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 100, 12 },
                    { new Guid("da2351fe-aca6-4282-906f-bfbd7048e5c2"), 4.6m, "Nike", "Basketball", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6681), "One of the best shoes for basketball and the symbol of Nike's World. You won't be able to take your eyes off of this brand new Jordan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6682), "Leather, fabric, foam, and rubber.", "Jordan 1 Low Bred Toe 2.0", 1813000m, 45, 100, 23 },
                    { new Guid("fc7677a6-d7c2-4ef3-aa13-9d1397a26489"), 4.2m, "Adidas", "Basketball", new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6686), "One of the best shoes for basketball and the symbol of Adidas's World. You won't be able to take your eyes off of this brand new SuperStan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 19, 21, 54, 52, 520, DateTimeKind.Local).AddTicks(6687), "Leather, fabric, foam, and rubber.", "Adidas Original StanSmith", 1713000m, 65, 100, 33 }
                });

            migrationBuilder.InsertData(
                table: "ShoeColors",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("02b1cd59-2780-4997-9489-cc5214326ba4"), "Green", new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1") },
                    { new Guid("039ef229-1ee1-479e-80cf-36883ceea0b0"), "White", new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e") },
                    { new Guid("07c87c7f-7557-4bb1-bd4a-f4ef38a2179f"), "Black", new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb") },
                    { new Guid("0988acce-a97c-4e28-adc4-2fa2cbd28e9b"), "Blue", new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb") },
                    { new Guid("0a433736-b313-493b-b110-b5e1dc9f3551"), "Purple", new Guid("d688e565-ca0e-4bc5-9c09-925951215a42") },
                    { new Guid("0b7e717f-9fdb-4784-81a7-a603877be31d"), "Black", new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1") },
                    { new Guid("0ecbcbbc-0957-47ec-841b-fa420a77fb5e"), "Black", new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e") },
                    { new Guid("2311771e-378b-4e64-b397-bedb8bb116c3"), "Purple", new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e") },
                    { new Guid("32d03850-7303-4a4a-b751-809242e7ac41"), "White", new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b") },
                    { new Guid("38c2e881-f3e4-4dec-a451-2fc5a65a17e6"), "Black", new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f") },
                    { new Guid("3dd9165c-4832-43b6-b4f7-e1c2c4dea8d1"), "Pink", new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0") },
                    { new Guid("4593169d-7716-49b1-90b4-e6f4a98e820b"), "Black", new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76") },
                    { new Guid("487f4896-e456-4467-a7b6-6ec1d0329469"), "White", new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274") },
                    { new Guid("4881495a-3772-49b5-b647-eadd11c26b47"), "Black", new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e") },
                    { new Guid("4a8a4e8c-f367-46ed-8887-a28b5b1e8ab2"), "Pink", new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b") },
                    { new Guid("4ccc6d13-271d-4a71-aef6-224a372e472e"), "Brown", new Guid("65609372-386a-452e-804e-308ebf56d5d5") },
                    { new Guid("51ae8180-63c2-4e22-b4be-fb97a90de071"), "White", new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76") },
                    { new Guid("52777372-b05c-4643-93f4-cf97ec70810d"), "Pink", new Guid("501db903-775b-4421-899a-0ba8f8900a60") },
                    { new Guid("583b5946-3273-47fa-be9b-cd7a16d31b26"), "Orange", new Guid("208e66df-537f-4b10-9e0d-080b87c458f5") },
                    { new Guid("58d2b114-86b1-4fd0-bce9-0b1187f763e0"), "Red", new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb") },
                    { new Guid("5d3e0768-1e67-4a4c-9d3f-554e5e66f294"), "Black", new Guid("208e66df-537f-4b10-9e0d-080b87c458f5") },
                    { new Guid("5e335d6b-48a0-47ed-b750-b5647faf490d"), "Black", new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b") },
                    { new Guid("62e85995-8e52-4323-b209-a42a52c5e08f"), "Black", new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7") },
                    { new Guid("69906d97-7681-4bfd-9838-826d9a6129d4"), "Black", new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656") },
                    { new Guid("7314c765-9a0a-4d7a-bb9c-69aa46162198"), "Blue", new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272") },
                    { new Guid("745e6ba4-7e03-4673-945b-960d26b1d958"), "Orange", new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b") },
                    { new Guid("797f98e4-ecfc-4575-876f-b79d761ad2fc"), "Blue", new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b") },
                    { new Guid("87bb5065-89dd-49c3-969f-2470d376d4f3"), "Red", new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76") },
                    { new Guid("8823f9da-fccc-43a6-b3bf-8a2d7dca9ed3"), "White", new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656") },
                    { new Guid("8c94d12c-d7d1-475f-b6b7-ccbdd1710523"), "Black", new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b") },
                    { new Guid("8d64af9e-56cd-4743-96e2-8d3aa3775adf"), "White", new Guid("d688e565-ca0e-4bc5-9c09-925951215a42") },
                    { new Guid("8de492ff-0ce2-4880-a946-9a01cc26157f"), "White", new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb") },
                    { new Guid("8fcc65a7-1a2f-4077-acf7-da5986e8e601"), "Black", new Guid("d688e565-ca0e-4bc5-9c09-925951215a42") },
                    { new Guid("91e3bb9c-2917-40a2-93fa-e5a43b9c0605"), "Purple", new Guid("91187975-a547-4548-9a0d-0a603073b473") },
                    { new Guid("91e3bd2d-daee-4ea3-82eb-7da43448d723"), "Black", new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b") },
                    { new Guid("986fc080-59d5-4c04-90ed-b347c408bb57"), "Pink", new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e") },
                    { new Guid("9a14ca8a-5fdd-42e9-bab1-d7db2b96bcdb"), "Orange", new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1") },
                    { new Guid("9e10e701-7b45-4279-b9a8-2a41506fce0b"), "Red", new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1") },
                    { new Guid("9e7b388d-10d5-41fc-b02d-fbe713954ed5"), "Blue", new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1") },
                    { new Guid("9f64e386-fe37-440c-a750-d4ff1a750019"), "Blue", new Guid("959d723f-8966-4875-9887-abf1c73a37ce") },
                    { new Guid("a3827d5a-90f3-41de-a312-09143e32f538"), "Green", new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f") },
                    { new Guid("b104dd69-4b58-4e21-8c6c-3ca73b43d9c1"), "Yellow", new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1") },
                    { new Guid("b2d63234-42ca-4827-8f12-dddaf98b297d"), "Blue", new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76") },
                    { new Guid("b8dcc5ce-3ec4-4230-a892-988a17199e7a"), "Grey", new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272") },
                    { new Guid("b925981f-ea85-40d0-a8fd-d07bfb0d9d15"), "Red", new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1") },
                    { new Guid("bf164598-5cd6-4e9d-b8e1-3ec2f40ed029"), "Blue", new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f") },
                    { new Guid("c953ad84-a38e-452a-a11f-0b39e1d3ef36"), "White", new Guid("4dd36f0e-4565-4a1a-81d3-8076d9f573c6") },
                    { new Guid("cdc6006f-bd54-4228-a71a-679ec669a8bf"), "White", new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1") },
                    { new Guid("ceccdcca-8bcd-4d44-b1e1-8cabc5b7e940"), "Orange", new Guid("91187975-a547-4548-9a0d-0a603073b473") },
                    { new Guid("d75ad447-08c3-49a2-9ba8-c21da0d34b11"), "Pink", new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb") },
                    { new Guid("d9491b66-48bb-4dcb-b221-c786b130faef"), "Yellow", new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b") },
                    { new Guid("dd6803f0-a304-4717-86df-0d20c8405e32"), "Blue", new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87") },
                    { new Guid("e0cead86-7cf0-4f27-9c4e-e1c74641c446"), "White", new Guid("208e66df-537f-4b10-9e0d-080b87c458f5") },
                    { new Guid("e4b654e3-3b5f-4d2f-95d8-4ee6d64608d1"), "Brown", new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656") },
                    { new Guid("e6e02030-9b6f-4ea3-a899-2ab2e81bace9"), "White", new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e") },
                    { new Guid("ecfae5a6-8fa0-4359-9e60-b34be44df112"), "White", new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272") },
                    { new Guid("ed54e553-7d44-46ff-a3e9-255d8076495d"), "Blue", new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0") },
                    { new Guid("f0bb3181-8f36-4dcc-8cee-7721e7b9abfa"), "Brown", new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274") },
                    { new Guid("f19d3994-d58c-41f1-9258-aa76ec990c98"), "Blue", new Guid("d688e565-ca0e-4bc5-9c09-925951215a42") },
                    { new Guid("f56bd5c6-feb7-4bba-8f56-7948b1d07c3a"), "Green", new Guid("65609372-386a-452e-804e-308ebf56d5d5") },
                    { new Guid("f62ceff7-ed84-46bb-b405-3e28aa81840c"), "Black", new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f") },
                    { new Guid("fa31a1ab-a7af-4331-bc12-cb2f582c1751"), "Black", new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272") },
                    { new Guid("fb33c04b-4b9b-4ee1-9723-4d7ce0135c6d"), "Blue", new Guid("501db903-775b-4421-899a-0ba8f8900a60") }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("0045d7c0-47de-456c-b0c2-c38a934a2a32"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), "images/shoes/[IDGiay_7]_AnhChinh.jpg" },
                    { new Guid("00d68a5b-0519-407c-b2cf-30faed9fb9fb"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), "images/shoes/[IDGiay_23]_AnhChinh.jpg" },
                    { new Guid("00f256bd-5086-4c55-8817-a9c07c854426"), new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("024d95c6-9c80-4a26-9981-a03915cf18ab"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("037fa8eb-3c2a-4197-9cc9-30a25c2f84aa"), new Guid("959d723f-8966-4875-9887-abf1c73a37ce"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("06a8ba81-01d4-40ec-bb22-2c46ad853aa8"), new Guid("65609372-386a-452e-804e-308ebf56d5d5"), "images/shoes/[IDGiay_25]_AnhChinh.jpg" },
                    { new Guid("09800e83-8130-4310-b8db-d29d15c53353"), new Guid("4dd36f0e-4565-4a1a-81d3-8076d9f573c6"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("0aa182a0-ab15-4074-acbe-f1ad62fac18f"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("0cad11a4-6a19-447a-8fe8-136a999b95cf"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), "images/shoes/[IDGiay_2]_AnhChinh.png" },
                    { new Guid("0d5d2b5a-d3f1-4f6a-90d6-7a12109c434f"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("13f67145-31b9-4f27-bb12-c46447113609"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("1416310a-e00c-4eea-9180-c9b9e58315d4"), new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("1430a36c-2c75-4677-9b92-e2da9f4bdea9"), new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("162b5d4b-94f4-4ee7-80c1-8ce2b11c0160"), new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("16e44676-d51a-4dba-b657-54822831bc53"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), "images/shoes/[IDGiay_16]_AnhChinh.png" },
                    { new Guid("17c36efc-5613-420d-bd9b-e58cd9cfcbf1"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("195ea6c2-b4c8-4293-85a8-f048bd781ca8"), new Guid("669ecd2f-bfcb-429c-886d-8b2294f591cf"), "https://c.files.bbci.co.uk/1081F/production/_117751676_satan-shoes2.jpg" },
                    { new Guid("19d77bd8-d609-4be5-8bd5-f7b7e915306a"), new Guid("959d723f-8966-4875-9887-abf1c73a37ce"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("1c2fd5fe-6b2a-4e4b-be20-fa130b0df65f"), new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("1e64539f-e2b9-4154-94ef-3e9997d64e5c"), new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("1ffee96e-2ab6-424b-9655-d714271f79e2"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), "images/shoes/[IDGiay_13]_AnhChinh.jpeg" },
                    { new Guid("200489fe-190b-40b5-ad15-d958d44efbdd"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("2128c5a9-5e24-42c9-8562-dbb743e1da4d"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("216ae64c-f681-48ea-b1c4-5e55c7a0c5c0"), new Guid("65609372-386a-452e-804e-308ebf56d5d5"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("229464e9-7e1a-4091-b2bb-0661c78d41ac"), new Guid("91187975-a547-4548-9a0d-0a603073b473"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("241dbae6-8d1a-40cc-8c2b-3e32627091e1"), new Guid("65609372-386a-452e-804e-308ebf56d5d5"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("258e6aaf-8289-45c7-8564-af56482939cf"), new Guid("959d723f-8966-4875-9887-abf1c73a37ce"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("291f4c82-07e9-4467-a7a1-7d36505cdf65"), new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("2ebf9d5c-03ae-4817-88c8-0a24192b5d13"), new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0"), "images/shoes/[IDGiay_14]_AnhChinh.jpeg" },
                    { new Guid("2f642acc-512f-49b6-916d-a899f9674c2f"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("35e0b3c3-a7a5-4850-8938-66cd53b4a152"), new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("3aee5fb6-1175-41bb-a7b8-61062d537772"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("3b84ee47-9587-4549-98e1-c686fc06a839"), new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("3bdfb035-c0c8-42a6-afdf-404dd3445e5b"), new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("3c0c60ab-7ab9-4071-8cae-6405a0d62b6d"), new Guid("1b85b3c9-7b46-488d-810e-3ec01876ebb8"), "https://thumblr.uniid.it/product/336262/57daee260d2a.jpg?width=3840&format=webp&q=75" },
                    { new Guid("3f927835-5910-4462-a0c2-a80079422cb0"), new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), "images/shoes/[IDGiay_5]_AnhChinh.jpeg" },
                    { new Guid("406ae6f1-4160-4587-a6d6-2f686b75e866"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("40a105ea-6471-4eb9-9cf1-ae06d29abefc"), new Guid("4dd36f0e-4565-4a1a-81d3-8076d9f573c6"), "images/shoes/[IDGiay_19]_AnhChinh.png" },
                    { new Guid("42a31c33-3f93-460c-89d0-5b7db8fa3308"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), "images/shoes/[IDGiay_6]_AnhChinh.jpg" },
                    { new Guid("42b339ed-0a1a-4874-a885-a2db3d7db039"), new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("4777a14d-7cf6-40f7-a78b-e041c41a7495"), new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f"), "images/shoes/[IDGiay_12]_AnhChinh.jpeg" },
                    { new Guid("47ee7e87-2689-4b93-b496-314c98bba9f4"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("4ad23f2d-00af-4e00-b976-b15a4982a8a1"), new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("4cdae8b2-75f9-4506-9391-7580330ec9df"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("50997931-f60c-4e23-970d-7e6c25999f23"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("533637ad-ef16-4702-bd51-dfcad5d46d8f"), new Guid("91187975-a547-4548-9a0d-0a603073b473"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("53a61b9f-9b32-4695-ba61-ab3f5e987f35"), new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), "images/shoes/[IDGiay_9]_AnhChinh.jpg" },
                    { new Guid("57ee88b5-c32f-4456-897f-e5f99709ef79"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("59a88bd4-102f-4d60-a8ed-fafa4d343d60"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("59cbb251-3ef4-49be-8175-65d3baab31ca"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("5b75110d-368b-485a-83d5-0534c3115477"), new Guid("669ecd2f-bfcb-429c-886d-8b2294f591cf"), "https://media.cnn.com/api/v1/images/stellar/prod/210328223753-03-lil-nas-x-satan-shoes.jpg?q=w_3000,h_3000,x_0,y_0,c_fill" },
                    { new Guid("5ddc2825-5355-489a-8ccd-b9f8c70e7ae4"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("5dea9118-ae79-4c8e-9486-0855cbc52727"), new Guid("959d723f-8966-4875-9887-abf1c73a37ce"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("609351ff-763b-45ff-89ae-d91d5fc468d2"), new Guid("da2351fe-aca6-4282-906f-bfbd7048e5c2"), "https://dmpkickz.com/cdn/shop/files/6_78fd24e0-cd30-400a-8fa1-e5e6cd3c5b0b.png?v=1696679846&width=480" },
                    { new Guid("634a58bd-2edc-4d7e-9655-b24c07a40163"), new Guid("4dd36f0e-4565-4a1a-81d3-8076d9f573c6"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("642d224b-1d5b-46af-8e2d-6689873b1254"), new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("6438fbf6-e9ab-45d7-aca5-3fe097d4ffb2"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("64cbe7ef-27fd-4d05-9720-73c08d00ed7b"), new Guid("65609372-386a-452e-804e-308ebf56d5d5"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("65290590-552d-474f-b839-92c75d2f81cd"), new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("66b0c6c1-69fa-480c-b9bc-44b585980f1a"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("675a7859-5f72-46b5-b914-141a07b794dc"), new Guid("1b85b3c9-7b46-488d-810e-3ec01876ebb8"), "https://www.prosoccer.com/cdn/shop/files/PumaFuture7UltimateFGAG-ForeverFasterPack_SP24_Model1_1500x.png?v=1713488175" },
                    { new Guid("67639517-aa38-40c8-ae79-e981ea3f65c4"), new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("6771bc08-4d9b-419e-bfd2-c8275d5cf3f5"), new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("6a1f8375-7084-4d9f-aec9-49e2c67c1300"), new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("6f41b0d2-b962-49d5-b648-996bb4416393"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("70fee227-e71d-4bde-bfec-e111b4ddb36c"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), "images/shoes/[IDGiay_10]_AnhChinh.jpg" },
                    { new Guid("731c16fa-c4db-43c3-a89b-3fbdd3f2644f"), new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("7596e9f1-7a68-45c0-ad85-cc7603309cc9"), new Guid("65609372-386a-452e-804e-308ebf56d5d5"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("7753b6f6-4703-4272-aa3c-49377425ff2a"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("791f5f26-4614-4774-8c8d-f21283a9000e"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("7c0a8498-8537-4ee6-a146-e1d9dd3c275b"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("7df642fe-bb4f-4002-855a-ce202b91e8d2"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("7eba3ae9-e055-45e3-ba29-403df86dd1a4"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("7ff9a0f4-08b4-40bd-8e5f-c7549b9430b9"), new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("80b4d1b7-3111-46d9-95e8-6b44c6084d96"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("81102a30-4701-4d3b-bf72-d0dcac4ee41b"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("889fece0-d7b6-45b1-bf3a-f0f0bc4c2386"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("8b763082-aa44-446e-9602-01d9458e1488"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("8c818cbc-871c-4e3d-ac62-78a4d8fa7fd6"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("90393381-960e-4965-a2c1-d74de78c9c8e"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), "images/shoes/[IDGiay_22]_AnhChinh.jpg" },
                    { new Guid("92a37486-1970-4983-a574-6769cd19973d"), new Guid("91187975-a547-4548-9a0d-0a603073b473"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("932f5e8e-eeb9-46c6-a035-d88aeb63c4de"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("93f7a45e-3f9e-40f8-811a-d39f6528b073"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("94afaf1d-5a83-4ad7-bea0-4ff8eb7f7f21"), new Guid("669ecd2f-bfcb-429c-886d-8b2294f591cf"), "https://i.pinimg.com/originals/c0/cf/d1/c0cfd1545f10c56793e888e991b60487.png" },
                    { new Guid("95e0b611-3a36-47e7-98a5-7f2782d9d2d6"), new Guid("669ecd2f-bfcb-429c-886d-8b2294f591cf"), "https://photo.znews.vn/w660/Uploaded/rohunwa/2021_03_26/SHOES3.jpeg" },
                    { new Guid("98fe9748-1220-4487-a464-6c497c6f83b9"), new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("991c0462-31bf-424d-b67a-0986fd8e311a"), new Guid("91187975-a547-4548-9a0d-0a603073b473"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("9bb3515b-644c-4dff-ad30-d56a4d82830b"), new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("a35faba1-d72b-4d18-8f1a-d28397f35461"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("a44a6632-b4c5-4946-8130-e5211b4cd1d5"), new Guid("91187975-a547-4548-9a0d-0a603073b473"), "images/shoes/[IDGiay_11]_AnhChinh.png" },
                    { new Guid("a5d702ce-9480-4872-9f0d-1042befab833"), new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("a5f9fdc3-5865-42eb-9860-14c9dc53cd72"), new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("a6e5dc48-074e-4e54-b28c-50fe8e5c622d"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("a8eaf5e5-2f63-4f54-9fe2-2325a618768e"), new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("aa717123-a236-4bcd-9219-6aa12ba37812"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("aae8197f-366c-4ed1-a78d-9122f7925d81"), new Guid("669ecd2f-bfcb-429c-886d-8b2294f591cf"), "https://gossipdergi.com/wp-content/uploads/2021/04/nikeayakkabi.gif" },
                    { new Guid("aaf4faea-80e1-42c8-acdc-b432c144b1fe"), new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("ab723f11-3fbc-436e-a724-6cdf5959dca8"), new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("acd0ed93-f2f3-434e-a613-dee9b43c42b4"), new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("ad1ed956-1635-45df-8717-ddefa226bfbb"), new Guid("fc7677a6-d7c2-4ef3-aa13-9d1397a26489"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-3.jpg" },
                    { new Guid("ad4610ef-9933-46b9-af0f-3a6ba3374fc2"), new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("adcb1dd8-fc47-40ed-9eac-e6cda0a11ea0"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("aea09c06-c75b-4316-87ef-e3da0273033f"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), "images/shoes/[IDGiay_21]_AnhChinh.jpg" },
                    { new Guid("b315ae50-2acd-41ff-ac67-65b5aea221cf"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("b42d294d-8e1d-499a-a486-b2a7e4213bec"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), "images/shoes/[IDGiay_4]_AnhChinh.jpeg" },
                    { new Guid("b5cd153f-ecba-411f-81c6-8232167a371f"), new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0"), "images/shoes/[IDGiay_18]_AnhChinh.png" },
                    { new Guid("bac90626-681d-478c-a414-6c66fac18ad8"), new Guid("4dd36f0e-4565-4a1a-81d3-8076d9f573c6"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("bbc30f5f-9eae-4e6a-a8cb-9c9699cbd972"), new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("bc204150-65f4-4a03-afdf-49cdbf128385"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("c3ecad6e-dabe-42ae-ba69-d0530874992d"), new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("c5528465-a5a7-4bfb-94bc-df482d86ad41"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("c7f1d46e-06c3-4bb0-858c-fc195a69986c"), new Guid("959d723f-8966-4875-9887-abf1c73a37ce"), "images/shoes/[IDGiay_20]_AnhChinh.png" },
                    { new Guid("c9526d15-e470-441e-82ce-15f4211a492e"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), "images/shoes/[IDGiay_1]_AnhChinh.png" },
                    { new Guid("c9d04ab1-dae4-4ae6-9a98-d6612767bfa1"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("ca04ea77-fdad-40cc-9ae8-bf1efb1894d3"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), "images/shoes/[IDGiay_17]_AnhChinh.png" },
                    { new Guid("cba314a1-e7fb-415b-859a-913af6a8e716"), new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e"), "images/shoes/[IDGiay_15]_AnhChinh.jpeg" },
                    { new Guid("cd8d50c6-3a0c-43a1-9eb2-c50b576e5e17"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("d0655a83-ec54-4341-8628-6b274951a045"), new Guid("da2351fe-aca6-4282-906f-bfbd7048e5c2"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3rZPCUSKRHdQA5_g3YBJRdcmIf_6PpZcNZg&s" },
                    { new Guid("d183b45d-0939-4709-8553-00ee6d4e102a"), new Guid("fc7677a6-d7c2-4ef3-aa13-9d1397a26489"), "https://likelihood.us/cdn/shop/files/stansmith_angle_1200x.png?v=1691430477" },
                    { new Guid("d797495b-4f89-4dd4-a9a5-a956bf071f77"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("d7ca88b3-1fd6-43d8-b749-46a7df65f755"), new Guid("fc7677a6-d7c2-4ef3-aa13-9d1397a26489"), "https://assets.adidas.com/images/w_1880,f_auto,q_auto/e53b9a57b0a745be924bac1e00f54427_9366/FX5502_42_detail.jpg" },
                    { new Guid("d7db3020-4c24-45d1-b2b4-67e3163fb2d6"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("d8ddf950-1cbb-4b24-a812-54aa6a85f3dd"), new Guid("da2351fe-aca6-4282-906f-bfbd7048e5c2"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNBQXFHswxHuyjT_e8rb5XOaWUzEe3pphPPw&s" },
                    { new Guid("dde3e845-f985-4425-bfeb-2a038854a52d"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("deaac5e8-b006-4cd9-807b-b61961761aaf"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("df26ec8f-32cc-4797-af90-2138c0738db4"), new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b"), "images/shoes/[IDGiay_3]_AnhChinh.jpeg" },
                    { new Guid("e10b0192-b166-44b7-ae28-8815f50118bd"), new Guid("1b85b3c9-7b46-488d-810e-3ec01876ebb8"), "https://thumblr.uniid.it/product/336262/a92a6cadc8a6.jpg?width=3840&format=webp&q=75" },
                    { new Guid("e2364859-c533-4973-9c18-79a47be3d59a"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("e51ed3d1-d9a3-4f27-873e-5c052475921b"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), "images/shoes/[IDGiay_8]_AnhChinh.jpg" },
                    { new Guid("e7639bcc-7069-4d45-9657-0e7b82f07246"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("e7869298-de72-48c0-8b84-6df55e274cd6"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("e7e9f2df-278c-4eed-a8bd-261bd0f1fe12"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("e95ec52b-cd0e-4311-99e9-b38cdf7dd8c1"), new Guid("da2351fe-aca6-4282-906f-bfbd7048e5c2"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQPenW_eiwOe1RkKeaF_kg5TraxKiem6NJ_Q&s" },
                    { new Guid("eb62d8f7-29b0-44e3-a3fa-d0ec12285dc3"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("ed221706-7140-4e28-bdd0-5aca0ecf19c3"), new Guid("4dd36f0e-4565-4a1a-81d3-8076d9f573c6"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("f5bb7056-05d5-4d62-949a-38aa86a360ca"), new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("f6921305-8b1c-4588-95e4-035ce0a7eb77"), new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("f8f5f059-c448-4d71-b551-36ca0b27a727"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("f984192c-0fba-457c-8467-f33a925021fc"), new Guid("1b85b3c9-7b46-488d-810e-3ec01876ebb8"), "https://thumblr.uniid.it/product/336262/8307c19dcf3d.jpg?width=3840&format=webp&q=75" },
                    { new Guid("fae21532-4fb2-446b-b6bb-777b53710393"), new Guid("fc7677a6-d7c2-4ef3-aa13-9d1397a26489"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-1.jpg" },
                    { new Guid("fb58b370-a4a7-493d-8c95-15f4413c3aef"), new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274"), "images/shoes/[IDGiay_24]_AnhChinh.jpg" },
                    { new Guid("fc9ef36e-c2cc-4b5b-942d-ee19c16dfd0e"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("00078cfd-1b3a-4499-be82-dbdfff5d76bf"), "Winter", new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f") },
                    { new Guid("025ed1b7-1f36-480f-adeb-c94318b2c79b"), "Summer", new Guid("959d723f-8966-4875-9887-abf1c73a37ce") },
                    { new Guid("091489dc-130e-4b17-a69d-702429805255"), "Spring", new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b") },
                    { new Guid("0b7487cb-487d-4a09-9c88-30e8f61ad1c4"), "Fall", new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1") },
                    { new Guid("0c796347-8e19-450f-81ab-7673637b9664"), "Summer", new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272") },
                    { new Guid("1a1572fc-8547-4376-a21f-bc7d122d118f"), "Winter", new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87") },
                    { new Guid("1b6fb99b-1b85-4e18-9bcc-b5a8e17cdc69"), "Spring", new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656") },
                    { new Guid("220181b8-ba9b-44ed-b543-a7095cc441ed"), "Winter", new Guid("4dd36f0e-4565-4a1a-81d3-8076d9f573c6") },
                    { new Guid("23279376-9a7e-49d2-9aad-35f931334c5d"), "Fall", new Guid("208e66df-537f-4b10-9e0d-080b87c458f5") },
                    { new Guid("26454ae1-465d-4d31-a74d-fab9b32199b5"), "Winter", new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76") },
                    { new Guid("2f5f20ad-4d26-4a7e-983a-b24bf37b8b2b"), "Fall", new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272") },
                    { new Guid("30508f4a-4cd1-4d91-ad06-95bc552018e5"), "Spring", new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0") },
                    { new Guid("33b36991-4bd2-471a-826c-9050796b5c75"), "Summer", new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e") },
                    { new Guid("36cbf366-e41e-437f-b70f-01adaef8c9f8"), "Spring", new Guid("d688e565-ca0e-4bc5-9c09-925951215a42") },
                    { new Guid("3d089f93-31f6-4401-af9b-114bb9b6302c"), "Winter", new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1") },
                    { new Guid("566bd1f7-518d-4020-a9ea-25d1315cb820"), "Fall", new Guid("91187975-a547-4548-9a0d-0a603073b473") },
                    { new Guid("57b153cf-331c-43fa-afbd-e4d941b2d3b4"), "Fall", new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7") },
                    { new Guid("5eadedbf-d70c-44e0-959b-6171bbacc2f0"), "Spring", new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274") },
                    { new Guid("64967f5e-792d-4d71-a3a6-db36bd104f27"), "Summer", new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f") },
                    { new Guid("6ca1174a-7391-482d-9b0c-2bf67f21089a"), "Summer", new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1") },
                    { new Guid("6fe5c2b0-19be-4c34-993d-329ed6afdc72"), "Spring", new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0") },
                    { new Guid("714f18f0-68b0-4b93-bb9d-dc5d674834c0"), "Winter", new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272") },
                    { new Guid("78408029-e7fd-4d7e-bc51-8705020ec765"), "Winter", new Guid("208e66df-537f-4b10-9e0d-080b87c458f5") },
                    { new Guid("79218d73-4ab0-481b-b03a-be65ce47f7d9"), "Summer", new Guid("d688e565-ca0e-4bc5-9c09-925951215a42") },
                    { new Guid("7c2b8e89-abe6-4e3c-892e-d9f259faf1c8"), "Fall", new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656") },
                    { new Guid("8667966e-04a2-4f82-9c4f-4b387bfc4ae0"), "Spring", new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1") },
                    { new Guid("87b52e99-fce5-4165-95bb-3feb385b20c8"), "Winter", new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7") },
                    { new Guid("9178f59c-c59f-4bb7-b10d-63680158c50d"), "Spring", new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f") },
                    { new Guid("921726c3-7e72-433d-9ec7-0b00e82f730f"), "Summer", new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1") },
                    { new Guid("93c7fc11-1d89-4b09-9398-3192bc17a530"), "Summer", new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7") },
                    { new Guid("96b87124-a132-470f-a481-b73b32edf824"), "Winter", new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f") },
                    { new Guid("9c92717e-82c6-44bb-b731-925e59cf0ea7"), "Fall", new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274") },
                    { new Guid("a801e224-99ef-4f94-a716-c8351632c614"), "Fall", new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f") },
                    { new Guid("b59cf423-c3e3-411d-b7be-bb18e8b9f7ed"), "Summer", new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76") },
                    { new Guid("b7fdca15-e1de-40dc-993f-11c6f272711c"), "Spring", new Guid("959d723f-8966-4875-9887-abf1c73a37ce") },
                    { new Guid("c2abd0a7-3e02-4ab9-a108-d290c3943da4"), "Fall", new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76") },
                    { new Guid("c5fe4f80-8987-4235-a311-265c9fc2d94b"), "Summer", new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0") },
                    { new Guid("cb604b61-39ba-4576-86fe-68be5930344d"), "Summer", new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0") },
                    { new Guid("ce9c69d4-d7c7-4888-bb09-609b8a45b831"), "Winter", new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656") },
                    { new Guid("d4f3fbc8-1042-4919-9e8c-01edacb26979"), "Summer", new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b") },
                    { new Guid("d5877042-d99e-4358-9561-9864d5ee218b"), "Winter", new Guid("501db903-775b-4421-899a-0ba8f8900a60") },
                    { new Guid("dd02986b-ca6b-4ad3-9d78-ff79df770c35"), "Spring", new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7") },
                    { new Guid("dee53dde-528d-44ac-b6cb-aa1c040e324c"), "Summer", new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656") },
                    { new Guid("e3561c0b-4de4-4449-9b8a-e898c69cb105"), "Spring", new Guid("65609372-386a-452e-804e-308ebf56d5d5") },
                    { new Guid("e7923fad-0766-4640-aa1d-efd555f6d41b"), "Spring", new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e") },
                    { new Guid("ebb85965-aa58-46e5-b83d-0975990e758a"), "Winter", new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b") },
                    { new Guid("f1845d3f-1bd0-4899-b363-41430926952b"), "Summer", new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b") },
                    { new Guid("f20b3ae1-a2d6-4c60-a77d-b85caff04de3"), "Spring", new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e") },
                    { new Guid("f28f3e00-33b8-4872-b5ff-4ea9f091efec"), "Winter", new Guid("959d723f-8966-4875-9887-abf1c73a37ce") },
                    { new Guid("f37cf5f1-abab-4978-86c9-6c4f0a3be44d"), "Spring", new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272") },
                    { new Guid("fa6f8565-d3b8-47b8-ab1c-5a73e7a9128e"), "Spring", new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb") }
                });

            migrationBuilder.InsertData(
                table: "ShoeSizes",
                columns: new[] { "Id", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("0157198c-e5da-4a6b-bdd5-49e6f07459c2"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 36 },
                    { new Guid("017fd604-f499-4739-a67c-0c4a6b40f369"), new Guid("959d723f-8966-4875-9887-abf1c73a37ce"), 38 },
                    { new Guid("0c28a52e-5105-4009-9d30-e82bf8ee2364"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 37 },
                    { new Guid("0c894c8c-c843-4cfd-9fa3-f6adcd399c87"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), 41 },
                    { new Guid("10409572-8eb6-48ac-bd18-48fa044b9a07"), new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b"), 44 },
                    { new Guid("12c9efd3-a95a-4e2d-8e2b-70b5bf4f17d6"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), 37 },
                    { new Guid("12d327ca-263c-4a03-829f-9211b1f55701"), new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), 43 },
                    { new Guid("13a5b56b-a10c-4f39-8d96-b27878bdb9c0"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), 36 },
                    { new Guid("1622e668-8950-4566-9e30-3842bee87ea3"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), 40 },
                    { new Guid("16cb6f0a-80d4-4fa8-b4e1-75906e47d373"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), 45 },
                    { new Guid("18f7bba2-4729-4ad9-9471-4a9a9b2d5be9"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), 42 },
                    { new Guid("1eee65ed-fc55-41e3-868c-85c2ac5b5883"), new Guid("959d723f-8966-4875-9887-abf1c73a37ce"), 40 },
                    { new Guid("20f5afd2-ce1a-4de5-8646-632ad95f673c"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), 44 },
                    { new Guid("211700ee-ad4f-4405-bffa-a04a680bdda2"), new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), 39 },
                    { new Guid("21bf619a-d0fd-4a40-b0b8-81f0f4d55672"), new Guid("91187975-a547-4548-9a0d-0a603073b473"), 45 },
                    { new Guid("2385cbc4-2025-4a0c-921a-b64986954f6c"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 39 },
                    { new Guid("23fb213b-58a0-4321-8f7c-2be226655c09"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 36 },
                    { new Guid("2b02cfa7-4a9a-4129-88ac-b459529b8ede"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), 37 },
                    { new Guid("2d886b13-6610-4bce-acb4-9db5e4fe575d"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), 43 },
                    { new Guid("2deb66cb-213e-4b2b-8885-dae809662a32"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 42 },
                    { new Guid("308010ed-97ef-4038-a526-2bca2d397947"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), 39 },
                    { new Guid("31c09fe9-8ac0-4b0b-9e1b-cfcc90b3410c"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), 39 },
                    { new Guid("320565d4-32d9-41ae-b6e6-781fce851057"), new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b"), 43 },
                    { new Guid("3262d651-7150-44f5-85c7-dcf0421f0c38"), new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e"), 44 },
                    { new Guid("32daec83-3174-4729-a4ee-f14c1e0fd460"), new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0"), 36 },
                    { new Guid("32e926f0-758a-42a0-8040-81dc2f712bbc"), new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b"), 42 },
                    { new Guid("369929f1-42ad-4dfd-bf75-3956f88efff9"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 36 },
                    { new Guid("37e5e810-217f-47cb-841a-9ad7bc03fc76"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), 38 },
                    { new Guid("3863d055-7078-4c05-93fb-6a9d56a0a8d5"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 40 },
                    { new Guid("3a7d1b11-fde9-48ee-98c2-09ebcc440be2"), new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0"), 37 },
                    { new Guid("3defa733-3668-4e8e-82e4-9077f3eb0a13"), new Guid("4dd36f0e-4565-4a1a-81d3-8076d9f573c6"), 44 },
                    { new Guid("3f32603f-c56f-4ccc-8686-4b0020ae8780"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), 45 },
                    { new Guid("3f5e483c-459e-4fd7-a777-73bfe0df2d1c"), new Guid("91187975-a547-4548-9a0d-0a603073b473"), 44 },
                    { new Guid("443e69e8-9766-4ee7-8ea5-2ce865e77b7d"), new Guid("4dd36f0e-4565-4a1a-81d3-8076d9f573c6"), 45 },
                    { new Guid("46cb43dc-25a4-453e-a544-8ba66fcf776a"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), 36 },
                    { new Guid("47f157ce-2ccb-4cd7-b309-ff6aeb1c5d06"), new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), 42 },
                    { new Guid("4a5c85b7-4934-4d1f-9fd0-e2908b0624df"), new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f"), 41 },
                    { new Guid("4b1d9855-50f2-4365-bdb0-4d23930a2b01"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), 44 },
                    { new Guid("529f8d05-3e68-4b8a-907a-17af77e3751a"), new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), 44 },
                    { new Guid("53442480-d0ec-42b5-b92b-e1553bd2d9a9"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), 40 },
                    { new Guid("53bae827-edfa-425a-a8dc-036907c8ad23"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 44 },
                    { new Guid("53de5d5f-473a-4835-b13d-743dfc473a31"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), 39 },
                    { new Guid("556d1320-d391-46f1-aba7-42277b0fba87"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), 40 },
                    { new Guid("58208c66-3ebc-4423-9685-bb9c54ad9816"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), 45 },
                    { new Guid("58679a23-c565-4ce5-a714-82673e7a97af"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), 44 },
                    { new Guid("5cf61972-4bde-41ba-8cba-de565bc2611c"), new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274"), 44 },
                    { new Guid("5dd3b9ae-2ac0-47ce-b644-94ae5ec8ed85"), new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), 40 },
                    { new Guid("60fa5313-0f06-4da6-a528-0c7c527cf56e"), new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0"), 40 },
                    { new Guid("62cc8a1d-1dc6-4439-bd0b-87ebdb3f2e4d"), new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274"), 45 },
                    { new Guid("649cf2d8-f98b-412c-bda2-7537f9adef55"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), 41 },
                    { new Guid("6d691713-ca0b-4ec0-a9eb-7c1547bf5b10"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 37 },
                    { new Guid("6e1d7ef3-800e-4ad0-ad6e-7d1aa1eb33bf"), new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), 39 },
                    { new Guid("6e2de29c-4422-48d7-b35c-986c78dc797e"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), 40 },
                    { new Guid("7131325d-afa3-4772-9450-35c3997cbac1"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), 41 },
                    { new Guid("7271219f-a2bb-47e1-8b20-084cde132b27"), new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0"), 38 },
                    { new Guid("73e26ef5-1bd8-47fe-90f4-9f0514787ffa"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), 43 },
                    { new Guid("745961d0-5831-4bcf-8fb8-54f279806877"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), 40 },
                    { new Guid("74b51d94-2584-405c-b81d-5bb56d0dca31"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 41 },
                    { new Guid("77574daf-fbd0-4d9e-afb3-3bade41f78ba"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), 36 },
                    { new Guid("779315f9-962d-4b77-a428-8a000ec39f28"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), 38 },
                    { new Guid("7800702e-5959-44a8-b974-f0070a7aa0d7"), new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), 41 },
                    { new Guid("7a7ba3a4-ca96-41a2-bc67-f287825be116"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 42 },
                    { new Guid("7b4bc232-129e-4a30-b9b6-fb2df3564b32"), new Guid("cfba02b9-695b-4e38-b694-0c4e662b623b"), 45 },
                    { new Guid("7b9432ca-c1c5-49c0-a8a9-4a390da52f99"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), 42 },
                    { new Guid("7f4f88a7-a0a6-4b5f-9586-fa361278f7dc"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 38 },
                    { new Guid("8065f0d8-a6ab-46f8-a057-28bef2872fda"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), 38 },
                    { new Guid("81447182-041d-4948-b3d1-0ed8b2299d52"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), 39 },
                    { new Guid("8457ac7a-cab4-4a60-803e-5bb70ea9dd81"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), 41 },
                    { new Guid("859f5cc6-4af3-47ba-8110-e7b547fa2c3b"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), 45 },
                    { new Guid("867194b5-7974-4eae-b8a8-eece0922bc42"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 39 },
                    { new Guid("870f5ad9-a958-4b42-bb66-113f485bfdcb"), new Guid("65609372-386a-452e-804e-308ebf56d5d5"), 36 },
                    { new Guid("875203ce-6d28-4299-b6d9-3a95d1d42ea5"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), 40 },
                    { new Guid("8d0987f3-25f4-472e-b730-d1a16aa72060"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), 41 },
                    { new Guid("8d67e94f-a21e-426c-ac8a-83a588835014"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), 38 },
                    { new Guid("904dcf12-fd83-4309-ab7f-5820d02ae51a"), new Guid("959d723f-8966-4875-9887-abf1c73a37ce"), 37 },
                    { new Guid("93ab8dd4-3526-4bce-8631-d50ebc9ede99"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), 43 },
                    { new Guid("949e3632-4abc-491f-acb7-9bb464821a9b"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 43 },
                    { new Guid("95fe9a58-e4cc-49fc-b0c8-f309e06d1aac"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), 40 },
                    { new Guid("96672bfe-fee8-486b-9500-663fb54de983"), new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f"), 40 },
                    { new Guid("9a8ec9b2-74ee-4070-bf73-3237393d8517"), new Guid("65609372-386a-452e-804e-308ebf56d5d5"), 44 },
                    { new Guid("9ce072e0-e7e7-4775-ab3d-5e47381ebf41"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), 40 },
                    { new Guid("9cf405f0-685f-41db-8baf-a0d787599dcb"), new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0"), 41 },
                    { new Guid("9d03b713-2a87-4288-8afe-761956db7334"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 40 },
                    { new Guid("9d4f33a4-a5e5-4ca4-a619-47dd0e99d328"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), 37 },
                    { new Guid("9d8259fd-a41c-40aa-bb22-cc47c2d6e21b"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), 41 },
                    { new Guid("a21a93bc-1599-4a5d-b7e6-032acfc3c6d4"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 44 },
                    { new Guid("a2357a8c-de2c-445a-a292-1e46208fbb21"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), 41 },
                    { new Guid("a3439c22-22d9-48e4-9276-ff24d3f7ab6f"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 37 },
                    { new Guid("a3c35f3b-8950-4a28-9c4a-50bdddea1b31"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), 38 },
                    { new Guid("a7cff130-178c-4ab6-a58a-d0cb0930f279"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), 39 },
                    { new Guid("a863dcbf-1c22-4a4d-b3ef-09a98f30b298"), new Guid("65d3b58f-1331-4e7d-ad86-da5d0257d274"), 42 },
                    { new Guid("a869a67f-ec19-45a4-b841-e60eafb85128"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), 44 },
                    { new Guid("a8e4a74d-8d79-4b89-9afa-73b33695eee8"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), 44 },
                    { new Guid("aa0dd756-2890-4900-a36f-e8143f1a9ae8"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 45 },
                    { new Guid("aa81c814-2e27-423f-8bed-bf5a931efcee"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 45 },
                    { new Guid("acc56ca3-3cf1-49e4-8816-4ad25b6699d3"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), 43 },
                    { new Guid("b0cff86e-3060-4fa7-b5f4-6ceb7003e183"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), 45 },
                    { new Guid("b2c57d3a-8c57-4236-bad6-65759a75a45f"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 38 },
                    { new Guid("b31237c8-ebbc-40d5-b250-a94f656d3c6b"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), 41 },
                    { new Guid("b5120b1b-5bda-410d-acba-926f47978502"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), 40 },
                    { new Guid("b797602b-5804-4c6b-8aca-87795662891d"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), 43 },
                    { new Guid("b7b816b9-514d-4ccf-aaa0-58c215fffda8"), new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0"), 36 },
                    { new Guid("bad0bd9d-e2b6-4b1d-b06e-18fc80f5890d"), new Guid("0dc5b682-3cfa-42c6-95ae-d32ee1725a76"), 42 },
                    { new Guid("c30befa1-98eb-4f0a-b4ae-ff041f879cec"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), 39 },
                    { new Guid("c3f7f2c8-b64f-4faf-aafb-9e78f0517fad"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), 40 },
                    { new Guid("cb98f03d-5775-4e1f-8416-78841a30d6bf"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), 41 },
                    { new Guid("cbe4c442-0291-4bff-a979-80f22aa7eb74"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), 36 },
                    { new Guid("cbfdb4e3-23ce-4fc5-bdd4-998c6cc90897"), new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), 44 },
                    { new Guid("cdf9b4da-e02d-4267-b35d-ab7d3de99106"), new Guid("d688e565-ca0e-4bc5-9c09-925951215a42"), 39 },
                    { new Guid("d026256f-9329-4f01-bb55-7aee31a5cf75"), new Guid("65609372-386a-452e-804e-308ebf56d5d5"), 37 },
                    { new Guid("d152edea-a2f4-4986-a491-f84d85c2c5b3"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 44 },
                    { new Guid("d1d102ea-e398-4826-8a7e-ac54dd305882"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), 38 },
                    { new Guid("d61a561d-feb1-4c8a-9b0b-8a4abaa0022b"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 41 },
                    { new Guid("d6c35234-91b7-43ac-8ef5-f2744bb9a340"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), 42 },
                    { new Guid("d8430798-8704-42b4-afc9-de3dd221db22"), new Guid("9b2ffaf1-8e1c-4829-a1c1-405dff0052a1"), 42 },
                    { new Guid("d8451a57-fb5b-4f89-a849-0328a9bb71f3"), new Guid("3cbb64ac-85e4-4c53-8ad8-784b0b90896b"), 43 },
                    { new Guid("d8a7cda1-e5ec-4993-8a44-2023c7fd0cd6"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), 39 },
                    { new Guid("d9439bd2-1287-494d-b20b-1e1e3be4a003"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), 42 },
                    { new Guid("d9dda17e-2730-4541-b3c5-46fc600790bc"), new Guid("501db903-775b-4421-899a-0ba8f8900a60"), 37 },
                    { new Guid("dab22058-0a0f-48b8-a768-2c24765a5a3b"), new Guid("0bec23df-7b41-4b3f-a7d1-9666a799f2a0"), 37 },
                    { new Guid("df1f1cef-a2f7-4e4f-b15e-1348b7197e42"), new Guid("47ba542b-90ee-4d72-b1ed-9bb5ba1da10f"), 42 },
                    { new Guid("e1bf412d-204c-4bb9-bcd0-1811f7840083"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 43 },
                    { new Guid("e1d2a05a-ffa0-493f-a960-b2b22eac45c4"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), 42 },
                    { new Guid("e1dcc7cc-f09c-460e-ad4d-db4147b8ea6e"), new Guid("959d723f-8966-4875-9887-abf1c73a37ce"), 39 },
                    { new Guid("e33cd0e6-007f-45f9-b179-0b84e3d24ced"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 41 },
                    { new Guid("e453ff50-5c45-4906-a092-ed0166295aad"), new Guid("61de6f3f-a596-4456-b9e9-7b8daabcaf9e"), 45 },
                    { new Guid("e4a34e10-5b8d-4d17-aa63-60a6e8ee3037"), new Guid("208e66df-537f-4b10-9e0d-080b87c458f5"), 43 },
                    { new Guid("e7cfd658-bea1-47ee-8e1e-aaf5692f483c"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 39 },
                    { new Guid("e9fc5c80-634a-489a-be4c-9f1cb2d241b0"), new Guid("7879653f-9a6b-47ff-9b17-2ed36e0b24c7"), 41 },
                    { new Guid("eb5c168f-19ec-4ed5-9873-5c9eba9a65a0"), new Guid("c471b711-933c-475f-8e2d-e8c9c877d2b1"), 42 },
                    { new Guid("ebc948f4-74de-4519-b67f-129efe57d2a9"), new Guid("947930d0-dc35-4a70-9fd1-05bd0e182a3b"), 45 },
                    { new Guid("ee0c5958-d5d3-4ad9-bda3-d7813ca36f1b"), new Guid("65609372-386a-452e-804e-308ebf56d5d5"), 41 },
                    { new Guid("ee3de989-e450-4ed4-9132-76f853c28d52"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 43 },
                    { new Guid("ee607025-6f37-4939-9879-2e37d45a35aa"), new Guid("d9da07f7-c0d0-4f57-a795-0200fb20eba0"), 39 },
                    { new Guid("efbf23f3-c372-4f8c-8ca2-a36f029ca8bc"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 42 },
                    { new Guid("f01339a7-204f-425d-9d0f-ab8329bd1aba"), new Guid("5d2376a9-850c-4aa3-9807-73d74f2a7a87"), 37 },
                    { new Guid("f0d2b9ac-5aa6-41ca-b396-2d176d8014cb"), new Guid("7b395e61-6309-4c57-9a92-53affcf0e4cb"), 42 },
                    { new Guid("f104a552-0aaa-4f23-bf55-426a5e0913c3"), new Guid("91187975-a547-4548-9a0d-0a603073b473"), 43 },
                    { new Guid("f211b8ec-2356-4d76-8b9d-32e5e4d47574"), new Guid("ac179883-2899-4c8d-a59a-d050bc5a1272"), 45 },
                    { new Guid("f3c7fd98-2b8a-4541-b016-868bc471c3b3"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), 36 },
                    { new Guid("f8219c63-b980-433f-9197-2998003c165a"), new Guid("9dd67cf4-8287-41ed-900d-5decf0a74a1f"), 38 },
                    { new Guid("fb1debbf-c6f4-4fe8-a047-fcd26eb422d8"), new Guid("bc6287e9-17d8-4f9b-825a-e287aaa58c5e"), 37 },
                    { new Guid("fc3cf64d-d766-4a53-b4c0-08f716973630"), new Guid("61c4346e-d0a4-4d55-8de2-2d0b8bbe9656"), 40 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "CreateDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "IsExternalLogin", "LastModifiedDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileName", "ProviderName", "RoleId", "SecurityStamp", "TotalMoney", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("82c24f02-071e-4407-af06-045f07e9b353"), 0, null, "95d03faf-f4d7-4202-8d9c-26bff9252e78", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, "Jane", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("6ad35d46-5478-44a2-9488-cee17edab89f"), null, 1500m, false, "jane.smith" },
                    { new Guid("917c1f19-aa29-4e0e-a305-4d7fffbd58e3"), 0, null, "389c171e-a129-4729-a9d2-c80d04ac6738", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2204, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "machgiahuy@gmail.com", false, "Mach", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gia Huy", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("b926c80b-af39-4157-9748-2ccdc040add1"), null, 1000m, false, "Mach Gia Huy" }
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
                name: "IX_ShoeColors_ShoeId",
                table: "ShoeColors",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeImages_ShoeId",
                table: "ShoeImages",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSeasons_ShoeId",
                table: "ShoeSeasons",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSizes_ShoeId",
                table: "ShoeSizes",
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
                name: "ShoeColors");

            migrationBuilder.DropTable(
                name: "ShoeImages");

            migrationBuilder.DropTable(
                name: "ShoeSeasons");

            migrationBuilder.DropTable(
                name: "ShoeSizes");

            migrationBuilder.DropTable(
                name: "WishlistItems");

            migrationBuilder.DropTable(
                name: "Orders");

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
