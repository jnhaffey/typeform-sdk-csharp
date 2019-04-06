using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class Price
    {
        /// <summary>
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}