using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B.Tech.Migrations
{
    /// <inheritdoc />
    public partial class aaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Orders_Products_ProductID",
                table: "product_Orders");

            migrationBuilder.DropIndex(
                name: "IX_product_Orders_ProductID",
                table: "product_Orders");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "product_Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_product_Orders_Products_PrdId",
                table: "product_Orders",
                column: "PrdId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Orders_Products_PrdId",
                table: "product_Orders");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "product_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_product_Orders_ProductID",
                table: "product_Orders",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_product_Orders_Products_ProductID",
                table: "product_Orders",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
