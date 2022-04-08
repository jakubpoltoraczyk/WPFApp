using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqUserCategoryList : IMoqList<UserCategory>
    {
        public List<UserCategory> GetMoqList()
        {
            return new List<UserCategory>()
            {
                new UserCategory(){UserCategoryId=-1,UserCategoryName="unemployed"},
                new UserCategory(){UserCategoryId=0,UserCategoryName="admin"},
                new UserCategory(){UserCategoryId=1,UserCategoryName="manager"},
                new UserCategory(){UserCategoryId=2,UserCategoryName="worker"},
            };
        }
    }
}
