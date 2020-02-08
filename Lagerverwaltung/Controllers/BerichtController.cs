using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagerverwaltung.Models;
using Lagerverwaltung.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSG_Lagerverwaltung.Data;

namespace Lagerverwaltung.Controllers
{
    public class BerichtController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> usernManager;

        public BerichtController(ApplicationDbContext context, UserManager<IdentityUser> usernManager)
        {
            _context = context;
            this.usernManager = usernManager;
        }
        public IActionResult Index(BerichtViewModel model)
        {

            //Warenanzahl ermitteln:
            int Ber_Anzahl_Ware = _context.Ware.Count();
            model.Anzahl_Waren = Ber_Anzahl_Ware;



            //Gesamtwert aller Waren ermitteln:
            var ware = _context.Ware;
            foreach (var i in ware)
            {
                model.Warenwert += decimal.Round((i.Anschaff_Kosten * i.Menge), 2, MidpointRounding.AwayFromZero);

            }

            // Lagerauslastung ermitteln:

            int Ber_Lagerplatz = _context.Lagerplatz.Count();
            model.Lagerplaetze = Ber_Lagerplatz;

            model.Lagerbelegung = decimal.Round(((Convert.ToDecimal(Ber_Anzahl_Ware) / Convert.ToDecimal(Ber_Lagerplatz)) * 100m), 2, MidpointRounding.AwayFromZero);

            return View(model);
        }
    }
}