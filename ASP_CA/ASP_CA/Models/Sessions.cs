using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Models
{
    public class Sessions
    {
        public Dictionary<string, Session> map { get; set; }

        public Sessions()
        {
            map = new Dictionary<string, Session>();
        }
    }
}
