using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagerverwaltung.Migrations
{
    public partial class Auftragsnummer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Auftragsnummer",
                table: "Ware",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auftragsnummer",
                table: "Ware");
        }
    }
}
