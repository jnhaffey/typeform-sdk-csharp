using System;
using Microsoft.Extensions.Logging;
using Typeform.Sdk.CSharp.Abstracts;

namespace Typeform.Sdk.CSharp.ApiClients
{
    public class WebhooksApiClient : ApiClientBase
    {
        private readonly ILogger<WebhooksApiClient> _logger;

        public WebhooksApiClient(string apiKey = "", ILogger<WebhooksApiClient> logger = null)
            : base(apiKey)
        {
            _logger = logger;
        }

        public void RetrieveWebhooks()
        {
            Guard.ForInitializedClient(this);
            throw new NotImplementedException();
        }

        public void RetrieveWebhook()
        {
            Guard.ForInitializedClient(this);
            throw new NotImplementedException();
        }

        public void CreateOrUpdateWebhook()
        {
            Guard.ForInitializedClient(this);
            throw new NotImplementedException();
        }

        public void DeleteWebhook()
        {
            Guard.ForInitializedClient(this);
            throw new NotImplementedException();
        }
    }
}