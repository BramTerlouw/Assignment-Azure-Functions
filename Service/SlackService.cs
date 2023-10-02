using Http_Trigger_Github.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http_Trigger_Github.Service
{
    public class SlackService : ISlackService
    {
        private readonly ILogger _logger;

        public SlackService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SlackService>();
        }

        public async Task SendPayload(string payload)
        {
            string slackWebhookUrl = "https://hooks.slack.com/services/YOUR_WEBHOOK_URL";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                var content = new StringContent(payload, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(slackWebhookUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Payload was send to Slackbot Succesfully!");
                }
                else
                {
                    _logger.LogError("Failed to send payload!");
                }
            }
        }
    }
}
