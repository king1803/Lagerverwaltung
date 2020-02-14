using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Models
{
    public class KommissionierungWaren
    {
        [Key]
        public int Id { get; set; }
        public int Ware_Id { get; set; }
       
        public int Kommision_Id { get; set; }

        public int Menge { get; set; }

    }
}
