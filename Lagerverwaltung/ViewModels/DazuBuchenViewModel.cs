using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.ViewModels
{
    public class DazuBuchenViewModel
    {
        public List<Ware> Waren { get; set; }

        public int Ware_Id { get; set; }

        public string Suche { get; set; }

        [Range(0, 100000, ErrorMessage = "Darf nicht negativ sein")]
        [Display(Name = "Menge Dazu")]
        public int MengeNeu { get; set; }
    }
}
