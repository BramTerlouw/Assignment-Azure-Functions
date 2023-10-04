using Http_Trigger_Github.DAL.Interface;
using Http_Trigger_Github.Model;
using Http_Trigger_Github.Service.Interface;

namespace Http_Trigger_Github.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logCommitRepository;

        public LogService(ILogRepository logCommitRepository)
        {
            _logCommitRepository = logCommitRepository;
        }

        public async Task Add(Github_Payload payload)
        {
            await _logCommitRepository.CreateAsync(payload);
        }
    }
}
