using Microsoft.AspNetCore.Mvc.Rendering;
using StartSpelerMVC.Areas.Identity.Data;
using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class EditPersoonViewModel
    {
        public List<SelectListItem> Rol { get; set; }
        public Persoon Persoon { get; set; }
    }
}
