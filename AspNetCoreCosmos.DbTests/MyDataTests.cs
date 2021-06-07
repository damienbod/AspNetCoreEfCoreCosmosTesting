using AspNetCoreCosmos.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreCosmos.DbTests
{
    public class MyDataTests : IAsyncLifetime
    {
        private ServiceProvider _serviceProvider;

        public ServiceProvider ServiceProvider { get; private set; }

        [Fact]
        public async Task MyDataCreateAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Arrange
                var myData = new MyData
                {
                    Id = Guid.NewGuid().ToString(),
                    PartitionKey = "Test",
                    Name = "testData",
                    Description = "test description"
                };

                var myDataService = scope.ServiceProvider.GetService<MyDataService>();
                myDataService.EnsureCreated();

                // Act
                await myDataService.CreateAsync(myData);
                var first = await myDataService.Get(myData.Id);

                // Arrange
                Assert.Equal(myData.Id, first.Id);
            }
        }

        public Task InitializeAsync()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<CosmosContext>(options =>
            {
                options.UseCosmos(
                   "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                    databaseName: "MyDataDb"
               );
            });

            serviceCollection.AddScoped<MyDataService>();

            _serviceProvider = serviceCollection.BuildServiceProvider();

            return Task.CompletedTask;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
