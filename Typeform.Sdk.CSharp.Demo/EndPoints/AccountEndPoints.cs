using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Typeform.Sdk.CSharp.ApiClients;

namespace Typeform.Sdk.CSharp.Demo.EndPoints
{
    internal class AccountEndPoints
    {
        private readonly CreateApiClient _createApiClient;

        public AccountEndPoints(ServiceProvider serviceProvider)
        {
            _createApiClient = serviceProvider.GetService<CreateApiClient>();
        }

        public async Task ExecuteRetrieveAccount()
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF ACCOUNT");
            var results = await _createApiClient.RetrieveAccount();
            HelperMethods.PrintEndOfExecution(results);
        }
    }
}