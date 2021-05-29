using Microsoft.AspNetCore.Mvc;
using OrderManagement.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    public class LinqAssigmentController : Controller
    {
        orderDbContext dbContext = new orderDbContext();
        public IActionResult Index()
        {

            var data = 
                (from E in dbContext.employees
                        from O in dbContext.orders
                        join C in dbContext.customers on O.CustomerID equals C.CustomerID
                        where E.City == C.City
                        select new { E.FirstName, E.LastName, E.City }).Distinct();
            return Ok(data);
        }
        public IActionResult Index1()
        {
            var data = (from c in dbContext.customers
                        where !dbContext.orders.Any(a=>a.CustomerID==c.CustomerID)
                     

                        select c.ContactName);
               
            return Ok(data);
        }
        public IActionResult Index2()
        {
            var data = (from p in dbContext.products join c in dbContext.categories on p.CategoryID equals
                        c.CategoryID group  p by c.CategoryName into categoryProduct
                        select new
                        {
                            categoryProduct.Key,
                            AveragePrice = categoryProduct.Average(cp => cp.UnitPrice)
                        });

            return Ok(data);
        }
        public IActionResult Index3()
        {
            var data = (from S in dbContext.suppliers join p in dbContext.products
                        on S.SupplierID equals p.SupplierID
                where  dbContext.suppliers.Count()> 3
                        select new { S.SupplierID, S.CompanyName });
            return Ok(data);
        }

        public IActionResult Index4()
        {
            var data =  (from e in dbContext.employees.Where(e => e.City == "London")
                                      from o in dbContext.orders
                                      from od in dbContext.orderDetails
                                      join p in dbContext.products on od.OrderID equals p.ProductID
                                      select new { p.ProductName })
                                      .Union((from c in dbContext.customers
                                              .Where(c => c.City == "London")

                                              from o in dbContext.orders
                                              from od in dbContext.orderDetails
                                              join p in dbContext.products on od.ProductID equals p.ProductID
                                              select new { p.ProductName }).Distinct());
            return Ok(data);
        }



    }
}
