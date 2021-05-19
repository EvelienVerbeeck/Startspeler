using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartSpelerMVC.Models
{
    public class Orderlijn //tussentabel
    {
        [Key]
        public int Orderlijn_ID { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [ForeignKey("Bestelling")]
        public int BestellingID { get; set; }

        //nav prop
        public Product Producten { get; set; }
        public Bestelling Bestelling { get; set; }
    }
}
