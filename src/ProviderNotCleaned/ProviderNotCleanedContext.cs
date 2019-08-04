using DummyModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProviderNotCleaned
{
    public class ProviderNotCleanedContext : DbContext
    {
        public ProviderNotCleanedContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DummyModel>()
                .HasKey(d => d.Id);

            modelBuilder
                .Entity<DummyModel>()
                .OwnsOne(d => d.OwnedModel);
        }
    }

    internal class ProviderNotCleanedContextFactory : IDesignTimeDbContextFactory<ProviderNotCleanedContext>
    {
        public ProviderNotCleanedContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProviderNotCleanedContext>();
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=TestDb;Integrated Security=SSPI;");
            return new ProviderNotCleanedContext(optionsBuilder.Options);
        }
    }
}
