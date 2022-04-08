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
        private readonly OracleDbContext _dataContext;
        public CompanyController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        [HttpGet]
        public List<Company> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return new MoqCompanyList().GetMoqList();
            }
            return _dataContext.Company.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var inspection = await _dataContext.Company.FindAsync(id);
            if (inspection == null){
                return NotFound();
            }
            return inspection;
        }
        [HttpPost]
        public async Task<ActionResult<Company>> PostInspection(Company company)
        {
            _dataContext.Company.Add(company);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }
    }
}
