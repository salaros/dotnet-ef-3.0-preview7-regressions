using Microsoft.EntityFrameworkCore;
using EmptyDbSet;
using OwnedEntityRequired;
using Xunit;
using DummyModels;

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

            var model = new DummyModel { OwnedModel = new OwnedModel() };
            var entry = dbContext.Set<DummyModel>().Add(model);
            dbContext.SaveChanges();

            Assert.True(true); // Save changes on 2.2.6 won't freak out, because required field is not set
        }
            dbContext.Database.EnsureCreated();

            var model = new DummyModel { OwnedModel = new OwnedModel() };
            var entry = dbContext.Set<DummyModel>().Add(model);
            dbContext.SaveChanges();

            Assert.True(model.Id > 0);
        }

        [Fact]
        public void ProviderNotCleaned()
        {

        }
    }
}
