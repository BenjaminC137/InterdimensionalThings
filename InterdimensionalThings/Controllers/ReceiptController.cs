using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InterdimensionalThings.Models;
using InterdimensionalThings.Data;

namespace InterdimensionalThings.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReceiptController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receipt/Details/5
        public async Task<IActionResult> Index(Guid? id)
        {
            ReceiptModel model = new ReceiptModel();
            if (id == null)
            {
                return NotFound();
            }
            model.ThingsOrder = await _context.ThingsOrders.Include(x => x.ThingsOrderThings)
               .SingleOrDefaultAsync(m => m.ID == id);

            var thingIds = model.ThingsOrder.ThingsOrderThings.Where(x => x.ProductID.HasValue).Select(x => x.ProductID.Value);

            model.Things = await _context.Things.Where(x => thingIds.Contains(x.Id)).ToArrayAsync();

            return View(model);
        }



    }
}