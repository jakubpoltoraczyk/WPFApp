using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqPaletList : IMoqList<Palet>
    {
        public List<Palet> GetMoqList()
        {
            return new List<Palet>()
            {
                new Palet(){PaletId=1,PaletNumber=1155,PaletPlantsType_Id=1,DateOfPlanting=DateTime.Now.AddDays(-7*1)},
                new Palet(){PaletId=2,PaletNumber=2255,PaletPlantsType_Id=1,DateOfPlanting=DateTime.Now.AddDays(-7*1)},
                new Palet(){PaletId=3,PaletNumber=3355,PaletPlantsType_Id=2,DateOfPlanting=DateTime.Now.AddDays(-7*1)},
                new Palet(){PaletId=4,PaletNumber=1222,PaletPlantsType_Id=3,DateOfPlanting=DateTime.Now.AddDays(-7*1)},
                new Palet(){PaletId=5,PaletNumber=5888,PaletPlantsType_Id=3,DateOfPlanting=DateTime.Now.AddDays(-7*1)},
                new Palet(){PaletId=6,PaletNumber=1354,PaletPlantsType_Id=4,DateOfPlanting=DateTime.Now.AddDays(-7*1)},
                new Palet(){PaletId=7,PaletNumber=9988,PaletPlantsType_Id=4,DateOfPlanting=DateTime.Now.AddDays(-7*1)},
            };
        }
    }
}
