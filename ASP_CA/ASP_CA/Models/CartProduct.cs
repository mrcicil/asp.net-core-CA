using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Models
{
    public class CartProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductTotal { get; set; }
    }
}
