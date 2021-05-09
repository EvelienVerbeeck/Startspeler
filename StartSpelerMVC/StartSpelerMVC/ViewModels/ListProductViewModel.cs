using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class ListProductViewModel
    {
        public List<Product> Producten { get; set; }
        public string ZoekProduct { get; set; }

    }
}
