using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterdimensionalThings.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterdimensionalThings.Controllers
{
    public class ThingsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string category)
        {
            List<Thing> model = new List<Thing>();
            model.Add(new Thing { Id = 1, Name = "Eyeholes", Description = "Get up on out of here with my Eyeholes!", Price = 25.99m, ImagePath = "./images/Eyeholes.png" });
            model.Add(new Thing { Id = 1, Name = "Eyeholes", Description = "Get up on out of here with my Eyeholes!", ImagePath = "./images/Eyeholes.png" });


            if(string.IsNullOrEmpty(category)){
                ViewBag.message = "Get All Products";
                ViewData["Title"] = "Get All Products";
            }
            else if(category.ToLowerInvariant() == "no"){
                ViewBag.message = "no things";
                ViewData["Title"] = "no things";

            }
            else if (category.ToLowerInvariant() == "is")
            {
                ViewBag.message = "things are";
                ViewData["Title"] = "thing are";

            }
            return View(model);
        }
    }
}
