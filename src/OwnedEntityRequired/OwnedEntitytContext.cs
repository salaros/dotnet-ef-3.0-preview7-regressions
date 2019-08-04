using System.Linq;
using System.ComponentModel.DataAnnotations;
using DummyModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OwnedEntityRequired
{
    public class OwnedEntitytContext : DbContext
    {
        public OwnedEntitytContext(DbContextOptions options) : base(options)
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

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

    internal class OwnedEntitytContextFactory : IDesignTimeDbContextFactory<OwnedEntitytContext>
    {
        public OwnedEntitytContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OwnedEntitytContext>();
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite("DataSource=:memory:");
            return new OwnedEntitytContext(optionsBuilder.Options);
        }
    }
}
