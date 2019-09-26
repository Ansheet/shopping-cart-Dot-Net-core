using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        [Display(Name = "Order")]
        public int OrderID { get; set; }

        [Display(Name = "Product")]
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Products Products { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
    }
}
