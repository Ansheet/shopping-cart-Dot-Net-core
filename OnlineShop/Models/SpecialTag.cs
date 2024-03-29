﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class SpecialTag
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Special Name")]
        public string Name { get; set; }
    }
}
