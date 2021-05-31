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
                    { 1, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(6833), "apples.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(6833), "apples" },
                    { 29, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7993), "olives.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7993), "olives" },
                    { 30, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7995), "oranges.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7995), "oranges" },
                    { 31, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7998), "papayas.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7998), "papayas" },
                    { 33, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8004), "pears.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8004), "pears" },
                    { 34, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8007), "peas.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8007), "peas" },
                    { 35, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8009), "pineapples.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8009), "pineapples" },
                    { 36, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8012), "pomegranates.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8012), "pomegranates" },
                    { 37, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8015), "potatoes.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8015), "potatoes" },
                    { 38, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8100), "pumpkins.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8100), "pumpkins" },
                    { 39, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8105), "radish.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8105), "radish" },
                    { 28, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7990), "mushrooms.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7990), "mushrooms" },
                    { 40, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8108), "radishes.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8108), "radishes" },
                    { 42, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8114), "salad.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8114), "salad" },
                    { 43, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8117), "salads.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8117), "salads" },
                    { 44, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8120), "scallions.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8120), "scallions" },
                    { 45, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8122), "spinach.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8122), "spinach" },
                    { 46, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8125), "star-fruits.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8125), "star-fruits" },
                    { 47, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8128), "strawberries.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8128), "strawberries" },
                    { 48, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8130), "sweet-potatoes.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8130), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8133), "tomatoes.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8133), "tomatoes" },
                    { 50, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8136), "watermelons.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8136), "watermelons" },
                    { 51, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8139), "v-coin.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8139), "v-coin" },
                    { 41, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8111), "raspberries.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8111), "raspberries" },
                    { 27, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7987), "melons.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7987), "melons" },
                    { 32, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8001), "peaches.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(8001), "peaches" },
                    { 25, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7982), "mangos.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7982), "mangos" },
                    { 2, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7904), "artichokes.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7904), "artichokes" },
                    { 3, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7918), "asparagus.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7918), "asparagus" },
                    { 4, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7922), "bananas.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7922), "bananas" },
                    { 5, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7926), "bell-peppers.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7926), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7928), "blueberries.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7928), "blueberries" },
                    { 7, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7931), "bok-choy.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7931), "bok-choy" },
                    { 26, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7984), "mangosteens.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7984), "mangosteens" },
                    { 9, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7937), "brussels-sprouts.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7937), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7940), "carrots.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7940), "carrots" },
                    { 11, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7942), "cherries.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7942), "cherries" },
                    { 12, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7946), "chilis.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7946), "chilis" },
                    { 13, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7948), "coconuts.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7948), "coconuts" },
                    { 8, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7934), "broccoli.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7934), "broccoli" },
                    { 15, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7954), "corn.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7954), "corn" },
                    { 16, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7956), "cucumbers.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7956), "cucumbers" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7959), "dragon-fruits.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7959), "dragon-fruits" },
                    { 18, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7962), "durians.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7962), "durians" },
                    { 19, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7965), "eggplants.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7965), "eggplants" },
                    { 20, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7968), "garlic.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7968), "garlic" },
                    { 21, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7970), "grapes.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7970), "grapes" },
                    { 22, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7973), "guavas.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7973), "guavas" },
                    { 23, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7976), "kiwis.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7976), "kiwis" },
                    { 24, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7979), "lemons.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7979), "lemons" },
                    { 14, new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7951), "coriander.svg", new DateTime(2021, 5, 31, 21, 6, 27, 483, DateTimeKind.Local).AddTicks(7951), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1889), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1889), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 10, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1874), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1874), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 9, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1858), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1858), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 8, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1843), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1843), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 7, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1827), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1827), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 1, new DateTime(2021, 5, 31, 21, 6, 27, 477, DateTimeKind.Local).AddTicks(6288), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 31, 21, 6, 27, 477, DateTimeKind.Local).AddTicks(6288), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 5, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1795), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1795), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 4, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1779), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1779), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 3, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1754), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1754), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 2, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1547), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1547), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 12, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1905), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1905), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 6, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1812), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1812), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } },
                    { 13, new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1920), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 31, 21, 6, 27, 481, DateTimeKind.Local).AddTicks(1920), new byte[] { 130, 199, 110, 225, 152, 155, 218, 162, 74, 234, 130, 232, 235, 150, 45, 187, 187, 45, 169, 99, 48, 86, 97, 118, 245, 176, 73, 17, 228, 16, 52, 247, 200, 188, 248, 154, 163, 55, 210, 226, 91, 32, 130, 33, 102, 224, 184, 233, 222, 221, 33, 106, 169, 213, 24, 151, 64, 46, 194, 157, 37, 254, 202, 27 }, new byte[] { 142, 119, 216, 176, 76, 88, 189, 201, 36, 78, 40, 136, 151, 23, 95, 23, 2, 5, 76, 40, 185, 233, 207, 104, 89, 46, 23, 64, 90, 208, 32, 1, 103, 62, 77, 250, 185, 101, 51, 178, 70, 168, 171, 12, 50, 33, 151, 145, 126, 220, 108, 150, 101, 99, 148, 103, 14, 6, 124, 34, 171, 58, 193, 48, 110, 19, 168, 4, 154, 92, 43, 44, 240, 14, 43, 24, 83, 76, 196, 36, 9, 146, 2, 213, 254, 31, 0, 129, 12, 152, 226, 105, 48, 219, 239, 32, 19, 72, 255, 69, 209, 131, 139, 111, 2, 240, 64, 127, 164, 228, 12, 133, 207, 167, 248, 202, 179, 183, 26, 32, 224, 187, 53, 131, 96, 19, 136, 134 } }
                });

            migrationBuilder.InsertData(
                table: "UserTradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 1, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(4488), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(4488), 1, 1 },
                    { 2, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5940), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5940), 2, 1 },
                    { 3, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5953), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5953), 3, 1 },
                    { 4, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5956), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5956), 10, 2 },
                    { 5, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5959), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5959), 11, 2 },
                    { 6, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5962), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5962), 12, 2 },
                    { 7, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5965), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5965), 1, 3 },
                    { 8, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5968), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5968), 5, 3 },
                    { 9, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5971), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5971), 7, 4 },
                    { 10, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5974), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5974), 20, 4 },
                    { 11, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5977), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5977), 21, 4 },
                    { 12, 50, new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5980), new DateTime(2021, 5, 31, 21, 6, 27, 484, DateTimeKind.Local).AddTicks(5980), 22, 4 }
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
