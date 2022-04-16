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

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>List of all TypeOfCares</returns>
        [HttpGet]
        public List<TypeOfCare> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return MoqTypeOfCareList.GetInstance().GetMoqList();
            }
            return _dataContext.TypeOfCare.ToList();
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>return TypeOfCare model that have matching id parameter</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfCare>> GetTypeOfCare(int id)
        {
            var inspection = await _dataContext.TypeOfCare.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            return inspection;
        }

        /// <summary>
        /// Rest Api Post method, to insert TypeOfCare into database 
        /// </summary>
        /// <returns>Inserted TypeOfCare</returns>
        [HttpPost]
        public void Post(TypeOfCare company)
        {
            if (ApplicationVersion.IsTestVersion())
            {
                MoqTypeOfCareList.GetInstance().PushToMoqList(company);
            }
            else
            {
                _dataContext.TypeOfCare.Add(company);
                _dataContext.SaveChangesAsync();
            }
            //return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }
    }
}
