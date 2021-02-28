using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class IngredientAded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_Recepies_RecepieId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_RecepieId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "RecepieId",
                table: "FoodItems");

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    foodItemId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AmountInGram = table.Column<int>(type: "INTEGER", nullable: false),
                    RecepieId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_FoodItems_foodItemId",
                        column: x => x.foodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredient_Recepies_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "Recepies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_foodItemId",
                table: "Ingredient",
                column: "foodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecepieId",
                table: "Ingredient",
                column: "RecepieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.AddColumn<Guid>(
                name: "RecepieId",
                table: "FoodItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_RecepieId",
                table: "FoodItems",
                column: "RecepieId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_Recepies_RecepieId",
                table: "FoodItems",
                column: "RecepieId",
                principalTable: "Recepies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
