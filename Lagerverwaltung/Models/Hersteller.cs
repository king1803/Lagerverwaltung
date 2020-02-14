using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.Models
{
    public class Hersteller
    {
        [Key]
        public int Hersteller_Id { get; set; }

        public string Hersteller_Beschreibung { get; set; }
    }
}

