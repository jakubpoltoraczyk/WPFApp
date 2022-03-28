using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebAppServer.Contexts;
using WebAppServer.Controllers;
using WebAppServer.Models;

namespace Tests_WebAppServer
{
    class UsersControler_Tests
    {
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

            UsersController service = new UsersController(mockContext.Object);
            var result = service.Get();


            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Jan", result[0].Name);
            Assert.AreEqual("Piotr", result[1].Name);
            Assert.AreEqual("Kuba", result[2].Name);
        }
    }
}
