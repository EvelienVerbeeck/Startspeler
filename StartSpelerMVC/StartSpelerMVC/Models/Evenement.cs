using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StartSpelerMVC.Models
{
    public class Evenement
    {
        [Key]
        public int Evenement_ID { get; set; }

        public byte  MaxDeelnemers { get; set; } //waarde 0-255
        [MaxLength(255)]
        public string Beschrijving { get; set; }
        [DataType(DataType.Time)]
        [Required]
        public DateTime Startuur { get; set; }
        [DataType(DataType.Time)]
        [Required]
        public DateTime Einduur { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public Decimal Prijs { get; set; }
        public bool IsZichtbaar { get; set; }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}