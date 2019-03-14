using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Typeform.Sdk.CSharp.ApiClients;
using Typeform.Sdk.CSharp.Builders;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Demo.EndPoints
{
    internal class ThemeEndPoints
    {
        private readonly CreateApiClient _createApiClient;

        public ThemeEndPoints(ServiceProvider serviceProvider)
        {
            _createApiClient = serviceProvider.GetService<CreateApiClient>();
        }

        public async Task ExecuteRetrieveThemes()
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF THEMES");
            var results = await _createApiClient.RetrieveThemes(QueryParameters.Create());
            HelperMethods.PrintEndOfExecution(results);
        }

        public async Task ExecuteRetrieveTheme(string themeId)
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF SINGLE THEME");
            var results = await _createApiClient.RetrieveTheme(themeId);
            HelperMethods.PrintEndOfExecution(results);
        }

        public async Task<string> ExecuteCreateTheme()
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING CREATION OF THEME");
            var themeToCreate = ThemeBuilder.Create("SDK Theme").Build();
            var results = await _createApiClient.CreateTheme(themeToCreate);
            HelperMethods.PrintEndOfExecution(results);
            return results.Id;
        }

        public async Task ExecuteUpdateTheme(string themeId)
        {
            //HelperMethods.PrintStartOfNewExecution("EXECUTING UPDATING OF THEME");
            //var themeToCreate = ThemeBuilder.Create("SDK Theme").Build();
            //var results = await _createApiClient.UpdateTheme();
            //HelperMethods.PrintEndOfExecution(results);            
        }

        public async Task ExecuteDeleteTheme(string themeId)
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING DELETION OF THEME");
            await _createApiClient.DeleteTheme(themeId);
            HelperMethods.PrintEndOfExecution("DELETED");
        }
    }
}