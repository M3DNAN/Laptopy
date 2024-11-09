using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Laptopy.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Description", "Discount", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Dell XPS 13 with Intel i7, 16GB RAM, and 512GB SSD.", 0.1m, "XPS 13", "Dell XPS 13", 999.99m },
                    { 2, 1, "Apple MacBook Air with M1 chip, 8GB RAM, and 256GB SSD.", 0.15m, "MacBook Air", "MacBook Air M1", 1199.99m },
                    { 3, 1, "HP Spectre x360 with Intel i7, 16GB RAM, and 512GB SSD.", 0.2m, "Spectre x360", "HP Spectre x360", 1099.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
