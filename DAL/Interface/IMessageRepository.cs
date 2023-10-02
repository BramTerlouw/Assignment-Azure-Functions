using Http_Trigger_Github.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http_Trigger_Github.DAL.Interface
{
    public interface IMessageRepository
    {
        Task CreateTable(string tableName);
        IEnumerable<Github_Payload> GetAll();
        Task AddAsync(Github_Payload payload);
    }
}
