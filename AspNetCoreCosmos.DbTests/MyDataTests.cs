using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreCosmos.DbTests
{
    public class MyDataTests : IAsyncLifetime
    {

        [Fact]
        public Task MyDataCreate()
        {
            return Task.CompletedTask;
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
