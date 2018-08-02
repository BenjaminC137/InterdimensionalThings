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
            ViewData["Message"] = "It's for gettin multi-verse products. It all started one beautiful, foggy, humid, arabian night about 19 years ago. I was traveling along the Gazorpazorpian mountain range, and I suddenly heard a loud fploofpftrorph. It was the last thing I expected. Obviously I needed to proceed to the nearest inter-galactic hospital, but as you probably already know, I was in quite a lot of trouble with the Galactic Federation due to my nutglobbering shnoozyfoldalongs. If the grophs hadn't molmpreeets my glibber-holes, then I would've halp had the flimft glomft gleereries of glorpson glopsin glooverietrophen. But all of that in a different time. For now, let's get back to creating this wonderful transaction station situation known as Interdimensionsl Things. It's where you can browse amogst the things I've discovered that I through worth spreading. I have a currier service that can travel multidemensionally. It's like amazon prime, only it delivers when it's supposed to. Otherwise, it has to pay to go back in time and correct the mess. There's no blarmfletoods in ract romphis galuou fbloonkooders ville nut ball ganter.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Please contact through multiverse mail (M-mail) as I hate taking phone calls. Don't forget the leading '0's, '1's, and '0&1's Thank you.";

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
