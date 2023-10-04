using Microsoft.WindowsAzure.Storage.Table;

namespace Http_Trigger_Github.DAL.Interface
{
    public interface IBaseRepository<T> where T : TableEntity, new()
    {
        Task CreateAsync(T entity);
    }
}
