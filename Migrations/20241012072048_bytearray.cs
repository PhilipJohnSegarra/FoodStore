using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodStore.Migrations
{
    /// <inheritdoc />
    public partial class bytearray : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Food");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Food",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Food");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Food",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
