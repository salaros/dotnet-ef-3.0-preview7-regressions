using Microsoft.EntityFrameworkCore;
using EmptyDbSet;
using OwnedEntityRequired;
using Xunit;
using DummyModels;
using ProviderNotCleaned;

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
            var options = new DbContextOptionsBuilder<OwnedEntitytContext>();
            options.EnableSensitiveDataLogging();
            options.UseInMemoryDatabase(nameof(OwnedEntityRequired));
            var dbContext = new OwnedEntitytContext(options.Options);

            var model = new DummyModel();
            dbContext.Set<DummyModel>().Add(model);
            dbContext.SaveChanges();

            Assert.True(true); // IMO 2.2.6 should freak out, because OwnedModel.RequiredField is not set

            // I don't know how to test it via DB context's meta-data, please take a look at differences between:
            //    OwnedEntityRequired => Migrations\3.0.0-preview7\20190804135006_Initial.cs
            //    OwnedEntityRequired => Migrations\2.2.6\20190804134956_Initial.cs
            // As you can see in one case RequiredField has 'nullable: true' and in the other 'nullable: false'
            // IMO the latter is correct
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
