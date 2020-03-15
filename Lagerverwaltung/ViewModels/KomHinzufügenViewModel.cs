using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class KomHinzufügenViewModel
    {
        public List<KomWaren> Waren { get; set; }

        public List<KomWaren> ZwischenWaren { get; set; }

        public int Id { get; set; }

        public string Beschreibung { get; set; }

        public bool Hinzu { get; set; }

        public string Suche { get; set; }
    }
}
