using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using WebAppServer.Contexts;
using WebAppServer.Models;

namespace WebAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly OracleDbContext _dataContext;

        public UsersController(OracleDbContext dbContext)
        {
            _dataContext = dbContext;
        }


        [HttpGet]
        public IEnumerable<WeatherForecast> GetRandom()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
            })
            .ToArray();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsersAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }

        [HttpGet]
        public List<Users> GetUsers()
        {
            return _dataContext.Users.ToList();
        }

        // GET: api/Inspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsersAsync(int id)
        {
            var inspection = await _dataContext.Users.FindAsync(id);

            if (inspection == null)
            {
                return NotFound();
            }

            return inspection;
        }

    }
}
