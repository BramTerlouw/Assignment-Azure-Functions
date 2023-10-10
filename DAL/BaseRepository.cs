using Http_Trigger_Github.DAL.Interface;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Http_Trigger_Github.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableEntity, new()
    {
        private readonly CloudStorageAccount _storageAccount;
        protected CloudTableClient _tableClient;
        protected CloudTable _table;


        public BaseRepository() : base()
        {
            _storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("CONNSTRING"));
            _tableClient = _storageAccount.CreateCloudTableClient();
        }

        public async Task CreateAsync(T entity)
        {
            TableOperation insertOperation = TableOperation.Insert(entity);
            await _table.ExecuteAsync(insertOperation);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> entities = new List<T>();
            TableQuery<T> query = new TableQuery<T>();

            foreach (T entity in _table.ExecuteQuerySegmentedAsync(query, null).Result)
            {
                entities.Add(entity);
            }

            return Task.FromResult<IEnumerable<T>>(entities);
        }

    }
}
