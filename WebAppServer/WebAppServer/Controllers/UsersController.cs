using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Contexts;
using WebAppServer.Models;

namespace WebAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly OracleDbContext _dataContext;
        public UsersController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        [HttpGet]
        public List<Users> Get()
        {
            /*
            ObjectSet<Contact> contacts = context.Contacts;
            ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

            var query =
                contacts.Join(
                    orders,
                    order => order.ContactID,
                    contact => contact.Contact.ContactID,
                    (contact, order) => new
                    {
                        ContactID = contact.ContactID,
                        SalesOrderID = order.SalesOrderID,
                        FirstName = contact.FirstName,
                        Lastname = contact.LastName,
                        TotalDue = order.TotalDue
                    });
            return _dataContext.Users.ToList();
            */
            
            return _dataContext.Users.ToList();

            List<Users> tmp = new List<Users>()
            {
                new Users(){Name = "Kuba", UserId = 1},
                new Users(){Name = "Jan", UserId = 2},
                new Users(){Name = "Peter", UserId = 3},
                new Users(){Name = "Wiki", UserId = 4},
            };
            return tmp;
        }

    }
}
