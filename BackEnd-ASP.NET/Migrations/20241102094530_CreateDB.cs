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
                    GeneralReview = table.Column<int>(type: "int", nullable: false),
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
                    { new Guid("0431a0a2-c866-452a-8efc-eeab951b2056"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(887), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/[IDGiay_1]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(901), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20, 0 },
                    { new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(935), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/[IDGiay_8]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(936), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84, 0 },
                    { new Guid("12898a90-7645-4f19-b548-6da58618f253"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1238), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/[IDGiay_20]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1239), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10, 0 },
                    { new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5"), 4.8m, "Nike", "Football", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(911), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/[IDGiay_3]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(912), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10, 0 },
                    { new Guid("23615a39-528a-4625-8e26-7ef6231aba4a"), 7m, "Nike", "Basketball", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1291), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/[IDGiay_26]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1292), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5, 0 },
                    { new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1246), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/[IDGiay_22]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1247), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45, 0 },
                    { new Guid("2ae15ce3-5df0-4772-8125-5421a563b688"), 4.4m, "Converse", "Basketball", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1251), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/[IDGiay_23]_AnhChinh.png", true, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1251), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34, 0 },
                    { new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1114), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/[IDGiay_13]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1115), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23, 0 },
                    { new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3"), 4.2m, "Nike", "Tennis", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(916), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/[IDGiay_4]_AnhChinh.png", true, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(916), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5, 0 },
                    { new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29"), 4.2m, "Puma", "Football", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1109), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/[IDGiay_12]_AnhChinh.png", true, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1110), "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17, 0 },
                    { new Guid("58eb3939-9946-4d0c-b168-d04bb739699b"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1092), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/[IDGiay_9]_AnhChinh.png", true, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1094), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268, 0 },
                    { new Guid("6219b616-ae80-42d8-afa2-4aba5279734b"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1242), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/[IDGiay_21]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1243), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10, 0 },
                    { new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1223), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/[IDGiay_17]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1223), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20, 0 },
                    { new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 3, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1311), "Whether you're starting your running journey or an expert eager to switch up your pace, the Downshifter 13 is down for the ride. With a revamped upper, cushioning and durability, it helps you find that extra gear or take that first stride towards chasing down your goals.", 40m, 1, "images/shoes/[IDGiay_Home_3]_AnhChinh_1.png", true, new DateTime(2024, 10, 3, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1311), "Plastics, yarns and textiles.", "Nike Downshifter 13", 2069000m, 78, 20, 0 },
                    { new Guid("881d695e-24da-4f84-9419-6a75e9d6114f"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1256), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/[IDGiay_24]_AnhChinh.png", true, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1257), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100, 0 },
                    { new Guid("8d704b3c-9f76-4127-a342-4850fae21948"), 4.9m, "Nike", "Yoga", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(920), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/[IDGiay_5]_AnhChinh.png", true, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(920), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66, 0 },
                    { new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada"), 4.7m, "Nike", "Basketball", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(906), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/[IDGiay_2]_AnhChinh.png", true, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(906), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45, 0 },
                    { new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea"), 4.7m, "Converse", "Yoga", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1287), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/[IDGiay_25]_AnhChinh.png", true, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1288), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30, 0 },
                    { new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 3, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1296), "Nike Youth React Presto Extreme combines lightweight React technology and a flexible upper to provide comfort and support for everyday activities and gym training.", 40m, 2, "images/shoes/[IDGiay_Home_1]_AnhChinh_1.png", true, new DateTime(2024, 10, 3, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1302), "Rubber, yarns and textiles.", "Nike Youth React Presto Extreme", 2069000m, 78, 60, 0 },
                    { new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1212), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/[IDGiay_15]_AnhChinh.png", true, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1214), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87, 0 },
                    { new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 3, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1305), "Nike's first lifestyle Air Max brings you style, comfort and big attitude in the Nike Air Max 270. The design draws inspiration from Air Max icons, showcasing Nike's greatest innovation with its large window and fresh array of colors.", 40m, 1, "images/shoes/[IDGiay_Home_2]_AnhChinh_1.png", true, new DateTime(2024, 10, 3, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1306), "Plastics, yarns and textiles.", "Nike Air Max 270", 4059000m, 8, 3, 0 },
                    { new Guid("bbd74e81-d305-4413-bdb2-a475989b676e"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(924), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/[IDGiay_6]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(925), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381, 0 },
                    { new Guid("bcc67668-9258-48b9-954e-7a87aac79171"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1229), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/[IDGiay_18]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1229), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12, 0 },
                    { new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1099), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/[IDGiay_10]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1099), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3, 0 },
                    { new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3"), 4.4m, "Adidas", "Football", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(931), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/[IDGiay_7]_AnhChinh.png", true, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(931), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37, 0 },
                    { new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1218), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/[IDGiay_16]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1218), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25, 0 },
                    { new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1234), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/[IDGiay_19]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1235), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111, 0 },
                    { new Guid("df78e5ac-10a6-4b40-847e-657a873e657c"), 4.1m, "Puma", "Yoga", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1119), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/[IDGiay_14]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1120), "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22, 0 },
                    { new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994"), 4.0m, "Puma", "Basketball", new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1103), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/[IDGiay_11]_AnhChinh.png", false, new DateTime(2024, 11, 2, 16, 45, 20, 589, DateTimeKind.Local).AddTicks(1104), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21, 0 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("08e14c04-c740-446d-a1aa-7fdf80b62902"), new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("092375ce-f7b0-4b91-827b-a36295b20237"), new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("0e9f24cc-e599-44ee-ad84-7d2d3bdd6a60"), new Guid("bcc67668-9258-48b9-954e-7a87aac79171"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("12f31b31-56bd-4865-ae9d-f3c1f7ee0fc0"), new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("14947dbd-858b-49bc-a2ee-1ac84eb95cc2"), new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("162ac3e7-4606-429b-912c-e46b54227443"), new Guid("bbd74e81-d305-4413-bdb2-a475989b676e"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("18f2d7e8-44c1-4d4b-ba9e-245f98241d26"), new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("1a8dc1c4-14a9-40c9-ae58-c0302b36650c"), new Guid("0431a0a2-c866-452a-8efc-eeab951b2056"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("1c08a3cd-60fd-4e5c-9e87-ba2e1645ce4a"), new Guid("6219b616-ae80-42d8-afa2-4aba5279734b"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("1fa3249a-e09b-43f4-9b70-134191dcc546"), new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3"), "images/shoes/[IDGiay_Home_3]_AnhPhu_4.png" },
                    { new Guid("212b0fed-5124-4c63-aff4-b567df01858a"), new Guid("df78e5ac-10a6-4b40-847e-657a873e657c"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("2842d3bf-72cb-47ab-9e12-bbb56d58c8db"), new Guid("8d704b3c-9f76-4127-a342-4850fae21948"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("2f752aaa-0597-442e-8a65-17512562adfb"), new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("2f79e45f-30af-49bd-84ae-4154056f4cc5"), new Guid("6219b616-ae80-42d8-afa2-4aba5279734b"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("30f2b91f-db40-47a4-b0cd-42465e9f9237"), new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c"), "images/shoes/[IDGiay_Home_2]_AnhPhu_2.png" },
                    { new Guid("32570137-6a1d-4a8b-9571-69d6877b1d2b"), new Guid("6219b616-ae80-42d8-afa2-4aba5279734b"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("3304a2da-d247-463d-9c04-55eb3d7a72ee"), new Guid("23615a39-528a-4625-8e26-7ef6231aba4a"), "images/shoes/[IDGiay_26]_AnhPhu_3.jpg" },
                    { new Guid("34996c28-ee79-45eb-a813-043a81c0e74b"), new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06"), "images/shoes/[IDGiay_Home_1]_AnhPhu_4.jpg" },
                    { new Guid("34e5cb0d-b512-45b1-a863-d2c27ed6365a"), new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("364136f1-0222-4ee0-a475-e5cf4df85ea3"), new Guid("0431a0a2-c866-452a-8efc-eeab951b2056"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("381fdf5e-4a40-4e6f-a6d2-bb1a12e3a0f9"), new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("387f959b-e994-436a-a72f-d9e9b09ca43d"), new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("3a926d90-d2cc-456e-8f4c-f3afce5f7987"), new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("43bff9a2-2547-40b3-aecc-531d074656d8"), new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("43d723df-ede6-435a-a40f-8aa500d24fcd"), new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("46a13dce-34f0-44e2-a692-c9d81a30f84d"), new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("47170bc0-75c9-4e22-a228-700a4eea7a28"), new Guid("8d704b3c-9f76-4127-a342-4850fae21948"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("48aab423-1037-43f1-bcb7-0b7761eb10fa"), new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("49bb1dfc-47b9-4cef-ae49-893af070554b"), new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("4cf3a7cb-ef46-4758-81a1-8d92e7327ca9"), new Guid("23615a39-528a-4625-8e26-7ef6231aba4a"), "images/shoes/[IDGiay_26]_AnhPhu_4.jpg" },
                    { new Guid("4dae3d4a-f449-48e6-a605-0dda3e148710"), new Guid("bcc67668-9258-48b9-954e-7a87aac79171"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("4e04dc1e-6fee-487d-8448-f28525842abe"), new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("53ef99a9-e233-454d-978e-8ccac3ee90db"), new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("54625ec9-25eb-48f5-b5b2-68635a7813f1"), new Guid("df78e5ac-10a6-4b40-847e-657a873e657c"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("55697e03-ad65-45ef-b9ee-7f13a68f671a"), new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("55b3d804-1132-4cef-a4fc-9ef672a879ee"), new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3"), "images/shoes/[IDGiay_Home_3]_AnhPhu_3.png" },
                    { new Guid("58ef0735-d079-4c2b-8e66-213b85de0a83"), new Guid("881d695e-24da-4f84-9419-6a75e9d6114f"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("59982f71-0588-4803-a3a9-d47e479a78a3"), new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3"), "images/shoes/[IDGiay_Home_3]_AnhPhu_2.png" },
                    { new Guid("5e1e27bc-dbbc-44a0-a31c-cf7a6902240e"), new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c"), "images/shoes/[IDGiay_Home_2]_AnhPhu_4.png" },
                    { new Guid("60624959-8102-492c-a3ef-4c75479f1d82"), new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3"), "images/shoes/[IDGiay_Home_3]_AnhPhu_1.png" },
                    { new Guid("63a613f4-e7af-4d05-8a41-28f13aab8d55"), new Guid("58eb3939-9946-4d0c-b168-d04bb739699b"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("644a0894-8c6b-43fc-a474-d819d87c1141"), new Guid("bbd74e81-d305-4413-bdb2-a475989b676e"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("647d09b7-6a28-4e76-9185-f15af6115f72"), new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("664ef02a-cd73-41ab-bfdc-b7321577f031"), new Guid("12898a90-7645-4f19-b548-6da58618f253"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("66abe111-e0ef-4399-97c2-07768a2f936b"), new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("677e9c70-0833-405f-9e00-59170c66781a"), new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("69d1f7b7-1197-46a7-90e4-32f088fa1fef"), new Guid("881d695e-24da-4f84-9419-6a75e9d6114f"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("6a0b5410-59a3-4d1d-8e58-8b6453d0ad1c"), new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("6ad2decc-db6f-4c16-a20d-7fe550f5e793"), new Guid("12898a90-7645-4f19-b548-6da58618f253"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("6c56bbbf-d6d3-462f-a42e-d75d34f28d1b"), new Guid("bcc67668-9258-48b9-954e-7a87aac79171"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("6d2b42d0-b4cd-48ee-99fd-46d42ef5cbb3"), new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("6f4ad5a7-4fa4-4884-a5df-2b1936469409"), new Guid("bbd74e81-d305-4413-bdb2-a475989b676e"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("712ac971-aedd-4436-b77a-4617371ea54b"), new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("728eb9cc-73e1-4407-b393-fdb38da7aa46"), new Guid("6219b616-ae80-42d8-afa2-4aba5279734b"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("7297fa80-2dfc-4957-982d-bf7f12fb924f"), new Guid("bcc67668-9258-48b9-954e-7a87aac79171"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("73f45f48-10f1-4377-9399-a9f31a45b35d"), new Guid("12898a90-7645-4f19-b548-6da58618f253"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("74cb1fb6-a9ae-4398-82b6-f717cf3f0cb6"), new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("74e5497a-c15f-47e4-944a-7974b997ff4d"), new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("78326282-4f84-46ba-b2d2-74891d09036c"), new Guid("2ae15ce3-5df0-4772-8125-5421a563b688"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("78d37694-a855-4143-aa67-d4bdbfb20080"), new Guid("23615a39-528a-4625-8e26-7ef6231aba4a"), "images/shoes/[IDGiay_26]_AnhPhu_1.png" },
                    { new Guid("7a0fd66f-d06b-4703-8255-6e8458ec17cc"), new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("7a14f04c-0ac0-461b-8527-c51b768f921a"), new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("7c295101-5f20-498c-93fa-7f1e5bb5bd69"), new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("7da44d37-e96d-4dd9-9e1f-521d1b2623dd"), new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("7ed53eaa-6b14-4fbc-8c1d-02af757125a6"), new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("88541de7-b84d-4d74-93a9-869c7c9c7cd8"), new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("8922b3a6-c658-489e-88d0-888a0491a835"), new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("8abe913a-4362-4345-9712-92990bd1e3c2"), new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("8b48dd85-3955-435a-8d53-c7cc4f4f1f7a"), new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("8c84379a-2b09-4d22-b85f-afd5410e087c"), new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("902aba78-6554-4ea1-a843-2da311d16714"), new Guid("58eb3939-9946-4d0c-b168-d04bb739699b"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("933cf24f-e47f-48b9-a7a0-8f51ea68d6e8"), new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("93a3642d-d2fb-48f6-be5b-3a14fad0b97a"), new Guid("8d704b3c-9f76-4127-a342-4850fae21948"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("97eeb150-8626-411c-b1da-6fbcbb92692e"), new Guid("2ae15ce3-5df0-4772-8125-5421a563b688"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("99407ef6-3e54-414d-878a-5c9b6b9e197e"), new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06"), "images/shoes/[IDGiay_Home_1]_AnhPhu_2.jpg" },
                    { new Guid("9e626bc7-2ba5-4a21-984f-0a720be5e3cc"), new Guid("df78e5ac-10a6-4b40-847e-657a873e657c"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("9ea7b80b-fcbf-435b-9c0a-0fb0b4a52384"), new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("9f387a86-9a09-45b5-832c-2beb9e0b5baa"), new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c"), "images/shoes/[IDGiay_Home_2]_AnhPhu_3.png" },
                    { new Guid("a0fe9133-b928-4c35-8d98-b1e37d202310"), new Guid("2ae15ce3-5df0-4772-8125-5421a563b688"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("a2bad8c3-a3cb-4456-9226-6893f58434b2"), new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("a77fba96-cd7d-4047-aa5f-c1f054987f80"), new Guid("881d695e-24da-4f84-9419-6a75e9d6114f"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("b05e0ba1-2cf8-42f5-9bce-6c925086e603"), new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("b12487d4-6dc9-4dba-8bf9-97fd0c79fd5c"), new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("b3943e31-505c-4cf3-8420-fdd04f60fdc8"), new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06"), "images/shoes/[IDGiay_Home_1]_AnhPhu_1.jpg" },
                    { new Guid("b47f88cd-abd8-428e-9e1a-264998ea73be"), new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("b5752eed-f15a-47fd-8a22-2cdc3232e15a"), new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("bd400c93-0d6c-4585-83ba-2e0313961fee"), new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("c19bccfe-f25a-4dc1-85a0-2e3e4bd0aa94"), new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("c376d3fe-9684-4b94-9ef4-fd4fdf88924a"), new Guid("58eb3939-9946-4d0c-b168-d04bb739699b"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("c94122ae-3ea6-43eb-ab84-7f143b1798ed"), new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06"), "images/shoes/[IDGiay_Home_1]_AnhPhu_3.jpg" },
                    { new Guid("ca29e049-0d92-45b6-95f1-ee92cd4c45da"), new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c"), "images/shoes/[IDGiay_Home_2]_AnhPhu_1.png" },
                    { new Guid("cd8f358d-48a3-4f61-82fb-97c9df683e59"), new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("cf1688ff-7f14-4ca4-a6dd-6d454cf0ee7e"), new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("cfdb82ac-df46-4849-a463-f15e04868afd"), new Guid("58eb3939-9946-4d0c-b168-d04bb739699b"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("d348ceac-70d4-4d0b-98aa-9f63b11f7a31"), new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("d36ef8ed-0bb7-4ee4-aff6-a6e4da607ca6"), new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("d662634c-ef6e-414a-82d8-231a182f6044"), new Guid("0431a0a2-c866-452a-8efc-eeab951b2056"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("d7f6054f-702b-4ff0-9f61-3d550f190b3d"), new Guid("12898a90-7645-4f19-b548-6da58618f253"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("da1bdc85-cd15-455a-baba-a3e8fccea402"), new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("dcdc647e-5de0-4628-ba20-61b9d173e63b"), new Guid("bbd74e81-d305-4413-bdb2-a475989b676e"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("dd073242-34b7-4bef-bd29-24a3ec3f77ae"), new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("ddf2ddd1-a3b3-41a3-90c0-ca0fd3ba9959"), new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("e15bc18a-64ca-449b-9887-69341b9036d4"), new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("e2ad3c80-75c2-454d-8f3d-c29f23b1f341"), new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("e2df7a43-9e7b-4df7-96b2-19579f029487"), new Guid("881d695e-24da-4f84-9419-6a75e9d6114f"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("e417df7c-92d8-4edf-9c54-6869b691fc19"), new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("e59af16e-ebee-4dc2-bf13-38f9f086e998"), new Guid("23615a39-528a-4625-8e26-7ef6231aba4a"), "images/shoes/[IDGiay_26]_AnhPhu_2.png" },
                    { new Guid("eab046c7-11c3-4cd0-9815-97635f667f19"), new Guid("2ae15ce3-5df0-4772-8125-5421a563b688"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("ed867a15-37d6-437a-a4fd-fe6ad1d30bd0"), new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("f51602c4-48c3-4002-a7b5-aa0e255f9da5"), new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("f6bab441-6698-48e5-a15f-cdafaa39232d"), new Guid("df78e5ac-10a6-4b40-847e-657a873e657c"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("fa77b775-3b60-49e8-b3f9-ef2daadf85ad"), new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("fc26ad9b-98c5-45c8-a35d-87a16ee1987b"), new Guid("8d704b3c-9f76-4127-a342-4850fae21948"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("fd320df5-cc42-4baf-96e1-748f8e587d53"), new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("fef6e45a-f7ef-46b8-b1b9-6e3b68f43675"), new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("ff62c450-b800-4c98-a5e3-e0ef16f90c1f"), new Guid("0431a0a2-c866-452a-8efc-eeab951b2056"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("0723d172-8fe8-47a1-a7fa-8e93d75205e1"), "Summer", new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3") },
                    { new Guid("09c91aa7-1286-43e4-b3a3-4e24d0541272"), "Summer", new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06") },
                    { new Guid("175f232a-302d-4053-9040-3891c163c953"), "Winter", new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d") },
                    { new Guid("19577f3f-af7c-4444-ba6c-c1d4ed5672a6"), "Winter", new Guid("58eb3939-9946-4d0c-b168-d04bb739699b") },
                    { new Guid("1a206483-1e4a-4e4a-9306-236d5d2287f9"), "Winter", new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3") },
                    { new Guid("1b81d8db-b5a3-431c-9a8f-64033416b13e"), "Winter", new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada") },
                    { new Guid("1bdce35f-b5e7-453b-ad81-7f04965813bc"), "Winter", new Guid("12898a90-7645-4f19-b548-6da58618f253") },
                    { new Guid("1bee8778-3c1b-4e77-97d7-64cdb75f6fef"), "Summer", new Guid("6219b616-ae80-42d8-afa2-4aba5279734b") },
                    { new Guid("1ea2da63-780e-44cd-848b-f6d481813856"), "Spring", new Guid("12898a90-7645-4f19-b548-6da58618f253") },
                    { new Guid("208fb6b4-44b5-4fd9-a792-a93eddfeebd1"), "Spring", new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5") },
                    { new Guid("23a23984-180f-4727-922e-a7f7c450b2bd"), "Spring", new Guid("6219b616-ae80-42d8-afa2-4aba5279734b") },
                    { new Guid("2adb260f-2ea9-46bd-95d6-4843707eb881"), "Summer", new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb") },
                    { new Guid("2fc17aae-8df0-4a53-8f73-d93d9d4c548b"), "Spring", new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e") },
                    { new Guid("36a165af-f5b7-4049-88d9-6a9693db2e04"), "Fall", new Guid("23615a39-528a-4625-8e26-7ef6231aba4a") },
                    { new Guid("40acd8d2-fa0a-4b24-8bb4-81976dc9577d"), "Spring", new Guid("bcc67668-9258-48b9-954e-7a87aac79171") },
                    { new Guid("4807c1fa-52d5-4ca1-a8a8-43d6e123a847"), "Spring", new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3") },
                    { new Guid("4d894f61-7de2-419d-b06c-2e29f1a3969d"), "Fall", new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3") },
                    { new Guid("5c401672-c653-48f8-98d0-7452e4efbb78"), "Summer", new Guid("0431a0a2-c866-452a-8efc-eeab951b2056") },
                    { new Guid("603d4786-17ed-462a-82f9-71c3556d3851"), "Spring", new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29") },
                    { new Guid("61b25351-ad19-4718-a056-14e5fb3333e3"), "Spring", new Guid("0431a0a2-c866-452a-8efc-eeab951b2056") },
                    { new Guid("61d6ff8c-b27c-4a5b-bc20-00853198d42b"), "Summer", new Guid("58eb3939-9946-4d0c-b168-d04bb739699b") },
                    { new Guid("635e4042-b4c7-42aa-a1fd-a37bc8a0aa24"), "Summer", new Guid("df78e5ac-10a6-4b40-847e-657a873e657c") },
                    { new Guid("66b4bf72-149e-4e32-92b3-4c2bf675bf46"), "Summer", new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3") },
                    { new Guid("671bfa7d-6f08-4a31-bfaa-b41755deb38d"), "Fall", new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3") },
                    { new Guid("67c4f8c6-1495-405d-abad-b61800d47280"), "Spring", new Guid("23615a39-528a-4625-8e26-7ef6231aba4a") },
                    { new Guid("6b220881-6c08-4ed7-b707-3d9ccae3c0df"), "Winter", new Guid("8d704b3c-9f76-4127-a342-4850fae21948") },
                    { new Guid("6ee72d45-241d-4bc2-8a0b-3d8b3a25052e"), "Summer", new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c") },
                    { new Guid("6f4c328a-26de-4153-b785-1f0e3fa34ade"), "Summer", new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c") },
                    { new Guid("6fd46fdd-bb9d-4fce-85d5-7d3e1e845b2b"), "Summer", new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada") },
                    { new Guid("705b4a5d-1929-44a1-9543-7bcdff059c34"), "Fall", new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29") },
                    { new Guid("722ab73d-5f04-4f8b-a7d9-7704d260cb0e"), "Spring", new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb") },
                    { new Guid("79a62758-1c34-480d-9523-739ac81239ee"), "Winter", new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615") },
                    { new Guid("7a35ce28-0754-4076-8d0e-a91dbeda228b"), "Summer", new Guid("bbd74e81-d305-4413-bdb2-a475989b676e") },
                    { new Guid("837e3290-570c-491b-85a2-177cf86db873"), "Spring", new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3") },
                    { new Guid("8fb2f2a7-96c0-425d-a823-e4b221f861ab"), "Winter", new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3") },
                    { new Guid("9127b1b8-7398-4466-81e2-7eb7ce2b9c79"), "Winter", new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29") },
                    { new Guid("91ef07e3-8f95-4cac-a00f-d2e4095a6cb3"), "Fall", new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3") },
                    { new Guid("93cf49fb-5252-4497-8f6a-6f05504c1943"), "Fall", new Guid("881d695e-24da-4f84-9419-6a75e9d6114f") },
                    { new Guid("9ee17dfe-0843-435a-b324-e119b7016319"), "Winter", new Guid("6219b616-ae80-42d8-afa2-4aba5279734b") },
                    { new Guid("a1bd6d1a-d5e2-4440-8fd1-99a2ad6782ba"), "Spring", new Guid("df78e5ac-10a6-4b40-847e-657a873e657c") },
                    { new Guid("a6eed01d-6f51-4332-a7cf-5f167721fc4e"), "Spring", new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c") },
                    { new Guid("a8b744f4-a58f-4f6e-b5b9-82ded01b4f3f"), "Summer", new Guid("bcc67668-9258-48b9-954e-7a87aac79171") },
                    { new Guid("acb0f157-00f5-4bba-af96-1d0cd95e2cb6"), "Spring", new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d") },
                    { new Guid("af8f7751-8fec-4e3a-ba2f-3dc9b15b775d"), "Fall", new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada") },
                    { new Guid("b0354bb1-4338-4bf2-8e35-b8ac28693bf1"), "Winter", new Guid("23615a39-528a-4625-8e26-7ef6231aba4a") },
                    { new Guid("b1b2d089-7b5e-4095-b606-a60fff5a8301"), "Winter", new Guid("2ae15ce3-5df0-4772-8125-5421a563b688") },
                    { new Guid("b45c021c-432a-45bd-bef7-ed42d28ad2fe"), "Summer", new Guid("12898a90-7645-4f19-b548-6da58618f253") },
                    { new Guid("b8be3ac0-80ff-485b-9f47-d452de251b43"), "Fall", new Guid("8d704b3c-9f76-4127-a342-4850fae21948") },
                    { new Guid("ba0f9059-6bf8-430b-b0b7-833d0d45ed35"), "Winter", new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3") },
                    { new Guid("bfa2d7e8-5653-4910-92b8-4334893a62f0"), "Winter", new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d") },
                    { new Guid("c10edd79-2737-4651-92a3-f1f06362fddf"), "Summer", new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d") },
                    { new Guid("c31a309c-6bdf-4167-91bd-6d480b469847"), "Fall", new Guid("6219b616-ae80-42d8-afa2-4aba5279734b") },
                    { new Guid("c7007a37-8638-41b6-a381-10ca1cebab33"), "Winter", new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3") },
                    { new Guid("d872f59d-506e-4130-ab27-938cd77e5440"), "Summer", new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3") },
                    { new Guid("d8c3523a-839c-49ab-9bd7-9049dadff75c"), "Spring", new Guid("881d695e-24da-4f84-9419-6a75e9d6114f") },
                    { new Guid("dedcee50-b6a0-43d4-9c3c-1366f3d2c8cf"), "Fall", new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3") },
                    { new Guid("e3c51429-216a-400a-b94b-5ba0e73d9463"), "Fall", new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c") },
                    { new Guid("e5df2cd8-5274-4170-8d08-916678530bfc"), "Spring", new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3") },
                    { new Guid("ed85d0a3-ef20-4058-82fe-0afea5abe36f"), "Summer", new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3") },
                    { new Guid("fc435637-b6e2-4f76-b778-060be627a279"), "Spring", new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06") },
                    { new Guid("febd4509-b856-416b-955a-4d5a92dccf54"), "Spring", new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea") },
                    { new Guid("ff5be896-fd81-48a7-8e38-a458a2e9ae46"), "Fall", new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("03e43033-ec2a-462b-857f-d981ad363859"), "Pink", new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5") },
                    { new Guid("0c2717d8-f548-46fd-911f-138b929f2257"), "Orange", new Guid("8d704b3c-9f76-4127-a342-4850fae21948") },
                    { new Guid("0f0048c5-1b42-4188-8a2e-c238ea00e1a4"), "Blue", new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada") },
                    { new Guid("1591c289-d60d-4beb-aedd-1f3bd166b8bc"), "Pink", new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb") },
                    { new Guid("15b8c96d-bc76-4060-bc66-0c3f49061249"), "Pink", new Guid("df78e5ac-10a6-4b40-847e-657a873e657c") },
                    { new Guid("16a15944-cbcc-4933-ba0f-574155e04a28"), "White", new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615") },
                    { new Guid("17d61d19-202e-45a1-a105-854804f1ed95"), "Blue", new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3") },
                    { new Guid("1ac89278-31c2-4488-8d02-45abff13b47c"), "Orange", new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994") },
                    { new Guid("1f70912c-3ec7-4115-8f61-a598133e5420"), "Blue", new Guid("2ae15ce3-5df0-4772-8125-5421a563b688") },
                    { new Guid("2339ef7f-3731-47cc-a078-cb38b0d489fe"), "Yellow", new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3") },
                    { new Guid("273e9f99-7689-49d3-ba89-ffaf23f035e8"), "White", new Guid("0431a0a2-c866-452a-8efc-eeab951b2056") },
                    { new Guid("2fe86c24-f15c-4538-96fe-abf51f06f27e"), "Black", new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06") },
                    { new Guid("34098037-0538-4526-9fc7-094aacb96eb6"), "Orange", new Guid("bbd74e81-d305-4413-bdb2-a475989b676e") },
                    { new Guid("3558adeb-4f25-489d-8a8c-e9f58d58cd89"), "Black", new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c") },
                    { new Guid("3bbe6fa0-1dce-4108-a618-269776552925"), "Blue", new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d") },
                    { new Guid("3e68dc4e-8ef3-4526-bc33-902e1acb0bac"), "Green", new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea") },
                    { new Guid("3f1740aa-8be6-4915-aa07-f4f1bd754f23"), "White", new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3") },
                    { new Guid("3fd7af73-fbec-45d7-9a57-73156bbcad4d"), "Green", new Guid("bbd74e81-d305-4413-bdb2-a475989b676e") },
                    { new Guid("41af1777-b83c-4bf3-a57e-bceb1213aa52"), "Blue", new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29") },
                    { new Guid("45e5b178-837e-4b49-bd90-2dc1684e5318"), "Red", new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3") },
                    { new Guid("467c0f7f-c92e-463e-9bfc-35e73e491c34"), "White", new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada") },
                    { new Guid("4e51d403-2bb6-485b-acb7-5f6159d037c1"), "Brown", new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3") },
                    { new Guid("4fc725df-96ee-4838-9975-e8807b3ba649"), "Black", new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3") },
                    { new Guid("50862a9e-9c9b-4062-b17a-b6a359998b34"), "Red", new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d") },
                    { new Guid("5310a6ea-a99e-4b9d-9fd0-57b643934d69"), "Pink", new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c") },
                    { new Guid("59910aeb-9813-4ed0-8f35-448c478fced4"), "Black", new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e") },
                    { new Guid("59aa9b77-7473-493e-998e-d253a0343c43"), "Black", new Guid("0431a0a2-c866-452a-8efc-eeab951b2056") },
                    { new Guid("5bec8455-89c5-4ee4-a022-9f8d5d2f7657"), "Pink", new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d") },
                    { new Guid("5e90266f-4815-45ae-90be-325c01505b62"), "Purple", new Guid("0431a0a2-c866-452a-8efc-eeab951b2056") },
                    { new Guid("5fc586b7-6397-43a4-af53-042beeba79fa"), "Orange", new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c") },
                    { new Guid("62947789-3474-4fab-b4ae-80eead22fc3b"), "Blue", new Guid("bbd74e81-d305-4413-bdb2-a475989b676e") },
                    { new Guid("724ee7e1-634b-41b4-adbe-cbab20f0f496"), "Red", new Guid("23615a39-528a-4625-8e26-7ef6231aba4a") },
                    { new Guid("78f622cd-fa46-40dc-8682-41cd55db299b"), "Black", new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada") },
                    { new Guid("7a547be9-2b08-4a9b-8a48-8ec5877dbfab"), "Blue", new Guid("12898a90-7645-4f19-b548-6da58618f253") },
                    { new Guid("850f36f6-c2e1-4153-9eb1-1ab02404ce73"), "Blue", new Guid("0431a0a2-c866-452a-8efc-eeab951b2056") },
                    { new Guid("8591dbd3-9b4c-4717-9a4b-a259f99dabf9"), "White", new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d") },
                    { new Guid("87fc4cb0-1a29-4e19-9175-47fefb08e3c1"), "White", new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb") },
                    { new Guid("8c66f706-59f4-4878-bf5a-1f444a3465fb"), "White", new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e") },
                    { new Guid("8f2e83e4-503b-49d2-9227-a3ccf11ac13f"), "Black", new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5") },
                    { new Guid("91b231d5-608f-406f-9770-1faec9578144"), "Black", new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c") },
                    { new Guid("94f97a6c-e273-446f-9ec6-00775642268b"), "White", new Guid("8d704b3c-9f76-4127-a342-4850fae21948") },
                    { new Guid("96af3a5d-e63f-4570-8ab0-2f67e22aff22"), "Purple", new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb") },
                    { new Guid("99f56770-db76-4996-8182-29ac0ccaf3d2"), "Red", new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3") },
                    { new Guid("a191a813-da18-4e65-b51c-03c01b52fd43"), "Black", new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29") },
                    { new Guid("a3312b1f-7f18-4b0c-b940-3ee42d595b05"), "Black", new Guid("6219b616-ae80-42d8-afa2-4aba5279734b") },
                    { new Guid("ad16d30f-e438-4eae-adc7-a0405ade5b41"), "White", new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06") },
                    { new Guid("aec79020-8ee0-4455-8d16-a142bd4d6341"), "Red", new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada") },
                    { new Guid("af2da881-a5b9-4641-93e7-ddf2d633eea1"), "White", new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3") },
                    { new Guid("af4eeab5-0020-4fe0-8523-c69283ea436b"), "Black", new Guid("bbd74e81-d305-4413-bdb2-a475989b676e") },
                    { new Guid("b2512607-d9b7-4d0c-90dc-9ffa60cf45a5"), "White", new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c") },
                    { new Guid("b5d66a6b-0de9-42ac-9186-adbfd4d85447"), "Black", new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3") },
                    { new Guid("b6b46674-cf55-43e6-98bd-5ce04f2fd927"), "Blue", new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d") },
                    { new Guid("b852fe64-cea0-4db6-9f73-71096370dfc3"), "White", new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5") },
                    { new Guid("b94c1e47-cb29-4de9-917d-fb98ef4640bd"), "Red", new Guid("bbd74e81-d305-4413-bdb2-a475989b676e") },
                    { new Guid("ba692096-a97c-4925-8743-574da85ca241"), "Black", new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d") },
                    { new Guid("bd1a3c6c-c994-4583-bda3-55e1fe8f0305"), "Black", new Guid("8d704b3c-9f76-4127-a342-4850fae21948") },
                    { new Guid("be2a0a4e-db63-4455-8d3e-7a5dadc11fee"), "Grey", new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3") },
                    { new Guid("c20c54e3-73cc-49f6-b45a-05e397aeb926"), "Blue", new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5") },
                    { new Guid("c35c4864-2ec3-4131-9192-322400a72e2a"), "Pink", new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d") },
                    { new Guid("c79976d5-b24f-46a9-9b64-b1dc328b0e27"), "Brown", new Guid("881d695e-24da-4f84-9419-6a75e9d6114f") },
                    { new Guid("c79ddfb7-770d-44a6-9139-c8ea666ad8c1"), "Yellow", new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5") },
                    { new Guid("cacf1786-f294-414e-a842-44e33421d718"), "White", new Guid("bbd74e81-d305-4413-bdb2-a475989b676e") },
                    { new Guid("cd8a06c2-a7dc-4ebe-af07-d722a79d274e"), "Purple", new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994") },
                    { new Guid("d563723a-68e0-4a42-bcad-ab91e1cc8c2a"), "Brown", new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea") },
                    { new Guid("d625bcd8-0c48-4341-9864-df91306f747b"), "Blue", new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c") },
                    { new Guid("d93f5805-9d1e-40c2-aa99-42f83ff916e7"), "Green", new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29") },
                    { new Guid("db1a7181-3231-4707-8fb3-a63ef7cf992e"), "White", new Guid("881d695e-24da-4f84-9419-6a75e9d6114f") },
                    { new Guid("ddebe0ca-3065-47e3-81d0-a1ba286ffb0d"), "Black", new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3") },
                    { new Guid("e405703d-6ee5-4561-9608-e3e6d24e8b37"), "White", new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3") },
                    { new Guid("e6b3afec-6d80-42a6-af8e-9cdb8af4b8b3"), "Black", new Guid("23615a39-528a-4625-8e26-7ef6231aba4a") },
                    { new Guid("ed2e1de9-4329-476e-9003-94f4765e8080"), "Black", new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb") },
                    { new Guid("eff95cf4-5ef0-4863-8e17-9ea36730c945"), "Blue", new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3") },
                    { new Guid("f1d480df-d881-45e7-9e98-df271415eb15"), "Black", new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d") },
                    { new Guid("f6515f41-0326-4846-ac1b-ed7fef60e94f"), "Blue", new Guid("bcc67668-9258-48b9-954e-7a87aac79171") },
                    { new Guid("fbe96248-4d5e-40df-8b1c-931af707dd32"), "Black", new Guid("58eb3939-9946-4d0c-b168-d04bb739699b") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("0168358f-3fe9-4760-896c-0c28c680ca7c"), 82, new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3"), 42 },
                    { new Guid("04e4fb57-b596-466a-973d-d6e3792c4d70"), 23, new Guid("12898a90-7645-4f19-b548-6da58618f253"), 39 },
                    { new Guid("05c5bf96-d095-4944-a723-19c868265d73"), 2, new Guid("bcc67668-9258-48b9-954e-7a87aac79171"), 48 },
                    { new Guid("09703093-fbeb-4f8f-8dae-273a9a3380d4"), 18, new Guid("8d704b3c-9f76-4127-a342-4850fae21948"), 44 },
                    { new Guid("098cf0d5-5883-4cea-a733-8df1eb87fa5c"), 38, new Guid("2ae15ce3-5df0-4772-8125-5421a563b688"), 44 },
                    { new Guid("0c5d29ea-b207-47ca-b811-29feeeb34534"), 104, new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d"), 38 },
                    { new Guid("0d6a12f3-ef0a-4294-856f-433f81197027"), 141, new Guid("6219b616-ae80-42d8-afa2-4aba5279734b"), 39 },
                    { new Guid("0e587ddf-59d0-433e-a3c9-44d59c5fd453"), 32, new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea"), 37 },
                    { new Guid("0fc1fa09-326b-4ebd-9126-3c5bf42b9b29"), 101, new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e"), 39 },
                    { new Guid("107d263b-8a8c-4edc-8e2c-7e57dba03627"), 115, new Guid("12898a90-7645-4f19-b548-6da58618f253"), 40 },
                    { new Guid("11fa667e-eaa0-4a72-ae35-7ed58a1dbad2"), 94, new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c"), 41 },
                    { new Guid("17c540f4-d973-4435-8e38-523b4fc7fa21"), 5, new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c"), 43 },
                    { new Guid("186dd533-1bc0-4c5d-afe7-f11cd85f7f3f"), 37, new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3"), 43 },
                    { new Guid("196abab0-4ef1-45d9-b3a9-25faf80d8e31"), 44, new Guid("bcc67668-9258-48b9-954e-7a87aac79171"), 47 },
                    { new Guid("1b6ff11e-8591-43f9-803a-6aaad3f9111a"), 65, new Guid("23615a39-528a-4625-8e26-7ef6231aba4a"), 41 },
                    { new Guid("1b8322a6-e77e-48ca-b6d9-324d52d80058"), 41, new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d"), 42 },
                    { new Guid("1d8b1dfc-f906-46d5-87c3-4fd906cb8c37"), 142, new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3"), 39 },
                    { new Guid("1e6158c2-dec4-4cf6-b0ef-93ff51f72f2e"), 126, new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5"), 42 },
                    { new Guid("1f00e5d1-afc8-4823-97e9-cc81990e07ea"), 118, new Guid("8d704b3c-9f76-4127-a342-4850fae21948"), 45 },
                    { new Guid("1f6c289b-eedd-4bfe-b3d0-848aef5e05b2"), 147, new Guid("6219b616-ae80-42d8-afa2-4aba5279734b"), 41 },
                    { new Guid("1f6ffc14-dedf-4641-8f99-6c50aff331c3"), 44, new Guid("6219b616-ae80-42d8-afa2-4aba5279734b"), 38 },
                    { new Guid("2506b822-35b8-432a-b966-229a04d83ff7"), 65, new Guid("df78e5ac-10a6-4b40-847e-657a873e657c"), 47 },
                    { new Guid("253d1e5b-1efe-4015-a2f0-49988ab3bfe6"), 70, new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea"), 38 },
                    { new Guid("2d2992d1-5114-484c-9bb9-c2e4d59d177d"), 17, new Guid("8d704b3c-9f76-4127-a342-4850fae21948"), 43 },
                    { new Guid("33798a80-eac2-471a-9194-ebdd1fa7daf8"), 16, new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada"), 36 },
                    { new Guid("35e9c6c5-4808-4a5f-9501-d7ca5782064d"), 14, new Guid("2ae15ce3-5df0-4772-8125-5421a563b688"), 45 },
                    { new Guid("3c43a5eb-1b30-448c-9661-22b801247a14"), 112, new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3"), 42 },
                    { new Guid("3cbb2b8e-aca1-4c1c-9db2-bd254b43fbfb"), 36, new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3"), 40 },
                    { new Guid("3ff7da26-3344-4f81-9ff9-48faf3796f68"), 31, new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615"), 41 },
                    { new Guid("4007b5cb-87bc-4916-9d43-c42c2b465f19"), 51, new Guid("23615a39-528a-4625-8e26-7ef6231aba4a"), 42 },
                    { new Guid("40cda2d7-c563-4027-8398-311dae6ab072"), 70, new Guid("2ae15ce3-5df0-4772-8125-5421a563b688"), 42 },
                    { new Guid("41a21cd5-3ea0-4e59-a847-505359acfb2d"), 36, new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3"), 41 },
                    { new Guid("420b6692-862a-4d8d-afbd-11e1af3e7318"), 145, new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d"), 41 },
                    { new Guid("42675009-5136-4587-9f3a-4a33f2367676"), 94, new Guid("58eb3939-9946-4d0c-b168-d04bb739699b"), 36 },
                    { new Guid("4350b8d5-d5e1-4026-8e79-426f32c1577d"), 21, new Guid("bbd74e81-d305-4413-bdb2-a475989b676e"), 36 },
                    { new Guid("43ce14f3-0eae-47b0-a393-b9dd52f921b4"), 30, new Guid("bcc67668-9258-48b9-954e-7a87aac79171"), 49 },
                    { new Guid("46543425-d635-493b-a343-6b4fdb98f2e7"), 6, new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea"), 36 },
                    { new Guid("4a6ad583-299b-40a7-89c8-571980a9be01"), 29, new Guid("ca72c85b-3a76-48a9-b773-a4d9f703deb3"), 40 },
                    { new Guid("4c7aa82d-2007-4cfb-bced-93546dbcbbd3"), 5, new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d"), 41 },
                    { new Guid("4cf611d1-45c0-48b9-b231-1650d84c14c4"), 27, new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29"), 41 },
                    { new Guid("53178f3a-fce1-4214-b2e4-1df125615eac"), 123, new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994"), 40 },
                    { new Guid("54a09443-1a9e-473e-9174-5388f8ea7993"), 19, new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3"), 40 },
                    { new Guid("56103448-88bc-497e-ae22-f6c06112af26"), 136, new Guid("58eb3939-9946-4d0c-b168-d04bb739699b"), 40 },
                    { new Guid("565d44d4-5675-49f0-aff2-01eea97bc53f"), 87, new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06"), 41 },
                    { new Guid("60e4d8cc-a4f8-4199-973e-cca5d48857be"), 96, new Guid("12898a90-7645-4f19-b548-6da58618f253"), 41 },
                    { new Guid("65f4ebcc-553a-4d9f-a7ec-5fb82c3afa15"), 33, new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615"), 43 },
                    { new Guid("665a7400-1df3-423e-a119-5be3be2b4762"), 68, new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d"), 39 },
                    { new Guid("666c2b0c-2489-4b3c-8fd7-8b068efa378b"), 14, new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c"), 41 },
                    { new Guid("683d0d07-46ab-4e54-b1a1-0245fcda9fac"), 91, new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e"), 38 },
                    { new Guid("6ae58fa5-c2a4-4067-8e54-4d65e6538ea6"), 43, new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb"), 39 },
                    { new Guid("6cc729fe-608c-4f0f-846b-02787506ce4a"), 126, new Guid("8d704b3c-9f76-4127-a342-4850fae21948"), 42 },
                    { new Guid("6d4dc6f1-3d7d-4b33-b236-fbd4eaf96d97"), 76, new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994"), 38 },
                    { new Guid("6ef0e9ac-a817-4b37-953a-46d0fc2f2e81"), 40, new Guid("df78e5ac-10a6-4b40-847e-657a873e657c"), 49 },
                    { new Guid("6f1fe661-d177-48a7-99e1-a627c27c1a94"), 119, new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e"), 41 },
                    { new Guid("6fc16575-0d00-4708-a6f7-38ba354862d7"), 100, new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615"), 44 },
                    { new Guid("728cae8d-8ab6-4c12-a786-80e0211dac45"), 144, new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c"), 42 },
                    { new Guid("787260f1-4694-4ec7-b9e1-07d3eb94b771"), 146, new Guid("2ae15ce3-5df0-4772-8125-5421a563b688"), 43 },
                    { new Guid("79f1660a-efb6-4657-954d-92a8c8721221"), 122, new Guid("881d695e-24da-4f84-9419-6a75e9d6114f"), 41 },
                    { new Guid("7cddcd48-91d5-4fbe-9464-92be5f503c58"), 88, new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d"), 44 },
                    { new Guid("7fe582ec-b567-42d8-bb15-412fa1cf908b"), 20, new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c"), 43 },
                    { new Guid("83249e97-0bd9-4312-92e2-14e1b10574c7"), 35, new Guid("df78e5ac-10a6-4b40-847e-657a873e657c"), 46 },
                    { new Guid("873218f9-a42b-4e2b-9d76-15045e5c37a7"), 11, new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3"), 41 },
                    { new Guid("885626b5-59ed-4bea-9d2d-cc13d518d186"), 81, new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d"), 41 },
                    { new Guid("887d72db-751e-4744-b5eb-2c9daa4157c7"), 41, new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3"), 42 },
                    { new Guid("8b602d71-1964-4abc-aafb-393352f6c432"), 125, new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c"), 42 },
                    { new Guid("8cd408f6-ad10-4cf3-a19c-1916d4380404"), 143, new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb"), 41 },
                    { new Guid("8cf3749d-1e62-4f92-9311-59f0d302403f"), 13, new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3"), 41 },
                    { new Guid("8d78591a-b7d0-42c6-9434-b06b29bc83cf"), 141, new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5"), 45 },
                    { new Guid("8e5ee2de-07b5-447c-80f8-6b6c3d898a44"), 117, new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e"), 40 },
                    { new Guid("93909eae-c709-45cb-9682-3af8082b4a5b"), 81, new Guid("d30e7f9a-3ae8-4461-8e98-b4cd2065fea3"), 43 },
                    { new Guid("9390e850-8fee-4392-bac3-86bef603e7a3"), 25, new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada"), 39 },
                    { new Guid("95c49819-41d4-4453-9d6b-ef5d66f922c3"), 114, new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29"), 40 },
                    { new Guid("972681b8-2c81-4a1e-88b9-18fd551adae8"), 67, new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d"), 40 },
                    { new Guid("975bb5db-7ba5-4ef9-843d-9c25008bbf63"), 135, new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994"), 41 },
                    { new Guid("97913ed1-c6a1-4ae8-8923-d5648cce3922"), 39, new Guid("881d695e-24da-4f84-9419-6a75e9d6114f"), 43 },
                    { new Guid("9bab059a-4ed2-4f30-af65-26b10a763090"), 47, new Guid("2703d435-daf4-40ec-bd9e-c875f0e60c3d"), 40 },
                    { new Guid("9ec4d733-ba07-4c12-be7f-3b19f767e2f7"), 48, new Guid("a152d553-2f9e-47e8-b830-37bf90686d3e"), 42 },
                    { new Guid("9f2d20a4-38c1-4340-8ab9-ab37e6ae858e"), 148, new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada"), 37 },
                    { new Guid("a3e0a38a-f39e-4150-afbe-78ba8fd5eca0"), 35, new Guid("23615a39-528a-4625-8e26-7ef6231aba4a"), 39 },
                    { new Guid("a54eff6a-4382-431b-8d97-b030755ba29e"), 29, new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29"), 42 },
                    { new Guid("a5689196-19d6-4b88-9e88-f1ff6eda8334"), 144, new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada"), 38 },
                    { new Guid("a6347939-e562-4657-8519-00122910e7b5"), 54, new Guid("acffb9e9-1fa4-4e0f-89f1-aa914ff0676c"), 40 },
                    { new Guid("a78d907c-ab0a-4ed3-9588-bceb994d6fdb"), 137, new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29"), 39 },
                    { new Guid("a8d0043e-6a9f-4d31-ba58-d00aeba2c13d"), 22, new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d"), 43 },
                    { new Guid("a8f94712-8802-4d11-8607-c93446e71a77"), 11, new Guid("8fb12a67-51af-49b2-9c63-4eb95b10dada"), 40 },
                    { new Guid("abeb3da1-3242-40b1-aae9-871002139008"), 1, new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06"), 43 },
                    { new Guid("acd71ff5-b5c8-45c7-9250-a4943ddff703"), 79, new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb"), 38 },
                    { new Guid("adcb63f5-74d3-4f28-a732-557d876458e4"), 127, new Guid("0431a0a2-c866-452a-8efc-eeab951b2056"), 40 },
                    { new Guid("b4339434-f18b-4b92-a04c-6eb0f45b23b3"), 136, new Guid("12898a90-7645-4f19-b548-6da58618f253"), 38 },
                    { new Guid("b602e86b-0d73-44f9-87d0-1e4c84e13068"), 138, new Guid("0775ddd7-34ea-4fa0-b5e0-de43a42ea13d"), 42 },
                    { new Guid("b6572605-490f-41d2-8b9b-b105d6d5ff94"), 72, new Guid("6219b616-ae80-42d8-afa2-4aba5279734b"), 40 },
                    { new Guid("b79c6d24-a6e7-42fe-af6c-7ea25d31f043"), 26, new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3"), 41 },
                    { new Guid("b97b6f73-9045-4336-9e39-0a86885c5acb"), 75, new Guid("df78e5ac-10a6-4b40-847e-657a873e657c"), 48 },
                    { new Guid("b9a905b4-1c24-4cf8-bebb-0a873bc69c56"), 73, new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06"), 40 },
                    { new Guid("c06a06a7-340f-4fa0-96c2-cce3f927ff46"), 25, new Guid("58eb3939-9946-4d0c-b168-d04bb739699b"), 39 },
                    { new Guid("c46dc669-57e9-44ed-a7a6-84d420a12f2c"), 99, new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5"), 43 },
                    { new Guid("c68ab5c3-cb2b-4b33-b356-b016d9295ee0"), 112, new Guid("2313fe66-c1be-4cc5-bb1b-5e8b244598d5"), 44 },
                    { new Guid("c76b2b8f-d265-4af6-b23b-28d9e49051d5"), 93, new Guid("bbd74e81-d305-4413-bdb2-a475989b676e"), 37 },
                    { new Guid("c8b96c55-1c65-49ff-b198-cc6c925f31f7"), 148, new Guid("881d695e-24da-4f84-9419-6a75e9d6114f"), 40 },
                    { new Guid("ca67f616-5729-436e-a51e-e20303ec3ef4"), 53, new Guid("881d695e-24da-4f84-9419-6a75e9d6114f"), 42 },
                    { new Guid("ca83c955-1d78-4502-bebe-16010d676193"), 112, new Guid("6219b616-ae80-42d8-afa2-4aba5279734b"), 37 },
                    { new Guid("cc650e42-0f71-4047-b1b8-1f6cde66705d"), 86, new Guid("df78e5ac-10a6-4b40-847e-657a873e657c"), 45 },
                    { new Guid("d0636c19-44c5-49f6-8065-fd139d3e1efc"), 27, new Guid("7583550c-b690-43d4-96dd-cd1ed35ee42d"), 39 },
                    { new Guid("d198cf55-8bd1-45e0-8e81-93c1a468b9e5"), 29, new Guid("e7e0f3b3-0d34-4821-bf92-f35dad016994"), 39 },
                    { new Guid("d4d00fb9-ee8f-4943-ace8-dcc26157e19e"), 44, new Guid("bbd74e81-d305-4413-bdb2-a475989b676e"), 39 },
                    { new Guid("d77b14c5-6f29-4502-8842-db82b246700d"), 149, new Guid("0431a0a2-c866-452a-8efc-eeab951b2056"), 38 },
                    { new Guid("d84cdeb5-636d-458f-abe0-7b6ecc1873d3"), 141, new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3"), 40 },
                    { new Guid("d896d7c0-5401-4670-abd8-283e3a75e940"), 126, new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c"), 40 },
                    { new Guid("dc4e6bbb-d0a1-41d9-8d0f-a753f90c26b6"), 68, new Guid("2fc159e0-a1fd-46bd-8b96-8dacd3e2c22c"), 44 },
                    { new Guid("dce8b0d3-e0f7-488a-ba92-db0f6b48d402"), 102, new Guid("12898a90-7645-4f19-b548-6da58618f253"), 37 },
                    { new Guid("dd6f770b-a09e-4bae-965c-3be785b5ecc4"), 95, new Guid("58eb3939-9946-4d0c-b168-d04bb739699b"), 37 },
                    { new Guid("e0b9af4b-44d9-4e15-acdb-fbb9fac0af9e"), 80, new Guid("991e5f9c-7845-4cb7-880c-3e34c7b7de06"), 42 },
                    { new Guid("e192d775-ac0e-472f-8156-3909a59f141e"), 45, new Guid("0431a0a2-c866-452a-8efc-eeab951b2056"), 39 },
                    { new Guid("e24dedec-6282-4113-82bb-01b4de808d3f"), 110, new Guid("793a13fe-9ce3-4f9f-91b1-ae33c41b9ef3"), 43 },
                    { new Guid("e477ff6e-996f-4b1f-83af-b573e0ab41ab"), 104, new Guid("c40a4a37-2cfc-43f8-a040-e3da328793eb"), 40 },
                    { new Guid("e5af95ec-b722-45d5-afed-904619a89df4"), 61, new Guid("bcc67668-9258-48b9-954e-7a87aac79171"), 45 },
                    { new Guid("e727a0e3-5be3-4c02-87cf-2bcfdc79ffa3"), 87, new Guid("2ae15ce3-5df0-4772-8125-5421a563b688"), 41 },
                    { new Guid("e954a240-57b3-4c12-864b-77ab9c920a98"), 20, new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea"), 39 },
                    { new Guid("ec4c6467-39e4-4726-bec4-832a8308094f"), 139, new Guid("23615a39-528a-4625-8e26-7ef6231aba4a"), 40 },
                    { new Guid("ecc1491d-0250-4e17-9b45-5d9554b36be3"), 83, new Guid("0431a0a2-c866-452a-8efc-eeab951b2056"), 37 },
                    { new Guid("f15d8e97-0d10-4cc3-9502-00850ba768d2"), 104, new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3"), 42 },
                    { new Guid("f53938c4-3e4e-46cd-b903-e4015e7de1eb"), 83, new Guid("97bd194d-bf4f-4f34-8537-309b003ea6ea"), 40 },
                    { new Guid("f6051d3d-9cca-454f-86b0-2523aa5c1f96"), 73, new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3"), 39 },
                    { new Guid("f7f10fe7-7448-42b3-b40b-fdffb7236284"), 126, new Guid("3ee2a13c-54a2-4dbf-b5b5-98fdffb8b9e3"), 43 },
                    { new Guid("f849ee9d-04d8-4c05-9275-71d65ac132d2"), 43, new Guid("57068ea0-8cf7-4a41-816b-0fadf5bdcf29"), 38 },
                    { new Guid("f87e2ad0-a673-4a64-934b-1367dfb7c3d2"), 28, new Guid("58eb3939-9946-4d0c-b168-d04bb739699b"), 38 },
                    { new Guid("f9cd0a74-e2ea-43fa-bcc3-a26f1f8900bd"), 69, new Guid("bbd74e81-d305-4413-bdb2-a475989b676e"), 38 },
                    { new Guid("f9f90145-9a30-433c-8d1c-3c50d05e2df8"), 8, new Guid("bcc67668-9258-48b9-954e-7a87aac79171"), 46 },
                    { new Guid("fce70dae-d343-445c-8fd8-28c5971d0290"), 136, new Guid("d721fd62-66c7-44e4-ad99-9358c2c51615"), 42 }
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
