using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_CA.Common
{
    public class ScrambleMethod
    {
        public static string Key = "pr3ttyg00dpr1vacy";
        public static string ToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        //public static string ToDecrypt(string base64EncodedData)
        //{
        //    if (string.IsNullOrEmpty(base64EncodedData))
        //    {
        //        return "";
        //    }
        //    var base64EncodedBtyes = Convert.FromBase64String(base64EncodedData);
        //    var pw = Encoding.UTF8.GetString(base64EncodedBtyes);
        //    pw = pw.Substring(0, pw.Length - Key.Length);
        //    return pw;
        //}
    }
}
