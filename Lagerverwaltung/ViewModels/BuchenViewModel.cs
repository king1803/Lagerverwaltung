using Lagerverwaltung.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class BuchenViewModel
    {
        public int Ware_Id { get; set; }

        [Display(Name = "Beschreibung")]
        [Required(ErrorMessage = "Beschreibung muss ausgefült sein")]
        public string Ware_Beschreibung { get; set; }

        //[Required(ErrorMessage = "Lagerplatz muss ausgefült sein")]
        //[RegularExpression(@"[A-Z][0-9]*" , ErrorMessage ="A-Z 0-9")]
        public List<Lagerplatz> Lagerplatz { get; set; }

        public List<Kategorie> Kategorie { get; set; }

        public List<Hersteller> Hersteller { get; set; }

        public List<Kostenstelle> Kostenstelle { get; set; }

        public List<Lieferant> Lieferant { get; set; }

        public int Lagerplatz_Id { get; set; }

        public string Kategorie_Name { get; set; }

        [Required(ErrorMessage = "Menge muss ausgefült sein")]
        [Range(1,100000, ErrorMessage = "Menge darf nicht negativ sein")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "nur ganze Zahlen")]
        public decimal Menge { get; set; }

        public string Suche { get; set; }

        [Display(Name = "Seriennummer")]
        public string Seriennr { get; set; }
        public string Modellnummer { get; set; }

    }
}
