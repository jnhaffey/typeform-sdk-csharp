using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Typeform.Sdk.CSharp.ApiClients;

namespace Typeform.Sdk.CSharp.Demo.EndPoints
{
    internal class ThemeEndPoints
    {
        private CreateApiClient _createApiClient;

        public ThemeEndPoints(ServiceProvider serviceProvider)
        {
            _createApiClient = serviceProvider.GetService<CreateApiClient>();
        }

        public async Task ExecuteRetrieveThemes()
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF THEMES");
            var results = await _createApiClient.RetrieveThemes();
            HelperMethods.PrintEndOfExecution(results);
        }

        public async Task ExecuteRetrieveTheme(string themeId)
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF SINGLE THEME");
            var results = await _createApiClient.RetrieveTheme(themeId);
            HelperMethods.PrintEndOfExecution(results);
        }
    }
}