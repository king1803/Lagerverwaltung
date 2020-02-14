using Lagerverwaltung.Models;
using System.Collections.Generic;

namespace Lagerverwaltung.ViewModels
{
    public class VerwaltungÜbersichtViewmodel
    {
        public List<Kategorie> Kategorien { get; set; }

        public List<Hersteller> Herstellers { get; set; }

        public List<Lieferant> Lieferanten { get; set; }

        public List<Kostenstelle> Kostenstellen { get; set; }

        public Kategorie Kategorie { get; set; }

        public Hersteller Hersteller { get; set; }

        public Lieferant Lieferant { get; set; }

        public Kostenstelle Kostenstelle { get; set; }

        public string Filter { get; set; }

        public bool KFilter { get; set; }
        public bool LFilter { get; set; }
        public bool HFilter { get; set; }
        public bool KSFilter { get; set; }

        public LagerEditViewModel Lager { get; set; }
    }
}
