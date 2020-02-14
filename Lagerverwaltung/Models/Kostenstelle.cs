using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.Models
{
    public class Kostenstelle
    {
        [Key]
        public int Kostenstelle_Nr { get; set; }

        public string Kostenstelle_Beschreibung { get; set; }
    }
}

