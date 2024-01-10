using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomNomNosh.API.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteBehaviorCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_Recipe_Id",
                table: "RecipeSteps");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipes_Recipe_Id",
                table: "RecipeSteps",
                column: "Recipe_Id",
                principalTable: "Recipes",
                principalColumn: "Recipe_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_Recipe_Id",
                table: "RecipeSteps");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipes_Recipe_Id",
                table: "RecipeSteps",
                column: "Recipe_Id",
                principalTable: "Recipes",
                principalColumn: "Recipe_Id");
        }
    }
}
