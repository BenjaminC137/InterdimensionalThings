using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterdimensionalThings.Models;
using MySql.Data.MySqlClient;
using InterdimensionalThings.Data;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterdimensionalThings.Controllers
{

    public class ThingsController : Controller
    {
        public string Color { get; set; }

        private ApplicationDbContext _context;

        public ThingsController(ApplicationDbContext context)
        {
            this._context = context;
        }
        //private MySqlConnection _connection;
        // GET: /<controller>/
        public IActionResult Index(string category, string search, string id)
        {
            //List<Thing> model;

            //if(!string.IsNullOrEmpty(category))
            //{
            //    model = _context.Things.Where(x => x.Category == category).ToList(); 
            //} 
            //else
            //{
            //    model = _context.Things.ToList();
            //}

            //MySqlConnection connection = new MySqlConnection();
            //MySqlCommand command = connection.CreateCommand();
            //command.E
            if (_context.Things.Count() == 0)
            {
                List<Thing> Inventions = new List<Thing>();

                Inventions.Add(new Thing { Id = 4, Name = "PortalGun", Description = "Create portals for interdimensional travel! Portals allow travel between two different locations. Usually, these locations exist in the same universe. The only groups that have been known to use intergalactic portal technology are the Ricks and the Galactic Federation. Some organizations and people have knowledge of interdimensional portal technology, but it is unclear whether they possess it or not. The Portal Gun is a gadget that allows the user(s) to travel between different universes / dimensions / realities.The Gun was likely created by a Rick Sanchez, although it is unknown which one; if there is any truth to C-137's fabricated origin story, then he may not be the original inventor. ", Price = 98.99m, ImagePath = "/images/portalGun.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C-137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 7, Name = "Space Cruiser", Description = "The Space Cruiser is a UFO-like flying vehicle created by Rick Sanchez, possessing numerous gadgets and the ability to fly through outer space. Gadgets and Abilities: Microverse Battery: The Microverse Battery is a gadget developed by Rick to supply power to this flying ship.It contains a miniature universe that Rick created in which organic, and some intelligent life, had developed.He then introduced electricity to the miniature planet with intelligent life inside his Microverse in the form of kinetic devices, under the pretence that the inhabitants could use the devices to generate electricity to power their homes and devices.Unknowingly to them, however, the vast majority of the power they generated(and in fact their entire universe's existence) went into powering this ship. Keeping passengers Safe. It also exhibits a formidable array of weaponry, artificial intelligence.Committed to fulfilling its task, it can slice up a man, paralyse another, mentally scar with a melting delusion of one's dead child, and successfully negotiate peace between mankind and the Giant Telepathic Spiders or others that inhabited that particular dimension. Body Switching There is a button that, when sitting in the pilot and co - pilot seats, switches the minds of both individuals.", Price = 25.99m, ImagePath = "/images/SpaceCruiser.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 8, Name = "Neutrino Bomb", Description = "Bomb created to destroy the planet in order to make a fresh new start. Very dangerous!!!", Price = 215.99m, ImagePath = "/images/NeutrinoBomb.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 3, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 9, Name = "Particle Beam Wrist Watch", Description = "Instantly vaporizes targets", Price = 2.99m, ImagePath = "/images/ParticleBeamWristWatch.jpg", Category = "prototypes", Quality = "Stable", ShippingDays = 2, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 10, Name = "Combat Suit", Description = "Suit of armor adding robotic abilities including advanced weaponry and flying via hover jets on boots.", Price = 188.99m, ImagePath = "/images/CombatSuit.png", Category = "prototypes", Quality = "Stable", ShippingDays = 9, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 12, Name = "Cognition Amplifier", Description = "Helmet that increases the cognitive abilities and intelligence of it's user. Can be used on animals.", Price = 61.99m, ImagePath = "/images/CognitionAmplifier.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 873, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 11, Name = "Freeze Ray", Description = "Gun that freezes targets until either you unfreeze them (sold separately) or they shatter/melt.", Price = 25.00m, ImagePath = "/images/FreezeRay.jpeg", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 13, Name = "Dream Inceptor", Description = "Item that when you put in in someone's ear, you can enter their dreams.", Price = 25.00m, ImagePath = "/images/DreamInceptor.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 873, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 14, Name = "Shrink Ray", Description = "Device that shrinks targets beneath it to cellular sized organisms.", Price = 445.76m, ImagePath = "/images/ShrinkRay.png", Category = "prototypes", Quality = "Stable", ShippingDays = 45, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 15, Name = "Love Potion", Description = "Anybody that you put this on will fall in love with you forever. DO NOT USE if you have the flu.", Price = 29.99m, ImagePath = "/images/LovePotion.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 16, Name = "Meeseeks Box", Description = " It is a gadget which creates a Mr. Meeseeks for the purpose of completing one objective. Once it completes the objective, Mr. Meeseeks vanishes.", Price = 35.99m, ImagePath = "/images/MeeseeksBox.png", Category = "prototypes", Quality = "Stable", ShippingDays = 31, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 17, Name = "Ionic Defibulizer", Description = "Not a lot is known about this except that it was never completely finished by it's inventor, Rick Sanchez. We do know that it caused the Cronenberg-ization of Earth Dimension C-137.", Price = 21.99m, ImagePath = "/images/IonicDefibulizer.png", Category = "prototypes", Quality = "Stable", ShippingDays = 13, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                Inventions.Add(new Thing { Id = 18, Name = "Microverse battery", Description = "The Microverse Battery contains a miniature universe with a planet inhabited by intelligent life. These lifeforms use kinetic devices, which were given to them by Rick, to produce electricity. Under the guise of waste power a majority of the energy produced is extracted by Rick to power his ship. The people of this world consider Rick to be a benevolent alien, when in fact, he is using them as slaves. Trouble occurs when a scientist in this miniature world, Zeep Xanflorp, invents his own Microverse Battery (which he calls a 'Miniverse') to provide his people with energy, thus making the kinetic devices Rick installed obsolete.  Construction Microverse - made by Rick; energy extraction via goobleboxes Miniverse - made by Zeep Xanflorp; energy extraction via flooblecrank Teenyverse - made by Kyle; planned energy extraction via bloobleyank Rick describes creating a spatially tessellated void inside a modified temporal field, while Zeep Xanflorp describes his miniverse as an unbounded vacuum inside a temporal field.  Zeep Xanflorp states that 80% of the energy made by the inhabitants of his Miniverse is extracted for his use, while Rick does not state precisely how much of the Mircoverse's energy is extracted saying only that 'some of it' powers his ship. The Television broadcast in the Microverse world suggests that he is extracting about two thirds of the energy generated.", Price = 25.00m, ImagePath = "/images/MicroverseBattery.png", Category = "prototypes", Quality = "Relatively Stable", ShippingDays = 364, Maker = "Rick Sanchez, Earth C137", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });

                _context.ThingCategory.Add(new ThingCategory { Name = "Inventions", Things = Inventions });

                List<Thing> ads = new List<Thing>();
                ads.Add(new Thing { Id = 2, Name = "Eyeholes", Description = "Get up on out of here with my Eyeholes!", Price = 25.99m, ImagePath = "/images/Eyeholes.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                ads.Add(new Thing { Id = 1, Name = "Strawberry Smiggles", Description = "Here they are! This is cereal that has strawbery flavored smiggles in it. Seems to be a lovely breakfast experience. That guy gets his guts torn out, though, in the ad.", ImagePath = "/images/strawberrysmiggles.jpeg", Price = 18.43m, Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                ads.Add(new Thing { Id = 3, Name = "TurbulentJuice", Description = "Turbulent Juice is a multi-purpose cleaning product and nutritional supplement fluid advertised on cable channels based in dimensions other than C-137. Beyond quickly and effortlessly transforming most any household appliance or object from a dirty, scum-ridden mess into a shining paragon of next to godly cleanliness, Turbulent Juice is also capable of turning skinny 98 pound weakling Michaels into buff studly Mannys.Ingredients: juice(preferably sourced from phallic volcanoes for maximum turblence).", Price = 98.99m, ImagePath = "/images/TurbulentJuice.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                ads.Add(new Thing { Id = 5, Name = "Plumbus", Description = "Crech one; if there is any truth to C-137's fabricated origin story, then he may not be the original inventor. ", Price = 829.99m, ImagePath = "/images/Plumbus.png", Category = "itv", Quality = "Stable", ShippingDays = 8, Maker = "Nike", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });
                ads.Add(new Thing { Id = 6, Name = "Lil Bits", Description = "We've got tiny lasagna, tiny pizza, tiny pie. Mmm! Little tiny fried eggs! Everything on the menu is extremely tiny shaped, intended for people with tiny mouths.For those that have large spherical heads with small facial features.", Price = 200.98m, ImagePath = "/images/LilBits.png", Category = "itv", Quality = "Stable", ShippingDays = 3, Maker = "Big Heads", DateCreated = DateTime.Now, DateLastModified = DateTime.Now });

                _context.ThingCategory.Add(new ThingCategory { Name = "As Seen On TV", Things = ads });

                //_context.Things.AddRange(Inventions);
                //_context.Things.AddRange(ads);

                _context.SaveChanges();
            }

            ViewBag.selectedCategory = category;
            List<Thing> model;
            if (string.IsNullOrEmpty(category))
            {
                model = this._context.Things.ToList();
            }
            else
            {
                model = this._context.Things.Where(x => x.ThingCategoryName == category).ToList();

            }
            ViewData["Categories"] = this._context.ThingCategory.Select(x => x.Name).ToArray();

            //  if(string.IsNullOrEmpty(category)){
            //      //ViewBag.message = "Get All Products";

            //      ViewData["Title"] = "Get All Products";
            //  }
            //  else if (category.ToLowerInvariant() == "itv")
            //  {
            //      //ViewBag.message = "ITV";
            //      ViewData["Title"] = "ITV";
            //      model = model.Where(x => x.Category.ToLowerInvariant().Contains(category)).ToList();

            //  }
            //  else if (category.ToLowerInvariant() == "prototypes")
            //  {
            //      ViewData["Title"] = "Prototypes";
            //      model = model.Where(x => x.Category.ToLowerInvariant().Contains(category.ToLowerInvariant())).ToList();

            //  }

            //  if(!string.IsNullOrEmpty(search)){
            //      model = model.Where(x => x.Description.ToLowerInvariant().Contains(search.ToLowerInvariant()) || x.Name.ToLowerInvariant().Contains(search.ToLowerInvariant())).ToList();
            //  }
            return View(model);

        }

        public IActionResult Details(int? id)
        {

            var model = _context.Things.Find(id);


            //List<Thing> model = new List<Thing>();


            //MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            //connectionString.Server = "127.0.0.1";
            //connectionString.UserID = "root";
            //connectionString.Password = "password";
            //connectionString.Database = "NewDatabase";
            //MySqlConnection connection = new MySqlConnection(connectionString.ToString());

            //connection.Open();

            //MySqlCommand command = connection.CreateCommand();
            //command.CommandText = "SELECT * FROM THING WHERE ID = " + id + ";";

            //MySqlDataReader reader = command.ExecuteReader();


            //Thing model = new Thing();

            //int idPosition = reader.GetOrdinal("ID");
            //int namePosition = reader.GetOrdinal("Name");
            //int descriptionPosition = reader.GetOrdinal("Description");
            //int pricePosition = reader.GetOrdinal("Price");
            //int imagePathPosition = reader.GetOrdinal("ImagePath");
            //int makerPosition = reader.GetOrdinal("Maker");
            //int categoryPosition = reader.GetOrdinal("category");
            //int qualityPosition = reader.GetOrdinal("Quality");
            //int shippingDaysPosition = reader.GetOrdinal("ShippingDays");

            //while (reader.Read())
            //{

            //model.Add(new Thing { Id = 1, Name = "Strawberry Smiggles", Description = "Here they are! This is cereal that has strawbery flavored smiggles in it. Seems to be a lovely breakfast experience. That guy gets his guts torn out, though, in the ad.", ImagePath = "/images/strawberrysmiggles.jpeg", Price = 18.43m, Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            //model.Add(new Thing { Id = 2, Name = "Eyeholes", Description = "Get up on out of here with my Eyeholes!", Price = 25.99m, ImagePath = "/images/Eyeholes.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            //model.Add(new Thing { Id = 3, Name = "TurbulentJuice", Description = "Turbulent Juice is a multi-purpose cleaning product and nutritional supplement fluid advertised on cable channels based in dimensions other than C-137. Beyond quickly and effortlessly transforming most any household appliance or object from a dirty, scum-ridden mess into a shining paragon of next to godly cleanliness, Turbulent Juice is also capable of turning skinny 98 pound weakling Michaels into buff studly Mannys.Ingredients: juice(preferably sourced from phallic volcanoes for maximum turblence).", Price = 98.99m, ImagePath = "/images/TurbulentJuice.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            //model.Add(new Thing { Id = 4, Name = "PortalGun", Description = "Create portals for interdimensional travel! Portals allow travel between two different locations. Usually, these locations exist in the same universe. The only groups that have been known to use intergalactic portal technology are the Ricks and the Galactic Federation. Some organizations and people have knowledge of interdimensional portal technology, but it is unclear whether they possess it or not. The Portal Gun is a gadget that allows the user(s) to travel between different universes / dimensions / realities.The Gun was likely created by a Rick Sanchez, although it is unknown which one; if there is any truth to C-137's fabricated origin story, then he may not be the original inventor. ", Price = 98.99m, ImagePath = "/images/portalGun.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C-137" });
            //model.Add(new Thing { Id = 5, Name = "Plumbus", Description = "Crech one; if there is any truth to C-137's fabricated origin story, then he may not be the original inventor. ", Price = 829.99m, ImagePath = "/images/Plumbus.png", Category = "itv", Quality = "Stable", ShippingDays = 8, Maker = "Nike" });
            //model.Add(new Thing { Id = 6, Name = "Lil Bits", Description = "We've got tiny lasagna, tiny pizza, tiny pie. Mmm! Little tiny fried eggs! Everything on the menu is extremely tiny shaped, intended for people with tiny mouths.For those that have large spherical heads with small facial features.", Price = 200.98m, ImagePath = "/images/LilBits.png", Category = "itv", Quality = "Stable", ShippingDays = 3, Maker = "Big Heads" });
            //model.Add(new Thing { Id = 7, Name = "Space Cruiser", Description = "The Space Cruiser is a UFO-like flying vehicle created by Rick Sanchez, possessing numerous gadgets and the ability to fly through outer space. Gadgets and Abilities: Microverse Battery: The Microverse Battery is a gadget developed by Rick to supply power to this flying ship.It contains a miniature universe that Rick created in which organic, and some intelligent life, had developed.He then introduced electricity to the miniature planet with intelligent life inside his Microverse in the form of kinetic devices, under the pretence that the inhabitants could use the devices to generate electricity to power their homes and devices.Unknowingly to them, however, the vast majority of the power they generated(and in fact their entire universe's existence) went into powering this ship. Keeping passengers Safe. It also exhibits a formidable array of weaponry, artificial intelligence.Committed to fulfilling its task, it can slice up a man, paralyse another, mentally scar with a melting delusion of one's dead child, and successfully negotiate peace between mankind and the Giant Telepathic Spiders or others that inhabited that particular dimension. Body Switching There is a button that, when sitting in the pilot and co - pilot seats, switches the minds of both individuals.", Price = 25.99m, ImagePath = "/images/SpaceCruiser.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 8, Name = "Neutrino Bomb", Description = "Bomb created to destroy the planet in order to make a fresh new start. Very dangerous!!!", Price = 215.99m, ImagePath = "/images/NeutrinoBomb.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 3, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 9, Name = "Particle Beam Wrist Watch", Description = "Instantly vaporizes targets", Price = 2.99m, ImagePath = "/images/ParticleBeamWristWatch.jpg", Category = "prototypes", Quality = "Stable", ShippingDays = 2, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 10, Name = "Combat Suit", Description = "Suit of armor adding robotic abilities including advanced weaponry and flying via hover jets on boots.", Price = 188.99m, ImagePath = "/images/CombatSuit.png", Category = "prototypes", Quality = "Stable", ShippingDays = 9, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 12, Name = "Cognition Amplifier", Description = "Helmet that increases the cognitive abilities and intelligence of it's user. Can be used on animals.", Price = 61.99m, ImagePath = "/images/CognitionAmplifier.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 873, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 11, Name = "Freeze Ray", Description = "Gun that freezes targets until either you unfreeze them (sold separately) or they shatter/melt.", Price = 25.00m, ImagePath = "/images/FreezeRay.jpeg", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 13, Name = "Dream Inceptor", Description = "Item that when you put in in someone's ear, you can enter their dreams.", Price = 25.00m, ImagePath = "/images/DreamInceptor.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 873, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 14, Name = "Shrink Ray", Description = "Device that shrinks targets beneath it to cellular sized organisms.", Price = 445.76m, ImagePath = "/images/ShrinkRay.png", Category = "prototypes", Quality = "Stable", ShippingDays = 45, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 15, Name = "Love Potion", Description = "Anybody that you put this on will fall in love with you forever. DO NOT USE if you have the flu.", Price = 29.99m, ImagePath = "/images/LovePotion.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 16, Name = "Meeseeks Box", Description = " It is a gadget which creates a Mr. Meeseeks for the purpose of completing one objective. Once it completes the objective, Mr. Meeseeks vanishes.", Price = 35.99m, ImagePath = "/images/MeeseeksBox.png", Category = "prototypes", Quality = "Stable", ShippingDays = 31, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 17, Name = "Ionic Defibulizer", Description = "Not a lot is known about this except that it was never completely finished by it's inventor, Rick Sanchez. We do know that it caused the Cronenberg-ization of Earth Dimension C-137.", Price = 21.99m, ImagePath = "/images/IonicDefibulizer.png", Category = "prototypes", Quality = "Stable", ShippingDays = 13, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 18, Name = "Microverse battery", Description = "The Microverse Battery contains a miniature universe with a planet inhabited by intelligent life. These lifeforms use kinetic devices, which were given to them by Rick, to produce electricity. Under the guise of waste power a majority of the energy produced is extracted by Rick to power his ship. The people of this world consider Rick to be a benevolent alien, when in fact, he is using them as slaves. Trouble occurs when a scientist in this miniature world, Zeep Xanflorp, invents his own Microverse Battery (which he calls a 'Miniverse') to provide his people with energy, thus making the kinetic devices Rick installed obsolete.  Construction Microverse - made by Rick; energy extraction via goobleboxes Miniverse - made by Zeep Xanflorp; energy extraction via flooblecrank Teenyverse - made by Kyle; planned energy extraction via bloobleyank Rick describes creating a spatially tessellated void inside a modified temporal field, while Zeep Xanflorp describes his miniverse as an unbounded vacuum inside a temporal field.  Zeep Xanflorp states that 80% of the energy made by the inhabitants of his Miniverse is extracted for his use, while Rick does not state precisely how much of the Mircoverse's energy is extracted saying only that 'some of it' powers his ship. The Television broadcast in the Microverse world suggests that he is extracting about two thirds of the energy generated.", Price = 25.00m, ImagePath = "/images/MicroverseBattery.png", Category = "prototypes", Quality = "Relatively Stable", ShippingDays = 364, Maker = "Rick Sanchez, Earth C137" });

            //Thing model = new Thing();
            //model.Add(new Thing
            //{
            //    Id = reader.GetInt32(idPosition),
            //    Name = reader.GetString(namePosition),
            //    Description = reader.GetString(descriptionPosition),
            //    Price = reader.IsDBNull(pricePosition) ? (decimal?)null : reader.GetDecimal(pricePosition),
            //    ImagePath = reader.GetString(imagePathPosition),
            //    Maker = reader.GetString(makerPosition),
            //    Category = reader.GetString(categoryPosition),
            //    Quality = reader.GetString(qualityPosition),
            //    ShippingDays = reader.GetInt32(shippingDaysPosition)
            //});

            //connection.Close();




            //        List<Thing> model = new List<Thing>();
            //model.Add(new Thing { Id = 1, Name = "Strawberry Smiggles", Description = "Here they are! This is cereal that has strawbery flavored smiggles in it. Seems to be a lovely breakfast experience. That guy gets his guts torn out, though, in the ad.", ImagePath = "/images/strawberrysmiggles.jpeg", Price = 18.43m, Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            //model.Add(new Thing { Id = 2, Name = "Eyeholes", Description = "Get up on out of here with my Eyeholes!", Price = 25.99m, ImagePath = "/images/Eyeholes.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            //model.Add(new Thing { Id = 3, Name = "TurbulentJuice", Description = "Turbulent Juice is a multi-purpose cleaning product and nutritional supplement fluid advertised on cable channels based in dimensions other than C-137. Beyond quickly and effortlessly transforming most any household appliance or object from a dirty, scum-ridden mess into a shining paragon of next to godly cleanliness, Turbulent Juice is also capable of turning skinny 98 pound weakling Michaels into buff studly Mannys.Ingredients: juice(preferably sourced from phallic volcanoes for maximum turblence).", Price = 98.99m, ImagePath = "/images/TurbulentJuice.png", Category = "itv", Quality = "Stable", ShippingDays = 873, Maker = "Gromflamites" });
            //model.Add(new Thing { Id = 4, Name = "PortalGun", Description = "Create portals for interdimensional travel! Portals allow travel between two different locations. Usually, these locations exist in the same universe. The only groups that have been known to use intergalactic portal technology are the Ricks and the Galactic Federation. Some organizations and people have knowledge of interdimensional portal technology, but it is unclear whether they possess it or not. The Portal Gun is a gadget that allows the user(s) to travel between different universes / dimensions / realities.The Gun was likely created by a Rick Sanchez, although it is unknown which one; if there is any truth to C-137's fabricated origin story, then he may not be the original inventor. ", Price = 98.99m, ImagePath = "/images/portalGun.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C-137" });
            //model.Add(new Thing { Id = 5, Name = "Plumbus", Description = "Crech one; if there is any truth to C-137's fabricated origin story, then he may not be the original inventor. ", Price = 829.99m, ImagePath = "/images/Plumbus.png", Category = "itv", Quality = "Stable", ShippingDays = 8, Maker = "Nike" });
            //model.Add(new Thing { Id = 6, Name = "Lil Bits", Description = "We've got tiny lasagna, tiny pizza, tiny pie. Mmm! Little tiny fried eggs! Everything on the menu is extremely tiny shaped, intended for people with tiny mouths.For those that have large spherical heads with small facial features.", Price = 200.98m, ImagePath = "/images/LilBits.png", Category = "itv", Quality = "Stable", ShippingDays = 3, Maker = "Big Heads" });
            //model.Add(new Thing { Id = 7, Name = "Space Cruiser", Description = "The Space Cruiser is a UFO-like flying vehicle created by Rick Sanchez, possessing numerous gadgets and the ability to fly through outer space. Gadgets and Abilities: Microverse Battery: The Microverse Battery is a gadget developed by Rick to supply power to this flying ship.It contains a miniature universe that Rick created in which organic, and some intelligent life, had developed.He then introduced electricity to the miniature planet with intelligent life inside his Microverse in the form of kinetic devices, under the pretence that the inhabitants could use the devices to generate electricity to power their homes and devices.Unknowingly to them, however, the vast majority of the power they generated(and in fact their entire universe's existence) went into powering this ship. Keeping passengers Safe. It also exhibits a formidable array of weaponry, artificial intelligence.Committed to fulfilling its task, it can slice up a man, paralyse another, mentally scar with a melting delusion of one's dead child, and successfully negotiate peace between mankind and the Giant Telepathic Spiders or others that inhabited that particular dimension. Body Switching There is a button that, when sitting in the pilot and co - pilot seats, switches the minds of both individuals.", Price = 25.99m, ImagePath = "/images/SpaceCruiser.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 8, Name = "Neutrino Bomb", Description = "Bomb created to destroy the planet in order to make a fresh new start. Very dangerous!!!", Price = 215.99m, ImagePath = "/images/NeutrinoBomb.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 3, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 9, Name = "Particle Beam Wrist Watch", Description = "Instantly vaporizes targets", Price = 2.99m, ImagePath = "/images/ParticleBeamWristWatch.jpg", Category = "prototypes", Quality = "Stable", ShippingDays = 2, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 10, Name = "Combat Suit", Description = "Suit of armor adding robotic abilities including advanced weaponry and flying via hover jets on boots.", Price = 188.99m, ImagePath = "/images/CombatSuit.png", Category = "prototypes", Quality = "Stable", ShippingDays = 9, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 12, Name = "Cognition Amplifier", Description = "Helmet that increases the cognitive abilities and intelligence of it's user. Can be used on animals.", Price = 61.99m, ImagePath = "/images/CognitionAmplifier.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 873, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 11, Name = "Freeze Ray", Description = "Gun that freezes targets until either you unfreeze them (sold separately) or they shatter/melt.", Price = 25.00m, ImagePath = "/images/FreezeRay.jpeg", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 13, Name = "Dream Inceptor", Description = "Item that when you put in in someone's ear, you can enter their dreams.", Price = 25.00m, ImagePath = "/images/DreamInceptor.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 873, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 14, Name = "Shrink Ray", Description = "Device that shrinks targets beneath it to cellular sized organisms.", Price = 445.76m, ImagePath = "/images/ShrinkRay.png", Category = "prototypes", Quality = "Stable", ShippingDays = 45, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 15, Name = "Love Potion", Description = "Anybody that you put this on will fall in love with you forever. DO NOT USE if you have the flu.", Price = 29.99m, ImagePath = "/images/LovePotion.png", Category = "prototypes", Quality = "Unstable", ShippingDays = 1, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 16, Name = "Meeseeks Box", Description = " It is a gadget which creates a Mr. Meeseeks for the purpose of completing one objective. Once it completes the objective, Mr. Meeseeks vanishes.", Price = 35.99m, ImagePath = "/images/MeeseeksBox.png", Category = "prototypes", Quality = "Stable", ShippingDays = 31, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 17, Name = "Ionic Defibulizer", Description = "Not a lot is known about this except that it was never completely finished by it's inventor, Rick Sanchez. We do know that it caused the Cronenberg-ization of Earth Dimension C-137.", Price = 21.99m, ImagePath = "/images/IonicDefibulizer.png", Category = "prototypes", Quality = "Stable", ShippingDays = 13, Maker = "Rick Sanchez, Earth C137" });
            //model.Add(new Thing { Id = 18, Name = "Microverse battery", Description = "The Microverse Battery contains a miniature universe with a planet inhabited by intelligent life. These lifeforms use kinetic devices, which were given to them by Rick, to produce electricity. Under the guise of waste power a majority of the energy produced is extracted by Rick to power his ship. The people of this world consider Rick to be a benevolent alien, when in fact, he is using them as slaves. Trouble occurs when a scientist in this miniature world, Zeep Xanflorp, invents his own Microverse Battery (which he calls a 'Miniverse') to provide his people with energy, thus making the kinetic devices Rick installed obsolete.  Construction Microverse - made by Rick; energy extraction via goobleboxes Miniverse - made by Zeep Xanflorp; energy extraction via flooblecrank Teenyverse - made by Kyle; planned energy extraction via bloobleyank Rick describes creating a spatially tessellated void inside a modified temporal field, while Zeep Xanflorp describes his miniverse as an unbounded vacuum inside a temporal field.  Zeep Xanflorp states that 80% of the energy made by the inhabitants of his Miniverse is extracted for his use, while Rick does not state precisely how much of the Mircoverse's energy is extracted saying only that 'some of it' powers his ship. The Television broadcast in the Microverse world suggests that he is extracting about two thirds of the energy generated.", Price = 25.00m, ImagePath = "/images/MicroverseBattery.png", Category = "prototypes", Quality = "Relatively Stable", ShippingDays = 364, Maker = "Rick Sanchez, Earth C137" });


            //model = model.Where(x => x.Id.Equals(id)).ToList();


            //return View(model);
            //}
            //reader.Close();

            //command.Dispose();
            //connection.Close();

            return View(model);

        }

        [HttpPost]
        public IActionResult AddToCart(int? id, int quantity, string color)
        {
            ThingCart cart = null;
    if (Request.Cookies.ContainsKey("cart_id"))
    {
        int existingCartID = int.Parse(Request.Cookies["cart_id"]);
        //cart = _context.ThingCarts.Find(existingCartID);
        cart = _context.ThingCarts.Include(x => x.ThingCartThings).FirstOrDefault(x => x.ID == existingCartID);
        cart.DateLastModified = DateTime.Now;
    }
        if (cart == null)
        {
            cart = new ThingCart
            {
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now
            };
            _context.ThingCarts.Add(cart);
        }
        ThingCartThing thing = cart.ThingCartThings.FirstOrDefault(x => x.ThingID == id);
        if (thing == null)
        {
            thing = new ThingCartThing
            {
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
                ThingID = id ?? 0,
                Quantity = 0
            };
            cart.ThingCartThings.Add(thing);
        }
        thing.Quantity += quantity;
        thing.DateLastModified = DateTime.Now;
        _context.SaveChanges();

        Response.Cookies.Append("cart_id", cart.ID.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
        {
            Expires = DateTime.Now.AddYears(1)
        });
        return RedirectToAction("Index", "Cart");
    }

        [HttpPost]
        public IActionResult ChangeColor(int? id, int quantity, string color)
        {
            var model = _context.Things.Find(id);

            if(color == "grayscale"){
                Color = "colorGrayscale";
                //img.Attributes["class"] += (" " + "colorGrayscale");
            }
            else{
                Color = "colorColor";
            }

            TempData["Color"] = color;
            return RedirectToAction("details", new { id = id, color=color });;
            //control.Attributes["class"] += (" " + cssClass);

            //return View(model);
            //return RedirectToAction("Index", "Cart");
        }

    }
}
