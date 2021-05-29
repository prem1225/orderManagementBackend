using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Data_Access;
using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
   
    [EnableCors("MyPolicy")]
    public class CustomerController : Controller
    {
        orderDbContext dbContext = new orderDbContext();
      [HttpGet]
        public IActionResult findAllCustomer()
        {
            var customerData = (from c in dbContext.customers
                                select c);
            return Ok(customerData);
        }

        // GET: Customer/Details/5
        [HttpGet]
        public IActionResult findCustomerById(String id)
        {

            var customerData = (from c in dbContext.customers
                                where c.CustomerID==id
                                select c);
            return Ok(customerData);
        }
     
        [HttpPost]
        public IActionResult Post([FromBody] Customers customer)
        {
            dbContext.customers.Add(customer);
            dbContext.SaveChanges();
            return Ok("Success");
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

       /* // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
      /*  [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
*/    }
}
