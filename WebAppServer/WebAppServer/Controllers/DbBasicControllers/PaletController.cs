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
    public class PaletController : ControllerBase
    {
        private readonly OracleDbContext _dataContext;
        public PaletController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>List of all Palets</returns>
        [HttpGet]
        public List<Palet> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return MoqPaletList.GetInstance().GetMoqList();
            }
            return _dataContext.Palet.ToList();
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>returns Palet model that have matching id parameter</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Palet>> GetPalet(int id)
        {
            var inspection = await _dataContext.Palet.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            return inspection;
        }

        /// <summary>
        /// Rest Api Post method, to insert Company into database 
        /// </summary>
        /// <returns>Inserted Palet</returns>
        [HttpPost]
        public void Post(Palet company)
        {
            if (ApplicationVersion.IsTestVersion())
            {
                MoqPaletList.GetInstance().PushToMoqList(company);
            }
            else
            {
                _dataContext.Palet.Add(company);
                _dataContext.SaveChangesAsync();
            }
            //return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }
    }
}
