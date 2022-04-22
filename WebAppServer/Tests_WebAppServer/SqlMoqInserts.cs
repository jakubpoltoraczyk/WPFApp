using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WebAppServer.Contexts;
using WebAppServer.Contexts.SQL.Comands;
using WebAppServer.Controllers.DbBasicControllers;
using WebAppServer.MoqModels;

namespace Tests_WebAppServer
{
    class SqlMoqInserts
    {
        [Test]
        public void InsertRecordsFromMoqToDb()
        {
            /*
            new MoqInsert_Users().Insert();
            new MoqInsert_ActualTask().Insert();
            new MoqInsert_CareSchedule().Insert();
            new MoqInsert_Company().Insert();
            new MoqInsert_Palet().Insert();
            new MoqInsert_PaletPlantsType().Insert();
            new MoqInsert_TypeOfCare().Insert();
            new MoqInsert_UserCategory().Insert();
            /*/
        }

        [Test]
        public void DeleteDatabase()
        {
            //to create db - Make migrations
            /*
            new MoqInsert_Users().Delete();
            new MoqInsert_ActualTask().Delete();
            new MoqInsert_CareSchedule().Delete();
            new MoqInsert_Company().Delete();
            new MoqInsert_Palet().Delete();
            new MoqInsert_PaletPlantsType().Delete();
            new MoqInsert_TypeOfCare().Delete();
            new MoqInsert_UserCategory().Delete();
            */
        }


        [Test]
        public void MoqInsert_Users()
        {
            //new MoqInsert_Users().Insert();
        }
        [Test]
        public void MoqInsert_ActualTask()
        {
            //new MoqInsert_ActualTask().Insert();
        }
        [Test]
        public void MoqInsert_CareSchedule()
        {
            //new MoqInsert_CareSchedule().Insert();
        }
        [Test]
        public void MoqInsert_Company()
        {
            //new MoqInsert_Company().Insert();
        }
        [Test]
        public void MoqInsert_Palet()
        {
            //new MoqInsert_Palet().Insert();
        }
        [Test]
        public void MoqInsert_PaletPlantsType()
        {
            //new MoqInsert_PaletPlantsType().Insert();
        }
        [Test]
        public void MoqInsert_TypeOfCare()
        {
            //new MoqInsert_TypeOfCare().Insert();
        }
        [Test]
        public void MoqInsert_UserCategory()
        {
            //new MoqInsert_UserCategory().Insert();
        }

    }
}
