using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EmptyDbSet.Tests
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

        }

        [Fact]
        public void ProviderNotCleaned()
        {

        }
    }
}
