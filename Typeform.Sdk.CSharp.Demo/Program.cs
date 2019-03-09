using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Typeform.Sdk.CSharp.ApiClients;
using Typeform.Sdk.CSharp.Models;

namespace Typeform.Sdk.CSharp.Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // Get and Setup Configuration
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.Development.json", true, true);

            // Setup Logging
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            // Setup Service Provider
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(options => configBuilder.Build())
                .AddLogging(loggerBuilder => loggerBuilder.AddSerilog(dispose: true))
                .BuildServiceProvider();

            var config = serviceProvider.GetService<IConfiguration>();
            var createApiLogger = serviceProvider.GetService<ILogger<CreateApiClient>>();

            var createApiClient = new CreateApiClient(config["Typeform:ApiKey"], createApiLogger);
            var results = await createApiClient.RetrieveWorkSpaces(QueryParameters.Create());
            Log.Information("Results: {@results}", results);
        }
    }
}