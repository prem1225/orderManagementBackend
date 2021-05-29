using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Data_Access;
using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]

    public class CustomerApiController : ControllerBase
    {
        orderDbContext dbContext = new orderDbContext();
        // GET: api/<CustomerApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerApiController>
        [HttpPost]
        public IActionResult Post([FromBody] Customers customer)
        {
            Customers newCustomers = new Customers();
            newCustomers.CustomerID = customer.CustomerID;
            newCustomers.CompanyName = customer.CompanyName;
            newCustomers.ContactName = customer.ContactName;
            newCustomers.ContactTitle = customer.ContactTitle;
            newCustomers.Address = customer.Address;
            newCustomers.City = customer.City;
            newCustomers.Region = customer.Region;
            newCustomers.PostalCode = customer.PostalCode;
            newCustomers.Country = customer.Country;
            newCustomers.Phone = customer.Phone;
            newCustomers.Fax = customer.Fax;

            dbContext.customers.Add(newCustomers);
            dbContext.SaveChanges();
            return Ok("Success");
        }

        [HttpGet("getCustomerNumber")]
        public IActionResult getCustomerNumber()
        {
            var OD = (from o in dbContext.customers

                      select o.CustomerID);
            var countOrder = OD.Count();
            return Ok(countOrder);
        }

        // PUT api/<CustomerApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
