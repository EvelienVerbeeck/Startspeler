using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class ListProducttypeViewModel
    {
        public List<ProductType> Producttypes { get; set; }
        public string Zoekproducttypes { get; set; }
    }
}
