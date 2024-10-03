using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodStore.Migrations
{
    /// <inheritdoc />
    public partial class relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_FoodCategory_CategoryFoodCatId",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_CategoryFoodCatId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "CategoryFoodCatId",
                table: "Food");

            migrationBuilder.CreateIndex(
                name: "IX_Food_FoodCatId",
                table: "Food",
                column: "FoodCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_FoodCategory_FoodCatId",
                table: "Food",
                column: "FoodCatId",
                principalTable: "FoodCategory",
                principalColumn: "FoodCatId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_FoodCategory_FoodCatId",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_FoodCatId",
                table: "Food");

            migrationBuilder.AddColumn<int>(
                name: "CategoryFoodCatId",
                table: "Food",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_CategoryFoodCatId",
                table: "Food",
                column: "CategoryFoodCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_FoodCategory_CategoryFoodCatId",
                table: "Food",
                column: "CategoryFoodCatId",
                principalTable: "FoodCategory",
                principalColumn: "FoodCatId");
        }
    }
}
