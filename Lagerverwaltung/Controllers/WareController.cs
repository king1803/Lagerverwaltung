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

        public IActionResult Index(IndexViewModel? model)
        {
            if (!string.IsNullOrEmpty(model.Suche))
            {
                string suche = model.Suche;
                if (!string.IsNullOrEmpty(model.Sortierung))
                {
                    
                    if (model.Sortierung == "Beschreibung")
                    {
                        if(model.Beschreiung)
                        {
                            model.Waren = _context.Ware.Where(s => s.Ware_Beschreibung.Contains(suche)).OrderByDescending(a => a.Ware_Beschreibung).ToList();
                            model.Beschreiung = false;
                        }
                        else
                        {
                            model.Waren = _context.Ware.Where(s => s.Ware_Beschreibung.Contains(suche)).OrderBy(a => a.Ware_Beschreibung).ToList();
                            model.Beschreiung = true;
                        }
                        
                        
                    }

                    if (model.Sortierung == "Datum")
                    {

                        if (model.Datum)
                        {
                            model.Waren = _context.Ware.Where(s => s.Ware_Beschreibung.Contains(suche)).OrderByDescending(a => a.Ware_Einlagerungsdatum).ToList();
                            model.Datum = false;
                        }
                        else
                        {
                            model.Waren = _context.Ware.Where(s => s.Ware_Beschreibung.Contains(suche)).OrderBy(a => a.Ware_Einlagerungsdatum).ToList();
                            model.Datum = true;
                        }

                    }

                    if (model.Sortierung == "Menge")
                    {

                        if (model.Menge)
                        {
                            model.Waren = _context.Ware.Where(s => s.Ware_Beschreibung.Contains(suche)).OrderByDescending(a => a.Menge).ToList();
                            model.Menge = false;
                        }
                        else
                        {
                            model.Waren = _context.Ware.Where(s => s.Ware_Beschreibung.Contains(suche)).OrderBy(a => a.Menge).ToList();
                            model.Menge = true;
                        }

                    }
                    return View(model);
                }
                
                model.Waren = _context.Ware.Where(s => s.Ware_Beschreibung.Contains(suche)).ToList();
                return View(model);
            }

            if (!string.IsNullOrEmpty(model.Sortierung))
            {
                if(model.Sortierung == "Beschreibung")
                {
                    if(model.Beschreiung)
                    {
                        model.Waren = _context.Ware.OrderByDescending(s => s.Ware_Beschreibung).ToList();
                        model.Beschreiung = false;
                    }
                    else
                    {
                        model.Waren = _context.Ware.OrderBy(s => s.Ware_Beschreibung).ToList();
                        model.Beschreiung = true;
                    }
                    
                   
                }

                if (model.Sortierung == "Menge")
                {
                    if(model.Menge)
                    {
                        model.Waren = _context.Ware.OrderByDescending(s => s.Menge).ToList();
                        model.Menge = false;
                    }
                    else
                    {
                        model.Waren = _context.Ware.OrderBy(s => s.Menge).ToList();
                        model.Menge = true;
                    }
                    
                    
                }

                if (model.Sortierung == "Datum")
                {
                    if(model.Datum)
                    {
                        model.Waren = _context.Ware.OrderByDescending(s => s.Ware_Einlagerungsdatum).ToList();
                        model.Datum = false;
                    }
                    else
                    {
                        model.Waren = _context.Ware.OrderBy(s => s.Ware_Einlagerungsdatum).ToList();
                        model.Datum = true;
                    }
                    
                    
                }
                return View(model);

            }

                IndexViewModel model1 = new IndexViewModel();
            model1.Waren = _context.Ware.ToList();
            return View(model1);
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
            return View(model);
        }
        public IActionResult BuchenSuche (BuchenViewModel model)
        {
            var ware = _context.Ware;
            


            model.Lagerplatz = _context.Lagerplatz.Where(s => s.Lagerplatz_Beschreibung.Contains(model.Suche)).OrderBy(i => i.Lagerplatz_Beschreibung).ToList();
            foreach (var i in ware)
            {

                model.Lagerplatz.RemoveAll(s => s.Lagerplatz_Id == i.Lagerplatz_Id);
            }

            return View("Buchen",model);
        }
        [HttpPost]
        public async Task<IActionResult> Buchen(BuchenViewModel model)
        {
            var test = _context.Ware;
            foreach( var i in test)
            {
                if (i.Ware_Beschreibung.Contains(model.Ware_Beschreibung))
                {
                    ModelState.AddModelError("Ware_Beschreibung", "Ware schon vorhanden");
                }
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
                    User_id = userID
                    
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
            return View(model);
        }

        public async Task<IActionResult> Ausbuchen(int id)
        {
            var ware = _context.Ware.Find(id);
            var lager = _context.Lagerplatz.Find(ware.Lagerplatz_Id);
             var user = await usernManager.FindByIdAsync(ware.User_id);
            AusbuchenViewModel model = new AusbuchenViewModel
            {
                Ware_Beschreibung = ware.Ware_Beschreibung,
                Ware_Id = ware.Ware_Id,
                Menge = ware.Menge,
                Ware_Einlagerungsdatum = ware.Ware_Einlagerungsdatum,
                Lagerplatz_Beschreibung = lager.Lagerplatz_Beschreibung,
                User = user.UserName
            };



            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Ausbuchen(AusbuchenViewModel model)
        {

            Ware ware = _context.Ware.Find(model.Ware_Id);
            decimal i = model.Menge;
            decimal j = model.MengeNeu;

            model.Ware_Id = ware.Ware_Id;
            model.Ware_Einlagerungsdatum = ware.Ware_Einlagerungsdatum;
            model.Ware_Beschreibung = ware.Ware_Beschreibung;

            if (ModelState.IsValid)
            {

                if (i == j)
                {

                    _context.Ware.Remove(ware);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                if (j > i)
                {
                    ModelState.AddModelError("MengeNeu", "So viel ist nicht da");
                    return View(model);
                }
                if (j < i)
                {

                    ware.Menge = ware.Menge - model.MengeNeu;
                    _context.Ware.Update(ware);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public IActionResult DazuBuchenSuche(DazuBuchenViewModel model)
        {   

            
            
            var ware = _context.Ware;
            model.Waren = _context.Ware.ToList();
            if (!string.IsNullOrEmpty(model.Suche))
            {
                model.Waren = _context.Ware.Where(s => s.Ware_Beschreibung.Contains(model.Suche)).ToList();  
            }
            
            foreach(var i in model.Waren)
            {
                i.Ware_Beschreibung = i.Ware_Beschreibung + " Menge: " + Convert.ToInt32(i.Menge);
            }
            model.MengeNeu = 1;
            return View("DazuBuchen",model);
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
    }
}