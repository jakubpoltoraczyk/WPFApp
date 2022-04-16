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
    public class PaletPlantsTypeController : ControllerBase
    {
        private readonly OracleDbContext _dataContext;
        public PaletPlantsTypeController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>List of all Companies</returns>
        [HttpGet]
        public List<PaletPlantsType> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return MoqPaletPlantsTypeList.GetInstance().GetMoqList();
            }
            return _dataContext.PaletPlantsType.ToList();
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>Company model that have matching id parameter</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PaletPlantsType>> GetCompany(int id)
        {
            var inspection = await _dataContext.PaletPlantsType.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            return inspection;
        }

        /// <summary>
        /// Rest Api Post method, to insert Company into database 
        /// </summary>
        /// <returns>Inserted Company</returns>
        [HttpPost]
        public void Post(PaletPlantsType company)
        {
            if (ApplicationVersion.IsTestVersion())
            {
                MoqPaletPlantsTypeList.GetInstance().PushToMoqList(company);
            }
            else
            {
                _dataContext.PaletPlantsType.Add(company);
                _dataContext.SaveChangesAsync();
            }
            //return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }
    }
}
