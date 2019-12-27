using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagerverwaltung.Migrations
{
    public partial class Luk_Lind_DBModell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hersteller",
                columns: table => new
                {
                    Hersteller_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Hersteller_Beschreibung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hersteller", x => x.Hersteller_Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Kategorie_Name = table.Column<string>(nullable: false),
                    Kategorie_Beschreibung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Kategorie_Name);
                });

            migrationBuilder.CreateTable(
                name: "Kostenstelle",
                columns: table => new
                {
                    Kostenstelle_Nr = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Kostenstelle_Beschreibung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kostenstelle", x => x.Kostenstelle_Nr);
                });

            migrationBuilder.CreateTable(
                name: "Lager",
                columns: table => new
                {
                    Lager_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Lager_Beschreibung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lager", x => x.Lager_Id);
                });

            migrationBuilder.CreateTable(
                name: "Lieferant",
                columns: table => new
                {
                    Lieferant_Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Lieferant_Beschreibung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lieferant", x => x.Lieferant_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hersteller");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Kostenstelle");

            migrationBuilder.DropTable(
                name: "Lager");

            migrationBuilder.DropTable(
                name: "Lieferant");
        }
    }
}
