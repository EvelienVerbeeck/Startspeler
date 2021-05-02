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
      
        public int PersoonID { get; set; }
        [Required]
        public List<Orderlijn> Orderlijnen { get; set; } //Naar product
        [Required]
        public Decimal Prijs { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        //nav prop
        public Persoon Persoon { get; set; }

    }
}
