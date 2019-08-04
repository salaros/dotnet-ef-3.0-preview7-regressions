using Microsoft.EntityFrameworkCore;
using EmptyDbSet;
using OwnedEntityRequired;
using Xunit;
using DummyModels;
using ProviderNotCleaned;
using Microsoft.Data.Sqlite;
using System.Diagnostics;

namespace Regressions.Tests
{
    public class InMemoryTests
    {
        [Fact]
        public async void EmptyDbSet()
        {
            var options = new DbContextOptionsBuilder<EmptyDbSetContext>();
            options.EnableSensitiveDataLogging();
            options.UseInMemoryDatabase(nameof(EmptyDbSet));
            var dbContext = new EmptyDbSetContext(options.Options);
            var dbService = new EmptyDbService(dbContext);

            var model = await dbService.GetOneById(1000);

            Assert.Null(model);
        }

        [Fact]
        public void OwnedEntityRequired()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<OwnedEntitytContext>();
            options.EnableSensitiveDataLogging();
            options.UseSqlite(connection);
            var dbContext = new OwnedEntitytContext(options.Options);
            dbContext.Database.EnsureCreated();


            DummyModel model;

            try
            {
                model = new DummyModel { OwnedModel = new OwnedModel() };
                dbContext.Set<DummyModel>().Add(model);
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine(ex.Message);
                model = null;
            }

            Assert.Null(model);
        }

        [Fact]
        public async void ProviderNotCleaned()
        {
            var options = new DbContextOptionsBuilder<ProviderNotCleanedContext>();
            options.EnableSensitiveDataLogging();
            options.UseInMemoryDatabase(nameof(ProviderNotCleaned));
            var dbContext = new ProviderNotCleanedContext(options.Options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var entities = await dbContext.Set<UniqueIdModel>().ToListAsync();

            var model = new DummyModel { OwnedModel = new OwnedModel() };
            var entry = dbContext.Set<DummyModel>().Add(model);
            dbContext.SaveChanges();

            Assert.NotEmpty(entities);
        }
    }
}
