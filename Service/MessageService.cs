using Http_Trigger_Github.DAL.Interface;
using Http_Trigger_Github.Model;
using Http_Trigger_Github.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http_Trigger_Github.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
            _messageRepository.CreateTable("payloads");
        }

        public async Task Add(Github_Payload payload)
        {
            await _messageRepository.AddAsync(payload);
        }

        public IEnumerable<Github_Payload> GetAll()
        {
            return _messageRepository.GetAll();
        }
    }
}
