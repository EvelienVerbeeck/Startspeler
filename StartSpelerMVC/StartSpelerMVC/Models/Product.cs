using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StartSpelerMVC.Models
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }
        [MaxLength(50)]
        [Required]
        public int Naam { get; set; }
       
        public int ProductTypeID { get; set; }
        [Required]
        public int Aantal { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDatum { get; set; }
        public List<Orderlijn> Orderlijnen { get; set; } //many to many
        [DataType(DataType.Date)]
        public DateTime EindDatum { get; set; }
        [Required]
        public Decimal AankoopPrijs { get; set; }
        [Required]
        public Decimal VerkoopPrijs { get; set; }
        [Required]
        public byte Slotwaarde { get; set; } //waarde 0-255
        public float Alcoholpercentage { get; set; }
        [Required]
        public int Aantal_in_stock { get; set; }
        [Required]
        public int Aantal_in_Frigo { get; set; }
        public bool IsZichtbaar { get; set; }

        public ProductType ProductType { get; set; }

    }
}