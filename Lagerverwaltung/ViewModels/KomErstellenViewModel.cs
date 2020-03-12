using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class KomErstellenViewModel
    {
        [Required(ErrorMessage = "Beschreibung muss ausgefüllt sein")]
        public string Beschreibung { get; set; }

        public List<KomWaren> Waren { get; set; }


    }
}
