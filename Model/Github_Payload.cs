using Http_Trigger_Github.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http_Trigger_Github.Model
{
    public class Github_Payload : IBaseEntity
    {
        public string? commitMadeBy {  get; set; }
        public string? branch { get; set; }
        public string? message { get; set; }
        public string? timestamp { get; set; }
    }
}
