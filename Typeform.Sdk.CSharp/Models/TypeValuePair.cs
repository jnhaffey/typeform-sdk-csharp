using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class TypeValuePair
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}