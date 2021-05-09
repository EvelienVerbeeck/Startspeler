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
    public class ProductController : Controller
    {
        private readonly LocalStartSpelerConnection _context;

        public ProductController(LocalStartSpelerConnection context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var localStartSpelerConnection = _context.Producten.Include(p => p.ProductType);
            return View(await localStartSpelerConnection.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.Product_ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["ProductTypeID"] = new SelectList(_context.productTypes, "ProductType_ID", "Naam");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Product_ID,Naam,ProductTypeID,Aantal,StartDatum,EindDatum,AankoopPrijs,VerkoopPrijs,Slotwaarde,Alcoholpercentage,Aantal_in_stock,Aantal_in_Frigo,IsZichtbaar")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeID"] = new SelectList(_context.productTypes, "ProductType_ID", "Naam", product.ProductTypeID);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeID"] = new SelectList(_context.productTypes, "ProductType_ID", "Naam", product.ProductTypeID);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product_ID,Naam,ProductTypeID,Aantal,StartDatum,EindDatum,AankoopPrijs,VerkoopPrijs,Slotwaarde,Alcoholpercentage,Aantal_in_stock,Aantal_in_Frigo,IsZichtbaar")] Product product)
        {
            if (id != product.Product_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Product_ID))
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
            ViewData["ProductTypeID"] = new SelectList(_context.productTypes, "ProductType_ID", "Naam", product.ProductTypeID);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.Product_ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Producten.FindAsync(id);
            _context.Producten.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Producten.Any(e => e.Product_ID == id);
        }
    }
}
