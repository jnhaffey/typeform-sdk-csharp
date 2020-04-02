using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Webhook
{
    public class Choices
    {
        [JsonProperty("labels")] public List<string> Labels { get; set; }

        [JsonProperty("other")] public string Other { get; set; }
    }
}