using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class LagerEditViewModel
    {
        [Required]
        [Range(1,100)]
        public int Anzahl { get; set; }

        public String LetzesLager { get; set; }

        public Lagerplatz LetzesElement  { get; set; }

        public List<char> lagerbezeichner  { get; set; }

        public char lager { get; set; }


    }
}
