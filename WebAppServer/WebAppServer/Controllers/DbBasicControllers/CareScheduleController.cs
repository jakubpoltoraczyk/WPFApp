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
    public class CareScheduleController : ControllerBase
    {
        private OracleDbContext _dataContext;
        public CareScheduleController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>List of all CareSchedule</returns>
        [HttpGet]
        public List<CareSchedule> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return MoqCareScheduleList.GetInstance().GetMoqList();
            }
            return _dataContext.CareSchedule.ToList();
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>return CareSchedule model that have matching id parameter</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CareSchedule>> GetCareSchedule(int id)
        {
            var inspection = await _dataContext.CareSchedule.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            return inspection;
        }

        /// <summary>
        /// Rest Api Post method, to insert Company into database 
        /// </summary>
        /// <returns>Inserted CareSchedule</returns>
        [HttpPost]
        public void Post(CareSchedule company)
        {
            if (ApplicationVersion.IsTestVersion())
            {
                MoqCareScheduleList.GetInstance().PushToMoqList(company);
            }
            else
            {
                _dataContext.CareSchedule.Add(company);
                _dataContext.SaveChangesAsync();
            }
            //return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }
    }
}
