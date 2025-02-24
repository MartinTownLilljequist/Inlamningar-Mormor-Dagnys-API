using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eshop.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrdersFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItems");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "OrderItems",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "OrderItems");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "OrderItems",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
