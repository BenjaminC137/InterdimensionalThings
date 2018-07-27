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
        public IActionResult Index(string category, string search)
        {
            List<Thing> model = new List<Thing>();
            model.Add(new Thing { Id = 1, Name = "Strawberry Smiggles", Description = "Here they are! This is cereal that has strawbery flavored smiggles in it. Seems to be a lovely breakfast experience. That guy gets his guts torn out, though, in the ad.", ImagePath = "/images/strawberrysmiggles.jpeg", Price = 18.43m, Category = "itv" });
            model.Add(new Thing { Id = 2, Name = "Eyeholes", Description = "Get up on out of here with my Eyeholes!", Price = 25.99m, ImagePath = "/images/Eyeholes.png", Category = "itv" });
            model.Add(new Thing { Id = 3, Name = "TurbulentJuice", Description = "Turbulent Juice is a multi-purpose cleaning product and nutritional supplement fluid advertised on cable channels based in dimensions other than C-137. Beyond quickly and effortlessly transforming most any household appliance or object from a dirty, scum-ridden mess into a shining paragon of next to godly cleanliness, Turbulent Juice is also capable of turning skinny 98 pound weakling Michaels into buff studly Mannys.Ingredients: juice(preferably sourced from phallic volcanoes for maximum turblence).", Price = 98.99m, ImagePath = "/images/TurbulentJuice.png", Category = "itv" });
            model.Add(new Thing { Id = 4, Name = "PortalGun", Description = "Create portals for interdimensional travel! Portals allow travel between two different locations. Usually, these locations exist in the same universe. The only groups that have been known to use intergalactic portal technology are the Ricks and the Galactic Federation. Some organizations and people have knowledge of interdimensional portal technology, but it is unclear whether they possess it or not. The Portal Gun is a gadget that allows the user(s) to travel between different universes / dimensions / realities.The Gun was likely created by a Rick Sanchez, although it is unknown which one; if there is any truth to C-137's fabricated origin story, then he may not be the original inventor. ", Price = 98.99m, ImagePath = "/images/portalGun.png", Category = "prototypes" });

  
            if(string.IsNullOrEmpty(category)){
                //ViewBag.message = "Get All Products";

                ViewData["Title"] = "Get All Products";
            }
            else if (category.ToLowerInvariant() == "itv")
            {
                //ViewBag.message = "ITV";
                ViewData["Title"] = "ITV";
                model = model.Where(x => x.Category.ToLowerInvariant().Contains(category)).ToList();

            }
            else if (category.ToLowerInvariant() == "prototypes")
            {
                ViewData["Title"] = "Prototypes";
                model = model.Where(x => x.Category.ToLowerInvariant().Contains(category.ToLowerInvariant())).ToList();

            }

            if(!string.IsNullOrEmpty(search)){
                model = model.Where(x => x.Description.ToLowerInvariant().Contains(search.ToLowerInvariant()) || x.Name.ToLowerInvariant().Contains(search.ToLowerInvariant())).ToList();
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
        public IActionResult AddToCart(int? id, int quantity, string color){
            //Console.WriteLine("User added " + id.ToString() + " , " + quantity.ToString() + ", " + color);
            //Thing model = new Thing
            //{
            //    Id = 2,
            //    Name = "Strawberry Smiggles",
            //    Description = "Here they are!",
            //    ImagePath = "/images/strawberrysmiggles.jpeg"
            //};
            //return View(model);

            return RedirectToAction("Index", "Cart");
        }
    }
}
