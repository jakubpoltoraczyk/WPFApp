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

namespace WebAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualTaskDedicController : ControllerBase
    {
        private readonly OracleDbContext _dataContext;
        public ActualTaskDedicController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        [HttpGet]
        public List<ActualTask> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return new MoqActualTask().GetMoqList();
            }
            return _dataContext.ActualTask.ToList();
        }
    }
}
