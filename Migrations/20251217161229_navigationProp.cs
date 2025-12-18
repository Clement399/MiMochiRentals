using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiMochiRentals.Migrations
{
    /// <inheritdoc />
    public partial class navigationProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderID1",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 1,
                column: "orderID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 2,
                column: "orderID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 3,
                column: "orderID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 4,
                column: "orderID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 5,
                column: "orderID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 6,
                column: "orderID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 7,
                column: "orderID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 8,
                column: "orderID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 9,
                column: "orderID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 10,
                column: "orderID1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Items_orderID1",
                table: "Items",
                column: "orderID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_orderID1",
                table: "Items",
                column: "orderID1",
                principalTable: "Orders",
                principalColumn: "orderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_orderID1",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_orderID1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "orderID1",
                table: "Items");
        }
    }
}
