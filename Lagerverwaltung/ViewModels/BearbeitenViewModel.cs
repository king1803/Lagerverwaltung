using Lagerverwaltung.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class BearbeitenViewModel
    {
        //ALTE WERTE
        public int Ware_Id { get; set; }

        [Display(Name = "Beschreibung")]
        public string Ware_Beschreibung { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Einlagerungsdatum")]
        public DateTime Ware_Einlagerungsdatum { get; set; }



        public decimal Menge { get; set; }

        [Display(Name = "Menge")]
        [Range(0, 100000, ErrorMessage = "Darf nicht negativ sein")]
        public decimal MengeNeu { get; set; }

        //public string User { get; set; }

        public int Hersteller_NEU { get; set; }

        public string Kategorie_NEU { get; set; }

        public int Lieferant_NEU { get; set; }

        public int Kostenstelle_NEU { get; set; }

        public int Kostenstellennr { get; set; }

        public string Seriennummer { get; set; }

        public string Modellnummer { get; set; }

        public decimal Anschaffungskosten { get; set; }

        //NEUE WERTE

        public string Ware_Beschreibung_NEU { get; set; }

        public List<Lagerplatz> Lagerplatz { get; set; }

        public List<Hersteller> Hersteller { get; set;}
        public List<Lieferant> Lieferant { get; set; }
        public List<Kategorie> Kategorie { get; set; }
        public List<Kostenstelle> Kostenstelle { get; set; }
        public decimal Anschaffungskosten_NEU { get; set; }
        public string Seriennummer_NEU { get; set; }
        public string Modellnummer_NEU { get; set; }

        public decimal Menge_NEU { get; set; }

        public int Lagerplatz_NEU { get; set; }

    }
}
