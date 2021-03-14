using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DepsWebApp.Models
{
    /// <summary>
    /// Contract for register account
    /// </summary>
    public class AuthRequest
    {
        /// <summary>
        /// Account login.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [MinLength(6)]
        public string Login { get; set; }

        /// <summary>
        /// Account password.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
