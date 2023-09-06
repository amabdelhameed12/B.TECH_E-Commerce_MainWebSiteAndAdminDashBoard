using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B.Tech.Migrations
{
    /// <inheritdoc />
    public partial class trytwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Orders_Products_PrdId",
                table: "product_Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "product_Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "PrdId",
                table: "product_Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "product_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_Orders_Products_ProductID",
                table: "product_Orders");

            migrationBuilder.DropIndex(
                name: "IX_product_Orders_ProductID",
                table: "product_Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "product_Orders");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "product_Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "product_Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "PrdId",
                table: "product_Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddForeignKey(
                name: "FK_product_Orders_Products_PrdId",
                table: "product_Orders",
                column: "PrdId",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
