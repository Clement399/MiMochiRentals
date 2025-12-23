using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiMochiRentals.Migrations
{
    /// <inheritdoc />
    public partial class ReceiptNo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_receiptNo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "receiptNo",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_orderID",
                table: "Orders",
                column: "orderID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_orderID",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "receiptNo",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 1,
                column: "receiptNo",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 2,
                column: "receiptNo",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 3,
                column: "receiptNo",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 4,
                column: "receiptNo",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 5,
                column: "receiptNo",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_receiptNo",
                table: "Orders",
                column: "receiptNo",
                unique: true);
        }
    }
}
