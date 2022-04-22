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
    class PaletController_Tests
    {
        /// <summary>
        /// Checks that controler returns corect values
        /// </summary>
        [Test]
        public void ControlerTest()
        {
            IQueryable<Palet> data = new List<Palet>
            {
                new Palet { PaletId = 5 },
                new Palet { PaletId = 9 },
                new Palet { PaletId = 7 },
            }.AsQueryable();

            Mock<DbSet<Palet>> mockSet = new Mock<DbSet<Palet>>();

            mockSet.As<IQueryable<Palet>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Palet>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Palet>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Palet>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());




            Mock<OracleDbContext> mockContext = new Mock<OracleDbContext>();
            mockContext.Setup(c => c.Palet).Returns(mockSet.Object);

            PaletController service = new PaletController(mockContext.Object);
            var result = service.Get();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result[0].PaletId);
            Assert.AreEqual(9, result[1].PaletId);
            Assert.AreEqual(7, result[2].PaletId);
        }
    }
}
