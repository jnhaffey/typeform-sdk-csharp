using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Typeform.Sdk.CSharp.ApiClients;

namespace Typeform.Sdk.CSharp.Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            /********************
             * To execute this demo project, you must populate the following variables.
             ********************/
            var apiKey = "";
            var workGroupId = "";

            // Setup Logging
            Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Debug()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            // Setup Service Provider
            var serviceProvider = new ServiceCollection()
                .AddLogging(loggerBuilder => loggerBuilder.AddSerilog(dispose: true))
                .AddSingleton<IConfiguration>(options => new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string> {{"apiKey", apiKey}})
                    .AddEnvironmentVariables()
                    .Build())
                .AddSingleton(options =>
                {
                    var logger = options.GetService<ILogger<CreateApiClient>>();
                    var keyToUse = options.GetService<IConfiguration>()["apiKey"];
                    return new CreateApiClient(keyToUse, logger);
                })
                .BuildServiceProvider();

            // ACCOUNTS
            var accountEndPoints = new AccountEndPoints(serviceProvider);
            await accountEndPoints.ExecuteRetrieveAccount();

            // WORKSPACES
            var workspaceEndPoints = new WorkSpaceEndPoints(serviceProvider);
            await workspaceEndPoints.ExecuteRetrieveWorkspaces();
            await workspaceEndPoints.ExecuteRetrieveWorkspace(workGroupId);

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
}