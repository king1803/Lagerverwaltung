using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Models
{
    public class Kategorie
    {
        [Key]
        public string Kategorie_Name { get; set; }

        public string Kategorie_Beschreibung { get; set; }
    }
}

