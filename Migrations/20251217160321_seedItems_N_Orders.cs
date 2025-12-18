using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiMochiRentals.Migrations
{
    /// <inheritdoc />
    public partial class seedItems_N_Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "orderID", "bond", "bondReturned", "customerID", "orderVal", "paid", "receiptNo" },
                values: new object[,]
                {
                    { 1, 5000, false, 1, 15000, true, 1 },
                    { 2, 3000, true, 1, 8500, true, 2 },
                    { 3, 7500, false, 3, 22000, false, 3 },
                    { 4, 4000, true, 2, 12000, true, 4 },
                    { 5, 6000, false, 3, 18500, true, 5 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "itemId", "ItemTypeCode", "bond", "endDate", "endPeriod", "orderID", "price", "quantity", "startDate", "startPeriod" },
                values: new object[,]
                {
                    { 1, "w-set-001", 100, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 900, 1, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "w-chair-001", 50, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, 50, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "blu-cb-001", 50, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 50, 1, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "blu-dt-001", 100, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 100, 1, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, "w-tent-001", 100, new DateTime(2025, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 60, 2, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "w-floralArch-001", 100, new DateTime(2025, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 160, 1, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "mc-cb-001", 50, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 50, 1, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, "mc-dt-001", 1, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1, 1, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, "mlp-ra-003", 100, new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 120, 1, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, "mlp-tb-001", 50, new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 60, 1, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "itemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "orderID",
                keyValue: 5);
        }
    }
}
