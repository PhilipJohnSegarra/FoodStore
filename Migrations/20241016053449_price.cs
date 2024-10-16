using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodStore.Migrations
{
    /// <inheritdoc />
    public partial class price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Food",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Food",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Food");
        }
    }
}
