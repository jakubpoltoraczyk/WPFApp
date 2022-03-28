using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(20)]
        public string Mail { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public int UserCategory_Id { get; set; }
        public int Company_Id { get; set; }

    }
}
