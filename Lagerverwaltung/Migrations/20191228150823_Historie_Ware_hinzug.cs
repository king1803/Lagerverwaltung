using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lagerverwaltung.Migrations
{
    public partial class Historie_Ware_hinzug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WareHistorie",
                columns: table => new
                {
                    Ware_Id_hi = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ware_Beschreibung_hi = table.Column<string>(nullable: true),
                    Ware_Einlagerungsdatum_hi = table.Column<DateTime>(nullable: false),
                    Menge_hi = table.Column<decimal>(nullable: false),
                    Seriennr_hi = table.Column<string>(nullable: true),
                    Modelnr_hi = table.Column<string>(nullable: true),
                    Ware_Auslagerungsdatum_hi = table.Column<DateTime>(nullable: false),
                    Anschaff_Kosten_hi = table.Column<decimal>(nullable: false),
                    Lagerplatz_Id_hi = table.Column<int>(nullable: false),
                    User_id_hi = table.Column<string>(nullable: true),
                    Lieferant_Id_hi = table.Column<int>(nullable: false),
                    Kostenstelle_Nr_hi = table.Column<int>(nullable: false),
                    Hersteller_Id_hi = table.Column<int>(nullable: false),
                    Kategorie_Name_hi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHistorie", x => x.Ware_Id_hi);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WareHistorie");
        }
    }
}
