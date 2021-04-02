using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StartSpelerMVC.Models
{
    public class Orderlijn
    {
        [Key]
        public int Orderlijn_ID { get; set; }
        public ICollection<Product> Producten { get; set; }
        public Bestelling Bestelling { get; set; }
    }
}
