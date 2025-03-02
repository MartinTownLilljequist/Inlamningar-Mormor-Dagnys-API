﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eshop.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class FindOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SalesOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SalesOrders");
        }
    }
}
