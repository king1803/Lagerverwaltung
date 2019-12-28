using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagerverwaltung.Migrations
{
    public partial class ModelNrModellNummer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modellnr",
                table: "Ware");

            migrationBuilder.AddColumn<string>(
                name: "Modellnummer",
                table: "Ware",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modellnummer",
                table: "Ware");

            migrationBuilder.AddColumn<string>(
                name: "Modellnr",
                table: "Ware",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
