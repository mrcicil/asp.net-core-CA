using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Models
{
    public class Session
    {
        public string SessionId { get; set; }
        public int UserId { get; set; }

        public long Timestamp { get; set; }
    }
}
