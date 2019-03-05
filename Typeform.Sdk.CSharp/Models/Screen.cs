using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Screen<TProperties>
    {
        [JsonProperty("ref")]
        public string Ref { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("properties")]
        public TProperties Properties { get; set; }

        [JsonProperty("attachment")]
        public AttachmentWithScale AttachmentWithScale { get; set; }
    }
}