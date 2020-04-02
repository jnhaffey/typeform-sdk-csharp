using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Typeform.Sdk.CSharp.ApiClients;
using Typeform.Sdk.CSharp.Models.Shared;
using Typeform.Sdk.CSharp.Models.Workspaces;

namespace Typeform.Sdk.CSharp.Demo.EndPoints
{
    internal class WorkSpaceEndPoints
    {
        private readonly CreateClient _createClient;

        public WorkSpaceEndPoints(ServiceProvider serviceProvider)
        {
            _createClient = serviceProvider.GetService<CreateClient>();
        }

        public async Task ExecuteRetrieveWorkspaces()
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF WORKSPACES");
            var results = await _createClient.RetrieveWorkSpaces(QueryParametersWithSearch.Create());
            HelperMethods.PrintEndOfExecution(results);
        }

        public async Task<string> ExecuteCreateWorkspace()
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING CREATION OF WORKSPACE");
            var results = await _createClient.CreateWorkspace("SDK Created ViewWorkspace");
            HelperMethods.PrintEndOfExecution(results);
            return results.Id;
        }

        public async Task<ViewWorkspace> ExecuteRetrieveWorkspace(string workspaceId)
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF SINGLE WORKSPACE");
            var results = await _createClient.RetrieveWorkspace(workspaceId);
            HelperMethods.PrintEndOfExecution(results);
            return results;
        }

        //public async Task ExecuteUpdateWorkspace(ViewWorkspace workspace)
        //{
        //    HelperMethods.PrintStartOfNewExecution("EXECUTING UPDATING OF WORKSPACE");
        //    var workspaceModifier = WorkspaceModifier.Create(workspace)
        //        .ReplaceName("ViewWorkspace Name Changed from SDK");
        //    await _createClient.UpdateWorkspace(workspaceModifier);
        //    HelperMethods.PrintEndOfExecution("UPDATED");
        //}

        public async Task ExecuteDeleteWorkspace(string workspaceId)
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING DELETION OF WORKSPACE");
            await _createClient.DeleteWorkspace(workspaceId);
            HelperMethods.PrintEndOfExecution("DELETED");
        }
    }
}