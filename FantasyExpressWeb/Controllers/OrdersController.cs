using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FantasyExpressApi.Models;
using FantasyExpressApi.Models.TableClasses;
using FantasyExpressWeb.Models.BuisnessLogic;

namespace FantasyExpressWeb.Controllers
{
    public class OrdersController : Controller
    {
        private readonly FantasyExpressDbContext _context;

        public OrdersController(FantasyExpressDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var fantasyExpressDbContext = _context.Orders.Include(o => o.Delivery).Include(o => o.Payment);
            return View(await fantasyExpressDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Delivery)
                .Include(o => o.Payment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["DeliveryId"] = new SelectList(_context.Deliveries, "Id", "Name");
            ViewData["PaymentId"] = new SelectList(_context.Payments, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeliveryId,PaymentId")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.IsActive = true;
                order.CreatedDate = DateTime.Now;
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeliveryId"] = new SelectList(_context.Deliveries, "Id", "Name", order.DeliveryId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "Id", "Name", order.PaymentId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["DeliveryId"] = new SelectList(_context.Deliveries, "Id", "Name", order.DeliveryId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "Id", "Name", order.PaymentId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeliveryId,PaymentId,IsActive")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    order.ModifiedDate = DateTime.Now;
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeliveryId"] = new SelectList(_context.Deliveries, "Id", "Name", order.DeliveryId);
            ViewData["PaymentId"] = new SelectList(_context.Payments, "Id", "Name", order.PaymentId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Delivery)
                .Include(o => o.Payment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'FantasyExpressDbContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult Data()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
            Data([Bind("DeliveryId,PaymentId")]Order order)
        {
            if (ModelState.IsValid)
            {
                order.CreatedDate = DateTime.Now;
                order.IsActive = true;
                await _context.AddAsync(order);
                CartB cartB = new CartB(this._context, this.HttpContext);
                var cartItems = await cartB.GetCartItemList();

                foreach (var element in cartItems)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        MealId = element.MealId,
                        Quantity = element.Quantity,
                        TotalPrice = Convert.ToDecimal(element.Quantity * element.Meal.Price),
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                    };
                    order.OrderItems.Add(orderItem);
                    await _context.OrderItems.AddAsync(orderItem);
                }
                order.TotalPrice = await cartB.GetTotal();
                await _context.SaveChangesAsync();
                return RedirectToAction ("Details", new {id = order.Id });
            }
            return View();
        }
        public async Task<ActionResult> Summary (int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(z => z.Id == id);
            
            if (order == null)
            {
                return View("Error");
            }
            return View(order);
        }
    }
}
