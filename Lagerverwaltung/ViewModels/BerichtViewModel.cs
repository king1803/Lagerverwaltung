using Lagerverwaltung.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace Lagerverwaltung.ViewModels
{
    public class BerichtViewModel
    {

        public int Anzahl_Waren { get; set; }

        public decimal Warenwert { get; set; }

        public int Lagerplaetze { get; set; }

        public decimal Lagerbelegung { get; set; }

        public List<Ware> Ware_List { get; set; }

        public string Ware_Beschreibung { get; set; }

        [DataType(DataType.Date)]
        public DateTime Ware_Einlagerungsdatum { get; set; }

    }
}
