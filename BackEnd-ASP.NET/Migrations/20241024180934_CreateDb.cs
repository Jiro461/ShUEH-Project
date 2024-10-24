using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEnd_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
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
                    { new Guid("1a60c76f-7e73-4c64-a43c-9e2e4cbe9e19"), "Role Admin với đầy đủ các quyền hạn", "Admin" },
                    { new Guid("50201422-a8b8-4bb2-b39a-8f5b0186d0d7"), "Role User với các quyền hạn có giới hạn và mua hàng", "User" }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "AverageRating", "Brand", "Category", "CreateDate", "Description", "Discount", "Gender", "ImageUrl", "IsSale", "LastModifiedDate", "Material", "Name", "Price", "Sold", "TotalRatings" },
                values: new object[,]
                {
                    { new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), 4.4m, "Adidas", "Football", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4339), "The game's all about goals, and these football boots are crafted to find the net. Every. Time. Target perfection in all-new adidas Predator. With a textured finish on the outside and a foot-hugging fit on the inside, the synthetic upper looks and feels the part. Sitting underneath, a lug rubber outsole ensures you're always in the perfect position to take aim.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 15.0m, 1, "images/shoes/[IDGiay_7]_AnhChinh.png", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4340), "Leather, fabric, and rubber.", "Predator Club Sock Turf Football Boots", 1600000m, 44, 37 },
                    { new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b"), 7m, "Nike", "Basketball", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4637), "The seventy returned with joy, saying, “Lord, even the demons are subject to us in your name!”\r\n\r\n18 And he said to them,“I saw Satan fall like lightning from heaven.\r\n\r\n24 Behold, I have given you authority to tread on serpents and scorpions, and over all the power of the enemy, and nothing shall hurt you.\r\n\r\n20 Nevertheless do not rejoice in this, that the spirits are subject to you; but rejoice that your names are written in heaven.”", 0.0m, 1, "images/shoes/[IDGiay_26]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4638), "Leather, fabric, foam, and rubber.", "Satan ", 10460000m, 7, 5 },
                    { new Guid("13694ddb-95e1-40b7-911c-741620c6d808"), 4.7m, "Adidas", "Basketball", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4360), "From the moment he first stepped onto the hardwood, Donovan Mitchell has been a game changer, and that's continued even as his game has grown and evolved. These D.O.N. Issue 6 Signature shoes from adidas Basketball continue to build on Spida's on-court persona as well as his off-court social activism. Riding an ultra-lightweight Lightstrike midsole and a unique rubber outsole with an elevated traction pattern, these basketball trainers help you dominate the game just like one of the sport's very best.", 0.0m, 1, "images/shoes/[IDGiay_10]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4361), "Leather, fabric, foam, and rubber.", "D.O.N. Issue 6 Shoes", 3200000m, 23, 3 },
                    { new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), 4.4m, "Adidas", "Gym & Training", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4345), "Whether the workout calls for power or endurance, these adidas shoes offer the support you need for strength training. A dual-density midsole keeps feet stable through heavy lifts, while remaining flexible enough for cardio. HEAT.RDY and a breathable upper work overtime to beat the heat, so you can focus on the reps. A wide fit accommodates swelling feet, and an Adiwear outsole grips the floor to drive performance.\r\n\r\nThis product features at least 20% recycled materials. By reusing materials that have already been created, we help to reduce waste and our reliance on finite resources and reduce the footprint of the products we make.", 0.0m, 2, "images/shoes/[IDGiay_8]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4346), "Leather, fabric, foam, and rubber.", "Dropset 3 Shoes", 3500000m, 120, 84 },
                    { new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), 4.8m, "Reebok", "Basketball", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4588), "Inspired by the 1996 Mobius collection, these Reebok shoes evoke a modern approach to a blast from the past. Their flashy, asymmetrical look is created by the contrast between yin and yang lighting, so your left shoe looks different from the right shoe. Wear them and show everyone that OG spirit.\r\n", 0.0m, 1, "images/shoes/[IDGiay_19]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4589), "Leather, fabric, foam, and rubber.", "Unisex Reebok The Blast", 3990000m, 134, 111 },
                    { new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09"), 4.0m, "Puma", "Basketball", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4366), "Run like an intergalactic MVP in the MB.03 Halloween. NITRO™ foam rockets energy return with each explosive step, while the space-age woven upper lets breathability blast off. Scratch cutouts and slime soles complete the Melo world trip. Get ready for lift-off.", 0.0m, 1, "images/shoes/[IDGiay_11]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4367), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PUMA x LAMELO BALL MB.03 Halloween Men's Basketball Shoes", 3300000m, 32, 21 },
                    { new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), 4.8m, "Adidas", "Basketball", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4331), "Get ready for what's next. This iteration of the signature shoes from Trae Young and adidas Basketball is all about the future of the game. Celebrating Trae's unique look, crowd-pleasing bravado and expressive, futuristic style of play, these shoes are built for optimised motion and stability, two elements of Trae's game that have elevated him to superstar status. The midsole ensures your most explosive moves can be done at top speed while a rubber outsole adds support on hard plants and cuts.", 0.0m, 1, "images/shoes/[IDGiay_6]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4332), "Leather, fabric, foam, and rubber.", "TRAE YOUNG 3 BASKETBALL SHOES", 4200000m, 456, 381 },
                    { new Guid("50f984a0-2219-42e4-ae0a-dfaeea10f70b"), 4.6m, "Nike", "Basketball", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4643), "One of the best shoes for basketball and the symbol of Nike's World. You won't be able to take your eyes off of this brand new Jordan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4644), "Leather, fabric, foam, and rubber.", "Jordan 1 Low Bred Toe 2.0", 1813000m, 45, 23 },
                    { new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), 4.1m, "Puma", "Yoga", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4388), "The PUMA Easy Rider was born in the late ‘70s, when running made its move from the track to the streets. Today it's back with its classic", 0.0m, 2, "images/shoes/[IDGiay_14]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4389), "Midsole: 100% Rubber\r\nSockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 68.19% Leather - cow, 31.81% Textile\r\nLining: 100% Textile.", "Easy Rider Supertifo Women's Sneakers", 2300000m, 65, 22 },
                    { new Guid("58e70527-c353-41dc-9b20-fc105551f412"), 4.2m, "Nike", "Tennis", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4314), "The NikeCourt Legacy serves up style rooted in tennis culture. They are durable and comfy with heritage stitching and a retro Swoosh. When you pull these on—it's game, set, match.", 30.0m, 1, "images/shoes/[IDGiay_4]_AnhChinh.png", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4315), "Leather, fabric, and rubber.", "NikeCourt Legacy", 1279000m, 7, 5 },
                    { new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835"), 4.7m, "Nike", "Basketball", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4296), "Ready to zigzag across the court with ease? Start by lacing up the Nike G.T. Cut 3. Made for a new generation of players, its advanced traction helps give you the grip you need to shake, stop and cross up defenders as you fly to the hoop. The light and springy foam helps cushion every step so you can cut and create space in comfort. Plus, getting game-ready is easy with the wide collar opening—just grab the loops to pull these on and lace 'em up. This is the future of hoops.", 15.0m, 1, "images/shoes/[IDGiay_2]_AnhChinh.png", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4297), "Leather, fabric, foam, and rubber.", "Nike G.T. Cut 3", 2419000m, 50, 45 },
                    { new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), 4.3m, "Converse", "Gym & Training", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4602), "Meet the Run Star Trainer—a celebration of sports, style, and heritage. Sleek details and luxe cushioning pair well with all your favorite 'fits, day and night. The next step in the Star Chevron legacy is here.\r\n\r\nFeatures And Benefits\r\nA durable nylon upper with suede overlays and leather accents for a luxe look and feel\r\nCX foam cushioning helps provide next-level comfort\r\nTraction rubber outsole helps provide grip\r\nPunched eyelets and waxed laces add a premium touch\r\nIconic Star Chevron, All Star, and Converse logos", 0.0m, 1, "images/shoes/[IDGiay_21]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4603), "Leather, fabric, foam, and rubber.", "Run Star Trainer", 1900000m, 20, 10 },
                    { new Guid("68cf9eff-eefb-4c20-9642-94ee9bf08fc8"), 4.7m, "Puma", "Football", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4658), "One of the best shoes for football and the symbol of Puma's World. You won't be able to take your eyes off of this brand new FUTURE, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4658), "Leather, fabric, foam, and rubber.", "Puma FUTURE 7 Ultimate FG/AG The Forever Faster", 2713000m, 78, 55 },
                    { new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249"), 4.9m, "Nike", "Yoga", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4323), "You bring the speed. We'll bring the stability. The Luka 2 is built to support your skills, with an emphasis on stepbacks, side-steps and quick-stop action. A stacked midsole features firm, flexible cushioning for added responsiveness as you shift back and forth on the court. Up top, the full-foot wrapped cage design helps you stay contained whether you're faking out a defender or driving down the lane. With all that tech in a lightweight package, we've got efficiency covered. The rest is up to you.", 30.0m, 2, "images/shoes/[IDGiay_5]_AnhChinh.png", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4324), "Leather, fabric, foam, and rubber.", "Luka 2", 1784299m, 89, 66 },
                    { new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), 4.5m, "Puma", "Gym & Training", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4381), "Hit the bike, locked in and ready to dominate your workout with the PWRSPIN indoor cycling shoes. They contain a lightweight upper with our performance ULTRAWEAVE fabric, which will help your feet breathe. Then, the DISC closure and PWRPLATE carbon fibre plate with a delta closure will ensure your feet are secure for a hard training session.\r\n4D PWRPRINT over ULTRAWEAVE upper\r\nKnitted collar construction\r\nDISC technology closure\r\nHook-and-loop closure\r\nPWRPLATE with delta clip on heel\r\nFuturistic heel fin design\r\n", 0.0m, 1, "images/shoes/[IDGiay_13]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4382), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 98.30% Rubber, 1.70% Synthetic\r\nUpper: 69.50% Textile, 30.50% Synthetic\r\nLining: 100% Textile", "PWRSPIN Indoor Cycling Shoes", 2900000m, 54, 23 },
                    { new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), 4.4m, "Converse", "Basketball", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4615), "Express your personal style with a pair of shoes from Converse. Our range of shoes and trainers are built for ultimate comfort and timeless street style. With a stylish and iconic silhouette, Converse offers a wide variety of shoes to suit your personality.\r\n\r\nThere may be a 1-2cm difference in measurements depending on the development and manufacturing process.", 20.0m, 1, "images/shoes/[IDGiay_23]_AnhChinh.png", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4616), "Leather, fabric, foam, and rubber.", "Converse x OLD MONEY Weapon\r\n", 2170000m, 56, 34 },
                    { new Guid("976b2fc3-97a6-4de0-a974-fff0e9880f6c"), 4.2m, "Adidas", "Basketball", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4650), "One of the best shoes for basketball and the symbol of Adidas's World. You won't be able to take your eyes off of this brand new SuperStan, where every details have been scopefully arted.", 20.0m, 1, "images/shoes/noimage.webp", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4651), "Leather, fabric, foam, and rubber.", "Adidas Original StanSmith", 1713000m, 65, 33 },
                    { new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), 4.7m, "Reebok", "Basketball", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4595), "Designed for versatile workouts\r\n\r\nProduct Code GZ1400\r\n\r\nThe shoe body is made of soft leather for a comfortable feel\r\n\r\nThe EVA midsole provides lightweight cushioning and shock absorption. The ICE outsole offers abrasion resistance and durability.", 0.0m, 2, "images/shoes/[IDGiay_20]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4596), "Leather, fabric, foam, and rubber.", "QUESTION LOW", 3590000m, 22, 10 },
                    { new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4609), "Take on unpredictable city terrain in low-tops that boast reliable comfort and style. Traction tread means durability and better grip for your power walk, while the suede heel brings a fashion-forward edge. Plus, CX foam cushioning helps keep your steps comfortable for your midtown-to-downtown strut.\r\n\r\nFeatures And Benefits\r\nLow-top shoe with a canvas upper\r\nCX foam helps provide next-level comfort\r\nSuede heel overlay and heel pulls for easy on and off\r\nTraction outsole and rubber toe bumper for added durability\r\nPrinted utility-inspired graphic on the heel", 0.0m, 1, "images/shoes/[IDGiay_22]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4610), "Leather, fabric, foam, and rubber.", "Chuck 70 AT-CX", 2500000m, 67, 45 },
                    { new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777"), 4.3m, "Reebok", "Tennis", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4581), "Club C 85 S29074 is a retro style leather walking sneaker.\r\nLow-cut shoes help you score points with delicate beauty. Enjoy comfort with a lightly padded midsole that cushions your feet as you move. A delicate embroidered logo enhances the look for a casual yet sophisticated style. Lightweight molded rubber sole with high abrasion resistance and grip.", 0.0m, 2, "images/shoes/[IDGiay_18]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4582), "Leather, fabric, foam, and rubber.", "Club C 85", 1990000m, 35, 12 },
                    { new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), 4.6m, "Adidas", "Gym & Training", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4353), "The feel of the barbell in your hands, the clang of the plates, the ring of the PR bell. Nothing beats a great lifting day, and these adidas training shoes provide outstanding performance during your Strength Training sessions. The 6 mm midsole drop gives you a flat and stable platform and helps you find proper alignment in all your lifts. The dual-density midsole provides comfort and controlled stability, and a grippy Traxion outsole keeps your footing secure.\r\n\r\nMade with a series of recycled materials, this upper features at least 50% recycled content. This product represents just one of our solutions to help end plastic waste.", 30.0m, 1, "images/shoes/[IDGiay_9]_AnhChinh.png", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4354), "Leather, fabric, foam, and rubber.", "Dropset 2 Trainer", 2450000m, 390, 268 },
                    { new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5"), 4.9m, "Converse", "Gym & Training", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4622), "90S REMIX\r\n\r\nWant some '90s flair? Throw on this Weapon that pays homage to our basketball and skate shoes from that era. A durable, leather upper in retro colors gives it the look of a pre-Y2K favorite.\r\n\r\nFeatures And Benefits\r\n Leather and nubuck upper, with that classic Weapon look\r\n CX cushioning helps provide next-level comfort\r\n Flat cotton laces offer durability\r\n Iconic, woven All Star tongue label reps the legacy", 10.0m, 2, "images/shoes/[IDGiay_24]_AnhChinh.png", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4623), "Leather, fabric, foam, and rubber.", "Weapon", 2500000m, 156, 100 },
                    { new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c"), 4.2m, "Puma", "Football", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4372), "A simple, no-nonsense cleat built to meet your demands on the pitch, the ATTACANTO is built with a soft upper for enhanced touch and ball", 30.0m, 1, "images/shoes/[IDGiay_12]_AnhChinh.png", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4373), "Sockliner: 100% Textile\r\nOutsole: 100% Rubber\r\nUpper: 99.44% Synthetic, 0.56% Textile\r\nLining: 100% Textile", "ATTACANTO Turf Training Men's Soccer Cleats", 1800000m, 76, 17 },
                    { new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a"), 4.8m, "Nike", "Football", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4306), "Serious about your game? Wanna run fast so you can score goals? The Jr. Vapor 16 Pro has an improved heel Air Zoom unit to help you flash your speed. It gives you and those devoted to the game the propulsive feel needed to break through the back line. Take your skills to the next level with some of Nike's greatest innovations like Flyknit on the upper, which makes the boot even lighter so you can play fast.", 0.0m, 1, "images/shoes/[IDGiay_3]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4307), "Leather, fabric and rubber.", "Jr. Mercurial Vapor 16 Pro", 4109000m, 13, 10 },
                    { new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), 4.5m, "Reebok", "Gym & Training", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4403), "Whether you're new to the gym or already know how to lift weights, these Reebok men's training shoes are designed to help you reach your fitness goals. The breathable and lightweight mesh upper keeps your feet comfortable while built-in support provides stability during box jumps and all-day activity. The rubber outsole features lateral wraps for durability and traction whether indoors or outdoors, with forefoot grooves to provide flexibility when needed.", 0.0m, 1, "images/shoes/[IDGiay_16]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4404), "Leather, fabric, foam, and rubber.", "Reebok NFX Trainer", 2490000m, 30, 25 },
                    { new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), 4.7m, "Puma", "Gym & Training", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4396), "Get going in comfort and style. SOFTRIDE Divine running shoes deliver an ultra-cushioned ride and bold styling. SOFTRIDE and SOFTFOAM+ technologies provide step-in comfort and shock absorption so you can run further in bliss. Zoned rubber traction lets you pick up the pace on any road.\r\n\r\nFEATURES & BENEFITS\r\n", 40.0m, 2, "images/shoes/[IDGiay_15]_AnhChinh.png", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4397), "Midsole: 100% Synthetic\r\nSockliner: 100% Textile\r\nOutsole: 81.10% Rubber, 18.90% Synthetic\r\nUpper: 52.47% Textile, 40.66% Synthetic, 6.87% Leather - cow\r\nLining: 100% Textile", "SOFTRIDE Divine Running Shoes Women", 1750000m, 123, 87 },
                    { new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), 4.5m, "Nike", "Gym & Training", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4268), "On any given night, Giannis can impact a game from any position. Lace up his latest signature shoe and leave your own mark, whatever the playing surface. Grippy traction and 2 layers of foam underfoot help you lock into a game and feel your best while you play. Lightweight and breathable material on top helps make the Immortality 4 a comfortable go-to whether you're shooting hoops with friends or securing a win with your team.\r\n\r\n", 0.0m, 1, "images/shoes/[IDGiay_1]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4288), "Leather, fabric, foam, and rubber.", "Giannis Immortality 4", 1909000m, 28, 20 },
                    { new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8"), 4.7m, "Converse", "Yoga", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4629), "Nothing combines '90s-inspired edge and everyday comfort like the ultra-lightweight Chuck Taylor All Star Cruise. Add fresh colors to the mix, and you get a style that's ready to take on any adventure.\r\n\r\nFeatures And Benefits\r\nA lightweight, canvas-and-suede upper gives you that classic Chucks look\r\nOrthoLite cushioning helps provide optimal comfort\r\nFresh colors give your rotation a boost\r\nIconic Chuck Taylor All Star patch reps the legacy", 22.0m, 2, "images/shoes/[IDGiay_25]_AnhChinh.png", true, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4630), "Leather, fabric, foam, and rubber.", "Converse Cruise", 1520000m, 60, 30 },
                    { new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80"), 4.6m, "Reebok", "Tennis", new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4574), "This shoe is inspired by a combination of Y2K skateboarding style and Reebok DNA, with bold color choices and a striking contrasting solid rubber sole. Everything on these shoes is subtly \"exaggerated\", from the wider designed upper to the thicker and larger shoe laces. The label on the tongue is designed in the form of a special small pocket.\r\n", 0.0m, 1, "images/shoes/[IDGiay_17]_AnhChinh.png", false, new DateTime(2024, 10, 25, 1, 9, 30, 413, DateTimeKind.Local).AddTicks(4575), "Leather, fabric, foam, and rubber.", "Unisex Reebok Club C Bulc", 2690000m, 41, 20 }
                });

            migrationBuilder.InsertData(
                table: "ShoeImages",
                columns: new[] { "Id", "ShoeId", "Url" },
                values: new object[,]
                {
                    { new Guid("022fc4b0-f1e3-44c3-9b00-de95aebf215e"), new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), "images/shoes/[IDGiay_16]_AnhPhu_3.png" },
                    { new Guid("02eb7b0c-b8d9-49f0-887f-d62696fb5c67"), new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), "images/shoes/[IDGiay_23]_AnhPhu_4.jpg" },
                    { new Guid("0bb8769d-3213-41cd-afc0-cf2cc5f5cc20"), new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), "images/shoes/[IDGiay_23]_AnhPhu_2.jpg" },
                    { new Guid("0cbcc53d-bdec-46eb-88b2-f62d6df893ba"), new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), "images/shoes/[IDGiay_9]_AnhChinh.jpg" },
                    { new Guid("0d4e2260-af57-4178-9f76-452eac50f886"), new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), "images/shoes/[IDGiay_23]_AnhPhu_3.jpg" },
                    { new Guid("0f79115d-b7f8-4cf6-bed7-3e17f1e6bce1"), new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), "images/shoes/[IDGiay_15]_AnhPhu_1.jpeg" },
                    { new Guid("108c5425-3f49-499f-84b2-4d5fbf1f8b94"), new Guid("13694ddb-95e1-40b7-911c-741620c6d808"), "images/shoes/[IDGiay_10]_AnhPhu_2.jpg" },
                    { new Guid("11294fab-e66b-4641-b750-513ed86063dc"), new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), "images/shoes/[IDGiay_20]_AnhPhu_2.png" },
                    { new Guid("12348819-6067-4812-aef8-460a131888fa"), new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), "images/shoes/[IDGiay_16]_AnhChinh.png" },
                    { new Guid("14918062-4547-4e24-9a57-cc384c6d3718"), new Guid("13694ddb-95e1-40b7-911c-741620c6d808"), "images/shoes/[IDGiay_10]_AnhPhu_4.jpg" },
                    { new Guid("14fe1c2f-5801-4394-916f-f3cb44cbbb7f"), new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), "images/shoes/[IDGiay_9]_AnhPhu_1.jpg" },
                    { new Guid("15baff23-dcd4-4db5-b649-46aa742b2493"), new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), "images/shoes/[IDGiay_7]_AnhChinh.jpg" },
                    { new Guid("18a5630e-e36c-4ff1-9594-51a6ee94e00a"), new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), "images/shoes/[IDGiay_6]_AnhPhu_3.jpg" },
                    { new Guid("1a4ff8cd-bcd5-408f-a586-476dd19e1291"), new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a"), "images/shoes/[IDGiay_3]_AnhPhu_3.jpeg" },
                    { new Guid("1aba5493-210f-4f09-9454-aa0494ac9295"), new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), "images/shoes/[IDGiay_1]_AnhPhu_2.png" },
                    { new Guid("1bb6f3b5-8a92-4a6d-b3a0-222481b3493a"), new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777"), "images/shoes/[IDGiay_18]_AnhPhu_1.png" },
                    { new Guid("1d836c70-5a35-4de6-98a8-eb83571747a0"), new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), "images/shoes/[IDGiay_7]_AnhPhu_1.jpg" },
                    { new Guid("1f3ab83a-5e00-4315-9b3d-e37526b85c24"), new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8"), "images/shoes/[IDGiay_25]_AnhPhu_4.jpg" },
                    { new Guid("217c1389-6ecb-45ba-97c0-988371de928c"), new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), "images/shoes/[IDGiay_21]_AnhPhu_1.jpg" },
                    { new Guid("238174fa-c378-42af-ae50-62ea14a849ed"), new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), "images/shoes/[IDGiay_14]_AnhPhu_1.jpeg" },
                    { new Guid("23b98a41-3428-418f-9d65-5493a9369ff4"), new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b"), "https://i.pinimg.com/originals/c0/cf/d1/c0cfd1545f10c56793e888e991b60487.png" },
                    { new Guid("23d64d5f-6716-46ab-af70-5ad8ad77af36"), new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), "images/shoes/[IDGiay_20]_AnhPhu_4.png" },
                    { new Guid("26cc61aa-3130-458a-8d6b-e9532e7e177a"), new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), "images/shoes/[IDGiay_8]_AnhPhu_3.jpg" },
                    { new Guid("26d24e6a-afd2-44f4-a919-7bfc469917bc"), new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), "images/shoes/[IDGiay_9]_AnhPhu_4.jpg" },
                    { new Guid("27c4b0ec-be85-4f0b-bf8a-86a76620fbd4"), new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), "images/shoes/[IDGiay_8]_AnhPhu_4.jpg" },
                    { new Guid("2814251f-ea1f-4570-9853-643f1c6b7a3e"), new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), "images/shoes/[IDGiay_9]_AnhPhu_3.jpg" },
                    { new Guid("282ebcfb-bb58-4799-9618-4cdec9e99de3"), new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5"), "images/shoes/[IDGiay_24]_AnhPhu_3.jpg" },
                    { new Guid("287fba14-96a7-4416-bae8-262a921f13bf"), new Guid("50f984a0-2219-42e4-ae0a-dfaeea10f70b"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3rZPCUSKRHdQA5_g3YBJRdcmIf_6PpZcNZg&s" },
                    { new Guid("2a0975bd-2f8e-4f10-8ff7-4861a78d97b4"), new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), "images/shoes/[IDGiay_21]_AnhChinh.jpg" },
                    { new Guid("2a393b16-3a10-4a29-a0e8-724af1ac53a2"), new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), "images/shoes/[IDGiay_21]_AnhPhu_2.jpg" },
                    { new Guid("2cbbafc8-4f63-42ab-a4b3-ebed3f1a8330"), new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), "images/shoes/[IDGiay_19]_AnhPhu_3.png" },
                    { new Guid("2cea4302-e9fc-4fef-b4b4-fe10b9b294f5"), new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a"), "images/shoes/[IDGiay_3]_AnhPhu_2.jpeg" },
                    { new Guid("2cf2c62e-2ddd-4eb8-bb1f-353017582dd6"), new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), "images/shoes/[IDGiay_21]_AnhPhu_4.jpg" },
                    { new Guid("306a955f-5cdc-465b-93a2-2d6d147886d4"), new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a"), "images/shoes/[IDGiay_3]_AnhPhu_4.jpeg" },
                    { new Guid("33310b8d-a62a-4c36-9305-1afe789ff065"), new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249"), "images/shoes/[IDGiay_5]_AnhPhu_2.jpeg" },
                    { new Guid("348876c6-53d9-4eb4-b43a-19d48b7e0273"), new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5"), "images/shoes/[IDGiay_24]_AnhPhu_2.jpg" },
                    { new Guid("35988415-6ddf-494d-b79f-9f4d64016427"), new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835"), "images/shoes/[IDGiay_2]_AnhPhu_3.png" },
                    { new Guid("359a0c11-377e-4bb8-aeb2-2dd7e8869248"), new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), "images/shoes/[IDGiay_14]_AnhPhu_4.jpeg" },
                    { new Guid("37158b64-5667-4e11-b3fb-0b61f79fd944"), new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09"), "images/shoes/[IDGiay_11]_AnhPhu_3.png" },
                    { new Guid("371fd6dc-415e-434c-bbe3-9c8d381c47d5"), new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), "images/shoes/[IDGiay_23]_AnhPhu_1.jpg" },
                    { new Guid("394d2acd-313d-4462-89b1-feb8736bf603"), new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777"), "images/shoes/[IDGiay_18]_AnhPhu_2.png" },
                    { new Guid("39979bb2-3c54-411b-bdbb-e85d9d77ad35"), new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), "images/shoes/[IDGiay_6]_AnhChinh.jpg" },
                    { new Guid("3ac805e1-adcd-4050-91e4-9e9a4a7eb8d6"), new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), "images/shoes/[IDGiay_13]_AnhPhu_4.jpeg" },
                    { new Guid("3b479011-cd81-4d73-a349-559a024f7096"), new Guid("68cf9eff-eefb-4c20-9642-94ee9bf08fc8"), "https://thumblr.uniid.it/product/336262/a92a6cadc8a6.jpg?width=3840&format=webp&q=75" },
                    { new Guid("3ba01a39-36f3-44c1-9ef2-ead892e53338"), new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), "images/shoes/[IDGiay_7]_AnhPhu_3.jpg" },
                    { new Guid("40726f00-3e2e-436a-99b0-50336fa26f29"), new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249"), "images/shoes/[IDGiay_5]_AnhChinh.jpeg" },
                    { new Guid("40c6a7d4-8924-445f-b644-ee8853ff951f"), new Guid("976b2fc3-97a6-4de0-a974-fff0e9880f6c"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-3.jpg" },
                    { new Guid("43f5b818-a92b-42b7-96d2-d10638f95ebb"), new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), "images/shoes/[IDGiay_16]_AnhPhu_1.png" },
                    { new Guid("45c3c27c-586d-47e6-9d0e-8e95b0d097ab"), new Guid("68cf9eff-eefb-4c20-9642-94ee9bf08fc8"), "https://thumblr.uniid.it/product/336262/57daee260d2a.jpg?width=3840&format=webp&q=75" },
                    { new Guid("47413858-d6a2-4b90-8455-506db09c72a9"), new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), "images/shoes/[IDGiay_8]_AnhChinh.jpg" },
                    { new Guid("477f7ad5-ded6-4db0-879c-e5d7fbf631e8"), new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), "images/shoes/[IDGiay_16]_AnhPhu_4.png" },
                    { new Guid("49ae308f-06ce-45d9-817a-436efc1db6e7"), new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09"), "images/shoes/[IDGiay_11]_AnhChinh.png" },
                    { new Guid("4b8a127d-3706-4cc3-86cd-7f453c7619b4"), new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80"), "images/shoes/[IDGiay_17]_AnhPhu_4.png" },
                    { new Guid("4f648ce3-4e5f-47c4-8423-27f981912e6f"), new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), "images/shoes/[IDGiay_13]_AnhPhu_1.jpeg" },
                    { new Guid("518704f1-6a20-43f1-80e0-e51d975f07fc"), new Guid("58e70527-c353-41dc-9b20-fc105551f412"), "images/shoes/[IDGiay_4]_AnhPhu_1.jpeg" },
                    { new Guid("5567ca36-a96f-411b-bef3-63f86aebd57d"), new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), "images/shoes/[IDGiay_7]_AnhPhu_4.jpg" },
                    { new Guid("55af9244-84fa-4d95-81e2-9e58f39e9b98"), new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), "images/shoes/[IDGiay_19]_AnhPhu_1.png" },
                    { new Guid("5a69ebf7-b04e-4350-8327-c10177409eeb"), new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), "images/shoes/[IDGiay_15]_AnhPhu_4.jpeg" },
                    { new Guid("5a9ff173-9b6f-4c20-b483-895f327e96b4"), new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09"), "images/shoes/[IDGiay_11]_AnhPhu_2.png" },
                    { new Guid("5c974d84-26bd-413d-b554-3fccdcd9323f"), new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8"), "images/shoes/[IDGiay_25]_AnhPhu_2.jpg" },
                    { new Guid("5da4e973-c683-462f-ab5a-cb79fa274305"), new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), "images/shoes/[IDGiay_6]_AnhPhu_2.jpg" },
                    { new Guid("60101c63-de2f-4f11-b27c-cae76a1e0621"), new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), "images/shoes/[IDGiay_13]_AnhPhu_3.jpeg" },
                    { new Guid("60882b42-4522-464d-b1c9-3b6fcca49f0c"), new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), "images/shoes/[IDGiay_15]_AnhChinh.jpeg" },
                    { new Guid("6130713e-4cc5-44e4-aa4f-29b4adfbaabf"), new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8"), "images/shoes/[IDGiay_25]_AnhChinh.jpg" },
                    { new Guid("620a74d0-43f6-4464-bd45-126c3ec714ef"), new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80"), "images/shoes/[IDGiay_17]_AnhPhu_1.png" },
                    { new Guid("636e6cde-f4fa-4780-b049-ea5652b219b7"), new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c"), "images/shoes/[IDGiay_12]_AnhPhu_2.jpeg" },
                    { new Guid("6441bd90-4eb2-44da-bf7a-67a85a3058c1"), new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), "images/shoes/[IDGiay_8]_AnhPhu_1.jpg" },
                    { new Guid("665f9266-f4be-4d1d-9e7d-579093b50caf"), new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), "images/shoes/[IDGiay_19]_AnhChinh.png" },
                    { new Guid("66a9f7e0-b4f0-4952-b47c-ea163e1299c2"), new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), "images/shoes/[IDGiay_13]_AnhPhu_2.jpeg" },
                    { new Guid("674933a6-f792-4bba-a917-a2a94e2a00b0"), new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b"), "https://gossipdergi.com/wp-content/uploads/2021/04/nikeayakkabi.gif" },
                    { new Guid("67919074-d453-452d-abe0-8a6f5a6bd347"), new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5"), "images/shoes/[IDGiay_24]_AnhPhu_1.jpg" },
                    { new Guid("69603c77-727d-4b8f-ba12-e38c5ac98a54"), new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), "images/shoes/[IDGiay_22]_AnhPhu_2.jpg" },
                    { new Guid("6a0c94ae-b9cf-43ad-b00d-79a90bc19bac"), new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777"), "images/shoes/[IDGiay_18]_AnhPhu_4.png" },
                    { new Guid("6a1b0756-3ab5-499f-9cb3-7c74393058da"), new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5"), "images/shoes/[IDGiay_24]_AnhPhu_4.jpg" },
                    { new Guid("6aedcc52-e515-4ee8-b76e-f9f12c97928f"), new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), "images/shoes/[IDGiay_22]_AnhPhu_3.jpg" },
                    { new Guid("6d408830-1d41-4e4c-b146-db3935fc1ca8"), new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80"), "images/shoes/[IDGiay_17]_AnhPhu_2.png" },
                    { new Guid("71682f71-5b58-4caf-8155-7179f7ddfe47"), new Guid("976b2fc3-97a6-4de0-a974-fff0e9880f6c"), "https://likelihood.us/cdn/shop/files/stansmith_angle_1200x.png?v=1691430477" },
                    { new Guid("7441c06c-c646-4add-a007-943a3de8083e"), new Guid("13694ddb-95e1-40b7-911c-741620c6d808"), "images/shoes/[IDGiay_10]_AnhPhu_1.jpg" },
                    { new Guid("7533ad74-3d02-4cd3-9e5b-9bcee53718ea"), new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09"), "images/shoes/[IDGiay_11]_AnhPhu_1.png" },
                    { new Guid("76b8c15d-7ec0-41a9-be2a-276a8988307d"), new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), "images/shoes/[IDGiay_14]_AnhChinh.jpeg" },
                    { new Guid("7915ed46-1c04-490a-b0e7-957dff0beb2e"), new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249"), "images/shoes/[IDGiay_5]_AnhPhu_4.jpeg" },
                    { new Guid("7950c567-c554-447b-a10f-bb611adff953"), new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c"), "images/shoes/[IDGiay_12]_AnhChinh.jpeg" },
                    { new Guid("7c559f77-b280-4ce5-9ebf-2d68c25daa18"), new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), "images/shoes/[IDGiay_22]_AnhChinh.jpg" },
                    { new Guid("7d05d662-21c5-48e3-960a-e9c73abed43a"), new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), "images/shoes/[IDGiay_16]_AnhPhu_2.png" },
                    { new Guid("805c99a8-3480-4f39-804f-7b6d979c1159"), new Guid("58e70527-c353-41dc-9b20-fc105551f412"), "images/shoes/[IDGiay_4]_AnhPhu_2.jpeg" },
                    { new Guid("80ef9b8a-c361-47bb-acdf-8c5c31c6a390"), new Guid("976b2fc3-97a6-4de0-a974-fff0e9880f6c"), "https://assets.adidas.com/images/w_1880,f_auto,q_auto/e53b9a57b0a745be924bac1e00f54427_9366/FX5502_42_detail.jpg" },
                    { new Guid("83e5a54c-af9d-4486-8b2f-ae9f39f84e11"), new Guid("68cf9eff-eefb-4c20-9642-94ee9bf08fc8"), "https://www.prosoccer.com/cdn/shop/files/PumaFuture7UltimateFGAG-ForeverFasterPack_SP24_Model1_1500x.png?v=1713488175" },
                    { new Guid("868861ed-8119-4624-8b05-f3582158f923"), new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), "images/shoes/[IDGiay_15]_AnhPhu_2.jpeg" },
                    { new Guid("897806c4-a04b-4853-86bc-7004fc89bdb2"), new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), "images/shoes/[IDGiay_8]_AnhPhu_2.jpg" },
                    { new Guid("89f602b7-8c81-4ba9-9fd7-7069abce9439"), new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835"), "images/shoes/[IDGiay_2]_AnhPhu_2.png" },
                    { new Guid("8b3b54be-eb21-4cc7-b869-5282696c27d3"), new Guid("13694ddb-95e1-40b7-911c-741620c6d808"), "images/shoes/[IDGiay_10]_AnhChinh.jpg" },
                    { new Guid("8c9a5e84-a49a-4f90-968a-ad4de9910c69"), new Guid("976b2fc3-97a6-4de0-a974-fff0e9880f6c"), "https://sneakerholicvietnam.vn/wp-content/uploads/2021/06/adidas-stan-smith-green-m20324-1.jpg" },
                    { new Guid("8d3d2525-dcb6-4954-9e0e-daaf0a29a8df"), new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), "images/shoes/[IDGiay_1]_AnhPhu_1.png" },
                    { new Guid("8f433a97-42f0-49f8-8fac-6267fac31e30"), new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249"), "images/shoes/[IDGiay_5]_AnhPhu_3.jpeg" },
                    { new Guid("951618bd-f1a1-4a37-a4db-79e159df8e62"), new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835"), "images/shoes/[IDGiay_2]_AnhPhu_1.png" },
                    { new Guid("962a320c-ded9-4590-a5ed-13d31b2571f8"), new Guid("50f984a0-2219-42e4-ae0a-dfaeea10f70b"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQPenW_eiwOe1RkKeaF_kg5TraxKiem6NJ_Q&s" },
                    { new Guid("975379e2-7a5d-4df8-bdd0-be04c7cdd82b"), new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), "images/shoes/[IDGiay_21]_AnhPhu_3.jpg" },
                    { new Guid("98a9f625-6162-4aa0-8225-29364ef4ecd7"), new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777"), "images/shoes/[IDGiay_18]_AnhPhu_3.png" },
                    { new Guid("994f7e66-3bde-420e-b5b7-609bfac5ec0f"), new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b"), "https://photo.znews.vn/w660/Uploaded/rohunwa/2021_03_26/SHOES3.jpeg" },
                    { new Guid("9a2a3cbb-d16a-4383-a1cf-08364dbe96be"), new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835"), "images/shoes/[IDGiay_2]_AnhPhu_4.jpeg" },
                    { new Guid("9bc29a4b-5735-496b-9d3c-ecfa015c95f0"), new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8"), "images/shoes/[IDGiay_25]_AnhPhu_1.jpg" },
                    { new Guid("9f3a945c-eebe-4f0d-98e7-7bf5837259a9"), new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), "images/shoes/[IDGiay_1]_AnhPhu_3.jpeg" },
                    { new Guid("9f9ad560-12aa-4d28-9464-44e896a0b3ef"), new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c"), "images/shoes/[IDGiay_12]_AnhPhu_3.jpeg" },
                    { new Guid("a155f02b-f00f-40b8-a82d-66582bfdc117"), new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c"), "images/shoes/[IDGiay_12]_AnhPhu_4.jpeg" },
                    { new Guid("a9f4e8db-2bd0-43f5-beed-f2b78095967f"), new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), "images/shoes/[IDGiay_1]_AnhPhu_4.png" },
                    { new Guid("b248ec1f-2e26-4e18-bd06-0adcf3c70274"), new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a"), "images/shoes/[IDGiay_3]_AnhChinh.jpeg" },
                    { new Guid("b562f1fa-89f4-46f4-bc7d-9cb2e671f878"), new Guid("68cf9eff-eefb-4c20-9642-94ee9bf08fc8"), "https://thumblr.uniid.it/product/336262/8307c19dcf3d.jpg?width=3840&format=webp&q=75" },
                    { new Guid("b74c96ca-957e-4fcb-a9e5-795f16ca4010"), new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09"), "images/shoes/[IDGiay_11]_AnhPhu_4.png" },
                    { new Guid("b78674bd-2365-4137-b356-8d524fa693f9"), new Guid("58e70527-c353-41dc-9b20-fc105551f412"), "images/shoes/[IDGiay_4]_AnhPhu_3.jpeg" },
                    { new Guid("b7ee186d-49e9-4e83-9094-2bca9908946c"), new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8"), "images/shoes/[IDGiay_25]_AnhPhu_3.jpg" },
                    { new Guid("b930cb45-2207-41c3-b9f4-cae4085df8a7"), new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), "images/shoes/[IDGiay_19]_AnhPhu_4.png" },
                    { new Guid("ba1020d1-e1ee-4890-adf1-504c7312f5af"), new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), "images/shoes/[IDGiay_7]_AnhPhu_2.jpg" },
                    { new Guid("badd5e19-bd9c-4bcc-8a71-220757ae1d6b"), new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), "images/shoes/[IDGiay_22]_AnhPhu_1.jpg" },
                    { new Guid("c07a45cb-c3dc-4749-8861-2ec2d360500e"), new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), "images/shoes/[IDGiay_19]_AnhPhu_2.png" },
                    { new Guid("c36b6151-4ae4-4553-9018-e9abaafd6408"), new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a"), "images/shoes/[IDGiay_3]_AnhPhu_1.png" },
                    { new Guid("c3bb4285-2f93-4617-962f-488940523bcf"), new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), "images/shoes/[IDGiay_14]_AnhPhu_2.jpeg" },
                    { new Guid("c5ff6724-c5a3-4ac9-8230-5962dcba6a85"), new Guid("13694ddb-95e1-40b7-911c-741620c6d808"), "images/shoes/[IDGiay_10]_AnhPhu_3.jpg" },
                    { new Guid("c7d1b2df-2906-4a23-aee6-4a773cbd1b26"), new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80"), "images/shoes/[IDGiay_17]_AnhPhu_3.png" },
                    { new Guid("ccac9755-4cea-435d-aafc-28a0f46db4f1"), new Guid("58e70527-c353-41dc-9b20-fc105551f412"), "images/shoes/[IDGiay_4]_AnhChinh.jpeg" },
                    { new Guid("ccca4d51-05e5-4b89-8b6f-a2a6594770b0"), new Guid("50f984a0-2219-42e4-ae0a-dfaeea10f70b"), "https://dmpkickz.com/cdn/shop/files/6_78fd24e0-cd30-400a-8fa1-e5e6cd3c5b0b.png?v=1696679846&width=480" },
                    { new Guid("d1145cf0-dd09-4559-a024-18eade8c27bb"), new Guid("58e70527-c353-41dc-9b20-fc105551f412"), "images/shoes/[IDGiay_4]_AnhPhu_4.jpeg" },
                    { new Guid("d114c705-e2a1-4d30-85ed-0b7e2b73fb95"), new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), "images/shoes/[IDGiay_15]_AnhPhu_3.jpeg" },
                    { new Guid("d12cd13a-46c6-4667-8be2-43c86b6919e2"), new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), "images/shoes/[IDGiay_22]_AnhPhu_4.jpg" },
                    { new Guid("d33278cb-4d7b-4bf4-897c-3b6da5c41f58"), new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), "images/shoes/[IDGiay_20]_AnhPhu_3.png" },
                    { new Guid("d4a26d67-e14f-43c1-9026-6c3b17ace821"), new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80"), "images/shoes/[IDGiay_17]_AnhChinh.png" },
                    { new Guid("d668518e-849d-4ff1-aa0d-3e922898bcf7"), new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5"), "images/shoes/[IDGiay_24]_AnhChinh.jpg" },
                    { new Guid("dba5ee8e-25d8-4d83-afa8-484d4fcd043a"), new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), "images/shoes/[IDGiay_20]_AnhChinh.png" },
                    { new Guid("dd42efca-490b-4608-bd51-527183b8a33f"), new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b"), "https://c.files.bbci.co.uk/1081F/production/_117751676_satan-shoes2.jpg" },
                    { new Guid("e04747b4-9feb-40b6-b886-6a69133de9e4"), new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), "images/shoes/[IDGiay_1]_AnhChinh.png" },
                    { new Guid("e0ae04ec-43ed-4c95-be12-c52670ff854e"), new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c"), "images/shoes/[IDGiay_12]_AnhPhu_1.jpeg" },
                    { new Guid("e1badb43-4068-460c-95d4-79a9fc399559"), new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249"), "images/shoes/[IDGiay_5]_AnhPhu_1.jpeg" },
                    { new Guid("e4206545-431b-4b58-bfc9-9a8383252af8"), new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), "images/shoes/[IDGiay_14]_AnhPhu_3.jpeg" },
                    { new Guid("e60a92f0-e497-42d6-9be0-04ef6b21948b"), new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), "images/shoes/[IDGiay_6]_AnhPhu_1.jpg" },
                    { new Guid("e9e7d463-e7b2-4853-8480-6e03748ea4ef"), new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835"), "images/shoes/[IDGiay_2]_AnhChinh.png" },
                    { new Guid("eb661fc4-1a13-471d-8346-3a916a7d04d1"), new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777"), "images/shoes/[IDGiay_18]_AnhChinh.png" },
                    { new Guid("eb7d6bb6-7115-47de-8163-bb3fdb64d1da"), new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), "images/shoes/[IDGiay_23]_AnhChinh.jpg" },
                    { new Guid("edd843b3-3555-4588-afa6-27418d95c97a"), new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), "images/shoes/[IDGiay_13]_AnhChinh.jpeg" },
                    { new Guid("f56d1336-f2a0-4b5f-a3ca-5c6379c6d930"), new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), "images/shoes/[IDGiay_6]_AnhPhu_4.jpg" },
                    { new Guid("f8033386-94c7-4d25-a8e7-a387bf21af48"), new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), "images/shoes/[IDGiay_9]_AnhPhu_2.jpg" },
                    { new Guid("f86974c8-bb7c-45d0-9f99-2a1334f439d2"), new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b"), "https://media.cnn.com/api/v1/images/stellar/prod/210328223753-03-lil-nas-x-satan-shoes.jpg?q=w_3000,h_3000,x_0,y_0,c_fill" },
                    { new Guid("f8f71758-bf3c-4a17-853c-fbaf4ea452cc"), new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), "images/shoes/[IDGiay_20]_AnhPhu_1.png" },
                    { new Guid("fc9a6bff-6ca7-47b1-9a42-d9fe84fa8a25"), new Guid("50f984a0-2219-42e4-ae0a-dfaeea10f70b"), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNBQXFHswxHuyjT_e8rb5XOaWUzEe3pphPPw&s" }
                });

            migrationBuilder.InsertData(
                table: "ShoeSeasons",
                columns: new[] { "Id", "Season", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("07aa2789-5f61-471e-b603-6a5babca95a1"), "Spring", new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881") },
                    { new Guid("0aa6a7c8-2e85-4baa-ad8b-ba47961fc946"), "Summer", new Guid("d8b818fb-2122-46af-9e68-7bca63d96649") },
                    { new Guid("16627631-8e07-42f2-a263-0c89e2f0891c"), "Fall", new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c") },
                    { new Guid("1e8b0c08-95e2-4553-9329-ce4afc519905"), "Summer", new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d") },
                    { new Guid("2dc1926c-13c1-4a4e-8091-8c068793d85c"), "Winter", new Guid("ab9d2138-612d-4536-9ce8-f993d238d134") },
                    { new Guid("326ff9ff-402f-4fb6-bf63-bd48b48fdc95"), "Fall", new Guid("58e70527-c353-41dc-9b20-fc105551f412") },
                    { new Guid("3309ac3f-bc6a-47ab-9248-b7878bdc330c"), "Summer", new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994") },
                    { new Guid("33e922f0-bf53-4ff5-9a65-638880e9961a"), "Winter", new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c") },
                    { new Guid("453ac0a9-989b-4af2-8a44-6956499e5162"), "Spring", new Guid("58e70527-c353-41dc-9b20-fc105551f412") },
                    { new Guid("460fc430-4fe6-4005-bd78-481fa5b17926"), "Summer", new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835") },
                    { new Guid("46770a69-fe4d-484c-bf9e-d22a5c41ae39"), "Winter", new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1") },
                    { new Guid("476f0592-198f-418e-931d-8467e7ab289f"), "Winter", new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c") },
                    { new Guid("47f755ef-4cf6-4cb2-8091-18c1e8f10d62"), "Summer", new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a") },
                    { new Guid("513862c5-dd92-417e-9dcd-9bb68259d4f9"), "Summer", new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd") },
                    { new Guid("5d1d8cbb-addc-40c7-992a-6191becc922d"), "Spring", new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8") },
                    { new Guid("5d44120f-dac4-445a-8c75-bdd77533cba2"), "Winter", new Guid("58e70527-c353-41dc-9b20-fc105551f412") },
                    { new Guid("5eb7217e-66ab-4f8f-93dd-07eb9077aac6"), "Winter", new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881") },
                    { new Guid("6159e8a4-eead-4a83-8cf5-570dba2e8831"), "Summer", new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881") },
                    { new Guid("638c78fd-c620-4344-94e4-583843f44014"), "Spring", new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de") },
                    { new Guid("63ed120c-45dd-4d77-908d-1d578cb99b95"), "Winter", new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a") },
                    { new Guid("67f15ec7-90bb-4300-8a79-b57a12d52292"), "Fall", new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a") },
                    { new Guid("6c0649e3-a12b-408e-9c55-34181131fe58"), "Spring", new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a") },
                    { new Guid("6ea229a6-0921-495a-b134-82d1efd532cf"), "Winter", new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835") },
                    { new Guid("6ea31541-bca8-4877-85a8-47e7c1ed9d34"), "Summer", new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26") },
                    { new Guid("6fcab9eb-d8d8-4c66-806a-74b1341dc02e"), "Summer", new Guid("13694ddb-95e1-40b7-911c-741620c6d808") },
                    { new Guid("7494a205-3f97-4c8d-812d-565fe4e8e438"), "Fall", new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5") },
                    { new Guid("7658ede9-4460-407c-ae06-62943ed06c6c"), "Summer", new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777") },
                    { new Guid("78f1a502-e861-474e-ac18-4030d2f057b1"), "Summer", new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1") },
                    { new Guid("791a6b95-d30e-433a-9d57-c43ac6651d29"), "Spring", new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1") },
                    { new Guid("79ef536b-7ac3-45de-a3b8-f099e6671e80"), "Winter", new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d") },
                    { new Guid("7c2f2a2c-ae85-47e6-8387-857d9958681b"), "Spring", new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777") },
                    { new Guid("81230f8a-3002-49d8-99b7-9ed863957ad9"), "Winter", new Guid("03473f4b-af4b-41cc-9f1b-36935525d760") },
                    { new Guid("893bb082-2914-4081-aad1-86b3334e2a33"), "Spring", new Guid("13694ddb-95e1-40b7-911c-741620c6d808") },
                    { new Guid("8c200161-020f-4e54-9597-67fce51aec36"), "Spring", new Guid("03473f4b-af4b-41cc-9f1b-36935525d760") },
                    { new Guid("8df5dfea-bee4-40ba-849f-4cf44f2bbc53"), "Fall", new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09") },
                    { new Guid("92f7901d-f707-4957-9cfd-0b7fde443f36"), "Summer", new Guid("ab9d2138-612d-4536-9ce8-f993d238d134") },
                    { new Guid("970fda8c-2685-401a-af80-27d81fbfc27f"), "Fall", new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249") },
                    { new Guid("a117c5d8-26fe-4d9e-a9a2-e9c614ca3ea7"), "Fall", new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835") },
                    { new Guid("a60d6365-b73d-4b03-b3cb-72c4c86daf35"), "Fall", new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b") },
                    { new Guid("ae3d563a-c9a9-4ee5-a2c1-ffa6fb6f0241"), "Spring", new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994") },
                    { new Guid("b78a4b9c-4f23-4b28-aa4d-9ae662b49b67"), "Winter", new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b") },
                    { new Guid("bf2aa37f-8f01-4c1c-8a05-7087a84c8239"), "Summer", new Guid("03473f4b-af4b-41cc-9f1b-36935525d760") },
                    { new Guid("c019dd96-7159-40c3-a2eb-a72347c55da7"), "Winter", new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249") },
                    { new Guid("c75e7935-e783-4af8-86f0-1ada911a7547"), "Spring", new Guid("d8b818fb-2122-46af-9e68-7bca63d96649") },
                    { new Guid("c763a07e-ab18-4284-866d-627a2378474d"), "Winter", new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80") },
                    { new Guid("ce955f54-6474-43df-9823-20126a53f439"), "Spring", new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c") },
                    { new Guid("cf649171-0bf5-40c3-a15d-03ec35bcc7b1"), "Fall", new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881") },
                    { new Guid("e50e31f1-ae83-4b56-a6a1-d10359ce2922"), "Spring", new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a") },
                    { new Guid("eaa85fdd-f546-4ca8-8c1a-c55c7c90dc1e"), "Summer", new Guid("58e70527-c353-41dc-9b20-fc105551f412") },
                    { new Guid("eced1efb-0124-454e-b420-13186f086780"), "Winter", new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d") },
                    { new Guid("f27cbb7d-72eb-431d-91a9-efe4a1e1a5b5"), "Fall", new Guid("03473f4b-af4b-41cc-9f1b-36935525d760") },
                    { new Guid("f8ede9f8-f77b-4fe4-a9bb-58fe75bb437d"), "Spring", new Guid("196fb766-95d4-4c04-b904-806a7b0e23db") },
                    { new Guid("f9a71dc6-f3a8-43c0-ba62-9f400b1235dd"), "Spring", new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b") },
                    { new Guid("fc5eb34e-5260-4118-b942-9d849ec37ad7"), "Spring", new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5") }
                });

            migrationBuilder.InsertData(
                table: "ShoesColor",
                columns: new[] { "Id", "Color", "ShoeId" },
                values: new object[,]
                {
                    { new Guid("088b57ac-8396-40ae-a273-a946b0c5d5c1"), "White", new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26") },
                    { new Guid("0c290737-b6ae-4fbc-8cf4-86a5a60fd50d"), "White", new Guid("196fb766-95d4-4c04-b904-806a7b0e23db") },
                    { new Guid("0c9cad66-cd14-4d93-bb59-a36625e75d30"), "Black", new Guid("196fb766-95d4-4c04-b904-806a7b0e23db") },
                    { new Guid("105646d9-fa92-412a-b80e-ad1753d4a25b"), "Black", new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881") },
                    { new Guid("110fa46d-21be-4356-9c94-9a460395595d"), "Black", new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd") },
                    { new Guid("15670d5b-99b6-421d-b27d-ee4069385f0b"), "White", new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249") },
                    { new Guid("1754536b-baa1-4002-a2c9-dbe42c1534b6"), "White", new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a") },
                    { new Guid("19742320-3779-4f8e-adda-67b999c64228"), "Black", new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249") },
                    { new Guid("1a0e82e1-2498-4090-98c6-45375aac4e7d"), "Brown", new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5") },
                    { new Guid("22bb5334-b5df-436b-b8ea-49c479d22569"), "Black", new Guid("ab9d2138-612d-4536-9ce8-f993d238d134") },
                    { new Guid("26b3a253-b44a-40d0-bce6-e979e991c317"), "Blue", new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26") },
                    { new Guid("2a7f5e15-1431-48a1-9a0e-6a58e73320b6"), "Red", new Guid("03473f4b-af4b-41cc-9f1b-36935525d760") },
                    { new Guid("2d7b1c83-170b-4360-ad2b-18ff18ce477a"), "Grey", new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a") },
                    { new Guid("32fceb47-f05c-4f9f-9900-ee4be07e7515"), "Black", new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26") },
                    { new Guid("3acb3df1-52bf-47fb-8b79-a30a1ea61358"), "Black", new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a") },
                    { new Guid("43137731-37e2-4af1-b9ab-ce6c242578a6"), "Red", new Guid("196fb766-95d4-4c04-b904-806a7b0e23db") },
                    { new Guid("45cb484a-9987-4768-a161-a19db7075b66"), "Yellow", new Guid("03473f4b-af4b-41cc-9f1b-36935525d760") },
                    { new Guid("482c1481-ca2d-452e-beec-4b5030330b2e"), "Red", new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26") },
                    { new Guid("4b310787-0cbc-4ddd-92cc-6e791fc3c1d8"), "Black", new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a") },
                    { new Guid("5282b490-84ed-4cc7-9b26-dd2884c07aae"), "Brown", new Guid("58e70527-c353-41dc-9b20-fc105551f412") },
                    { new Guid("5e2c5056-60bf-45cb-af18-3b13ab9683bd"), "White", new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a") },
                    { new Guid("67bfcf46-ba76-429d-889d-95365d43abf2"), "Black", new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c") },
                    { new Guid("692277d3-cab2-491c-b7c3-1214ba0ff0d6"), "White", new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de") },
                    { new Guid("6a811f20-9efc-42ee-833d-15811135bbfb"), "Blue", new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c") },
                    { new Guid("6b21f845-cceb-44a4-afd1-6cde4a8c0819"), "Black", new Guid("13694ddb-95e1-40b7-911c-741620c6d808") },
                    { new Guid("70add04a-3dfc-4f38-8cc2-f717852e13dc"), "Black", new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835") },
                    { new Guid("75395b62-39b1-4aa4-9dde-15ac5136c590"), "Red", new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835") },
                    { new Guid("775d2a56-e7e7-4206-a47d-997a63d89b97"), "Black", new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d") },
                    { new Guid("7d1c2fe5-1d5d-4f17-a94e-529fa5d322be"), "Purple", new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09") },
                    { new Guid("849f9c67-290b-4a64-b241-d6c722e218e5"), "Pink", new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a") },
                    { new Guid("8990d2d8-51c7-4d75-830c-1afbe3585592"), "Blue", new Guid("196fb766-95d4-4c04-b904-806a7b0e23db") },
                    { new Guid("9d1b5ad6-617c-47f0-8208-c21080bde054"), "Black", new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b") },
                    { new Guid("9dd8cf8c-62e7-4cbf-a7fb-a684f369fbf1"), "Red", new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b") },
                    { new Guid("9fee5f4b-fce8-4ca8-a074-0fc0cf537e8a"), "Pink", new Guid("196fb766-95d4-4c04-b904-806a7b0e23db") },
                    { new Guid("a08bbc70-32ca-49d9-a5e7-c68fa7663aad"), "Orange", new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249") },
                    { new Guid("a1a7e91d-73b2-42df-a488-5b6c40a19c67"), "Blue", new Guid("d8b818fb-2122-46af-9e68-7bca63d96649") },
                    { new Guid("a327406b-3ba1-4b20-b8f0-5d8e53ab61c5"), "Pink", new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80") },
                    { new Guid("a38e2853-f8bc-4331-ab80-eeddefab0773"), "Blue", new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a") },
                    { new Guid("ab5757f9-a094-4134-b535-fee51d08b782"), "Black", new Guid("d8b818fb-2122-46af-9e68-7bca63d96649") },
                    { new Guid("b0dc55bc-d5a9-4f4e-a88e-777c0b15aab5"), "Black", new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de") },
                    { new Guid("b57772af-fb63-4db7-b8b8-5a8e3b2412bf"), "Blue", new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c") },
                    { new Guid("be34aa46-1b4b-49ed-a1e4-8a57514ae2a4"), "Yellow", new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a") },
                    { new Guid("c0f52f16-ed84-4f35-9cfc-e9d366764326"), "Blue", new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80") },
                    { new Guid("c50cbaf1-2322-47ed-8e5a-78385d0349b4"), "White", new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d") },
                    { new Guid("c58e53ff-8057-4d41-8bae-28005c5b0a22"), "Orange", new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd") },
                    { new Guid("c64c0e10-aa1f-4b27-b458-ce925874608a"), "Orange", new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26") },
                    { new Guid("c889bf19-17f7-43d6-96fb-b52f07390d23"), "White", new Guid("13694ddb-95e1-40b7-911c-741620c6d808") },
                    { new Guid("ca181425-7044-4109-9185-571b839a058e"), "Pink", new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994") },
                    { new Guid("ccc9b421-91d0-40ad-a2f6-61baa355c6ba"), "Green", new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c") },
                    { new Guid("d1c14b24-1566-4785-85d0-c6dfe5e002b6"), "Green", new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8") },
                    { new Guid("d33888bf-caf9-4084-acab-79c107998a61"), "Purple", new Guid("d8b818fb-2122-46af-9e68-7bca63d96649") },
                    { new Guid("d3e763d2-8654-4fda-aa71-1c023fd5ca83"), "Brown", new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8") },
                    { new Guid("d8649e70-24f0-4922-b945-3b6795851390"), "Blue", new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835") },
                    { new Guid("dd7bb9b4-bcd6-4e1e-ba14-1b3cf648753e"), "Blue", new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777") },
                    { new Guid("dfa5c3ad-eec1-4d9b-97da-a7abf903c3b4"), "White", new Guid("d8b818fb-2122-46af-9e68-7bca63d96649") },
                    { new Guid("e4159dda-cac3-487f-9c72-e4a46d368e10"), "Purple", new Guid("13694ddb-95e1-40b7-911c-741620c6d808") },
                    { new Guid("e6a2a002-c13d-46cb-99c9-3ed3795f3900"), "White", new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5") },
                    { new Guid("ec041a62-b4d2-4e5b-bc42-d4e6f3f90611"), "Black", new Guid("58e70527-c353-41dc-9b20-fc105551f412") },
                    { new Guid("f140d31f-968d-46b4-b41f-287451a7b87e"), "Pink", new Guid("13694ddb-95e1-40b7-911c-741620c6d808") },
                    { new Guid("f231356e-ab11-4458-9368-5c881911e287"), "Orange", new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09") },
                    { new Guid("f4eeb36b-c6b3-4fa3-809f-8c81a09c9c6c"), "Green", new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26") },
                    { new Guid("f72293e9-4674-4ba4-bdb9-38968d6bbe68"), "White", new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835") },
                    { new Guid("f7cb2a13-2ccb-4b9f-8eb5-8c2d7ac76142"), "Blue", new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a") },
                    { new Guid("ff6066a1-0fbd-4caa-8c2a-b9dd45dd5659"), "White", new Guid("58e70527-c353-41dc-9b20-fc105551f412") },
                    { new Guid("fff8c3ad-b6ef-4a8f-8840-757aa154c655"), "Blue", new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1") }
                });

            migrationBuilder.InsertData(
                table: "ShoesDetail",
                columns: new[] { "Id", "Quantity", "ShoeId", "Size" },
                values: new object[,]
                {
                    { new Guid("00aa7811-ed0c-459a-896a-59bf6a588a5d"), 51, new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), 43 },
                    { new Guid("0c6f581a-0517-4073-8eec-000daf8e9c48"), 38, new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), 46 },
                    { new Guid("12b7e857-a701-4de2-8491-e4cc4ce1d71f"), 39, new Guid("58e70527-c353-41dc-9b20-fc105551f412"), 41 },
                    { new Guid("13af84b8-a0e4-4151-92a3-7303ddc31319"), 48, new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), 42 },
                    { new Guid("18d03dbe-ae7e-481c-90ce-959186910b7e"), 33, new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8"), 41 },
                    { new Guid("19c3ec67-8f6b-4d5d-8c65-27b248dcf4c4"), 13, new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a"), 39 },
                    { new Guid("1af55db0-affd-4b92-8248-bca0e068bbc2"), 31, new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c"), 45 },
                    { new Guid("1c0dbb7d-cdce-46af-9aec-7e9164cb2745"), 45, new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), 44 },
                    { new Guid("21414f70-c1a3-4c0e-89c6-843fe8fa1f74"), 32, new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835"), 38 },
                    { new Guid("21afe584-50dd-4caf-b3d1-32d8537d7169"), 28, new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777"), 41 },
                    { new Guid("21fbc244-654f-43b7-961f-0a90aceae802"), 41, new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), 42 },
                    { new Guid("22d3e769-6f9e-4a57-9beb-a8cc607a4867"), 20, new Guid("58e70527-c353-41dc-9b20-fc105551f412"), 42 },
                    { new Guid("2345a403-434d-4a99-acaf-948a51a0c56b"), 47, new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), 37 },
                    { new Guid("27bcd825-b185-4f14-877d-b052a74df0ed"), 10, new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835"), 40 },
                    { new Guid("2917ea11-9bee-44e0-8f2d-312fa3b2ed80"), 42, new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), 42 },
                    { new Guid("2d1bb68b-cbde-4f41-aa2c-c15f5bc580f7"), 34, new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5"), 44 },
                    { new Guid("2dc621e2-77ef-49b3-8561-e5a22ceeb85a"), 25, new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09"), 42 },
                    { new Guid("2dcaa30e-a65d-4cb9-882d-3cbb408e1e4c"), 7, new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), 43 },
                    { new Guid("2f6b5a10-3a30-4045-ad71-01e2fe9f05a2"), 1, new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), 42 },
                    { new Guid("2fe80b96-063b-49dc-8a66-8a73c77d1489"), 49, new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), 41 },
                    { new Guid("3301aaee-8031-4db4-848a-df8f0b880497"), 48, new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), 41 },
                    { new Guid("331a5796-2966-48a0-a9f4-6c120db44c44"), 5, new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), 45 },
                    { new Guid("35dda95d-fa7d-45c8-b008-13fb9d0dc8de"), 1, new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), 40 },
                    { new Guid("36a37069-9e45-432c-875e-ca52056c8743"), 49, new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), 45 },
                    { new Guid("3890e397-659b-401c-84a6-770b381ab5f4"), 30, new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835"), 39 },
                    { new Guid("3cb9f5dd-1226-40ad-9ba1-0a1dabbd5fd6"), 20, new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), 44 },
                    { new Guid("3d21fc54-7a76-4d83-be85-9e896b2ca1b4"), 52, new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), 44 },
                    { new Guid("3d6e28db-d8ee-41ce-a77c-e5271c83e8ee"), 14, new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), 43 },
                    { new Guid("3deaeefb-7cdf-4682-bc5f-ead3d2ebc2c2"), 33, new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), 46 },
                    { new Guid("3f7f2be8-3fff-4cfa-896f-89c788010c4c"), 37, new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80"), 42 },
                    { new Guid("3f81c70e-8918-474c-97cd-e27be1879501"), 37, new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), 42 },
                    { new Guid("40bbd66f-93ad-4ab8-9297-a2ea147ca72e"), 21, new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09"), 44 },
                    { new Guid("418f5b2c-cc13-440e-9030-4786664012f0"), 17, new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), 44 },
                    { new Guid("42339150-df41-4f6b-badf-fe948529864f"), 12, new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), 42 },
                    { new Guid("4541543d-24c8-4a0f-baec-a72d80f9ae7c"), 1, new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5"), 42 },
                    { new Guid("4951d17f-3e44-468f-90c8-18f74712cf1f"), 12, new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249"), 39 },
                    { new Guid("4c74bfab-07e7-4978-9521-3f010809f61a"), 23, new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80"), 40 },
                    { new Guid("4c7cdbf1-f9c9-4cc0-9860-dca814b4be9a"), 37, new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b"), 43 },
                    { new Guid("4caeae80-64db-4e52-9c0b-e1ebc679ebdd"), 45, new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8"), 42 },
                    { new Guid("50703692-6031-4b4b-8f82-18c432d49ad5"), 19, new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5"), 45 },
                    { new Guid("513a56bf-2bdb-491a-8a80-34be14180416"), 12, new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), 46 },
                    { new Guid("52387cd1-01da-45b2-84d7-d20eb9096858"), 53, new Guid("61d65139-1045-4e5c-ba7b-72c9febc9835"), 37 },
                    { new Guid("52615604-861f-4cfa-aaad-4b4310d3c2c0"), 51, new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b"), 42 },
                    { new Guid("535be632-b6e0-499a-9037-3e2e4e0241ec"), 50, new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249"), 40 },
                    { new Guid("53697746-4f0d-41c8-9a13-f7993a61beb8"), 13, new Guid("13694ddb-95e1-40b7-911c-741620c6d808"), 42 },
                    { new Guid("5584bf26-3ada-4e2f-95d0-eaeec228b485"), 33, new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), 43 },
                    { new Guid("55e47f23-6d14-428b-9cde-609787b9884d"), 6, new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777"), 43 },
                    { new Guid("56b9f9fe-1213-4c17-8d72-b8e019c570ec"), 33, new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), 40 },
                    { new Guid("57933034-b39a-4215-8113-86b4108cac5f"), 17, new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249"), 38 },
                    { new Guid("5915664f-2600-42a8-b380-6d85cf68eb28"), 40, new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), 40 },
                    { new Guid("5aabfaf6-0888-4df1-a243-ad250685cf55"), 37, new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), 39 },
                    { new Guid("5aefbc59-b2e7-4d75-8c19-f4993efefe15"), 46, new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), 41 },
                    { new Guid("5b7bf1f0-1bb0-482c-9ce0-15276cc92219"), 32, new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777"), 44 },
                    { new Guid("5b8c4cd2-7391-444b-bd2b-54d1aae9631e"), 9, new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8"), 40 },
                    { new Guid("5cdf418b-5779-44bf-a21e-c1f77a08fd72"), 9, new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09"), 43 },
                    { new Guid("5d9cc6fe-1ea1-496c-8356-68eef4c5f856"), 16, new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), 41 },
                    { new Guid("5e2f0e70-47c8-4fa7-bf1e-90849695ea5f"), 27, new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), 42 },
                    { new Guid("61c13bd4-bc70-4b8a-ae36-a0ee3b0d5c4e"), 52, new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), 43 },
                    { new Guid("63473638-ad65-4a09-b875-cf4d598caa74"), 11, new Guid("1d0f091b-2612-4998-ae60-382a0b0ccf09"), 45 },
                    { new Guid("67bf3fac-809d-46cf-ae52-1f380b52bc99"), 44, new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), 44 },
                    { new Guid("6ab2102e-ee24-46dc-87d1-ed4b1e20e645"), 0, new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), 42 },
                    { new Guid("6d2dd1e0-6184-4361-b831-93d1cf096ed4"), 17, new Guid("58e70527-c353-41dc-9b20-fc105551f412"), 39 },
                    { new Guid("70c8a82a-6d68-4ce6-adec-b20008ec2e13"), 7, new Guid("13694ddb-95e1-40b7-911c-741620c6d808"), 44 },
                    { new Guid("7602e14c-bbda-412f-8eba-9e714b83ed59"), 17, new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c"), 43 },
                    { new Guid("7691d0a0-2ce0-4a08-aa8f-a8b3ae2b4e19"), 35, new Guid("13694ddb-95e1-40b7-911c-741620c6d808"), 43 },
                    { new Guid("7cb638df-d4ab-4ab4-9a34-dafcd75d7966"), 33, new Guid("13694ddb-95e1-40b7-911c-741620c6d808"), 41 },
                    { new Guid("840a8811-27c8-46f1-9a77-5f69c380325e"), 54, new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), 41 },
                    { new Guid("84a20f65-6e4d-461f-9de8-61dc9c29cc1e"), 9, new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), 42 },
                    { new Guid("84e9c27e-fc81-4b43-9d66-b8f956c6fd0a"), 16, new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), 41 },
                    { new Guid("89fac112-590c-4137-9d55-c6c819628202"), 36, new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a"), 38 },
                    { new Guid("8cee6b50-7102-4b74-9767-a23c4328ec01"), 11, new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), 43 },
                    { new Guid("8e712c35-bb00-456e-b9dd-b65f9ead83d1"), 1, new Guid("837d71b8-ee99-48d7-9a3a-445bbd057cfd"), 44 },
                    { new Guid("8e9438ca-add8-4d9f-96a1-140a08a01216"), 46, new Guid("196fb766-95d4-4c04-b904-806a7b0e23db"), 45 },
                    { new Guid("929fb3b1-b508-4030-867b-25eb004ad51a"), 2, new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), 46 },
                    { new Guid("95607308-4d89-421c-b902-3984bc7856a8"), 16, new Guid("52a7d194-c3d5-4cb4-8189-a8297b557994"), 40 },
                    { new Guid("96412e2b-5f0f-47b1-84a1-6e1daeba7d7d"), 37, new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), 40 },
                    { new Guid("98d10161-5221-41eb-8ad2-6a79d33ac382"), 30, new Guid("e7bf7f4c-7851-4617-bdaa-ac5f53911bd8"), 39 },
                    { new Guid("9d77a2c3-81a1-40fc-916c-7b9fe17691ed"), 40, new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), 45 },
                    { new Guid("a29900c3-98bb-46f4-a6c0-c2c54e166dd7"), 48, new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), 38 },
                    { new Guid("a6547ca2-7734-46bf-8ca8-d1de01c3f220"), 1, new Guid("c40e89b9-e4c4-43b3-95da-938d12844f8a"), 42 },
                    { new Guid("a7c50d13-a24d-42c8-bfdb-240a991967d4"), 27, new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), 40 },
                    { new Guid("aa182ef6-b7ce-4377-9096-31795063d600"), 45, new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), 39 },
                    { new Guid("ab8e740e-32af-433f-8dca-57beff0a112d"), 45, new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), 44 },
                    { new Guid("ad436048-9df3-416a-b2fb-d7c75f033de2"), 30, new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80"), 39 },
                    { new Guid("af7bf080-2404-4925-8b99-a012238df446"), 49, new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), 46 },
                    { new Guid("b1641894-e7a2-4917-8ad9-a0b14b265286"), 28, new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a"), 37 },
                    { new Guid("b4e59ebc-29a1-4886-81ab-9c596fd9bc49"), 19, new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), 41 },
                    { new Guid("b8482395-2d08-432a-8974-21f12e25a3a7"), 4, new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), 44 },
                    { new Guid("bb3d49c6-a6c4-4b36-b05f-9e026aefc4c7"), 46, new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), 39 },
                    { new Guid("bbf2aefd-9aa6-470f-9e5a-44b592ac97d2"), 46, new Guid("c015c5e4-8a5f-4afe-a3e5-2bd93cb8ba7a"), 40 },
                    { new Guid("bbfa3b5e-33e4-4163-ab07-9434f9ae778a"), 10, new Guid("cf8e7c0e-debb-46fb-805f-89036c8086de"), 38 },
                    { new Guid("bc795027-a975-4484-bf11-d1307c052ece"), 13, new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), 42 },
                    { new Guid("bf8d7025-2132-4418-9c7b-36f444821ed4"), 7, new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), 44 },
                    { new Guid("c06c28bd-58ad-4d3a-8e10-ca1f80c70cdf"), 43, new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), 42 },
                    { new Guid("c154c1fd-5221-4876-b883-fb2a44224f68"), 41, new Guid("58e70527-c353-41dc-9b20-fc105551f412"), 40 },
                    { new Guid("c8972594-16be-4abf-bbb6-668d2be219de"), 7, new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), 38 },
                    { new Guid("ca3b6ae1-e999-4e49-a014-c97ad9c64801"), 15, new Guid("a960e9a4-1215-48cc-a43d-f1d579d9c777"), 42 },
                    { new Guid("cbfb3424-617f-433d-95f3-f3d984b861a7"), 47, new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b"), 44 },
                    { new Guid("ce951aac-fd73-4ac0-bdfb-9cfb5ea5aa57"), 34, new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), 40 },
                    { new Guid("d41811ff-e0ff-4313-9ecd-65cbb54d3060"), 8, new Guid("068801b4-819f-4e2d-b50a-d5182ed92d8b"), 45 },
                    { new Guid("d6a020da-8600-4e5f-a82c-752dd45d7089"), 4, new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), 37 },
                    { new Guid("d75b729e-e2ec-46ad-99f2-347cd37c7f1b"), 30, new Guid("f5d59491-13d4-4a48-9ca9-217b2880af80"), 41 },
                    { new Guid("d98ba05e-98f6-40d5-968d-6d1e8f2a2e9a"), 33, new Guid("aed343b8-b02a-47b6-b399-2bbc064fcdc5"), 43 },
                    { new Guid("dd679335-22f5-456f-927a-92c152787768"), 41, new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), 43 },
                    { new Guid("e39c1f06-f4d4-4c61-93b8-1c5d0985bcb4"), 25, new Guid("03473f4b-af4b-41cc-9f1b-36935525d760"), 45 },
                    { new Guid("e8002135-efa1-4348-b1a9-5386496a9762"), 13, new Guid("d8b818fb-2122-46af-9e68-7bca63d96649"), 39 },
                    { new Guid("e882e23b-bfc2-4284-a4f3-4d86cf785b5a"), 51, new Guid("a95dfa14-a13b-4868-aa22-486b01f4285d"), 40 },
                    { new Guid("e9bf824e-ed9f-4d22-9432-84df17c27354"), 31, new Guid("ab9d2138-612d-4536-9ce8-f993d238d134"), 38 },
                    { new Guid("eee2967a-5f69-4a0c-a051-3b1f5e5ca5d8"), 50, new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c"), 42 },
                    { new Guid("f02f01a5-54df-48ec-9a35-009c5a7e715f"), 51, new Guid("a0bbc450-5077-423a-a3ec-65d132bdfee1"), 43 },
                    { new Guid("f2438109-7537-4aca-936b-5ad51b941fd5"), 1, new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), 43 },
                    { new Guid("f2ea422e-c696-4ec7-98e0-bd4ab7ffca7c"), 32, new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), 45 },
                    { new Guid("f34842e7-74ae-4b36-ba37-7409757d93e9"), 4, new Guid("31d4a7b8-026d-4896-b80c-9fc0e694aa26"), 41 },
                    { new Guid("f53edf76-58d4-4d53-aa57-452a080e83d2"), 40, new Guid("6bac21ce-b097-445e-984b-e91cb0d9c249"), 37 },
                    { new Guid("f79ceef8-2f78-4763-b70d-772b498fd0d4"), 7, new Guid("b7af704b-7a95-4091-bbc1-0fff72538d5c"), 44 },
                    { new Guid("f824537a-3985-49f2-af2c-e781d3b58d36"), 2, new Guid("8b7152d2-fb12-4d2d-ac2e-9a2c102a8f4c"), 39 },
                    { new Guid("fcd290be-c802-4f76-98bd-b288e98e688f"), 7, new Guid("1bacbafa-1c55-43bb-8ba5-91ae3e604a5d"), 43 },
                    { new Guid("ffaa091d-22aa-42b0-88c1-f791a15ca7a9"), 25, new Guid("649ed57f-e8fa-4c17-ba32-a87f2aae2881"), 41 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "CreateDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "IsExternalLogin", "LastModifiedDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileName", "ProviderName", "RoleId", "SecurityStamp", "TotalMoney", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("82f48edf-e195-48e3-bbb4-e502f3adb6dd"), 0, null, "069379cc-9b5a-46d5-a934-2a53e782b883", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2204, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "machgiahuy@gmail.com", false, "Mach", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gia Huy", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("1a60c76f-7e73-4c64-a43c-9e2e4cbe9e19"), null, 1000m, false, "Mach Gia Huy" },
                    { new Guid("ad0700af-97da-4b41-acfa-2fb8f81a9275"), 0, null, "568999d5-00a4-488f-8c0f-254ed492c4e2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, "Jane", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", null, false, null, null, new Guid("50201422-a8b8-4bb2-b39a-8f5b0186d0d7"), null, 1500m, false, "jane.smith" }
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
