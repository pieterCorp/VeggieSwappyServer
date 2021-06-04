using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VeggieSwappyServer.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User1Id = table.Column<int>(type: "int", nullable: false),
                    User2Id = table.Column<int>(type: "int", nullable: false),
                    TradeStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTradeProposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProposingUserId = table.Column<int>(type: "int", nullable: false),
                    TradeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTradeProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentTradeProposals_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rejectedTradeProposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProposingUserId = table.Column<int>(type: "int", nullable: false),
                    TradeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rejectedTradeProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rejectedTradeProposals_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    longitude = table.Column<float>(type: "real", nullable: true),
                    latitude = table.Column<float>(type: "real", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradeUser",
                columns: table => new
                {
                    TradesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeUser", x => new { x.TradesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TradeUser_Trades_TradesId",
                        column: x => x.TradesId,
                        principalTable: "Trades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTradeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTradeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTradeItems_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTradeItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposedTradeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    CurrentTradeProposalId = table.Column<int>(type: "int", nullable: true),
                    RejectedTradeProposalId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposedTradeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposedTradeItems_CurrentTradeProposals_CurrentTradeProposalId",
                        column: x => x.CurrentTradeProposalId,
                        principalTable: "CurrentTradeProposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProposedTradeItems_rejectedTradeProposals_RejectedTradeProposalId",
                        column: x => x.RejectedTradeProposalId,
                        principalTable: "rejectedTradeProposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProposedTradeItems_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposedTradeItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(1805), "apples.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(1805), "apples" },
                    { 29, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3049), "olives.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3049), "olives" },
                    { 30, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3052), "oranges.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3052), "oranges" },
                    { 31, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3054), "papayas.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3054), "papayas" },
                    { 32, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3057), "peaches.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3057), "peaches" },
                    { 33, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3060), "pears.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3060), "pears" },
                    { 34, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3063), "peas.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3063), "peas" },
                    { 35, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3066), "pineapples.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3066), "pineapples" },
                    { 36, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3068), "pomegranates.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3068), "pomegranates" },
                    { 38, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3074), "pumpkins.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3074), "pumpkins" },
                    { 39, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3077), "radish.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3077), "radish" },
                    { 28, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3046), "mushrooms.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3046), "mushrooms" },
                    { 40, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3079), "radishes.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3079), "radishes" },
                    { 42, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3085), "salad.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3085), "salad" },
                    { 43, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3087), "salads.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3087), "salads" },
                    { 44, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3090), "scallions.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3090), "scallions" },
                    { 45, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3093), "spinach.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3093), "spinach" },
                    { 46, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3096), "star-fruits.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3096), "star-fruits" },
                    { 47, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3098), "strawberries.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3098), "strawberries" },
                    { 48, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3101), "sweet-potatoes.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3101), "sweet-potatoes" },
                    { 49, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3104), "tomatoes.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3104), "tomatoes" },
                    { 50, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3107), "watermelons.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3107), "watermelons" },
                    { 51, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3109), "v-coin.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3109), "v-coin" },
                    { 41, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3082), "raspberries.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3082), "raspberries" },
                    { 27, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3043), "melons.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3043), "melons" },
                    { 37, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3071), "potatoes.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3071), "potatoes" },
                    { 25, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3038), "mangos.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3038), "mangos" },
                    { 2, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2876), "artichokes.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2876), "artichokes" },
                    { 26, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3040), "mangosteens.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3040), "mangosteens" },
                    { 4, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2894), "bananas.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2894), "bananas" },
                    { 5, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2896), "bell-peppers.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2896), "bell-peppers" },
                    { 6, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2900), "blueberries.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2900), "blueberries" },
                    { 7, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2902), "bok-choy.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2902), "bok-choy" },
                    { 8, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2905), "broccoli.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2905), "broccoli" },
                    { 9, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2908), "brussels-sprouts.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2908), "brussels-sprouts" },
                    { 10, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2911), "carrots.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2911), "carrots" },
                    { 11, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2914), "cherries.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2914), "cherries" },
                    { 12, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2917), "chilis.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2917), "chilis" },
                    { 13, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2919), "coconuts.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2919), "coconuts" },
                    { 3, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2890), "asparagus.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2890), "asparagus" },
                    { 15, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2925), "corn.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2925), "corn" },
                    { 14, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2923), "coriander.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2923), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 23, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3032), "kiwis.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3032), "kiwis" },
                    { 22, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3029), "guavas.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3029), "guavas" },
                    { 21, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3026), "grapes.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3026), "grapes" },
                    { 20, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3023), "garlic.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3023), "garlic" },
                    { 24, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3035), "lemons.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3035), "lemons" },
                    { 18, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2933), "durians.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2933), "durians" },
                    { 17, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2931), "dragon-fruits.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2931), "dragon-fruits" },
                    { 16, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2928), "cucumbers.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(2928), "cucumbers" },
                    { 19, new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3019), "eggplants.svg", new DateTime(2021, 6, 3, 20, 37, 34, 591, DateTimeKind.Local).AddTicks(3019), "eggplants" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 12, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6259), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6259), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 19, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6452), "Karolien@mail.com", "Karolien", "78", false, "Vdabpolitie", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6452), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 18, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6436), "Joke@mail.com", "Joke", "24", false, "LidlAnnoying", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6436), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 17, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6418), "Sien@mail.com", "Sien", "57", false, "Rommeltje", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6418), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 16, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6322), "Emma@mail.com", "Emma", "45", false, "Schoonkind", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6322), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 15, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6306), "Anke@mail.com", "Anke", "27", false, "Kleurenkenner", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6306), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 20, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6468), "Hoon@mail.com", "Hoon", "99", false, "Tomatenplukker", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6468), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 14, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6290), "Marieke@mail.com", "Marieke", "T1", false, "Van Leren Broeke", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6290), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 13, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6275), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6275), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 11, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6243), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6243), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 6, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6163), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6163), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 9, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6211), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6211), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 8, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6195), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6195), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 7, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6179), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6179), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 5, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6147), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6147), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 4, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6130), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6130), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 3, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6104), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6104), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 2, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(5879), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(5879), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 1, new DateTime(2021, 6, 3, 20, 37, 34, 583, DateTimeKind.Local).AddTicks(5324), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 6, 3, 20, 37, 34, 583, DateTimeKind.Local).AddTicks(5324), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 21, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6484), "Michaël@mail.com", "Michaël", "25", false, "Wanderer", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6484), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 10, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6228), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6228), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } },
                    { 22, new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6501), "Brent@mail.com", "Brent", "29", false, "Tomatentrucker", new DateTime(2021, 6, 3, 20, 37, 34, 587, DateTimeKind.Local).AddTicks(6501), new byte[] { 159, 204, 222, 248, 220, 152, 121, 227, 31, 90, 113, 73, 58, 7, 241, 192, 35, 147, 200, 66, 40, 120, 190, 114, 100, 78, 192, 40, 222, 35, 58, 136, 125, 228, 181, 125, 23, 229, 207, 94, 149, 152, 255, 250, 183, 185, 237, 219, 191, 75, 15, 245, 102, 216, 51, 110, 174, 14, 236, 145, 189, 166, 131, 252 }, new byte[] { 12, 142, 31, 197, 169, 50, 246, 143, 148, 166, 11, 179, 106, 152, 103, 251, 187, 197, 171, 209, 149, 90, 185, 58, 239, 148, 122, 151, 115, 110, 116, 136, 47, 81, 26, 197, 172, 255, 174, 220, 160, 22, 240, 236, 247, 219, 152, 77, 191, 146, 116, 141, 158, 228, 212, 219, 101, 217, 158, 128, 15, 184, 234, 162, 126, 246, 152, 23, 165, 130, 108, 226, 163, 102, 13, 75, 79, 37, 166, 63, 210, 246, 115, 254, 114, 176, 214, 16, 59, 136, 190, 180, 30, 134, 21, 190, 182, 185, 221, 67, 51, 185, 25, 89, 112, 233, 181, 67, 199, 110, 215, 90, 198, 80, 116, 221, 33, 191, 123, 216, 235, 184, 139, 16, 135, 120, 30, 135 } }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId", "latitude", "longitude" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(7076), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(7076), 9000, "Anti-Veggiestraat", 89, 1, null, null },
                    { 21, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9168), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9168), 3020, "Balletjesstraat", 100, 21, null, null },
                    { 8, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9092), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9092), 1000, "Kotsvisplein", 96, 8, null, null },
                    { 9, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9095), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9095), 2000, "Greenlivesweg", 420, 9, null, null },
                    { 10, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9098), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9098), 9070, "Geenpolitiekstraat", 200, 10, null, null },
                    { 11, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9101), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9101), 9500, "Kalfslapjesstraat", 32, 11, null, null },
                    { 12, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9104), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9104), 1000, "Blacklivesmatterstraat", 78, 12, null, null },
                    { 7, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9089), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9089), 9050, "Greenpeacestraat", 1, 7, null, null },
                    { 13, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9107), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9107), 7000, "Worstenbroodjesstraat", 4, 13, null, null },
                    { 15, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9150), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9150), 1081, "Bloedworststraat", 78, 15, null, null },
                    { 16, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9153), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9153), 1180, "Runderlendedreef", 36, 16, null, null },
                    { 17, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9156), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9156), 1500, "Ribbetjesstraat", 14, 17, null, null },
                    { 18, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9159), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9159), 2070, "Bickyburgerstraat", 15, 18, null, null },
                    { 19, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9162), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9162), 2323, "Lookbroodjesstraat", 11, 19, null, null },
                    { 20, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9165), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9165), 2890, "Worstenbroodjesstraat", 79, 20, null, null },
                    { 14, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9146), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9146), 9000, "Jurgenverstopstraat", 24, 14, null, null },
                    { 6, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9086), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9086), 1000, "Spekmeteierenstraat", 43, 6, null, null },
                    { 22, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9171), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9171), 3110, "Kalfsrib-eyelaan", 107, 22, null, null },
                    { 4, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9080), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9080), 1000, "Vleesbroodstraat", 66, 4, null, null },
                    { 5, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9083), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9083), 9000, "Boerenworststraat", 85, 5, null, null },
                    { 2, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9059), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9059), 3000, "Vrbaan", 45, 2, null, null },
                    { 3, new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9075), new DateTime(2021, 6, 3, 20, 37, 34, 589, DateTimeKind.Local).AddTicks(9075), 4000, "Balletjesstraat", 74, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserTradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 28, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4063), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4063), 37, 10 },
                    { 29, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4066), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4066), 30, 10 },
                    { 30, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4069), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4069), 31, 10 },
                    { 8, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4006), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4006), 5, 3 },
                    { 7, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4003), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4003), 1, 3 },
                    { 6, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4000), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4000), 12, 2 },
                    { 5, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(3998), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(3998), 11, 2 },
                    { 4, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(3994), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(3994), 10, 2 },
                    { 3, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(3991), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(3991), 3, 1 },
                    { 2, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(3977), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(3977), 2, 1 },
                    { 1, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(2491), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(2491), 1, 1 },
                    { 27, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4061), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4061), 35, 10 },
                    { 14, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4024), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4024), 2, 5 },
                    { 26, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4058), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4058), 10, 9 },
                    { 25, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4055), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4055), 12, 9 },
                    { 24, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4052), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4052), 11, 9 },
                    { 9, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4009), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4009), 7, 4 },
                    { 23, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4050), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4050), 21, 8 },
                    { 22, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4047), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4047), 20, 8 },
                    { 10, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4012), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4012), 20, 4 }
                });

            migrationBuilder.InsertData(
                table: "UserTradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 21, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4044), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4044), 7, 7 },
                    { 20, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4041), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4041), 5, 7 },
                    { 11, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4015), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4015), 21, 4 },
                    { 12, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4019), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4019), 22, 4 },
                    { 18, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4036), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4036), 12, 6 },
                    { 17, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4033), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4033), 11, 6 },
                    { 16, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4030), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4030), 10, 6 },
                    { 15, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4027), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4027), 3, 6 },
                    { 13, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4021), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4021), 1, 5 },
                    { 19, 50, new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4038), new DateTime(2021, 6, 3, 20, 37, 34, 592, DateTimeKind.Local).AddTicks(4038), 1, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrentTradeProposals_TradeId",
                table: "CurrentTradeProposals",
                column: "TradeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProposedTradeItems_CurrentTradeProposalId",
                table: "ProposedTradeItems",
                column: "CurrentTradeProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedTradeItems_RejectedTradeProposalId",
                table: "ProposedTradeItems",
                column: "RejectedTradeProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedTradeItems_ResourceId",
                table: "ProposedTradeItems",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposedTradeItems_UserId",
                table: "ProposedTradeItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_rejectedTradeProposals_TradeId",
                table: "rejectedTradeProposals",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeUser_UsersId",
                table: "TradeUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeItems_ResourceId",
                table: "UserTradeItems",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeItems_UserId",
                table: "UserTradeItems",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ProposedTradeItems");

            migrationBuilder.DropTable(
                name: "TradeUser");

            migrationBuilder.DropTable(
                name: "UserTradeItems");

            migrationBuilder.DropTable(
                name: "CurrentTradeProposals");

            migrationBuilder.DropTable(
                name: "rejectedTradeProposals");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Trades");
        }
    }
}
