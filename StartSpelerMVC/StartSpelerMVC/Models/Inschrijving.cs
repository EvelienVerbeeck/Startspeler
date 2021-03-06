using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StartSpelerMVC.Models
{
    public class Inschrijving
    {   [Key]
        public int InschrijvingID { get; set; }
        public int PersoonID { get; set; }
        public int EvenementID { get; set; }

        public Evenement Evenement { get; set; }
        
        public Persoon Personen { get; set; }
      
        [DataType(DataType.Date)]
        [Required]
        public DateTime Datum { get; set; }

    }
}
