using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyPortFolio.DAL
{
    public class DataContextFactory : IDesignTimeDbContextFactory<SqlServerDataContext>
    {
        public SqlServerDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlServerDataContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-UKD9ORK;Initial Catalog=MyPortfolioDb;Integrated Security=True");

            return new SqlServerDataContext(optionsBuilder.Options);
        }
    }
}
