using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Products
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public decimal price { get; set; }
        public string Image { get; set; }
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Display(Name = "Available")]
        public bool Isavailable { get; set; }
        [ForeignKey("ProductTypeId")]
        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }
        public ProductTypes ProductType { get; set; }
        [Display(Name = "Special Tag")]
        public int SpecialTagID { get; set; }
        [ForeignKey("SpecialTagID")]
        public SpecialTag specialTag { get; set; }
    }
}
