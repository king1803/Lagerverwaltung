using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Models
{
    public class Kommissionierung
    {
        [Key]
        public int Kom_Id { get; set; }

        public string Beschreibung { get; set; }

        public string User_Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ErsStelldatum")]
        public DateTime Erstelldatum { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Abschlussdatum")]
        public DateTime Abschlussdatum { get; set; }
    }
}
