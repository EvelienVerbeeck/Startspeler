using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.Areas.Identity.Data
{
    public class CustomerUser:IdentityUser
    {
        [PersonalData]
        [Required]
        public string Voornaam { get; set; }
        [PersonalData]
        [Required]
        public string Achternaam { get; set; }
        [PersonalData]
        [Required]
        public string Gebruikersnaam { get; set; }
        [PersonalData]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Geboortedatum { get; set; }

    }
}
