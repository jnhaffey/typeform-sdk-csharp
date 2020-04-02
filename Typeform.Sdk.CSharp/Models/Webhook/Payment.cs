using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Webhook
{
    public class Payment
    {
        [JsonProperty("amount")] public string Amount { get; set; }

        [JsonProperty("last4")] public string Last4 { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("success")] public bool Success { get; set; }
    }
}