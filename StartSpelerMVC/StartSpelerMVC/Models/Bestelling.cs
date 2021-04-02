using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StartSpelerMVC.Models
{
    public class Bestelling
    {
        [Key]
        public int Bestelling_ID { get; set; }
        
        public Persoon Persoon { get; set; }
        [Required]
        public ICollection<Orderlijn> Orderlijnen { get; set; }
        [Required]
        public Decimal Prijs { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        
    }
}
