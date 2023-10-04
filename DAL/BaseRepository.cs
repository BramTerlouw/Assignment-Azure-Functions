using Http_Trigger_Github.DAL.Interface;
using Microsoft.Extensions.Configuration;
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
            // Yes i knoww, voor testing purposes, gaat straks naar de configuration
           _storageAccount = CloudStorageAccount.Parse("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;");
            _tableClient = _storageAccount.CreateCloudTableClient();
        }

        public async Task CreateAsync(T entity)
        {
            TableOperation insertOperation = TableOperation.Insert(entity);
            await _table.ExecuteAsync(insertOperation);
        }
    }
}
