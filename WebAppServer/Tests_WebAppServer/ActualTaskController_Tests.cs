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
    class ActualTaskController_Tests
    {
        /// <summary>
        /// Checks that controler returns corect values
        /// </summary>
        [Test]
        public void ControlerTest()
        {
            IQueryable<ActualTask> data = new List<ActualTask>
            {
                new ActualTask { ActualTaskId = 5 },
                new ActualTask { ActualTaskId = 9 },
                new ActualTask { ActualTaskId = 7 },
            }.AsQueryable();

            Mock<DbSet<ActualTask>> mockSet = new Mock<DbSet<ActualTask>>();

            mockSet.As<IQueryable<ActualTask>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ActualTask>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ActualTask>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ActualTask>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            Mock<OracleDbContext> mockContext = new Mock<OracleDbContext>();
            mockContext.Setup(c => c.ActualTask).Returns(mockSet.Object);

            ActualTaskController service = new ActualTaskController(mockContext.Object);
            var result = service.Get();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result[0].ActualTaskId);
            Assert.AreEqual(9, result[1].ActualTaskId);
            Assert.AreEqual(7, result[2].ActualTaskId);
        }
    }
}
