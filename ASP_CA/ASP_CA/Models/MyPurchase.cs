using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Models
{
    public class MyPurchase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string TimeStamp { get; set; }
        public string ActivationCode { get; set; }
    }
}
