using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    public class CareSchedule
    {
        public int CareScheduleId { get; set; }
        public int TypeOfCare_Id { get; set; }
        public DateTime Date { get; set; }
        public int Palet_Id { get; set; }
        public int User_Id { get; set; }
        public int PriorityNumber { get; set; }
    }
}
