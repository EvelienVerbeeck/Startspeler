using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StartSpelerMVC.Models
{
    public class Inschrijving
    {   [Key]
        public int Inschrijving_ID { get; set; }
        
        public Evenement Evenement { get; set; }
        public ICollection<Persoon> Personen { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Datum { get; set; }
    }
}
