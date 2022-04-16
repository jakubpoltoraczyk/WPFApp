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
    public class ActualTaskController : ControllerBase
    {
        private readonly OracleDbContext _dataContext;
        public ActualTaskController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>List of all Actual Tasks - not joined</returns>
        [HttpGet]
        public List<ActualTask> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return new MoqActualTaskList().GetMoqList();
            }
            return _dataContext.ActualTask.ToList();
        }
    }
}
