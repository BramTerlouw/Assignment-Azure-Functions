using Http_Trigger_Github.DAL;
using Http_Trigger_Github.DAL.Interface;
using Http_Trigger_Github.Model;
using Http_Trigger_Github.Service;
using Http_Trigger_Github.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//IConfigurationRoot configuration = new ConfigurationBuilder()
//    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
//    .AddJsonFile("local.settings.json", false)
//    .Build();

var host = new HostBuilder()
      .ConfigureAppConfiguration(configurationBuilder =>
      {
      })
      .ConfigureFunctionsWorkerDefaults()
      .ConfigureServices(services =>
      {
          services.AddTransient<ISlackService, SlackService>();
          services.AddTransient<ILogService, LogService>();
          services.AddTransient<ILogRepository, LogRepository>();
          //services.AddSingleton<IConfigurationRoot>(configuration);
      })
            .Build();

host.Run();
