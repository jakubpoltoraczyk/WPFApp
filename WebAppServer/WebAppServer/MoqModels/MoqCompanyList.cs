using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Models;

namespace WebAppServer.MoqModels
{
    public class MoqCompanyList : IMoqList<Company>
    {
        public List<Company> GetMoqList()
        {
            return new List<Company>()
            {
                new Company(){CompanyId=1,CompanyName="Capgemini"},
                new Company(){CompanyId=2,CompanyName="BTS"},
                new Company(){CompanyId=3,CompanyName="Google"},
                new Company(){CompanyId=4,CompanyName="PWr"},
            };
        }
    }
}
