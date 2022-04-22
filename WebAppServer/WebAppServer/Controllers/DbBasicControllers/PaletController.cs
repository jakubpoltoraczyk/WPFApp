using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private OracleDbContext _dataContext;
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
                company.PaletId = 0;                //to make sql auto increment this value
                _dataContext.Palet.Add(company);
                _dataContext.SaveChangesAsync();

                Palet tmp = _dataContext.Palet.ToList().Where(m => m.PaletNumber == company.PaletNumber).OrderByDescending(m => m.PaletId).First(); //get inserted object
                List<CareSchedule> careSchedulesList = _dataContext.CareSchedule.ToList().Where(m => m.PaletPlantsType_Id == tmp.PaletPlantsType_Id).ToList();
                _dataContext.SaveChangesAsync();

                for (int i = 0; i < careSchedulesList.Count; i++)
                {
                    ActualTask actual = new ActualTask()
                    {
                        //ActualTaskId = 0,
                        Palet_Id = tmp.PaletId,
                        CareSchedule_Id = careSchedulesList[i].CareScheduleId,
                        //RealizationDate = null,
                        //User_Id = null
                    };
                    _dataContext.ActualTask.Add(actual);
                }
                _dataContext.SaveChangesAsync();

            }
            //return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }
    }
}
