using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StartSpelerMVC.Models
{
    public class Orderlijn //tussentabel
    {
        [Key]
        public int Orderlijn_ID { get; set; }
        public int ProductID { get; set; }
        public int BestellingID { get; set; }

        //nav prop
        public Product Producten { get; set; }
        public Bestelling Bestelling { get; set; }
    }
}
