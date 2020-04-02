using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Typeform.Sdk.CSharp.ApiClients;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Demo.EndPoints
{
    internal class ThemeEndPoints
    {
        private readonly CreateClient _createClient;

        public ThemeEndPoints(ServiceProvider serviceProvider)
        {
            _createClient = serviceProvider.GetService<CreateClient>();
        }

        public async Task ExecuteRetrieveThemes()
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF THEMES");
            var results = await _createClient.RetrieveThemes(QueryParameters.Create());
            HelperMethods.PrintEndOfExecution(results);
        }

        public async Task ExecuteRetrieveTheme(string themeId)
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF SINGLE THEME");
            var results = await _createClient.RetrieveTheme(themeId);
            HelperMethods.PrintEndOfExecution(results);
        }

        //public async Task<string> ExecuteCreateTheme()
        //{
        //    HelperMethods.PrintStartOfNewExecution("EXECUTING CREATION OF THEME");
        //    var themeToCreate = ThemeBuilder.Create("SDK Theme").Build();
        //    var results = await _createClient.CreateTheme(themeToCreate);
        //    HelperMethods.PrintEndOfExecution(results);
        //    return results.Id;
        //}

        //public async Task ExecuteUpdateTheme(string themeId)
        //{
        //    //HelperMethods.PrintStartOfNewExecution("EXECUTING UPDATING OF THEME");
        //    //var themeToCreate = ThemeBuilder.Create("SDK Theme").Build();
        //    //var results = await _createClient.UpdateTheme();
        //    //HelperMethods.PrintEndOfExecution(results);            
        //}

        //public async Task ExecuteDeleteTheme(string themeId)
        //{
        //    HelperMethods.PrintStartOfNewExecution("EXECUTING DELETION OF THEME");
        //    await _createClient.DeleteTheme(themeId);
        //    HelperMethods.PrintEndOfExecution("DELETED");
        //}
    }
}