using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StartSpelerMVC.Data;
using StartSpelerMVC.Models;
using StartSpelerMVC.ViewModels;

namespace StartSpelerMVC.Controllers
{
    public class BestellingController : Controller
    {
        private readonly StartSpelerContext _context;

        public BestellingController(StartSpelerContext context)
        {
            _context = context;
        }
        
        // GET: Bestelling
        public async Task<IActionResult> Index()
        {
            ListBestellingViewModel viewModel = new ListBestellingViewModel();
            viewModel.Bestellingen = await _context.Bestellingen.Include(b => b.Persoon).ToListAsync();
            return View(viewModel);
        }

        // GET: Bestelling/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DetailsBestellingViewModel viewModel = new DetailsBestellingViewModel();
            viewModel.Bestelling = await _context.Bestellingen
                .Include(b => b.Persoon)
                .FirstOrDefaultAsync(m => m.BestellingID == id);
            if (viewModel.Bestelling == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Bestelling/Create
        public IActionResult Create()
        {
            CreateBestellingViewModel viewModel = new CreateBestellingViewModel();
            //viewModel.Persoon = _context.Personen.Find(id); //Hoe kan ik hier de ingelogde id vinden
            viewModel.Bestelling = new Bestelling();
            viewModel.Bestelling.Datum = DateTime.Now.Date;
            viewModel.Productenlijst = _context.Producten.Include(x => x.ProductType).ToList();


            //ViewData["PersoonID"] = new SelectList(_context.Personen, "Persoon_ID", "Achternaam");
            return View(viewModel);
        }

        // POST: Bestelling/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBestellingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.Bestelling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //viewModel.Persoon = _context.Personen.Find(id);// hoe kan ik hier de ingelogde id vinden
            viewModel.Bestelling = new Bestelling();
            viewModel.Bestelling.Datum = DateTime.Now.Date;
            viewModel.Productenlijst = _context.Producten.Include(x => x.ProductType).ToList();
            return View(viewModel);
        }

        // GET: Bestelling/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EditBestellingViewModel viewModel = new EditBestellingViewModel();
            viewModel.Bestelling = await _context.Bestellingen.FindAsync(id);
            if (viewModel.Bestelling == null)
            {
                return NotFound();
            }
            viewModel.Bestelling.PersoonID = viewModel.Persoon.Persoon_ID;
            return View(viewModel);
        }

        // POST: Bestelling/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditBestellingViewModel viewModel)
        {
            if (id != viewModel.Bestelling.BestellingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Bestelling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BestellingExists(viewModel.Bestelling.BestellingID))
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
            viewModel.Bestelling.PersoonID = viewModel.Bestelling.PersoonID;
            return View(viewModel);
        }

        // GET: Bestelling/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DeleteBestellingViewModel viewmodel = new DeleteBestellingViewModel();
            viewmodel.Bestelling = await _context.Bestellingen
                .Include(b => b.Persoon)
                .FirstOrDefaultAsync(m => m.BestellingID == id);
            if (viewmodel.Bestelling == null)
            {
                return NotFound();
            }

            return View(viewmodel);
        }

        // POST: Bestelling/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            DeleteBestellingViewModel viewModel = new DeleteBestellingViewModel();
            viewModel.Bestelling = await _context.Bestellingen.FindAsync(id);
            _context.Bestellingen.Remove(viewModel.Bestelling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BestellingExists(int id)
        {
            return _context.Bestellingen.Any(e => e.BestellingID == id);
        }
    }
}
