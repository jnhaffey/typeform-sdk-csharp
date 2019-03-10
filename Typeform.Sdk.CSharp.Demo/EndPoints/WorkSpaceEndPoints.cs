using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Typeform.Sdk.CSharp.ApiClients;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Demo.EndPoints
{
    internal class WorkSpaceEndPoints
    {
        private readonly CreateApiClient _createApiClient;

        public WorkSpaceEndPoints(ServiceProvider serviceProvider)
        {
            _createApiClient = serviceProvider.GetService<CreateApiClient>();
        }

        public async Task ExecuteRetrieveWorkspaces()
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF WORKSPACES");
            var results = await _createApiClient.RetrieveWorkSpaces(QueryParametersWithSearch.Create());
            HelperMethods.PrintEndOfExecution(results);
        }

        public async Task ExecuteRetrieveWorkspace(string workGroupdId)
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF SINGLE WORKSPACE");
            var results = await _createApiClient.RetrieveWorkspace(workGroupdId);
            HelperMethods.PrintEndOfExecution(results);
        }
    }
}