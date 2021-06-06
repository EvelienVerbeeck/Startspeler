using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
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
            viewModel.Frisdrankenlijst= viewModel.Product.Where(x => x.ProductType.Naam == "Frisdrank").ToList();
            viewModel.Alcohollijst= viewModel.Product.Where(x => x.ProductType.Naam == "Alcohol").ToList();
            viewModel.Snacklijst= viewModel.Product.Where(x=>x.ProductType.Naam=="Snack").ToList();

            foreach (var item in viewModel.Frisdrankenlijst)
            {
                item.Aantal = 0;
            }
            foreach (var item in viewModel.Alcohollijst)
            {
                item.Aantal = 0;
            }
            foreach (var item in viewModel.Snacklijst)
            {
                item.Aantal = 0;
            }
            viewModel.Bestelling = new Bestelling() { Productenlijst=new List<Product> { } };
            return View( viewModel);
        }

        public async Task <IActionResult> IndexManager()
        {
            ListProductViewModel viewModel = new ListProductViewModel();
            viewModel.DrankInMagazijn = await _context.Producten.Include(p => p.ProductType).ToListAsync();
            viewModel.DrankInIjskast = new List<Product>();
            foreach (Product item in viewModel.DrankInMagazijn)
            {
                if (!viewModel.DrankInIjskast.Contains(item)&& item.Aantal_in_Frigo>=0)
                {
                    viewModel.DrankInIjskast.Add(item);
                }
            }

            return View(viewModel);
        }

        public async Task <IActionResult> VerminderenMetEen(ListProductViewModel viewModel,int Product_ID)
        { 
            viewModel.ProductEventChange = _context.Producten.Include(x => x.ProductType).FirstOrDefault(x => x.ProductID == Product_ID);
            viewModel.ProductEventChange.Aantal_in_Frigo-=1;
            if (viewModel.ProductEventChange.Aantal_in_Frigo>0)
            {
                try
                {
                    _context.Update(viewModel.ProductEventChange);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(viewModel.ProductEventChange.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            viewModel.DrankInMagazijn = await _context.Producten.Include(p => p.ProductType).ToListAsync();
            viewModel.DrankInIjskast = new List<Product>();
            foreach (Product item in viewModel.DrankInMagazijn)
            {
                if (!viewModel.DrankInIjskast.Contains(item) && item.Aantal_in_Frigo >= 0)
                {
                    viewModel.DrankInIjskast.Add(item);
                }
            }
            return View(nameof(IndexManager),viewModel);
        }

        public async Task<IActionResult> VermeerderenMetEen(ListProductViewModel viewModel, int Product_ID)
        {
            viewModel.ProductEventChange = _context.Producten.Include(x => x.ProductType).FirstOrDefault(x => x.ProductID == Product_ID);
            viewModel.ProductEventChange.Aantal_in_Frigo += 1;
            try
            {
                _context.Update(viewModel.ProductEventChange);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(viewModel.ProductEventChange.ProductID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            viewModel.DrankInMagazijn = await _context.Producten.Include(p => p.ProductType).ToListAsync();
            viewModel.DrankInIjskast = new List<Product>();
            foreach (Product item in viewModel.DrankInMagazijn)
            {
                if (!viewModel.DrankInIjskast.Contains(item) && item.Aantal_in_Frigo >= 0)
                {
                    viewModel.DrankInIjskast.Add(item);
                }
            }

            return View(nameof(IndexManager), viewModel);
        }
        public async Task<IActionResult> MinEenFris(ListProductViewModel viewModel,int Product_ID)
        {
            
            viewModel.GekozenFrisdrank = _context.Producten.Include(x => x.ProductType).Where(x=>x.ProductType.Naam=="Frisdrank").FirstOrDefault(x => x.ProductID == Product_ID);
            viewModel.GekozenFrisdrank.Aantal -= 1;
            viewModel.Frisdrankenlijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Frisdrank").ToListAsync();
            viewModel.Alcohollijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Alcohol").ToListAsync();
            viewModel.Snacklijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Snack").ToListAsync();
            return View(nameof(Index),viewModel);

        }
        public async Task<IActionResult> PlusEenFris(ListProductViewModel viewModel, int Product_ID)
        {
            viewModel.GekozenFrisdrank = _context.Producten.Include(x => x.ProductType).Where(x => x.ProductType.Naam == "Frisdrank").FirstOrDefault(x => x.ProductID == Product_ID);
            viewModel.GekozenFrisdrank.Aantal += 1;
            viewModel.Frisdrankenlijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Frisdrank").ToListAsync();
            viewModel.Alcohollijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Alcohol").ToListAsync();
            viewModel.Snacklijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Snack").ToListAsync();
            return View(nameof(Index), viewModel);

        }
        public async Task<IActionResult> MinEenAlcohol(ListProductViewModel viewModel, int Product_ID)
        {
            viewModel.GekozenAlcohol = _context.Producten.Include(x => x.ProductType).Where(x => x.ProductType.Naam == "Alcohol").FirstOrDefault(x => x.ProductID == Product_ID);
            viewModel.GekozenAlcohol.Aantal -= 1;
            viewModel.Alcohollijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Alcohol").ToListAsync();
            viewModel.Frisdrankenlijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Frisdrank").ToListAsync();
            viewModel.Snacklijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Snack").ToListAsync();


            return View(nameof(Index), viewModel);

        }
        public async Task<IActionResult> PlusEenAlcohol(ListProductViewModel viewModel, int Product_ID)
        {
            viewModel.GekozenAlcohol = _context.Producten.Include(x => x.ProductType).Where(x => x.ProductType.Naam == "Alcohol").FirstOrDefault(x => x.ProductID == Product_ID);
            viewModel.GekozenAlcohol.Aantal += 1;
            viewModel.Alcohollijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Alcohol").ToListAsync();
            viewModel.Frisdrankenlijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Frisdrank").ToListAsync();
            viewModel.Snacklijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Snack").ToListAsync();
            return View(nameof(Index), viewModel);

        }

        public async Task<IActionResult> MinEenSnack(ListProductViewModel viewModel, int Product_ID)
        {
            viewModel.GekozenSnack = _context.Producten.Include(x => x.ProductType).Where(x => x.ProductType.Naam == "Snack").FirstOrDefault(x => x.ProductID == Product_ID);
            viewModel.GekozenSnack.Aantal -= 1;
            viewModel.Snacklijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Snack").ToListAsync();
            viewModel.Alcohollijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Alcohol").ToListAsync();
            viewModel.Frisdrankenlijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Frisdrank").ToListAsync();

            return View(nameof(Index), viewModel);

        }
        public async Task<IActionResult> PlusEenSnack(ListProductViewModel viewModel, int Product_ID)
        {
            viewModel.GekozenSnack = _context.Producten.Include(x => x.ProductType).Where(x => x.ProductType.Naam == "Snack").FirstOrDefault(x => x.ProductID == Product_ID);
            viewModel.GekozenSnack.Aantal += 1;
            viewModel.Snacklijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Snack").ToListAsync();
            viewModel.Alcohollijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Alcohol").ToListAsync();
            viewModel.Frisdrankenlijst = await _context.Producten.Include(p => p.ProductType).Where(x => x.ProductType.Naam == "Frisdrank").ToListAsync();

            return View(nameof(Index), viewModel);

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
            return View("IndexManager", viewModel);
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
            viewModel.ProductTypes = new SelectList( _context.productTypes,"ProductTypeID" , "Naam");
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
            viewModel.ProductTypes = new SelectList(_context.productTypes, "ProductTypeID", "Naam", viewModel.Product.ProductTypeID);
            viewModel.Product.IsZichtbaar = true;
            viewModel.Product.StartDatum = DateTime.Now;
            viewModel.Product.EindDatum = default;
            return RedirectToAction(nameof(IndexManager));
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
            viewModel.Product.StartDatum = viewModel.Product.StartDatum;
            viewModel.AantalToevoegenAanIjskast = 0;
            if (viewModel.Product == null)
            {
                return NotFound();
            }
            viewModel.ProductTypes = new SelectList(_context.productTypes, "ProductTypeID", "Naam", viewModel.Product.ProductTypeID);
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
            viewModel.ProductTypes = new SelectList(_context.productTypes, "ProductType_ID", "Naam", viewModel.Product.ProductTypeID);
            viewModel.Product.StartDatum = viewModel.Product.StartDatum;
            if (viewModel.AantalToevoegenAanIjskast>0)
            {
                viewModel.Product.Aantal_in_stock-= viewModel.AantalToevoegenAanIjskast;
                viewModel.Product.Aantal_in_Frigo+= viewModel.AantalToevoegenAanIjskast;
            }
            else
            {
                viewModel.AantalToevoegenAanIjskast = 0;
            }
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
                return RedirectToAction(nameof(IndexManager));
            }
            viewModel.ProductTypes= new SelectList(_context.productTypes, "ProductType_ID", "Naam", viewModel.Product.ProductTypeID);
            return View(nameof(IndexManager));
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
            viewModel.Product = await _context.Producten.Include(x => x.ProductType).FirstOrDefaultAsync(x => x.ProductID == id);
            _context.Producten.Remove(viewModel.Product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexManager));
        }

        private bool ProductExists(int id)
        {
            return _context.Producten.Any(e => e.ProductID == id);
        }

        public async Task DrankenOverzichtExcel()
        {
            ListProductViewModel viewModel = new ListProductViewModel();
            viewModel.Product = await _context.Producten.Include(x => x.ProductType).ToListAsync();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("ExcelProduct");
            Sheet.Cells["A1"].Value = "Naam";
            Sheet.Cells["B1"].Value = "ProductType";
            Sheet.Cells["C1"].Value = "Aankoopprijs";
            Sheet.Cells["D1"].Value = "Verkoopprijs";
            Sheet.Cells["E1"].Value = "Slotwaarde";
            Sheet.Cells["F1"].Value = "Aantal in stock";
            Sheet.Cells["G1"].Value = "Aantal in ijskast";

            int row = 2;
            foreach (var item in viewModel.Product)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = item.Naam;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.ProductType;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.AankoopPrijs;
                Sheet.Cells[string.Format("C{0}", row)].Style.Numberformat.Format="0.00";
                Sheet.Cells[string.Format("D{0}", row)].Value = item.VerkoopPrijs;
                Sheet.Cells[string.Format("D{0}", row)].Style.Numberformat.Format="0.00";
                Sheet.Cells[string.Format("E{0}", row)].Value = item.Slotwaarde;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.Aantal_in_stock;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.Aantal_in_Frigo;
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment: filename=" + "Report.xlsx");
            await Response.Body.WriteAsync(Ep.GetAsByteArray());
            Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
