using Lagerverwaltung.Models;
using Lagerverwaltung.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SSG_Lagerverwaltung.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.Controllers
{
    public class VerwaltungController : Controller
    {
        private readonly ApplicationDbContext _context;


        public VerwaltungController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index(string Id, string Kat, VerwaltungÜbersichtViewmodel model)
        {
            if (string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(Request.Cookies["Filter"]))
            {
                model.KFilter = true;
                model.LFilter = true;
                model.HFilter = true;
                model.KSFilter = false;
            }

            string Filter = "";

            if (model.KFilter)
            {
                Filter = Filter + "Kategorie";
            }
            if (model.HFilter)
            {
                Filter = Filter + "Hersteller";
            }
            if (model.LFilter)
            {
                Filter = Filter + "Lieferant";
            }
            if (model.KSFilter)
            {
                Filter = Filter + "Kostenstelle";
            }
            Response.Cookies.Append("Filter", Filter);



            model.Kategorien = _context.Kategorie.ToList();
            model.Herstellers = _context.Hersteller.ToList();
            model.Lieferanten = _context.Lieferant.ToList();
            model.Kostenstellen = _context.Kostenstelle.ToList();


            if (model.Kategorie == null)
            {
                model.Kategorie = new Kategorie();
            }
            if (model.Hersteller == null)
            {
                model.Hersteller = new Hersteller();
            }
            if (model.Lieferant == null)
            {
                model.Lieferant = new Lieferant();
            }
            if (model.Kostenstelle == null)
            {
                model.Kostenstelle = new Kostenstelle();
            }

            if (!string.IsNullOrEmpty(Id) && Kat == "Kategorie")
            {
                model.Kategorie = _context.Kategorie.Find(Id);
            }

            if (!string.IsNullOrEmpty(Id) && Kat == "Hersteller")
            {

                model.Hersteller = _context.Hersteller.Find(Convert.ToInt32(Id));
            }

            if (!string.IsNullOrEmpty(Id) && Kat == "Lieferant")
            {

                model.Lieferant = _context.Lieferant.Find(Convert.ToInt32(Id));
            }

            if (!string.IsNullOrEmpty(Id) && Kat == "Kostenstelle")
            {

                model.Kostenstelle = _context.Kostenstelle.Find(Convert.ToInt32(Id));
            }

            //Lager

            //Fuege eine Lager ein, falls beim ersten start noch keins vorhanden ist:

            if (_context.Lager.FirstOrDefault() == null)
            {
                Lager lager = new Lager
                {
                    Lager_Id = 1,
                    Lager_Beschreibung = "Standard Lager"
                };

                _context.Lager.Add(lager);
                _context.SaveChanges();
            }

            if (_context.Lagerplatz.FirstOrDefault() == null)
            {
                Lagerplatz lagerplatz = new Lagerplatz
                {
                    Lagerplatz_Id = 1,
                    Lagerplatz_Beschreibung = "A1",
                    Lager_Id = 1
                };

                _context.Lagerplatz.Add(lagerplatz);
                _context.SaveChanges();
            }




            model.Lager = new LagerEditViewModel();
            model.Lager.LetzesElement = _context.Lagerplatz.ToList().Last();
            var test = _context.Lagerplatz;


            foreach (var i in test)
            {

                if (!(model.Lager.lagerbezeichner == null))
                {
                    if (!model.Lager.lagerbezeichner.Contains(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1))))
                    {
                        model.Lager.lagerbezeichner.Add(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1)));

                    }
                }
                else
                {
                    model.Lager.lagerbezeichner = new List<char>();
                    model.Lager.lagerbezeichner.Add(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1)));



                }

            }
            model.Lager.bestand = new List<int>();
            foreach (var i in model.Lager.lagerbezeichner)
            {


                model.Lager.bestand.Add(_context.Lagerplatz.Where(s => s.Lagerplatz_Beschreibung.Contains(i.ToString())).Count());

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Bearbeiten(string Id, VerwaltungÜbersichtViewmodel model)
        {
            if (Id == "Kategorie")
            {


                _context.Kategorie.Update(model.Kategorie);
                await _context.SaveChangesAsync();
                model.Kategorie.Kategorie_Name = null;


            }

            if (Id == "Hersteller")
            {


                _context.Hersteller.Update(model.Hersteller);
                await _context.SaveChangesAsync();





            }

            if (Id == "Lieferant")
            {


                _context.Lieferant.Update(model.Lieferant);
                await _context.SaveChangesAsync();





            }

            if (Id == "Kostenstelle")
            {


                _context.Kostenstelle.Update(model.Kostenstelle);
                await _context.SaveChangesAsync();





            }




            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Löschen(string Id, VerwaltungÜbersichtViewmodel model)
        {
            if (Id == "Kategorie")
            {
                foreach (var ware in _context.Ware)
                {
                    if (ware.Kategorie_Name == model.Kategorie.Kategorie_Name)
                    {
                        ModelState.AddModelError("Kategorie", "Kategorie noch in verwendung");
                        break;
                    }

                }
                if (ModelState.IsValid)
                {
                    _context.Kategorie.Remove(model.Kategorie);
                    await _context.SaveChangesAsync();
                    model.Kategorie = new Kategorie();
                }



            }

            if (Id == "Hersteller")
            {


                _context.Hersteller.Remove(model.Hersteller);
                await _context.SaveChangesAsync();





            }

            if (Id == "Lieferant")
            {


                _context.Lieferant.Remove(model.Lieferant);
                await _context.SaveChangesAsync();




            }

            if (Id == "Kostenstelle")
            {


                _context.Kostenstelle.Remove(model.Kostenstelle);
                await _context.SaveChangesAsync();





            }

            model.Lager = new LagerEditViewModel();
            model.Lager.LetzesElement = _context.Lagerplatz.ToList().Last();
            var test = _context.Lagerplatz;


            foreach (var i in test)
            {

                if (!(model.Lager.lagerbezeichner == null))
                {
                    if (!model.Lager.lagerbezeichner.Contains(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1))))
                    {
                        model.Lager.lagerbezeichner.Add(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1)));

                    }
                }
                else
                {
                    model.Lager.lagerbezeichner = new List<char>();
                    model.Lager.lagerbezeichner.Add(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1)));



                }

            }
            model.Lager.bestand = new List<int>();
            foreach (var i in model.Lager.lagerbezeichner)
            {


                model.Lager.bestand.Add(_context.Lagerplatz.Where(s => s.Lagerplatz_Beschreibung.Contains(i.ToString())).Count());

            }

            model.Kategorien = _context.Kategorie.ToList();
            model.Herstellers = _context.Hersteller.ToList();
            model.Lieferanten = _context.Lieferant.ToList();
            model.Kostenstellen = _context.Kostenstelle.ToList();

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Neu(string Id, VerwaltungÜbersichtViewmodel model)
        {

            if (Id == "Kategorie")
            {

                model.Kategorie.Kategorie_Name = model.Kategorie.Kategorie_Beschreibung;
                _context.Kategorie.Add(model.Kategorie);
                await _context.SaveChangesAsync();





            }

            if (Id == "Hersteller")
            {

                model.Hersteller.Hersteller_Id = 0;
                _context.Hersteller.Add(model.Hersteller);
                await _context.SaveChangesAsync();





            }

            if (Id == "Lieferant")
            {

                model.Lieferant.Lieferant_Id = 0;
                _context.Lieferant.Add(model.Lieferant);
                await _context.SaveChangesAsync();





            }

            if (Id == "Kostenstelle")
            {

                model.Kostenstelle.Kostenstelle_Nr = 0;
                _context.Kostenstelle.Add(model.Kostenstelle);
                await _context.SaveChangesAsync();





            }



            return RedirectToAction("Index", model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(VerwaltungÜbersichtViewmodel model)
        {
            if (ModelState.IsValid)
            {
                var liste = _context.Lagerplatz.Where(s => s.Lagerplatz_Beschreibung.Contains(model.Lager.lager.ToString()));
                int nummer = liste.Count();
                for (int i = 1; i <= model.Lager.Anzahl; i++)
                {

                    var lager = new Lagerplatz();
                    if (model.Lager.lager == '1')
                    {
                        lager.Lagerplatz_Beschreibung = Convert.ToChar(model.Lager.lagerbezeichner.Count() + 65).ToString() + i;
                    }
                    else
                    {
                        lager.Lagerplatz_Beschreibung = model.Lager.lager.ToString() + (nummer + i);
                    }
                    _context.Lagerplatz.Add(lager);
                    await _context.SaveChangesAsync();
                }

            }

            model.Lager.LetzesElement = _context.Lagerplatz.ToList().Last();
            var test = _context.Lagerplatz;


            foreach (var i in test)
            {

                if (!(model.Lager.lagerbezeichner == null))
                {
                    if (!model.Lager.lagerbezeichner.Contains(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1))))
                    {
                        model.Lager.lagerbezeichner.Add(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1)));

                    }
                }
                else
                {
                    model.Lager.lagerbezeichner = new List<char>();
                    model.Lager.lagerbezeichner.Add(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1)));



                }

            }
            model.Lager.bestand = new List<int>();
            foreach (var i in model.Lager.lagerbezeichner)
            {


                model.Lager.bestand.Add(_context.Lagerplatz.Where(s => s.Lagerplatz_Beschreibung.Contains(i.ToString())).Count());

            }

            model.Kategorien = _context.Kategorie.ToList();
            model.Herstellers = _context.Hersteller.ToList();
            model.Lieferanten = _context.Lieferant.ToList();
            model.Kostenstellen = _context.Kostenstelle.ToList();

            return RedirectToAction("Index");
        }
    }




}