using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Typeform.Sdk.CSharp.ApiClients;
using Typeform.Sdk.CSharp.Models.Shared;

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
                //.MinimumLevel.Debug()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            // Setup Service Provider
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(options => configBuilder.Build())
                .AddLogging(loggerBuilder => loggerBuilder.AddSerilog(dispose: true))
                .BuildServiceProvider();

            // ACCOUNTS
            await ExecuteRetrieveAccount(serviceProvider);

            // WORKSPACES
            await ExecuteRetrieveWorkspaces(serviceProvider);

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        private static async Task ExecuteRetrieveAccount(ServiceProvider serviceProvider)
        {
            var config = serviceProvider.GetService<IConfiguration>();
            var createApiLogger = serviceProvider.GetService<ILogger<CreateApiClient>>();

            PrintStartOfNewExecution("EXECUTING RETRIEVAL OF ACCOUNT");
            var createApiClient = new CreateApiClient(config["Typeform:ApiKey"], createApiLogger);
            var results = await createApiClient.RetrieveAccount();
            PrintEndOfExecution(results);
        }

        private static async Task ExecuteRetrieveWorkspaces(ServiceProvider serviceProvider)
        {
            var config = serviceProvider.GetService<IConfiguration>();
            var createApiLogger = serviceProvider.GetService<ILogger<CreateApiClient>>();

            PrintStartOfNewExecution("EXECUTING RETRIEVAL OF WORKSPACES");
            var createApiClient = new CreateApiClient(config["Typeform:ApiKey"], createApiLogger);
            var results = await createApiClient.RetrieveWorkSpaces(QueryParameters.Create());
            PrintEndOfExecution(results);
        }

        private static void PrintStartOfNewExecution(string title)
        {
            Log.Information("------------- {title} -------------", title.ToUpper());
        }

        private static void PrintEndOfExecution<TData>(TData results)
        {
            Log.Information("{@results}", results);
            Log.Information($"-----------------------------------{Environment.NewLine}");
        }
    }
}