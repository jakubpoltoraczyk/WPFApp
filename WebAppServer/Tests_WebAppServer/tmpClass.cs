using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebAppServer.Contexts;
using WebAppServer.Controllers;
using WebAppServer.Controllers.DbBasicControllers;
using WebAppServer.Models;
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
    }
}
