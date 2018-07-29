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
            model.Add(new Thing { Id = 1, Name = "Strawberry Smiggles",         Description = "Here they are! This is cereal that has strawbery flavored smiggles in it. Seems to be a lovely breakfast experience. That guy gets his guts torn out, though, in the ad.", ImagePath = "/images/strawberrysmiggles.jpeg", Price = 18.43m, Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing { Id = 2, Name = "Eyeholes",                    Description = "Get up on out of here with my Eyeholes!", Price = 25.99m, ImagePath = "/images/Eyeholes.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing { Id = 3, Name = "TurbulentJuice",              Description = "Turbulent Juice is a multi-purpose cleaning product and nutritional supplement fluid advertised on cable channels based in dimensions other than C-137. Beyond quickly and effortlessly transforming most any household appliance or object from a dirty, scum-ridden mess into a shining paragon of next to godly cleanliness, Turbulent Juice is also capable of turning skinny 98 pound weakling Michaels into buff studly Mannys.Ingredients: juice(preferably sourced from phallic volcanoes for maximum turblence).", Price = 98.99m, ImagePath = "/images/TurbulentJuice.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing { Id = 4, Name = "PortalGun",                   Description = "Create portals for interdimensional travel! Portals allow travel between two different locations. Usually, these locations exist in the same universe. The only groups that have been known to use intergalactic portal technology are the Ricks and the Galactic Federation. Some organizations and people have knowledge of interdimensional portal technology, but it is unclear whether they possess it or not. The Portal Gun is a gadget that allows the user(s) to travel between different universes / dimensions / realities.The Gun was likely created by a Rick Sanchez, although it is unknown which one; if there is any truth to C-137's fabricated origin story, then he may not be the original inventor. ", Price = 98.99m, ImagePath = "/images/portalGun.png", Category = "prototypes", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing { Id = 5, Name = "Plumbus",                     Description = "Crech one; if there is any truth to C-137's fabricated origin story, then he may not be the original inventor. ", Price = 80229.99m, ImagePath = "/images/Plumbus.png", Category = "Plumbus", Quality = "Stable", ShippingDays = 873, Maker = "Nike" });
            model.Add(new Thing { Id = 6, Name = "Lil Bits",                    Description = "s!",               Price = 25.99m, ImagePath = "/images/LilBits.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing { Id = 7, Name = "Space cruiser",               Description = "s!",               Price = 25.99m, ImagePath = "/images/SpaceCruiser.png", Category = "itv", Quality = "Stable", ShippingDays=873, Maker="Gromflamites"});
            model.Add(new Thing {Id = 8,  Name = "Neutrino bomb",                Description = "s!",              Price = 25.99m, ImagePath = "/images/NeutrinoBomb.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 9,  Name = "Operation Phoenix",               Description = "s!",           Price = 25.99m, ImagePath = "/images/OperationPhoenix.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 10, Name = "Combat suit",                     Description = "s!",           Price = 25.99m, ImagePath = "/images/CombatSuit.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 11, Name = "Freeze ray",                      Description = "s!",           Price = 25.99m, ImagePath = "/images/FreezeRay.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 12, Name = "Cognition amplifier",           Description = "s!",             Price = 25.99m, ImagePath = "/images/CognitionAmplifier.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 13, Name = "Dream inceptor",                 Description = "s!",            Price = 25.99m, ImagePath = "/images/DreamInceptor.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 14, Name = "Shrink ray",                    Description = "s!",             Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 15, Name = "vDark matter",                    Description = "s!",           Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 16, Name = "vMeeseeks Box",                    Description = "s!",          Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 17, Name = "Ionic Defibulizer",               Description = "s!",           Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 18, Name = "Demonic Alien Containment Box",   Description = "s!",           Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 19, Name = "Love Potion",                      Description = "s!",          Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 20, Name = "Love Antidote",                     Description = "s!",         Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 21, Name = "Particle Beam Wrist Watch",       Description = "s!",           Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 22, Name = "Microverse battery",               Description = "s!",          Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 9,  Name = "Operation Phoenix",               Description = "s!",           Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            model.Add(new Thing {Id = 10, Name = "Combat suit",                      Description = "s!",          Price = 25.99m, ImagePath = "/images/LilBitz.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
                                                                    

  
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
