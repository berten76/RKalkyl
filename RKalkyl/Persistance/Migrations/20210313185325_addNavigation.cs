using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class addNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_FoodItems_foodItemId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Meals_MealId",
                table: "Ingredient");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Meals",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "foodItemId",
                table: "Ingredient",
                newName: "FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_foodItemId",
                table: "Ingredient",
                newName: "IX_Ingredient_FoodItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FoodItems",
                newName: "FoodItemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "FoodItemId",
                table: "Ingredient",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MealId",
                table: "Ingredient",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_FoodItems_FoodItemId",
                table: "Ingredient",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "FoodItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Meals_MealId",
                table: "Ingredient",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_FoodItems_FoodItemId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Meals_MealId",
                table: "Ingredient");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "Meals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FoodItemId",
                table: "Ingredient",
                newName: "foodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_FoodItemId",
                table: "Ingredient",
                newName: "IX_Ingredient_foodItemId");

            migrationBuilder.RenameColumn(
                name: "FoodItemId",
                table: "FoodItems",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "MealId",
                table: "Ingredient",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "foodItemId",
                table: "Ingredient",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_FoodItems_foodItemId",
                table: "Ingredient",
                column: "foodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Meals_MealId",
                table: "Ingredient",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
