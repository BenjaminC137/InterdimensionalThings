using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterdimensionalThings;
using InterdimensionalThings.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterdimensionalThings.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CheckoutModel model)

        {
            if(!ModelState.IsValid){
                return RedirectToAction("Index", "Receipt", new { IDisposable = Guid.NewGuid() });

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
