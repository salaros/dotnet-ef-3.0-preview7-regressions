using Microsoft.EntityFrameworkCore;

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
}
