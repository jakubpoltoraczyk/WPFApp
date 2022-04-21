using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp.Models
{
    public class Palet
    {
        public int paletId { get; set; }
        public int paletNumber { get; set; }
        public int paletPlantsType_Id { get; set; }
        public DateTime dateOfPlanting { get; set; }
    }
}
