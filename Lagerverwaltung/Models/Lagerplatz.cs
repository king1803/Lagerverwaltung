using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.Models
{
    public class Lagerplatz
    {

        [Key]
        public int Lagerplatz_Id { get; set; }

        public string Lagerplatz_Beschreibung { get; set; }

        public int Lager_Id { get; set; }
    }
}
