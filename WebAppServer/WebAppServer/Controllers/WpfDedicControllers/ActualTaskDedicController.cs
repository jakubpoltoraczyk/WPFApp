using DedicModels_Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppServer.Contexts;
using WebAppServer.Models;
using WebAppServer.MoqModels;
using WebAppServer.SingletonsFlags;

namespace WebAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualTaskDedicController : ControllerBase
    {
        private readonly OracleDbContext _dataContext;
        public ActualTaskDedicController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }

        /// <summary>
        /// Rest Api Get method
        /// </summary>
        /// <returns>returns joined information of all actual tasks</returns>
        [HttpGet]
        public List<ActualTaskDedic> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                List<ActualTaskDedic> ret = new List<ActualTaskDedic>();

                List<ActualTask> ActualTaskList = MoqActualTaskList.GetInstance().GetMoqList();
                List<Palet> PaletsList = MoqPaletList.GetInstance().GetMoqList();
                List<PaletPlantsType> PaletPlantsTypeList = MoqPaletPlantsTypeList.GetInstance().GetMoqList();
                List<CareSchedule> CareScheduleList = MoqCareScheduleList.GetInstance().GetMoqList();
                List<TypeOfCare> TypeOfCareList = MoqTypeOfCareList.GetInstance().GetMoqList();

                // ----------------------------------------------------------------------------------do poprawy joinowanie-----------------------------------------------------------
                foreach (ActualTask actualTask in ActualTaskList)
                {
                    ActualTaskDedic tmp = new ActualTaskDedic();
                    tmp.User_Id = actualTask.User_Id;
                    tmp.RealizationDate = actualTask.RealizationDate;

                    foreach (Palet palet in PaletsList)
                    {
                        if (actualTask.Palet_Id == palet.PaletId)
                        {
                            tmp.DateOfPlanting = palet.DateOfPlanting;
                            tmp.PaletNumber = palet.PaletNumber;
                            foreach (PaletPlantsType paletPlantsType in PaletPlantsTypeList)
                            {
                                if (palet.PaletPlantsType_Id == paletPlantsType.PaletPlantsTypeId)
                                {
                                    tmp.PaletPlantsTypeName = paletPlantsType.PaletPlantsTypeName;
                                }
                            }
                        }
                    }
                    foreach (CareSchedule careSchedule in CareScheduleList)
                    {
                        if (actualTask.CareSchedule_Id == careSchedule.CareScheduleId)
                        {
                            tmp.PriorityNumber = careSchedule.PriorityNumber;
                            tmp.TimeOfCare = careSchedule.TimeOfCare;
                            foreach (TypeOfCare typeOfCare in TypeOfCareList)
                            {
                                if (typeOfCare.TypeOfCareId == careSchedule.TypeOfCare_Id)
                                {
                                    tmp.TypeOfCareName = typeOfCare.TypeOfCareName;
                                }
                            }
                        }
                    }
                    ret.Add(tmp);
                }

                return ret;
            }
            //return _dataContext.ActualTask.ToList();
            throw new NotImplementedException("ActualTaskDedicController -> Get()");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ActualTask actualTask)
        {
            //throw new NotImplementedException("ActualTaskDedicController -> Put()");

            if (id != actualTask.ActualTaskId)
            {
                return BadRequest();
            }
            if (ApplicationVersion.IsTestVersion()){
                List<ActualTask> list = MoqActualTaskList.GetInstance().GetMoqList();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ActualTaskId == actualTask.ActualTaskId )
                    {
                        //list[i].CareSchedule_Id = actualTask.CareSchedule_Id ;
                        //list[i].Palet_Id = actualTask.Palet_Id ;
                        list[i].RealizationDate = actualTask.RealizationDate ;
                        list[i].User_Id = actualTask.User_Id ;
                    }
                }
            }
            else{

                _dataContext.Entry(actualTask).State = EntityState.Modified;
                try
                {
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (true)//!TodoItemExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return NoContent();
        }
    }
}
