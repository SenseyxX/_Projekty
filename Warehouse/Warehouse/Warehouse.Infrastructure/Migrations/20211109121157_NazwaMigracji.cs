using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Infrastructure.Migrations
{
    public partial class NazwaMigracji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryState",
                schema: "Warehouse",
                table: "Users",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "CategoryState",
                schema: "Warehouse",
                table: "Teams",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "CategoryState",
                schema: "Warehouse",
                table: "Squads",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "CategoryState",
                schema: "Warehouse",
                table: "Items",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "CategoryState",
                schema: "Warehouse",
                table: "Category",
                newName: "State");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                schema: "Warehouse",
                table: "Users",
                newName: "CategoryState");

            migrationBuilder.RenameColumn(
                name: "State",
                schema: "Warehouse",
                table: "Teams",
                newName: "CategoryState");

            migrationBuilder.RenameColumn(
                name: "State",
                schema: "Warehouse",
                table: "Squads",
                newName: "CategoryState");

            migrationBuilder.RenameColumn(
                name: "State",
                schema: "Warehouse",
                table: "Items",
                newName: "CategoryState");

            migrationBuilder.RenameColumn(
                name: "State",
                schema: "Warehouse",
                table: "Category",
                newName: "CategoryState");
        }
    }
}
