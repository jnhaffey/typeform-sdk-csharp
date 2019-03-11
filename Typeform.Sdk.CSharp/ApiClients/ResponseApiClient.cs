using System;
using Microsoft.Extensions.Logging;
using Typeform.Sdk.CSharp.Abstracts;

namespace Typeform.Sdk.CSharp.ApiClients
{
    public class ResponseApiClient : ApiClientBase
    {
        private readonly ILogger<ResponseApiClient> _logger;

        public ResponseApiClient(string apiKey = "", ILogger<ResponseApiClient> logger = null)
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