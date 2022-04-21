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
        private OracleDbContext _dataContext;
        public ActualTaskController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>List of all ActualTasks</returns>
        [HttpGet]
        public List<ActualTask> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return MoqActualTaskList.GetInstance().GetMoqList();
            }
            return _dataContext.ActualTask.ToList();
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>return ActualTask model that have matching id parameter</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ActualTask>> GetActualTask(int id)
        {
            var inspection = await _dataContext.ActualTask.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            return inspection;
        }

        /// <summary>
        /// Rest Api Post method, to insert Company into database 
        /// </summary>
        /// <returns>Inserted ActualTask</returns>
        [HttpPost]
        public void Post(ActualTask company)
        {
            if (ApplicationVersion.IsTestVersion())
            {
                MoqActualTaskList.GetInstance().PushToMoqList(company);
            }
            else
            {
                _dataContext.ActualTask.Add(company);
                _dataContext.SaveChangesAsync();
            }
            //return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }
    }
}
