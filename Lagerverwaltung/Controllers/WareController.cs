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
    public class WareController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> usernManager;

        public WareController(ApplicationDbContext context, UserManager<IdentityUser> usernManager)
        {
            _context = context;
            this.usernManager = usernManager;
        }

        public IActionResult Index(IndexViewModel model)
        {
            if (model.Suche || !string.IsNullOrEmpty(Request.Cookies["Suche"]))

            {
                string suche_Beschreibung = "";

                string suche_Hersteller = "";
                string suche_Kategorie = "";
                string suche_Knummer = "";
                string suche_Lagerplatz = "";
                string suche_Lieferant = "";
                string suche_Modelnr = "";
                string suche_Seriennr = "";

                if (!string.IsNullOrEmpty(model.Suche_Beschreibung))
                {
                    suche_Beschreibung = model.Suche_Beschreibung;
                    Response.Cookies.Append("Suche", suche_Beschreibung);
                }
                if(!string.IsNullOrEmpty(Request.Cookies["Suche"]) && string.IsNullOrEmpty(model.Suche_Beschreibung))
                {
                    suche_Beschreibung = Request.Cookies["Suche"];
                    Response.Cookies.Delete("Suche");
                }
                if (!string.IsNullOrEmpty(model.Suche_Hersteller))
                {
                    suche_Hersteller = model.Suche_Hersteller;
                }
                if (!string.IsNullOrEmpty(model.Suche_Kategorie))
                {
                    suche_Kategorie = model.Suche_Kategorie;
                }
                if (!string.IsNullOrEmpty(model.Suche_Kostenstellennr))
                {
                    suche_Knummer = model.Suche_Kostenstellennr;
                }
                if (!string.IsNullOrEmpty(model.Suche_Lagerplatz))
                {
                    suche_Lagerplatz = model.Suche_Lagerplatz;
                }
                if (!string.IsNullOrEmpty(model.Suche_Lieferanten))
                {
                    suche_Lieferant = model.Suche_Lieferanten;
                }
                if (!string.IsNullOrEmpty(model.Suche_Modellnummer))
                {
                    suche_Modelnr = model.Suche_Modellnummer;
                }
                if (!string.IsNullOrEmpty(model.Suche_Seriennummer))
                {
                    suche_Seriennr = model.Suche_Seriennummer;
                }



                var waren = _context.Ware.Join(_context.Hersteller, ware => ware.Hersteller_Id, hersteller => hersteller.Hersteller_Id,
                   (ware, hersteller) => new
                   {
                       Ware_Id = ware.Ware_Id,
                       Ware_Beschreibung = ware.Ware_Beschreibung,
                       Ware_Hersteller = hersteller.Hersteller_Beschreibung,
                       Kategorie_Name = ware.Kategorie_Name,
                       Kostenstelle_Nr = ware.Kostenstelle_Nr,
                       Lagerplatz_Id = ware.Lagerplatz_Id,
                       Lieferant_Id = ware.Lieferant_Id,
                       Modellnummer = ware.Modellnummer,
                       Seriennr = ware.Seriennr
                   }).Join(_context.Kategorie, ware => ware.Kategorie_Name, kategorie => kategorie.Kategorie_Name,
                   (ware, kategorie) => new
                   {
                       ware.Ware_Id,
                       Ware_Beschreibung = ware.Ware_Beschreibung,
                       Ware_Hersteller = ware.Ware_Hersteller,
                       Kategorie_Beschreibung = kategorie.Kategorie_Beschreibung,
                       Kostenstelle_Nr = ware.Kostenstelle_Nr,
                       Lagerplatz_Id = ware.Lagerplatz_Id,
                       Lieferant_Id = ware.Lieferant_Id,
                       Modellnummer = ware.Modellnummer,
                       Seriennr = ware.Seriennr
                   }
                       ).Join(_context.Kostenstelle, ware => ware.Kostenstelle_Nr, kostenstelle => kostenstelle.Kostenstelle_Nr,
                   (ware, kostenstelle) => new
                   {
                       Ware_Id = ware.Ware_Id,
                       Ware_Beschreibung = ware.Ware_Beschreibung,
                       Ware_Hersteller = ware.Ware_Hersteller,
                       Kategorie_Beschreibung = ware.Kategorie_Beschreibung,
                       Kostenstelle = kostenstelle.Kostenstelle_Beschreibung,
                       Lagerplatz_Id = ware.Lagerplatz_Id,
                       Lieferant_Id = ware.Lieferant_Id,
                       Modellnummer = ware.Modellnummer,
                       Seriennr = ware.Seriennr
                   }
                       ).Join(_context.Lagerplatz, ware => ware.Lagerplatz_Id, lagerplatz => lagerplatz.Lagerplatz_Id,
                   (ware, lagerplatz) => new
                   {
                       Ware_Id = ware.Ware_Id,
                       Ware_Beschreibung = ware.Ware_Beschreibung,
                       Ware_Hersteller = ware.Ware_Hersteller,
                       Kategorie_Beschreibung = ware.Kategorie_Beschreibung,
                       Kostenstelle = ware.Kostenstelle,
                       Lagerplatz = lagerplatz.Lagerplatz_Beschreibung,
                       Lieferant_Id = ware.Lieferant_Id,
                       Modellnummer = ware.Modellnummer,
                       Seriennr = ware.Seriennr
                   }
                       ).Join(_context.Lieferant, ware => ware.Lieferant_Id, lieferant => lieferant.Lieferant_Id,
                   (ware, lieferant) => new
                   {
                       Ware_Id = ware.Ware_Id,
                       Ware_Beschreibung = ware.Ware_Beschreibung,
                       Hersteller = ware.Ware_Hersteller,
                       Kategorie = ware.Kategorie_Beschreibung,
                       Kostenstelle = ware.Kostenstelle,
                       Lagerplatz = ware.Lagerplatz,
                       Lieferant = lieferant.Lieferant_Beschreibung,
                       Modellnummer = ware.Modellnummer,
                       Seriennr = ware.Seriennr
                   }
                       )
                       .Where(a => a.Ware_Beschreibung.Contains(suche_Beschreibung))
                       .Where(a => a.Kategorie.Contains(suche_Kategorie))
                       .Where(a => a.Hersteller.Contains(suche_Hersteller))
                       .Where(a => a.Kostenstelle.Contains(suche_Knummer))
                       .Where(a => a.Lagerplatz.Contains(suche_Lagerplatz))
                       .Where(a => a.Lieferant.Contains(suche_Lieferant))
                       .Where(a => a.Modellnummer.Contains(suche_Modelnr))
                       .Where(a => a.Seriennr.Contains(suche_Seriennr))
                       .ToList();

                model.Waren = new List<Ware>();

                foreach (var a in waren)
                {
                    model.Waren.Add(_context.Ware.Find(a.Ware_Id));
                }

                if (!string.IsNullOrEmpty(model.Sortierung))
                {
                    if (model.Sortierung == "Beschreibung")
                    {
                        if (model.Beschreiung)
                        {
                            model.Waren = model.Waren.OrderByDescending(s => s.Ware_Beschreibung).ToList();
                            model.Beschreiung = false;
                        }
                        else
                        {
                            model.Waren = model.Waren.OrderBy(s => s.Ware_Beschreibung).ToList();
                            model.Beschreiung = true;
                        }


                    }

                    if (model.Sortierung == "Menge")
                    {
                        if (model.Menge)
                        {
                            model.Waren = model.Waren.OrderByDescending(s => s.Menge).ToList();
                            model.Menge = false;
                        }
                        else
                        {
                            model.Waren = model.Waren.OrderBy(s => s.Menge).ToList();
                            model.Menge = true;
                        }


                    }

                    if (model.Sortierung == "Datum")
                    {
                        if (model.Datum)
                        {
                            model.Waren = model.Waren.OrderByDescending(s => s.Ware_Einlagerungsdatum).ToList();
                            model.Datum = false;
                        }
                        else
                        {
                            model.Waren = model.Waren.OrderBy(s => s.Ware_Einlagerungsdatum).ToList();
                            model.Datum = true;
                        }


                    }


                }




            }


            return View(model);
        }


        public IActionResult Buchen()
        {
            var ware = _context.Ware;
            var model = new BuchenViewModel();


            model.Lagerplatz = _context.Lagerplatz.OrderBy(i => i.Lagerplatz_Beschreibung).ToList();
            foreach (var i in ware)
            {

                model.Lagerplatz.RemoveAll(s => s.Lagerplatz_Id == i.Lagerplatz_Id);
            }
            model.Menge = 1;

            model.Kategorie = _context.Kategorie.ToList();
            model.Hersteller = _context.Hersteller.ToList();
            model.Kostenstelle = _context.Kostenstelle.ToList();
            model.Lieferant = _context.Lieferant.ToList();

            return View(model);
        }
        public IActionResult BuchenSuche(BuchenViewModel model)
        {
            var ware = _context.Ware;



            model.Lagerplatz = _context.Lagerplatz.Where(s => s.Lagerplatz_Beschreibung.Contains(model.Suche)).OrderBy(i => i.Lagerplatz_Beschreibung).ToList();
            foreach (var i in ware)
            {

                model.Lagerplatz.RemoveAll(s => s.Lagerplatz_Id == i.Lagerplatz_Id);
            }

            return View("Buchen", model);
        }
        [HttpPost]
        public async Task<IActionResult> Buchen(BuchenViewModel model)
        {

            if(string.IsNullOrEmpty(model.Seriennr))
            {
                model.Seriennr = "0";
            }
            else
            {
                model.Menge = 1;
            }

            if (string.IsNullOrEmpty(model.Modellnummer))
            {
                model.Modellnummer = "0";
            }

            if (ModelState.IsValid)
            {
                var userID = usernManager.GetUserId(HttpContext.User);
                Ware ware = new Ware
                {
                    Ware_Beschreibung = model.Ware_Beschreibung,
                    Ware_Einlagerungsdatum = DateTime.Today,
                    Lagerplatz_Id = model.Lagerplatz_Id,
                    Menge = model.Menge,
                    User_id = userID,
                    Seriennr = model.Seriennr,
                    Modellnummer = model.Modellnummer,
                    Kategorie_Name = model.Kategorie_Name,
                    Lieferant_Id = model.Lieferant_Id,
                    Hersteller_Id = model.Hersteller_Id,
                    Kostenstelle_Nr = model.Kostenstelle_Id,
                    Anschaff_Kosten = model.Anschaff_Kosten


                };

                _context.Ware.Add(ware);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            model.Lagerplatz = _context.Lagerplatz.OrderBy(i => i.Lagerplatz_Beschreibung).ToList();
            var ware1 = _context.Ware;
            foreach (var i in ware1)
            {

                model.Lagerplatz.RemoveAll(s => s.Lagerplatz_Id == i.Lagerplatz_Id);
            }
            model.Kategorie = _context.Kategorie.ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var ware = _context.Ware.Find(id);
            var lager = _context.Lagerplatz.Find(ware.Lagerplatz_Id);
            //var user = await usernManager.FindByIdAsync(ware.User_id);
            var hersteller = _context.Hersteller.Find(ware.Hersteller_Id);
            var lieferant = _context.Lieferant.Find(ware.Lieferant_Id);
            var kategorie = _context.Kategorie.Find(ware.Kategorie_Name);
            var kostenstellennummer = _context.Kostenstelle.Find(ware.Kostenstelle_Nr);

            DetailsViewModel model = new DetailsViewModel
            {
                Ware_Beschreibung = ware.Ware_Beschreibung,
                Ware_Id = ware.Ware_Id,
                Menge = decimal.Round(ware.Menge, 0),
                Ware_Einlagerungsdatum = ware.Ware_Einlagerungsdatum,
                Lagerplatz_Beschreibung = lager.Lagerplatz_Beschreibung,
                //User = user.UserName,
                Hersteller_Beschreibung = hersteller.Hersteller_Beschreibung,
                Lieferant_Beschreibung = lieferant.Lieferant_Beschreibung,
                Kategorie_Beschreibung = kategorie.Kategorie_Name,
                Kostenstellennr = kostenstellennummer.Kostenstelle_Nr,
                Modellnummer = ware.Modellnummer,
                Seriennummer = ware.Seriennr,
                Anschaffungskosten = decimal.Round(ware.Anschaff_Kosten, 2, MidpointRounding.AwayFromZero),
                AusbuchenMenge = 1
                

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Ausbuchen(DetailsViewModel model)
        {

            Ware ware = _context.Ware.Find(model.Ware_Id);
            int j = model.AusbuchenMenge;
            int i = Convert.ToInt32(ware.Menge);

            if (j > i)
            {
                ModelState.AddModelError("AusbuchenMenge", "So viel ist nicht da");
                
            }


            if (ModelState.IsValid)
            {

                if (i == j)
                {

                    _context.Ware.Remove(ware);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                
                if (j < i)
                {

                    ware.Menge = ware.Menge - model.AusbuchenMenge;
                    _context.Ware.Update(ware);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            
            var lager = _context.Lagerplatz.Find(ware.Lagerplatz_Id);
            //var user = await usernManager.FindByIdAsync(ware.User_id);
            var hersteller = _context.Hersteller.Find(ware.Hersteller_Id);
            var lieferant = _context.Lieferant.Find(ware.Lieferant_Id);
            var kategorie = _context.Kategorie.Find(ware.Kategorie_Name);
            var kostenstellennummer = _context.Kostenstelle.Find(ware.Kostenstelle_Nr);


            model.Ware_Beschreibung = ware.Ware_Beschreibung;
            model.Ware_Id = ware.Ware_Id;
            model.Menge = ware.Menge;
            model.Ware_Einlagerungsdatum = ware.Ware_Einlagerungsdatum;
            model.Lagerplatz_Beschreibung = lager.Lagerplatz_Beschreibung;
            //User = user.UserName,
            model.Hersteller_Beschreibung = hersteller.Hersteller_Beschreibung;
            model.Lieferant_Beschreibung = lieferant.Lieferant_Beschreibung;
            model.Kategorie_Beschreibung = kategorie.Kategorie_Name;
            model.Kostenstellennr = kostenstellennummer.Kostenstelle_Nr;
            model.Modellnummer = ware.Modellnummer;
            model.Seriennummer = ware.Seriennr;
            model.Anschaffungskosten = decimal.Round(ware.Anschaff_Kosten, 2, MidpointRounding.AwayFromZero);

            model.Fehler = true;

            return View("Details",model);
        }
        public IActionResult DazuBuchenSuche(DazuBuchenViewModel model)
        {



            var ware = _context.Ware;
            model.Waren = _context.Ware.ToList();
            if (!string.IsNullOrEmpty(model.Suche))
            {
                model.Waren = _context.Ware.Where(s => s.Ware_Beschreibung.Contains(model.Suche)).ToList();
            }

            foreach (var i in model.Waren)
            {
                i.Ware_Beschreibung = i.Ware_Beschreibung + " Menge: " + Convert.ToInt32(i.Menge);
            }
            model.MengeNeu = 1;
            return View("DazuBuchen", model);
        }

        public IActionResult DazuBuchen()
        {


            var model = new DazuBuchenViewModel();
            var ware = _context.Ware;
            model.MengeNeu = 1;
            model.Waren = _context.Ware.ToList();

            foreach (var i in model.Waren)
            {
                i.Ware_Beschreibung = i.Ware_Beschreibung + " Menge: " + Convert.ToInt32(i.Menge);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DazuBuchen(DazuBuchenViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ware = _context.Ware.Find(model.Ware_Id);
                ware.Menge = ware.Menge + model.MengeNeu;
                _context.Ware.Update(ware);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            model.Waren = _context.Ware.ToList();

            foreach (var i in model.Waren)
            {
                i.Ware_Beschreibung = i.Ware_Beschreibung + " Menge: " + Convert.ToInt32(i.Menge);
            }
            return View(model);

        }

        public IActionResult Bearbeiten(int id)
        {
           
            var ware = _context.Ware.Find(id);
            var lager = _context.Lagerplatz.Find(ware.Lagerplatz_Id);
            //var user = await usernManager.FindByIdAsync(ware.User_id);
            var hersteller = _context.Hersteller.Find(ware.Hersteller_Id);
            var lieferant = _context.Lieferant.Find(ware.Lieferant_Id);
            var kategorie = _context.Kategorie.Find(ware.Kategorie_Name);
            var kostenstellennummer = _context.Kostenstelle.Find(ware.Kostenstelle_Nr);



            BearbeitenViewModel model = new BearbeitenViewModel
            {
                Ware_Beschreibung = ware.Ware_Beschreibung,
                Ware_Id = ware.Ware_Id,
                Menge = decimal.Round(ware.Menge, 0),
                Ware_Einlagerungsdatum = ware.Ware_Einlagerungsdatum,
                Lagerplatz_NEU = ware.Lagerplatz_Id,
                //User = user.UserName,
                Hersteller_NEU = hersteller.Hersteller_Id,
                Lieferant_NEU = lieferant.Lieferant_Id,
                Kategorie_NEU = kategorie.Kategorie_Name,
                Kostenstellennr = kostenstellennummer.Kostenstelle_Nr,
                Modellnummer = ware.Modellnummer,
                Seriennummer = ware.Seriennr,
                Anschaffungskosten = decimal.Round(ware.Anschaff_Kosten, 2, MidpointRounding.AwayFromZero),
                Lagerplatz = _context.Lagerplatz.ToList(),
                Kategorie = _context.Kategorie.ToList(),
                Hersteller = _context.Hersteller.ToList(),
                Kostenstelle = _context.Kostenstelle.ToList(),
                Lieferant = _context.Lieferant.ToList()

            };

            return View(model);
        }
                   [HttpPost]
                     public async Task<IActionResult> Bearbeiten(BearbeitenViewModel model)
                     {

                        if (ModelState.IsValid)
                        {
                            var userID = usernManager.GetUserId(HttpContext.User);
                            Ware ware = new Ware
                            {
                                Ware_Id = model.Ware_Id,
                                Ware_Beschreibung = model.Ware_Beschreibung_NEU,
                                Ware_Einlagerungsdatum = model.Ware_Einlagerungsdatum,
                                Lagerplatz_Id = model.Lagerplatz_NEU,
                                Menge = model.Menge_NEU,                
                                Seriennr = model.Seriennummer_NEU,
                                Modellnummer = model.Modellnummer_NEU,
                                Kategorie_Name = model.Kategorie_NEU,
                                Anschaff_Kosten = model.Anschaffungskosten_NEU,
                                Lieferant_Id = model.Lieferant_NEU,
                                Kostenstelle_Nr = model.Kostenstelle_NEU,
                                Hersteller_Id = model.Hersteller_NEU,


                            };
                            
                            _context.Ware.Update(ware);
                            await _context.SaveChangesAsync();
                            return RedirectToAction("Details", new { id = model.Ware_Id });
                        }
                        return View(model);
                    }
                
            
        
    }
}