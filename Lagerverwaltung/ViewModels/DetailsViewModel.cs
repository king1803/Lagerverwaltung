using System;
using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.ViewModels
{
    public class DetailsViewModel
    {
        public int Ware_Id { get; set; }

        [Display(Name = "Beschreibung")]
        public string Ware_Beschreibung { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Einlagerungsdatum")]
        public DateTime Ware_Einlagerungsdatum { get; set; }



        public decimal Menge { get; set; }

        public int Lagerplatz_Id { get; set; }

        public string Lagerplatz_Beschreibung { get; set; }

        public string User { get; set; }

        public string Hersteller_Beschreibung { get; set; }

        public string Kategorie_Beschreibung { get; set; }

        public string Lieferant_Beschreibung { get; set; }

        public int Kostenstellennr { get; set; }

        public string Seriennummer { get; set; }

        public string Modellnummer { get; set; }

        public decimal Anschaffungskosten { get; set; }

        [Range(1, 100000, ErrorMessage = "Keine Menge kleiner 1")]

        public int AusbuchenMenge { get; set; }

        public bool Fehler { get; set; }

        public string Auftragsnummer { get; set; }



    }
}
