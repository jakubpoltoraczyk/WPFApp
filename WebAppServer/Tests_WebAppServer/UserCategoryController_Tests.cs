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
    class UserCategoryController_Tests
    {
        /// <summary>
        /// Checks that controler returns corect values
        /// </summary>
        [Test]
        public void ControlerTest()
        {
            IQueryable<UserCategory> data = new List<UserCategory>
            {
                new UserCategory { UserCategoryId = 5 },
                new UserCategory { UserCategoryId = 9 },
                new UserCategory { UserCategoryId = 7 },
            }.AsQueryable();

            Mock<DbSet<UserCategory>> mockSet = new Mock<DbSet<UserCategory>>();

            mockSet.As<IQueryable<UserCategory>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserCategory>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserCategory>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserCategory>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());




            Mock<OracleDbContext> mockContext = new Mock<OracleDbContext>();
            mockContext.Setup(c => c.UserCategory).Returns(mockSet.Object);

            UserCategoryController service = new UserCategoryController(mockContext.Object);
            var result = service.Get();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result[0].UserCategoryId);
            Assert.AreEqual(9, result[1].UserCategoryId);
            Assert.AreEqual(7, result[2].UserCategoryId);
        }
    }
}
