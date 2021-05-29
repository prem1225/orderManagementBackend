using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Data_Access
{
  
    public class orderDbContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0GH5FP3;Initial Catalog=Northwind;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
            .ToTable("Categories");
            modelBuilder.Entity<Categories>()
            .HasKey(category => category.CategoryID);

            modelBuilder.Entity<Customers>()
           .ToTable("Customers");
            modelBuilder.Entity<Customers>()
            .HasKey(c => c.CustomerID);

            modelBuilder.Entity<Employees>()
           .ToTable("Employees");
            modelBuilder.Entity<Employees>()
            .HasKey(e => e.EmployeeID);

            modelBuilder.Entity<Orders>()
           .ToTable("Orders");
            modelBuilder.Entity<Orders>()
            .HasKey(o => o.OrderID);

            modelBuilder.Entity<Products>()
           .ToTable("Products");
            modelBuilder.Entity<Products>()
            .HasKey(p => p.ProductID);

            modelBuilder.Entity<OrderDetails>()
           .ToTable("Order Details");
            modelBuilder.Entity<OrderDetails>()
            .HasKey(ord=>ord.OrderID);

            modelBuilder.Entity<Suppliers>()
          .ToTable("Suppliers");
            modelBuilder.Entity<Suppliers>()
            .HasKey(sup => sup.SupplierID);

            modelBuilder.Entity<Users>()
                .ToTable("User");
            modelBuilder.Entity<Users>()
            .HasKey(sup => sup.userID);

            modelBuilder.Entity<Shipper>()
                .ToTable("Shippers");
            modelBuilder.Entity<Shipper>()
            .HasKey(sup => sup.ShipperID);
        }
        public DbSet<Customers> customers { get; set; }

        public DbSet<Products> products { get; set; }

        public DbSet<Categories> categories { get; set; }

        public DbSet<Employees> employees { get; set; }

        public DbSet<OrderDetails> orderDetails { get; set; }

        public DbSet<Orders> orders { get; set; }

        public DbSet<Suppliers> suppliers { get; set; }
        public DbSet<Users> user { get; set; }

        public DbSet<Shipper> shippers { get; set; }



    }
}

 