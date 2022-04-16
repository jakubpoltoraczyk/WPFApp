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
        /// <summary>
        /// Moq-ed class model that holds informations about Care Schedules
        /// </summary>
        public List<CareSchedule> GetMoqList()
        {
            return new List<CareSchedule>()
            {
                new CareSchedule(){ CareScheduleId=1, TimeOfCare=DateTime.Now.AddHours(9),  PaletPlantsType_Id=1, PriorityNumber=5, TypeOfCare_Id=3 },
                new CareSchedule(){ CareScheduleId=2, TimeOfCare=DateTime.Now.AddHours(1),  PaletPlantsType_Id=1, PriorityNumber=2, TypeOfCare_Id=4 },
                new CareSchedule(){ CareScheduleId=3, TimeOfCare=DateTime.Now.AddHours(2),  PaletPlantsType_Id=2, PriorityNumber=2, TypeOfCare_Id=6 },
                new CareSchedule(){ CareScheduleId=4, TimeOfCare=DateTime.Now.AddDays(1),   PaletPlantsType_Id=2, PriorityNumber=3, TypeOfCare_Id=2 },
                new CareSchedule(){ CareScheduleId=5, TimeOfCare=DateTime.Now.AddDays(2),   PaletPlantsType_Id=3, PriorityNumber=2, TypeOfCare_Id=1 },
                new CareSchedule(){ CareScheduleId=6, TimeOfCare=DateTime.Now.AddDays(7),   PaletPlantsType_Id=4, PriorityNumber=2, TypeOfCare_Id=3 },
                new CareSchedule(){ CareScheduleId=7, TimeOfCare=DateTime.Now.AddMonths(1), PaletPlantsType_Id=5, PriorityNumber=1, TypeOfCare_Id=5 },
            };
        }
    }
}
