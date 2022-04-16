using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    /// <summary>
    /// Class model that holds informations about Types of Care
    /// </summary>
    public class TypeOfCare
    {
        [Key]
        public int TypeOfCareId { get; set; }
        [StringLength(20)]
        public string TypeOfCareName { get; set; }
    }
}
