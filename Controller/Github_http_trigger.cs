using Google.Protobuf.WellKnownTypes;
using Http_Trigger_Github.Model;
using Http_Trigger_Github.Service.Interface;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

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
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function,"post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if (string.IsNullOrWhiteSpace(requestBody))
            {
                _logger.LogError("Error: Request body was empty!");
            }

            try
            {
                JObject reqBody = JObject.Parse(requestBody);
                Github_Payload payload = new Github_Payload
                (
                    (string)reqBody["commitMadeBy"],
                    (string)reqBody["branch"],
                    (string)reqBody["message"],
                    (string)reqBody["committedAt"]
                );

                SlackMessage message = new SlackMessage(
                    $"Commit made by {payload.commitMadeBy} in branch " +
                    $"{payload.branch}: Message: {payload.message} on " +
                    $"{DateTimeOffset.FromUnixTimeSeconds((long)reqBody["committedAt"]).LocalDateTime}");
                
                string serializedMessage = JsonConvert.SerializeObject(message);
                await _slackService.SendPayload(serializedMessage);
                await _logService.Add(payload);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} at {ex.StackTrace}, details: {ex.GetBaseException()}");
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Message was send and stored succesfully!");
            return response;
        }
    }
}
