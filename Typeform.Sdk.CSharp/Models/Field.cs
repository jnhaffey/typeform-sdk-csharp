using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Field
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ref")]
        public string Ref { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public Property Properties { get; set; }

        [JsonProperty("validations")]
        public Validations Validations { get; set; }

        [JsonProperty("attachment")]
        public AttachmentWithScale AttachmentWithScale { get; set; }
    }
}