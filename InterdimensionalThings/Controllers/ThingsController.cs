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

            if(string.IsNullOrEmpty(category)){
                //ViewBag.message = "Get All Products";
                model.Add(new Thing { Id = 2, Name = "Strawberry Smiggles", Description = "Here they are!", ImagePath = "/images/strawberrysmiggles.jpeg", Price = 18.43m, category = "prototypes" });
                model.Add(new Thing { Id = 1, Name = "Eyeholes", Description = "Get up on out of here with my Eyeholes!", Price = 25.99m, ImagePath = "/images/Eyeholes.png", category = "itv" });
                ViewData["Title"] = "Get All Products";
            }
            else if (category.ToLowerInvariant() == "itv")
            {
                //ViewBag.message = "ITV";
                ViewData["Title"] = "ITV";
                model.Add(new Thing { Id = 1, Name = "Eyeholes", Description = "Get up on out of here with my Eyeholes!", Price = 25.99m, ImagePath = "/images/Eyeholes.png", category = "itv" });
            }
            else if (category.ToLowerInvariant() == "prototypes")
            {
                ViewData["Title"] = "Prototypes";
                model.Add(new Thing { Id = 2, Name = "Strawberry Smiggles", Description = "Here they are!", ImagePath = "/images/strawberrysmiggles.jpeg", Price = 18.43m, category = "prototypes"});
            }
            return View(model);
        }
        public IActionResult Details(int? id)
        {
            Thing model = new Thing
            {
                Id = 2,
                Name = "Strawberry Smiggles",
                Description = "Here they are!",
                ImagePath = "/images/strawberrysmiggles.jpeg"
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Details(int? id, int quantity, string color){
            Console.WriteLine("User added " + id.ToString() + " , " + quantity.ToString() + ", " + color);
            return RedirectToAction("Index", "Cart");
        }
    }
}
