using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Models
{
    public class WareHistorie
    {

        [Key]
        public int Ware_Id_hi { get; set; }

        [Display(Name = "Beschreibung")]
        public string Ware_Beschreibung_hi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Einlagerungsdatum")]
        public DateTime Ware_Einlagerungsdatum_hi { get; set; }

        public Decimal Menge_hi { get; set; }

        public string Seriennr_hi { get; set; }

        public string Modelnr_hi { get; set; }

        public DateTime Ware_Auslagerungsdatum_hi { get; set; }

        public Decimal Anschaff_Kosten_hi { get; set; }

        public int Lagerplatz_Id_hi { get; set; }

        public string User_id_hi { get; set; }

        public int Lieferant_Id_hi { get; set; }

        public int Kostenstelle_Nr_hi { get; set; }

        public int Hersteller_Id_hi { get; set; }

        public string Kategorie_Name_hi { get; set; }

    }
}
