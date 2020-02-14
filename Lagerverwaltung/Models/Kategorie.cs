using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.Models
{
    public class Kategorie
    {
        [Key]
        public string Kategorie_Name { get; set; }

        public string Kategorie_Beschreibung { get; set; }
    }
}

