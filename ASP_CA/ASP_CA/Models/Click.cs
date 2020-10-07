using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Models
{
    public class Click
    {
        private int count = 0;
        public int productId { get; set; }
        public int press()
        {
            count++;
            return count;
        }
    }
}
