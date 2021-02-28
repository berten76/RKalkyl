using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class RecepieAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecepieId",
                table: "FoodItems",
                type: "TEXT",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_Recepies_RecepieId",
                table: "FoodItems");

            migrationBuilder.DropTable(
                name: "Recepies");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_RecepieId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "RecepieId",
                table: "FoodItems");
        }
    }
}
