using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterdimensionalThings;
using InterdimensionalThings.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InterdimensionalThings.Data;
using InterdimensionalThings.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterdimensionalThings.Controllers
{
    public class CheckoutController : Controller
    {


        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        private IEmailSender _emailSender;

        public CheckoutController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _context = context;
            _emailSender = emailSender;

        }





        // GET: /<controller>/
        public IActionResult Index()
        {
            CheckoutModel model = new CheckoutModel();
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = _userManager.GetUserAsync(User).Result;
                model.Email = currentUser.Email;
            }

            return View(model);        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CheckoutModel model)

        {
            if(!ModelState.IsValid){




                ThingsOrder order = new ThingsOrder
                {
                    City = model.City,
                    State = model.State,
                    Email = model.Email,
                    StreetAddress = model.StreetAddress,
                    ZipCode = model.ZipCode,
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                };

                ThingCart cart = null;
                if (User.Identity.IsAuthenticated)
                {
                    var currentUser = _userManager.GetUserAsync(User).Result;
                    cart = _context.ThingCarts.Include(x => x.ThingCartThings).ThenInclude(x => x.Thing).Single(x => x.ApplicationUserID == currentUser.Id);


                }
                else if (Request.Cookies.ContainsKey("cart_id")) //Use this consistently!  If you use CaRt_ID, it's a different KEY!
                {
                    int existingCartID = int.Parse(Request.Cookies["cart_id"]);
                    cart = _context.ThingCarts.Include(x => x.ThingCartThings).ThenInclude(x => x.Thing).FirstOrDefault(x => x.ID == existingCartID);
                }
                foreach (var cartItem in cart.ThingCartThings)
                {
                    order.ThingsOrderThings.Add(new ThingsOrderThing
                    {
                        DateCreated = DateTime.Now,
                        DateLastModified = DateTime.Now,
                        Quantity = cartItem.Quantity ?? 1,
                        ProductID = cartItem.ThingID,
                        ProductDescription = cartItem.Thing.Description,
                        ProductName = cartItem.Thing.Name,
                        ProductPrice = cartItem.Thing.Price ?? 0
                    });
                }

                _context.ThingCartThings.RemoveRange(cart.ThingCartThings);
                _context.ThingCarts.Remove(cart);

                if (Request.Cookies.ContainsKey("cart_id"))
                {
                    Response.Cookies.Delete("cart_id");
                }

                _context.ThingsOrders.Add(order);
                _context.SaveChanges();
                await _emailSender.SendEmailAsync(model.Email, "Your order #: " + order.ID, "Thanks for your Request! You requested : " + String.Join(",", order.ThingsOrderThings.Select(x => x.ProductName)));

                return RedirectToAction("Index", "Receipt", new { id = order.ID });   

            }
            return View();

            //if(string.IsNullOrEmpty(model.Email)){
            //    return View();
            //}
            //else{
                //return RedirectToAction("Index", "Receipt", new { IDisposable = Guid.NewGuid() });
            }
        }
}
