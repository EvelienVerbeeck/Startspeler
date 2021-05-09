using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class EditBestellingViewModel
    {
        public Bestelling Bestelling { get; set; }
        public List<Product> Productenlijst { get; set; }
        public Persoon Persoon { get; set; }
    }
}
