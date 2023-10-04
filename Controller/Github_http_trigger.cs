using System.Net;
using System.Runtime.Serialization;
using Google.Protobuf.WellKnownTypes;
using Http_Trigger_Github.Model;
using Http_Trigger_Github.Service.Interface;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Newtonsoft.Json;

namespace Http_Trigger_Github
{
    public class Github_http_trigger
    {
        private readonly ILogger _logger;
        private readonly ISlackService _slackService;
        private readonly ILogService _logService;

        public Github_http_trigger(ILoggerFactory loggerFactory, ISlackService slackService, ILogService logService)
        {
            _logger = loggerFactory.CreateLogger<Github_http_trigger>();
            _slackService = slackService;
            _logService = logService;
        }

        [Function("Github_http_trigger")]
        public async Task Run([HttpTrigger(AuthorizationLevel.Function,"post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if (string.IsNullOrWhiteSpace(requestBody))
            {
                _logger.LogError("Error: Request body was empty!");
            }

            try
            {
                Github_Payload? payload = JsonConvert.DeserializeObject<Github_Payload>(requestBody);

                SlackMessage message = new SlackMessage($"Commit made by {payload.commitMadeBy} in branch {payload.branch}: Message: {payload.message} on {payload.committedAt}");
                string serializedMessage = JsonConvert.SerializeObject(message);

                await _slackService.SendPayload(serializedMessage);
                await _logService.Add(payload);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
            }
        }
    }
}
