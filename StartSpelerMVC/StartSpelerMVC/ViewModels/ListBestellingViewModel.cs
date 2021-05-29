using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class ListBestellingViewModel
    {
        public List<Bestelling> Bestellingen { get; set; }
        public string ZoekArtikel { get; set; }
        public Bestelling Bestelling { get; set; }
  
    }
}
