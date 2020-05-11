using System.Data.Entity;
using Domain.Models;

namespace Infra.Data.Context
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("DbConnectionString")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}