using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterdimensionalThings.Models;
using InterdimensionalThings.Services;

namespace InterdimensionalThings.Controllers
{
    public class HomeController : Controller
    {
        private SettingsService _settingsService;

        public HomeController(SettingsService settingsService)
        {
            this._settingsService = settingsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "It's for gettin multi-verse products.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "For contacting through multiverse mail (M-mail)";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Currency(string id)
        {
            this._settingsService.SelectedCurrency = id;
            return RedirectToAction("Index");
        }

        public IActionResult Language(string id)
        {
            this._settingsService.SelectedLanguage = id;
            return RedirectToAction("Index");
        }
    }
}
