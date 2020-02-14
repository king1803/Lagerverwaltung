using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagerverwaltung.Models;
using Lagerverwaltung.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SSG_Lagerverwaltung.Data;

namespace Lagerverwaltung.Controllers
{
    public class KommissionierungController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> usernManager;

        public KommissionierungController(ApplicationDbContext context, UserManager<IdentityUser> usernManager)
        {
            _context = context;
            this.usernManager = usernManager;
        }

        public IActionResult Index()
        {

            List<KomIndexViewModel> model = new List<KomIndexViewModel>();

            

            foreach (var w in _context.Kommissionierung.ToList())
            {
                
                int a = _context.KommissionierungWaren.Where(z => z.Kommision_Id.Equals(w.Kom_Id)).Count();
               
                KomIndexViewModel kom = new KomIndexViewModel
                {
                    Anzahl = a
                    
                };
                kom.Kom = w;
                model.Add(kom);
            }

            return View(model);
        }

        public IActionResult Erstellen()
        {
            KomErstellenViewModel model = new KomErstellenViewModel();
            model.Waren = new List<KomWaren>();

            var Waren = _context.Ware;

            foreach(var w in Waren)
            {
                var KW = new KomWaren
                {
                    Ware_Id = w.Ware_Id,
                    Beschreibung = w.Ware_Beschreibung,
                    Menge = Convert.ToInt32(w.Menge),
                    Ausgewählt = false
                };
                model.Waren.Add(KW);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Erstellen (KomErstellenViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userID = usernManager.GetUserId(HttpContext.User);
                Kommissionierung kommissionierung = new Kommissionierung
                {
                    Erstelldatum = DateTime.Today,
                    User_Id = userID,
                    Beschreibung= model.Beschreibung
                };

                _context.Kommissionierung.Add(kommissionierung);
                await _context.SaveChangesAsync();

                int K_Id = _context.Kommissionierung.ToList().Last().Kom_Id;

                foreach(var w in model.Waren)
                {
                    if(w.Ausgewählt)
                    {
                        KommissionierungWaren kw = new KommissionierungWaren
                        {
                            Ware_Id = w.Ware_Id,
                            Kommision_Id = K_Id,
                            Menge = w.Kom_Menge
                        };

                        _context.KommissionierungWaren.Add(kw);
                        await _context.SaveChangesAsync();

                    }
                }


                return RedirectToAction("Index");
            }



            return View(model);
        }

        public IActionResult Bearbeiten(int Id)
        {
            Kommissionierung Kom = _context.Kommissionierung.Find(Id);

            KomBearbeitenViewModel model = new KomBearbeitenViewModel
            {
                Beschreibung = Kom.Beschreibung,
                BestandWaren = new List<KomWaren>(),
                NeueWaren = new List<KomWaren>()
            };

            foreach(var w in _context.KommissionierungWaren.Where(s => s.Kommision_Id.Equals(Kom.Kom_Id)).ToList())
            {
                KomWaren kw = new KomWaren
                {
                    Beschreibung = _context.Ware.Find(w.Ware_Id).Ware_Beschreibung,
                    Ware_Id = w.Ware_Id,
                    Menge = Convert.ToInt32(_context.Ware.Find(w.Ware_Id).Menge),
                    Kom_Menge = w.Menge,
                    Ausgewählt = true
                };

                model.BestandWaren.Add(kw);
            }

            return View(model);
        }
    }
}