using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StartSpelerMVC.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeID { get; set; }
        [MaxLength(20)]
        [Required]
        public string Naam { get; set; }
    }
}