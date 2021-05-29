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
    public class CategoryController : ControllerBase
    {
        orderDbContext dbContext = new orderDbContext();
        // GET: api/<CategoryController>
        [Route("~/api/getAllCategories")]
        [HttpGet]
        public IActionResult getAllCategories()
        {
            var categories = (from c in dbContext.categories
                              select c);
            return Ok(categories);
        }

        [HttpGet("getCategoryNumber")]
        public IActionResult getCategoryNumber()
        {
            var OD = (from o in dbContext.categories

                      select o.CategoryID);
            var countOrder = OD.Count();
            return Ok(countOrder);
        }

        [HttpGet("ProductByCategory/{id}")]
        public IActionResult findProductByCatrgory(int id)
        {
            var product = (from p in dbContext.products
                           where p.CategoryID == id
                           select p);
            return Ok(product);
        }

        [HttpGet("ProductUnitPrice/{id}")]
        public IActionResult findProductRate(int id)
        {
            var productRate = (from p in dbContext.products
                           where p.ProductID == id
                           select p.UnitPrice);
            return Ok(productRate);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
