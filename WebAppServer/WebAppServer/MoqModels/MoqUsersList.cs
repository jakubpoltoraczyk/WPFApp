using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqUsersList : BaseMoqList<Users>
    {
        private static MoqUsersList _instance;
        public static MoqUsersList GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MoqUsersList();
                _data = new List<Users>()
                {
                    new Users(){UserId= 1,Birthday=DateTime.Now.AddDays(-365*20),Company_Id= 1,Name="Peter", LastName= "Tomaszkiewicz",Mail="pkubon3@gmail.com",Phone="721545820",UserCategory_Id=2},
                    new Users(){UserId= 2,Birthday=DateTime.Now.AddDays(-365*22),Company_Id= 1,Name="Kuba",  LastName= "Jankowski",    Mail="kuba@gmail.com",   Phone="777555777",UserCategory_Id=2},
                    new Users(){UserId= 3,Birthday=DateTime.Now.AddDays(-365*50),Company_Id= 2,Name="Elon",  LastName= "Musk",         Mail="musk@gmail.com",   Phone="222000999",UserCategory_Id=1},
                };
            }
            return _instance;
        }
        static MoqUsersList()
        {

        }
    }
}


