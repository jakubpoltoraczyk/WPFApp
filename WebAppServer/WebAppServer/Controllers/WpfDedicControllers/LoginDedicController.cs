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
    public class LoginDedicController : ControllerBase
    {
        private OracleDbContext _dataContext;
        public LoginDedicController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }
        /// <summary>
        /// Login method 
        /// </summary>
        /// <returns>if user exist, returns user category id, -1 if not </returns>
        [HttpPost]
        public int LogIn(Login login)                           //returns role_id
        {
            List<Users> tmp;
            if (ApplicationVersion.IsTestVersion()){
                tmp = MoqUsersList.GetInstance().GetMoqList();
            }
            else{
                tmp = _dataContext.Users.ToList();
            }

            //-------------------------------------------------------------poprawic
            foreach (var item in tmp)
            {
                if (item.Mail == login.mail){
                    return item.UserCategory_Id;
                }
            }
            return -1;
        }
    }
}
