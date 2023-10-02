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
            string slackWebhookUrl = "https://hooks.slack.com/services/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";

            using (HttpClient client = new HttpClient())
            {
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
