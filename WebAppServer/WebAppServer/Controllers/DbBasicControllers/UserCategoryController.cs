using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Contexts;
using WebAppServer.Models;
using WebAppServer.MoqModels;
using WebAppServer.SingletonsFlags;

namespace WebAppServer.Controllers.DbBasicControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCategoryController : ControllerBase
    {
        private readonly OracleDbContext _dataContext;
        public UserCategoryController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>List of all User Categories</returns>
        [HttpGet]
        public List<UserCategory> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return new MoqUserCategoryList().GetMoqList();
            }
            return _dataContext.UserCategory.ToList();
        }
    }
}
