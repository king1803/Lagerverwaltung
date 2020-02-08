using System;
using System.ComponentModel.DataAnnotations;

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

        public string Seriennr { get; set; }

        public string Modellnummer { get; set; }

        public Decimal Anschaff_Kosten { get; set; }


        //Fremdschluessel:
        public int Lagerplatz_Id { get; set; }

        public string User_id { get; set; }

        public int Lieferant_Id { get; set; }

        public int Kostenstelle_Nr { get; set; }

        public int Hersteller_Id { get; set; }

        public string Kategorie_Name { get; set; }


    }
}
