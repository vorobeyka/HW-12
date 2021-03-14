using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepsWebApp.Converters
{
    public class BaseConverter
    {
        /// <summary>
        /// Encode string to base64 string
        /// </summary>
        /// <param name="str">Default string</param>
        /// <returns>Encoded string</returns>
        public static string ToBase64String(string str)
        {
            return Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(str));
        }

        /// <summary>
        /// Decode string from base64 string.
        /// </summary>
        /// <param name="str">Base64 string.</param>
        /// <returns>Decoded string.</returns>
        public static string FromBase64String(string str)
        {
            return Encoding.GetEncoding("ISO-8859-1").GetString(
                    Convert.FromBase64String(
                        str.ToString().Split("Basic ")[1]));
        }
    }
}
