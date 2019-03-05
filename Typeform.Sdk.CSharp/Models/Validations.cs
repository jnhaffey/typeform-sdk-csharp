using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Validations
    {
        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("max_length")]
        public int MaxLength { get; set; }

        [JsonProperty("min_value")]
        public int MinValue { get; set; }

        [JsonProperty("max_value")]
        public int MaxValue { get; set; }
    }
}