using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B.Tech.Migrations
{
    /// <inheritdoc />
    public partial class asdfghj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "product_Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "product_Orders",
                type: "int",
                nullable: true);
        }
    }
}
