using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        public RoleController(AspNetRoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [Authorize(Policy="AdminPolicy")]
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        [Authorize(Policy ="AdminPolicy")]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        //Inschrijven [Allow Anonymous]
        //Evenement [Authorize(Policy="SpelerPolicy")]
        //drankenlijst [Authorize(Policy="SpelerPolicy")]
        //drankenlijst [Authorize(Policy="SpelerPolicy")]
    }
}
