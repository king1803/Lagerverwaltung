using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Models
{
    public class Ware
    {
        [Key]
        public int Ware_Id { get; set; }

        [Display(Name = "Beschreibung")]
        public string Ware_Beschreibung { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Einlagerungsdatum")]
        public DateTime Ware_Einlagerungsdatum { get; set; }

        
        public Decimal Menge { get; set; }

        public int Lagerplatz_Id { get; set; }

       




    }
}
