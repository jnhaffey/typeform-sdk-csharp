using System;
using Microsoft.Extensions.Logging;
using Typeform.Sdk.CSharp.Abstracts;

namespace Typeform.Sdk.CSharp.ApiClients
{
    public class WebhooksClient : ClientBase
    {
        private readonly ILogger<WebhooksClient> _logger;

        public WebhooksClient(string apiKey = "", ILogger<WebhooksClient> logger = null)
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