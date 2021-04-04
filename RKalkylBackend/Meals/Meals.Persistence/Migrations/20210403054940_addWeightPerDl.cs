using Microsoft.EntityFrameworkCore.Migrations;

namespace Meals.Persistence.Migrations
{
    public partial class addWeightPerDl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeightPerDl",
                table: "FoodItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeightPerItem",
                table: "FoodItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeightPerDl",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "WeightPerItem",
                table: "FoodItems");
        }
    }
}
