using Lagerverwaltung.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.ViewModels
{
    public class IndexViewModel
    {
        public List<Ware> Waren { get; set; }

        public string Suche_Beschreibung { get; set; }

        public string Suche_Seriennummer { get; set; }

        public string Suche_Modellnummer { get; set; }

        public string Suche_Lagerplatz { get; set; }

        public string Suche_Lieferanten { get; set; }

        public string Suche_Kostenstellennr { get; set; }

        public string Suche_Hersteller { get; set; }

        public string Suche_Kategorie { get; set; }

        public string Suche_Auftragsnummer { get; set; }

        public string Sortierung { get; set; }

        public bool Beschreiung { get; set; }

        public bool Datum { get; set; }

        public bool Menge { get; set; }
        public bool Suche { get; set; }

        public string Seriennr { get; set; }

        public string Modellnummer { get; set; }

        public bool Lagerplatz { get; set; }

        public List<Lagerplatz> Lagerplatz_Beschreibung { get; set; }

        public List<Reservierungen> Reservierung { get; set; }
        
        [Display(Name = "Zeilenanzahl: ")]
        public int ausgabeanzahl { get; set; }

    }
}
