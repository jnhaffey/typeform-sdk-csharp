using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Abstracts;

namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class ObjectTypeValuePair : TypeValuePairBase
    {
        /// <summary>
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }
    }
}