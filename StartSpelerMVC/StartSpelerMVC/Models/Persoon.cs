using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.Models
{
    public class Persoon
    {
        [Key]
        public int Persoon_ID { get; set; }
        [MaxLength(50)]
        [Required]
        public string Voornaam { get; set; }
        [MaxLength(50)]
        [Required]
        public string Achternaam { get; set; }
        [MaxLength(20)]
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Geboortedatum { get; set; }
        [DataType(DataType.EmailAddress)]// maakt link clickable
        [Required]
        public string Email { get; set; }
        [MaxLength(4)]
        [DataType(DataType.Password)]//Maakt wachtwoordveld niet leesbaar
        [Required]
        public string Wachtwoord { get; set; }
        public bool IsActief { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
        public ICollection<Bestelling> Bestellingen { get; set; }
        public Drankkaart Drankkaart { get; set; }
    }
}
