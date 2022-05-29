using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class MobilivaDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MobilivaCaseDB;Trusted_Connection=True;");
        }

       public DbSet<Order> Orders { get; set; }
       public DbSet<OrderDetail> OrderDetails { get; set; }
       public DbSet<Product> Products { get; set; }
    }
}
