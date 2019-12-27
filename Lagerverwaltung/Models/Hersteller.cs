using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Models
{
    public class Hersteller
    {
        [Key]
        public int Hersteller_Id { get; set; }

        public string Hersteller_Beschreibung { get; set; }
    }
}

