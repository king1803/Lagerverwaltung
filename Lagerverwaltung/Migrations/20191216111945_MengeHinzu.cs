using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagerverwaltung.Migrations
{
    public partial class MengeHinzu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ware_Lagerplatz_Lagerplatz_Id1",
                table: "Ware");

            migrationBuilder.DropIndex(
                name: "IX_Ware_Lagerplatz_Id1",
                table: "Ware");

            migrationBuilder.DropColumn(
                name: "Lagerplatz_Id1",
                table: "Ware");

            migrationBuilder.AddColumn<decimal>(
                name: "Menge",
                table: "Ware",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Menge",
                table: "Ware");

            migrationBuilder.AddColumn<int>(
                name: "Lagerplatz_Id1",
                table: "Ware",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ware_Lagerplatz_Id1",
                table: "Ware",
                column: "Lagerplatz_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ware_Lagerplatz_Lagerplatz_Id1",
                table: "Ware",
                column: "Lagerplatz_Id1",
                principalTable: "Lagerplatz",
                principalColumn: "Lagerplatz_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
