using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    /// <summary>
    /// Class model that holds informations about User Categories
    /// </summary>
    public class UserCategory
    {
        [Key]
        public int UserCategoryId { get; set; }
        [StringLength(20)]
        public string UserCategoryName { get; set; }
    }
}
