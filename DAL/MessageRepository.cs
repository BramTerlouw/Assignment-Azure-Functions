using Http_Trigger_Github.DAL.Interface;
using Http_Trigger_Github.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http_Trigger_Github.DAL
{
    public class MessageRepository : EntityBaseRepository<Github_Payload>, IMessageRepository
    {
        public MessageRepository() : base()
        {

        }
    }
}
