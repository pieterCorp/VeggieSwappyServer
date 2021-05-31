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
                    Completed = table.Column<bool>(type: "bit", nullable: false),
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
                    { 1, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(1586), "apples.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(1586), "apples" },
                    { 29, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2767), "olives.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2767), "olives" },
                    { 30, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2770), "oranges.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2770), "oranges" },
                    { 31, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2772), "papayas.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2772), "papayas" },
                    { 33, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2778), "pears.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2778), "pears" },
                    { 34, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2781), "peas.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2781), "peas" },
                    { 35, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2783), "pineapples.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2783), "pineapples" },
                    { 36, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2786), "pomegranates.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2786), "pomegranates" },
                    { 37, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2789), "potatoes.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2789), "potatoes" },
                    { 38, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2792), "pumpkins.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2792), "pumpkins" },
                    { 39, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2795), "radish.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2795), "radish" },
                    { 28, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2764), "mushrooms.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2764), "mushrooms" },
                    { 40, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2797), "radishes.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2797), "radishes" },
                    { 42, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2803), "salad.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2803), "salad" },
                    { 43, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2806), "salads.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2806), "salads" },
                    { 44, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2808), "scallions.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2808), "scallions" },
                    { 45, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2811), "spinach.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2811), "spinach" },
                    { 46, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2814), "star-fruits.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2814), "star-fruits" },
                    { 47, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2817), "strawberries.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2817), "strawberries" },
                    { 48, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2820), "sweet-potatoes.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2820), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2822), "tomatoes.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2822), "tomatoes" },
                    { 50, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2825), "watermelons.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2825), "watermelons" },
                    { 51, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2828), "v-coin.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2828), "v-coin" },
                    { 41, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2800), "raspberries.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2800), "raspberries" },
                    { 27, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2761), "melons.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2761), "melons" },
                    { 32, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2775), "peaches.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2775), "peaches" },
                    { 25, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2756), "mangos.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2756), "mangos" },
                    { 2, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2678), "artichokes.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2678), "artichokes" },
                    { 3, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2692), "asparagus.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2692), "asparagus" },
                    { 4, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2695), "bananas.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2695), "bananas" },
                    { 5, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2699), "bell-peppers.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2699), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2702), "blueberries.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2702), "blueberries" },
                    { 7, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2705), "bok-choy.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2705), "bok-choy" },
                    { 26, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2759), "mangosteens.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2759), "mangosteens" },
                    { 9, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2711), "brussels-sprouts.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2711), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2714), "carrots.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2714), "carrots" },
                    { 11, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2717), "cherries.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2717), "cherries" },
                    { 12, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2719), "chilis.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2719), "chilis" },
                    { 13, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2722), "coconuts.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2722), "coconuts" },
                    { 8, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2708), "broccoli.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2708), "broccoli" },
                    { 15, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2728), "corn.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2728), "corn" },
                    { 16, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2731), "cucumbers.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2731), "cucumbers" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2733), "dragon-fruits.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2733), "dragon-fruits" },
                    { 18, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2736), "durians.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2736), "durians" },
                    { 19, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2739), "eggplants.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2739), "eggplants" },
                    { 20, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2742), "garlic.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2742), "garlic" },
                    { 21, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2745), "grapes.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2745), "grapes" },
                    { 22, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2748), "guavas.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2748), "guavas" },
                    { 23, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2750), "kiwis.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2750), "kiwis" },
                    { 24, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2753), "lemons.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2753), "lemons" },
                    { 14, new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2725), "coriander.svg", new DateTime(2021, 5, 31, 18, 43, 55, 97, DateTimeKind.Local).AddTicks(2725), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6338), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6338), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 10, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6323), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6323), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 9, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6306), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6306), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 8, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6291), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6291), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 7, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6275), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6275), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 1, new DateTime(2021, 5, 31, 18, 43, 55, 91, DateTimeKind.Local).AddTicks(2090), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 31, 18, 43, 55, 91, DateTimeKind.Local).AddTicks(2090), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 5, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6241), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6241), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 4, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6049), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6049), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 3, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6021), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6021), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 2, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(5826), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(5826), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 12, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6353), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6353), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 6, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6259), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6259), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } },
                    { 13, new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6369), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 31, 18, 43, 55, 94, DateTimeKind.Local).AddTicks(6369), new byte[] { 144, 216, 148, 59, 213, 91, 155, 116, 170, 234, 13, 188, 82, 5, 31, 15, 192, 213, 77, 4, 61, 148, 224, 212, 88, 156, 200, 164, 110, 47, 66, 164, 147, 50, 217, 65, 242, 207, 162, 175, 246, 7, 116, 239, 91, 47, 119, 238, 7, 141, 188, 102, 60, 248, 76, 237, 19, 92, 49, 68, 169, 207, 36, 48 }, new byte[] { 208, 218, 61, 247, 228, 43, 101, 62, 96, 43, 93, 64, 102, 248, 16, 171, 146, 10, 51, 252, 219, 189, 108, 99, 18, 143, 144, 136, 229, 155, 45, 133, 161, 44, 14, 239, 88, 62, 183, 255, 14, 31, 13, 127, 111, 57, 5, 20, 118, 16, 37, 164, 222, 254, 113, 187, 174, 199, 94, 190, 117, 123, 235, 234, 79, 235, 11, 168, 90, 70, 136, 240, 125, 223, 51, 93, 249, 63, 130, 17, 222, 156, 143, 95, 125, 183, 45, 189, 202, 192, 144, 172, 253, 91, 181, 77, 78, 241, 159, 179, 95, 57, 133, 189, 225, 136, 54, 115, 216, 79, 76, 98, 3, 50, 170, 158, 197, 2, 34, 123, 56, 135, 171, 220, 149, 120, 158, 21 } }
                });

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
