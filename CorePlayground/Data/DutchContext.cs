using CorePlayground.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePlayground.Data
{
    public class DutchContext : IdentityDbContext<StoreUser>
    {
        public DutchContext(DbContextOptions<DutchContext> contextOptions) : base(contextOptions)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
