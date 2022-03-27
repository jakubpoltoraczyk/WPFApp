using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    public class Palet
    {
        public int PaletId { get; set; }
        public int PaletNumber { get; set; }
        public int PaletPlantsType_Id { get; set; }
        public DateTime DateOfPlanting { get; set; }
    }
}
