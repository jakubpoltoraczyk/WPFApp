using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    /// <summary>
    /// Class model that holds informations about login data
    /// </summary>
    public class Login
    {
        [Key]
        public string mail { get; set; }
    }
}
