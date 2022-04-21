using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WebAppServer.Contexts;
using WebAppServer.Contexts.SQL.Comands;
using WebAppServer.Controllers.DbBasicControllers;
using WebAppServer.MoqModels;

namespace Tests_WebAppServer
{
    class tmpClass
    {
        [Test]
        public void ControlerTest()
        {
            var aaa = MoqCareScheduleList.GetInstance().GetMoqList();
        }

        [Test]
        public void Moq_Insert()
        {
            OracleDbContext _dataContext = new OracleDbContext();

            var m1 = MoqUsersList.GetInstance().GetMoqList();
            foreach (var item in m1)
            {
                _dataContext.Users.Add(item);
                _dataContext.SaveChangesAsync();

            }

        }

    }
}
