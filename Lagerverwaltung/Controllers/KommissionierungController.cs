using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lagerverwaltung.Models;
using Lagerverwaltung.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using OfficeOpenXml;
using SSG_Lagerverwaltung.Data;

namespace Lagerverwaltung.Controllers
{
    public class KommissionierungController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> usernManager;
        private readonly IWebHostEnvironment _env;

        public KommissionierungController(ApplicationDbContext context, UserManager<IdentityUser> usernManager, IWebHostEnvironment env)
        {
            _context = context;
            this.usernManager = usernManager;
            _env = env;
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

           
            model.Waren = new List<KomWaren>();

            var Waren = _context.Ware;

            foreach (var w in Waren)
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

        public IActionResult Bearbeiten(int Id)
        {
            Kommissionierung Kom = _context.Kommissionierung.Find(Id);

            KomBearbeitenViewModel model = new KomBearbeitenViewModel
            {
                Beschreibung = Kom.Beschreibung,
                Id = Kom.Kom_Id,
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

        public async Task<IActionResult> Löschen(int Id)
        {
            var KomWaren = _context.KommissionierungWaren.Where(a => a.Kommision_Id.Equals(Id)).ToList();

            foreach(var kw in KomWaren)
            {
                _context.KommissionierungWaren.Remove(kw);
                await _context.SaveChangesAsync();
            }

            var Kom = _context.Kommissionierung.Find(Id);

            _context.Kommissionierung.Remove(Kom);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Abschließen(int Id)
        {
            var Kom = _context.Kommissionierung.Find(Id);

            using (ExcelPackage excelPackage = new ExcelPackage())
            {

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Kommission");
                worksheet.Column(3).Width = 50;
                worksheet.Column(5).Width = 20;
                worksheet.Cells["C2"].Value = "Beschreibung";
                worksheet.Cells["C2"].Style.Font.Bold =true;
                worksheet.Cells["B2"].Value = "#";
                worksheet.Cells["B2"].Style.Font.Bold = true;
                worksheet.Cells["D2"].Value = "Menge";
                worksheet.Cells["D2"].Style.Font.Bold = true;
                worksheet.Cells["E2"].Value = "Lagerplatz";
                worksheet.Cells["E2"].Style.Font.Bold = true;

                int i = 3;   

                foreach(var k in _context.KommissionierungWaren.Where(a => a.Kommision_Id.Equals(Id)).ToList() )
                {

                    worksheet.Cells["B"+i].Value = i-3;

                    worksheet.Cells["C" + i].Value = _context.Ware.Find(k.Ware_Id).Ware_Beschreibung;

                    worksheet.Cells["D" + i].Value = k.Menge;

                    worksheet.Cells["E" + i].Value = _context.Lagerplatz.Find(_context.Ware.Find(k.Ware_Id).Lagerplatz_Id).Lagerplatz_Beschreibung;
                }


                string Name = Kom.Kom_Id + "_" + Kom.Beschreibung;

                FileInfo fi = new FileInfo(_env.WebRootPath +"\\Download\\" + Name +".xlsx");
               
                excelPackage.SaveAs(fi);

                byte[] bin = excelPackage.GetAsByteArray();

                if (bin == null || bin.Length == 0)
                {
                    return NotFound();
                }

                return File(
                    fileContents: bin,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: Name +".xlsx"
                );
            }

                

        }
    }
}