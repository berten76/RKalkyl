using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class ChangeFromIngredientToMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recepies_RecepieId",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "Recepies");

            migrationBuilder.RenameColumn(
                name: "RecepieId",
                table: "Ingredient",
                newName: "MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_RecepieId",
                table: "Ingredient",
                newName: "IX_Ingredient_MealId");

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Meals_MealId",
                table: "Ingredient",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Meals_MealId",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "Ingredient",
                newName: "RecepieId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_MealId",
                table: "Ingredient",
                newName: "IX_Ingredient_RecepieId");

            migrationBuilder.CreateTable(
                name: "Recepies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepies", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recepies_RecepieId",
                table: "Ingredient",
                column: "RecepieId",
                principalTable: "Recepies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
