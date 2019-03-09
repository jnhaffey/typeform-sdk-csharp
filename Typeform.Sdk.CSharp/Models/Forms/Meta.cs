using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class Meta
    {
        public Meta()
        {
            AllowIndexing = false;
        }

        /// <summary>
        ///     True to allow search engines to index your typeform. Otherwise, false.
        /// </summary>
        [JsonProperty("allow_indexing")]
        public bool AllowIndexing { get; set; }

        /// <summary>
        ///     Description for search engines to display for your typeform.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     URL of image for search engines to display for your typeform.
        /// </summary>
        [JsonProperty("image")]
        public HrefObject Image { get; set; }
    }
}