using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartSpelerMVC.Models
{
    public class Drankkaart
    {
        [Key]
        public int DrankkaartID { get; set; }
        public int PersoonID { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:n} €")]
        public decimal Prijs { get; set; }
        [Required]
        public byte AantalSlots { get; set; } //waarde 0-255
        [DataType(DataType.Date)]
        [Required]
        public DateTime Begindatum { get; set; }
       
        public bool IsBetaald { get; set; }
        public bool IsActief { get; set; }


    }
}
