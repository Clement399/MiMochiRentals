using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiMochiRentals.Migrations
{
    /// <inheritdoc />
    public partial class decimal_orderVal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "orderVal",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 1,
                column: "orderVal",
                value: 15000m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 2,
                column: "orderVal",
                value: 8500m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 3,
                column: "orderVal",
                value: 22000m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 4,
                column: "orderVal",
                value: 12000m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 5,
                column: "orderVal",
                value: 18500m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "orderVal",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 1,
                column: "orderVal",
                value: 15000);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 2,
                column: "orderVal",
                value: 8500);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 3,
                column: "orderVal",
                value: 22000);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 4,
                column: "orderVal",
                value: 12000);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 5,
                column: "orderVal",
                value: 18500);
        }
    }
}
