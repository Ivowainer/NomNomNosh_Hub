using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomNomNosh.API.Migrations
{
    /// <inheritdoc />
    public partial class OnCascadeRecipeComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeComments_Members_Member_Id",
                table: "RecipeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeComments_Recipes_Recipe_Id",
                table: "RecipeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_Recipe_Id",
                table: "RecipeSteps");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeComments_Members_Member_Id",
                table: "RecipeComments",
                column: "Member_Id",
                principalTable: "Members",
                principalColumn: "Member_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeComments_Recipes_Recipe_Id",
                table: "RecipeComments",
                column: "Recipe_Id",
                principalTable: "Recipes",
                principalColumn: "Recipe_Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_RecipeComments_Members_Member_Id",
                table: "RecipeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeComments_Recipes_Recipe_Id",
                table: "RecipeComments");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_Recipe_Id",
                table: "RecipeSteps");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeComments_Members_Member_Id",
                table: "RecipeComments",
                column: "Member_Id",
                principalTable: "Members",
                principalColumn: "Member_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeComments_Recipes_Recipe_Id",
                table: "RecipeComments",
                column: "Recipe_Id",
                principalTable: "Recipes",
                principalColumn: "Recipe_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipes_Recipe_Id",
                table: "RecipeSteps",
                column: "Recipe_Id",
                principalTable: "Recipes",
                principalColumn: "Recipe_Id");
        }
    }
}
