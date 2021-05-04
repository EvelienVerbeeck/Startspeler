using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StartSpelerMVC.Models;

namespace StartSpelerMVC.Areas.Identity.Data
{
    public class CustomUser:IdentityUser
    {
        [PersonalData]
        public Persoon Persoon { get; set; }

    }
}
