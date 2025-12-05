using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiMochiRentals.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderID = table.Column<string>(type: "TEXT", nullable: false),
                    receiptNo = table.Column<string>(type: "TEXT", nullable: false),
                    customerID = table.Column<string>(type: "TEXT", nullable: false),
                    orderVal = table.Column<int>(type: "INTEGER", nullable: false),
                    bond = table.Column<int>(type: "INTEGER", nullable: false),
                    paid = table.Column<bool>(type: "INTEGER", nullable: false),
                    bondReturned = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderID);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    code = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    genre = table.Column<string>(type: "TEXT", nullable: false),
                    isSet = table.Column<bool>(type: "INTEGER", nullable: false),
                    totalQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<int>(type: "INTEGER", nullable: false),
                    bond = table.Column<int>(type: "INTEGER", nullable: false),
                    sHeight = table.Column<double>(type: "REAL", nullable: false),
                    sWidth = table.Column<double>(type: "REAL", nullable: false),
                    sLength = table.Column<double>(type: "REAL", nullable: false),
                    weight = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemTypeCode = table.Column<string>(type: "TEXT", nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<int>(type: "INTEGER", nullable: false),
                    bond = table.Column<int>(type: "INTEGER", nullable: false),
                    startDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    orderID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_Items_Orders_orderID",
                        column: x => x.orderID,
                        principalTable: "Orders",
                        principalColumn: "orderID");
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "code", "bond", "genre", "isSet", "name", "price", "sHeight", "sLength", "sWidth", "totalQuantity", "type", "weight" },
                values: new object[,]
                {
                    { "bbs-cb-001", 50, "birthday", false, "baby-shark", 50, 1.0, 1.0, 1.0, 1, "circle-board", 0.0 },
                    { "bbs-dt-001", 1, "birthday", false, "baby-shark", 1, 1.0, 1.0, 1.0, 1, "dessert-table", 0.0 },
                    { "blu-cb-001", 50, "birthday", false, "bluey", 50, 1.0, 1.0, 1.0, 1, "circle-board", 0.0 },
                    { "blu-dt-001", 100, "birthday", false, "bluey", 100, 1.0, 1.0, 1.0, 1, "dessert-table", 0.0 },
                    { "cm-cb-001", 50, "birthday", false, "cocomelon", 50, 1.0, 1.0, 1.0, 1, "circle-board", 0.0 },
                    { "cm-dt-001", 1, "birthday", false, "cocomelon", 1, 1.0, 1.0, 1.0, 1, "dessert-table", 0.0 },
                    { "cm-tb-001", 50, "birthday", false, "cocomelon", 60, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "cm-tb-002", 50, "birthday", false, "cocomelon", 50, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "cm-tb-003", 50, "birthday", false, "cocomelon", 50, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "frz-tb-001", 50, "birthday", false, "frozen", 60, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "frz-tb-002", 50, "birthday", false, "frozen", 50, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "frz-tb-003", 50, "birthday", false, "frozen", 50, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "mc-cb-001", 50, "birthday", false, "minecraft", 50, 1.0, 1.0, 1.0, 1, "circle-board", 0.0 },
                    { "mc-dt-001", 1, "birthday", false, "minecraft", 1, 1.0, 1.0, 1.0, 1, "dessert-table", 0.0 },
                    { "mlp-ra-001", 100, "birthday", false, "my-little-pony", 60, 1.0, 1.0, 1.0, 1, "rainbow-arc", 0.0 },
                    { "mlp-ra-002", 100, "birthday", false, "my-little-pony", 60, 1.0, 1.0, 1.0, 1, "rainbow-arc", 0.0 },
                    { "mlp-ra-003", 100, "birthday", false, "my-little-pony", 120, 1.0, 1.0, 1.0, 1, "rainbow-arc", 0.0 },
                    { "mlp-tb-001", 50, "birthday", false, "my-little-pony", 60, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "mlp-tb-002", 50, "birthday", false, "my-little-pony", 50, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "mlp-tb-003", 100, "birthday", false, "my-little-pony", 100, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "pep-cb-001", 50, "birthday", false, "peppa-pig", 50, 1.0, 1.0, 1.0, 1, "circle-board", 0.0 },
                    { "pep-dt-001", 1, "birthday", false, "peppa-pig", 1, 1.0, 1.0, 1.0, 1, "dessert-table", 0.0 },
                    { "pep-tb-001", 50, "birthday", false, "peppa-pig", 60, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "pep-tb-002", 50, "birthday", false, "peppa-pig", 50, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "pep-tb-003", 50, "birthday", false, "peppa-pig", 50, 1.0, 1.0, 1.0, 1, "theme-board", 0.0 },
                    { "spi-cb-001", 50, "birthday", false, "spidey", 50, 1.0, 1.0, 1.0, 1, "circle-board", 0.0 },
                    { "spi-dt-001", 1, "birthday", false, "spi", 1, 1.0, 1.0, 1.0, 1, "dessert-table", 0.0 },
                    { "w-background-001", 100, "wedding", false, "floral-background", 120, 1.0, 1.0, 1.0, 2, "floral-background", 0.0 },
                    { "w-carpet-001", 100, "wedding", false, "carpet", 80, 1.0, 1.0, 1.0, 1, "carpet", 0.0 },
                    { "w-chaffing-001", 100, "wedding", false, "chaffing-dish", 10, 1.0, 1.0, 1.0, 10, "chaffing dish", 0.0 },
                    { "w-chair-001", 100, "wedding", false, "chair", 3, 1.0, 1.0, 1.0, 100, "chair", 0.0 },
                    { "w-dessert-001", 100, "wedding", false, "dessert-table", 100, 1.0, 1.0, 1.0, 1, "dessert-table", 0.0 },
                    { "w-floralArch-001", 100, "wedding", false, "floral-arch", 160, 1.0, 1.0, 1.0, 1, "floral-arch", 0.0 },
                    { "w-set-001", 100, "wedding", true, "wedding-fullset", 900, 1.0, 1.0, 1.0, 1, "fullset", 0.0 },
                    { "w-steelArch-001", 100, "wedding", false, "steel-arch", 70, 1.0, 1.0, 1.0, 3, "steel-arch", 0.0 },
                    { "w-table-blue-001", 50, "wedding", false, "table-blue", 10, 1.0, 1.0, 1.0, 2, "table", 0.0 },
                    { "w-table-white-001", 50, "wedding", false, "table-white", 10, 1.0, 1.0, 1.0, 2, "table", 0.0 },
                    { "w-tent-001", 100, "wedding", false, "tent", 60, 1.0, 1.0, 1.0, 3, "tent", 0.0 },
                    { "w-woodenArch-001", 100, "wedding", false, "wooden-arch", 100, 1.0, 1.0, 1.0, 1, "wooden-arch", 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_itemId",
                table: "Items",
                column: "itemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_orderID",
                table: "Items",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_receiptNo",
                table: "Orders",
                column: "receiptNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Types_code",
                table: "Types",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
