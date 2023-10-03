using Http_Trigger_Github.Service.Interface;
using Microsoft.Extensions.Logging;
using System.Text;

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
            string slackWebhookUrl = ""; // Get from Configurations;

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
