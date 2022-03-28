using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    public class UserCategory
    {
        [Key]
        public int UserCategoryId { get; set; }
        [StringLength(20)]
        public string UserCategoryName { get; set; }
    }
}
