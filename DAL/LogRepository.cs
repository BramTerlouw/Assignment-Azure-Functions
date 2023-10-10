using Http_Trigger_Github.DAL.Interface;
using Http_Trigger_Github.Model;

namespace Http_Trigger_Github.DAL
{
    public class LogRepository : BaseRepository<Github_Payload>, ILogRepository
    {
        public LogRepository() : base()
        {
            _table = _tableClient.GetTableReference("commitLogs");
            _table.CreateIfNotExistsAsync().GetAwaiter().GetResult();
        }
    }
}
