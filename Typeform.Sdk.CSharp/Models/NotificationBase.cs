using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public abstract class NotificationBase
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}