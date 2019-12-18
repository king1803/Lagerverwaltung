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
    public class LagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LagerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            // model.LetzesLager = test.Lagerplatz_Beschreibung.Remove(1);
            // model.LetzesLager = Convert.ToInt32(Convert.ToChar(model.LetzesLager)).ToString(); 

            var model = new LagerEditViewModel();
            model.LetzesElement = _context.Lagerplatz.ToList().Last();
            var test = _context.Lagerplatz;
            

            foreach(var i in test)
            {
                if (!(model.lagerbezeichner == null))
                {
                    if (!model.lagerbezeichner.Contains(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1))))
                    {
                        model.lagerbezeichner.Add(Convert.ToChar(i.Lagerplatz_Beschreibung.Remove(1)));
                    }
                }
                else
                {
                    model.lagerbezeichner = new List<char>();
                }
            }
           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LagerEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var liste = _context.Lagerplatz.Where(s => s.Lagerplatz_Beschreibung.Contains(model.lager.ToString()));
                int nummer = liste.Count();
                for (int i = 1; i <= model.Anzahl; i++)
                {

                    var lager = new Lagerplatz();
                    if (model.lager == '1')
                    {
                        lager.Lagerplatz_Beschreibung = Convert.ToChar(model.lagerbezeichner.Count() + 65).ToString() + i;
                    }
                    else
                    {
                        lager.Lagerplatz_Beschreibung = model.lager.ToString() + (nummer + i);
                    }
                    _context.Lagerplatz.Add(lager);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index", "Ware");
            }
            return View(model);
        }
    }
}