using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using StartSpelerMVC.Areas.Identity.Data;
using StartSpelerMVC.Data;
using StartSpelerMVC.Models;
using StartSpelerMVC.ViewModels;

namespace StartSpelerMVC.Controllers
{
    public class PersoonController : Controller
    {
        private readonly StartSpelerContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CustomUser> _userManager;

        public PersoonController(StartSpelerContext context,RoleManager<IdentityRole> roleManager,UserManager<CustomUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Persoon
        public async Task<IActionResult> Index()
        {
            ListPersoonViewModel viewModel = new ListPersoonViewModel();
            viewModel.Persoon = await _context.Personen.Include(p => p.CustomUser).Include(x=>x.Drankkaarten).ToListAsync();


            
            foreach (var persoon in viewModel.Persoon)
            {
                persoon.ActieveDrankkaart = await _context.Drankkaarten.FirstOrDefaultAsync(x=>x.PersoonID == persoon.Persoon_ID && x.IsBetaald==false);
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
                persoon.ActieveDrankkaart = await _context.Drankkaarten.FirstOrDefaultAsync(x => x.PersoonID == persoon.Persoon_ID && x.IsBetaald == false);
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
                IsAdmin = false
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
            viewModel.Persoon = await _context.Personen.Include(x=>x.CustomUser).FirstOrDefaultAsync(x=>x.Persoon_ID==id);
            viewModel.Persoon.UserID = viewModel.Persoon.CustomUser.Id;
            viewModel.Persoon.Geboortedatum = viewModel.Persoon.Geboortedatum;
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
                   viewModel.Persoon= await _context.Personen.Include(x => x.CustomUser).FirstOrDefaultAsync(x => x.Persoon_ID == id);
                    viewModel.Persoon.UserID = viewModel.Persoon.CustomUser.Id;
                    viewModel.Persoon.RolDuiding = viewModel.Persoon.RolDuiding;
                    viewModel.Persoon.Geboortedatum = viewModel.Persoon.Geboortedatum;
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
            viewModel.Persoon = await _context.Personen.Include(x=>x.CustomUser).FirstOrDefaultAsync(x=>x.Persoon_ID==id);
            _context.Personen.Remove(viewModel.Persoon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersoonExists(int id)
        {
            return _context.Personen.Any(e => e.Persoon_ID == id);
        }

        public async Task KlantenOverzichtDownload()
        {
            ListPersoonViewModel viewModel = new ListPersoonViewModel();
            viewModel.Persoon = await _context.Personen.Include(x => x.CustomUser).ToListAsync();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage Ep = new ExcelPackage();

            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("ExcelKlanten");
            Sheet.Cells["A1"].Value = "Voornaam";
            Sheet.Cells["B1"].Value = "Achternaam";
            Sheet.Cells["C1"].Value = "Username";
            Sheet.Cells["D1"].Value = "IsAdmin";
            Sheet.Cells["E1"].Value = "EmailAdres";
            Sheet.Cells["F1"].Value = "GeboorteDatum";
            Sheet.Cells["G1"].Value = "Aangemaakte Datum";
            Sheet.Cells["G1"].Value = "Totale uitgave Drankkaarten";

            int row = 2;
            foreach (var item in viewModel.Persoon)
            {
                Sheet.Cells[string.Format("A{0}",row)].Value = item.Voornaam;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.Achternaam;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.Username;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.IsAdmin;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.Email;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.Geboortedatum;
                Sheet.Cells[string.Format("F{0}", row)].Style.Numberformat.Format = "yyyy-mm-dd";
                Sheet.Cells[string.Format("G{0}", row)].Value = item.AangemaaktDatum;
                Sheet.Cells[string.Format("G{0}", row)].Style.Numberformat.Format = "yyyy-mm-dd";
                Sheet.Cells[string.Format("H{0}", row)].Value = item.Drankkaarten.Sum(x=>x.Prijs);
                Sheet.Cells[string.Format("H{0}", row)].Style.Numberformat.Format="0.00";
                row++;
            }
            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment: filename=" + "Report.xlsx");
            await Response.Body.WriteAsync(Ep.GetAsByteArray());
            Response.StatusCode = StatusCodes.Status200OK;
        }
        public ActionResult DrankkaartIsBetaald(ListPersoonViewModel viewModel, int PersoonID)
        {
            viewModel.ActDrankkaart = _context.Drankkaarten.FirstOrDefault(x => x.PersoonID == PersoonID && x.IsBetaald == false);
            viewModel.ActDrankkaart.IsBetaald = true;

            _context.Update(viewModel.ActDrankkaart);
            _context.SaveChangesAsync();

            return View("Index", viewModel);
        }
        public ActionResult SpelerIsAdmin(EditPersoonViewModel viewModel, int PersoonID)
        {
            viewModel.Persoon = _context.Personen.Include(x => x.CustomUser).FirstOrDefault(x => x.Persoon_ID == PersoonID);
            viewModel.Persoon.IsAdmin = !viewModel.Persoon.IsAdmin;
            if (viewModel.Persoon.IsAdmin == true)
            {
                viewModel.Persoon.RolDuiding = "Administrator";

                DbSet<IdentityUserRole<string>> roles = _context.UserRoles;
                IdentityRole userrole = _context.Roles.FirstOrDefault(r => r.Name == "Speler");
                if (userrole != null)
                {
                    if (!roles.Any(ur => ur.UserId == viewModel.Persoon.CustomUser.Id && ur.RoleId == userrole.Id))
                    {
                        roles.Add(new IdentityUserRole<string>() { UserId = viewModel.Persoon.CustomUser.Id, RoleId = userrole.Id });
                        _context.SaveChanges();
                    }
                }
            }
            if (viewModel.Persoon.IsAdmin == false)
            {
                viewModel.Persoon.RolDuiding = "Speler";
                DbSet<IdentityUserRole<string>> roles = _context.UserRoles;
                IdentityRole userrole = _context.Roles.FirstOrDefault(r => r.Name == "Speler");
                if (userrole != null)
                {
                    if (!roles.Any(ur => ur.UserId == viewModel.Persoon.CustomUser.Id && ur.RoleId == userrole.Id))
                    {
                        roles.Add(new IdentityUserRole<string>() { UserId = viewModel.Persoon.CustomUser.Id, RoleId = userrole.Id });
                        _context.SaveChanges();
                    }
                }
            }
            return View("Edit", viewModel);
        }
        public ActionResult SpelerIsActief(EditPersoonViewModel viewModel,int PersoonID)
        {
            viewModel.Persoon = _context.Personen.Include(x => x.CustomUser).FirstOrDefault(x => x.Persoon_ID == PersoonID);
            viewModel.Persoon.IsActief = !viewModel.Persoon.IsActief;
            _context.Update(viewModel.Persoon);
            _context.SaveChangesAsync();

            return View("Edit", viewModel);
        }
    }
}
