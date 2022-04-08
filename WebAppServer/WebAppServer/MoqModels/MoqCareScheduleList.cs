﻿using System;
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
                new CareSchedule(){ CareScheduleId=1, TimeOdCare=DateTime.Now,              PaletPlantsType_Id=1, PriorityNumber=5, TypeOfCare_Id=3 },
                new CareSchedule(){ CareScheduleId=2, TimeOdCare=DateTime.Now.AddHours(1),  PaletPlantsType_Id=1, PriorityNumber=2, TypeOfCare_Id=4 },
                new CareSchedule(){ CareScheduleId=3, TimeOdCare=DateTime.Now.AddHours(2),  PaletPlantsType_Id=2, PriorityNumber=2, TypeOfCare_Id=6 },
                new CareSchedule(){ CareScheduleId=4, TimeOdCare=DateTime.Now.AddDays(1),   PaletPlantsType_Id=2, PriorityNumber=3, TypeOfCare_Id=2 },
                new CareSchedule(){ CareScheduleId=5, TimeOdCare=DateTime.Now.AddDays(2),   PaletPlantsType_Id=3, PriorityNumber=2, TypeOfCare_Id=1 },
                new CareSchedule(){ CareScheduleId=6, TimeOdCare=DateTime.Now.AddDays(7),   PaletPlantsType_Id=4, PriorityNumber=2, TypeOfCare_Id=3 },
                new CareSchedule(){ CareScheduleId=7, TimeOdCare=DateTime.Now.AddMonths(1), PaletPlantsType_Id=5, PriorityNumber=1, TypeOfCare_Id=5 },
            };
        }
    }
}
