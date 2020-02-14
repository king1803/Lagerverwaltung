using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagerverwaltung.Migrations
{
    public partial class Kom2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Menge",
                table: "KommissionierungWaren",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Menge",
                table: "KommissionierungWaren");
        }
    }
}
