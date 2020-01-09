using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lagerverwaltung.Models;
using Lagerverwaltung.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SSG_Lagerverwaltung.Data;

namespace Lagerverwaltung.Controllers
{
    public class VerwaltungController : Controller
    {
        private readonly ApplicationDbContext _context;


        public VerwaltungController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index(string Id, string Kat)
        {
            VerwaltungÜbersichtViewmodel model = new VerwaltungÜbersichtViewmodel
            {
                Kategorien = _context.Kategorie.ToList(),
                Herstellers = _context.Hersteller.ToList(),
                Lieferanten = _context.Lieferant.ToList(),
                Kostenstellen = _context.Kostenstelle.ToList()
            };

            
            model.Kategorie = new Kategorie();
            model.Hersteller = new Hersteller();
            if (!string.IsNullOrEmpty(Id)&& Kat =="Kategorie")
            {
                model.Kategorie = _context.Kategorie.Find(Id);
            }

            if (!string.IsNullOrEmpty(Id) && Kat == "Hersteller")
            {

                model.Hersteller = _context.Hersteller.Find(Convert.ToInt32(Id));
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
                    model.Hersteller.Hersteller_Id = 0;



            }

            if(Id == "Hersteller")
            {

                
                    _context.Hersteller.Update(model.Hersteller);
                    await _context.SaveChangesAsync();
                model.Kategorie.Kategorie_Name = null;
                model.Hersteller.Hersteller_Id = 0;




            }

            model.Kategorien = _context.Kategorie.ToList();
            model.Herstellers = _context.Hersteller.ToList();
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Löschen(string Id, VerwaltungÜbersichtViewmodel model)
        {
            if (Id == "Kategorie")
            {
                
                
                    _context.Kategorie.Remove(model.Kategorie);
                    await _context.SaveChangesAsync();
                model.Kategorie.Kategorie_Name = null;
                model.Hersteller.Hersteller_Id = 0;



            }

            if (Id == "Hersteller")
            {


                _context.Hersteller.Remove(model.Hersteller);
                await _context.SaveChangesAsync();
                model.Kategorie.Kategorie_Name = null;
                model.Hersteller.Hersteller_Id = 0;




            }

            model.Kategorien = _context.Kategorie.ToList();
            model.Herstellers = _context.Hersteller.ToList();

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
                model.Kategorie.Kategorie_Name = null;
                model.Hersteller.Hersteller_Id = 0;




            }

            if (Id == "Hersteller")
            {
                
                    
                    _context.Hersteller.Add(model.Hersteller);
                    await _context.SaveChangesAsync();
                model.Kategorie.Kategorie_Name = null;
                model.Hersteller.Hersteller_Id = 0;




            }

            model.Kategorien = _context.Kategorie.ToList();
            model.Herstellers = _context.Hersteller.ToList();

            return View("Index", model);
        }
    }
}