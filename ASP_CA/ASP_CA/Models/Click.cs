using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEF.Models
{
    public class Click
    {
        private int count = 0;
        public int press()
        {
            count++;
            return count;
        }
    }
}
