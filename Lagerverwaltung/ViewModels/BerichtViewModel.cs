﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class BerichtViewModel
    {

        public int Anzahl_Waren { get; set; }

        public decimal Warenwert { get; set; }

        public int Lagerplaetze { get; set; }

        public decimal Lagerbelegung { get; set; }

    }
}
