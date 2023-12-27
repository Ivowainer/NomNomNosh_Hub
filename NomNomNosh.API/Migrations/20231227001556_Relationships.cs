using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomNomNosh.API.Migrations
{
    /// <inheritdoc />
    public partial class Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeComments",
                columns: table => new
                {
                    RecipeComment_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Recipe_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Member_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeComment_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeComment_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeComments", x => x.RecipeComment_Id);
                    table.ForeignKey(
                        name: "FK_RecipeComments_Members_Member_Id",
                        column: x => x.Member_Id,
                        principalTable: "Members",
                        principalColumn: "Member_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeComments_Recipes_Recipe_Id",
                        column: x => x.Recipe_Id,
                        principalTable: "Recipes",
                        principalColumn: "Recipe_Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeImages",
                columns: table => new
                {
                    RecipeImage_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Recipe_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeImages", x => x.RecipeImage_Id);
                    table.ForeignKey(
                        name: "FK_RecipeImages_Recipes_Recipe_Id",
                        column: x => x.Recipe_Id,
                        principalTable: "Recipes",
                        principalColumn: "Recipe_Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeRates",
                columns: table => new
                {
                    RecipeRate_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Recipe_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Member_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRates", x => x.RecipeRate_Id);
                    table.ForeignKey(
                        name: "FK_RecipeRates_Members_Member_Id",
                        column: x => x.Member_Id,
                        principalTable: "Members",
                        principalColumn: "Member_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeRates_Recipes_Recipe_Id",
                        column: x => x.Recipe_Id,
                        principalTable: "Recipes",
                        principalColumn: "Recipe_Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeSaved",
                columns: table => new
                {
                    RecipeSaved_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Recipe_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Member_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSaved", x => x.RecipeSaved_Id);
                    table.ForeignKey(
                        name: "FK_RecipeSaved_Members_Member_Id",
                        column: x => x.Member_Id,
                        principalTable: "Members",
                        principalColumn: "Member_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeSaved_Recipes_Recipe_Id",
                        column: x => x.Recipe_Id,
                        principalTable: "Recipes",
                        principalColumn: "Recipe_Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeSteps",
                columns: table => new
                {
                    RecipeStep_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Recipe_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeSteps", x => x.RecipeStep_Id);
                    table.ForeignKey(
                        name: "FK_RecipeSteps_Recipes_Recipe_Id",
                        column: x => x.Recipe_Id,
                        principalTable: "Recipes",
                        principalColumn: "Recipe_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeComments_Member_Id",
                table: "RecipeComments",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeComments_Recipe_Id",
                table: "RecipeComments",
                column: "Recipe_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeImages_Recipe_Id",
                table: "RecipeImages",
                column: "Recipe_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRates_Member_Id",
                table: "RecipeRates",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRates_Recipe_Id",
                table: "RecipeRates",
                column: "Recipe_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSaved_Member_Id",
                table: "RecipeSaved",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSaved_Recipe_Id",
                table: "RecipeSaved",
                column: "Recipe_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_Recipe_Id",
                table: "RecipeSteps",
                column: "Recipe_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeComments");

            migrationBuilder.DropTable(
                name: "RecipeImages");

            migrationBuilder.DropTable(
                name: "RecipeRates");

            migrationBuilder.DropTable(
                name: "RecipeSaved");

            migrationBuilder.DropTable(
                name: "RecipeSteps");
        }
    }
}
