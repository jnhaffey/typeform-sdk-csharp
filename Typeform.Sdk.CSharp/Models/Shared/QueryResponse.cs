using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class QueryResponse<TItems>
    {
        public QueryResponse()
        {
            Items = new List<TItems>();
        }

        /// <summary>
        ///     Total number of items in the retrieved collection.
        /// </summary>
        [JsonProperty("total_items")]
        public int TotalItems { get; set; }

        /// <summary>
        ///     Number of pages.
        /// </summary>
        [JsonProperty("page_count")]
        public int PageCount { get; set; }

        /// <summary>
        ///     List of items on the current page.
        /// </summary>
        [JsonProperty("items")]
        public List<TItems> Items { get; set; }
    }
}