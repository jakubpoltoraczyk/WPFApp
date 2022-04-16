using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqUserCategoryList : BaseMoqList<UserCategory>
    {
        private static MoqUserCategoryList _instance;
        public static MoqUserCategoryList GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MoqUserCategoryList();
                _data = new List<UserCategory>()
                {
                    new UserCategory(){UserCategoryId=-1,UserCategoryName="unemployed"},
                    new UserCategory(){UserCategoryId=0,UserCategoryName="admin"},
                    new UserCategory(){UserCategoryId=1,UserCategoryName="manager"},
                    new UserCategory(){UserCategoryId=2,UserCategoryName="worker"},
                };
            }
            return _instance;
        }
        static MoqUserCategoryList()
        {

        }
    }
}


