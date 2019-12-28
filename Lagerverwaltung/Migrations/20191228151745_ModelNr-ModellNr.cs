using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagerverwaltung.Migrations
{
    public partial class ModelNrModellNr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modelnr_hi",
                table: "WareHistorie");

            migrationBuilder.AddColumn<string>(
                name: "Modellnr_hi",
                table: "WareHistorie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modellnr_hi",
                table: "WareHistorie");

            migrationBuilder.AddColumn<string>(
                name: "Modelnr_hi",
                table: "WareHistorie",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
