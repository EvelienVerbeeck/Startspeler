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

        public List<Product> Frisdrankenlijst { get; set; }
        public List<Product> Snacklijst { get; set; }
        public List<Product> Alcohollijst { get; set; }
        public Product GekozenFrisdrank { get; set; }
        public Product GekozenAlcohol { get; set; }
        public Product GekozenSnack { get; set; }

        public Bestelling Bestelling { get; set; }
    


    }
}
