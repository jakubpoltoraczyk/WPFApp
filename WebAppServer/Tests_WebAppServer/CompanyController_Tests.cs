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
    class CompanyController_Tests
    {
        /// <summary>
        /// Checks that controler returns corect values
        /// </summary>
        [Test]
        public void ControlerTest()
        {
            IQueryable<Company> data = new List<Company>
            {
                new Company { CompanyId = 5 },
                new Company { CompanyId = 9 },
                new Company { CompanyId = 7 },
            }.AsQueryable();

            Mock<DbSet<Company>> mockSet = new Mock<DbSet<Company>>();

            mockSet.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());




            Mock<OracleDbContext> mockContext = new Mock<OracleDbContext>();
            mockContext.Setup(c => c.Company).Returns(mockSet.Object);

            CompanyController service = new CompanyController(mockContext.Object);
            var result = service.Get();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result[0].CompanyId);
            Assert.AreEqual(9, result[1].CompanyId);
            Assert.AreEqual(7, result[2].CompanyId);
        }
    }
}
