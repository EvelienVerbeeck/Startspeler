using Microsoft.AspNetCore.Mvc.Rendering;
using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        public int AantalToevoegenAanIjskast { get; set; }
        public IEnumerable<SelectListItem> ProductTypes { get; set; }
    }
}
