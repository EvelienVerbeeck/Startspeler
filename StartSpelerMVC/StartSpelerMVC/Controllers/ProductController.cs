﻿using System;
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
    public class ProductController : Controller
    {
        private readonly StartSpelerContext _context;

        public ProductController(StartSpelerContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            ListProductViewModel viewModel = new ListProductViewModel();
            viewModel.Product = await _context.Producten.Include(p => p.ProductType).ToListAsync();
           
            return View( viewModel);
        }
        public async Task<IActionResult> Search(ListProductViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.ZoekProduct))
            {
                viewModel.Product = await _context.Producten.Include(p => p.ProductType)
                .Where(x => x.Naam.Contains(viewModel.ZoekProduct)).ToListAsync();
            }
            else
            {
                viewModel.Product = await _context.Producten.Include(p => p.ProductType).ToListAsync();
            }
            return View("Index", viewModel);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DetailsProductViewModel viewModel = new DetailsProductViewModel();
            viewModel.Product = await _context.Producten
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (viewModel.Product == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            CreateProductViewModel viewModel = new CreateProductViewModel();
            viewModel.ProductTypes = new SelectList(_context.productTypes, "ProductType_ID", "Naam");
            return View(viewModel);
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ProductTypes = new SelectList(_context.productTypes, "ProductType_ID", "Naam", viewModel.Product.ProductTypeID);
            viewModel.Product.IsZichtbaar = true;
            viewModel.Product.StartDatum = DateTime.Now;
            viewModel.Product.EindDatum = default;
            return View(viewModel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EditProductViewModel viewModel = new EditProductViewModel();
            viewModel.Product = await _context.Producten.Include(x => x.ProductType).FirstOrDefaultAsync(x => x.ProductID == id); 
            viewModel.Product.IsZichtbaar = true;
            viewModel.Product.StartDatum = viewModel.Product.StartDatum;
            if (viewModel.Product == null)
            {
                return NotFound();
            }
            viewModel.ProductTypes = new SelectList(_context.productTypes, "ProductType_ID", "Naam", viewModel.Product.ProductTypeID);
            return View(viewModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductViewModel viewModel)
        {
            if (id != viewModel.Product.ProductID)
            {
                return NotFound();
            }
            viewModel.Product = await _context.Producten.Include(x => x.ProductType).FirstOrDefaultAsync(x => x.ProductID == id);
            viewModel.ProductTypes = new SelectList(_context.productTypes, "ProductType_ID", "Naam", viewModel.Product.ProductTypeID);
            viewModel.Product.StartDatum = viewModel.Product.StartDatum;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(viewModel.Product.ProductID))
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
            viewModel.ProductTypes= new SelectList(_context.productTypes, "ProductType_ID", "Naam", viewModel.Product.ProductTypeID);
            return View(viewModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeleteProductViewModel viewModel = new DeleteProductViewModel();
           viewModel.Product = await _context.Producten
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (viewModel.Product == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            DeleteProductViewModel viewModel = new DeleteProductViewModel();
            viewModel.Product = await _context.Producten.FindAsync(id);
            _context.Producten.Remove(viewModel.Product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Producten.Any(e => e.ProductID == id);
        }
    }
}
