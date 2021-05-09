using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StartSpelerMVC.Data;
using StartSpelerMVC.Models;

namespace StartSpelerMVC.Controllers
{
    public class DrankkaartController : Controller
    {
        private readonly LocalStartSpelerConnection _context;

        public DrankkaartController(LocalStartSpelerConnection context)
        {
            _context = context;
        }

        // GET: Drankkaart
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drankkaarten.ToListAsync());
        }

        // GET: Drankkaart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankkaart = await _context.Drankkaarten
                .FirstOrDefaultAsync(m => m.Drankkaart_ID == id);
            if (drankkaart == null)
            {
                return NotFound();
            }

            return View(drankkaart);
        }

        // GET: Drankkaart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drankkaart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Drankkaart_ID,Prijs,AantalSlots,Begindatum,IsBetaald")] Drankkaart drankkaart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drankkaart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drankkaart);
        }

        // GET: Drankkaart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankkaart = await _context.Drankkaarten.FindAsync(id);
            if (drankkaart == null)
            {
                return NotFound();
            }
            return View(drankkaart);
        }

        // POST: Drankkaart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Drankkaart_ID,Prijs,AantalSlots,Begindatum,IsBetaald")] Drankkaart drankkaart)
        {
            if (id != drankkaart.Drankkaart_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drankkaart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrankkaartExists(drankkaart.Drankkaart_ID))
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
            return View(drankkaart);
        }

        // GET: Drankkaart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drankkaart = await _context.Drankkaarten
                .FirstOrDefaultAsync(m => m.Drankkaart_ID == id);
            if (drankkaart == null)
            {
                return NotFound();
            }

            return View(drankkaart);
        }

        // POST: Drankkaart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drankkaart = await _context.Drankkaarten.FindAsync(id);
            _context.Drankkaarten.Remove(drankkaart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrankkaartExists(int id)
        {
            return _context.Drankkaarten.Any(e => e.Drankkaart_ID == id);
        }
    }
}
