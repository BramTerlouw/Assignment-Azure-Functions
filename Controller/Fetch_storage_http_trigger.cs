using System.Net;
using Http_Trigger_Github.Model;
using Http_Trigger_Github.Service.Interface;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Http_Trigger_Github.Controller
{
    public class Fetch_storage_http_trigger
    {
        private readonly ILogger _logger;
        private readonly ILogService _logService;

        public Fetch_storage_http_trigger(ILoggerFactory loggerFactory, ILogService logService)
        {
            _logger = loggerFactory.CreateLogger<Fetch_storage_http_trigger>();
            _logService = logService;
        }

        [Function("Fetch_storage_http_trigger")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            HttpResponseData? response;
            try
            {
                IEnumerable<Github_Payload>? data = await _logService.GetAll();
                response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} at {ex.StackTrace}, details: {ex.GetBaseException()}");
                response = req.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return response;
        }
    }
}
