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
                    { 1, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(4340), "apples.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(4340), "apples" },
                    { 29, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5487), "olives.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5487), "olives" },
                    { 30, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5490), "oranges.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5490), "oranges" },
                    { 31, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5492), "papayas.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5492), "papayas" },
                    { 33, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5498), "pears.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5498), "pears" },
                    { 34, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5501), "peas.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5501), "peas" },
                    { 35, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5504), "pineapples.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5504), "pineapples" },
                    { 36, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5507), "pomegranates.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5507), "pomegranates" },
                    { 37, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5510), "potatoes.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5510), "potatoes" },
                    { 38, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5513), "pumpkins.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5513), "pumpkins" },
                    { 39, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5516), "radish.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5516), "radish" },
                    { 28, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5484), "mushrooms.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5484), "mushrooms" },
                    { 40, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5519), "radishes.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5519), "radishes" },
                    { 42, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5525), "salad.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5525), "salad" },
                    { 43, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5528), "salads.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5528), "salads" },
                    { 44, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5531), "scallions.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5531), "scallions" },
                    { 45, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5534), "spinach.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5534), "spinach" },
                    { 46, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5537), "star-fruits.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5537), "star-fruits" },
                    { 47, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5540), "strawberries.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5540), "strawberries" },
                    { 48, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5543), "sweet-potatoes.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5543), "sweet-potatoes" },
                    { 49, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5546), "tomatoes.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5546), "tomatoes" },
                    { 50, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5549), "watermelons.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5549), "watermelons" },
                    { 51, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5551), "v-coin.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5551), "v-coin" },
                    { 41, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5522), "raspberries.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5522), "raspberries" },
                    { 27, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5481), "melons.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5481), "melons" },
                    { 32, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5495), "peaches.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5495), "peaches" },
                    { 25, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5475), "mangos.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5475), "mangos" },
                    { 2, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5394), "artichokes.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5394), "artichokes" },
                    { 3, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5408), "asparagus.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5408), "asparagus" },
                    { 4, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5411), "bananas.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5411), "bananas" },
                    { 5, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5414), "bell-peppers.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5414), "bell-peppers" },
                    { 6, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5418), "blueberries.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5418), "blueberries" },
                    { 7, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5421), "bok-choy.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5421), "bok-choy" },
                    { 26, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5478), "mangosteens.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5478), "mangosteens" },
                    { 9, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5427), "brussels-sprouts.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5427), "brussels-sprouts" },
                    { 10, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5430), "carrots.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5430), "carrots" },
                    { 11, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5433), "cherries.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5433), "cherries" },
                    { 12, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5436), "chilis.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5436), "chilis" },
                    { 13, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5439), "coconuts.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5439), "coconuts" },
                    { 8, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5425), "broccoli.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5425), "broccoli" },
                    { 15, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5445), "corn.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5445), "corn" },
                    { 16, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5448), "cucumbers.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5448), "cucumbers" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5451), "dragon-fruits.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5451), "dragon-fruits" },
                    { 18, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5454), "durians.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5454), "durians" },
                    { 19, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5457), "eggplants.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5457), "eggplants" },
                    { 20, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5460), "garlic.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5460), "garlic" },
                    { 21, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5463), "grapes.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5463), "grapes" },
                    { 22, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5466), "guavas.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5466), "guavas" },
                    { 23, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5469), "kiwis.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5469), "kiwis" },
                    { 24, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5472), "lemons.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5472), "lemons" },
                    { 14, new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5442), "coriander.svg", new DateTime(2021, 6, 1, 13, 37, 0, 999, DateTimeKind.Local).AddTicks(5442), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6624), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6624), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 10, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6608), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6608), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 9, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6593), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6593), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 8, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6578), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6578), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 7, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6563), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6563), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 1, new DateTime(2021, 6, 1, 13, 37, 0, 992, DateTimeKind.Local).AddTicks(1921), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 6, 1, 13, 37, 0, 992, DateTimeKind.Local).AddTicks(1921), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 5, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6532), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6532), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 4, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6514), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6514), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 3, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6486), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6486), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 2, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6188), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6188), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 12, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6639), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6639), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 6, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6547), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6547), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } },
                    { 13, new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6654), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 6, 1, 13, 37, 0, 996, DateTimeKind.Local).AddTicks(6654), new byte[] { 17, 72, 45, 198, 174, 228, 60, 186, 36, 68, 62, 156, 160, 98, 222, 2, 150, 38, 125, 2, 44, 224, 244, 108, 110, 96, 109, 252, 33, 106, 169, 95, 176, 67, 5, 203, 67, 190, 208, 49, 110, 222, 57, 2, 19, 222, 91, 222, 24, 20, 14, 29, 229, 242, 171, 208, 132, 233, 52, 58, 229, 42, 129, 120 }, new byte[] { 23, 200, 236, 205, 44, 102, 98, 18, 200, 126, 167, 202, 90, 222, 11, 183, 205, 196, 65, 242, 193, 23, 193, 68, 42, 201, 44, 28, 160, 107, 72, 1, 131, 5, 224, 152, 208, 3, 85, 234, 241, 235, 57, 96, 254, 180, 101, 111, 249, 212, 25, 195, 236, 14, 176, 193, 67, 229, 53, 147, 164, 14, 100, 245, 111, 116, 182, 10, 25, 224, 172, 107, 83, 17, 44, 131, 5, 243, 242, 152, 163, 142, 183, 113, 126, 166, 88, 165, 98, 104, 119, 47, 240, 1, 18, 36, 13, 115, 27, 221, 3, 78, 133, 188, 55, 13, 248, 236, 211, 77, 35, 148, 127, 253, 28, 142, 141, 2, 229, 204, 243, 224, 17, 244, 166, 67, 108, 254 } }
                });

            migrationBuilder.InsertData(
                table: "UserTradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 1, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(6137), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(6137), 1, 1 },
                    { 28, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7718), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7718), 37, 10 },
                    { 27, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7715), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7715), 35, 10 },
                    { 26, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7712), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7712), 10, 9 },
                    { 25, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7709), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7709), 12, 9 },
                    { 24, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7706), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7706), 11, 9 },
                    { 23, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7703), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7703), 21, 8 },
                    { 22, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7700), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7700), 20, 8 },
                    { 21, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7697), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7697), 7, 7 },
                    { 20, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7693), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7693), 5, 7 },
                    { 19, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7690), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7690), 1, 7 },
                    { 18, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7687), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7687), 12, 6 },
                    { 17, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7684), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7684), 11, 6 },
                    { 16, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7682), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7682), 10, 6 },
                    { 15, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7679), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7679), 3, 6 },
                    { 14, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7676), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7676), 2, 5 },
                    { 13, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7673), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7673), 1, 5 },
                    { 12, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7670), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7670), 22, 4 },
                    { 11, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7667), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7667), 21, 4 },
                    { 10, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7664), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7664), 20, 4 },
                    { 9, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7661), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7661), 7, 4 },
                    { 8, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7658), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7658), 5, 3 },
                    { 7, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7655), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7655), 1, 3 },
                    { 6, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7652), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7652), 12, 2 },
                    { 5, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7648), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7648), 11, 2 },
                    { 4, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7645), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7645), 10, 2 },
                    { 3, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7642), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7642), 3, 1 },
                    { 2, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7627), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7627), 2, 1 },
                    { 29, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7721), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7721), 30, 10 },
                    { 30, 50, new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7724), new DateTime(2021, 6, 1, 13, 37, 1, 0, DateTimeKind.Local).AddTicks(7724), 31, 10 }
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
