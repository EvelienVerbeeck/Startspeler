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
    public class DrankkaartController : Controller
    {
        private readonly StartSpelerContext _context;

        public DrankkaartController(StartSpelerContext context)
        {
            _context = context;
        }

        // GET: Drankkaart
        public async Task<IActionResult> Index()
        {
            ListDrankkaartViewModel viewModel = new ListDrankkaartViewModel();
            viewModel.Drankkaartenlijst = await _context.Drankkaarten.ToListAsync();
            return View(viewModel); // wanneer je viewmodel.Drankkaart schrijft krijg je volgende error   The model item passed into the dictionary is of type ‘[]’ , but this dictionary requires a model item of type ‘[]’
        }

        // GET: Drankkaart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DetailsDrankkaartViewModel viewModel = new DetailsDrankkaartViewModel();
            viewModel.Drankkaart = await _context.Drankkaarten
                .FirstOrDefaultAsync(m => m.DrankkaartID == id);
            if (viewModel.Drankkaart == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Drankkaart/Create
        public IActionResult Create()
        {
            CreateDrankkaartViewModel viewModel = new CreateDrankkaartViewModel();
            viewModel.Drankkaart = new Drankkaart();
           
            return View(viewModel);
        }

        // POST: Drankkaart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDrankkaartViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.Drankkaart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(viewModel);
        }

        // GET: Drankkaart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EditDrankkaartViewModel viewModel = new EditDrankkaartViewModel();
            viewModel.Drankkaart = await _context.Drankkaarten.FindAsync(id);
            if (viewModel.Drankkaart == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Drankkaart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditDrankkaartViewModel viewModel)
        {
            if (id != viewModel.Drankkaart.DrankkaartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Drankkaart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrankkaartExists(viewModel.Drankkaart.DrankkaartID))
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

        // GET: Drankkaart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DeleteDrankkaartViewModel viewmodel = new DeleteDrankkaartViewModel();
            viewmodel.Drankkaart = await _context.Drankkaarten
                .FirstOrDefaultAsync(m => m.DrankkaartID == id);
            if (viewmodel.Drankkaart == null)
            {
                return NotFound();
            }

            return View(viewmodel);
        }

        // POST: Drankkaart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            DeleteDrankkaartViewModel viewmodel = new DeleteDrankkaartViewModel();
            viewmodel.Drankkaart = await _context.Drankkaarten.FindAsync(id);
            _context.Drankkaarten.Remove(viewmodel.Drankkaart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrankkaartExists(int id)
        {
            return _context.Drankkaarten.Any(e => e.DrankkaartID == id);
        }
    }
}
