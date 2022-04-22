using DedicModels_Library;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebAppServer.Contexts;
using WebAppServer.Controllers;
using WebAppServer.Controllers.DbBasicControllers;
using WebAppServer.Models;

namespace Tests_WebAppServer
{
    /// <summary>
    /// Class to test controlers connection and retured type values
    /// </summary>
    class CareScheduleController_Tests
    {
        /// <summary>
        /// Checks that controler returns corect values
        /// </summary>
        [Test]
        public void ControlerTest()
        {
            IQueryable<CareSchedule> data = new List<CareSchedule>
            {
                new CareSchedule { CareScheduleId = 5 },
                new CareSchedule { CareScheduleId = 9 },
                new CareSchedule { CareScheduleId = 7 },
            }.AsQueryable();

            Mock<DbSet<CareSchedule>> mockSet = new Mock<DbSet<CareSchedule>>();

            mockSet.As<IQueryable<CareSchedule>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<CareSchedule>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<CareSchedule>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<CareSchedule>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());




            Mock<OracleDbContext> mockContext = new Mock<OracleDbContext>();
            mockContext.Setup(c => c.CareSchedule).Returns(mockSet.Object);

            CareScheduleController service = new CareScheduleController(mockContext.Object);
            var result = service.Get();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result[0].CareScheduleId);
            Assert.AreEqual(9, result[1].CareScheduleId);
            Assert.AreEqual(7, result[2].CareScheduleId);
        }
    }
}
