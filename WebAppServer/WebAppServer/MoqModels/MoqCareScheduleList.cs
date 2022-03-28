using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqCareScheduleList : IMoqList<CareSchedule>
    {
        public List<CareSchedule> GetMoqList()
        {
            return new List<CareSchedule>()
            {
                new CareSchedule(){ CareScheduleId=1, Date=DateTime.Now,              Palet_Id=1, PriorityNumber=5, TypeOfCare_Id=3, User_Id=1},
                new CareSchedule(){ CareScheduleId=2, Date=DateTime.Now.AddHours(1),  Palet_Id=1, PriorityNumber=2, TypeOfCare_Id=4, User_Id=2},
                new CareSchedule(){ CareScheduleId=3, Date=DateTime.Now.AddHours(2),  Palet_Id=2, PriorityNumber=2, TypeOfCare_Id=6, User_Id=2},
                new CareSchedule(){ CareScheduleId=4, Date=DateTime.Now.AddDays(1),   Palet_Id=2, PriorityNumber=3, TypeOfCare_Id=2, User_Id=1},
                new CareSchedule(){ CareScheduleId=5, Date=DateTime.Now.AddDays(2),   Palet_Id=3, PriorityNumber=2, TypeOfCare_Id=1, User_Id=1},
                new CareSchedule(){ CareScheduleId=6, Date=DateTime.Now.AddDays(7),   Palet_Id=4, PriorityNumber=2, TypeOfCare_Id=3, User_Id=2},
                new CareSchedule(){ CareScheduleId=7, Date=DateTime.Now.AddMonths(1), Palet_Id=5, PriorityNumber=1, TypeOfCare_Id=5, User_Id=1},
            };
        }
    }
}
