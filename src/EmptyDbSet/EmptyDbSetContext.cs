using DummyModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmptyDbSet
{
    public class EmptyDbSetContext : DbContext
    {
        public EmptyDbSetContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DummyModel>()
                .HasKey(d => d.Id);
        }
    }

    internal class EmptyDbSetContextFactory : IDesignTimeDbContextFactory<EmptyDbSetContext>
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
