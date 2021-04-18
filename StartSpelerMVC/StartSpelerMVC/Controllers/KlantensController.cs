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
    public class KlantensController : Controller
    {
        private readonly LocalStartSpelerConnection _context;

        public KlantensController(LocalStartSpelerConnection context)
        {
            _context = context;
        }

        // GET: Klantens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personen.ToListAsync());
        }

        // GET: Klantens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoon = await _context.Personen
                .FirstOrDefaultAsync(m => m.Persoon_ID == id);
            if (persoon == null)
            {
                return NotFound();
            }

            return View(persoon);
        }

        // GET: Klantens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klantens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Persoon_ID,Voornaam,Achternaam,Username,Geboortedatum,Email,Wachtwoord,IsActief,IsAdmin")] Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persoon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persoon);
        }

        // GET: Klantens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoon = await _context.Personen.FindAsync(id);
            if (persoon == null)
            {
                return NotFound();
            }
            return View(persoon);
        }

        // POST: Klantens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Persoon_ID,Voornaam,Achternaam,Username,Geboortedatum,Email,Wachtwoord,IsActief,IsAdmin")] Persoon persoon)
        {
            if (id != persoon.Persoon_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persoon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersoonExists(persoon.Persoon_ID))
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
            return View(persoon);
        }

        // GET: Klantens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoon = await _context.Personen
                .FirstOrDefaultAsync(m => m.Persoon_ID == id);
            if (persoon == null)
            {
                return NotFound();
            }

            return View(persoon);
        }

        // POST: Klantens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persoon = await _context.Personen.FindAsync(id);
            _context.Personen.Remove(persoon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersoonExists(int id)
        {
            return _context.Personen.Any(e => e.Persoon_ID == id);
        }
    }
}
