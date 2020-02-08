using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.Models
{
    public class Lager
    {
        [Key]
        public int Lager_Id { get; set; }

        public string Lager_Beschreibung { get; set; }
    }
}
