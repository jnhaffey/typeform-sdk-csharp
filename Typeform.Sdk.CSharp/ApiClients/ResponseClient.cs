using System;
using Microsoft.Extensions.Logging;
using Typeform.Sdk.CSharp.Abstracts;

namespace Typeform.Sdk.CSharp.ApiClients
{
    public class ResponseClient : ClientBase
    {
        private readonly ILogger<ResponseClient> _logger;

        public ResponseClient(string apiKey = "", ILogger<ResponseClient> logger = null)
            : base(apiKey)
        {
            _logger = logger;
        }

        public void RetrieveResponses()
        {
            Guard.ForInitializedClient(this);
            throw new NotImplementedException();
        }

        public void DeleteResponses()
        {
            Guard.ForInitializedClient(this);
            throw new NotImplementedException();
        }
    }
}