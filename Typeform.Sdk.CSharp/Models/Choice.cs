using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Choice
    {
        [JsonProperty("ref")]
        public string Ref { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("attachment")]
        public Attachment Attachment { get; set; }
    }
}