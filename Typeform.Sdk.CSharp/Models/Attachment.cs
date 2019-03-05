using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Attachment
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("href")]
        public string Url { get; set; }
    }
}