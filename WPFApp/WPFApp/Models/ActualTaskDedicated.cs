using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp.Models
{
    public class ActualTaskDedicated
    {
        public int actualTaskId { get; set; }
        public string user_Id { get; set; }
        public string realizationDate { get; set; }
        public int paletNumber { get; set; }
        public string dateOfPlanting { get; set; }
        public string paletPlantsTypeName { get; set; }
        public string timeOfCare { get; set; }
        public int priorityNumber { get; set; }
        public string typeOfCareName { get; set; }
    }
}
