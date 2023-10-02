using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http_Trigger_Github.Service.Interface
{
    public interface ISlackService
    {
        Task SendPayload(string payload);
    }
}
