using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B.Tech.Migrations
{
    /// <inheritdoc />
    public partial class tryone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderNumber",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderNumber",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "Products",
                newName: "Discount");

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "product_Orders",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "product_Orders");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Products",
                newName: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderNumber",
                table: "Products",
                column: "OrderNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderNumber",
                table: "Products",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber");
        }
    }
}
