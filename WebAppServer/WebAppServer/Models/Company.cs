using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    /// <summary>
    /// Class model that holds informations about Companies
    /// </summary>
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [StringLength(20)]
        public string CompanyName { get; set; }
    }
}
