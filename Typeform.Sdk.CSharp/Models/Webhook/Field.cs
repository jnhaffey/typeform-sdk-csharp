using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Typeform.Sdk.CSharp.Enums;

namespace Typeform.Sdk.CSharp.Models.Webhook
{
    public class Field
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public FieldType Type { get; set; }

        [JsonProperty("ref")] public string Ref { get; set; }

        [JsonProperty("allow_multiple_selections")]
        public bool AllowsMultipleSelections { get; set; }

        [JsonProperty("allow_other_choice")] public bool AllowsOtherChoice { get; set; }
    }
}