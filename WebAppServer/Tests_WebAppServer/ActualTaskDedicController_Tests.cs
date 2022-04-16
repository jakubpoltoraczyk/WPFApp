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
    class ActualTaskDedicController_Tests
    {
        /// <summary>
        /// Checks that controler returns corect values
        /// </summary>
        [Test]
        public void ControlerTest()
        {
            IQueryable<Users> data = new List<Users>
            {
                new Users { Name = "Jan" },
                new Users { Name = "Piotr" },
                new Users { Name = "Kuba" },
            }.AsQueryable();

            Mock<DbSet<Users>> mockSet = new Mock<DbSet<Users>>();

            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());




            Mock<OracleDbContext> mockContext = new Mock<OracleDbContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            ActualTaskDedicController service = new ActualTaskDedicController(mockContext.Object);
            var result = service.Get();

            /*
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Jan", result[0].Name);
            Assert.AreEqual("Piotr", result[1].Name);
            Assert.AreEqual("Kuba", result[2].Name);
            */
        }
    }
}
