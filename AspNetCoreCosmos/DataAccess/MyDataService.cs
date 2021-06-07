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
    }
}
