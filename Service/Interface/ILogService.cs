using Http_Trigger_Github.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http_Trigger_Github.Service.Interface
{
    public interface ILogService
    {
        Task Add(Github_Payload payload);

    }
}
