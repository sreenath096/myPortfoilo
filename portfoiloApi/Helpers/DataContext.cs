using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using portfoiloApi.Entities;

namespace portfoiloApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // use when we use in memory database
            //optionsBuilder.UseInMemoryDatabase("TestDb");
        }

        public DbSet<User> Users { get; set; }
    }
}