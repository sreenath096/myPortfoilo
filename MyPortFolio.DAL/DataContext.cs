using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models.Entities;

namespace MyPortFolio.DAL
{
    public class SqlServerDataContext : DbContext
    {
        public SqlServerDataContext(DbContextOptions options) : base(options)
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