using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StartSpelerMVC.Data;
using StartSpelerMVC.Models;
using StartSpelerMVC.ViewModels;

namespace StartSpelerMVC.Controllers
{
    public class PersoonController : Controller
    {
        private readonly StartSpelerContext _context;

        public PersoonController(StartSpelerContext context)
        {
            _context = context;
        }

        // GET: Persoon
        public async Task<IActionResult> Index()
        {
            ListPersoonViewModel viewModel = new ListPersoonViewModel();
            viewModel.Persoon = await _context.Personen.Include(p => p.CustomUser).ToListAsync();
            foreach (var persoon in viewModel.Persoon)
            {
                if (persoon.IsAdmin==true)
                {
                    persoon.RolDuiding = "Administrator";
                }
                else
                {
                    persoon.RolDuiding = "Speler";
                }
            }
            return View( viewModel);
        }
        public async Task<IActionResult> Search(ListPersoonViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.ZoekPersoon))
            {
                viewModel.Persoon = await _context.Personen.Include(p => p.CustomUser)
                     .Where(x => x.Voornaam.Contains(viewModel.ZoekPersoon)).ToListAsync();
            }
            else
            {
                viewModel.Persoon = await _context.Personen.Include(p => p.CustomUser).ToListAsync();
            }
            foreach (var persoon in viewModel.Persoon)
            {
                if (persoon.IsAdmin == true)
                {
                    persoon.RolDuiding = "Administrator";
                }
                else
                {
                    persoon.RolDuiding = "Speler";
                }
            }
            return View("Index", viewModel);
        }

        // GET: Persoon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DetailsPersoonViewModel viewModel = new DetailsPersoonViewModel();
            viewModel.Persoon= await _context.Personen
                .Include(p => p.CustomUser)
                .FirstOrDefaultAsync(m => m.Persoon_ID == id);
            viewModel.Persoon.Drankkaarten = await _context.Drankkaarten.Where(x => x.PersoonID == id).ToListAsync();
            viewModel.Persoon.TotaleUitgaveDrankkaart = viewModel.Persoon.Drankkaarten.Sum(x => x.Prijs);
            if (viewModel.Persoon == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Persoon/Create
        public IActionResult Create()
        {
            CreatePersoonViewModel viewModel = new CreatePersoonViewModel();
            viewModel.Persoon = new Persoon() 
            {  
                AangemaaktDatum=DateTime.Now,
                IsActief=true,
                IsAdmin=false
            };
            
            return View(viewModel);
        }

        // POST: Persoon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePersoonViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.Persoon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.Persoon = new Persoon()
                {
                AangemaaktDatum = DateTime.Now,
                IsActief = true,
                IsAdmin = false,
                };
            return View(viewModel);
        }

        // GET: Persoon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EditPersoonViewModel viewModel = new EditPersoonViewModel();
            viewModel.Persoon = await _context.Personen.FindAsync(id);
            if (viewModel.Persoon == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Persoon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditPersoonViewModel viewModel)
        {
            if (id != viewModel.Persoon.Persoon_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Persoon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersoonExists(viewModel.Persoon.Persoon_ID))
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

            return View(viewModel);
        }

        // GET: Persoon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DeletePersoonViewModel viewmodel = new DeletePersoonViewModel();
            viewmodel.Persoon = await _context.Personen
                .Include(p => p.CustomUser)
                .FirstOrDefaultAsync(m => m.Persoon_ID == id);
            if (viewmodel.Persoon == null)
            {
                return NotFound();
            }

            return View(viewmodel);
        }

        // POST: Persoon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            DeletePersoonViewModel viewModel = new DeletePersoonViewModel();
            viewModel.Persoon = await _context.Personen.FindAsync(id);
            _context.Personen.Remove(viewModel.Persoon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersoonExists(int id)
        {
            return _context.Personen.Any(e => e.Persoon_ID == id);
        }


    }
}
