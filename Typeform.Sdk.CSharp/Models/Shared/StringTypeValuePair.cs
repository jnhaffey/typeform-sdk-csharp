using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Abstracts;

namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class StringTypeValuePair : TypeValuePairBase
    {
        /// <summary>
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}