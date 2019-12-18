using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lagerverwaltung.Models;
using Lagerverwaltung.ViewModels;
using SSG_Lagerverwaltung.Data;

namespace Lagerverwaltung.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        

        

        public IActionResult Index()
        {
            var model = new HomeViewModel();
            decimal lager = _context.Lagerplatz.Count();
            decimal ware = _context.Ware.Count();
            decimal aus = Decimal.Divide(ware, lager);
            model.Auslastung = Convert.ToInt32(aus*100);
            model.AnzahlWare = _context.Ware.Count();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
