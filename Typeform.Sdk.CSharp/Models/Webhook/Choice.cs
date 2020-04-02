using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Webhook
{
    public class Choice
    {
        [JsonProperty("label")] public string Label { get; set; }

        [JsonProperty("other")] public string Other { get; set; }
    }
}