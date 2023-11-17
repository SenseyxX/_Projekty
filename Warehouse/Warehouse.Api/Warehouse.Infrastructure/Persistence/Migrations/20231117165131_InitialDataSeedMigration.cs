using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Infrastructure.Migrations
{
    public partial class InitialDataSeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Warehouse",
                table: "Squads",
                columns: new[] { "Id", "Name", "SquadOwnerId", "State" },
                values: new object[] { new Guid("1a0e19f9-8e92-41a1-9e92-09c587caef05"), "Drużyna Oskara", new Guid("eab0a7ad-8542-4e1a-8dd3-a8391edbf5f4"), (byte)0 });

            migrationBuilder.InsertData(
                schema: "Warehouse",
                table: "Squads",
                columns: new[] { "Id", "Name", "SquadOwnerId", "State" },
                values: new object[] { new Guid("6251c1dc-58b9-43fa-bf01-098037d53bb6"), "Drużyna Szymka", new Guid("fa797f3e-b77a-4b92-a7e3-5aeba9aa4675"), (byte)0 });

            migrationBuilder.InsertData(
                schema: "Warehouse",
                table: "Squads",
                columns: new[] { "Id", "Name", "SquadOwnerId", "State" },
                values: new object[] { new Guid("c7d09645-cf24-4aca-93c1-96e8c97e4286"), "Drużyna Olka", new Guid("321a719b-b778-485f-8432-11f0f038cbce"), (byte)0 });

            migrationBuilder.InsertData(
                schema: "Warehouse",
                table: "Teams",
                columns: new[] { "Id", "Description", "Name", "Points", "SquadId", "State", "TeamOwnerId" },
                values: new object[] { new Guid("296f60db-9f13-48f3-853f-343de5ebdd20"), "Opis zastępu Oskara", "Zastęp Oskara", (byte)1, new Guid("1a0e19f9-8e92-41a1-9e92-09c587caef05"), 0, new Guid("eab0a7ad-8542-4e1a-8dd3-a8391edbf5f4") });

            migrationBuilder.InsertData(
                schema: "Warehouse",
                table: "Teams",
                columns: new[] { "Id", "Description", "Name", "Points", "SquadId", "State", "TeamOwnerId" },
                values: new object[] { new Guid("f7921a66-83b4-451d-8556-893882233118"), "Opis zastępu Szymka", "Zastęp Szymka", (byte)1, new Guid("6251c1dc-58b9-43fa-bf01-098037d53bb6"), 0, new Guid("fa797f3e-b77a-4b92-a7e3-5aeba9aa4675") });

            migrationBuilder.InsertData(
                schema: "Warehouse",
                table: "Teams",
                columns: new[] { "Id", "Description", "Name", "Points", "SquadId", "State", "TeamOwnerId" },
                values: new object[] { new Guid("d1401039-21d8-4a83-97e1-67dd2201e4a1"), "Opis zastępu Olka", "Zastęp Olka", (byte)1, new Guid("c7d09645-cf24-4aca-93c1-96e8c97e4286"), 0, new Guid("321a719b-b778-485f-8432-11f0f038cbce") });

            migrationBuilder.InsertData(
                schema: "Warehouse",
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "PasswordHash", "PermissionLevel", "PhoneNumber", "SquadId", "State", "TeamId" },
                values: new object[,]
                {
                    { new Guid("eab0a7ad-8542-4e1a-8dd3-a8391edbf5f4"), "ogacki", "Gacki", "Oskar", new byte[] { 68, 249, 238, 1, 181, 104, 102, 91, 134, 226, 253, 16, 26, 55, 105, 89, 250, 56, 154, 177, 202, 39, 221, 156, 116, 142, 202, 202, 29, 179, 124, 94, 242, 0, 190, 209, 190, 147, 126, 253, 192, 28, 69, 125, 101, 197, 170, 130, 2, 17, 59, 75, 117, 94, 108, 243, 111, 38, 181, 189, 34, 169, 222, 90, 179, 114, 204, 223, 164, 187, 4, 159, 48, 113, 80, 98, 67, 245, 223, 21, 231, 28, 35, 226, 187, 85, 103, 177, 236, 21, 197, 99, 71, 152, 217, 187, 73, 67, 233, 114, 179, 244, 76, 143, 168, 59, 62, 232, 92, 44, 110, 136, 45, 55, 222, 93, 165, 45, 188, 51, 216, 9, 144, 102, 128, 173, 14, 64 }, (byte)0, "888888888", new Guid("1a0e19f9-8e92-41a1-9e92-09c587caef05"), (byte)0, new Guid("296f60db-9f13-48f3-853f-343de5ebdd20") },
                    { new Guid("071c18c6-93e1-40ef-ae43-bdb3c8f2aab6"), "akijowski", "Patoń", "Wojtek", new byte[] { 172, 176, 251, 90, 203, 48, 72, 183, 112, 175, 85, 250, 142, 169, 61, 166, 123, 95, 136, 235, 94, 146, 145, 167, 36, 25, 232, 130, 65, 52, 136, 217, 152, 52, 139, 249, 218, 12, 14, 1, 200, 47, 41, 109, 173, 91, 216, 33, 54, 41, 121, 46, 2, 164, 152, 164, 45, 191, 97, 57, 233, 6, 94, 248, 166, 223, 157, 150, 252, 108, 86, 84, 0, 164, 86, 23, 234, 238, 170, 185, 66, 153, 30, 165, 9, 142, 232, 140, 161, 120, 255, 104, 59, 223, 248, 34, 124, 54, 87, 169, 239, 197, 250, 8, 3, 20, 72, 39, 25, 155, 198, 66, 67, 49, 220, 236, 187, 206, 78, 12, 107, 193, 190, 94, 88, 1, 230, 30 }, (byte)0, "666666666", new Guid("1a0e19f9-8e92-41a1-9e92-09c587caef05"), (byte)0, new Guid("296f60db-9f13-48f3-853f-343de5ebdd20") },
                    { new Guid("fa797f3e-b77a-4b92-a7e3-5aeba9aa4675"), "skatryniok", "Katryniok", "Szymon", new byte[] { 191, 241, 96, 125, 56, 97, 233, 246, 197, 216, 233, 108, 42, 120, 122, 50, 77, 174, 44, 208, 110, 8, 67, 205, 183, 246, 150, 74, 61, 106, 243, 87, 217, 28, 43, 87, 229, 85, 53, 163, 25, 113, 36, 184, 171, 92, 117, 93, 147, 84, 100, 220, 167, 2, 150, 198, 180, 229, 119, 41, 33, 219, 70, 124, 215, 71, 130, 36, 220, 43, 56, 179, 207, 1, 182, 128, 75, 166, 83, 81, 65, 131, 134, 247, 236, 9, 158, 20, 169, 25, 245, 218, 24, 68, 19, 104, 84, 125, 6, 39, 170, 72, 166, 15, 61, 143, 128, 110, 206, 174, 5, 233, 221, 1, 196, 155, 239, 146, 127, 197, 115, 67, 185, 242, 230, 29, 142, 177 }, (byte)0, "999999999", new Guid("6251c1dc-58b9-43fa-bf01-098037d53bb6"), (byte)0, new Guid("f7921a66-83b4-451d-8556-893882233118") },
                    { new Guid("321a719b-b778-485f-8432-11f0f038cbce"), "akijowski", "Kijowski", "Aleksander", new byte[] { 235, 166, 147, 103, 147, 151, 125, 46, 69, 126, 64, 158, 10, 107, 134, 177, 208, 2, 98, 14, 135, 64, 142, 93, 74, 153, 91, 48, 186, 155, 78, 31, 29, 166, 6, 225, 25, 149, 173, 205, 11, 250, 219, 82, 163, 165, 180, 234, 194, 166, 172, 42, 214, 101, 113, 134, 100, 3, 203, 19, 72, 148, 163, 84, 146, 182, 38, 142, 121, 237, 11, 220, 253, 211, 179, 150, 239, 2, 47, 210, 168, 67, 110, 207, 45, 209, 227, 186, 176, 217, 234, 55, 211, 237, 115, 166, 46, 245, 99, 210, 33, 23, 48, 11, 193, 242, 95, 198, 129, 116, 46, 191, 186, 159, 5, 1, 172, 128, 9, 30, 237, 45, 60, 221, 37, 196, 41, 176 }, (byte)0, "777777777", new Guid("c7d09645-cf24-4aca-93c1-96e8c97e4286"), (byte)0, new Guid("d1401039-21d8-4a83-97e1-67dd2201e4a1") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Warehouse",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("071c18c6-93e1-40ef-ae43-bdb3c8f2aab6"));

            migrationBuilder.DeleteData(
                schema: "Warehouse",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("321a719b-b778-485f-8432-11f0f038cbce"));

            migrationBuilder.DeleteData(
                schema: "Warehouse",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eab0a7ad-8542-4e1a-8dd3-a8391edbf5f4"));

            migrationBuilder.DeleteData(
                schema: "Warehouse",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fa797f3e-b77a-4b92-a7e3-5aeba9aa4675"));

            migrationBuilder.DeleteData(
                schema: "Warehouse",
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("296f60db-9f13-48f3-853f-343de5ebdd20"));

            migrationBuilder.DeleteData(
                schema: "Warehouse",
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("d1401039-21d8-4a83-97e1-67dd2201e4a1"));

            migrationBuilder.DeleteData(
                schema: "Warehouse",
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("f7921a66-83b4-451d-8556-893882233118"));

            migrationBuilder.DeleteData(
                schema: "Warehouse",
                table: "Squads",
                keyColumn: "Id",
                keyValue: new Guid("1a0e19f9-8e92-41a1-9e92-09c587caef05"));

            migrationBuilder.DeleteData(
                schema: "Warehouse",
                table: "Squads",
                keyColumn: "Id",
                keyValue: new Guid("6251c1dc-58b9-43fa-bf01-098037d53bb6"));

            migrationBuilder.DeleteData(
                schema: "Warehouse",
                table: "Squads",
                keyColumn: "Id",
                keyValue: new Guid("c7d09645-cf24-4aca-93c1-96e8c97e4286"));
        }
    }
}
