﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ASP_CA.Models
{ 
    public class Cart
    { 
        public Product Product { get; set; }
       
        public int Quantity { get; set; }

    }
}
