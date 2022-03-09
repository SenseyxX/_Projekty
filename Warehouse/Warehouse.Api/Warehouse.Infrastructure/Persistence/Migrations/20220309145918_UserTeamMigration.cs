using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Infrastructure.Migrations
{
    public partial class UserTeamMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Squads_SquadId",
                schema: "Warehouse",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Squads_SquadId",
                schema: "Warehouse",
                table: "Users",
                column: "SquadId",
                principalSchema: "Warehouse",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Squads_SquadId",
                schema: "Warehouse",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Squads_SquadId",
                schema: "Warehouse",
                table: "Users",
                column: "SquadId",
                principalSchema: "Warehouse",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
