using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Models
{
    public class Lagerplatz
    {

        [Key]
        public int Lagerplatz_Id { get; set; }

        public string Lagerplatz_Beschreibung { get; set; }
    }
}
