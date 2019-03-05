using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class DisplayObject
    {
        [JsonProperty("display")]
        public string Url { get; set; }
    }
}