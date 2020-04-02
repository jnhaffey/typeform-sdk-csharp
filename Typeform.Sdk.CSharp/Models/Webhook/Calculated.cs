using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Webhook
{
    public class Calculated
    {
        [JsonProperty("score")] public int Score { get; set; }
    }
}