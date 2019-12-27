using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class IndexViewModel
    {
        public List<Ware> Waren { get; set; }

        public string Suche { get; set; }

        public string Sortierung { get; set; }

        public bool Beschreiung { get; set; }

        public bool Datum { get; set; }

        public bool Menge { get; set; }

        public string Seriennr { get; set; }

    }
}
