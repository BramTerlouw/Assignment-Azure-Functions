using Http_Trigger_Github.DAL.Interface;
using Http_Trigger_Github.Model;
using Http_Trigger_Github.Service.Interface;
using Microsoft.Extensions.Logging;

namespace Http_Trigger_Github.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task Add(Github_Payload payload)
        {
            await _logRepository.CreateAsync(payload);
        }
    }
}
