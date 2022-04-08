using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqActualTaskList : IMoqList<ActualTask>
    {
        public List<ActualTask> GetMoqList()
        {
            return new List<ActualTask>()
            {
                new ActualTask(){ActualTaskId= 1, CareSchedule_Id= 1, Palet_Id= 1, RealizationDate= null, User_Id= null},
                new ActualTask(){ActualTaskId= 2, CareSchedule_Id= 3, Palet_Id= 2, RealizationDate= null, User_Id= null},
                new ActualTask(){ActualTaskId= 3, CareSchedule_Id= 4, Palet_Id= 3, RealizationDate= null, User_Id= null},
                new ActualTask(){ActualTaskId= 4, CareSchedule_Id= 2, Palet_Id= 4, RealizationDate= null, User_Id= null},
                new ActualTask(){ActualTaskId= 5, CareSchedule_Id= 6, Palet_Id= 5, RealizationDate= null, User_Id= null},
                new ActualTask(){ActualTaskId= 6, CareSchedule_Id= 3, Palet_Id= 6, RealizationDate= null, User_Id= null},
                new ActualTask(){ActualTaskId= 7, CareSchedule_Id= 2, Palet_Id= 7, RealizationDate= null, User_Id= null},
                new ActualTask(){ActualTaskId= 8, CareSchedule_Id= 7, Palet_Id= 8, RealizationDate= null, User_Id= null},
                new ActualTask(){ActualTaskId= 9, CareSchedule_Id= 2, Palet_Id= 9, RealizationDate= null, User_Id= null},
            };
        }
    }
    
}
