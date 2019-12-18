using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class AusbuchenViewModel
    {
        public int Ware_Id { get; set; }

        [Display(Name = "Beschreibung")]
        public string Ware_Beschreibung { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Einlagerungsdatum")]
        public DateTime Ware_Einlagerungsdatum { get; set; }


       
        public decimal Menge { get; set; }

        [Display(Name ="Menge")]
        [Range(0,100000, ErrorMessage ="Darf nicht negativ sein")]
        public decimal MengeNeu { get; set; }

        public int Lagerplatz_Id { get; set; }

        public string Lagerplatz_Beschreibung { get; set; }
    }
}
