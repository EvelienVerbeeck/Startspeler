using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class ListProductViewModel
    {
        public List<Product> Product { get; set; }
        public string ZoekProduct { get; set; }
#nullable enable
        public List<Product>? DrankInIjskast { get; set; }
#nullable disable
        public List<Product> DrankInMagazijn { get; set; }
        public Product ProductEventChange { get; set; }
        

    }
}
