using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqPaletPlantsTypeList : BaseMoqList<PaletPlantsType>
    {
        private static MoqPaletPlantsTypeList _instance;
        public static MoqPaletPlantsTypeList GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MoqPaletPlantsTypeList();
                _data = new List<PaletPlantsType>()
                {
                    new PaletPlantsType(){PaletPlantsTypeId=1,PaletPlantsTypeName="kawowiec"},
                    new PaletPlantsType(){PaletPlantsTypeId=2,PaletPlantsTypeName="chmiel"},
                    new PaletPlantsType(){PaletPlantsTypeId=3,PaletPlantsTypeName="kaktus"},
                    new PaletPlantsType(){PaletPlantsTypeId=4,PaletPlantsTypeName="tulipan"},
                    new PaletPlantsType(){PaletPlantsTypeId=5,PaletPlantsTypeName="jabłoń"},
                    new PaletPlantsType(){PaletPlantsTypeId=6,PaletPlantsTypeName="wiśnia"},
                };
            }
            return _instance;
        }
        static MoqPaletPlantsTypeList()
        {

        }
    }
}
