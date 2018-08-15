﻿using System;
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
using Braintree;
using SmartyStreets.USStreetApi;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterdimensionalThings.Controllers
{
    public class CheckoutController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        private IEmailSender _emailSender;

        private IBraintreeGateway _braintreeGateway;
        private Client _client;

        public CheckoutController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender, IBraintreeGateway braintreeGateway, Client client)
        {
            _userManager = userManager;
            _context = context;
            _emailSender = emailSender;
            _braintreeGateway = braintreeGateway;
            _client = client;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            CheckoutModel model = new CheckoutModel();
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                model.Email = currentUser.Email;
            }
            ViewBag.ClientAuthorization = await _braintreeGateway.ClientToken.GenerateAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CheckoutModel model, string nonce)
        {
            if (ModelState.IsValid)
            {
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

                var result = await _braintreeGateway.Transaction.SaleAsync(new TransactionRequest
                {
                    Amount = order.ThingsOrderThings.Sum(x => x.Quantity * x.ProductPrice),
                    PaymentMethodNonce = nonce,
                    LineItems = order.ThingsOrderThings.Select(x => new TransactionLineItemRequest
                    {
                        Description = x.ProductDescription,
                        Name = x.ProductName,
                        Quantity = x.Quantity,
                        ProductCode = x.ProductID.Value.ToString(),
                        UnitAmount = x.ProductPrice,
                        TotalAmount = x.ProductPrice * x.Quantity,
                        LineItemKind = TransactionLineItemKind.DEBIT
                    }).ToArray()
                });

                await _emailSender.SendEmailAsync(model.Email, "Your order " + order.ID, "Thanks for ordering!  You bought : " + String.Join(",", order.ThingsOrderThings.Select(x => x.ProductName)));

                return RedirectToAction("Index", "Receipt", new { id = order.ID });
            }
            //TODO: we have an error!  Redisplay the form!
            return View();
        }


        [HttpPost]
        public IActionResult ValidateAddress([FromBody] Lookup lookup)
        {
            try
            {
                _client.Send(lookup);
                return Json(lookup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
