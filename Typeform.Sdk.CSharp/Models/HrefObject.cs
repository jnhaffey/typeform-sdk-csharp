using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class HrefObject
    {
        [JsonProperty("href")]
        public string Url { get; set; }
    }
}