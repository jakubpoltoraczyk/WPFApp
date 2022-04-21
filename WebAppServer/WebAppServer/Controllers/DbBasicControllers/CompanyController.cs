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
    public class CompanyController : ControllerBase
    {
        private OracleDbContext _dataContext;
        public CompanyController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>List of all Companies</returns>
        [HttpGet]
        public List<Company> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return MoqCompanyList.GetInstance().GetMoqList();
            }
            return _dataContext.Company.ToList();
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>Company model that have matching id parameter</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var inspection = await _dataContext.Company.FindAsync(id);
            if (inspection == null){
                return NotFound();
            }
            return inspection;
        }

        /// <summary>
        /// Rest Api Post method, to insert Company into database 
        /// </summary>
        /// <returns>Inserted Company</returns>
        [HttpPost]
        public void Post(Company company)
        {
            if (ApplicationVersion.IsTestVersion()){
                MoqCompanyList.GetInstance().PushToMoqList(company);
            }
            else{
                _dataContext.Company.Add(company);
                _dataContext.SaveChangesAsync();
            }
            //return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }
    }
}
