using Http_Trigger_Github.Model;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http_Trigger_Github.DAL.Interface
{
    public interface ILogRepository : IBaseRepository<Github_Payload>
    {
    }
}
