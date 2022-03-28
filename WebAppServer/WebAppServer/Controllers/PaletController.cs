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

namespace WebAppServer.Controllers
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

        [HttpGet]
        public List<Palet> Get()
        {
            if (ApplicationVersion.IsTestVersion())
            {
                return new MoqPaletList().GetMoqList();
            }
            return _dataContext.Palet.ToList();
        }
    }
}
