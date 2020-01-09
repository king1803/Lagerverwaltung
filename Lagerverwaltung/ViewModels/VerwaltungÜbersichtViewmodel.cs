using Lagerverwaltung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class VerwaltungÜbersichtViewmodel
    {
       public List<Kategorie> Kategorien { get; set; }

       public  List<Hersteller> Herstellers { get; set; }

       public List<Lieferant> Lieferanten { get; set; }

       public List<Kostenstelle> Kostenstellen { get; set; }

       public Kategorie Kategorie { get; set; }

      public Hersteller Hersteller { get; set; }


    }
}
