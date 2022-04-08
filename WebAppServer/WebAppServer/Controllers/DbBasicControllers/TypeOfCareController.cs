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
    public class TypeOfCareController : ControllerBase
    {
        private readonly OracleDbContext _dataContext;
        public TypeOfCareController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        [HttpGet]
        public List<TypeOfCare> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return new MoqTypeOfCareList().GetMoqList();
            }
            return _dataContext.TypeOfCare.ToList();
        }
    }
}
