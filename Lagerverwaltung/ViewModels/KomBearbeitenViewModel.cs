using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class KomBearbeitenViewModel
    {
        public List<KomWaren> BestandWaren { get; set; }

        public string Beschreibung { get; set; }

        public List<KomWaren> NeueWaren { get; set; }
    }
}
