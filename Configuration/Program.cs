using Http_Trigger_Github.DAL;
using Http_Trigger_Github.DAL.Interface;
using Http_Trigger_Github.Service;
using Http_Trigger_Github.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//IConfigurationRoot configuration = new ConfigurationBuilder()
//    .AddJsonFile("local.settings.json", optional: false)
//    .Build();

var host = new HostBuilder()
      .ConfigureAppConfiguration(configurationBuilder =>
      {
      })
      .ConfigureFunctionsWorkerDefaults()
      .ConfigureServices(services =>
      {
          //services.AddSingleton<IConfiguration>(provider => configuration);
          services.AddTransient<ISlackService, SlackService>();
          services.AddTransient<ILogService, LogService>();
          services.AddTransient<ILogRepository, LogRepository>();
      })
            .Build();

host.Run();
