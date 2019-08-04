using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmptyDbSet
{
    public class EmptyDbService
    {
        protected EmptyDbSetContext db;

        public EmptyDbService(EmptyDbSetContext db)
        {
            this.db = db;
        }

        public async Task<DummyModel> GetOneById(long id)
        {
            return await db.Set<DummyModel>().SingleOrDefaultAsync(d => id == d.Id);
        }
    }

    internal class CatalogDbContextSqliteFactory__ForMigrationsOnly : IDesignTimeDbContextFactory<EmptyDbSetContext>
    {
        public EmptyDbSetContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmptyDbSetContext>();
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=TestDb;Integrated Security=SSPI;");
            return new EmptyDbSetContext(optionsBuilder.Options);
        }
    }

}
