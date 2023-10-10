using Http_Trigger_Github.Model;

namespace Http_Trigger_Github.Service.Interface
{
    public interface ILogService
    {
        Task Add(Github_Payload payload);
        Task<IEnumerable<Github_Payload>> GetAll();

    }
}
