using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagerverwaltung.Migrations
{
    public partial class Kom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kommissionierung",
                columns: table => new
                {
                    Kom_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Beschreibung = table.Column<string>(nullable: true),
                    User_Id = table.Column<string>(nullable: true),
                    Erstelldatum = table.Column<DateTime>(nullable: false),
                    Abschlussdatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommissionierung", x => x.Kom_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kommissionierung");
        }
    }
}
