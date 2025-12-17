using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiMochiRentals.Migrations
{
    /// <inheritdoc />
    public partial class orderIDItemFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_orderID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_orderID",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "orderID",
                table: "Items",
                newName: "orderId");

            migrationBuilder.AlterColumn<string>(
                name: "orderId",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "orderID",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeCode",
                table: "Items",
                column: "ItemTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Items_orderID",
                table: "Items",
                column: "orderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_orderID",
                table: "Items",
                column: "orderID",
                principalTable: "Orders",
                principalColumn: "orderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Types_ItemTypeCode",
                table: "Items",
                column: "ItemTypeCode",
                principalTable: "Types",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_orderID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Types_ItemTypeCode",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemTypeCode",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_orderID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "orderID",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Items",
                newName: "orderID");

            migrationBuilder.AlterColumn<string>(
                name: "orderID",
                table: "Items",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Items_orderID",
                table: "Items",
                column: "orderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_orderID",
                table: "Items",
                column: "orderID",
                principalTable: "Orders",
                principalColumn: "orderID");
        }
    }
}
