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
    public class OrderController : ControllerBase
    {
        orderDbContext dbContext = new orderDbContext();
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        [HttpGet("getAllShipper")]
        public IActionResult getAllShipper()
        {
            var shipper = (from s in dbContext.shippers
                           select s);
            return Ok(shipper);
        }

        [HttpGet("getLastOrderID")]
        public IActionResult getLastOrderID()
        {
            var OD= (from o in dbContext.orders
                     orderby o.OrderID descending 
                     select o.OrderID ).First();
            return Ok(OD);
        }

        [HttpGet("getOrderNumber")]
        public IActionResult getOrderNumber()
        {
            var OD = (from o in dbContext.orders
                     
                      select o.OrderID);
            var countOrder = OD.Count();
            return Ok(countOrder);
        }

        [HttpGet("getProductNumber")]
        public IActionResult getProductNumber()
        {
            var OD = (from o in dbContext.products

                      select o.ProductID);
            var countOrder = OD.Count();
            return Ok(countOrder);
        }

        // POST api/<OrderController>
        [HttpPost("addOrder")]
        public IActionResult addOrder([FromBody] Orders order)
        {
            Orders newOrder = new Orders();
            newOrder.CustomerID = order.CustomerID;
            newOrder.EmployeeID = order.EmployeeID;
   
            newOrder.OrderDate = order.OrderDate;
            newOrder.RequiredDate = order.RequiredDate;
            newOrder.ShippedDate = order.ShippedDate;
            newOrder.ShipVia = order.ShipVia;
            newOrder.Freight = order.Freight;
            newOrder.ShipName = order.ShipName;
            newOrder.ShipAddress = order.ShipAddress;
            newOrder.ShipCity = order.ShipCity;
            newOrder.ShipRegion = order.ShipRegion;
            newOrder.ShipPostalCode = order.ShipPostalCode;
            newOrder.ShipCountry = order.ShipCountry;
            dbContext.orders.Add(newOrder);
            dbContext.SaveChanges();

            return Ok("i am from addOrder");
        }

        [HttpPost("orderDetails")]
        public IActionResult Post([FromBody] OrderDetails orderDetails)
        {

            OrderDetails newOrderDetails = new OrderDetails();
            newOrderDetails.OrderID = orderDetails.OrderID;
            newOrderDetails.ProductID = orderDetails.ProductID;
            newOrderDetails.UnitPrice = orderDetails.UnitPrice;
            newOrderDetails.Quantity = orderDetails.Quantity;
            newOrderDetails.Discount = orderDetails.Discount;

            dbContext.orderDetails.Add(newOrderDetails);
            dbContext.SaveChanges();
            return Ok("order success");
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
