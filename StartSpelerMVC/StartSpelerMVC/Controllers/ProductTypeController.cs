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
    public class ProductTypeController : Controller
    {
        private readonly StartSpelerContext _context;

        public ProductTypeController(StartSpelerContext context)
        {
            _context = context;
        }

        // GET: ProductType
        public async Task<IActionResult> Index()
        {
            ListProducttypeViewModel viewModel = new ListProducttypeViewModel();
            viewModel.ProductType = await _context.productTypes.ToListAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> Search(ListProducttypeViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.Zoekproducttypes))
            {
                viewModel.ProductType = await _context.productTypes
                .Where(x => x.Naam.Contains(viewModel.Zoekproducttypes)).ToListAsync();
            }
            else
            {
                viewModel.ProductType = await _context.productTypes.ToListAsync();
            }
            return View("Index", viewModel);
        }

        // GET: ProductType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DetailsProducttypeViewModel viewModel = new DetailsProducttypeViewModel();
            viewModel.ProductType = await _context.productTypes
                .FirstOrDefaultAsync(m => m.ProductTypeID == id);
            if (viewModel.ProductType == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: ProductType/Create
        public IActionResult Create()
        {
            CreateProducttypeViewModel viewModel = new CreateProducttypeViewModel();
            viewModel.ProductType = new ProductType();
            return View(viewModel);
        }

        // POST: ProductType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProducttypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.ProductType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: ProductType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EditProducttypeViewModel viewModel = new EditProducttypeViewModel();
            viewModel.ProductType = await _context.productTypes.FindAsync(id);
            if (viewModel.ProductType == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: ProductType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProducttypeViewModel viewModel)
        {
            if (id != viewModel.ProductType.ProductTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.ProductType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTypeExists(viewModel.ProductType.ProductTypeID))
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

        // GET: ProductType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DeleteProducttypeViewModel viewModel = new DeleteProducttypeViewModel();
            viewModel.ProductType = await _context.productTypes
                .FirstOrDefaultAsync(m => m.ProductTypeID == id);
            if (viewModel.ProductType == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: ProductType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            DeleteProducttypeViewModel viewModel = new DeleteProducttypeViewModel();
            viewModel.ProductType = await _context.productTypes.FindAsync(id);
            _context.productTypes.Remove(viewModel.ProductType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTypeExists(int id)
        {
            return _context.productTypes.Any(e => e.ProductTypeID == id);
        }
    }
}
