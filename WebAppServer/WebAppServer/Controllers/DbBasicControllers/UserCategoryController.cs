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
    public class UserCategoryController : ControllerBase
    {
        private OracleDbContext _dataContext;
        public UserCategoryController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>List of all UserCategories</returns>
        [HttpGet]
        public List<UserCategory> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return MoqUserCategoryList.GetInstance().GetMoqList();
            }
            return _dataContext.UserCategory.ToList();
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>UserCategory model that have matching id parameter</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCategory>> GetUserCategory(int id)
        {
            var inspection = await _dataContext.UserCategory.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            return inspection;
        }

        /// <summary>
        /// Rest Api Post method, to insert UserCategory into database 
        /// </summary>
        [HttpPost]
        public void Post(UserCategory company)
        {
            if (ApplicationVersion.IsTestVersion())
            {
                MoqUserCategoryList.GetInstance().PushToMoqList(company);
            }
            else
            {
                _dataContext.UserCategory.Add(company);
                _dataContext.SaveChangesAsync();
            }
            //return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }

        /*
        /// <summary>
        /// Rest Api Post method, to delete UserCategory from database 
        /// </summary>
        [HttpDelete]
        public StatusCodeResult Delete()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return StatusCode(555);

                //MoqUserCategoryList.GetInstance().PushToMoqList(company);
            }
            else
            {
                IQueryable<UserCategory> records = from m in _dataContext.UserCategory select m;

                foreach (var record in records)
                {
                    _dataContext.UserCategory.Remove(record);
                }
                _dataContext.SaveChanges();
                return StatusCode(200);
            }
        }
        */
    }
}
