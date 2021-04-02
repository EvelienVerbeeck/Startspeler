using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.Controllers
{
    public class InlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
