using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class Userberechtigung
    {
        public string Name { get; set; }

        public bool Admin { get; set; }

        public bool Zurücksetzten { get; set; }
    }
}
