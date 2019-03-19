using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Typeform.Sdk.CSharp.ApiClients;
using Typeform.Sdk.CSharp.Models.Shared;
using Typeform.Sdk.CSharp.Models.Workspaces;
using Typeform.Sdk.CSharp.Modifiers;

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

        public async Task<string> ExecuteCreateWorkspace()
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING CREATION OF WORKSPACE");
            var results = await _createApiClient.CreateWorkspace("SDK Created ViewWorkspace");
            HelperMethods.PrintEndOfExecution(results);
            return results.Id;
        }

        public async Task<ViewWorkspace> ExecuteRetrieveWorkspace(string workspaceId)
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF SINGLE WORKSPACE");
            var results = await _createApiClient.RetrieveWorkspace(workspaceId);
            HelperMethods.PrintEndOfExecution(results);
            return results;
        }

        public async Task ExecuteUpdateWorkspace(ViewWorkspace workspace)
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING UPDATING OF WORKSPACE");
            var workspaceModifier = WorkspaceModifier.Create(workspace)
                .ReplaceName("ViewWorkspace Name Changed from SDK");
            await _createApiClient.UpdateWorkspace(workspaceModifier);
            HelperMethods.PrintEndOfExecution("UPDATED");
        }

        public async Task ExecuteDeleteWorkspace(string workspaceId)
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING DELETION OF WORKSPACE");
            await _createApiClient.DeleteWorkspace(workspaceId);
            HelperMethods.PrintEndOfExecution("DELETED");
        }
    }
}