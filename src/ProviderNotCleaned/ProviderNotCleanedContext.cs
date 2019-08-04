using System;
using DummyModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            modelBuilder
                .Entity<UniqueIdModel>()
                .HasKey(u => u.UniqueId);

            modelBuilder
                .Entity<UniqueIdModel>()
                .HasIndex(u => u.UniqueId)
                .IsUnique();

            modelBuilder
                .Entity<UniqueIdModel>()
                .Property(u => u.UniqueId)
                .HasConversion(new GuidToStringConverter());

            modelBuilder
                .Entity<UniqueIdModel>()
                .HasData(
                    new UniqueIdModel { UniqueId = new Guid("8ac4b5f4-eac9-4fc7-b7a4-6a3ba0ae3556") },
                    new UniqueIdModel { UniqueId = new Guid("509f3452-649f-4255-abb4-3608f3aa25db") }
                );
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
