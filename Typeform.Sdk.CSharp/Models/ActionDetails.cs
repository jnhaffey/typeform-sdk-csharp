using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class ActionDetails
    {
        [JsonProperty("to")]
        public TypeValuePair ActionTo { get; set; }

        [JsonProperty("target")]
        public TypeValuePair ActionTarget { get; set; }

        [JsonProperty("value")]
        public TypeValuePair ActionValue { get; set; }
    }
}