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
                    { new Guid("4d24feec-3be9-4d79-abed-1185a6d871d3"), "Role Admin với đầy đủ các quyền hạn", "Admin" },
                    { new Guid("62ce5c4c-023e-459f-9b6a-488f3438520e"), "Role User với các quyền hạn có giới hạn và mua hàng", "User" }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "AverageRating", "Brand", "Category", "CreateDate", "Description", "Discount", "Gender", "ImageUrl", "IsSale", "LastModifiedDate", "Material", "Name", "Price", "Sold", "TotalRatings" },
                values: new object[,]
                {
                    { new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7261), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/[IDGiay_6]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7261), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381 },
                    { new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), 4.4m, "Converse", "Basketball", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7448), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/[IDGiay_23]_AnhChinh.png", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7448), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34 },
                    { new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7356), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/[IDGiay_18]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7356), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12 },
                    { new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), 4.8m, "Nike", "Football", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7248), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/[IDGiay_3]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7249), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10 },
                    { new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), 4.7m, "Converse", "Yoga", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7458), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/[IDGiay_25]_AnhChinh.png", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7459), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30 },
                    { new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), 4.1m, "Puma", "Yoga", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7339), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/[IDGiay_14]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7340), "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22 },
                    { new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), 4.0m, "Puma", "Basketball", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7325), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/[IDGiay_11]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7325), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21 },
                    { new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7321), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/[IDGiay_10]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7321), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3 },
                    { new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54"), 4.2m, "Nike", "Tennis", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7253), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/[IDGiay_4]_AnhChinh.png", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7253), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5 },
                    { new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7454), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/[IDGiay_24]_AnhChinh.png", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7455), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100 },
                    { new Guid("60bfd401-8a9a-4e15-b9ae-433957796604"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7317), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/[IDGiay_9]_AnhChinh.png", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7317), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268 },
                    { new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7335), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/[IDGiay_13]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7336), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23 },
                    { new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7343), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/[IDGiay_15]_AnhChinh.png", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7344), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87 },
                    { new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a"), 4.4m, "Adidas", "Football", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7267), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/[IDGiay_7]_AnhChinh.png", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7267), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37 },
                    { new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7371), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/[IDGiay_21]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7371), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10 },
                    { new Guid("88c30b01-f5d5-4768-ab70-e93e98ca76a1"), 4.2m, "Adidas", "Basketball", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7470), "One of the best shoes for basketball and the symbol of Adidas's World. You won't be able to take your eyes off of this brand new SuperStan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7471), "Leather, fabric, foam, and rubber.", "Adidas Original StanSmith", 1713000m, 65, 33 },
                    { new Guid("97dd7463-fc71-4ff1-ab05-287500e93071"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7362), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/[IDGiay_19]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7363), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111 },
                    { new Guid("9912b869-09a3-4f90-928d-de9e98b4b06f"), 4.7m, "Puma", "Football", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7474), "One of the best shoes for football and the symbol of Puma's World. You won't be able to take your eyes off of this brand new FUTURE, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7475), "Leather, fabric, foam, and rubber.", "Puma FUTURE 7 Ultimate FG/AG The Forever Faster", 2713000m, 78, 55 },
                    { new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3"), 7m, "Nike", "Basketball", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7462), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/[IDGiay_26]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7463), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5 },
                    { new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7347), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/[IDGiay_16]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7348), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25 },
                    { new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7312), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/[IDGiay_8]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7313), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84 },
                    { new Guid("cfcc76e1-b3d6-469a-898a-fd33e959b13b"), 4.6m, "Nike", "Basketball", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7466), "One of the best shoes for basketball and the symbol of Nike's World. You won't be able to take your eyes off of this brand new Jordan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7467), "Leather, fabric, foam, and rubber.", "Jordan 1 Low Bred Toe 2.0", 1813000m, 45, 23 },
                    { new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7219), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/[IDGiay_1]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7236), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20 },
                    { new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7366), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/[IDGiay_20]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7367), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10 },
                    { new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902"), 4.9m, "Nike", "Yoga", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7257), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/[IDGiay_5]_AnhChinh.png", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7257), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66 },
                    { new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7351), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/[IDGiay_17]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7352), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20 },
                    { new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7375), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/[IDGiay_22]_AnhChinh.png", false, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7375), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45 },
                    { new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), 4.7m, "Nike", "Basketball", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7244), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/[IDGiay_2]_AnhChinh.png", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7245), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45 },
                    { new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), 4.2m, "Puma", "Football", new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7329), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/[IDGiay_12]_AnhChinh.png", true, new DateTime(2024, 10, 22, 22, 11, 21, 702, DateTimeKind.Local).AddTicks(7329), "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("01e0075c-b56c-412a-93e8-9e19d1ff68c6"), new Guid("9912b869-09a3-4f90-928d-de9e98b4b06f"), "https://thumblr.uniid.it/product/336262/a92a6cadc8a6.jpg?width=3840&format=webp&q=75" },
                    { new Guid("01e17856-2d50-4b80-8d82-d849e64d4cf5"), new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("02cba9c3-ef97-4c10-948a-f4a5a741fc48"), new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), "images/shoes/[IDGiay_10]_AnhChinh.jpg" },
                    { new Guid("03dfd889-6aec-4c4c-aab0-a371e0121f40"), new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("07e00c68-e911-4e8e-b1d0-9161cf124779"), new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("07e46e4f-9e50-4ed4-9991-3c3104b05d77"), new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("09c6834d-6873-493b-8a32-59b08fe966ec"), new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), "images/shoes/[IDGiay_3]_AnhChinh.jpeg" },
                    { new Guid("09c8092a-5a63-4145-8928-c859fe6dd8ce"), new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("09dfc443-5ce9-4210-983d-b93f7f42c5a5"), new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("0b510528-3a1f-47f4-b906-af4509c6752d"), new Guid("60bfd401-8a9a-4e15-b9ae-433957796604"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("0e9b9748-106c-45de-ab3e-b3695a2d73bb"), new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac"), "images/shoes/[IDGiay_13]_AnhChinh.jpeg" },
                    { new Guid("1015c489-dabf-495e-a028-d59ea0948bbb"), new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("107afbd1-50fa-4c49-8ef9-4d125c030a12"), new Guid("cfcc76e1-b3d6-469a-898a-fd33e959b13b"), "https://dmpkickz.com/cdn/shop/files/6_78fd24e0-cd30-400a-8fa1-e5e6cd3c5b0b.png?v=1696679846&width=480" },
                    { new Guid("115cade5-6926-4812-9349-009226a14e13"), new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("181b29b9-ac13-42d5-b380-36a539e88332"), new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("1d5ceada-e0db-408b-857d-98689a7349f0"), new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("1edfd40b-bede-4459-82f4-f25c4fad788a"), new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6"), "images/shoes/[IDGiay_20]_AnhChinh.png" },
                    { new Guid("1fd5b751-4e07-4318-b5e7-45d658a95af0"), new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3"), "https://gossipdergi.com/wp-content/uploads/2021/04/nikeayakkabi.gif" },
                    { new Guid("20af763b-0d73-4c75-9301-f81cadb38058"), new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("20bc144e-9ecd-4fc7-b974-a42549c975dc"), new Guid("97dd7463-fc71-4ff1-ab05-287500e93071"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("21e85d83-a1ed-43f8-9f31-ca4ba07fc12c"), new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("22d2d436-0464-477f-af64-a9f48f8d1ade"), new Guid("88c30b01-f5d5-4768-ab70-e93e98ca76a1"), "https://assets.adidas.com/images/w_1880,f_auto,q_auto/e53b9a57b0a745be924bac1e00f54427_9366/FX5502_42_detail.jpg" },
                    { new Guid("2366dc11-d72c-472d-946a-b29afbbcaba4"), new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3"), "https://photo.znews.vn/w660/Uploaded/rohunwa/2021_03_26/SHOES3.jpeg" },
                    { new Guid("239b3f30-723c-4743-9413-92cb17e93883"), new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("23b22e53-478c-4147-bd15-390cbf429e24"), new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("254f9e24-a198-4fc9-8bbb-36c2ec62397e"), new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("267f63d5-b372-41f5-8aca-098f73ee443f"), new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("26ef50b0-30cc-4b20-ad25-d2bb0ffb94ff"), new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("26f5d864-40c8-48c9-a1e9-8d6185cffb71"), new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), "images/shoes/[IDGiay_1]_AnhChinh.png" },
                    { new Guid("2724a0db-9542-4df9-b512-f4d1d59d2926"), new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("29a2b7b7-82ce-4c5a-910a-c2cd4ca7491c"), new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("2c084959-8a04-41c0-8de3-4fbc5e945702"), new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("2cdad41e-b2db-4fa6-926e-707b87051bc6"), new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("2efa33a0-3555-4da2-9dac-12bb94e2376b"), new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("30b8daf7-1fd6-4431-aa4d-85f4e4923b5f"), new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), "images/shoes/[IDGiay_21]_AnhChinh.jpg" },
                    { new Guid("3117c1d4-2edd-4290-915d-56471de077af"), new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("3558e4fe-4cf5-467f-94c1-2b62fd36e80f"), new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59"), "images/shoes/[IDGiay_17]_AnhChinh.png" },
                    { new Guid("360bf671-be1b-4395-88ee-8254831a7c85"), new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54"), "images/shoes/[IDGiay_4]_AnhChinh.jpeg" },
                    { new Guid("379cdff1-29a5-4c03-883c-549f25f20eb6"), new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3"), "https://c.files.bbci.co.uk/1081F/production/_117751676_satan-shoes2.jpg" },
                    { new Guid("39e642b0-bed5-4e43-8eeb-e12131ac5a59"), new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("3ce0f4f5-592d-43ed-a903-b481da1547fb"), new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("3dd2078d-691e-43b2-9174-986fb1862312"), new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("3f9d7c61-9406-432c-9226-08dca36481d5"), new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("49a23865-9863-46ce-9ca2-bffe7296ac59"), new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("4af98b3c-97df-42db-b625-f9d80b7e1bef"), new Guid("cfcc76e1-b3d6-469a-898a-fd33e959b13b"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3rZPCUSKRHdQA5_g3YBJRdcmIf_6PpZcNZg&s" },
                    { new Guid("4bf4933b-c5d5-4cc7-a181-b1af1ebe47ff"), new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("4eda5036-7f1f-49b9-af5b-7179e340e73a"), new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54"), "images/shoes/[IDGiay_24]_AnhChinh.jpg" },
                    { new Guid("52a80439-653b-4632-b32e-0a6dc5c728a6"), new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("55bf9ef7-5608-4349-9888-a82bb7b8aafd"), new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("57d8714e-3ab6-434b-b907-8cfd63d28c07"), new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902"), "images/shoes/[IDGiay_5]_AnhChinh.jpeg" },
                    { new Guid("58abec71-7aa7-4242-bd86-6e40e50736bf"), new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("5d672040-50a7-4092-b600-85634cfdc95d"), new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), "images/shoes/[IDGiay_2]_AnhChinh.png" },
                    { new Guid("5f0d4b42-07f3-40c1-8349-95e0ef40b13a"), new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("5fd4ad4a-1447-4edf-a493-18102a0fa44d"), new Guid("60bfd401-8a9a-4e15-b9ae-433957796604"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("5fe41611-2143-468a-8ee8-7eee022cde0c"), new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d"), "images/shoes/[IDGiay_18]_AnhChinh.png" },
                    { new Guid("63178d25-1f48-4552-9cf4-7a6016eecf12"), new Guid("60bfd401-8a9a-4e15-b9ae-433957796604"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("692e6991-c7f3-45d9-b946-4b004c29dff5"), new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), "images/shoes/[IDGiay_11]_AnhChinh.png" },
                    { new Guid("69943b09-882a-43bf-995c-39e35e703f89"), new Guid("cfcc76e1-b3d6-469a-898a-fd33e959b13b"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNBQXFHswxHuyjT_e8rb5XOaWUzEe3pphPPw&s" },
                    { new Guid("6a0e909a-471d-4a70-9060-74ac4e1a2388"), new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("6b0ddc62-b167-4eba-906c-415956bfd383"), new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("6bfa7cfc-8e65-4ad1-a4f4-6f7ba2c4ddff"), new Guid("60bfd401-8a9a-4e15-b9ae-433957796604"), "images/shoes/[IDGiay_9]_AnhChinh.jpg" },
                    { new Guid("70550173-2fc6-46da-b009-ca36cdd832da"), new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("723afd64-9139-490f-8648-c4cd4cfba9fd"), new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("73109acd-ad6e-46c0-aa69-bf53d179c44f"), new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("731ee352-5609-481f-9ec2-cb385c8d56c2"), new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("7503e1f7-5543-4396-b060-555b8c05a93c"), new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178"), "images/shoes/[IDGiay_15]_AnhChinh.jpeg" },
                    { new Guid("7511acaa-093c-4259-9fb6-7016f1e15841"), new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("791a7ac2-a48b-4609-ad0c-910b2feb948d"), new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("7b924fa5-bea2-4fd6-b493-db6313267200"), new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("7c078d80-397f-439f-974c-0be16d17ecce"), new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("7c1f6082-9926-43e4-b5bd-26a5ff95d540"), new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("7d8d1692-4ff6-4884-aada-668679728ec2"), new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca"), "images/shoes/[IDGiay_16]_AnhChinh.png" },
                    { new Guid("7dbf3ba5-f2b9-48e7-8276-b5e9e123cdc3"), new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("7ef39f30-78c5-4cc2-ac94-13e44de8f9dd"), new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("83b8dddd-0533-4b21-849a-f986a884b794"), new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), "images/shoes/[IDGiay_25]_AnhChinh.jpg" },
                    { new Guid("8427ee3e-d904-43c7-bbf0-1324f8ab14b5"), new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("85518f68-8732-4a29-b447-7e0116b95f09"), new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("88fb5b34-afbb-4e6e-aa7f-508a992830f9"), new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("8ccccb48-c5f9-4ee3-bb48-60971f7870f8"), new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("9086bb3f-2a58-41d1-ba64-f03a7082dabe"), new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), "images/shoes/[IDGiay_23]_AnhChinh.jpg" },
                    { new Guid("909d3d87-c9b6-4e33-91f7-20d4e14d97c6"), new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("936f9f37-0f93-4fbf-9bff-34650a11e968"), new Guid("60bfd401-8a9a-4e15-b9ae-433957796604"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("95134c67-ab99-414c-8919-71f0f494bacb"), new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("966cab1e-427b-453e-9054-76e40b702696"), new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("96de68a4-e23a-41bd-9af8-0dca0a1093e1"), new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("9c5c598f-cd0e-436b-86b8-b78cfba24b10"), new Guid("88c30b01-f5d5-4768-ab70-e93e98ca76a1"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-3.jpg" },
                    { new Guid("9d28160b-c58d-42f6-9b27-f4bbf431af8f"), new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("9d4649f1-b507-4561-9d58-1faed21b4aae"), new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("9d9d4c5f-9769-422d-b2ce-c826c02aac8e"), new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("a0a197d5-a409-418f-a837-dfd707c25c04"), new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("a298e05d-8a41-4523-ae00-a6a0253c7125"), new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("a3342d88-202f-428c-a05e-c13264662681"), new Guid("97dd7463-fc71-4ff1-ab05-287500e93071"), "images/shoes/[IDGiay_19]_AnhChinh.png" },
                    { new Guid("a56bd935-6c14-4647-ba4b-f83ffb75f1b1"), new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3"), "https://media.cnn.com/api/v1/images/stellar/prod/210328223753-03-lil-nas-x-satan-shoes.jpg?q=w_3000,h_3000,x_0,y_0,c_fill" },
                    { new Guid("a6a54957-2077-4610-9ce6-737df62e1a5d"), new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("a6e87ba9-e150-4b62-b99b-ad412976a2fa"), new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("a81b7c31-c330-4b09-9578-65fe012cd858"), new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), "images/shoes/[IDGiay_8]_AnhChinh.jpg" },
                    { new Guid("a91b65c7-43b6-409b-aea3-c9670ba59bc0"), new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("ada9a98a-f93d-4cc8-83e0-edd38123702b"), new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("b0f10fdb-7948-4986-a4ed-ee7bc3da5bf0"), new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("b1539a46-dbef-4271-acb6-ba9d86d2f7e4"), new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("b2354b01-18ed-43e2-8359-49aed45e9d1c"), new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("b47416f3-3ac0-4071-bed2-4e8c25cae2c7"), new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), "images/shoes/[IDGiay_6]_AnhChinh.jpg" },
                    { new Guid("b6b78169-74f3-4e87-98f6-0cb486cb759d"), new Guid("88c30b01-f5d5-4768-ab70-e93e98ca76a1"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-1.jpg" },
                    { new Guid("b8893957-11e5-47a5-a34e-bc4c2a6e9d79"), new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("b8bf1bdc-7d88-4a81-9d92-cfc85716265f"), new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("bd8b5910-36fc-4c17-abd8-0acddf2c8d21"), new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("bdb8c5f8-0297-46d5-b440-6b0e9ec5653b"), new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("bdfa64f0-1ffb-4f42-80c7-95044347907e"), new Guid("9912b869-09a3-4f90-928d-de9e98b4b06f"), "https://thumblr.uniid.it/product/336262/8307c19dcf3d.jpg?width=3840&format=webp&q=75" },
                    { new Guid("bea2aacf-6ef9-469a-8954-2ba6ba12c946"), new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("bf3729d8-943a-4b54-94b0-4cdf15e09a38"), new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("c45a0e65-4723-4590-9560-04c76d61f44b"), new Guid("9912b869-09a3-4f90-928d-de9e98b4b06f"), "https://thumblr.uniid.it/product/336262/57daee260d2a.jpg?width=3840&format=webp&q=75" },
                    { new Guid("c58cbd8c-6404-4231-9a3b-b443f006b436"), new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("c62a1fa0-00c9-4121-a460-eb295db6d3a8"), new Guid("cfcc76e1-b3d6-469a-898a-fd33e959b13b"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQPenW_eiwOe1RkKeaF_kg5TraxKiem6NJ_Q&s" },
                    { new Guid("c868b7d8-f6e0-4497-a2af-26322a4a990e"), new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17"), "images/shoes/[IDGiay_22]_AnhChinh.jpg" },
                    { new Guid("ca8fd30d-b30e-4714-9f7b-0b5184624cf8"), new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("cac6629a-cb6d-4af9-9ee0-2595696e2e05"), new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("cee63632-d675-4a46-a86f-4b33fe237cd5"), new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("d02e8e56-3a72-485b-9bb8-3881f900a268"), new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("d0b643a6-b960-4f3f-987e-fef46f4c41f4"), new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("d453ca09-27ea-43c9-b030-90433467eeb7"), new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), "images/shoes/[IDGiay_12]_AnhChinh.jpeg" },
                    { new Guid("d9ffd742-f9f9-4d03-9f8f-2cb66e6a07d6"), new Guid("88c30b01-f5d5-4768-ab70-e93e98ca76a1"), "https://likelihood.us/cdn/shop/files/stansmith_angle_1200x.png?v=1691430477" },
                    { new Guid("de5d8c17-4597-43fa-9760-d3f2f091777b"), new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("e1655db2-8bbb-4a86-9bec-7dfd18aaf2de"), new Guid("97dd7463-fc71-4ff1-ab05-287500e93071"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("e3360efe-bc64-4d54-98c8-ef624dfc896f"), new Guid("97dd7463-fc71-4ff1-ab05-287500e93071"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("e4258dd0-9b79-4677-aa9b-31fa1d05babc"), new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("e5a2c130-327d-4a26-87fe-d5b77055e902"), new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("e638eaab-f534-4993-91df-ef5634880f71"), new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("e7a5e7be-8c52-4329-bdfa-5baf44d18970"), new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("eb7c2dab-8f1a-4689-a9df-2045d9e494f7"), new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("ec7641c6-153e-4376-a605-0fff741aca31"), new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("f314d3ab-4e8c-4c4f-8b4a-a3889279f1cc"), new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("f4456ee2-a0af-4727-b99d-3c7f437d6779"), new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a"), "images/shoes/[IDGiay_7]_AnhChinh.jpg" },
                    { new Guid("f69c296b-e820-41f3-b796-c88635f994a0"), new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("f6d03b8a-2003-4d27-be31-930c91de67d0"), new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3"), "https://i.pinimg.com/originals/c0/cf/d1/c0cfd1545f10c56793e888e991b60487.png" },
                    { new Guid("f6f95d9e-1e30-4516-bbc6-22ab7dd45710"), new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("f797dff6-1062-4acf-994e-ee8049b0cf4a"), new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("f8b2e72d-7e50-4e0b-9454-2eb79bac7ae0"), new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("f9422ef3-6abc-48bd-b948-f0ccf6e7b093"), new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), "images/shoes/[IDGiay_14]_AnhChinh.jpeg" },
                    { new Guid("f9959b0d-0366-4507-8c1b-4efcb95a19a5"), new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("fbb4f48d-84db-4745-9996-2604a76f17f6"), new Guid("97dd7463-fc71-4ff1-ab05-287500e93071"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("fcc746a9-1563-4b36-ad51-36675475485f"), new Guid("9912b869-09a3-4f90-928d-de9e98b4b06f"), "https://www.prosoccer.com/cdn/shop/files/PumaFuture7UltimateFGAG-ForeverFasterPack_SP24_Model1_1500x.png?v=1713488175" },
                    { new Guid("fd17870a-5230-49c0-99e7-e4423b580c1b"), new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("00031b50-006e-4d89-bc19-fc77fdca63e0"), "Winter", new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca") },
                    { new Guid("0943015b-bff0-4b9b-8b85-da3088489259"), "Winter", new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59") },
                    { new Guid("22755801-cd17-4a8c-80ef-ac0b1bca8ab0"), "Summer", new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac") },
                    { new Guid("26057df8-b7c3-45cc-8881-0eef1da0e39f"), "Spring", new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8") },
                    { new Guid("2a68b957-e262-40bb-afe3-cf1c4f698da0"), "Fall", new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54") },
                    { new Guid("31addfaf-51e1-41bf-b90c-e7ca5379b295"), "Spring", new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e") },
                    { new Guid("3c7259c9-3d40-4756-9f84-689fbecc460b"), "Spring", new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6") },
                    { new Guid("3f55c0f1-7411-43e1-8a2c-3a6d8fe9634e"), "Spring", new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3") },
                    { new Guid("4139c124-7794-44e7-8d5a-2c2bda73e097"), "Summer", new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348") },
                    { new Guid("43c0bfd0-22bf-49b9-a084-4ba899144687"), "Spring", new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d") },
                    { new Guid("4564a0d3-175e-484c-8988-fbaace5a7827"), "Summer", new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6") },
                    { new Guid("4eddba1d-1e7d-42a1-811d-c5f8e7d8fd0e"), "Fall", new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a") },
                    { new Guid("4f5e84ed-f322-43c2-ad91-9b20778ccdb7"), "Spring", new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348") },
                    { new Guid("5112a4ea-40b2-4845-952e-b5930ebe20f1"), "Summer", new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be") },
                    { new Guid("56b8856a-daae-4b9e-9b7f-7d982d663254"), "Spring", new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178") },
                    { new Guid("623c87c1-9758-47dc-af60-df8eef787a8c"), "Fall", new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54") },
                    { new Guid("70d5713a-9323-4fad-a942-efd87e6c8f9d"), "Fall", new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e") },
                    { new Guid("72cdf924-8158-4f20-bf80-c9517a1f0b9f"), "Summer", new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d") },
                    { new Guid("736624c5-dafa-407a-bea3-360cc43d3d04"), "Spring", new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54") },
                    { new Guid("755325fb-2ae0-4c58-99f4-1127d46c0961"), "Summer", new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54") },
                    { new Guid("7b27e57f-c785-4e3e-be7b-c1db331f874b"), "Winter", new Guid("97dd7463-fc71-4ff1-ab05-287500e93071") },
                    { new Guid("7b74a944-da23-412e-9ed6-b4866755d6ca"), "Winter", new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348") },
                    { new Guid("7f2cc6c8-f8d6-40ac-a0a8-671529e6d2fd"), "Spring", new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57") },
                    { new Guid("80d6b9a8-c85d-4252-a27d-d5c42e309be0"), "Winter", new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e") },
                    { new Guid("8dc7ddf9-4f2e-45c2-ace0-88cd0cc8abf6"), "Spring", new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6") },
                    { new Guid("93661db0-e7ce-4e95-883d-fc88eed0eb7d"), "Summer", new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6") },
                    { new Guid("947ace1b-4cc7-4f0c-9828-6851fa277f54"), "Summer", new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca") },
                    { new Guid("96db0f23-4e34-44a6-b278-a9469e742471"), "Winter", new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a") },
                    { new Guid("9c806259-d9c8-480d-870a-5300937b2c95"), "Winter", new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6") },
                    { new Guid("9d97ba16-a013-40e8-8218-fb5492327603"), "Summer", new Guid("60bfd401-8a9a-4e15-b9ae-433957796604") },
                    { new Guid("a40a06a8-ab61-4678-80eb-9bbfd535d7fa"), "Fall", new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902") },
                    { new Guid("ac529cc0-da2b-4264-944c-1f0f55ad7d80"), "Spring", new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99") },
                    { new Guid("ae545ee2-5356-4df9-841d-d1116dee6510"), "Winter", new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3") },
                    { new Guid("b1ffcdb2-7a15-4ada-b6d9-2b9e8615daea"), "Summer", new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17") },
                    { new Guid("b449295b-63c4-47b1-bbc5-8b9b084344bb"), "Fall", new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca") },
                    { new Guid("b94c16c9-1074-4bf3-b34a-e71932a20c11"), "Spring", new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a") },
                    { new Guid("ba3336e3-758b-4cd5-8355-d64278ef7de7"), "Spring", new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54") },
                    { new Guid("be093873-8765-455d-aa6d-edb0340c51b5"), "Summer", new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a") },
                    { new Guid("c5aaa192-a5be-4da7-9374-c7a4b0d0e36b"), "Winter", new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54") },
                    { new Guid("c832ce10-6942-458c-a958-335f50c29401"), "Fall", new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348") },
                    { new Guid("d15a11eb-f335-4b4b-a407-c1a5f05202e2"), "Spring", new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca") },
                    { new Guid("d3150d94-76e5-419e-beab-64cfd5e8b5cf"), "Summer", new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6") },
                    { new Guid("d581a9c5-adf6-4116-bd59-e4216a72cae6"), "Spring", new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f") },
                    { new Guid("df2135c9-a682-4648-b7b2-0bb6cb766ece"), "Winter", new Guid("60bfd401-8a9a-4e15-b9ae-433957796604") },
                    { new Guid("e267c22f-722a-417e-bf95-508718ecce90"), "Spring", new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6") },
                    { new Guid("e490ea91-5b84-4ffd-9d6f-4d8f7dd48457"), "Summer", new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8") },
                    { new Guid("e4b91b05-0804-44ee-bda0-03935445788c"), "Winter", new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a") },
                    { new Guid("e9fe55c0-628c-4853-aa53-16dd04f73f56"), "Fall", new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8") },
                    { new Guid("eaf4752b-3636-408c-8708-87a09a306ae3"), "Summer", new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8") },
                    { new Guid("f16de1ea-7225-4812-9cb2-509f040f90f7"), "Fall", new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4") },
                    { new Guid("f2524699-ddf8-4501-bb12-1df0aceb2570"), "Winter", new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902") },
                    { new Guid("f43c8f20-79f8-451f-a6d1-2bd672e13048"), "Winter", new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8") },
                    { new Guid("f7e8c4ef-ce2b-4472-840b-f947387fceeb"), "Winter", new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17") },
                    { new Guid("fc67dfd4-1fd8-4947-a4e6-0bba52aa33c2"), "Fall", new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("0451afad-79bd-4df3-902c-9b7c925afe98"), "Pink", new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f") },
                    { new Guid("07c792f9-d6f2-491c-9289-c079d5795705"), "Blue", new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e") },
                    { new Guid("0b028369-286f-4dbc-be27-51f198e3156b"), "Purple", new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6") },
                    { new Guid("118b3316-c603-448c-8aa2-ae244d423aaa"), "Orange", new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902") },
                    { new Guid("12616c84-7c1a-4e50-bc1e-06734bf5d2ef"), "Black", new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99") },
                    { new Guid("20864f72-e879-428c-9148-e1dfafb1ad2f"), "Purple", new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6") },
                    { new Guid("27f382d4-a39f-4ebe-a536-036ce0722d25"), "Yellow", new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f") },
                    { new Guid("283a4890-24ae-4525-987d-65f9b4ff790c"), "Black", new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac") },
                    { new Guid("2b079c26-886e-4588-ad00-75d32d02eb8f"), "Pink", new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6") },
                    { new Guid("2eb0ace1-7a41-4280-827d-c5cfbcb9255e"), "White", new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be") },
                    { new Guid("345bf129-4ff5-4395-823a-8f1fd9458572"), "White", new Guid("97dd7463-fc71-4ff1-ab05-287500e93071") },
                    { new Guid("34ca7e6e-f735-4221-b49a-82bfb170ea29"), "White", new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178") },
                    { new Guid("35cff786-a09d-42ce-b55e-7427ebdc0adf"), "Blue", new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99") },
                    { new Guid("38ca2903-af94-4935-a56a-77104e36fdd6"), "Blue", new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d") },
                    { new Guid("38e6510a-0611-4a3a-ae25-c9690aec888c"), "Green", new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57") },
                    { new Guid("3fc1d16f-ab8d-4a36-ad30-60565ec0ea2c"), "Pink", new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99") },
                    { new Guid("3fe96e2f-f06b-4416-b1cc-4bb52772fbed"), "Blue", new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca") },
                    { new Guid("460424af-3a6c-4734-ba6b-5d6a542c3b83"), "Brown", new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57") },
                    { new Guid("51498b7e-3deb-4628-b6c5-3391dee2647a"), "Black", new Guid("60bfd401-8a9a-4e15-b9ae-433957796604") },
                    { new Guid("5b4eb00e-40bf-4aa8-95e0-c928d2798653"), "Grey", new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca") },
                    { new Guid("5b8dcc13-a1b6-48d6-b4bc-184db6b02b22"), "Pink", new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59") },
                    { new Guid("5be787bd-5727-481e-82bd-3f1af9ff6317"), "Red", new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a") },
                    { new Guid("5cbf179c-02c0-4335-9e04-468f1439476c"), "Black", new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f") },
                    { new Guid("5fd08ab1-4647-4e87-9aed-7ddba934a078"), "White", new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8") },
                    { new Guid("6393d92e-9168-4d8a-a5e6-46ccbc263d39"), "Orange", new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be") },
                    { new Guid("6ad62db1-60c6-42e8-93d5-17d6d4bf5fa9"), "Orange", new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4") },
                    { new Guid("6c5a726a-b206-411f-8c4f-5aafb72cb550"), "Black", new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178") },
                    { new Guid("70256f20-b418-4d90-a55f-0b57117f114c"), "Blue", new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be") },
                    { new Guid("7cee257f-5935-453b-b549-38169fc443ce"), "White", new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca") },
                    { new Guid("7d6a7906-70e7-448a-bb50-ec2506bd6e4f"), "Black", new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3") },
                    { new Guid("7e492622-c369-41d0-80b1-d5a993d74eac"), "Red", new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be") },
                    { new Guid("7e64835a-58f8-40b8-8b76-340538581af7"), "Black", new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902") },
                    { new Guid("7ed710c3-94ee-4fec-b30f-80d5bf1a67eb"), "White", new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54") },
                    { new Guid("7fb5c33a-ea1e-4756-9086-db6bf8843eec"), "Green", new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be") },
                    { new Guid("8623408a-d296-4224-ad04-60545c6f3803"), "Blue", new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8") },
                    { new Guid("8d3c702c-b73d-4678-a7a0-06e4cbec6165"), "Brown", new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54") },
                    { new Guid("8dc6dd75-e0be-43c1-b818-b2c32b5ceddd"), "Blue", new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59") },
                    { new Guid("8fc2dc40-7fe1-4459-bd6c-7bc7c6d97202"), "Red", new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99") },
                    { new Guid("9121f6c1-3200-4a96-9141-15f6241da090"), "Blue", new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a") },
                    { new Guid("921bce11-1ddd-499d-86b4-c74ea24d090a"), "Green", new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e") },
                    { new Guid("9300e731-d715-4832-8907-31c6674f0446"), "Black", new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e") },
                    { new Guid("97a9c33c-dc0c-4999-bec3-f11ecd9694a2"), "White", new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902") },
                    { new Guid("9bf34dbd-7f0d-4001-be69-2f1afd5e8ea5"), "White", new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f") },
                    { new Guid("9f3add44-2ff2-479b-8bd1-cc34958e6513"), "White", new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6") },
                    { new Guid("9f50627a-51de-4a9e-b589-2a29ea3a18d5"), "White", new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6") },
                    { new Guid("b62d1358-607e-45d1-b33f-e20525427a90"), "Red", new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3") },
                    { new Guid("b968641b-e832-48cf-8b41-a707713ab44f"), "White", new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54") },
                    { new Guid("bcb6e705-4ba4-4e60-89c3-316dcded7f62"), "Black", new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6") },
                    { new Guid("bcc28814-f657-437e-8cd7-7d286d8f677b"), "Pink", new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8") },
                    { new Guid("c5af8639-f81a-446b-ae48-57364b52a98c"), "Black", new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17") },
                    { new Guid("cd735268-717e-4f6a-8d4f-10f6923b5520"), "Brown", new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54") },
                    { new Guid("ce62e16a-5b15-40c6-b701-abc4733ec5a5"), "Black", new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca") },
                    { new Guid("d0132d42-6bc3-473d-8aa6-0cb0a635baca"), "Orange", new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac") },
                    { new Guid("d80ea884-5d43-452a-9a0d-f0f4902b7a40"), "Red", new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8") },
                    { new Guid("da9bf82a-1850-4feb-b1ea-9657ae02d3fa"), "Purple", new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4") },
                    { new Guid("dabb3422-81cb-4bbe-8e02-24511a5d6613"), "Black", new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be") },
                    { new Guid("ed9e2226-5496-4891-9772-788e000831c3"), "White", new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99") },
                    { new Guid("f40281c0-a50b-4544-abe1-7d7aa27d5f93"), "Black", new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6") },
                    { new Guid("f416e5cc-b4f6-4a82-800c-727d815666a9"), "Black", new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54") },
                    { new Guid("f9797547-a858-4e48-9885-fc4f153499c0"), "Blue", new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f") },
                    { new Guid("f97ff523-91f3-4c8a-ae23-5731453742be"), "Black", new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8") },
                    { new Guid("f9b8da32-94a9-4151-a361-b74746dcde5d"), "Black", new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348") },
                    { new Guid("fb5f2657-d2bb-4490-8b63-d5612dbb28df"), "Yellow", new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a") },
                    { new Guid("fbf84185-5e60-4b4c-94d5-ef6e0f9bbd0a"), "Blue", new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6") },
                    { new Guid("fe956256-872a-4031-b667-776be6977a39"), "Blue", new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("025576a1-d99b-434b-b9ce-ae772f125cc9"), 51, new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3"), 38 },
                    { new Guid("044b3731-9a5f-4d62-bd6a-f25a3c75d80b"), 14, new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59"), 41 },
                    { new Guid("06314aaa-54cb-405d-81d9-690465f8e2a4"), 37, new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), 40 },
                    { new Guid("06f9a75d-5cb0-4433-8f7f-d6d61ccfab06"), 34, new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54"), 39 },
                    { new Guid("0a6deee6-dd95-414a-924f-c9a69ef66e92"), 51, new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), 41 },
                    { new Guid("0f35b728-a090-4402-97e9-ef193a4becef"), 16, new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54"), 38 },
                    { new Guid("11b1ece7-9de7-48c4-aeb6-05f30f9d4f1f"), 23, new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59"), 40 },
                    { new Guid("12257d69-93b5-4c0b-8d77-c5bc892cc81d"), 41, new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), 40 },
                    { new Guid("128f902c-03ff-4f66-8008-53704dd6beec"), 20, new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), 41 },
                    { new Guid("167dcd6c-8c07-461b-84e6-cece18fc5c27"), 9, new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3"), 37 },
                    { new Guid("173a8d5d-2b0a-4ab1-a7a8-87a949ada8bd"), 13, new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), 46 },
                    { new Guid("1967bceb-a67c-440f-925a-2f7c20ceb2a3"), 40, new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), 40 },
                    { new Guid("1a3680f2-42bd-431f-886f-4c6c11a6f98c"), 34, new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), 41 },
                    { new Guid("20fee0c6-2f48-4a60-99c0-ee441632bc4b"), 13, new Guid("60bfd401-8a9a-4e15-b9ae-433957796604"), 37 },
                    { new Guid("2193b41f-4e84-4ef3-bd45-1cd9b602fb2a"), 16, new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), 44 },
                    { new Guid("28121f12-b209-4581-8665-eb35f2b546dd"), 3, new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), 39 },
                    { new Guid("29933844-e046-4bd7-9f35-cb9c3d68b464"), 8, new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), 39 },
                    { new Guid("2aa4e058-88a0-491d-b0c4-eeae3046b085"), 51, new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), 44 },
                    { new Guid("2b6b7a41-28fb-476a-8ee9-b1053c59b1de"), 32, new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), 45 },
                    { new Guid("2ee708c8-1d4a-4b35-b9df-36d1fb0e10be"), 23, new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), 44 },
                    { new Guid("322a179c-0057-43de-992a-00c84dfd2884"), 37, new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), 42 },
                    { new Guid("32ebb3cb-7a39-4e38-9d66-900ea2a2e94b"), 24, new Guid("97dd7463-fc71-4ff1-ab05-287500e93071"), 37 },
                    { new Guid("37d05baa-5aa6-4509-8f19-71c4c8b71ae7"), 39, new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a"), 40 },
                    { new Guid("39be2352-70bd-439b-b67c-e3e1d3dd7131"), 35, new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a"), 43 },
                    { new Guid("39ed0c53-129f-402b-be4c-be67cadac9d0"), 25, new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3"), 39 },
                    { new Guid("3c28509b-f340-4f46-848e-41da71ec0fe4"), 0, new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902"), 42 },
                    { new Guid("3db2b4ab-b5bb-4037-ac15-688853603f84"), 31, new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178"), 43 },
                    { new Guid("47352bb1-b888-4b72-9004-fc51fe66132a"), 6, new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54"), 38 },
                    { new Guid("4b8374d9-affc-417c-b1fc-e72949b80676"), 38, new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902"), 41 },
                    { new Guid("4cd09e91-2e75-4768-ad72-b958706c5dd4"), 35, new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6"), 41 },
                    { new Guid("4d311e1f-f10f-4baf-96ef-9bbb42be5a7c"), 15, new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59"), 38 },
                    { new Guid("4e048f1e-0280-41fd-8684-e2eb13f2071f"), 20, new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), 43 },
                    { new Guid("4ecc6645-eb2e-4391-b21a-55964dab04d2"), 4, new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), 43 },
                    { new Guid("4f2c697a-c2a3-457e-a2d4-4e3be57107eb"), 22, new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), 39 },
                    { new Guid("4f3bbfa2-a335-4edb-b958-d0fef820d4d5"), 54, new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a"), 42 },
                    { new Guid("509b8ee3-e6aa-4df3-a6d6-9ba5169595f6"), 19, new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), 39 },
                    { new Guid("52b8b52a-15c1-4263-ac87-b10a75a050cf"), 26, new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac"), 39 },
                    { new Guid("576d2c33-0a0f-4eba-9d84-16c69285eb55"), 38, new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), 41 },
                    { new Guid("595bf04a-83e0-4ef5-bbd9-c60a62819f62"), 37, new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), 42 },
                    { new Guid("5cca7cb5-83c5-4c04-8e08-0a39a993d403"), 52, new Guid("a413e470-1fa2-46f6-9cd4-8bf41c8b1ff3"), 40 },
                    { new Guid("5e48a880-2734-4f77-a77a-70d3c2265695"), 42, new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), 39 },
                    { new Guid("5e771b8e-0b97-4122-b085-2ed481094a55"), 40, new Guid("97dd7463-fc71-4ff1-ab05-287500e93071"), 38 },
                    { new Guid("6077955b-49d4-44eb-b71a-1022ebf7d564"), 47, new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), 39 },
                    { new Guid("61438b4d-bbd2-484f-bed1-d09c4ce78c71"), 14, new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), 41 },
                    { new Guid("62c17e5e-6246-4748-a1e9-ae0ec8c3aeb4"), 45, new Guid("60bfd401-8a9a-4e15-b9ae-433957796604"), 39 },
                    { new Guid("65b65ed6-e244-4b30-84a4-1c4eb985541c"), 19, new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178"), 44 },
                    { new Guid("66fcd76b-28f7-4327-928b-3936295f73b3"), 29, new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54"), 41 },
                    { new Guid("69e2e4b0-78b8-4729-82c8-495b54673164"), 49, new Guid("7a9110b0-56b0-4eb6-8352-3f94b925792a"), 41 },
                    { new Guid("719b56fd-3362-471c-979b-ee65585dfdb3"), 26, new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), 40 },
                    { new Guid("74082204-2564-444a-8726-dbd28ba80b1e"), 10, new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54"), 37 },
                    { new Guid("750d021d-30d6-4c1a-8a46-2b9214f994a7"), 23, new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), 40 },
                    { new Guid("77a004f1-1951-4915-923c-268685fad921"), 44, new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), 44 },
                    { new Guid("783040db-6d67-4d95-91b3-5a80a0168fc6"), 39, new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca"), 40 },
                    { new Guid("7bed0416-a71a-42c1-b2fa-a023099d5fcf"), 3, new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), 40 },
                    { new Guid("7e8bc7de-9989-4445-9373-d9cc057d90a5"), 5, new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), 41 },
                    { new Guid("7ea5ccfe-360a-4743-9b4f-6d19831709e8"), 32, new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6"), 42 },
                    { new Guid("80637e15-f5a2-47b7-ae7b-512c371dbaa1"), 26, new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), 41 },
                    { new Guid("82e99929-4c6a-4490-9211-06b4ccfe11a4"), 2, new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17"), 42 },
                    { new Guid("8364b5e7-24b7-47f1-9de4-db993ede4b5e"), 1, new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), 43 },
                    { new Guid("83e72774-4b76-4122-ac34-6161dc94e033"), 14, new Guid("97dd7463-fc71-4ff1-ab05-287500e93071"), 39 },
                    { new Guid("84ccdbef-aa0b-4241-a87f-01d16f0efe06"), 28, new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d"), 41 },
                    { new Guid("85817be8-e4a2-455d-9e15-7e816d1fe406"), 26, new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), 43 },
                    { new Guid("885009dc-525b-4870-942f-132cce461846"), 15, new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), 41 },
                    { new Guid("89717704-444b-4d79-938c-0f393d8f39c0"), 42, new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17"), 40 },
                    { new Guid("8a2de318-8f5b-468f-a67b-fb2af83caedc"), 30, new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), 45 },
                    { new Guid("8d0b0713-5fee-4dd6-9b6d-c3e53a3d3ed7"), 50, new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), 42 },
                    { new Guid("8f668477-2ba1-440b-840c-2d14872ca43a"), 53, new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54"), 40 },
                    { new Guid("91fa70c3-2976-4d56-9b5c-bc2121936d74"), 18, new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), 40 },
                    { new Guid("9b30d745-d301-4ea2-81c8-54f1e529dd95"), 8, new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), 38 },
                    { new Guid("9bf50abc-48f3-4c6a-819d-1a33cf556e22"), 37, new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), 42 },
                    { new Guid("9c994d2b-604e-4405-9d4a-fa886cc595a9"), 51, new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), 41 },
                    { new Guid("9e9338b5-08ae-4426-91a3-9f2dea6e711a"), 28, new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), 42 },
                    { new Guid("9f55fdc6-7a59-4bc0-9c02-11ad50e1d317"), 34, new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17"), 43 },
                    { new Guid("a032bebc-66dc-43ff-a764-29e5f8a88af6"), 19, new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d"), 39 },
                    { new Guid("a033731e-f2b0-41b7-b2a4-390701a7c076"), 43, new Guid("345f0d9c-f7a9-4125-b48d-ae750990d5b8"), 42 },
                    { new Guid("a04a952c-fc66-4789-a16d-b2a48b0b5835"), 31, new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), 38 },
                    { new Guid("a1e59f32-ae3d-4f35-8cf1-774a269c668d"), 27, new Guid("5fc478fd-76a0-4d81-ab58-bca2bf140e54"), 40 },
                    { new Guid("a4816cf9-0c3d-4f83-9012-06bafa3ccd3a"), 4, new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d"), 38 },
                    { new Guid("a682493a-8838-4f46-8216-e9fe97a92f12"), 13, new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), 43 },
                    { new Guid("a6b97202-4194-4cae-accc-e35ff100b634"), 1, new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), 42 },
                    { new Guid("a7ba04ef-aa65-4a09-b77d-dcf566aacfa2"), 35, new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac"), 40 },
                    { new Guid("a878bd38-50e9-4304-b160-bc8a69cb871b"), 11, new Guid("3c177e67-4a13-4bc7-a968-9dee872f9fe4"), 44 },
                    { new Guid("aa68012f-b540-422b-833e-be2381f56030"), 30, new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178"), 42 },
                    { new Guid("ad2e5e81-88db-4681-a308-dedeb917e577"), 47, new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), 40 },
                    { new Guid("ad8088af-7833-421b-b792-d538c1a239c5"), 25, new Guid("b7e3074d-3b8e-4202-aaa2-b9fa7bf5cd99"), 42 },
                    { new Guid("b11c0d7c-f22a-4ab3-9020-7ad73e796c4c"), 25, new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), 40 },
                    { new Guid("b2fb0d41-6d60-4eeb-9675-caf440e7cb5b"), 1, new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), 42 },
                    { new Guid("b629b42f-6639-4fe9-87b1-187f3c23ce21"), 42, new Guid("60bfd401-8a9a-4e15-b9ae-433957796604"), 38 },
                    { new Guid("bd4c0b8f-2c81-43b4-9a30-8336085cfb92"), 49, new Guid("fbefd4bf-7409-4089-a246-4d5d560f75d8"), 38 },
                    { new Guid("c2419e02-2185-4837-b120-d2ffb647d799"), 10, new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), 43 },
                    { new Guid("c718bf34-7c7c-4645-baba-ea7e5507774a"), 6, new Guid("2724bbb9-4876-4ab5-89f2-36ec1f55222f"), 46 },
                    { new Guid("cbfb42b8-4bf8-4756-9858-30180fed1004"), 4, new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902"), 40 },
                    { new Guid("cdb89856-eb15-473d-95a8-66599f910845"), 8, new Guid("fe93b1b5-58ce-4521-95b6-52263568a24e"), 45 },
                    { new Guid("cf82da13-228c-4ade-bae0-74fcce08f8de"), 47, new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6"), 40 },
                    { new Guid("d3109a5b-52f1-4082-87a8-dfad8a314c3b"), 27, new Guid("60bfd401-8a9a-4e15-b9ae-433957796604"), 40 },
                    { new Guid("d35ddec6-100f-470a-a93a-0e6d076eaf6c"), 41, new Guid("829b9d72-f8ff-40fd-8fc2-7b7fd78bb348"), 38 },
                    { new Guid("d3d3a8f2-f928-428a-bf40-b448a3d64ac7"), 19, new Guid("7613fabd-ba0c-4c2d-946a-2161d96ab178"), 45 },
                    { new Guid("d455e645-0402-46e9-8c28-ca7cdc42b0e4"), 39, new Guid("50d50f61-c63d-45ae-9600-ad0a10275d54"), 39 },
                    { new Guid("d4efb04b-992f-412a-9090-1a349dee91e5"), 42, new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac"), 37 },
                    { new Guid("d53f8ca2-8e93-4456-b212-3ca56d21e6b0"), 14, new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), 42 },
                    { new Guid("dcdd1854-a90a-45c1-8139-ba179fe715c8"), 16, new Guid("316c3031-e864-4c07-aee6-1a0adb1fbf57"), 37 },
                    { new Guid("dde263f0-8ef6-4610-8030-7cb1515cb4cf"), 18, new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca"), 38 },
                    { new Guid("ddf2568e-8ad2-418e-8021-79063ef86073"), 22, new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca"), 37 },
                    { new Guid("e35c56b0-5f36-425f-85e8-01b3523d4d03"), 48, new Guid("f3c1f98d-72a3-4f85-b989-53075acbad17"), 41 },
                    { new Guid("e585d4c0-80c0-4641-9701-f17d018ef659"), 10, new Guid("a7fd7c21-ae48-42d5-b21f-4cc0acfab6ca"), 39 },
                    { new Guid("e65a8c4e-d272-4396-b036-a7a559b0e022"), 19, new Guid("6e0afd51-5dad-4e79-a824-74ee9ec2d0ac"), 38 },
                    { new Guid("e66682f0-5e3f-4a17-97b0-38435648336f"), 35, new Guid("97dd7463-fc71-4ff1-ab05-287500e93071"), 40 },
                    { new Guid("e7c15ae7-b3d8-4513-bfc0-eb22aaee59ac"), 27, new Guid("25682595-ab87-4dec-bbd4-9bccaf75fe9d"), 40 },
                    { new Guid("e95960b9-ee6a-42f3-8a49-b3a20fdd9a6f"), 50, new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), 43 },
                    { new Guid("ec53edda-89d7-4b48-8afc-1355d110433a"), 20, new Guid("e64cd504-0698-4cb4-8166-83f2bfd2d902"), 39 },
                    { new Guid("f0612bce-a317-427f-812e-828d3a78c0d0"), 11, new Guid("f3831e5a-e50f-4088-b502-7f896ac45b59"), 39 },
                    { new Guid("f1410c55-9099-48b5-a709-ee197ebcfb88"), 22, new Guid("dc2d7e41-80f6-4685-ab7b-c8eb1bae7fc6"), 44 },
                    { new Guid("f54f964e-e5dd-4f59-a54f-ba826029fc32"), 39, new Guid("dd59a1ab-9618-4da6-9b0f-018137d5b0b6"), 39 },
                    { new Guid("fc310885-fb5a-403b-a773-dca948f0e727"), 31, new Guid("4d7a1f4a-1619-4bc6-87b6-cdc5951562e6"), 42 },
                    { new Guid("fdcaeddc-154d-4481-ae55-3831e2627ee9"), 1, new Guid("171081cc-4d9d-4c31-99dd-05444e54d78a"), 38 },
                    { new Guid("ff078da1-5750-4dd9-9bd9-caf9b1d7ad77"), 13, new Guid("0ff2e381-acc1-4fcb-a179-81aea031b2be"), 41 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "CreateDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "IsExternalLogin", "LastModifiedDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileName", "ProviderName", "RoleId", "SecurityStamp", "TotalMoney", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("b9de0aaa-3e75-4084-8eee-f2cd6f14c4dd"), 0, null, "78f3fdfc-1cda-495c-b39a-4a0693d68554", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, "Jane", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("62ce5c4c-023e-459f-9b6a-488f3438520e"), null, 1500m, false, "jane.smith" },
                    { new Guid("e988a67a-6170-4ed5-ab11-36603908a54f"), 0, null, "d91e8e26-5b81-4089-a841-84f47d76cfdc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2204, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "machgiahuy@gmail.com", false, "Mach", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gia Huy", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("4d24feec-3be9-4d79-abed-1185a6d871d3"), null, 1000m, false, "Mach Gia Huy" }
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
