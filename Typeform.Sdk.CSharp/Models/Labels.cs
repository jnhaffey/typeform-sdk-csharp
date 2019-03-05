using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Labels
    {
        [JsonProperty("left")]
        public string Left { get; set; }

        [JsonProperty("right")]
        public string Right { get; set; }

        [JsonProperty("center")]
        public string Center { get; set; }
    }
}