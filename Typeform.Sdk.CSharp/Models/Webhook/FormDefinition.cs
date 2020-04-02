using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Webhook
{
    public class FormDefinition
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("fields")] public List<Field> Fields { get; set; }
    }
}