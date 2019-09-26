using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Display(Name = "Order No")]
        public string OrderNo { get; set; }
        [Display(Name = "Email ID")]
        public string EmailID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
