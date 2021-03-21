using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class ChangeIngredience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_MealId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ingredient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                columns: new[] { "MealId", "FoodItemId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Ingredient",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_MealId",
                table: "Ingredient",
                column: "MealId");
        }
    }
}
