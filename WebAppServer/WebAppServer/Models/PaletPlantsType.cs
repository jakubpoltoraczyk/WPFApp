using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    public class PaletPlantsType
    {
        [Key]
        public int PaletPlantsTypeId { get; set; }
        [StringLength(20)]
        public string PaletPlantsTypeName { get; set; }
    }
}
