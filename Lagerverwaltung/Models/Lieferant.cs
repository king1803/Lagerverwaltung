using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.Models
{
    public class Lieferant
    {
        [Key]
        public int Lieferant_Id { get; set; }

        public string Lieferant_Beschreibung { get; set; }
    }
}

