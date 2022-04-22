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
    class TypeOfCareController_Tests
    {
        /// <summary>
        /// Checks that controler returns corect values
        /// </summary>
        [Test]
        public void ControlerTest()
        {
            IQueryable<TypeOfCare> data = new List<TypeOfCare>
            {
                new TypeOfCare { TypeOfCareId = 5 },
                new TypeOfCare { TypeOfCareId = 9 },
                new TypeOfCare { TypeOfCareId = 7 },
            }.AsQueryable();

            Mock<DbSet<TypeOfCare>> mockSet = new Mock<DbSet<TypeOfCare>>();

            mockSet.As<IQueryable<TypeOfCare>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TypeOfCare>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TypeOfCare>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TypeOfCare>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());




            Mock<OracleDbContext> mockContext = new Mock<OracleDbContext>();
            mockContext.Setup(c => c.TypeOfCare).Returns(mockSet.Object);

            TypeOfCareController service = new TypeOfCareController(mockContext.Object);
            var result = service.Get();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result[0].TypeOfCareId);
            Assert.AreEqual(9, result[1].TypeOfCareId);
            Assert.AreEqual(7, result[2].TypeOfCareId);
        }
    }
}
