using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class CreateBestellingViewModel
    {
        public Bestelling Bestelling { get; set; }
        public List<Product> Productenlijst { get; set; }
        public Persoon Persoon { get; set; }
        public List<Bestelling> Bestellingen { get; set; }
        public string ZoekArtikel { get; set; }
    
    }
}
