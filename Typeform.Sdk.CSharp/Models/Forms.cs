using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Forms
    {
        public Forms()
        {
            Items = new List<Item>();
        }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }

        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}