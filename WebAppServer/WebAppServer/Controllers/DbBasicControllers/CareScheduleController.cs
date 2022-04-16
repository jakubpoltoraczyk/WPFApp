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
        private readonly OracleDbContext _dataContext;
        public CareScheduleController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>List of all Care Schedules</returns>
        [HttpGet]
        public List<CareSchedule> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return new MoqCareScheduleList().GetMoqList();
            }
            return _dataContext.CareSchedule.ToList();
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>Company model that have matching id parameter</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CareSchedule>> GetCompany(int id)
        {
            var inspection = await _dataContext.CareSchedule.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            return inspection;
        }

        /// <summary>
        /// Rest Api Post method, to insert Care Schedule into database 
        /// </summary>
        /// <returns>Inserted Care Schedule</returns>
        [HttpPost]
        public async Task<ActionResult<CareSchedule>> PostInspection(CareSchedule company)
        {
            _dataContext.CareSchedule.Add(company);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.CareScheduleId }, company);
        }
    }
}
