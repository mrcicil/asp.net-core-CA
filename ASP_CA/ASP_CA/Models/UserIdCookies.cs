using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CA.Models
{
    public class UserIdCookies
    {
        public Dictionary<int, Session> map { get; set; }

        public UserIdCookies()
        {
            map = new Dictionary<int, Session>();
        }
    }
}
