using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Typeform.Sdk.CSharp.ApiClients;

namespace Typeform.Sdk.CSharp.Demo.EndPoints
{
    internal class AccountEndPoints
    {
        private readonly CreateClient _createClient;

        public AccountEndPoints(ServiceProvider serviceProvider)
        {
            _createClient = serviceProvider.GetService<CreateClient>();
        }

        public async Task ExecuteRetrieveAccount()
        {
            HelperMethods.PrintStartOfNewExecution("EXECUTING RETRIEVAL OF ACCOUNT");
            var results = await _createClient.RetrieveAccount();
            HelperMethods.PrintEndOfExecution(results);
        }
    }
}