using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mag.Migrations
{
    public partial class AddRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoansHistoriesId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loanHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    LastOwnerId = table.Column<int>(type: "int", nullable: false),
                    ActualOwnerId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loanHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "qualities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qualities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ActualOwnerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryForeignKey = table.Column<int>(type: "int", nullable: true),
                    LoansHistoriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_items_categories_CategoryForeignKey",
                        column: x => x.CategoryForeignKey,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_items_loanHistories_LoansHistoriesId",
                        column: x => x.LoansHistoriesId,
                        principalTable: "loanHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_items_qualities_QualityId",
                        column: x => x.QualityId,
                        principalTable: "qualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_ItemId",
                table: "users",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_users_LoansHistoriesId",
                table: "users",
                column: "LoansHistoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_items_CategoryForeignKey",
                table: "items",
                column: "CategoryForeignKey",
                unique: true,
                filter: "[CategoryForeignKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_items_LoansHistoriesId",
                table: "items",
                column: "LoansHistoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_items_QualityId",
                table: "items",
                column: "QualityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_items_ItemId",
                table: "users",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_loanHistories_LoansHistoriesId",
                table: "users",
                column: "LoansHistoriesId",
                principalTable: "loanHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_items_ItemId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_loanHistories_LoansHistoriesId",
                table: "users");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "loanHistories");

            migrationBuilder.DropTable(
                name: "qualities");

            migrationBuilder.DropIndex(
                name: "IX_users_ItemId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_LoansHistoriesId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LoansHistoriesId",
                table: "users");
        }
    }
}
