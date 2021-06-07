using Microsoft.EntityFrameworkCore;

namespace AspNetCoreCosmos.DataAccess
{
    public class CosmosContext : DbContext
    {
        public CosmosContext(DbContextOptions<CosmosContext> options) : base(options)
        { }
        public DbSet<MyData> MyData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("MyDataStore");

            modelBuilder.Entity<MyData>()
                .ToContainer("MyDataItems");

            modelBuilder.Entity<MyData>()
                .HasPartitionKey(o => o.PartitionKey);

            modelBuilder.Entity<MyData>()
                .Property(d => d.ETag)
                .IsETagConcurrency();
        }
    }
}
