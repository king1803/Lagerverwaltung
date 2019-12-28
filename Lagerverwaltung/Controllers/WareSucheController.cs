using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lagerverwaltung.Controllers
{
    public class WareSucheController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}