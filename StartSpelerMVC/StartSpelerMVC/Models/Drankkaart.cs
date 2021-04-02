using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StartSpelerMVC.Models
{
    public class Drankkaart
    {
        [Key]
        public int Drankkaart_ID { get; set; }
        
        public Persoon Persoon { get; set; }
        [Required]
        public Decimal Prijs { get; set; }
        [Required]
        public byte AantalSlots { get; set; } //waarde 0-255
        [DataType(DataType.Date)]
        [Required]
        public DateTime Begindatum { get; set; }
       
        public bool IsBetaald { get; set; } 

    }
}
