using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class ListPersoonViewModel
    {
        public List<Persoon> Persoon { get; set; }
        public string ZoekPersoon { get; set; }
        public Drankkaart ActDrankkaart { get; set; }

    }
}
