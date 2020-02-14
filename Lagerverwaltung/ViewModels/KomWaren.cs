using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class KomWaren
    {
        public int Ware_Id { get; set; }

        public string Beschreibung { get; set; }

        public int Menge { get; set; }

        [Required]
        [Range(1,100000,ErrorMessage ="Menge darf nicht kleiner als 1 sein")]
        
        public int Kom_Menge { get; set; }

        public bool Ausgewählt { get; set; }
    }
}
