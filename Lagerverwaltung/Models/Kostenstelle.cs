using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Models
{
    public class Kostenstelle
    {
        [Key]
        public int Kostenstelle_Nr { get; set; }

        public string Kostenstelle_Beschreibung { get; set; }
    }
}

