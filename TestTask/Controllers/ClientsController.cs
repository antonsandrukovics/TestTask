using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ShopContext _context;

        public ClientsController(ShopContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var client = _context.Clients
                .Select(client => new ClientData
                {
                    ID = client.ClientID,
                    Name = client.Name,
                    Email = client.Email,
                    Birthdate = client.Birthdate,
                    Gender = client.Gender,
                    TheNumberOfOrder = client.Orders.Count,
                    AverageOrderAmount = (from m in client.Orders
                                          select m.Product.Price * m.Quantity).Sum() /
                                         (client.Orders.Count == 0 ? 1 : client.Orders.Count)
                }).AsNoTracking().ToListAsync();
            return View(await client);
        }
        

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Birthdate,Gender")] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(client);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clientToUpdate = await _context.Clients.FirstOrDefaultAsync(s => s.ClientID == id);
            if (await TryUpdateModelAsync<Client>(
                clientToUpdate,
                "",
                s => s.Name, s => s.Email, s => s.Birthdate, s => s.Gender))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(clientToUpdate);
        }


        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed.";
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _context.Clients
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.ClientID == id);

            while(true)
            {
                var orders = (from o in _context.Orders
                              where o.ClientId == id
                              select o).FirstOrDefault();
                if (orders == null)
                {
                    break;
                }

                try
                {
                    _context.Orders.Remove(orders);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
                }
            }
            


            if (client == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }

        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientID == id);
        }
    }
}
