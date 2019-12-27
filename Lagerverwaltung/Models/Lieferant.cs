using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Models
{
    public class Lieferant
    {
        [Key]
        public int Lieferant_Id { get; set; }

        public string Lieferant_Beschreibung { get; set; }
    }
}

