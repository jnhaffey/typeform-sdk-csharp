using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Webhook;

namespace Typeform.Sdk.CSharp
{
    public class WebhookParser
    {
        public Response Parse(string jsonData)
        {
            var parsed = JsonConvert.DeserializeObject<Response>(jsonData);
            return parsed;
        }
    }
}