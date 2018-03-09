using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerWebApiApplication.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base() { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}