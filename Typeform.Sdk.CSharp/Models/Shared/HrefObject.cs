using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class HrefObject
    {
        [JsonProperty("href")]
        public string Url { get; set; }
    }
}