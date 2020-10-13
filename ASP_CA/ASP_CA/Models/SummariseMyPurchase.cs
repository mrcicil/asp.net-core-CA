using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Models
{
    public class SummariseMyPurchase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Timestamp { get; set; }
        public int Quantity { get; set; }
    }
}
