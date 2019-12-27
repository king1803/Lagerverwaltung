using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Models
{
    public class Lager
    {
        [Key]
        public int Lager_Id { get; set; }

        public string Lager_Beschreibung { get; set; }
    }
}
