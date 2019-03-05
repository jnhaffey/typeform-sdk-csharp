using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Meta
    {
        [JsonProperty("allow_indexing")]
        public bool AllowIndexing { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public HrefObject Image { get; set; }
    }
}