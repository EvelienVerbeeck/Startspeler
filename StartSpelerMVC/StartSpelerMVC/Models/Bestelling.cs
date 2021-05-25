using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartSpelerMVC.Models
{
    public class Bestelling
    {
        [Key]
        public int BestellingID { get; set; }
        [ForeignKey("Persoon")]
        public int PersoonID { get; set; }
        [Required]
        public List<Orderlijn> Orderlijnen { get; set; } //Naar product
        [Required]
        [Column(TypeName = "money")]
        public decimal Prijs { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        //nav prop
        public Persoon Persoon { get; set; }

    }
}
