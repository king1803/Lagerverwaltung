using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.ViewModels
{
    public class LagerEditViewModel
    {
        [Required]
        [Range(1, 1000)]
        public int Anzahl { get; set; }

        public String LetzesLager { get; set; }

        public Lagerplatz LetzesElement { get; set; }

        public List<char> lagerbezeichner { get; set; }

        public List<int> bestand { get; set; }

        public char lager { get; set; }


    }
}
