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
    class PaletPlantsTypeController_Tests
    {
        /// <summary>
        /// Checks that controler returns corect values
        /// </summary>
        [Test]
        public void ControlerTest()
        {
            IQueryable<PaletPlantsType> data = new List<PaletPlantsType>
            {
                new PaletPlantsType { PaletPlantsTypeId = 5 },
                new PaletPlantsType { PaletPlantsTypeId = 9 },
                new PaletPlantsType { PaletPlantsTypeId = 7 },
            }.AsQueryable();

            Mock<DbSet<PaletPlantsType>> mockSet = new Mock<DbSet<PaletPlantsType>>();

            mockSet.As<IQueryable<PaletPlantsType>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<PaletPlantsType>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<PaletPlantsType>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<PaletPlantsType>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());




            Mock<OracleDbContext> mockContext = new Mock<OracleDbContext>();
            mockContext.Setup(c => c.PaletPlantsType).Returns(mockSet.Object);

            PaletPlantsTypeController service = new PaletPlantsTypeController(mockContext.Object);
            var result = service.Get();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result[0].PaletPlantsTypeId);
            Assert.AreEqual(9, result[1].PaletPlantsTypeId);
            Assert.AreEqual(7, result[2].PaletPlantsTypeId);
        }
    }
}
