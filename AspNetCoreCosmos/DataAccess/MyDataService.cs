using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCosmos.DataAccess
{
    public class MyDataService
    {
        private CosmosContext _cosmosContext;

        public MyDataService(CosmosContext cosmosContext)
        {
            _cosmosContext = cosmosContext;
        }

        public void EnsureCreated()
        {
            _cosmosContext.Database.EnsureCreated();
        }

        public async Task CreateAsync(MyData myData)
        {
            await _cosmosContext.MyData.AddAsync(myData);
            await _cosmosContext.SaveChangesAsync(false);
        }

        public async Task<MyData> Get(string id)
        {
            return await _cosmosContext.MyData.FirstAsync(d => d.Id == id);
        }

        public async Task<IList<MyData>> NameContains(string name)
        {
            return await _cosmosContext.MyData.Where(d => d.Name.Contains(name)).ToListAsync();
        }
    }
}
