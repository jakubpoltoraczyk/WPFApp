using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqTypeOfCareList : BaseMoqList<TypeOfCare>
    {
        private static MoqTypeOfCareList _instance;
        public static MoqTypeOfCareList GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MoqTypeOfCareList();
                _data = new List<TypeOfCare>()
                {
                    new TypeOfCare(){TypeOfCareId=1,TypeOfCareName="podlewanie"},
                    new TypeOfCare(){TypeOfCareId=2,TypeOfCareName="przycinanie"},
                    new TypeOfCare(){TypeOfCareId=3,TypeOfCareName="plewienie"},
                    new TypeOfCare(){TypeOfCareId=4,TypeOfCareName="oprysl"},
                    new TypeOfCare(){TypeOfCareId=5,TypeOfCareName="naworzenie"},
                    new TypeOfCare(){TypeOfCareId=6,TypeOfCareName="przegląd"},
                    new TypeOfCare(){TypeOfCareId=7,TypeOfCareName="sprzedaż"},
                };
            }
            return _instance;
        }
        static MoqTypeOfCareList()
        {

        }
    }
}
