using Http_Trigger_Github.DAL.Interface;
using Http_Trigger_Github.Model;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Http_Trigger_Github.DAL
{
    public class MessageRepository : IMessageRepository
    {
        private CloudTable? _table;
        private CloudTableClient _tableClient;

        public MessageRepository()
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

        public async Task AddAsync(Github_Payload payload)
        {
            try
            {
                TableOperation tableOperation = TableOperation.Insert(payload);
                TableResult result = await _table.ExecuteAsync(tableOperation);
                Github_Payload? insertedPayload = result.Result as Github_Payload;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IEnumerable<Github_Payload> GetAll()
        {
            List<Github_Payload> orders = new List<Github_Payload>();

            TableQuery<Github_Payload> query = new TableQuery<Github_Payload>()
                   .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "1"));

            foreach (Github_Payload customer in _table.ExecuteQuerySegmentedAsync(query, null).Result)
            {
                orders.Add(customer);
            }
            return orders;
        }
    }
}
