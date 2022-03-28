using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqPaletPlantsTypeList : IMoqList<PaletPlantsType>
    {
        public List<PaletPlantsType> GetMoqList()
        {
            return new List<PaletPlantsType>()
            {
                new PaletPlantsType(){PaletPlantsTypeId=1,PaletPlantsTypeName="mery"},
                new PaletPlantsType(){PaletPlantsTypeId=2,PaletPlantsTypeName="chmiel"},
                new PaletPlantsType(){PaletPlantsTypeId=3,PaletPlantsTypeName="kaktus"},
                new PaletPlantsType(){PaletPlantsTypeId=4,PaletPlantsTypeName="tulipan"},
                new PaletPlantsType(){PaletPlantsTypeId=5,PaletPlantsTypeName="jabłoń"},
                new PaletPlantsType(){PaletPlantsTypeId=6,PaletPlantsTypeName="wiśnia"},
            };
        }
    }
}
