using Http_Trigger_Github.DAL.Interface;
using Http_Trigger_Github.Model.Interface;
using Http_Trigger_Github.Service;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http_Trigger_Github.DAL
{
    public class EntityBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity, new()
    {
        private CloudTable? _table;
        private CloudTableClient _tableClient;

        public EntityBaseRepository() : base()
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;");
            _tableClient = cloudStorageAccount.CreateCloudTableClient();
        }

        public async Task CreateTable(string tableName)
        {
            _table = _tableClient.GetTableReference(tableName);
            try
            {
                var result = await _table.CreateIfNotExistsAsync();
            }
            catch (StorageException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Enumerable.Empty<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            return;
        }
    }
}
