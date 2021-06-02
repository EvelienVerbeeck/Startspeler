using StartSpelerMVC.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        [Required]
        public string Email { get; set; }
        [MaxLength(4)]
        [DataType(DataType.Password)]//Maakt wachtwoordveld niet leesbaar
        [Required]
        public string Wachtwoord { get; set; }
        [Display (Name ="Actief lid")]
        public bool IsActief { get; set; }
        [Display(Name = "Rol")]
        public bool IsAdmin { get; set; }
        public DateTime AangemaaktDatum { get; set; }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
        public ICollection<Bestelling> Bestellingen { get; set; }
        public ICollection<Drankkaart> Drankkaarten { get; set; }

        [ForeignKey("CustomUser")]
        public string UserID { get; set; }
        public CustomUser CustomUser { get; set; }
        public override string ToString()
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.Append($"KlantID: {Persoon_ID}; ");
            stringbuilder.Append($"Voornaam: {Voornaam}; ");
            stringbuilder.Append($"Naam: {Achternaam}; ");
            stringbuilder.Append($"Datum aangemaakt: {AangemaaktDatum}; ");

            return stringbuilder.ToString();
        }

        [NotMapped]
        public string RolDuiding { get; set; }

        [NotMapped]
        public string ActiefDuiding { get; set; }
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:n} €")]
        public decimal TotaleUitgaveDrankkaart { get; set; }
    }
}
