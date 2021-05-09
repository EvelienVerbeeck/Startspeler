using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.ViewModels
{
    public class ListDrankkaartViewModel
    {
        public List<Drankkaart> Drankkaartenlijst { get; set; }
        public List<Drankkaart> ZoekDrankkaart { get; set; }
    }
}
