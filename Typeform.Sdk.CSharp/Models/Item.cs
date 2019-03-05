using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models
{
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("last_updated_at")]
        public string LastUpdated { get; set; }

        [JsonProperty("self")]
        public HrefObject HrefObject { get; set; }

        [JsonProperty("_links")]
        public DisplayObject DisplayObject { get; set; }

        [JsonProperty("theme")]
        public HrefObject ThemeUrl { get; set; }
    }
}