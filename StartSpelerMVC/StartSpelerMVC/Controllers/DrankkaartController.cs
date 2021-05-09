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
        private readonly LocalStartSpelerConnection _context;

        public DrankkaartController(LocalStartSpelerConnection context)
        {
            _context = context;
        }

        // GET: Drankkaart
        public async Task<IActionResult> Index()
        {
            ListDrankkaartViewModel viewModel = new ListDrankkaartViewModel();
            viewModel.Drankkaartenlijst = await _context.Drankkaarten.ToListAsync();
            return View(viewModel);
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
                .FirstOrDefaultAsync(m => m.Drankkaart_ID == id);
            if (viewModel.Drankkaart == null)
            {
                return NotFound();
            }

            return View(viewModel.Drankkaart);
        }
        public async Task<IActionResult> Search(ListDrankkaartViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.ZoekDrankkaart))
            {
                viewModel.Drankkaartenlijst = await _context.Drankkaarten.
                     .Where(x => x.Naam.Contains(viewModel.ZoekDrankkaart)).ToListAsync();
            }
            else
            {
                viewModel.Drankkaartenlijst = await _context.Drankkaarten.ToListAsync();
            }
            return View("Index", viewModel);
        }

        // GET: Drankkaart/Create
        public IActionResult Create()
        {
            ListDrankkaartViewModel viewModel = new ListDrankkaartViewModel();
            return View();
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
            return View(viewModel.Drankkaart);
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
            return View(viewModel.Drankkaart);
        }

        // POST: Drankkaart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditDrankkaartViewModel viewModel)
        {
            if (id != viewModel.Drankkaart.Drankkaart_ID)
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
                    if (!DrankkaartExists(viewModel.Drankkaart.Drankkaart_ID))
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
            return View(viewModel.Drankkaart);
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
                .FirstOrDefaultAsync(m => m.Drankkaart_ID == id);
            if (viewmodel.Drankkaart == null)
            {
                return NotFound();
            }

            return View(viewmodel.Drankkaart);
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
            return _context.Drankkaarten.Any(e => e.Drankkaart_ID == id);
        }
    }
}
