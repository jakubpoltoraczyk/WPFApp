using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqCareScheduleList : BaseMoqList<CareSchedule>
    {
        private static MoqCareScheduleList _instance;
        public static MoqCareScheduleList GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MoqCareScheduleList();
                _data = new List<CareSchedule>()
                {
                    new CareSchedule(){ CareScheduleId=1, TimeOfCare=new TimeSpan(7,2,0,0), PaletPlantsType_Id=1, PriorityNumber=5, TypeOfCare_Id=3 },
                    new CareSchedule(){ CareScheduleId=2, TimeOfCare=new TimeSpan(1,5,0,0), PaletPlantsType_Id=1, PriorityNumber=2, TypeOfCare_Id=4 },
                    new CareSchedule(){ CareScheduleId=3, TimeOfCare=new TimeSpan(2,6,0,0), PaletPlantsType_Id=2, PriorityNumber=2, TypeOfCare_Id=6 },
                    new CareSchedule(){ CareScheduleId=4, TimeOfCare=new TimeSpan(3,4,0,0), PaletPlantsType_Id=2, PriorityNumber=3, TypeOfCare_Id=2 },
                    new CareSchedule(){ CareScheduleId=5, TimeOfCare=new TimeSpan(7,2,0,0), PaletPlantsType_Id=3, PriorityNumber=2, TypeOfCare_Id=1 },
                    new CareSchedule(){ CareScheduleId=6, TimeOfCare=new TimeSpan(5,9,0,0), PaletPlantsType_Id=4, PriorityNumber=2, TypeOfCare_Id=3 },
                    new CareSchedule(){ CareScheduleId=7, TimeOfCare=new TimeSpan(7,1,0,0), PaletPlantsType_Id=5, PriorityNumber=1, TypeOfCare_Id=5 },
                };
            }
            return _instance;
        }
        static MoqCareScheduleList()
        {

        }
    }
}




