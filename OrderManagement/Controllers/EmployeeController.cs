using Microsoft.AspNetCore.Mvc;
using OrderManagement.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        orderDbContext dbContext = new orderDbContext();


        [HttpGet("getAllEmployee")]
        public IActionResult getEmployee()
        {
            var employee = (from e in dbContext.employees
                            select new { e.FirstName, e.EmployeeID });
            return Ok(employee);
        }

        [HttpGet("getEmployeeNumber")]
        public IActionResult getEmployeeNumber()
        {
            var OD = (from o in dbContext.customers

                      select o.ContactName);
            var countOrder = OD.Count();
            return Ok(countOrder);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
