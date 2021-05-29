using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class DetailsPersoonViewModel
    {
        public Persoon Persoon { get; set; }
        public ICollection<Drankkaart> Drankkaarten { get; set; }
    }
}
