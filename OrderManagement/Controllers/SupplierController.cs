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
   
    public class SupplierController : ControllerBase
    {
        orderDbContext dbContext = new orderDbContext();
        // GET: api/<SupplierController>
        [HttpGet("Suppliers")]
        public IActionResult findAllSuppliers()
        {
            var data = (from s in dbContext.suppliers
                        select s);
            return Ok(data);
        }

        // GET api/<SupplierController>/5
        [HttpGet("findSupplierById/{id}")]
        public IActionResult findSupplierById(int id)
        {
            var supplier = (from s in dbContext.suppliers where
              s.SupplierID == id select s);
            return Ok(supplier);
        }

        [HttpGet("getSupplierNumber")]
        public IActionResult getOrderNumber()
        {
            var OD = (from o in dbContext.suppliers

                      select o.SupplierID);
            var countOrder = OD.Count();
            return Ok(countOrder);
        }

        [HttpGet("getShipperNumber")]
        public IActionResult getShipperNumber()
        {
            var OD = (from o in dbContext.shippers

                      select o.ShipperID);
            var countOrder = OD.Count();
            return Ok(countOrder);
        }
        // POST api/<SupplierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
