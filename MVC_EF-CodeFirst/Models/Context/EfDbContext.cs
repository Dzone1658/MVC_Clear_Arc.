using MVC_EF_CodeFirst.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MVC_EF_CodeFirst.Models.Context
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("DbConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<EfDbContext>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}