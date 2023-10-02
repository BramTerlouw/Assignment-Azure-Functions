using System.Net;
using Http_Trigger_Github.Model;
using Http_Trigger_Github.Service.Interface;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Http_Trigger_Github
{
    public class Github_http_trigger
    {
        private readonly ILogger _logger;
        private readonly ISlackService _slackService;

        public Github_http_trigger(ILoggerFactory loggerFactory, ISlackService slackService)
        {
            _logger = loggerFactory.CreateLogger<Github_http_trigger>();
            _slackService = slackService;
        }

        [Function("Github_http_trigger")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function,"post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");



            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Github_Payload? payload = JsonConvert.DeserializeObject<Github_Payload>(requestBody);



            string serializedPayload = JsonConvert.SerializeObject(payload);
            await _slackService.SendPayload(serializedPayload);



            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            return response;
        }
    }
}
