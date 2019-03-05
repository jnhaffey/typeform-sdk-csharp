using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Fields
{
    public class Labels
    {
        /// <summary>
        ///     Label to help respondents understand the scale's range. Available for opinion_scale and rating types.
        /// </summary>
        [JsonProperty("left")]
        public string Left { get; set; }

        /// <summary>
        ///     Text of the right-aligned label for the scale.
        /// </summary>
        [JsonProperty("right")]
        public string Right { get; set; }

        /// <summary>
        ///     Text of the center-aligned label for the scale.
        /// </summary>
        [JsonProperty("center")]
        public string Center { get; set; }
    }
}