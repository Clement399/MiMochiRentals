using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiMochiRentals.Migrations
{
    /// <inheritdoc />
    public partial class Pending : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "payment",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 1,
                column: "payment",
                value: "pending");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 2,
                column: "payment",
                value: "pending");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 3,
                column: "payment",
                value: "pending");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 4,
                column: "payment",
                value: "pending");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 5,
                column: "payment",
                value: "pending");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payment",
                table: "Orders");
        }
    }
}
