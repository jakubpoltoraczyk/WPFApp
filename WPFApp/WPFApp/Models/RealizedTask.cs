using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp.Models
{
    public class RealizedTask
    {
        public int actualTaskId { get; set; }
        public string realizationDate { get; set; }
        public int palet_Id { get; set; }
        public int user_Id { get; set; }
        public int careSchedule_Id { get; set; }
    }
}
