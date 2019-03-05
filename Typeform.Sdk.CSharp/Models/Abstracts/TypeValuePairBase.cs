using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Abstracts
{
    public abstract class TypeValuePairBase
    {
        /// <summary>
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}