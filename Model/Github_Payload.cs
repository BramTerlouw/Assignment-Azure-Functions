using Microsoft.WindowsAzure.Storage.Table;

namespace Http_Trigger_Github.Model
{
    public class Github_Payload : TableEntity
    {
        public string? commitMadeBy {  get; set; }
        public string? branch { get; set; }
        public string? message { get; set; }
        public string? committedAt { get; set; }

        public Github_Payload() 
        { 
            
        }

        public Github_Payload(string commitMadeBy, string branch, string message, string committedAt)
        {
            this.commitMadeBy = commitMadeBy;
            this.branch = branch;
            this.message = message;
            this.committedAt = committedAt;
            
            PartitionKey = branch;
            RowKey = $"{branch}{committedAt}";
        }
    }
}
